using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SMNstatusApp
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HttpClient cliente;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            cliente = new HttpClient();
            return base.StartAsync(cancellationToken);
        }


        public override Task StopAsync(CancellationToken cancellationToken)
        {
            cliente.Dispose();
            return base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) //no para hasta que la ejecucion es cancelada
            {
                
                var resultado = await cliente.GetAsync("https://www.smn.gov.ar");

                
                if(resultado.IsSuccessStatusCode)
                {
                    _logger.LogInformation("El sitio es UP, {StatusCode}", resultado.StatusCode);
                }
                else
                {
                    _logger.LogError("El sitio esta offline {StatusCode}", resultado.StatusCode);
                }

                //Obviamente deberia ir a una base de datos, un archivo de LOG...etc.
                //un paquete nuguet que puede suplir eso es seliog.aspnetcore


                await Task.Delay(60*1000, stoppingToken); //cada 60 segundos?(60*1000)
            }
        }
    }
}
