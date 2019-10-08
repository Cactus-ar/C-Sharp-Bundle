using System;
using System.Net;


/* Intenta establecer la IP externa de la terminal
 * 
 */

namespace ExtIP
{
    class Program
    {
        static void Main(string[] args)
        {

            string ips;

            using (WebClient client = new WebClient())
            {
                try
                {
                    ips = client.DownloadString("http://canihazip.com/s");
                }
                catch (WebException e)
                {
                    ips = "Sitio fuera de linea?";
                }

                Console.WriteLine("Mi ip es -> {0}", ips);
            }

            

        }

        
    }
}
