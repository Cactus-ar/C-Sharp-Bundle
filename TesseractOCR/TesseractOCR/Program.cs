using System;
using System.IO;
using Tesseract;


/* Simple uso de la libreria tesseract para el
 * reconocimiento de imagenes dentro de una carpeta
 */


namespace TesseractOCR
{
    class Program
    {
        static void Main(string[] args)
        {

            string raiz = "imagenes";

                if (File.Exists(raiz))
                {
                    // La via al archivo
                    ProcesarArchivo(raiz);
                }
                else if (Directory.Exists(raiz))
                {
                    // el path al directorio
                    ProcesarCarpeta(raiz);
                }
                else
                {
                    Console.WriteLine("{0} no es un nombre de carpeta valido", raiz);
                }

            

        }

        public static void ProcesarCarpeta(string carpeta)
        {
            // Procesar la lista de archivos dentro del directorio
            string[] archivos = Directory.GetFiles(carpeta);

            foreach (string imagen in archivos)
                ProcesarArchivo(imagen);

        }

        // 
        public static void ProcesarArchivo(string path)
        {
           
            Pix imagen = Pix.LoadFromFile(path);
            TesseractEngine engine = new TesseractEngine("./tessdata", "eng", EngineMode.Default);
            Page pagina = engine.Process(imagen, PageSegMode.Auto);
            string salida = pagina.GetText();
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Archivo: {0}", path);
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine(salida);

            pagina.Dispose();
            engine.Dispose();
            imagen.Dispose();

        }
    }
}
