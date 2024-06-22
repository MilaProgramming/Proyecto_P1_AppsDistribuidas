using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddCategoria();
            AddEditorial();
            AddUsuario();
            Console.WriteLine("Funciona la wea");
            //AddAutor();
        }

        static void AddAutor()
        {
            var a = new Autor();

            a.aut_nombre = "J. K. Rowling";

            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(a);
            }
            Console.WriteLine("Id Producto {0}", a.aut_id);
        }

        static void AddCategoria()
        {
            var c = new Categoria();

            c.cat_nombre = "Ciencia Ficción";

            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(c);
            }
            Console.WriteLine("Id Producto {0}", c.cat_id);
        }

        static void AddEditorial()
        {
            var e = new Editorial();

            e.edi_nombre = "Salamandra";

            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(e);
            }
            Console.WriteLine("Id Producto {0}", e.edi_id);
        }

        static void AddUsuario()
        {
            var u = new Usuario();

            u.usu_cedula = 1111111111;
            u.usu_nombre = "Admin";
            u.usu_apellido = "Administrador";
            u.usu_usuario = "Admin";
            u.usu_contrasenia = "Admin";

            using (var r = RepositoryFactory.CreateRepository())
            {
                r.Create(u);
            }
            Console.WriteLine("Id Producto {0}", u.usu_cedula);
        }

    }
}
