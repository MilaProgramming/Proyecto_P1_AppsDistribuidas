using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LEditorial
    {
        public Editorial Create(Editorial editorial)
        {
            Editorial result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Editorial editorialTemp = r.Retrieve<Editorial>(e => e.edi_nombre == editorial.edi_nombre);
                if (editorialTemp == null)
                {
                    result = r.Create(editorial);
                }
                else
                {

                }
            }
            return result;
        }
        public bool Update(Editorial editorial)
        {
            bool result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Editorial editorialTemp = r.Retrieve<Editorial>(e => e.edi_id == editorial.edi_id);
                if (editorialTemp != null)
                {
                    result = r.Update(editorial);
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
            var editorialTemp = RetrieveById(id);
            if (editorialTemp != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Delete<Editorial>(editorialTemp);
                }
            }
            else
            {

            }
            return result;
        }
        public Editorial RetrieveById(int id)
        {
            Editorial result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<Editorial>(e => e.edi_id == id);
            }
            return result;
        }
        public List<Editorial> RetrieveAll()
        {
            List<Editorial> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.RetrieveAll<Editorial>().ToList();
            }
            return result;
        }
    }
}
