using System;

/*
 * La idea detras de este ejemplo
 * es mostrar como implementar el uso de interfaces
 * para desacoplar las clases.
 * Esto hace que el mantenimiento del codigo sea mucho 
 * mas sencillo.
 */
 
/* Partiendo del concepto general:
 * Que es una interfaz?
 * Una interfaz o interface define el comportamiento de una clase debe tener
 * pero NO como ese comportamiento debe estar implementado.
 * Una interfaz se mantiene separada de la construccion de la clase, pero requiere 
 * de una clase que provea el codigo para que su implementacion se concrete
 */

 /* Las interfaces son definidas utilizando la palabre clave interface,
  * pueden contener propiedades, metodos y eventos de igual forma que una clase comun y corriente.
  * Sin embargo, ningun elemento de una interface tiene acceso a modificadores de ningun tipo.
  * La clase que va a implementar la interfaz debe hacerlo con acceso publico.
  * Debajo se muetra el ejemplo de como declarar una simple interfaz junto a una posible implementacion
  */


namespace CoreInterfaces
{
    class Basica
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    //Creacion de una Interface
    public interface ISoyUnaInterface //Notese la palabra clave interface
    {
        void EsteMetodoRequiereImplementacion();

        string EstaPropiedadRequiereImplementacion
        {
            get;
            set;
        }

        int EstaPropiedadSoloTieneUnGetter
        {
            get;
        }

        event EventHandler<EventArgs> InterfacesPuedenContenerEventos;
    }

    //Clase Que va a Implementar la interface creada arriba
    public class ClaseImplementandoLaInterfaz : ISoyUnaInterface //Notese la implementacion luego del :
    {
        //a la hora de implementar la interfaz con la ayuda del helper de Visual studio,
        //el autocompletar va a insertar de forma automatica el uso de la excepcion de no implementado
        //como ayuda para que si todavia no se ha escrito el codigo, el error pueda ser interceptado.


        public string EstaPropiedadRequiereImplementacion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int EstaPropiedadSoloTieneUnGetter => throw new NotImplementedException();

        public event EventHandler<EventArgs> InterfacesPuedenContenerEventos;

        public void EsteMetodoRequiereImplementacion()
        {
            throw new NotImplementedException();
        }
    }



}
