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
    public class ProductoController : ControllerBase
    {
        private readonly ProductoBL objProductoBL;
        private readonly IMapper mapper;

        public ProductoController(IMapper mapper)
        {
            objProductoBL = new ProductoBL();
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Listar_Disponibles()
        {
            try
            {
                return Ok(objProductoBL.Listar_Disponibles().ProjectTo<ProductoModel.CatalogoDisponible>(mapper.ConfigurationProvider));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}
