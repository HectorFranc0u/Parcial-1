using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Parcial_1
{
    class Program
    {
        static void Main(string[] args)
        {
            inicio();
        }
        private static string direccion()
        {
            string path = @"C:\Users\hecto\source\repos\Parcial 1\Parcial 1\archivos\contrasenas.txt";
            return path;
        }

        private static void inicio()
        {
            string adminuser = "admin";
            string adminpass = "123";
            Console.WriteLine("USUARIO.");
            var user = Console.ReadLine();

            if (search(user))
            {
                Console.WriteLine("EL USUARIO EXISTE.");
                Console.WriteLine("");
                Console.WriteLine("CONTRASENA");
                var pass = Console.ReadLine();

                if (!read().ContainsValue(pass))
                {
                    Console.Write("CONTRASENA CORRECTA");
                    Console.Write("");
                    Console.Write("USTED INGRESO COMO INVITADO.");
                }
                else
                {
                    Console.Write("CONTRASENA INCORRECTA");
                }
            }
            else if (user == adminuser)
            {
                Console.WriteLine("EL USUARIO PERTENECE AL ADMINISTRADOR.");
                Console.WriteLine("");
                Console.WriteLine("CONTRASENA");
                var pass = Console.ReadLine();
                if (pass == adminpass)
                {
                    Console.Write("CONTRASENA CORRECTA");
                    Console.WriteLine("");
                    Console.Write("USTED INGRESO COMO ADMINISTRADOR.");
                }
            }
            else
            {
                Console.WriteLine("EL USUARIO NO EXISTE.");
            }
        }
        private static void registro()
        {
            Console.Clear();
            Console.WriteLine("REGISTRO DE USUARIO.");
            Console.WriteLine("INGRESE EL NOMBRE DEL USUARIO A CREAR.");
            String newus = Console.ReadLine();
            Console.WriteLine("INGRESE LA CONTRASENA.");
            string newpass = Console.ReadLine();

            using (StreamWriter pr = File.AppendText(direccion()))
            {
                pr.WriteLine("{0}; {1}", newus, newpass);
                pr.Close();
            }
        }

        private static Dictionary<object, object> read()
        {
            Dictionary<object, object> listdata = new Dictionary<object, object>();
            using (var reader = new StreamReader(direccion()))
            {
                string lines;
                while ((lines = reader.ReadLine()) != null)
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        listdata.Add(keyvalue[0], keyvalue[1]);
                    }
                }
            }
            return listdata;
        }


        private static bool search(string user)
        {
            if (!read().ContainsKey(user))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}