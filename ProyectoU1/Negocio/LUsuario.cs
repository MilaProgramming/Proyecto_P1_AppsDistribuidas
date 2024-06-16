using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LUsuario
    {
        public Usuario Create(Usuario usuario)
        {
            Usuario result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Usuario usuarioTemp = r.Retrieve<Usuario>(u => u.usu_cedula == usuario.usu_cedula);
                if (usuarioTemp == null)
                {
                    result = r.Create(usuario);
                }
                else
                {

                }
            }
            return result;
        }
        public bool Update(Usuario usuario)
        {
            bool result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Usuario usuarioTemp = r.Retrieve<Usuario>(u => u.usu_cedula == usuario.usu_cedula);
                if (usuarioTemp != null)
                {
                    result = r.Update(usuario);
                }
                else
                {
                    //caso negativo
                }
            }
            return result;
        }
        public bool Delete(int id)
        {
            bool result = false;
            var usuarioTemp = RetrieveById(id);
            if (usuarioTemp != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Delete<Usuario>(usuarioTemp);
                }
            }
            else
            {

            }
            return result;
        }
        public Usuario RetrieveById(int id)
        {
            Usuario result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<Usuario>(u => u.usu_cedula == id);
            }
            return result;
        }
        public List<Usuario> RetrieveAll()
        {
            List<Usuario> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.RetrieveAll<Usuario>().ToList();
            }
            return result;
        }
    }
}
