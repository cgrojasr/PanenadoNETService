using System;
using System.Collections.Generic;

namespace CR.Panenado.EF.Entities;

public partial class Orden
{
    public int IdOrden { get; set; }

    public int IdPedido { get; set; }

    public DateTime Fecha { get; set; }

    public DateTime FechaDespacho { get; set; }

    public byte[] HoraMinutoDespacho { get; set; } = null!;

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
