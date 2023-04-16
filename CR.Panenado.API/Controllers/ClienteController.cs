using AutoMapper;
using CR.Paneando.BL;
using CR.Panenado.API.Models;
using CR.Panenado.EF.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CR.Panenado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteBL objClienteBL;
        private readonly IMapper mapper;

        public ClienteController(IMapper mapper)
        {
            this.mapper = mapper;
            objClienteBL = new ClienteBL();
        }

        [HttpPost]
        public IActionResult Autenticar([FromBody]ClienteModel_Autenticar objCliente) {
            try
            {
                return Ok(objClienteBL.Autenticar(objCliente.Email, objCliente.Password));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("registrar")]
        public IActionResult Resgistrar(ClienteModel objClienteModel)
        {
            try
            {
                var objCliente = mapper.Map<Cliente>(objClienteModel);
                objCliente = objClienteBL.Registrar(objCliente);
                return Ok(mapper.Map<ClienteModel>(objCliente));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
