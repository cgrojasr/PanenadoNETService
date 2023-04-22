using CR.Panenado.BE;
using CR.Panenado.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Panenado.DA
{
    public class ClienteDA
    {
        private readonly DbPaneandoContext dc;
        public ClienteDA()
        {
            dc = new DbPaneandoContext();
        }

        public ClienteBE_Autenticar? Autenticar(string email, string password)
        {
            var cliente = from cli in dc.Clientes.Where(x=>x.Email.Equals(email) && x.Password.Equals(password))
                          select new ClienteBE_Autenticar
                          { 
                              IdCliente = cli.IdCliente,
                              Nombres = cli.Nombres,
                              Apellidos = cli.Apellidos,
                              Email = cli.Email
                          };
            return cliente.Single();
        }

        public int Registrar(Cliente objCliente) { 
            dc.Clientes.Add(objCliente);
            dc.SaveChanges();

            return objCliente.IdCliente;
        }
    }
}
