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
    
    public class ProductoController : ControllerBase
    {        
        private readonly IMapper _mapper;
        
        private readonly IProductRepository _repository;

        public ProductoController(IMapper maper,
                                  IProductRepository repository)
        {
            _mapper = maper;
            _repository = repository;
        }

        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var listProductos = await _repository.GetProducts();
                return Ok(listProductos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/<ProductoController>
        [HttpGet("{idProveedor}/{idTipoProducto}/{claveProveedor?}")]
        public async Task<IActionResult> Get(int idProveedor, int idTipoProducto, string? claveProveedor)
        {
            try
            {
                var listProductos = await _repository.SearchProducts(claveProveedor, idProveedor, idTipoProducto);
                return Ok(listProductos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var producto = await _repository.GetProductById(id);
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductoViewModel producto)
        {
            try
            {
                var productoNew = _mapper.Map<Producto>(producto);
                await _repository.InsertProduct(productoNew);
                return Ok(new { message = "El producto ha sido agregado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductoViewModel producto)
        {
            try
            {
                var productoMod = _mapper.Map<Producto>(producto);
                productoMod.Id = id;
                await _repository.UpdateProduct(productoMod);
                return Ok(new { message = "El producto ha sido actualizado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _repository.DeleteProduct(id);
                return Ok(new { message = "El producto ha sido eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
