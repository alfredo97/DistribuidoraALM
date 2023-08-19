using AutoMapper;
using DistribuidoraALM.Models;

namespace DistribuidoraALM
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<ProductoViewModel, Producto>();
        }
    }
}
