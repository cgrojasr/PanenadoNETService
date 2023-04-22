using System;
using System.Collections.Generic;

namespace CR.Panenado.EF.Entities;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? ImageUrl { get; set; }

    public int IdTipoProducto { get; set; }

    public bool Activo { get; set; }

    public virtual TipoProducto IdTipoProductoNavigation { get; set; } = null!;

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; } = new List<PedidoDetalle>();

    public virtual ICollection<ProductoPrecio> ProductoPrecios { get; } = new List<ProductoPrecio>();
}
