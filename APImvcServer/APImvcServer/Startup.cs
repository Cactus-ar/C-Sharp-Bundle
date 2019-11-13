using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APImvcServer.Interfaces;
using APImvcServer.Repositorios;
using APImvcServer.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/*
 * Ejemplo de un servidor de datos REST con interface API
 * no es un code first aproach. las tablas ya fueron generadas
 * (de un cliente real como ejemplo)
 */

namespace APImvcServer
{
    public class Startup
    {

        public static IConfiguration Config { get; set; }

        public Startup(IConfiguration config)
        {
            Config = config;
        }

        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);


            //DB contexto y engine setup
            var stringDeConexion = Config["stringDB:SalonRulito"];
            services.AddDbContext<ContextoClientesDB>(con => con.UseSqlServer(stringDeConexion));


            //registrar servicios
            services.AddScoped<ICliente, RCliente>();


        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseMvc();

        }
    }
}
