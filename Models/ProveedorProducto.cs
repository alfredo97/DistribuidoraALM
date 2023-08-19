using System;
using System.Collections.Generic;

namespace DistribuidoraALM.Models;

public partial class ProveedorProducto
{
    public int IdProveedor { get; set; }

    public int IdProducto { get; set; }

    public decimal? Costo { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
