using Entidades;
using Manejador;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentaciónCompilador
{
    public partial class FrmPrincipal : Form
    {
        ManejadorLexico ml;
        ManejadorSintactico ms;
        ManejadorSemantico ms2;
        ManejadorTraduccion mt;
        List<Tokens> lista = new List<Tokens>();
        public FrmPrincipal()
        {
            InitializeComponent();
            ms = new ManejadorSintactico();
            ms2 = new ManejadorSemantico();
            ml = new ManejadorLexico();
            mt = new ManejadorTraduccion();
        }

        private void btnLexico_Click(object sender, EventArgs e)
        {
            ml.HacerLexicos(txtTexto.Text, lista, dtgTabla);
        }

        private void btnSintactico_Click(object sender, EventArgs e)
        {
            if (txtTexto.Text.Equals(""))
            {
                MessageBox.Show("Indefinido");
            }
            ms.comprobar(txtTexto.Text, lista, dtgTabla);
        }

        private void btnSemantico_Click(object sender, EventArgs e)
        {
            ms2.comprobar(txtTexto.Text,lista,dtgTabla);
        }

        private void btnTraducir_Click(object sender, EventArgs e)
        {
            if (!txtPin1.Text.Equals("") || !txtPin2.Text.Equals(""))
            {
                if (!cmbPuerto.Text.Equals("") && !cmbPlaca.Text.Equals(""))
                {
                    if (int.Parse(txtPin1.Text) < 13 && int.Parse(txtPin1.Text) > 0 && int.Parse(txtPin2.Text) < 13 && int.Parse(txtPin2.Text) > 0)
                        txtTraduccion.Text = mt.ejecutar(dtgTabla, int.Parse(txtPin1.Text), int.Parse(txtPin2.Text), txtTexto.Text, lista
                            , cmbPlaca.SelectedItem.ToString().Substring(0, 2), cmbPuerto.Text);
                    else
                        MessageBox.Show("Los pines sólo pueden ser valores del 1 al 13");
                }
                else
                    MessageBox.Show("No se ha seleccionado la placa o el puerto");
            }
            else
                MessageBox.Show("No se han declarado los pines");
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            mt.puertos(cmbPuerto);
            //cmbPuerto.Text = "COM4";
        }
    }
}
