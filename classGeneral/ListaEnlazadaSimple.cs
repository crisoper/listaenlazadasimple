using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace classGeneral
{
    public class ListaEnlazadaSimple
    {

        private Nodo primero;
        private Nodo aux;
        private Nodo ultimo;

        public Nodo Primero { get => primero; set => primero = value; }
        public Nodo Aux { get => aux; set => aux = value; }
        public Nodo Ultimo { get => ultimo; set => ultimo = value; }


        public ListaEnlazadaSimple()
        {
            primero = null;
            aux = null;
            ultimo = null;
        }


        public void InsertarAlInicio(int dato)
        {
            // Crear el nuevo nodo
            Nodo nuevoNodo = new Nodo(dato);
            
            // Referencia siguiente es igual a nodo primero
            nuevoNodo.Siguiente = primero;

            // Indicamos que el nuevo primero ahora es el nuevo nodo
            primero = nuevoNodo;

            if(Ultimo == null)
            {
                Ultimo = nuevoNodo;
            }

        }



        public void InsertarAlFinal(int dato)
        {
            //Se verifica que haya elementos en la lista
            if (Primero == null) {
                //De no haberlos crea el primer elemento
                InsertarAlInicio(dato);
                // Sólo en el Primer caso Ultimo = Primero;
                Ultimo = Primero;
            }
            else {
                Nodo nuevo = new Nodo(dato);

                aux = Ultimo;
                Ultimo.Siguiente = nuevo;
                Ultimo = Ultimo.Siguiente;

                #region Comentario
                /*
                 * Hacemos uso del puntero Ultimo
                 * El nodo ultimo lo almacenamos temporalmente
                 * Hacemos referencia al ultimo nodo
                */
                #endregion
            }
        }



        public int NumeroElementos()
        {
            aux = primero;
            int contador = 0;

            while (aux != null)
            {
                aux = aux.Siguiente;
                contador = contador + 1;
            }
            return contador;
        }



        public bool Vacia()
        {
            return Primero == null;
        }



        #region Comentario
        /*
         * Metodo Burbuja Mejorada, es uno de los métodos mas efectivos
         * El punto clave es no es solo cambiar
         * los punteros para moverse a través de la lista
         * sino cambiar las ligas entre los diferentes nodos
         * e identificar el nodo anterior
         * https://es.stackoverflow.com/questions/10682/c%C3%B3mo-puedo-ordenar-una-lista-simples-enlazadas
        */
        #endregion
        public void OrdenarBurbuja()
        {
            if (!Vacia())
            {
                bool cambio;
                do
                {
                    Console.WriteLine("\nIniciando iteración");
                    
                    Nodo actual = Primero;
                    Nodo anterior = null;
                    Nodo siguiente = Primero.Siguiente;
                    cambio = false;

                    while (siguiente != null)
                    {
                        if (actual.Dato > siguiente.Dato)
                        {
                            Console.WriteLine("Actual " + actual.Dato + " > " + 
                                "Sig " + siguiente.Dato);
                            cambio = true;
                            if (anterior != null)
                            {
                                Nodo sig = siguiente.Siguiente;
                                anterior.Siguiente = siguiente;
                                siguiente.Siguiente = actual;
                                actual.Siguiente = sig;
                            }
                            else
                            {
                                Nodo sig = siguiente.Siguiente;
                                primero = siguiente;
                                siguiente.Siguiente = actual;
                                actual.Siguiente = sig;
                            }
                            anterior = siguiente;
                            siguiente = actual.Siguiente;
                        }
                        else
                        {   // Seguimos la iteracion
                            Console.WriteLine("Actual " + actual.Dato + 
                                " <= " + "Sig " + siguiente.Dato);
                            anterior = actual;
                            actual = siguiente;
                            siguiente = siguiente.Siguiente;
                        }
                    }
                } while (cambio);
            }
        }



        public void EliminarElemento(int dato)
        {
            if(!Vacia())
            {
                Nodo actual = Primero;
                Nodo anterior = null;

                while (actual != null)
                {
                    Console.WriteLine("Elemento actual " + actual.Dato);
                    Console.WriteLine("Elemento anterior " + anterior?.Dato);

                    if (actual.Dato == dato)
                    {
                        // Debemos elimininar el elemento
                        if (Primero.Dato == dato)
                        {
                            Primero = Primero.Siguiente;
                            anterior = null;
                            actual = actual.Siguiente;
                        }
                        else if (actual.Dato == Ultimo.Dato)
                        {
                            Ultimo = anterior;
                            // Al ser el ultimo nodo, no se requiere hacer la transición
                            anterior.Siguiente = null;
                            anterior = null;
                            actual = null;
                        }
                        else
                        {
                            // Se requiere enlazar el nodo anterior con el nuevo
                            anterior.Siguiente = actual.Siguiente;
                            anterior = actual;
                            actual = actual.Siguiente;
                        }

                    }
                    else
                    {
                        anterior = actual;  
                        actual = actual.Siguiente;
                    }
                }
            }
        }


        public bool BuscarElemento(int Dato)
        {
            bool encontrado =  false;
            Nodo aux = Primero;

            while (aux != null)
            {
                if(aux.Dato == Dato)
                {
                    encontrado = true;
                }
                aux = aux.Siguiente;
            }

            return encontrado;
        }


        public ListaEnlazadaSimple mezclarListas(ListaEnlazadaSimple les1, 
            ListaEnlazadaSimple les2)
        {
            ListaEnlazadaSimple nueva = new ListaEnlazadaSimple();
            // Recorriendo datos lista 01
            Nodo temporal = les1.Primero;
            while (temporal != null)
            {
                if (!nueva.BuscarElemento(temporal.Dato)) {
                    nueva.InsertarAlFinal(temporal.Dato);
                }
                temporal = temporal.Siguiente;
            }


            // Recorriendo datos lista 02
            temporal = les2.Primero;
            while (temporal != null)
            {
                if (!nueva.BuscarElemento(temporal.Dato)){
                    nueva.InsertarAlFinal(temporal.Dato);
                }
                temporal = temporal.Siguiente;
            }
            return nueva;
        }

    }
}
