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
                    menuadmin();
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
            menuadmin();
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

        // menu de administrador
        private static bool menuadmin()
        {
            Console.Clear();
            Console.WriteLine("BIENVENIDO AL MENU DE ADMINISTRADOR.");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("1 - CREAR UN USUARIO DE INVITADO.");
            Console.WriteLine("2 - CREAR EL ARCHIVO CON SU EXPERIENCIA PERSONAL.");
            Console.WriteLine("3 - BORRAR EL ARCHIVO CREADO.");
            Console.WriteLine("4 - CERRAR LA CONSOLA.");
            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine("SELECCIONE UNA OPCION. ");

            switch (Console.ReadLine())
            {
                case "1":
                    registro();
                    return true;
                case "2":
                    docalumno();
                    return true;
                case "3":
                    return true;
                case "4":
                    Console.WriteLine("PRESIONE CUALQUIER TECLA PARA CERRAR LA CONSOLA.");
                    return true;
                default:
                    return false;
            }
        }
        private static void docalumno()
        {
            Console.Clear();
            Console.WriteLine("ARCHIVO CON SU EXPERIENCIA PERSONAL.");
            Console.WriteLine("INGRESE SU NOMBRE.");
            String nombre = Console.ReadLine();
            Console.WriteLine("ESCRIBA SU EXPERIENCIA.");
            string experiencia = Console.ReadLine();

            StreamWriter sw = File.CreateText(nombre);
            sw.WriteLine(experiencia);
            sw.Dispose();
            menuadmin();
        }
        private static void borrardoc()
        {

        }
    }
}