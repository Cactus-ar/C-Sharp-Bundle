using System;
using System.Collections.Generic;
using System.Text;

namespace CoreInterfaces
{
    /*
     * La interfaces pueden ser implementadas de forma explicita.
     * Difieren de la implicitas (los ejemplos anteriores)
     */

    /* Como puede observarse se requiere la referencia a interface
     * de forma obligatoria.
     */

    public class Explicita : ISoyUnaInterface
    {
        private int IntEncapsulado;
        private event EventHandler<EventArgs> eventoEncapsulado;

        public Explicita()
        {
            this.IntEncapsulado = 4;
        }


        string ISoyUnaInterface.EstaPropiedadRequiereImplementacion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        int ISoyUnaInterface.EstaPropiedadSoloTieneUnGetter
        {
            get
            {
                return IntEncapsulado;
            }
        }

        event EventHandler<EventArgs> ISoyUnaInterface.InterfacesPuedenContenerEventos
        {
            add { eventoEncapsulado += value; }
            remove { eventoEncapsulado -= value; }
        }

        void ISoyUnaInterface.EsteMetodoRequiereImplementacion()
        {
            eventoEncapsulado(this, EventArgs.Empty);
        }
    }
}
