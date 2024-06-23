using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;

namespace Servicio.Controllers
{
    public class AutorController : ApiController
    {
        public Autor CrearAutor(Autor _autor)
        {
            var negocio = new Negocio.LAutor();
            var autor = negocio.Create(_autor);

            return autor;
        }
        [HttpPut]
        public Autor EditarAutor(Autor _autor)
        {
            var negocio = new Negocio.LAutor();
            var autor = negocio.Update(_autor);

            return null;
        }

        [HttpDelete]
        public Autor BorrarAutor(int id)
        {
            var negocio = new Negocio.LAutor();
            var autor = negocio.Delete(id);

            return null;
        }

        [HttpGet]
        public List<Autor> VerAutor()
        {
            var negocio = new Negocio.LAutor();
            List<Autor> result = negocio.RetrieveAll();

            return result;
        }

    }
}
