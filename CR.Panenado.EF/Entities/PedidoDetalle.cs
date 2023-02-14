using System;
using System.Collections.Generic;

namespace CR.Panenado.EF.Entities;

public partial class PedidoDetalle
{
    public int IdPedido { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public double ValorVenta { get; set; }

    public bool Eliminado { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
