using classGeneral;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pListaEnlazadaDemo
{
    public partial class Form1 : Form
    {

        ListaEnlazadaSimple LESimple = new ListaEnlazadaSimple();

        ListaEnlazadaSimple LESimple2 = new ListaEnlazadaSimple();

        ListaEnlazadaSimple LESResultado = new ListaEnlazadaSimple();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int dato = int.Parse(txtDato.Text);
            // LESimple.InsertarAlInicio(dato);
            LESimple.InsertarAlFinal(dato);

            LlenarDatosListView();

            txtDato.Text = "";
            
            MessageBox.Show("Dato insertado", "Atención");
            txtDato.Focus();
        }



        private void LlenarDatosListView()
        {
            lvDatos.Items.Clear();

            Nodo aux = LESimple.Primero;

            // Ciclo para imprimir hasta que siguiente sea null
            while (aux != null)
            {
                // Console.Write(aux.Dato.ToString() + "=>");
                ListViewItem item = new ListViewItem(aux.ToString());
                aux = aux.Siguiente;
                if (aux != null)
                {
                    item.SubItems.Add(aux.ToString());
                }
                lvDatos.Items.Add(item);
            }
        }



        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            LESimple.OrdenarBurbuja();
            LlenarDatosListView();
        }


        /*
         * Metodo eliminar
         */
        private void button1_Click(object sender, EventArgs e)
        {

            string dato = txtDato.Text;

            int number;

            bool success = int.TryParse(dato, out number);
            if (success)
            {
                MessageBox.Show("Eliminando " + number, "Atención");
                LESimple.EliminarElemento(number);
                LlenarDatosListView();
            }
            else
            {
                MessageBox.Show("El dato ingresado no es un número " + number, "Atención");
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dato = txtDato.Text;

            int number;

            bool success = int.TryParse(dato, out number);
            if (success)
            {
                if(LESimple.BuscarElemento(number))
                {
                    MessageBox.Show("Nodo " + number + " encontrado", "Atención");
                }
                else
                {
                    MessageBox.Show("Nodo NO encontrado", "Atención");
                }
            }
            else
            {
                MessageBox.Show("El dato ingresado no es un número " + number, "Atención");
            }
        }




        /**
         * Metodos para insertar en lista 2
         */
        private void btnAgregar2_Click(object sender, EventArgs e)
        {
            int dato = int.Parse(txtDato2.Text);
            LESimple2.InsertarAlFinal(dato);
            LlenarDatosListView2();
            txtDato2.Text = "";
            MessageBox.Show("Dato insertado", "Atención");
            txtDato2.Focus();
        }


        private void LlenarDatosListView2()
        {
            lvDatos2.Items.Clear();
            Nodo aux = LESimple2.Primero;
            while (aux != null)
            {
                ListViewItem item = new ListViewItem(aux.ToString());
                aux = aux.Siguiente;
                if (aux != null)
                {
                    item.SubItems.Add(aux.ToString());
                }
                lvDatos2.Items.Add(item);
            }
        }




        /*
         * Operación mezclar listas
         */
        private void btnMezclar_Click(object sender, EventArgs e)
        {
            LESResultado = LESResultado.mezclarListas(LESimple, LESimple2);
            LlenarDatosListViewResultado();
        }


        private void LlenarDatosListViewResultado()
        {
            lvResultado.Items.Clear();
            Nodo aux = LESResultado.Primero;
            while (aux != null)
            {
                ListViewItem item = new ListViewItem(aux.ToString());
                aux = aux.Siguiente;
                if (aux != null)
                {
                    item.SubItems.Add(aux.ToString());
                }
                lvResultado.Items.Add(item);
            }
        }
    }
}
