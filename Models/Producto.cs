using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistribuidoraALM.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int TipoProducto { get; set; }

    public bool EsActivo { get; set; }

    public decimal? Precio { get; set; }

    public decimal CostoProveedor { get; set; }

    public string? ClaveProductoProveedor { get; set; }

    public int IdProveedor { get; set; }

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual TipoProducto TipoProductoNavigation { get; set; } = null!;

}
