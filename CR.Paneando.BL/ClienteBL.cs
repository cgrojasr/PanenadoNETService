using CR.Panenado.DA;
using CR.Panenado.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR.Paneando.BL
{
    public class ClienteBL
    {
        private readonly ClienteDA objClienteDA;
        public ClienteBL() { 
            objClienteDA = new ClienteDA();
        }

        public bool Autenticar(string email, string password) {
            try
            {
                var objCliente = objClienteDA.Autenticar(email, password);
                if (objCliente != null)
                    return true;
                else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente Registrar(Cliente objCliente) {
            try
            {
                objCliente.Activo = true;
                var idCliente = objClienteDA.Registrar(objCliente);
                if (idCliente != 0)
                {
                    objCliente.IdCliente = idCliente;
                    return objCliente;
                } else {
                    throw new Exception("No se pudo registrar el cliente");
                }
            } catch (Exception) {
                throw;
            }
        }
    }
}
