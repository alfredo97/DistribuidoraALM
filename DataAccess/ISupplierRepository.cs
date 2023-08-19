using DistribuidoraALM.Models;

namespace DistribuidoraALM.DataAccess
{
    public interface ISupplierRepository
    {
        Task<IEnumerable<Proveedor>> GetSuppliers();

        Task<Proveedor> GetSupplierById(int id);
    }
}
