using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Manejador
{
    public class ManejadorLexico
    {
        int i = 0, k = 0, j = 0;
        string rss = "";

        public void recursivoSentencias(string[] separadores, string valor, string tipo, int contador, List<Tokens> tabla, int no)
        {
            if (i < separadores.Length)
            {
                Tokens tokens = new Tokens(0, "", "", 0);
                valor = separadores[i];
                tipo = resultado(separadores[i]);
                tokens.No = no;
                tokens.Tipo = tipo;
                tokens.Valor = valor;
                tokens.Linea = contador;
                if (separadores[i].Length != 0)
                {
                    tabla.Add(tokens);
                    no = no + 1;
                }
                i++;
                recursivoSentencias(separadores, valor, tipo, contador, tabla, no);
            }
        }
        public void recursivoLineas(string[] lineas, string valor, string tipo, int contador, List<Tokens> tabla, int no)
        {
            if (k < lineas.Length)
            {
                //Tokens tokens = new Tokens(0, "", "", 0);
                string[] separadores = organizarNuevo(lineas[k]).Split('\r', 'も', '\t');
                contador = contador + 1;
                recursivoSentencias(separadores, valor, tipo, contador, tabla, no);
                i = 0;
                k++;
                recursivoLineas(lineas, valor, tipo, contador, tabla, no);
            }
        }
        public void HacerLexicos(string texto, List<Tokens> tabla, DataGridView gtabla)
        {
            string[] lineas = texto.Split('\n');
            tabla = new List<Tokens>();
            string valor = "", tipo = "";
            int no = 1, contador = 0;
            recursivoLineas(lineas, valor, tipo, contador, tabla, no);
            k = 0;
            gtabla.DataSource = tabla;
            gtabla.Columns[1].Width = 220;
            gtabla.Columns[2].Width = 220;
            /*for (int k = 0; k < lineas.Length; k++)
            {
                valorlinea = organizarNuevo(lineas[k]);
                //Tokens tokens = new Tokens(0, "", "", 0);
                string[] separadores = valorlinea.Split('\r', 'も', '\t');
                contador = contador + 1;
                recursivoSentencias(separadores,valor,tipo,contador,tabla,no);
                i = 0;
                for (int i = 0; i < separadores.Length; i++)
                {
                    Tokens tokens = new Tokens(0, "", "", 0);
                    valor = separadores[i];
                    tipo = resultado(separadores[i]);
                    tokens.No = no;
                    tokens.Tipo = tipo;
                    tokens.Valor = valor;
                    tokens.Linea = contador;
                    if (separadores[i].Length != 0)
                    {
                        tabla.Add(tokens);
                        no = no + 1;
                    }
                }
            }
            gtabla.DataSource = tabla;
            gtabla.Columns[1].Width = 220;
            gtabla.Columns[2].Width = 220;*/
        }
        public string palabrasReservadas(string palabra)
        {
            Regex exp = new Regex(@"\A((clase)|(si)|(sino))\Z");
            if (exp.IsMatch(palabra))
            {
                return "Palabra reservada";
            }
            Regex exp2 = new Regex(@"\A<\Z");
            Regex exp3 = new Regex(@"\A>\Z");
            if (exp2.IsMatch(palabra))
            {
                return "Apertura de bloque";
            }
            else if (exp3.IsMatch(palabra))
                return "Cierre de bloque";
            return "";
        }
        public string parentesis(string palabra)
        {
            string rs = "";
            Regex exp = new Regex(@"\(.*?\)");
            if (exp.IsMatch(palabra))
                rs = "Paréntesis";
            return rs;
        }
        public string parametros(string palabra)
        {
            string rs = "";
            string espacio = " ";
            string exp2 = string.Format(@"[a-z,A-Z]\w*?\((decimal|numero|letra|verificar){0}([a-z,A-Z]\w*?)\)", espacio);
            Regex exp = new Regex(exp2);
            if (exp.IsMatch(palabra))
                rs = "Parámetros";
            return rs;
        }
        public string TipoDeDato(string palabra)
        {
            Regex exp = new Regex(@"\A(numero)\Z");
            if (exp.IsMatch(palabra))
            {
                return "Tipo de dato";
            }
            return "";
        }
        public string simbolos(string palabra)
        {
            Regex exp = new Regex(@"\A((-)|(=)|(\+)|(/)|(\*))\Z");
            if (exp.IsMatch(palabra))
            {
                return "Símbolo";
            }
            return "";
        }
        public string separador(string palabra)
        {
            Regex exp = new Regex(@"\A;\Z");
            if (exp.IsMatch(palabra))
            {
                return "Separador de tokens";
            }
            return "";
        }
        public string valor(string palabra)
        {
            Regex exp = new Regex(@"\A((|([0-9]+)(((\+)([0-9]+))|((\-)([0-9]+))|((/)([0-9]+))|((\*)([0-9]+)))*)|
(([A-z,a-z]\w*?)(((\+)(([0-9]+)|([A-z,a-z]\w*?)))|((\-)(([0-9]+)|([A-z,a-z]\w*?)))|((/)(([0-9]+)|([A-z,a-z]\w*?)))|((\*)(([0-9]+)|([A-z,a-z]\w*?))))+))\Z");
            //Regex exp2 = new Regex(@"\A(([A-z,a-z]\w*?)(((\+)(([0-9]+)|([A-z,a-z]\w*?)))|((\-)(([0-9]+)|([A-z,a-z]\w*?)))|((/)(([0-9]+)|([A-z,a-z]\w*?)))|((\*)(([0-9]+)|([A-z,a-z]\w*?))))+)\Z");
            if (exp.IsMatch(palabra) /*|| exp2.IsMatch(palabra)*/)
            {
                return "Valor";
            }
            return "";
        }
        public string copiaValor(string palabra)
        {
            string comillas = "\"";
            string cadena = string.Format(@"\A((verdadero)|({0}.*?{1})|(falso)|([0-9]+(.[0-9]+)*))\Z", comillas, comillas);
            Regex exp = new Regex(cadena);
            string rs = "";
            if (exp.IsMatch(palabra))
            {
                rs = "Valor";
            }
            return rs;
        }
        public string expresion(string palabra)
        {
            Regex exp = new Regex(@"\A(((\()((-*[0-9]+)|([A-z,a-z]\w*?))(\)))|(\()(([A-z,a-z]\w*?)(((\+)(([0-9]+)|([A-z,a-z]\w*?)))|((\-)(([0-9]+)|([A-z,a-z]\w*?)))|((/)(([0-9]+)|([A-z,a-z]\w*?)))|((\*)(([0-9]+)|([A-z,a-z]\w*?))))+(\)))|
(((\()((-*[0-9]+)|([A-z,a-z]\w*?))(\)))|((\()(([A-z,a-z]\w*?)(((\+)(([0-9]+)|([A-z,a-z]\w*?)))|((\-)(([0-9]+)|([A-z,a-z]\w*?)))|((/)(([0-9]+)|([A-z,a-z]\w*?)))|((\*)(([0-9]+)|([A-z,a-z]\w*?))))+)(\)))))\Z");
            //Regex exp = new Regex(@"\A((\()((-*[0-9]+)|([A-z,a-z]\w*?))(\)))\Z");
            //Regex exp3 = new Regex(@"\A((\()(([A-z,a-z]\w*?)(((\+)(([0-9]+)|([A-z,a-z]\w*?)))|((\-)(([0-9]+)|([A-z,a-z]\w*?)))|((/)(([0-9]+)|([A-z,a-z]\w*?)))|((\*)(([0-9]+)|([A-z,a-z]\w*?))))+)(\)))\Z");
            if (exp.IsMatch(palabra)/* || exp2.IsMatch(palabra) || exp3.IsMatch(palabra)*/)
            {
                return "Expresión";
            }
            return "";
        }
        public string Instruccion(string palabra)
        {
            Regex exp = new Regex(@"\A((atornillar)|(desatornillar)|(apagar)|(tiempo))\Z");
            if (exp.IsMatch(palabra))
            {
                return "Instrucción";
            }
            return "";
        }
        public string comentarios(string palabra)
        {
            Regex exp = new Regex(@"\A//.+\Z");
            if (exp.IsMatch(palabra))
            {
                return "Comentario";
            }
            return "";
        }
        /*public string condicion(string palabra)
        {
            string cadena = string.Format(@"\Asi(\()([A-Za-z]\w*?|([0-9]+))((=a)|(>a)|(<a)|(>o=)|(<o=)|(!=))(([A-Za-z]\w*?)|([0-9]+)|({0}\w*?{1}))(\))\Z", "\"", "\"");
            //@"\A(si(\()([A-Za-z]\w*?|([0-9]+))((=a)|(>a)|(<a)|(>o=)|(<o=)|(!=))(([A-Za-z]\w*?)|([0-9]+))|({0}\w*?{1})(\))(<>)*(sino)*)\Z", "\"", "\""
            Regex exp1 = new Regex(@"si(\()([A-Za-z]\w*?)(\))");
            string rs = "";
            Regex exp = new Regex(cadena);
            if (exp.IsMatch(palabra))
            {
                rs = "Condición";
            }
            return rs;
        }*/
        public string Identificador(string palabra)
        {
            Regex exp = new Regex(@"\A[a-z,A-Z]\w*?\Z");
            if (exp.IsMatch(palabra))
            {
                return "Identificador";
            }
            return "";
        }
        public string asignacion(string palabra)
        {
            //string comillas = "\"";
            string cadena = string.Format(@"\A[a-zA-Z]\w*?=([0-9]+|({0}.*?{1})|[A-Za-z]\w*?)\Z", "\"", "\"");
            Regex exp = new Regex(cadena);
            if (exp.IsMatch(palabra))
            {
                return "Expresión de asignación";
            }
            return "";
        }
        public void recursivoOrganizar(string linea, bool comillas, bool parentesis, bool comentario, bool espacio,bool comillasFin,bool separador,
            bool parentesisFin)
        {
            //MessageBox.Show(linea + " " + rss); ;
            if (j < linea.Length)
            {
                if (linea[j].Equals(' ') && comillas == false && parentesis == false && comentario == false)
                {
                    espacio = true;
                }
                if (!linea[j].Equals(' ') && espacio == true)
                {
                    espacio = false;
                    rss += "も";
                }
                if (linea[j].Equals(';') && comentario == false)
                {
                    separador = true;
                    rss += "も" + linea[j] + "も";
                }
                if (comillasFin == true)
                {
                    comillas = false;
                    comillasFin = false;
                    rss += "も";
                }
                if (comillas == true && linea[j].Equals('"'))
                {
                    comillasFin = true;
                }
                if (linea[j].Equals('"') && comillasFin == false && comentario == false)
                {
                    comillas = true;
                    rss += "も";
                }
                if (parentesisFin == true)
                {
                    parentesisFin = false;
                }
                if (linea[j].Equals('(') && comillas == false && comentario == false)
                {
                    parentesis = true;
                    rss += "も";
                }
                if (linea[j].Equals(')') && parentesis == true)
                {
                    parentesisFin = true;
                    parentesis = false;
                    rss += linea[j] + "も";
                }
                if (j < linea.Length - 2)
                {
                    if (linea[j].Equals('/') && linea[i + 1].Equals('/') && comentario == false)
                    {
                        comentario = true;
                        rss += "も";
                    }
                }
                if ((espacio == false && separador == false && comillas == true) || (espacio == false && separador == false && parentesis == true
                    && comillas == false) || comentario == true ||
                    (espacio == false && separador == false && parentesisFin == false && comillasFin == false))
                    rss += linea[j];
                separador = false;
                j++;
                recursivoOrganizar(linea, comillas, parentesis, comentario, espacio, comillasFin, separador, parentesisFin);
            }
        }
        public string organizarNuevo(string linea)
        {
            //separador: も
            bool parentesis = false, parentesisFin = false, espacio = false, separador = false, comillas = false, comillasFin = false, comentario = false;
            //string rs = "";
            rss = "";
            j = 0;
            /*for (int i = 0; i < linea.Length; i++)
            {
                if (linea[i].Equals(' ') && comillas == false && parentesis == false && comentario == false)
                {
                    espacio = true;
                }
                if (!linea[i].Equals(' ') && espacio == true)
                {
                    espacio = false;
                    rs += "も";
                }
                if (linea[i].Equals(';') && comentario == false)
                {
                    separador = true;
                    rs += "も" + linea[i] + "も";
                }
                if (comillasFin == true)
                {
                    comillas = false;
                    comillasFin = false;
                    rs += "も";
                }
                if (comillas == true && linea[i].Equals('"'))
                {
                    comillasFin = true;
                }
                if (linea[i].Equals('"') && comillasFin == false && comentario == false)
                {
                    comillas = true;
                    rs += "も";
                }
                if (parentesisFin == true)
                {
                    parentesisFin = false;
                }
                if (linea[i].Equals('(') && comillas == false && comentario == false)
                {
                    parentesis = true;
                    rs += "も";
                }
                if (linea[i].Equals(')') && parentesis == true)
                {
                    parentesisFin = true;
                    parentesis = false;
                    rs += linea[i] + "も";
                }
                if (i < linea.Length - 2)
                {
                    if (linea[i].Equals('/') && linea[i + 1].Equals('/') && comentario == false)
                    {
                        comentario = true;
                        rs += "も";
                    }
                }
                if ((espacio == false && separador == false && comillas == true) || (espacio == false && separador == false && parentesis == true
                    && comillas == false) || comentario == true ||
                    (espacio == false && separador == false && parentesisFin == false && comillasFin == false))
                    rs += linea[i];
                separador = false;
            }*/
            recursivoOrganizar(linea,comillas,parentesis,comentario,espacio,comillasFin,separador,parentesisFin);
            return rss;
        }
        public string organizar(string linea)
        {
            //separador: も
            int posicion = 0;
            bool parentesis = false, espacio = true;
            string rs = "";
            while (posicion < linea.Length)
            {
                if (linea[posicion] == ' ')
                {
                    if (posicion < linea.Length)
                    {
                        posicion++;
                    }
                    if (posicion < linea.Length)
                    {
                        while (linea[posicion] == ' ' && espacio == true)
                        {
                            posicion++;
                            if (posicion == linea.Length)
                            {
                                posicion--;
                                espacio = false;
                            }
                        }
                        if (espacio == false)
                        {
                            posicion++;
                            espacio = true;
                        }
                        rs += "も";
                    }
                }
                if (posicion < linea.Length)
                {
                    if (linea[posicion] == ';')
                    {
                        rs += "も" + linea[posicion] + "も";
                        posicion++;
                    }
                }
                if (posicion < linea.Length - 1)
                {
                    if (linea[posicion] == '"')
                    {
                        rs += linea[posicion];
                        posicion++;
                        while (linea[posicion] != '"')
                        {
                            rs += linea[posicion];
                            posicion++;
                        }
                    }
                }
                /*if (posicion < linea.Length - 2)
                {
                    if (linea[posicion].Equals('s') && linea[posicion + 1].Equals('i') && linea[posicion + 2].Equals('('))
                    {
                        while (posicion < linea.Length && linea[posicion] != ')')
                        {
                            rs += linea[posicion];
                            posicion++;
                        }
                        if (posicion < linea.Length)
                        {
                            rs += linea[posicion];
                            rs += "も";
                            posicion++;
                            if (posicion < linea.Length)
                            {
                                if (linea[posicion] == ';')
                                {
                                    rs += "も" + linea[posicion] + "も";
                                    posicion++;
                                }

                                if (posicion < linea.Length)
                                {
                                    if (linea[posicion] == ' ')
                                    {
                                        posicion++;
                                        while (linea[posicion] == ' ')
                                        {
                                            posicion++;
                                        }
                                        rs += "も";
                                    }
                                }
                            }
                        }
                    }
                }*/
                if (posicion < linea.Length - 1)
                {
                    if (linea[posicion] == '(')
                    {
                        parentesis = false;
                        rs += "も";
                        rs += linea[posicion];
                        posicion++;
                        if (linea[posicion] == ')')
                        {
                            rs += linea[posicion];
                            rs += "も";
                        }
                        /*while (linea[posicion] != ')')
                        {
                            rs += linea[posicion];
                            posicion++;
                        }*/
                        while (linea[posicion] != ')' && parentesis == false)
                        {
                            while (posicion < linea.Length && linea[posicion] != ')')
                            {
                                rs += linea[posicion];
                                posicion++;
                            }
                            posicion--;
                            parentesis = true;
                        }
                        posicion++;
                        //MessageBox.Show(rs);
                    }
                }
                if (posicion < linea.Length - 2)
                {//Comentarios
                    if (linea[posicion] == ' ')
                    {
                        if (posicion < linea.Length)
                        {
                            posicion++;
                        }
                        if (posicion < linea.Length)
                        {
                            while (linea[posicion] == ' ' && espacio == true)
                            {
                                posicion++;
                                if (posicion == linea.Length)
                                {
                                    posicion--;
                                    espacio = false;
                                }
                            }
                            if (espacio == false)
                            {
                                posicion++;
                                espacio = true;
                            }
                            rs += "も";
                        }
                    }
                    if (linea[posicion] == '/' && linea[posicion + 1] == '/')
                    {
                        while (posicion < linea.Length - 1)
                        {
                            rs += linea[posicion];
                            posicion++;
                        }
                    }
                }
                if (posicion < linea.Length)
                {
                    //MessageBox.Show(rs);
                    if (linea[posicion] != ')' || linea[posicion] != '"')
                    {
                        rs += linea[posicion];
                    }
                    else
                    {
                        rs += linea[posicion];
                        rs += "も";
                    }
                }
                posicion++;
            }
            //MessageBox.Show(rs);
            return rs;
        }
        public string resultado(string palabra)
        {
            string rs = "";
            rs += comentarios(palabra);
            rs += Instruccion(palabra);
            rs += separador(palabra);
            if (rs == "")
            {
                rs += expresion(palabra);
                rs += palabrasReservadas(palabra);
                rs += simbolos(palabra);
            }
            if (rs == "")
            {
                rs += TipoDeDato(palabra);
                rs += valor(palabra);
            }
            if (rs == "")
                rs += Identificador(palabra);
            if (rs == "")
            {
                rs = "No identificado";
            }
            return rs;
        }
    }
}
/*clase owo
<
funcion hacer
<
numero uwu=1
moverV(uwu)
si(uwu>a0);uwu=2 //Epico 7w7
owo("owo awa")
letra awa = "awa fría"
>
>*/