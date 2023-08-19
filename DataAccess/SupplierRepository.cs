using DistribuidoraALM.Models;
using Microsoft.EntityFrameworkCore;

namespace DistribuidoraALM.DataAccess
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly DistribuidoraAlmContext _ctx;

        public SupplierRepository(DistribuidoraAlmContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<Proveedor>> GetSuppliers()
        {
            try
            {
                var listProveedores = await _ctx.Proveedors.ToListAsync();
                return listProveedores;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Proveedor> GetSupplierById(int id)
        {
            try
            {
                var proveedor = await _ctx.Proveedors.FindAsync(id);
                return proveedor;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
