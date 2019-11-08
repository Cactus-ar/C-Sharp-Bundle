using Bogus;
using System;


/* Faker es una vieja libreria de PHP utilizada
 * para generar fake data (datos falsos) e incrustarlos
 * en una Db con el proposito de probar codigo o 
 * rendimiento
 * 
 * el paquete nuguet que se necesita se llama Bogus
 * https://github.com/bchavez/Bogus
 * 
 * la intencion es mostrar el uso del paquete en este ejemplo
 * y no incrustar los daos en una db..que podria facilmente 
 * hacerse con algunas lineas mas de codigo
 * 
 * este es un pequeño ejemplo, la libreria es endemoniadamente compleja y extensa
 */


namespace Faker_Ejemplo
{

    class Program
    {
        static void Main(string[] args)
        {
            var salir = false;

            do
            {

                var usuario = new Usuario();
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"Nombre: {usuario.Nombre}");
                Console.WriteLine($"Apellido: {usuario.Apellido}");
                Console.WriteLine($"Domicilio {usuario.Domicilio}");
                Console.WriteLine($"D.N.I.: {usuario.Dni}");
                Console.WriteLine($"Email: {usuario.Email}");
                Console.WriteLine($"Telefono: {usuario.Telefono}");
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Cualquier tecla genera otro o S..salir");
                var tecla = Console.ReadKey();
                if (tecla.KeyChar == 'S' || tecla.KeyChar == 's')
                    salir = true;

            } while (!salir);

            Console.WriteLine("Bye");


            
        }
    }

    class Usuario
    {
        public string Nombre;
        public string Apellido;
        public string Domicilio;
        public int Dni;
        public string Email;
        public string Telefono;

        public Usuario()
        {
            var data = new Faker("es_MX"); //Notese la localizacion

            Nombre = data.Person.FirstName;
            Apellido = data.Person.LastName;
            Domicilio = data.Address.StreetAddress(true);
            Dni = data.Random.Number(99999999);
            Email = data.Internet.Email();
            Telefono = data.Phone.PhoneNumber();

        }
    }
}
