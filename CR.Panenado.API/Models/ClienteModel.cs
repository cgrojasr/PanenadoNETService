namespace CR.Panenado.API.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool Activo { get; set; }
    }

    public class ClienteModel_Autenticar {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
