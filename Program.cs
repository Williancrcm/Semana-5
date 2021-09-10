using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio_5
{
    class Program
    {
        static void Main()
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = Menu(); //llamdo al metodo Menu()
            }
            Console.ReadKey();
        }

        private static bool Menu()
        {
            //crear el menu para mostrar al usuario
            Console.Clear(); //permite limpiar la consola
            Console.WriteLine("Seleccion la operación a realizar: ");
            Console.WriteLine("1. Registrar nuevo estudiante");
            Console.WriteLine("2. Actualizar datos de estudiante");
            Console.WriteLine("3. Eliminar datos de estudiante");
            Console.WriteLine("4. Mostrar listado de datos personales");
            Console.WriteLine("5. Salir");
            Console.Write("\nOpcion: ");

            switch (Console.ReadLine())
            {
                case "1": register(); //llama al metodo (PP)
                    return true;
                case "2":
                    return true;
                case "3":
                    return true;
                case "4":
                    //mostrar contenido del archivo
                    Console.WriteLine("LISTADO DE LOS DATOS PERSONALES");
                    foreach (KeyValuePair<object, object> data in readFile())
                    {
                        Console.WriteLine("{0}: {1}: ", data.Key, data.Value);
                    }
                    Console.ReadKey();
                    return true;
                case "5":
                    return false;
                default:
                    return false;
            }


        }

        //metodo para obtener la ruta del archivo
        private static string getpath()
        {
            string path = @"C:\Users\LENOVO\Desktop\Almacen\Registro1.txt";
            return path; 
        }

        //metodo para registrar datos en el archivo (PP)
        private static void register()
        {
            //Solicitar los datos personales
            Console.WriteLine("DATOS PERSONALES");

            Console.WriteLine("Nombre completo: ");
            string fullname = Console.ReadLine();

            Console.WriteLine("Edad: ");
            int age = Convert.ToInt32(Console.ReadLine());

         /* Console.WriteLine("Estado civil: ");
            string estate = Console.ReadLine(); */

            //crear el archivo, uso del streamWriter para escribir el archivo
            using (StreamWriter archivo = File.AppendText(getpath()))
            {
                archivo.WriteLine("{0}, {1} ", fullname, age);
                archivo.Close();
            }

        }

        //metodo para leer el contenido del archivo
        private static Dictionary<object, object> readFile()
        {
            //declarar el diccionario
            Dictionary<object, object> listData = new Dictionary<object, object>();

            //uso del streamReader para leer el archivo
            using (var reader = new StreamReader(getpath()))
            {
                //variable para almacenar el contenido del archivo en consola
                string lines;

                while ((lines = reader.ReadLine()) != null) //mientras no se encuentre una linea vacia se ejecuta el ciclo
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                      //int keyvalue3 = Convert.ToInt32(keyvalue[1] = keyvalue[2]);
                        listData.Add(keyvalue[0], keyvalue[2]);
                    }
                }

            }

            //retornar el diccionario
            return listData;
        }

    }

    
}
