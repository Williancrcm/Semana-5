using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ejercicio_5 
{
    class FileExample
    {
        static void Main()
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = Menu(); 
            }
            Console.ReadKey();
        }

        private static bool Menu()
        {
            
            Console.WriteLine("Seleccion la operación a realizar: ");
            Console.WriteLine("1. Registrar nuevos datos personales");
            Console.WriteLine("2. Actualizar datos personales");
            Console.WriteLine("3. Eliminar datos personales");
            Console.WriteLine("4. Mostrar listado de datos personales");
            Console.WriteLine("5. Salir");
            Console.Write("\nOpcion: ");

            switch (Console.ReadLine())
            {
                case "1":
                    register(); 
                    return true;
                case "2":
                    updateData(); 
                    Console.ReadKey();
                    return true;
                case "3":
                    return true;
                case "4":
                    
                    Console.WriteLine("LISTADO DE DATOS PERSONALES");
                    foreach (KeyValuePair<object, object> data in readFile())
                    {
                        Console.WriteLine("{0}: {1}", data.Key, data.Value);
                    }
                    Console.ReadKey();
                    return true;
                case "5":
                    return false;
                default:
                    return false;
            }
        }

        
        private static string getPath()
        {
            string path = @"C:\Users\LENOVO\Desktop\Almacen\Register11.txt";
            return path;
        }

        private static void register()
        {
            Console.WriteLine("DATOS PERSONALES");
            Console.Write("Nombre Completo: ");
            string fullname = Console.ReadLine();
            Console.Write("Edad: ");
            int age = Convert.ToInt32(Console.ReadLine());

            using (StreamWriter sw = File.AppendText(getPath()))
            {
                sw.WriteLine("{0}; {1}", fullname, age);
                sw.Close();
            }
        }

        private static Dictionary<object, object> readFile()
        {

            Dictionary<object, object> listData = new Dictionary<object, object>();

            using (var reader = new StreamReader(getPath()))
            {

                string lines;

                while ((lines = reader.ReadLine()) != null) 
                {
                    string[] keyvalue = lines.Split(';');
                    if (keyvalue.Length == 2)
                    {
                        listData.Add(keyvalue[0], keyvalue[1]);
                    }
                }

            }

            
            return listData;
        }

        
        private static bool search(string name)
        {
            if (!readFile().ContainsKey(name))
            {
                return false;
            }
            return true;
        }

        
        private static void updateData()
        {
            
            Console.Write("Escriba el nombre completo a actualizar: ");
            var name = Console.ReadLine();

            
            if (search(name))
            {
                Console.WriteLine("El registro existe!");
                Console.Write("Nueva edad: ");
                var newAge = Console.ReadLine();

                
                Dictionary<object, object> temp = new Dictionary<object, object>();
                temp = readFile();

                temp[name] = newAge; 
                Console.WriteLine("El registro ha sido actualizado!");
                File.Delete(getPath()); 

                using (StreamWriter sw = File.AppendText(getPath()))
                {
                    
                    foreach (KeyValuePair<object, object> values in temp)
                    {
                        sw.WriteLine("{0}; {1}", values.Key, values.Value);
                        sw.Close();
                    }
                }

            }
            else
            {
                Console.WriteLine("¡El registro no se encontro!");
            }
        }
    }
}
