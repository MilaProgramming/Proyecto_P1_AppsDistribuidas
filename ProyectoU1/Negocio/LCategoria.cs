using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LCategoria
    {
        public Categoria Create(Categoria categoria)
        {
            Categoria result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Categoria categoriaTemp = r.Retrieve<Categoria>(c => c.cat_nombre == categoria.cat_nombre);
                if (categoriaTemp == null)
                {
                    result = r.Create(categoria);
                }
                else
                {

                }
            }
            return result;
        }
        public bool Update(Categoria categoria)
        {
            bool result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Categoria categoriaTemp = r.Retrieve<Categoria>(c => c.cat_id == categoria.cat_id);
                if (categoriaTemp != null)
                {
                    result = r.Update(categoria);
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
            var categoriaTemp = RetrieveById(id);
            if (categoriaTemp != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Delete<Categoria>(categoriaTemp);
                }
            }
            else
            {
                
            }
            return result;
        }
        public Categoria RetrieveById(int id)
        {
            Categoria result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<Categoria>(c => c.cat_id == id);
            }
            return result;
        }
        public List<Categoria> RetrieveAll()
        {
            List<Categoria> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.RetrieveAll<Categoria>().ToList();
            }
            return result;
        }
    }
}
