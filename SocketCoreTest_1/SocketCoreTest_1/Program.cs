using System;
using System.Net;
using System.Net.Sockets;

namespace SocketCoreTest_1
{


    /*
    Demo de socket escuchando en el puerto especificado

    La aplicacion continuará escuchando hasta que el cliente haya establecido conexion
    luego de ello sin otra cosa que procesar termina.

    Para probar este comportamiento, necesitamos tener instalado el cliente Telnet
    con permisos de administrador puede instalarse desde la consola con:

     dism /online /Enable-Feature /FeatureName:TelnetClient

    una vez instalado intentamos accedes con
    
        Telnet localhost 23000

    quizas necesite permisos de admin para hacer la prueba, asi también otorgarle
    permisos a la aplicacion para que pueda atravesar el Firewall
    */


    class Program
    {
        static void Main(string[] args)
        {
            Socket Escuchar = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress DirIP = IPAddress.Any;

            int Puerto = 23000;

            IPEndPoint DirEndP = new IPEndPoint(DirIP, Puerto);

            Console.WriteLine("Escuchando");
            Escuchar.Bind(DirEndP);
            Escuchar.Listen(5);
            Escuchar.Accept();
            Console.WriteLine("Finalizado");

            
        }
    }
}
