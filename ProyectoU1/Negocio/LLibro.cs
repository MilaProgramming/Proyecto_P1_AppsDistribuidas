using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LLibro
    {
        public Libro Create(Libro libro)
        {
            Libro result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Libro libroTemp = r.Retrieve<Libro>(l => l.lib_nombre == libro.lib_nombre);
                if (libroTemp == null)
                {
                    result = r.Create(libro);
                }
                else
                {

                }
            }
            return result;
        }
        public bool Update(Libro libro)
        {
            bool result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Libro libroTemp = r.Retrieve<Libro>(l => l.lib_id == libro.lib_id);
                if (libroTemp != null)
                {
                    result = r.Update(libro);
                }
                else
                {
                    //caso negativo
                }
            }
            return result;
        }

        public Libro RetrieveById(int id)
        {
            Libro result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<Libro>(l => l.lib_id == id);
            }
            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            var libroTemp = RetrieveById(id);
            if (libroTemp != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Delete<Libro>(libroTemp);
                }
            }
            else
            {
                //caso negativo
            }
            return result;
        }
        public List<Libro> RetrieveAll()
        {
            List<Libro> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.RetrieveAll<Libro>().ToList();
            }
            return result;
        }
        public Libro RetrieveByName(string name)
        {
            Libro result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<Libro>(l => l.lib_nombre == name);
            }
            return result;
        }
        public List<Libro> FilterByCategoryId(int categoryId)
        {
            List<Libro> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<Libro>(l => l.cat_id == categoryId);
            }
            return result;
        }
        public List<Libro> FilterByEditorialId(int editorialId)
        {
            List<Libro> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<Libro>(l => l.edi_id == editorialId);
            }
            return result;
        }
        public List<Libro> FilterByAutorId(int autorId)
        {
            List<Libro> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Filter<Libro>(l => l.aut_id == autorId);
            }
            return result;
        }
    }
}
