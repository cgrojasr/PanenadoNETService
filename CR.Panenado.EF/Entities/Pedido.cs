using System;
using System.Collections.Generic;

namespace CR.Panenado.EF.Entities;

public partial class Pedido
{
    public int IdPedido { get; set; }

    public DateTime Fecha { get; set; }

    public string Direccion { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Estado { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public virtual ICollection<Orden> Ordens { get; } = new List<Orden>();

    public virtual ICollection<PedidoDetalle> PedidoDetalles { get; } = new List<PedidoDetalle>();

    public virtual ICollection<PedidoFecha> PedidoFechas { get; } = new List<PedidoFecha>();
}
