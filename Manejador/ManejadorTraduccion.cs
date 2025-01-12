using Entidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador
{
    public class ManejadorTraduccion
    {
        ManejadorLexico ml = new ManejadorLexico();
        ManejadoSemantico ms = new ManejadoSemantico();
        ManejadorSintactico msi = new ManejadorSintactico();
        #region metoditos
        string clase(DataGridView tabla, int contador, int pin1, int pin2)
        {
            string codigo = "";
            if (tabla.Rows[contador].Cells[1].Value.ToString() == "clase")
            {
                codigo += "#include <Taladro.h>\r\nFunciones t;\r\nvoid setup()\r\n{\r\npinMode(" + pin1 + ",OUTPUT);\r\npinMode(" + pin2 + ",OUTPUT);\r\n}\r\n";
            }
            return codigo;
        }
        string apertura(DataGridView tabla, int contador)
        {
            string codigo = "";
            if (tabla.Rows[contador].Cells[1].Value.ToString().Equals("<"))
            {
                codigo += "void loop()\r\n{\r\n";
            }
            return codigo;
        }
        string cierre(DataGridView tabla, int contador)
        {
            string codigo = "";
            if (tabla.Rows[contador].Cells[1].Value.ToString().Equals(">"))
            {
                codigo += "}\r\n";
            }
            return codigo;
        }
        string tipoDato(DataGridView tabla, int contador)
        {
            string codigo = "";
            if (tabla.Rows[contador].Cells[1].Value.ToString().Equals("numero"))
            {
                codigo += "int " + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " = " +
                    tabla.Rows[contador + 3].Cells[1].Value.ToString() + ";\r\n";
            }
            return codigo;
        }
        string instruccion(DataGridView tabla, int contador, int pin1, int pin2)
        {
            Regex identificador = new Regex(@"\A[a-z,A-Z]\w*?\Z");
            Regex operaciones = new Regex(@"\A((verdadero)|(falso)|(([0-9]+)(((\+)([0-9]+))|((\-)([0-9]+))|((/)([0-9]+))|((\*)([0-9]+))))*)\Z");
            Regex valorIden = new Regex(@"\A(([A-z,a-z]\w*?)(((\+)(([0-9]+)|([A-z,a-z]\w*?)))|((\-)(([0-9]+)|([A-z,a-z]\w*?)))|((/)(([0-9]+)|([A-z,a-z]\w*?)))|((\*)(([0-9]+)|([A-z,a-z]\w*?))))+)\Z");
            Regex numeros = new Regex(@"\A[0-9]+\Z");
            string codigo = "", valor = "", valor2 = "";
            int contador2 = 0;
            if (tabla.Rows[contador].Cells[2].Value.ToString().Equals("Instrucción"))
            {
                valor = tabla.Rows[contador + 1].Cells[1].Value.ToString();
                contador2++;
                while (valor[contador2] != ')')
                {
                    valor2 += valor[contador2];
                    if(contador2 < valor2.Length + 1)
                    {
                        contador2++;
                    }
                }
                if (tabla.Rows[contador].Cells[1].Value.ToString().Equals("atornillar"))
                {
                    if(valorIden.IsMatch(valor2) || identificador.IsMatch(valor2) || operaciones.IsMatch(valor2))
                    {
                        codigo += "if((((" + valor2 + ")*12)+100) > 230)\r\n  t.atornillar(" + pin1.ToString() + "," + pin2.ToString() + ",230);\r\n" +
                            "else\r\n  t.atornillar(" + pin1.ToString() + "," + pin2.ToString() + "," + valor2 + ");\r\n";
                    }else
                    if (numeros.IsMatch(valor2))
                    {
                        codigo += "t.atornillar(" + pin1.ToString() + "," + pin2.ToString() + "," + valor2 + ");\r\n";
                    }
                        
                }
                if (tabla.Rows[contador].Cells[1].Value.ToString().Equals("desatornillar"))
                {
                    if (valorIden.IsMatch(valor2) || identificador.IsMatch(valor2) || operaciones.IsMatch(valor2))
                    {
                        codigo += "if(((" + valor2 + "*12)+100) > 230)\r\n  t.desatornillar(" + pin1.ToString() + "," + pin2.ToString() + ",230);\r\n" +
                            "else\r\n  t.desatornillar(" + pin1.ToString() + "," + pin2.ToString() + "," + valor2 + ");\r\n";
                    }
                    else
                    if (!identificador.IsMatch(valor2))
                    {
                        codigo += "t.desatornillar(" + pin1.ToString() + "," + pin2.ToString()+"," + valor2 + ");\r\n";
                    }                
                }
                if (tabla.Rows[contador].Cells[1].Value.ToString().Equals("tiempo"))
                {
                    if(valorIden.IsMatch(valor2) || operaciones.IsMatch(valor2) || identificador.IsMatch(valor2))
                    {
                        codigo += "t.tiempo(" + valor2 + ");\r\n";
                    }
                    else
                    if (!identificador.IsMatch(valor2))
                    {
                        codigo += "t.tiempo(" + int.Parse(valor2.ToString()) + ");\r\n";
                    }
                }
                if (tabla.Rows[contador].Cells[1].Value.ToString().Equals("apagar"))
                {
                    codigo += "t.apagar(" + pin1.ToString() + ","+ pin2.ToString() + ");\r\n";
                }
            }
            return codigo;
        }
        string comentario(DataGridView tabla, int contador)
        {
            string codigo = "";
            if (tabla.Rows[contador].Cells[2].Value.ToString().Equals("Comentario"))
            {
                codigo += tabla.Rows[contador].Cells[1].Value.ToString() + "\r\n";
            }
            return codigo;
        }
        #endregion
        public string traduccion(DataGridView tabla, int pin1, int pin2, string texto, List<Tokens> lista, string a, string p)
        {
            string textoBat = "";
            Process pr = new Process();
            ml.HacerLexicos(texto, lista, tabla);
            string traduccionowo = "";
            int contador = 0;
            while (contador < tabla.RowCount || (tabla.RowCount == 1 && contador == 0))
            {
                traduccionowo += clase(tabla, contador, pin1, pin2);
                traduccionowo += apertura(tabla, contador);
                traduccionowo += cierre(tabla, contador);
                traduccionowo += tipoDato(tabla, contador);
                traduccionowo += instruccion(tabla, contador, pin1, pin2);
                traduccionowo += comentario(tabla, contador);
                contador++;
            }
            TextWriter archivo = new StreamWriter(@"C:\OneDrive\Documentos\Escuela\Programación\Lenguajes y autómatas II\Proyectos\Copia 1\PresentaciónCompilador\PresentaciónCompilador\bin\Debug\test.ino");
            archivo.Write(traduccionowo);
            archivo.Close();
            TextWriter compilar = new StreamWriter(@"C:\OneDrive\Documentos\Escuela\Programación\Lenguajes y autómatas II\Proyectos\Copia 1\PresentaciónCompilador\PresentaciónCompilador\bin\Debug\Compilar.bat");
            textoBat = string.Format("@echo off\narduinouploader test.ino {0} {1}", a, p);
            compilar.Write(textoBat);
            compilar.Close();
            //MessageBox.Show(traduccionowo);
            pr.StartInfo.FileName = @"C:\OneDrive\Documentos\Escuela\Programación\Lenguajes y autómatas II\Proyectos\Copia 1\PresentaciónCompilador\PresentaciónCompilador\bin\Debug\Compilar.bat";
            pr.Start();
            return traduccionowo;
        }
        public string ejecutar(DataGridView tabla, int pin1, int pin2, string texto, List<Tokens> lista, string a, string p)
        {
            ml.HacerLexicos(texto, lista, tabla);
            string traduccionowo = "", sintactico, semantico;
            sintactico = msi.Evaluar(tabla);
            semantico = ms.ejecutar(tabla);
            if (sintactico == "")
            {
                if (semantico == "")
                {
                    traduccionowo = traduccion(tabla, pin1, pin2, texto, lista, a, p);
                }
                else
                    MessageBox.Show(semantico);
            }
            else
                MessageBox.Show(sintactico);
            return traduccionowo;
        }
        public void puertos(ComboBox cmbPuerto)
        {
            string[] puertos = SerialPort.GetPortNames();
            cmbPuerto.Items.Clear();
            foreach (string puerto in puertos)
            {
                cmbPuerto.Items.Add(puerto);
            }
            if (cmbPuerto.Items.Count > 0)
                cmbPuerto.SelectedIndex = 0;
        }
    }
}