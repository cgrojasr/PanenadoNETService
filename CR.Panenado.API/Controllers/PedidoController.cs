using AutoMapper;
using AutoMapper.QueryableExtensions;
using CR.Paneando.BL;
using CR.Panenado.API.Models;
using CR.Panenado.EF.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CR.Panenado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoBL objPedidoBL;
        private readonly IMapper mapper;

        public PedidoController(IMapper mapper)
        {
            this.mapper = mapper;
            objPedidoBL = new PedidoBL();
        }

        [HttpPost]
        public ActionResult Registrar([FromBody]PedidoModel objPedidoModel) {
            try
            {
                var objPedido = objPedidoBL.Registrar(mapper.Map<Pedido>(objPedidoModel));
                return Ok(mapper.Map<PedidoModel>(objPedido));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
