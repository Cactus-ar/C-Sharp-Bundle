using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ServicioConsola
{
    public class Latencia
    {
        private readonly Timer _timer;

        public Latencia()
        {
            _timer = new Timer(5000) { AutoReset = true };
            _timer.Elapsed += timer_Disparo;
        }

        private void timer_Disparo(object sender, ElapsedEventArgs e)
        {
            string[] lineas = new string[] { DateTime.Now.ToString() };
            File.AppendAllLines(@"C:\Temp\Demo\Latencia.txt", lineas);
        }

        public void Iniciar()
        {
            _timer.Start();
        }

        public void Detener()
        {
            _timer.Stop();
        }
    }
}
