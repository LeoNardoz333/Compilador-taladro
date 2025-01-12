using Entidades;
using Manejador;
using System;
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
    public partial class FrmAplicacion : Form
    {
        ManejadorLexico ml;
        ManejadorSintactico ms;
        ManejadorSemantico ms2;
        ManejadorTraduccion mt;
        List<Tokens> lista = new List<Tokens>();
        public FrmAplicacion()
        {
            InitializeComponent();
            ms = new ManejadorSintactico();
            ms2 = new ManejadorSemantico();
            ml = new ManejadorLexico();
            mt = new ManejadorTraduccion();
        }

        private void btnTraducir_Click(object sender, EventArgs e)
        {
            if (!txtPin1.Text.Equals("") || !txtPin2.Text.Equals(""))
            {
                if (!cmbPuerto.Text.Equals("") && !cmbPlaca.Text.Equals(""))
                {
                    if (int.Parse(txtPin1.Text) < 13 && int.Parse(txtPin1.Text) > 0 && int.Parse(txtPin2.Text) < 13 && int.Parse(txtPin2.Text) > 0)
                    {
                        mt.ejecutar(dtgTabla, int.Parse(txtPin1.Text), int.Parse(txtPin2.Text), txtTexto.Text, lista
                            , cmbPlaca.SelectedItem.ToString().Substring(0, 2), cmbPuerto.Text);
                        //MessageBox.Show(mt.ejecutar(dtgTabla, int.Parse(txtPin1.Text), int.Parse(txtPin2.Text), txtTexto.Text, lista
                            //, cmbPlaca.SelectedItem.ToString().Substring(0, 2), cmbPuerto.Text));
                    }
                    else
                        MessageBox.Show("Los pines sólo pueden ser valores del 1 al 13");
                }
                else
                    MessageBox.Show("No se ha seleccionado la placa o el puerto");
            }
            else
                MessageBox.Show("No se han declarado los pines");
        }

        private void FrmAplicacion_Load(object sender, EventArgs e)
        {
            mt.puertos(cmbPuerto);
        }
    }
}
