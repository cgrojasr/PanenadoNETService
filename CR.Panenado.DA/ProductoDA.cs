﻿using CR.Panenado.BE;
using CR.Panenado.EF.Entities;
using System.Net.Mime;
using System.Security.Cryptography.X509Certificates;

namespace CR.Panenado.DA
{
    public class ProductoDA
    {
        private readonly DbPaneandoContext dc;

        public ProductoDA()
        {
            dc = new DbPaneandoContext();
        }

        public IEnumerable<ProductoBE.Catalogo> ListarCatalogo() {
            var productos = from pro in dc.Productos.Where(x => x.Activo && x.IdTipoProducto.Equals(1))
                            join pre in dc.ProductoPrecios.Where(x=>x.Activo) on pro.IdProducto equals pre.IdProducto
                            join tip in dc.TipoProductos on pro.IdTipoProducto equals tip.IdTipoProducto
                            orderby pro.IdTipoProducto
                            select new ProductoBE.Catalogo
                            {
                                IdProducto = pro.IdProducto,
                                Nombre = pro.Nombre,
                                Descripcion = pro.Descripcion,
                                TipoProducto = tip.Nombre,
                                ValorVenta = pre.ValorVenta
                            };
            return productos;
        }

        public ProductoBE.Catalogo BuscarCatalogoPorIdProducto(int idProducto) { 
            var productos = from pro in dc.Productos.Where(x=>x.IdProducto.Equals(idProducto))
                            join pre in dc.ProductoPrecios.Where(x => x.Activo) on pro.IdProducto equals pre.IdProducto
                            join tip in dc.TipoProductos on pro.IdTipoProducto equals tip.IdTipoProducto
                            orderby pro.IdTipoProducto
                            select new ProductoBE.Catalogo
                            {
                                IdProducto = pro.IdProducto,
                                Nombre = pro.Nombre,
                                Descripcion = pro.Descripcion,
                                TipoProducto = tip.Nombre,
                                ValorVenta = pre.ValorVenta
                            };

            return productos.Single();
        }

        public IEnumerable<ProductoBE.Precio> BuscarPrecioPorListaIdProductos(List<int> lstIdProductos) {
            var productos = from pre in dc.ProductoPrecios.Where(x => lstIdProductos.All(i => i.Equals(x.IdProducto)) && x.Activo)
                            orderby pre.IdProducto
                            select new ProductoBE.Precio
                            {
                                IdProducto = pre.IdProducto,
                                ValorVenta = pre.ValorVenta
                            };

            return productos;
        }

        public int Registrar(Producto objProducto)
        {
            dc.Productos.Add(objProducto);
            dc.SaveChanges();
            return objProducto.IdProducto;
        }

        public Producto Eliminar(Producto objProducto) {
            dc.Productos.Remove(objProducto);
            return objProducto;
        }

        public Producto? BuscarPorId(int idProducto) {
            var objProducto = dc.Productos.Find(idProducto);
            return objProducto;
        }

        public Producto Actualizar(Producto objProducto) {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Producto objProductoDB = dc.Productos.Find(objProducto.IdProducto);
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            objProductoDB.Nombre = objProducto.Nombre;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            objProductoDB.Descripcion = objProducto.Descripcion;
            objProductoDB.IdTipoProducto = objProducto.IdTipoProducto;
            objProductoDB.Activo = objProducto.Activo;

            dc.SaveChanges();
            return objProductoDB;
        }
    }
}