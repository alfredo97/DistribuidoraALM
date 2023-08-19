using DistribuidoraALM.Models;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraALM.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly DistribuidoraAlmContext _ctx;

        public ProductRepository(DistribuidoraAlmContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<Producto>> GetProducts()
        {
            try
            {
                var listProductos = await _ctx.Productos
                    .Where(p => p.EsActivo == true)
                    .Include("IdProveedorNavigation")
                    .Include("TipoProductoNavigation")
                    .ToListAsync();
                return listProductos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Producto>> SearchProducts(string? claveProducto, int idProveedor, int idTipoProducto)
        {
            try
            {
                var query = _ctx.Productos
                    .Where(p => p.EsActivo == true);

                if (claveProducto != null && claveProducto.Length > 0) query =  query.Where(p => p.ClaveProductoProveedor.Contains(claveProducto));
                if (idProveedor != 0) query = query.Where(p => p.IdProveedor == idProveedor);
                if (idTipoProducto != 0) query = query.Where(p => p.TipoProducto == idTipoProducto);

                var listProductos = await query.Include("IdProveedorNavigation")
                    .Include("TipoProductoNavigation")
                    .ToListAsync();
                return listProductos;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Producto> GetProductById(int id)
        {
            try
            {
                var producto = await _ctx.Productos.FindAsync(id);
                return producto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task InsertProduct(Producto product)
        {
            try
            {
                _ctx.Productos.Add(product);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task UpdateProduct(Producto product)
        {
            try
            {
                _ctx.Productos.Update(product);
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task DeleteProduct(int id)
        {
            try
            {
                var producto = await _ctx.Productos.FindAsync(id);
                if (producto != null) producto.EsActivo = false;
                await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
