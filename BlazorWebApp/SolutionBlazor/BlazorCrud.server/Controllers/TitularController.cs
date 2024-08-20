using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using BlazorCrud.shared;
using Microsoft.EntityFrameworkCore;
using BlazorCrud.server.Models;


namespace BlazorCrud.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitularController : ControllerBase
    {
        private readonly ProyectoDbContext _dbContext;

        public TitularController(ProyectoDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<TitularDTO>>();
            var listaTitularDTO = new List<TitularDTO>();

            try
            {
                foreach (var item in await _dbContext.Titulares.ToListAsync())
                {
                    listaTitularDTO.Add(new TitularDTO
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                    });
                }
                responseApi.Success = true;
                responseApi.Value = listaTitularDTO;

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

