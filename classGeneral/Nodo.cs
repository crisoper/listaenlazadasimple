using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classGeneral
{
    public class Nodo
    {
        /*
         * Propiedades del tipo privado
         */
        private int dato;
        private Nodo siguiente;

        /*
         * Métodos get & set de las propiedades
         */
        public int Dato { get => dato; set => dato = value; }
        public Nodo Siguiente { get => siguiente; set => siguiente = value; }

        /*
         * Constructor con parámetro
         */
        public Nodo(int dato)
        {
            this.Dato = dato;
            this.Siguiente = null;
        }


        /*
         * Constructor por defecto
         */
        public Nodo()
        {
            this.Siguiente = null;
        }


        #region Comentario
        /*
         * Sobre escribimos metodo to String
         * Permite imprimir directamente el nodo
        */
        #endregion
        public override string ToString()
        {
            return this.Dato.ToString();
        }
    }
}
