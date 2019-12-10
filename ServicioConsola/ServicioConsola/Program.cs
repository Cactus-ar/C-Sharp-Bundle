using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;


/*
 * Pequeño ejemplo de servicio y consola
 * para no lidiar con el tema de registrar el servicio uso TopShelf
 * 
 * para registrar el servicio hay que ubicar el programa en un directorio
 * con privilegios e inamovible
 * 
 * luego desde la consola se puede ejecutar 
 * programa.exe install start
 * 
 * 
 */

namespace ServicioConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitCode = HostFactory.Run(x =>
           {
               x.Service<Latencia>(s => 
               {
                   s.ConstructUsing(latencia => new Latencia());
                   s.WhenStarted(latencia => latencia.Iniciar());
                   s.WhenStopped(latencia => latencia.Detener());
               });

               x.RunAsLocalSystem();
               x.SetServiceName("ServicioLatencia");
               x.SetDisplayName("Servicio de Latencia");
               x.SetDescription("Ejemplo de servicio corriendo con TopShelf");

           });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;

        }
    }
}
