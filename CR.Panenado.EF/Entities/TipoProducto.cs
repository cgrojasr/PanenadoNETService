using System;
using System.Collections.Generic;

namespace CR.Panenado.EF.Entities;

public partial class TipoProducto
{
    public int IdTipoProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
