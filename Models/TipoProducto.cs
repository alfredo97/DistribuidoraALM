using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DistribuidoraALM.Models;

public partial class TipoProducto
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    [JsonIgnore]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
