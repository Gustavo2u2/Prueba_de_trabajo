using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using BlazorCrud.server.Models;
using BlazorCrud.shared;


namespace BlazorCrud.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {
        private readonly ProyectoDbContext _dbContext;

        public TarjetaController(ProyectoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<TarjetaDTO>>();
            var listaTarjetaDTO = new List<TarjetaDTO>();

            try
            {
                foreach (var item in await _dbContext.Tarjetas.Include(t => t.IdTitularNavigation).ToListAsync())
                {
                    listaTarjetaDTO.Add(new TarjetaDTO
                    {
                        Id = item.Id,
                        IdTitular = item.IdTitular,
                        NumeroTarjeta = item.NumeroTarjeta,
                        SaldoTotal = item.SaldoTotal,
                        SaldoMin = item.SaldoMin,
                        Interes = item.Interes,
                        PagoMin = item.PagoMin,
                        TotalAPagar = item.TotalAPagar,
                        InteresBono = item.InteresBono,
                        Titular = new TitularDTO
                        {
                            Id = item.IdTitularNavigation.Id,
                            Nombre = item.IdTitularNavigation.Nombre,
                            Apellido = item.IdTitularNavigation.Apellido
                        }
                    });
                }
                responseApi.Success = true;
                responseApi.Value = listaTarjetaDTO;

            }
            catch (Exception ex)
            {

                responseApi.Success = false;
                responseApi.Mesaje = ex.Message;

            }

            return Ok(responseApi);
        }


        [HttpGet]
        [Route("ListaCuenta")]
        public async Task<IActionResult> ListaCuenta()
        {
            var responseApi = new ResponseAPI<List<TarjetaDTO>>();
            var TarjetaDTO = new List<TarjetaDTO>();

            try
            {
                foreach (var item in await _dbContext.Tarjetas.Include(t => t.IdTitularNavigation).ToListAsync())
                {
                    TarjetaDTO.Add(new TarjetaDTO
                    {
                        Id = item.Id,
                        IdTitular = item.IdTitular,
                        NumeroTarjeta = item.NumeroTarjeta,
                        Titular = new TitularDTO
                        {
                            Id = item.IdTitularNavigation.Id,
                            Nombre = item.IdTitularNavigation.Nombre,
                            Apellido = item.IdTitularNavigation.Apellido
                        }
                    });
                }
                responseApi.Success = true;
                responseApi.Value = TarjetaDTO;

            }
            catch (Exception ex)
            {

                responseApi.Success = false;
                responseApi.Mesaje = ex.Message;

            }

            return Ok(responseApi);
        }


        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<TarjetaDTO>();
            var TarjetaDTO = new TarjetaDTO();

            try
            {
                var Titular = new TitularDTO();
                var dbTitular = await _dbContext.Titulares.FirstOrDefaultAsync(x => x.Id == id);
                var dbTarjeta = await _dbContext.Tarjetas.FirstOrDefaultAsync(x => x.Id == id);

                if (dbTarjeta != null)
                {
                    TarjetaDTO.Id = dbTarjeta.Id;
                    TarjetaDTO.IdTitular = dbTarjeta.IdTitular;
                    TarjetaDTO.NumeroTarjeta = dbTarjeta.NumeroTarjeta;



                    responseApi.Success = true;
                    responseApi.Value = TarjetaDTO;

                }
                else
                {

                    responseApi.Success = false;
                    responseApi.Mesaje = "No se encontro tarjeta";
                }


            }
            catch (Exception ex)
            {

                responseApi.Success = false;
                responseApi.Mesaje = ex.Message;

            }

            return Ok(responseApi);
        }


        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseAPI<int>();

            try
            {

                var dbTarjeta = await _dbContext.Tarjetas.FirstOrDefaultAsync(e => e.Id == id);


                if (dbTarjeta != null)
                {

                    _dbContext.Tarjetas.Remove(dbTarjeta);
                    await _dbContext.SaveChangesAsync();


                    responseApi.Success = true;
                }
                else
                {
                    responseApi.Success = false;
                    responseApi.Mesaje = "Tarjeta no encontrada";

                }

            }
            catch (Exception ex)
            {

                responseApi.Success = false;
                responseApi.Mesaje = ex.Message;

            }

            return Ok(responseApi);
        }



    }
}
