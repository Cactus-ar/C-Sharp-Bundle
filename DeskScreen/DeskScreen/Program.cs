using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

/*Ejemplo de timer y Captura
 * de pantalla */

namespace DeskScreen
{
    class Program
    {
        private static System.Timers.Timer aTimer;


        static void Main(string[] args)
        {
            SetTimer();

            Console.WriteLine("\nPresione una tecla para finalizar...\n");
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Finalizando...");


        }

        private static void SetTimer()
        {
           
            aTimer = new System.Timers.Timer(10000); //Setear un timer con interbalo de 10 segundos
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            var ancho = Screen.PrimaryScreen.Bounds.Width;
            var alto = Screen.PrimaryScreen.Bounds.Height;

            Bitmap captura = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(captura))
            {
                g.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size);
                Console.WriteLine("Captura de pantalla a las -> {0:HH:mm:ss.fff}", e.SignalTime);
                string nombre = "captura" + e.SignalTime.Ticks.ToString() + ".png";
                captura.Save(nombre);

            }

            
        }

        
    }
}
