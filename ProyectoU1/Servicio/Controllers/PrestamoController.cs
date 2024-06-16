using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;

namespace Servicio.Controllers
{
    public class PrestamoController : ApiController
    {
        public Prestamo_Libro CrearPrestamo(Prestamo_Libro _prestamo)
        {
            var negocio = new Negocio.LPrestamo();
            var prestamo = negocio.Create(_prestamo);

            return prestamo;
        }

        public Prestamo_Libro EditarPrestamo(Prestamo_Libro _prestamo)
        {
            var negocio = new Negocio.LPrestamo();
            var prestamo = negocio.Update(_prestamo);

            return null;
        }

        public Prestamo_Libro BorrarPrestamo(Prestamo_Libro _prestamo)
        {
            var negocio = new Negocio.LPrestamo();
            var prestamo = negocio.Delete(_prestamo.pre_id);

            return null;
        }

        [HttpGet]
        public List<Prestamo_Libro> VerPrestamos()
        {
            var negocio = new Negocio.LPrestamo();
            List<Prestamo_Libro> result = negocio.RetrieveAll();

            return result;
        }
    }
}
