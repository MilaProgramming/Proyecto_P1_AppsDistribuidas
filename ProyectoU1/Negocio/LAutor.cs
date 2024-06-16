using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LAutor
    {
        public Autor Create(Autor autor)
        {
            Autor result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Autor autorTemp = r.Retrieve<Autor>(a => a.aut_nombre == autor.aut_nombre);
                if (autorTemp == null)
                {
                    result = r.Create(autor);
                }
                else
                {

                }
            }
            return result;
        }
        public bool Update(Autor autor)
        {
            bool result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Autor autorTemp = r.Retrieve<Autor>(a => a.aut_id == autor.aut_id);
                if (autorTemp != null)
                {
                    result = r.Update(autor);
                }
                else
                {
                    
                }
            }
            return result;
        }
        public bool Delete(int id)
        {
            bool result = false;
            var autorTemp = RetrieveById(id);
            if (autorTemp != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Delete<Autor>(autorTemp);
                }
            }
            else
            {

            }
            return result;
        }
        public Autor RetrieveById(int id)
        {
            Autor result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<Autor>(a => a.aut_id == id);
            }
            return result;
        }
        public List<Autor> RetrieveAll()
        {
            List<Autor> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.RetrieveAll<Autor>().ToList();
            }
            return result;
        }
    }
}
