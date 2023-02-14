using System;
using System.Collections.Generic;

namespace CR.Panenado.EF.Entities;

public partial class PedidoFecha
{
    public int IdPedidoFecha { get; set; }

    public int IdPedido { get; set; }

    public string DiaSemana { get; set; } = null!;

    public TimeSpan? HoraMinuto { get; set; }

    public bool Activo { get; set; }

    public virtual Pedido IdPedidoNavigation { get; set; } = null!;
}
