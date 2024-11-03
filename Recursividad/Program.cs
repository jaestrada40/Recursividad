using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursividad
{
    internal class Program
    {
        // Función recursiva para contar archivos y carpetas manualmente
        public static int CountFilesAndFolders(string path)
        {
            int count = 0;

            // Contar archivos en el directorio actual
            string[] files = Directory.GetFiles(path);
            count += files.Length;

            // Obtener subdirectorios y contar cada uno, llamando recursivamente
            string[] directories = Directory.GetDirectories(path);
            count += directories.Length;

            foreach (var dir in directories)
            {
                count += CountFilesAndFolders(dir);  
            }

            return count;
        }

        // Función recursiva para buscar archivos con una extensión específica manualmente
        public static void SearchFilesByExtension(string path, string extension)
        {
            // Obtener archivos en el directorio actual y filtrar por la extensión
            string[] files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                if (file.EndsWith(extension, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(file);
                }
            }

            // Obtener subdirectorios y llamar recursivamente
            string[] directories = Directory.GetDirectories(path);
            foreach (var dir in directories)
            {
                SearchFilesByExtension(dir, extension);  
            }
        }

        // Método principal para probar las funciones
        public static void Main()
        {
            // Cambia esta ruta por la del directorio que deseas probar
            string path = @"C:\Users\jaest\OneDrive\Documentos"; 

            // Prueba de la función CountFilesAndFolders
            Console.WriteLine("Total de archivos y carpetas: " + CountFilesAndFolders(path));

            // Prueba de la función SearchFilesByExtension
            Console.WriteLine("\nArchivos .txt encontrados:");
            SearchFilesByExtension(path, ".txt");

            // Pausa para que la ventana no se cierre inmediatamente
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
