using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;

namespace Servicio.Controllers
{
    public class UsuarioController : ApiController
    {
        public Usuario CrearUsuario(Usuario _usuario)
        {
            var negocio = new Negocio.LUsuario();
            var usuario = negocio.Create(_usuario);

            return usuario;
        }

        public Usuario EditarUsuario(Usuario _usuario)
        {
            var negocio = new Negocio.LUsuario();
            var usuario = negocio.Update(_usuario);

            return null;
        }

        public Usuario BorrarUsuario(Usuario _usuario)
        {
            var negocio = new Negocio.LUsuario();
            var usuario = negocio.Delete(_usuario.usu_cedula);

            return null;
        }

        [HttpGet]
        public List<Usuario> VerUsuarios()
        {
            var negocio = new Negocio.LUsuario();
            List<Usuario> result = negocio.RetrieveAll();

            return result;
        }
    }
}
