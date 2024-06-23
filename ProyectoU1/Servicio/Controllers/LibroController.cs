using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;

namespace Servicio.Controllers
{
    using System.Web.Http;
    public class LibroController : ApiController
    {
        public Libro CrearLibro(Libro _libro)
        {
            var negocio = new Negocio.LLibro();
            var libro = negocio.Create(_libro);

            return libro;
        }
        [HttpDelete]
        public Libro BorrarLibro(int id)
        {
            var negocio = new Negocio.LLibro();
            var producto = negocio.Delete(id);

            return null;
        }
        [HttpPut]
        public Libro EditarLibro(Libro _libro)
        {
            var negocio = new Negocio.LLibro();
            var producto = negocio.Update(_libro);

            return null;
        }

        [HttpGet]
        public Libro BuscarLibro(string name)
        {
            var negocio = new Negocio.LLibro();
            Libro result = negocio.RetrieveByName(name);

            return result;
        }

        [HttpGet]
        public List<Libro> VerLibros()
        {
            var negocio = new Negocio.LLibro();
            List<Libro> result = negocio.RetrieveAll();

            return result;
        }

        [HttpGet]
        public List<Libro> FiltrarPorCategorias(int id)
        {
            var negocio = new Negocio.LLibro();
            List<Libro> productos = negocio.FilterByCategoryId(id);

            return productos;
        }

        [HttpGet]
        public List<Libro> FiltrarPorEditoriales(int id)
        {
            var negocio = new Negocio.LLibro();
            List<Libro> productos = negocio.FilterByEditorialId(id);

            return productos;
        }

        [HttpGet]
        public List<Libro> FiltrarPorAutores(int id)
        {
            var negocio = new Negocio.LLibro();
            List<Libro> productos = negocio.FilterByAutorId(id);

            return productos;
        }

    }
}
