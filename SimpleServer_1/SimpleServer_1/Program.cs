using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

/*
 * Simple server que esta constantemente escuchando
 * el puerto X y envia un mensaje de bienvenida
 * al cliente. solo acepta 1 conexion por vez
 * 
 * mientras el cliente este activo, hace un eco del teclado
 */



namespace SimpleServer_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int puerto = 8989; //puerto tcp
            

            TcpListener servidor = new TcpListener(IPAddress.Any, puerto);

            servidor.Start();

            while (true)
            {
                TcpClient cliente = servidor.AcceptTcpClient();
                NetworkStream stream = cliente.GetStream();
                byte[] _saludo = new byte[100];
                _saludo = Encoding.Default.GetBytes("Bienvenido");
                stream.Write(_saludo, 0, _saludo.Length);

                while (cliente.Connected)
                {
                    byte[] mensaje = new byte[1024];
                    stream.Read(mensaje, 0, mensaje.Length);
                    string captura = Encoding.Default.GetString(mensaje).Trim(' ').ToString();
                    Console.WriteLine("Captura -> {0}", captura);
                }
            }
        }
    }
}
