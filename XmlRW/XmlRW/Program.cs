using System;
using System.Xml;



/* Simple ejemplo de lectura de un archivo
 * en formato XML que basicamente
 * es un texto lleno de nodos que se separan
 * por etiquetas <tags>
 * 
 */

namespace XmlRW
{

    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument documento = new XmlDocument();
            documento.Load("datos\\DatosEjemplo.xml");  //Abrir el archivo

            
            XmlNodeList desayunos = documento.SelectNodes("desayunos/desayuno");

            Console.WriteLine("Item\tPrecio\tCalorias\tDescripcion");
            Console.WriteLine("-----------------------------------------------------------------------------------");

            foreach (XmlNode desayuno in desayunos)
            {
                string nombre = desayuno["producto"].InnerText;
                string precio = desayuno["precio"].InnerText;
                string calorias = desayuno["calorias"].InnerText;
                string descrip = desayuno["descripcion"].InnerText;

                Console.WriteLine("{0}\t{1}\t{2}\t{3}", nombre, precio, calorias, descrip);
            }


            
        }
    }
}
