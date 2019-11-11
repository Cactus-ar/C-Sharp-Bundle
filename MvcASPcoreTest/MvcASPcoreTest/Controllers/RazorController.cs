using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MvcASPcoreTest.Controllers
{
    public class RazorController : Controller
    {
        //get: retorna el indice sin mas
        public IActionResult Index()
        {
            return View();
        }


        //get: /razor/bienvenido?nombre=Gabriel&intentos=10
        public IActionResult Bienvenido(string nombre, int intentos = 1)
        {
            ViewData["Bienvenida"] = "Hola, " + nombre;
            ViewData["Intentos"] = intentos;
            return View();
        }
    }
}