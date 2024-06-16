using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class LPrestamo
    {
        public Prestamo_Libro Create(Prestamo_Libro prestamo)
        {
            Prestamo_Libro result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Libro prestamoTemp = r.Retrieve<Libro>(a => a.lib_id == prestamo.lib_id && a.lib_disponible == true);
                if (prestamoTemp != null)
                {
                    result = r.Create(prestamo);
                }
                else
                {

                }
            }
            return result;
        }
        public bool Update(Prestamo_Libro prestamo)
        {
            bool result = false;
            using (var r = RepositoryFactory.CreateRepository())
            {
                Prestamo_Libro prestamoTemp = r.Retrieve<Prestamo_Libro>(p => p.pre_id == prestamo.pre_id);
                if (prestamoTemp != null)
                {
                    result = r.Update(prestamo);
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
            var prestamoTemp = RetrieveById(id);
            if (prestamoTemp != null)
            {
                using (var r = RepositoryFactory.CreateRepository())
                {
                    result = r.Delete<Prestamo_Libro>(prestamoTemp);
                }
            }
            else
            {

            }
            return result;
        }
        public Prestamo_Libro RetrieveById(int id)
        {
            Prestamo_Libro result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.Retrieve<Prestamo_Libro>(p => p.pre_id == id);
            }
            return result;
        }
        public List<Prestamo_Libro> RetrieveAll()
        {
            List<Prestamo_Libro> result = null;
            using (var r = RepositoryFactory.CreateRepository())
            {
                result = r.RetrieveAll<Prestamo_Libro>().ToList();
            }
            return result;
        }
    }
}
