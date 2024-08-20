using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using BlazorCrud.server.Models;
using BlazorCrud.shared;
using System;

namespace BlazorCrud.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimientoController : ControllerBase
    {
        private readonly ProyectoDbContext _dbContext;

        public MovimientoController(ProyectoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<MovimientoDTO>>();
            var listaMovimientoDTO = new List<MovimientoDTO>();

            try
            {
                foreach (var item in await _dbContext.Movimientos.ToListAsync())
                {
                    listaMovimientoDTO.Add(new MovimientoDTO
                    {
                        Id = item.Id,
                        Monto = item.Monto,
                        Descripcion = item.Descripcion,
                        TipoMov = item.TipoMov,
                        NumeroAutorizacion = item.NumeroAutorizacion,
                        Fecha = item.Fecha,

                    });
                }
                responseApi.Success = true;
                responseApi.Value = listaMovimientoDTO;

            }
            catch (Exception ex)
            {

                responseApi.Success = false;
                responseApi.Mesaje = ex.Message;

            }

            return Ok(responseApi);
        }


        [HttpPost]
        [Route("Pago")]
        public async Task<IActionResult> Pago(MovimientoDTO tipomov)
        {
            var responseApi = new ResponseAPI<int>();
            

            try
            {
                Random random = new Random();
                int num = random.Next(1254, 988854);

                tipomov.TipoMov = 1;
                tipomov.NumeroAutorizacion = num;

                var dbMovimiento = new Movimiento
                {
                    Id = tipomov.Id,
                    Monto = tipomov.Monto,
                    Descripcion = tipomov.Descripcion,
                    TipoMov = tipomov.TipoMov,
                    NumeroAutorizacion = tipomov.NumeroAutorizacion,
                    Fecha = tipomov.Fecha,


                   
                };

                _dbContext.Movimientos.Add(dbMovimiento);
                await _dbContext.SaveChangesAsync();
                responseApi.Success = true;
                responseApi.Value = dbMovimiento.Id;

                if (dbMovimiento.Id != 0)
                {
                    responseApi.Success = true;
                    responseApi.Value = dbMovimiento.Id;
                }
                else
                {
                    responseApi.Success = false;
                    responseApi.Mesaje = "No se guardo pago";

                }

            }
            catch (Exception ex)
            {

                responseApi.Success = false;
                responseApi.Mesaje = ex.Message;

            }

            return Ok(responseApi);
        }



        [HttpPost]
        [Route("Compra")]
        public async Task<IActionResult> Compra(MovimientoDTO tipomov)
        {
            var responseApi = new ResponseAPI<int>();


            try
            {
             

                Random random = new Random();
                int num = random.Next(1254, 988854);

                tipomov.TipoMov = 2;
                tipomov.NumeroAutorizacion = num;

                var dbMovimiento = new Movimiento
                {
                    Id = tipomov.Id,
                    Monto = tipomov.Monto,
                    Descripcion = tipomov.Descripcion,
                    TipoMov = tipomov.TipoMov,
                    NumeroAutorizacion = tipomov.NumeroAutorizacion,
                    Fecha = tipomov.Fecha,



                };

                _dbContext.Movimientos.Add(dbMovimiento);
                await _dbContext.SaveChangesAsync();
                responseApi.Success = true;
                responseApi.Value = dbMovimiento.Id;

                if (dbMovimiento.Id != 0)
                {
                    responseApi.Success = true;
                    responseApi.Value = dbMovimiento.Id;
                }
                else
                {
                    responseApi.Success = false;
                    responseApi.Mesaje = "No se guardo pago";

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
