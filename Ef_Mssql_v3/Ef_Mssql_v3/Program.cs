using Ef_Mssql_v3.Modelos;
using Ef_Mssql_v3.Servicios;
using System;

namespace Ef_Mssql_v3
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new contextoDB())
            {
                db.Add(new Cliente
                {
                    Apellido = "Caruso",
                    Nombre = "El Gordo",
                    Domicilio = "Pje. Lafronda 22",
                    Localidad = "Rafael Castillo",
                    Telefono = "54-011-236-4569"

                });
                db.SaveChanges();
            }
        }
    }
}
