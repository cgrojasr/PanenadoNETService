using System;
using System.Collections.Generic;

namespace CR.Panenado.EF.Entities;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Activo { get; set; }
}
