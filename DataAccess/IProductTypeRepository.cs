using DistribuidoraALM.Models;

namespace DistribuidoraALM.DataAccess
{
    public interface IProductTypeRepository
    {
        Task<IEnumerable<TipoProducto>> GetProductTypes();

        Task<TipoProducto> GetProductTypeById(int id);
    }
}
