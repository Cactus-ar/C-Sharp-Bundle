using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplicationTEST3.Entidades;

namespace WebApplicationTEST3.Servicios
{

    public interface IServicioUsuario
    {
        Usuario Autenticar(string _usuario, string _password);
        IEnumerable<Usuario> Listado();
        Usuario GetPorId(int _id);
    }

    public class ServicioUsuario : IServicioUsuario
    {

        //Harcoded..luego usar una DB
        private List<Usuario> _usuarios = new List<Usuario>
        {
            new Usuario {Id = 1, Nombre = "Sapallo", Apellido ="enlata", NombreUsuario = "cosmo", Password ="cosmo", Rol = Rol.Admin},
            new Usuario {Id = 2, Nombre = "pez", Apellido ="espada", NombreUsuario = "pepe", Password ="pepe", Rol = Rol.Admin},
            new Usuario {Id = 3, Nombre = "Roberto", Apellido ="Perez", NombreUsuario = "rober", Password ="tito", Rol = Rol.Usuario},
            new Usuario {Id = 4, Nombre = "Marco", Apellido ="Polo", NombreUsuario = "marco", Password ="polo", Rol = Rol.Usuario},
            new Usuario {Id = 5, Nombre = "Rosita", Apellido ="patti", NombreUsuario = "rosita", Password ="rosita", Rol = Rol.Usuario},
            new Usuario {Id = 6, Nombre = "Pipo", Apellido ="Ripito", NombreUsuario = "pipo", Password ="pipo", Rol = Rol.Usuario}
        };

        private readonly Config _config;

        public ServicioUsuario(IOptions<Config> config)
        {
            _config = config.Value;
        }

        public Usuario Autenticar(string _usuario, string _password)
        {
            var usuario = _usuarios.SingleOrDefault(x => x.NombreUsuario == _usuario && x.Password == _password);

            //retornar nulo si no es encontrado
            if (usuario == null)
            {
                return null;
            }
            //si autentico generar token
            var tokenHandler = new JwtSecurityTokenHandler();
            var llave = Encoding.ASCII.GetBytes(_config.Key_Secreta);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuario.Rol)
                }),

                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(llave), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            usuario.Token = tokenHandler.WriteToken(token);

            //remover el password antes de volver
            usuario.Password = null;
            return usuario;
        }


        public Usuario GetPorId(int _id)
        {
            var usuario = _usuarios.FirstOrDefault(x => x.Id == _id);

            //retornar usuario menos el password
            if(usuario != null)
            {
                usuario.Password = null;
            }

            return usuario;
        }

        public IEnumerable<Usuario> Listado()
        {
            return _usuarios.Select(x =>
            {
                x.Password = null;
                return x;
            });
        }
    }
}
