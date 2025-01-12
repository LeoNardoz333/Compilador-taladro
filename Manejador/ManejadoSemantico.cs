using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Manejador
{
    /*
    clase owo
    <
    atornillar(4);
    tiempo(10);
    apagar();
    <
    */
    public class ManejadoSemantico
    {
        ManejadorSintactico ms = new ManejadorSintactico();
        ManejadorLexico m = new ManejadorLexico();
        public static List<string> variables = new List<string>();
        public static string claseNombre = "";
        void variablesUsadas(DataGridView tabla, int contador)
        {
            variables.Add(tabla.Rows[contador + 1].Cells[1].Value.ToString());
        }
        string separaIdentificadores(string valor)
        {
            Regex numeros = new Regex(@"\A([0-9]+)\Z");
            string rs = "";
            bool sihay = false, numero = false, sihayClase = false;
            for (int i = 0; i < valor.Length; i++)
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
                    foreach (var nombre in variables)
                    {
                        if (nombre.Equals(rs) && rs.Equals(claseNombre))
                        {
                            //MessageBox.Show("clase: " + claseNombre + " for each: " + nombre);
                            sihayClase = true; break;
                        }
                        if (nombre.Equals(rs) && sihayClase == false)
                        {
                            sihay = true; break;
                        }
                    }
                    if (sihayClase == true)
                        return "Hay clase";
                    else
                    if (sihay == false)
                        return "No hay xd";
                    else rs = "";
                }
                sihay = false; numero = false; sihayClase = false;
            }
            return rs;
        }
        public void comprobar(string texto, List<Tokens> tabla, DataGridView gtabla)
        {
            m.HacerLexicos(texto, tabla, gtabla);
            string rs;
            rs = ms.Evaluar(gtabla);
            string semantico = "";
            if (rs != "")
            {
                MessageBox.Show(ms.Evaluar(gtabla));
            }
            else
                semantico = ejecutar(gtabla);
            if (semantico != "")
            {
                MessageBox.Show(semantico);
            }
        }
        public string composicion(DataGridView tabla)
        {
            int contador = 0, contador2 = 0;
            string error = "", valores, linea, declaracion, expresion, numero = "", identificadores = "";
            while (contador < tabla.RowCount)
            {
                //MessageBox.Show("Se repitió, " + contador.ToString());
                Regex numeros = new Regex(@"\A([0-9]+)\Z");
                Regex numeros2 = new Regex(@"\A(([1-9])|(10)|([A-Z,a-z]\w*?))\Z");
                Regex operaciones = new Regex(@"\A(([A-z,a-z]\w*?)(((\+)(([0-9]+)|([A-z,a-z]\w*?)))|((\-)(([0-9]+)|([A-z,a-z]\w*?)))|((/)(([0-9]+)|([A-z,a-z]\w*?)))|((\*)(([0-9]+)|([A-z,a-z]\w*?))))+)\Z");
                if (tabla.Rows[contador].Cells[2].Value.Equals("No identificado"))
                {
                    error = "Se detectó código inválido en la línea "
                        + tabla.Rows[contador].Cells[3].Value.ToString() +
                        ", en el enunciado " + tabla.Rows[contador].Cells[1].Value.ToString();
                    return error;
                }
                if (tabla.Rows[contador].Cells[2].Value.Equals("Instrucción"))
                {
                    if (!tabla.Rows[contador].Cells[1].Value.Equals("apagar"))
                    {
                        identificadores = separaIdentificadores(tabla.Rows[contador + 1].Cells[1].Value.ToString());
                    }
                    if (identificadores.Equals("Hay clase"))
                    {
                        linea = tabla.Rows[contador + 1].Cells[3].Value.ToString();
                        declaracion = tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString()
                            + tabla.Rows[contador + 2].Cells[1].Value.ToString();
                        error = "Este nombre ya se ha usado para declarar la clase\"" + claseNombre + "\", línea "
                            + linea + ", en la variable: " + declaracion;
                        return error;
                    }
                    if (identificadores.Equals("No hay xd"))
                    {
                        linea = tabla.Rows[contador + 1].Cells[3].Value.ToString();
                        declaracion = tabla.Rows[contador].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 2].Cells[1].Value.ToString();
                        error = "No se ha declarado la variable, o alguna de las variables: \""
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString() +
                            "\", en la línea " + linea + ", " + declaracion;
                        return error;
                    }
                    linea = tabla.Rows[contador].Cells[3].Value.ToString();
                    declaracion = tabla.Rows[contador].Cells[1].Value.ToString() +
                        tabla.Rows[contador + 1].Cells[1].Value.ToString() +
                        tabla.Rows[contador + 2].Cells[1].Value.ToString();
                    if (!tabla.Rows[contador].Cells[1].Value.Equals("apagar"))
                    {
                        expresion = tabla.Rows[contador + 1].Cells[1].Value.ToString();
                        while (!expresion[contador2].Equals(')'))
                        {
                            if (expresion[contador2].Equals('('))
                                contador2++;
                            numero += expresion[contador2];
                            contador2++;
                        }
                        if (!numeros2.IsMatch(numero) && !operaciones.IsMatch(numero))
                        {
                            if (!tabla.Rows[contador].Cells[1].Value.Equals("tiempo"))
                            {
                                return "La velocidad debe ser un número del 1 al 10, línea " + linea +
                                    ": " + declaracion;
                            }
                        }
                        numero = "";
                        contador2 = 0;
                    }
                    contador += 2;
                }
                if (tabla.Rows[contador].Cells[2].Value.Equals("Tipo de dato"))
                {
                    if (!numeros.IsMatch(tabla.Rows[contador + 3].Cells[1].Value.ToString()))
                        identificadores = separaIdentificadores(tabla.Rows[contador + 3].Cells[1].Value.ToString());
                    if (identificadores.Equals("Hay clase"))
                    {
                        //linea = tabla.Rows[contador + 1].Cells[3].Value.ToString();
                        //declaracion = claseNombre;
                        error = "Este nombre ya se ha usado para declarar la clase\""+claseNombre+"\", línea "
                            + tabla.Rows[contador + 1].Cells[3].Value.ToString() + ", en la variable: "
                            + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                        return error;
                    }
                    if (identificadores.Equals("No hay xd"))
                    {
                        linea = tabla.Rows[contador + 1].Cells[3].Value.ToString();
                        declaracion = tabla.Rows[contador].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                        error = "No se ha declarado la variable, o alguna de las variables: \""
                            +tabla.Rows[contador+3].Cells[1].Value.ToString()+
                            "\", en la línea " + linea + ", " + declaracion;
                        return error;
                    }
                    foreach (var nombre in variables)
                    {
                        if (nombre.Equals(tabla.Rows[contador + 1].Cells[1].Value) && nombre.Equals(claseNombre))
                        {
                            error = "Este nombre ya se ha usado para declarar la clase, línea "
                                + tabla.Rows[contador + 1].Cells[3].Value.ToString() + ", en la variable: "
                                + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                            return error;
                        }
                        if (nombre.Equals(tabla.Rows[contador + 1].Cells[1].Value) && !nombre.Equals(claseNombre))
                        {
                            error = "Este nombre ya se ha usado en otra variable, línea "
                                + tabla.Rows[contador + 1].Cells[3].Value.ToString() + ", en la variable: "
                                + tabla.Rows[contador].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                                + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                            return error;
                        }
                    }
                    /*if (tabla.Rows[contador].Cells[1].Value.Equals("decimal"))
                    {
                        linea = tabla.Rows[contador].Cells[3].Value.ToString();
                        declaracion = tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                        valores = tabla.Rows[contador + 3].Cells[1].Value.ToString();
                        if (valores[0].Equals('"'))
                        {
                            error = "Tipo de dato incorrecto, se esperaba un valor numérico, en la línea "
                                + linea + ": " + declaracion;
                            return error;
                        }
                        if (tabla.Rows[contador + 1].Cells[1].Value.Equals(tabla.Rows[contador + 3].Cells[1].Value))
                        {
                            error = "No se puede asignar la propia variable como valor, en la línea "
                                + linea + ": " + declaracion;
                            return error;
                        }
                    }*/
                    if (tabla.Rows[contador].Cells[1].Value.Equals("numero"))
                    {
                        variablesUsadas(tabla, contador);
                        valores = tabla.Rows[contador + 3].Cells[1].Value.ToString();
                        linea = tabla.Rows[contador].Cells[3].Value.ToString();
                        declaracion = tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                        if (valores[0].Equals('"'))
                        {
                            error = "Tipo de dato incorrecto, se esperaba un valor numérico, en la línea "
                                + linea + ": " + declaracion;
                            return error;
                        }
                        if (valores.Contains('.'))
                        {
                            error = "El tipo de dato numero no puede llevar decimales, en la línea "
                                + linea + ": " + declaracion;
                            return error;
                        }
                        if (tabla.Rows[contador + 1].Cells[1].Value.Equals(tabla.Rows[contador + 3].Cells[1].Value))
                        {
                            error = "No se puede asignar la propia variable como valor, en la línea "
                                + linea + ": " + declaracion;
                            return error;
                        }
                    }
                    /*if (tabla.Rows[contador].Cells[1].Value.Equals("letra"))
                    {
                        valores = tabla.Rows[contador + 3].Cells[1].Value.ToString();
                        linea = tabla.Rows[contador].Cells[3].Value.ToString();
                        declaracion = tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                        if (numeros.IsMatch(valores))
                        {
                            error = "Tipo de dato incorrecto, no se permiten valores numéricos, en la línea "
                                + linea + ": " + declaracion;
                            return error;
                        }
                        if (tabla.Rows[contador + 1].Cells[1].Value.Equals(tabla.Rows[contador + 3].Cells[1].Value))
                        {
                            error = "No se puede asignar la propia variable como valor, en la línea "
                                + linea + ": " + declaracion;
                            return error;
                        }
                    }*/
                    /*if (tabla.Rows[contador].Cells[1].Value.Equals("verificar"))
                    {
                        linea = tabla.Rows[contador].Cells[3].Value.ToString();
                        declaracion = tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 2].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 3].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 4].Cells[1].Value.ToString();
                        if (tabla.Rows[contador + 1].Cells[1].Value.Equals(tabla.Rows[contador + 3].Cells[1].Value))
                        {
                            error = "No se puede asignar la propia variable como valor, en la línea "
                                + linea + ": " + declaracion;
                            return error;
                        }
                        if (!(tabla.Rows[contador + 3].Cells[1].Value.Equals("verdadero") |
                            tabla.Rows[contador + 3].Cells[1].Value.Equals("falso")) &&
                            !tabla.Rows[contador + 3].Cells[2].Value.Equals("Identificador"))
                        {
                            error = "Este tipo de dato sólo acepta valores de verdadero o falso, en la línea "
                                + linea + ": " + declaracion;
                            return error;
                        }
                    }*/
                    contador += 4;
                }
                contador++;
            }
            return error;
        }
        public string evaluar(DataGridView tabla)
        {
            int contador = 0;
            string rs = "", linea, declaracion;
            bool clase = false, apertura = false, cierre = false;
            contador = comentarios(contador, tabla);
            if (contador >= tabla.RowCount - 1)
            {
                rs = "No se ha declarado una clase";
                return rs;
            }
            while (contador < tabla.RowCount - 1)
            {
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
                        linea = tabla.Rows[contador].Cells[3].Value.ToString();
                        declaracion = tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString();
                        rs = "Se debe iniciar con una clase, linea " + linea + ": " + declaracion;
                        return rs;
                    }
                }
                //MessageBox.Show(tabla.Rows[contador].Cells[1].Value.ToString()+" "+contador);
                if (contador < tabla.RowCount)
                {
                    //MessageBox.Show(tabla.Rows[contador].Cells[1].Value.ToString());
                    contador = comentarios(contador, tabla);
                    if (contador > tabla.RowCount - 1)
                    {
                        contador--;
                    }
                    //MessageBox.Show(tabla.Rows[contador].Cells[1].Value.ToString());
                    if (tabla.Rows[contador].Cells[1].Value.Equals("clase") && clase == true)
                    {
                        linea = tabla.Rows[contador].Cells[3].Value.ToString();
                        declaracion = tabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + tabla.Rows[contador + 1].Cells[1].Value.ToString();
                        rs = "Ya se ha declarado una clase anteriormente, linea " + linea + ": " + declaracion;
                        return rs;
                    }
                    if (contador > tabla.RowCount - 1)
                    {
                        rs = "Falta declarar apertura y cierre de bloque después de la clase";
                        return rs;
                    }
                    if (tabla.Rows[contador].Cells[1].Value.Equals("<") && apertura == false)
                    {
                        contador++;
                        apertura = true;
                        if (contador > tabla.RowCount - 1)
                        {
                            linea = tabla.Rows[contador - 1].Cells[3].Value.ToString();
                            declaracion = tabla.Rows[contador - 1].Cells[1].Value.ToString();
                            rs = "Falta cierre de bloque, linea " + linea + ": " + declaracion;
                            return rs;
                        }
                    }
                    else if (apertura == false)
                    {
                        linea = tabla.Rows[contador].Cells[3].Value.ToString();
                        declaracion = tabla.Rows[contador].Cells[1].Value.ToString();
                        rs = "Falta apertura de bloque, linea " + linea + ": " + declaracion;
                        return rs;
                    }
                    contador = comentarios(contador, tabla);
                }
                else
                {
                    linea = tabla.Rows[contador - 2].Cells[3].Value.ToString();
                    declaracion = tabla.Rows[contador - 2].Cells[1].Value.ToString() + " "
                        + tabla.Rows[contador - 1].Cells[1].Value.ToString();
                    rs = "Falta apertura de bloque, linea " + linea + ": " + declaracion;
                    return rs;
                }
                //MessageBox.Show("LLegó al objetivo "+apertura.ToString()+" "+ tabla.Rows[contador].Cells[2].Value.ToString());
                if (tabla.Rows[contador].Cells[1].Value.Equals("<") && apertura == true)
                {
                    rs = "Sólo puede haber una apertura de bloque";
                    return rs;
                }
                contador = comentarios(contador, tabla);
                //MessageBox.Show(tabla.Rows[tabla.RowCount - 1].Cells[1].Value.ToString());
                if (!tabla.Rows[tabla.RowCount - 1].Cells[1].Value.Equals(">"))
                {
                    if (tabla.Rows[tabla.RowCount - 1].Cells[2].Value.ToString() != "Comentario")
                    {
                        rs = "Falta definir cierre de bloque, o hay código inválido debajo de éste";
                        return rs;
                    }
                }
                else
                    cierre = true;
                int final = tabla.RowCount - 1;
                while (tabla.Rows[final].Cells[2].Value.ToString() == "Comentario")
                {
                    final--;
                    if (tabla.Rows[final].Cells[1].Value.Equals(">"))
                    {
                        //contador = final2;
                        cierre = true;
                    }
                    else if (tabla.Rows[final].Cells[2].Value.ToString() != "Comentario")
                        return "Falta definir cierre de bloque, o hay código inválido debajo de éste";
                }
                //MessageBox.Show("LLegó al objetivo " + cierre.ToString() + " " + tabla.Rows[contador].Cells[1].Value.ToString()
                // +contador.ToString()+" final "+final);
                contador = comentarios(contador, tabla);
                if (tabla.Rows[contador].Cells[1].Value.Equals(">") && cierre == true && contador != final)
                {
                    rs = "Sólo puede haber un cierre de bloque";
                    return rs;
                }
                bool apagarN = false;
                if (tabla.Rows[contador].Cells[2].Value.Equals("Instrucción"))
                {
                    //MessageBox.Show("en: "+tabla.Rows[contador].Cells[1].Value.ToString());
                    if (!tabla.Rows[contador].Cells[1].Value.Equals("apagar"))
                    {
                        apagarN = true;
                    }
                    contador += 3;
                    contador = comentarios(contador, tabla);
                }
                if (tabla.Rows[contador].Cells[2].Value.Equals("Tipo de dato"))
                {
                    contador += 5;
                    contador = comentarios(contador, tabla);
                }
                //MessageBox.Show("Prueba, " + contador.ToString() + ", " + tabla.Rows[final - 3].Cells[1].Value.ToString());
                int final2 = final - 1;
                bool apagar = false;
                if (!tabla.Rows[final - 3].Cells[1].Value.Equals("apagar") && apagarN == true)
                {
                    //MessageBox.Show("Prueba, " + contador.ToString() + ", " + tabla.Rows[final2].Cells[1].Value.ToString());
                    if (tabla.Rows[final2].Cells[2].Value.ToString() != "Comentario")
                    {
                        if (tabla.Rows[final2].Cells[1].Value.ToString().Equals(">"))
                            return "Sólo puede haber un cierre de bloque";
                        else
                        return "La última instrucción debe ser de apagado";
                    }
                    while (tabla.Rows[final2].Cells[2].Value.ToString() == "Comentario" && apagar == false)
                    {
                        final2--;
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
                }
                if (contador < tabla.RowCount - 1)
                {
                    if (tabla.Rows[contador].Cells[2].Value.Equals("No identificado"))
                    {
                        linea = tabla.Rows[contador].Cells[3].Value.ToString();
                        declaracion = tabla.Rows[contador].Cells[1].Value.ToString();
                        rs = "Se ha detectado código invalido en la línea " + linea + ": " + declaracion;
                        return rs;
                    }
                    if (contador == final || tabla.Rows[contador].Cells[2].Value.Equals("Separador de tokens"))
                    {
                        contador++;
                    }
                }
                apagarN = false;
                //MessageBox.Show(tabla.Rows[contador].Cells[1].Value.ToString());
            }
            return rs;
        }
        /*public int interno(DataGridView tabla, int contador)
        {
            if (tabla.Rows[contador].Cells[2].Value.Equals("Instrucción"))
            {
                contador += 3;
                contador = comentarios(contador, tabla);
            }
            if (tabla.Rows[contador].Cells[2].Value.Equals("Tipo de dato"))
            {
                contador += 5;
                contador = comentarios(contador, tabla);
            }
            return contador;
        }*/
        public int comentarios(int contador, DataGridView tabla)
        {
            bool comentario = false;
            if (contador < tabla.RowCount - 1)
            {
                while (tabla.Rows[contador].Cells[2].Value.ToString() == "Comentario" && comentario == false)
                {
                    contador++;
                    if (contador > tabla.RowCount - 1)
                    {
                        contador--;
                        comentario = true;
                    }
                }
                if (comentario == true)
                {
                    contador++;
                    comentario = false;
                }
            }
            return contador;
        }
        public string ejecutar(DataGridView tabla)
        {
            variables = new List<string>();
            string rs = "";
            rs = evaluar(tabla);
            if (rs.Equals(""))
            {
                rs = composicion(tabla);
            }
            return rs;
        }
    }
}
