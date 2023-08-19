using DistribuidoraALM.Models;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraALM.DataAccess
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly DistribuidoraAlmContext _ctx;

        public ProductTypeRepository(DistribuidoraAlmContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<TipoProducto>> GetProductTypes()
        {
            try
            {
                var listTiposProducto = await _ctx.TipoProductos.ToListAsync();
                return listTiposProducto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<TipoProducto> GetProductTypeById(int id)
        {
            try
            {
                var tipoProducto = await _ctx.TipoProductos.FindAsync(id);
                return tipoProducto;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
