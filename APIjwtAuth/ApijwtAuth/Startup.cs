using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using WebApplicationTEST3.Entidades;
using WebApplicationTEST3.Servicios;
using Microsoft.IdentityModel.Tokens;


/*
 * Este ejemplo muestra como realizar un acceso basado en roles
 * El servicio de usuarios contiene una lista con diferentes usuarios y roles
 * que dependiendo del nivel de acceso dado en el controlador puede ancceder
 * al consumo de los diferentes recursos de la api
 * 
 * para probar el ejemplo con postman:
 * 
 * generar una peticion POST, pasando a localhost:xxx/api/usuarios/autenticar en formato json el usuario y contraseña
 * luego de autenticado copiar y utilizar el token generado para realizar consultas
 * 
 */

namespace ApijwtAuth
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc(options => options.EnableEndpointRouting = false );


            // leer la entrada del appjson
            var appSettingsSection = Configuration.GetSection("Config");
            services.Configure<Config>(appSettingsSection);

            // jwt autenticacion
            var appSettings = appSettingsSection.Get<Config>();
            var key = Encoding.ASCII.GetBytes(appSettings.Key_Secreta);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            
            services.AddScoped<IServicioUsuario, ServicioUsuario>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // politicas globales de cors
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();

            app.UseRouting();
            app.UseMvc();

           
        }
    }
}
