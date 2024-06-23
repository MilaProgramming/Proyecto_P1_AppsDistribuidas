using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;

namespace Servicio.Controllers
{
    public class EditorialController : ApiController
    {
        public Editorial CrearEditorial(Editorial _editorial)
        {
            var negocio = new Negocio.LEditorial();
            var editorial = negocio.Create(_editorial);

            return editorial;
        }
        [HttpPut]
        public Editorial EditarEditorial(Editorial _editorial)
        {
            var negocio = new Negocio.LEditorial();
            var editorial = negocio.Update(_editorial);

            return null;
        }
        [HttpDelete]
        public Editorial BorrarEditorial(int id)
        {
            var negocio = new Negocio.LEditorial();
            var editorial = negocio.Delete(id);

            return null;
        }

        [HttpGet]
        public List<Editorial> VerEditorial()
        {
            var negocio = new Negocio.LEditorial();
            List<Editorial> result = negocio.RetrieveAll();

            return result;
        }
    }
}
