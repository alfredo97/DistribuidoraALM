using AutoMapper;
using DistribuidoraALM.DataAccess;
using DistribuidoraALM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DistribuidoraALM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoProductoController : ControllerBase
    {
        private readonly DistribuidoraAlmContext _ctx;
        
        private readonly IProductTypeRepository _repository;

        public TipoProductoController(DistribuidoraAlmContext ctx, 
                                  IProductTypeRepository repository)
        {
            _ctx = ctx;
            _repository = repository;
        }
        // GET: api/<TipoProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listTiposProducto = await _repository.GetProductTypes();
                return Ok(listTiposProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<TipoProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var tipoProducto = await _repository.GetProductTypeById(id);
                return Ok(tipoProducto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
