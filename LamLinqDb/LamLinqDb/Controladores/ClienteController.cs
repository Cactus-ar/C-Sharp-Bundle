using LamLinqDb.Helpers;
using LamLinqDb.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LamLinqDb.Controladores
{
    class ClienteController : ICliente
    {

        DbConexion _context = new DbConexion();

        public ClienteController( contexto)
        {
            _context = contexto;
        }




        public void Alta()
        {
            throw new NotImplementedException();
        }
    }
}
