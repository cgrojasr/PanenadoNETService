using System;
using System.Collections.Generic;

namespace CR.Panenado.EF.Entities;

public partial class ProductoPrecio
{
    public int IdProductoPrecio { get; set; }

    public int IdProducto { get; set; }

    public double ValorProduccion { get; set; }

    public double ValorVenta { get; set; }

    public bool Activo { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
