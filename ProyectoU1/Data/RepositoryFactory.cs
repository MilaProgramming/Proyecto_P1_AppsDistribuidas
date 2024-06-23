using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class RepositoryFactory
    {
        public static iRepository CreateRepository()
        {
            var Context = new ProyectoDBEntities();
            Context.Configuration.ProxyCreationEnabled = false;
            return new FRepository(Context);
        }
    }
}

