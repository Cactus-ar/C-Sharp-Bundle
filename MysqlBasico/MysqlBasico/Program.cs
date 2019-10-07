using MySql.Data.MySqlClient;
using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Net;


/*
 * Ssh es utilizado para extablecer una conexion con
 * el host (en este caso una maquina virtual)
 */

/* Conector basico con servidores mysql de Oracle
 * Por defecto no existen helpers para la conexion
 * con mysql, por ello Oracle mantiene una serie
 * de paquetes Nuget para tal fin
 * 
 * https://dev.mysql.com/downloads/connector/net/
 * 
 */

namespace MysqlBasico
{
    class Program
    {
        const string ssh_host = "host";
        const int ssh_puerto = 2222;
        const int ssh_puente = 3306;
        const string ssh_usuaro = "usuario";
        const string ssh_pwd = "password";


        static void Main(string[] args)
        {

            PasswordConnectionInfo conInfo = new PasswordConnectionInfo(ssh_host, ssh_puerto, ssh_usuaro, ssh_pwd);
            conInfo.Timeout = TimeSpan.FromSeconds(30);

            using (var cliente = new SshClient(conInfo))
            {
                try
                {
                    Console.WriteLine("Estableciendo Conexion");
                    cliente.Connect();
                    if(cliente.IsConnected)
                    {
                        Console.WriteLine("Conexion establecida: {0}", cliente.ConnectionInfo.ToString());
                    }else
                    {
                        Console.WriteLine("La conexion exploto: {0}", cliente.ConnectionInfo.ToString());
                    }

                    
                    Console.WriteLine("\r\nIntentando establecer tunel en...");
                    var portFwld = new ForwardedPortLocal(IPAddress.Loopback.ToString(), ssh_puerto, ssh_host, ssh_puente);
                    cliente.AddForwardedPort(portFwld);
                    portFwld.Start();
                    if (portFwld.IsStarted)
                    {
                        Console.WriteLine("Puente establecido en: {0}", portFwld.ToString());
                    }
                    else
                    {
                        Console.WriteLine("No es posuble establecer puente.");
                    }

                    Console.WriteLine("Intentando acceder a la Base de Datos");
                    MySqlConnection conn;
                    string myConnectionString;

                    myConnectionString = "server=" + ssh_host + ";port=" + ssh_puerto + ";uid=" + ssh_usuaro + ";pwd=" + ssh_pwd + ";database=TABLA";

                    try
                    {
                        conn = new MySqlConnection(myConnectionString);
                        conn.Open();

                        MySqlCommand comando = conn.CreateCommand();
                        comando.CommandText = "SELECT * from ...";
                        MySqlDataReader lector = comando.ExecuteReader();
                        while (lector.Read())
                        {
                            Console.WriteLine(lector["first_name"] + " " + lector["last_name"]);
                        }

                        conn.Close();

                    }
                    catch (MySqlException ex)
                    {
                        switch (ex.Number)
                        {
                            case 0:
                                Console.WriteLine("No es posible establecer conexion");
                                break;
                            case 1042:
                                Console.WriteLine("Unable");
                                break;
                            case 1045:
                                Console.WriteLine("user/password, incorrectos");
                                break;
                            default:
                                Console.WriteLine(ex.ToString());
                                break;
                        }
                    }


                }
                catch (SshException e)
                {
                    Console.WriteLine("cliente SSH conn err: {0}", e.Message);
                }
                catch (System.Net.Sockets.SocketException e)
                {
                    Console.WriteLine("error de Socket: {0}", e.Message);
                }

            }
           
        }
    }
}
