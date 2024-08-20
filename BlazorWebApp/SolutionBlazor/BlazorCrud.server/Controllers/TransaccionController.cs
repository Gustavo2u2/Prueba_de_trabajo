using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using BlazorCrud.server.Models;
using BlazorCrud.shared;


namespace BlazorCrud.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        private readonly ProyectoDbContext _dbContext;

        public TransaccionController(ProyectoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("ListaHeader")]
        public async Task<IActionResult> ListaHeader()
        {
            var responseApi = new ResponseAPI<List<TransaccionDTO>>();
            var listaTransaccionDTO = new List<TransaccionDTO>();

            try
            {
                foreach (var item in await _dbContext.Transacciones.Include(m => m.IdMovimientoNavigation).Include(t => t.IdTarjetaNavigation).ToListAsync())
                {
                    listaTransaccionDTO.Add(new TransaccionDTO
                    {
                        Id = item.Id,
                        IdMovimiento = item.IdMovimiento,
                        IdTarjeta = item.IdTarjeta,
                        Fecha = item.Fecha,
                        Tarjeta = new TarjetaDTO
                        {
                            Id = item.IdTarjetaNavigation.Id,
                            IdTitular = item.IdTarjetaNavigation.IdTitular,
                            NumeroTarjeta = item.IdTarjetaNavigation.NumeroTarjeta,
                            

                        },
                        
                    });
                }
                responseApi.Success = true;
                responseApi.Value = listaTransaccionDTO;

            }
            catch (Exception ex)
            {

                responseApi.Success = false;
                responseApi.Mesaje = ex.Message;

            }

            return Ok(responseApi);
        }



        [HttpGet]
        [Route("ListaBody")]
        public async Task<IActionResult> ListaBody()
        {
            var responseApi = new ResponseAPI<List<TransaccionDTO>>();
            var listaTransaccionDTO = new List<TransaccionDTO>();

            try
            {
                foreach (var item in await _dbContext.Transacciones.Include(m => m.IdMovimientoNavigation).Include(t => t.IdTarjetaNavigation).ToListAsync())
                {
                    listaTransaccionDTO.Add(new TransaccionDTO
                    {
                        Id = item.Id,
                        IdMovimiento = item.IdMovimiento,
                        IdTarjeta = item.IdTarjeta,
                        Fecha = item.Fecha,
                        Movimiento = new MovimientoDTO
                        {
                            Id = item.IdMovimientoNavigation.Id,
                            Monto = item.IdMovimientoNavigation.Monto,
                            Descripcion = item.IdMovimientoNavigation.Descripcion,
                            TipoMov = item.IdMovimientoNavigation.TipoMov,
                            Fecha = item.IdMovimientoNavigation.Fecha,
                            NumeroAutorizacion = item.IdMovimientoNavigation.NumeroAutorizacion,
                        }
                


                    });
                }
                responseApi.Success = true;
                responseApi.Value = listaTransaccionDTO;

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

