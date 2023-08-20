using AutoMapper;
using DistribuidoraALM.DataAccess;
using DistribuidoraALM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DistribuidoraALM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProveedorController : ControllerBase
    {        
        private readonly ISupplierRepository _repository;

        public ProveedorController(DistribuidoraAlmContext ctx, 
                                  ISupplierRepository repository)
        {
            _repository = repository;
        }
        // GET: api/<ProveedorController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listProveedores = await _repository.GetSuppliers();
                return Ok(listProveedores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProveedorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var proveedor = await _repository.GetSupplierById(id);
                return Ok(proveedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
