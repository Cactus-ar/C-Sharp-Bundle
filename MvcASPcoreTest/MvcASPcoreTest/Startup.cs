using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcASPcoreTest.Helpers;
using Microsoft.EntityFrameworkCore;

//Simple ejemplo de uso de modelo MVC para el servicio
//de entrega de informacion a traves de ASP net Core.
/*
    Holamundo entrega cadenas sin generar vistas
    Razor devuleve vistas alojadas en la carpeta Views
    por ultimo se genera un modelo existente dentro de una
    Db llamada Clientes

    El modelo y el Db context toman los datos de la clase Cliente
    y dentro de la carpeta helpers se encuentra el contextDB

    luego de establecida la conexion con el servidor, el controlador
    CRUD de la Db fue autogenerado con el scaffold del modelo cliente y el contexto

    Basicamente los pasos para una DB existente son

    - Crear el modelo (o usar ingenieria inversa para generarlos)
    - Crear el contexto de utilizacion de la DB, importando los paquetes referidos al uso especifico del engine
    - Generar por medio de scaffold si es viable, el controlador CRUD para la tabla en particular
    - Ello va a generar tambien las vistas simples.

    Otro ejemplo un poco mas elaborado seria consumir recursos de una api.
    es un pendiente que saldrá como ejemplo dentro de poco
    
*/


namespace MvcASPcoreTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //agregar el contexto de la DB
            services.AddDbContext<conectorDB>(opciones => opciones.UseSqlServer(Configuration.GetConnectionString("MvcClientes")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
