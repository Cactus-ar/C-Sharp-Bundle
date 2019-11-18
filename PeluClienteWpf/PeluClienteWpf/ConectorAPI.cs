using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace PeluClienteWpf
{
    public static class ConectorAPI
    {
        public static HttpClient clienteAPI { get; set; }

        public static void InicializarCliente()
        {
            clienteAPI = new HttpClient();
            //clienteAPI.BaseAddress = new Uri("http://localhost:5000/");
            clienteAPI.DefaultRequestHeaders.Accept.Clear();
            clienteAPI.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
