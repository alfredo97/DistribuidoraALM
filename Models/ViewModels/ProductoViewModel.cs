namespace DistribuidoraALM.Models
{
    public class ProductoViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public int TipoProducto { get; set; }

        public bool EsActivo { get; set; }

        public decimal? Precio { get; set; }

        public decimal CostoProveedor { get; set; }

        public string? ClaveProductoProveedor { get; set; }

        public int IdProveedor { get; set; }

    }
}
