using System;

namespace ImplementacionBasica
{
    /* Demo de una implementacion basica y muy clasica de como
     * utilizar interfaces
     */

    class Program
    {
        static void Main(string[] args)
        {
            Pato patitoMarron = new PatoMarron();
            patitoMarron.Display();
            patitoMarron.Volar();
            


            Pato patitoBlanco = new PatoBlanco();
            patitoBlanco.Display();
            patitoBlanco.Volar();
            
            
        }
    }


    public class PatoBlanco : Pato
    {
        public override void Display()
        {
            Console.WriteLine("Soy un pato de Color Blanco");
        }

    }


    public class PatoMarron : Pato
    {
        
        public override void Display()
        {
            Console.WriteLine("Soy un Pato de color Marron");
        }

    }


    public abstract class Pato
    {

        ComportamientoAlVolar _comportamientoAlVolar;
    

        public Pato()
        {

        }

        public abstract void Display();

    
        public void Volar()
        {
            _comportamientoAlVolar.Vuela();
        }
    }

    public interface ComportamientoAlVolar
    {
        public void Vuela();
    }

    public class VolarConAlas : ComportamientoAlVolar
    {
        public void Vuela()
        {
            Console.WriteLine("Yo vuelo con mis alas");
        }
    }

    public class NoVuelo : ComportamientoAlVolar
    {
        public void Vuela()
        {
            Console.WriteLine("Yo no puedo Volar");
        }
    }


}
