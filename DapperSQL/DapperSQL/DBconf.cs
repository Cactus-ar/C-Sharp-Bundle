using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSQL
{
    public static class DBconf
    {
        public static string CadenaConexion(string cadena)
        {
            return ConfigurationManager.ConnectionStrings[cadena].ConnectionString;
        }
    }
}
