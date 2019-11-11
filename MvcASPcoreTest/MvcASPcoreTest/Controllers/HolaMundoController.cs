using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcASPcoreTest.Controllers
{
    public class HolaMundoController : Controller
    {
        //Get : HolaMundo
        public string Index()
        {
            return "Esta es la accion por defecto devuelta por Index...";
            
        }

        //get: /HolaMundo/Bienvendo/
        public string Bienvenido()
        {
            return "Retorno de la accion Bienvenido";
        }

        //get:  /HolaMundo/Hola?nombre=XXXXX    //sin especificar numeroVeces retorna 1
        //get:  /HolaMundo/Hola?nombre=Nico&numeroVeces=34666
        public string Hola(string nombre, int numeroVeces = 1)
        {
            return HtmlEncoder.Default.Encode($"Hola {nombre}, numeroVeces es: {numeroVeces}");
        }

        //get: /HolaMundo/Holaconid/3?nombre=Rick
        public string HolaConId(string nombre, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Holaa {nombre}, tu ID es:{ID}");
        }


    }
}