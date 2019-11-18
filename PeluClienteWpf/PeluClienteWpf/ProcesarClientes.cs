using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PeluClienteWpf
{
    public class ProcesarClientes
    {
        public static async Task<Cliente> TraerCliente(int Id = 0)
        {
            string url = "";

            if(Id > 0)
            {
                url = $"http://localhost:5000/api/clientes/{ Id }";

            }else
            {
                url = $"http://localhost:5000/api/clientes/";
            }

            using (HttpResponseMessage respuesta = await ConectorAPI.clienteAPI.GetAsync(url))
            {
                if (respuesta.IsSuccessStatusCode)
                {
                    Cliente cliente = await respuesta.Content.ReadAsAsync<Cliente>();
                    return cliente;
                }
                else
                {
                    throw new Exception(respuesta.ReasonPhrase);

                }
            }


        }
    }
}
