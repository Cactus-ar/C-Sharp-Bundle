using System;
using System.Collections.Generic;
using System.Text;

namespace CoreInterfaces
{
    /* Una clase puede implementar multiples interfaces
     * 
     * No hay un limite impuesto al numero de interfaces que una clase puede implementar
     * es mas una cuestion de diseño que otra cosa la que deberia de preocupar
     * 
     * Debido a ello, puede haber multiples interfaces implementadas en una sola
     * clase y una simple interfaz puede ser implementada en multiples clases.
     */

    public interface InterfaceNumeroUno
    {
        void MetodoUno();

    }

    public interface InterfaceNumeroDos
    {
        void MetodoDos();
    }

    class Doble : InterfaceNumeroUno, InterfaceNumeroDos
    {
        public void MetodoDos()
        {
            throw new NotImplementedException();
        }

        public void MetodoUno()
        {
            throw new NotImplementedException();
        }
    }
}
