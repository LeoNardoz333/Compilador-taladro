using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Manejador
{
    public class ManejadorSemantico
    {
        static string claseNombre = "", result = "", numeroExp = "", variable = "";
        static List<string> variables = new List<string>();
        ManejadorLexico m = new ManejadorLexico();
        ManejadorSintactico ms = new ManejadorSintactico();
        int contador = 0, final = 0, final2 = 0, listaCont = 0, i = 0;
        bool sihayClase = false, sihay = false, numero = false;
        Regex numeros = new Regex(@"\A([0-9]+)\Z");
        Regex numeros2 = new Regex(@"\A(([1-9])|(10)|([A-Z,a-z]\w*?))\Z");
        Regex operaciones = new Regex(@"\A(([A-z,a-z]\w*?)(((\+)(([0-9]+)|([A-z,a-z]\w*?)))|((\-)(([0-9]+)|([A-z,a-z]\w*?)))|((/)(([0-9]+)|([A-z,a-z]\w*?)))|((\*)(([0-9]+)|([A-z,a-z]\w*?))))+)\Z");
        void variablesUsadas(DataGridView tabla, int contador)
        {
            variables.Add(tabla.Rows[contador + 1].Cells[1].Value.ToString());
        }
        public void comentarios(DataGridView tabla)
        {
            if (contador < tabla.RowCount - 1 && tabla.Rows[contador].Cells[2].Value.ToString() == "Comentario")
            {
                contador++;
                comentarios(tabla);
            }
        }
        public void leerLista(string rs, int numero)
        {
            if(numero < variables.Count)
            {
                if (variables[numero].Equals(rs) && rs.Equals(claseNombre))
                {
                    sihayClase = true; listaCont = variables.Count;
                }
                if (variables[numero].Equals(rs) && sihayClase == false)
                {
                    sihay = true; listaCont = variables.Count;
                }
                leerLista(rs, listaCont++);
            }
            listaCont = 0;
        }
        public void leerLista2(string rs, int numero)
        {
            if (numero < variables.Count)
            {
                if (variables[numero].Equals(rs) && sihayClase == false)
                {
                    variable = variables[numero];
                    result = "sihayvariable"; listaCont = variables.Count;
                }
                leerLista2(rs, listaCont++);
            }
            listaCont = 0;
        }
        public void recorrerExpresiones(string valor, string rs)
        {
            if (i < valor.Length)
            {
                if (valor[i].Equals('('))
                    i++;
                if (!valor[i].Equals(')') && !valor[i].Equals('+') && !valor[i].Equals('-') &&
                    !valor[i].Equals('/') && !valor[i].Equals('*') && !valor[i].Equals(' '))
                {
                    rs += valor[i];
                }
                if (numeros.IsMatch(rs))
                    numero = true;
                if ((valor[i].Equals(')') | valor[i].Equals('+') | valor[i].Equals('-') |
                    valor[i].Equals('/') | valor[i].Equals('*') | valor[i].Equals(' ') | i == valor.Length - 1) && numero == false)
                {
                    leerLista(rs, listaCont);
                    if (sihayClase == true)
                        result = "Hay clase";
                    else
                    if (sihay == false)
                        result = "No hay xd";
                    else rs = "";
                    if (!result.Equals(""))
                    {
                        i = valor.Length;
                    }
                }
                sihay = false; numero = false; sihayClase = false;
                i++;
                recorrerExpresiones(valor,rs);
            }
            i = 0;
        }
        public void definirFinal(DataGridView tabla, int numero)
        {
            if (tabla.Rows[final].Cells[2].Value.ToString() == "Comentario")
            {
                final--;
                definirFinal(tabla, final);
            }
        }
        public void apagarFinal(DataGridView tabla, int numero, bool apagar)
        {
            if (tabla.Rows[final2].Cells[2].Value.ToString() == "Comentario" && apagar == false)
            {
                final2--;
                apagarFinal(tabla,final2,apagar);
            }
        }
        public void extraerNumeros(string expresion)
        {
            if (!expresion[i].Equals(')'))
            {
                if (expresion[i].Equals('('))
                    i++;
                numeroExp += expresion[i];
                i++;
                extraerNumeros(expresion);
            }
            i = 0;
        }
        public string ejecutar(DataGridView tabla)
        {
            variables = new List<string>();
            return evaluar(tabla);
        }
        public void comprobar(string texto, List<Tokens> tabla, DataGridView gtabla)
        {
            m.HacerLexicos(texto, tabla, gtabla);
            if (ms.Evaluar(gtabla) != "")
            {
                MessageBox.Show(ms.Evaluar(gtabla));
            }
            if (evaluar(gtabla) != "")
            {
                MessageBox.Show(evaluar(gtabla));
            }
        }
        public string evaluar(DataGridView tabla)
        {
            contador = 0;
            string rs = "", valores;
            bool clase = false, apertura = false, cierre = false;
            comentarios(tabla);
            if (contador >= tabla.RowCount - 1)
            {
                return "No se ha declarado una clase";
            }
            for (contador = contador; contador < tabla.RowCount - 1 || tabla.RowCount == 1; contador++)
            {
                comentarios(tabla);
                if (clase == false)
                {
                    if (tabla.Rows[contador].Cells[1].Value.Equals("clase"))
                    {
                        claseNombre = tabla.Rows[contador + 1].Cells[1].Value.ToString();
                        variables.Add(claseNombre);
                        contador = contador + 2;
                        clase = true;
                    }
                    else
                    {
                        return "Se debe iniciar con una clase, linea " + tabla.Rows[contador].Cells[3].Value.ToString()
                            + ": " + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString();
                    }
                }
                //MessageBox.Show(tabla.Rows[contador].Cells[1].Value.ToString()+" "+contador);
                if (contador < tabla.RowCount)
                {
                    comentarios(tabla);
                    //MessageBox.Show(tabla.Rows[contador].Cells[1].Value.ToString());
                    if (tabla.Rows[contador].Cells[1].Value.Equals("clase") && clase == true)
                    {
                        return "Ya se ha declarado una clase anteriormente, linea " + tabla.Rows[contador].Cells[3].Value.ToString()
                            + ": " + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString();
                    }
                    if (contador > tabla.RowCount - 1)
                    {
                        return "Falta declarar apertura y cierre de bloque después de la clase";
                    }
                    if (tabla.Rows[contador].Cells[1].Value.Equals("<") && apertura == false)
                    {
                        contador++;
                        apertura = true;
                        if (contador > tabla.RowCount - 1)
                        {
                            return "Falta definir un cierre de bloque, linea " + tabla.Rows[contador - 1].Cells[3].Value.ToString() +
                                ": " + tabla.Rows[contador - 1].Cells[1].Value.ToString();
                        }
                    }
                    else if (apertura == false)
                    {
                        return "Falta apertura de bloque, linea " + tabla.Rows[contador].Cells[3].Value.ToString() +
                            ": " + tabla.Rows[contador].Cells[1].Value.ToString();
                    }
                    comentarios(tabla);
                }
                else
                {
                    return "Falta apertura de bloque, linea " + tabla.Rows[contador - 2].Cells[3].Value.ToString()
                        + ": " + tabla.Rows[contador - 2].Cells[1].Value.ToString() + " "
                        + tabla.Rows[contador - 1].Cells[1].Value.ToString();
                }
                //MessageBox.Show("LLegó al objetivo "+apertura.ToString()+" "+ tabla.Rows[contador].Cells[2].Value.ToString());
                if (tabla.Rows[contador].Cells[1].Value.Equals("<") && apertura == true)
                {
                    return "Sólo puede haber una apertura de bloque";
                }
                //comentarios(tabla);
                //MessageBox.Show(tabla.Rows[tabla.RowCount - 1].Cells[1].Value.ToString());
                if (!tabla.Rows[tabla.RowCount - 1].Cells[1].Value.Equals(">"))
                {
                    if (tabla.Rows[tabla.RowCount - 1].Cells[2].Value.ToString() != "Comentario")
                    {
                        return "Falta definir cierre de bloque, o hay código inválido debajo de éste";
                    }
                }
                else
                {
                    cierre = true;
                    final = tabla.RowCount - 1;
                }
                if (cierre == false)
                {
                    final = tabla.RowCount - 1;
                    definirFinal(tabla, final); 
                    if (tabla.Rows[final].Cells[1].Value.Equals(">"))
                    {
                        cierre = true;
                    }
                    else if (tabla.Rows[final].Cells[2].Value.ToString() != "Comentario")
                        return "Falta definir cierre de bloque, o hay código inválido debajo de éste";
                }

                //MessageBox.Show("LLegó al objetivo " + cierre.ToString() + " " + tabla.Rows[contador].Cells[1].Value.ToString()
                 //+contador.ToString()+" final "+final);
                if (tabla.Rows[contador].Cells[1].Value.Equals(">") && cierre == true && contador != final)
                {
                    return "1 Sólo puede haber un cierre de bloque";
                }
                bool apagarN = false;
                string rss = "";

                if (tabla.Rows[contador].Cells[2].Value.Equals("Instrucción"))
                {
                    result = "";
                    if (!tabla.Rows[contador].Cells[1].Value.Equals("apagar"))
                    {
                        apagarN = true;
                        if (!numeros.IsMatch(tabla.Rows[contador + 3].Cells[1].Value.ToString()))
                            recorrerExpresiones(tabla.Rows[contador+1].Cells[1].Value.ToString(),rss);
                        if (result.Equals("Hay clase"))
                        {
                            return "Este nombre ya se ha usado para declarar la clase\"" + claseNombre + "\", línea "
                                + tabla.Rows[contador + 1].Cells[3].Value.ToString() + ", en la variable: " 
                                + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 1].Cells[1].Value.ToString()
                                + tabla.Rows[contador + 2].Cells[1].Value.ToString();
                        }
                        if (result.Equals("No hay xd"))
                        {
                            return "No se ha declarado la variable, o alguna de las variables: \""
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString() +
                                "\", en la línea " + tabla.Rows[contador + 1].Cells[3].Value.ToString()
                                + ", " + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                                    + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                                    + tabla.Rows[contador + 2].Cells[1].Value.ToString();
                        }
                    }
                    /*if (!tabla.Rows[contador].Cells[1].Value.Equals("apagar"))
                    {
                        identificadores = separaIdentificadores(tabla.Rows[contador + 1].Cells[1].Value.ToString());
                    }*/
                    if (!tabla.Rows[contador].Cells[1].Value.Equals("apagar"))
                    {
                        extraerNumeros(tabla.Rows[contador + 1].Cells[1].Value.ToString());
                        if (!numeros2.IsMatch(numeroExp) && !operaciones.IsMatch(numeroExp))
                        {
                            if (!tabla.Rows[contador].Cells[1].Value.Equals("tiempo"))
                            {
                                return "La velocidad debe ser un número del 1 al 10, línea " + tabla.Rows[contador].Cells[3].Value.ToString() +
                                    ": " + tabla.Rows[contador].Cells[1].Value.ToString() +
                        tabla.Rows[contador + 1].Cells[1].Value.ToString() +
                        tabla.Rows[contador + 2].Cells[1].Value.ToString();
                            }
                        }
                    }
                        numeroExp = "";
                        //contador2 = 0;
                    contador += 2;
                    //MessageBox.Show("en: " + tabla.Rows[contador].Cells[1].Value.ToString()+contador.ToString());
                }
                if (tabla.Rows[contador].Cells[2].Value.Equals("Tipo de dato"))
                {
                    result = "";
                    rss = "";
                    if (!numeros.IsMatch(tabla.Rows[contador + 3].Cells[1].Value.ToString()))
                        recorrerExpresiones(tabla.Rows[contador+3].Cells[1].Value.ToString(), rss);
                    //MessageBox.Show("result: "+result+", variable: "+tabla.Rows[contador+1].Cells[1].Value.ToString());
                    if (result.Equals("Hay clase"))
                    {
                        //linea = tabla.Rows[contador + 1].Cells[3].Value.ToString();
                        //declaracion = claseNombre;
                        return "Este nombre ya se ha usado para declarar la clase\"" + claseNombre + "\", línea "
                            + tabla.Rows[contador + 1].Cells[3].Value.ToString() + ", en la variable: "
                            + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                    }
                    if (result.Equals("No hay xd"))
                    {
                        return "No se ha declarado la variable, o alguna de las variables: \""
                            + tabla.Rows[contador + 3].Cells[1].Value.ToString() +
                            "\", en la línea " + tabla.Rows[contador + 1].Cells[3].Value.ToString() +
                            ", " + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                    }
                    leerLista2(tabla.Rows[contador + 1].Cells[1].Value.ToString(), listaCont);
                        if (result.Equals("sihayvariable") && variable.Equals(claseNombre))
                        {
                            return "Este nombre ya se ha usado para declarar la clase, línea "
                                + tabla.Rows[contador + 1].Cells[3].Value.ToString() + ", en la variable: "
                                + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                        }
                        if (result.Equals("sihayvariable") && !variable.Equals(claseNombre))
                        {
                            return "Este nombre ya se ha usado en otra variable, línea "
                                + tabla.Rows[contador + 1].Cells[3].Value.ToString() + ", en la variable: "
                                + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                        }
                    /*if (tabla.Rows[contador].Cells[1].Value.Equals("numero"))
                    {*/
                        variablesUsadas(tabla, contador);
                        valores = tabla.Rows[contador + 3].Cells[1].Value.ToString();
                        if (valores[0].Equals('"'))
                        {
                            return "Tipo de dato incorrecto, se esperaba un valor numérico, en la línea "
                                + tabla.Rows[contador].Cells[3].Value.ToString() +
                                ": " + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                        }
                        if (valores.Contains('.'))
                        {
                            return "El tipo de dato numero no puede llevar decimales, en la línea "
                                + tabla.Rows[contador].Cells[3].Value.ToString() + ": " + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                        }
                        if (tabla.Rows[contador + 1].Cells[1].Value.Equals(tabla.Rows[contador + 3].Cells[1].Value))
                        {
                            return "No se puede asignar la propia variable como valor, en la línea "
                                + tabla.Rows[contador].Cells[3].Value.ToString() + ": " + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                        }
                    //}
                    contador += 4;
                    //comentarios(tabla);
                }
                //MessageBox.Show("Prueba, " + contador.ToString() + ", " + tabla.Rows[final - 3].Cells[1].Value.ToString());
                final2 = final - 1;
                bool apagar = false;
                if (!tabla.Rows[final - 3].Cells[1].Value.Equals("apagar") && apagarN == true)
                {
                    //MessageBox.Show("Prueba, " + contador.ToString() + ", " + tabla.Rows[final2].Cells[1].Value.ToString());
                    if (tabla.Rows[final2].Cells[2].Value.ToString() != "Comentario")
                    {
                        if(!tabla.Rows[final2].Cells[1].Value.ToString().Equals("apagar"))
                            return "La última instrucción debe ser de apagado";
                    }
                    apagarFinal(tabla, final2,apagar);
                    //MessageBox.Show("Prueba, " + contador.ToString() + ", " + tabla.Rows[final - 3].Cells[1].Value.ToString());
                    if (tabla.Rows[final2].Cells[1].Value.Equals("apagar"))
                    {
                        apagar = true;
                    }
                    else if (tabla.Rows[final2].Cells[2].Value.ToString() != "Comentario" && apagar == false
                        && !tabla.Rows[final2].Cells[1].Value.Equals(";") && !tabla.Rows[final2].Cells[1].Value.Equals("()")
                        && !tabla.Rows[final2].Cells[1].Value.Equals("<") && !tabla.Rows[final2].Cells[1].Value.Equals(">"))
                        return "La última instrucción debe ser de apagado";
                }
                if (tabla.Rows[contador].Cells[2].Value.Equals("No identificado"))
                {
                    return "Se ha detectado código invalido en la línea " + tabla.Rows[contador].Cells[3].Value.ToString()
                        + ": " + tabla.Rows[contador].Cells[1].Value.ToString();
                }
                apagarN = false;
                //MessageBox.Show(tabla.Rows[contador].Cells[1].Value.ToString());
            }
            return rs;
        }
    }
}
