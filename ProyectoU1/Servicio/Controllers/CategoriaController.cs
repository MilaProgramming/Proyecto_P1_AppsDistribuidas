using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;

namespace Servicio.Controllers
{
    public class CategoriaController : ApiController
    {
        public Categoria CrearCategoria(Categoria _categoria)
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.Create(_categoria);

            return categoria;
        }
        [HttpPut]
        public Categoria EditarCategoria(Categoria _categoria)
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.Update(_categoria);

            return null;
        }
        [HttpDelete]
        public Categoria BorrarCategoria(int id)
        {
            var negocio = new Negocio.LCategoria();
            var categoria = negocio.Delete(id);

            return null;
        }

        [HttpGet]
        public List<Categoria> VerCategorias()
        {
            var negocio = new Negocio.LCategoria();
            List<Categoria> result = negocio.RetrieveAll();

            return result;
        }
    }
}
