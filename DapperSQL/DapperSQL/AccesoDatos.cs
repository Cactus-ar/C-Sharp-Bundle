using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSQL
{
    public class AccesoDatos
    {
        public List<Persona> GetPersonas(string apellido)
        {
            using (IDbConnection conexion = new System.Data.SqlClient.SqlConnection(DBconf.CadenaConexion("MsSqlClientes")))
            {
                var salida = conexion.Query<Persona>($"select * from Clientes where apellido = '{ apellido }'").ToList();
                //var salida = conexion.Query<Persona>($"select * from Clientes").ToList();
                return salida;
            }
        }

        public List<Persona> GetPersonasStProcedure(string apellido)
        {
            using (IDbConnection conexion = new System.Data.SqlClient.SqlConnection(DBconf.CadenaConexion("MsSqlClientes")))
            {
                var salida = conexion.Query<Persona>("dbo.seleccionar_500 @Apellido", new { Apellido = apellido }).ToList();
                return salida;
            }
        }
    }
}
