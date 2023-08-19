using DistribuidoraALM.Models;

namespace DistribuidoraALM.DataAccess
{
    public interface IProductRepository
    {
        Task<IEnumerable<Producto>> GetProducts();
        Task<IEnumerable<Producto>> SearchProducts(string claveProducto, int idProveedor, int idTipoProducto);
        Task<Producto> GetProductById(int id);
        Task InsertProduct(Producto product);
        Task UpdateProduct(Producto product);
        Task DeleteProduct(int id);
    }
}
