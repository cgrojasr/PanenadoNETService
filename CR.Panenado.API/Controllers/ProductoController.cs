using AutoMapper;
using AutoMapper.QueryableExtensions;
using CR.Paneando.BL;
using CR.Panenado.API.Models;
using CR.Panenado.EF.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        public ActionResult ListarCatalogo()
        {
            try
            {
                return Ok(objProductoBL.ListarCatalogo());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult Registrar(ProductoModel objProductoModel) {
            try
            {
                var objProducto = mapper.Map<Producto>(objProductoModel);
                objProducto = objProductoBL.Registrar(objProducto);
                return Ok(mapper.Map<ProductoModel>(objProducto));
            }
            catch (Exception)
            {
                return BadRequest("PROBLEMA");
            }
        }
    }
}
