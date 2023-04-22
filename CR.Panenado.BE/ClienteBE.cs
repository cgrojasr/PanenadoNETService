using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CR.Panenado.BE
{
    public class ClienteBE
    {
    }

    public class ClienteBE_Autenticar
    {
        [JsonPropertyName("id_cliente")]
        public int IdCliente { get; set; }
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
