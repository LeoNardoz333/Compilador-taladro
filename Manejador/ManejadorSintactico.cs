using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejador
{
    /* Código de prueba
owo = 10
clase
funcion
atornillar()
si();
*/
    /*
     * clase owo
<
atornillar(10);
numero kita = 10;
apagar();
>
    */
    public class ManejadorSintactico
    {
        ManejadorLexico m = new ManejadorLexico();
        bool apagar = false;
        #region metoditos
        #region respaldo
        public string generales(int contador, DataGridView dtgtabla)
        {
            string rs = "";
            if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Identificador"))
            {
                rs = "1 Falta un tipo de dato, o definición para el identificador en la línea "
                    + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                    ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
            }
            if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Símbolo"))
            {
                rs = "Falta un identificador para el símbolo en la línea "
                    + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                    ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
            }
            if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Valor"))
            {
                rs = "Falta expresión de asignación para el valor en la línea "
                    + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                    ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
            }
            return rs;
        }
        public string clase(int contador, DataGridView dtgtabla)
        {
            string rs = "";
            if (dtgtabla.Rows[contador].Cells[1].Value.Equals("clase"))
            {
                if (contador < dtgtabla.RowCount - 1)
                {
                    //contador++;
                    if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Identificador"))
                    {
                        contador++;
                        if (contador < dtgtabla.RowCount/* - 1*/)
                        {
                            //contador++;
                            if (contador < dtgtabla.RowCount - 1)
                            {
                                if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Separador de tokens"))
                                {
                                    rs = "La declaración de una clase no lleva \";\", línea "
                                    + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString() +
                                    ", en el enunciado " + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString()
                                    + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                                    + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString();
                                    return rs;
                                }
                            }
                            //contador++;
                        }
                        /*else
                            contador++;
                        MessageBox.Show(dtgtabla.Rows[contador].Cells[1].Value.ToString() + " " + contador);*/
                    }
                    else
                    {
                        rs = "Falta un identificador para la clase en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                        return rs;
                    }
                }
                else
                {
                    rs = "Falta un identificador para la clase en la línea "
                        + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                    + ", en el enunciado "
                    + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    return rs;
                }
            }
            return rs;
        }
        public string asignacion(int contador, DataGridView dtgtabla)
        {
            string rs = "";
            if (contador < dtgtabla.RowCount - 1 || contador == 0)
            {
                if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Tipo de dato"))
                {
                    if (contador < dtgtabla.RowCount - 1)
                    {
                        if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Símbolo"))
                        {
                            rs = "Falta un identificador en la expresión en la línea " +
                            dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                            return rs;
                        }
                        if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Valor"))
                        {
                            rs = "Falta símbolo de \"=\" en la expresión en la línea " +
                            dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                            return rs;
                        }
                        if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Identificador"))
                        {
                            contador++;
                            if (contador < dtgtabla.RowCount - 1)
                            {
                                if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Valor"))
                                {
                                    rs = "Falta símbolo de \"=\" en la expresión en la línea "
                                        + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador - 2].Cells[1].Value.ToString() + " "
                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                    return rs;
                                }
                                if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Símbolo") &&
                                    dtgtabla.Rows[contador + 1].Cells[1].Value.Equals("="))
                                {
                                    contador++;
                                    if (contador < dtgtabla.RowCount - 1)
                                    {
                                        if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Valor") ||
                                            dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Identificador"))
                                        {
                                            contador++;
                                            if (contador < dtgtabla.RowCount - 1)
                                            {
                                                if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Separador de tokens"))
                                                {
                                                    contador++;
                                                    //rs = "Ta bien";
                                                }
                                                else
                                                {
                                                    rs = "Falta separador de tokens en la línea "
                                                        + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                                                    + ", en el enunciado "
                                                    + dtgtabla.Rows[contador - 3].Cells[1].Value.ToString() + " "
                                                    + dtgtabla.Rows[contador - 2].Cells[1].Value.ToString() + " "
                                                    + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                                                    + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                                    return rs;
                                                }

                                            }
                                        }
                                        else
                                        {
                                            rs = "Asigne un valor correcto al tipo de dato en la línea "
                                                + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador - 2].Cells[1].Value.ToString() + " "
                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                        + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                                            return rs;
                                        }
                                    }
                                    else
                                    {
                                        rs = "Falta asignar el valor en la linea "
                                            + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador - 2].Cells[1].Value.ToString() + " "
                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                        return rs;
                                    }
                                }
                            }
                            else
                            {
                                rs = "Falta símbolo de \"=\" en la expresión en la línea "
                                    + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                return rs;
                            }
                        }
                    }
                    else
                    {
                        rs = "Falta la expresión de asignación para el tipo de dato en la linea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                        return rs;
                    }
                }
            }
            return rs;
        }
        public string instruccion(int contador, DataGridView dtgtabla)
        {
            bool apagar = false;
            string rs = "";
            if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Instrucción"))
            {
                if (contador < dtgtabla.RowCount - 1)
                {
                    if (dtgtabla.Rows[contador].Cells[1].Value.Equals("apagar"))
                    {
                        apagar = true;
                    }
                    if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals("()") &&
                    !dtgtabla.Rows[contador].Cells[1].Value.Equals("apagar"))
                    {
                        rs = "Falta sobrecarga para la instrucción en la linea "
                        + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString() +
                        ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString()
                        + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                        return rs;
                    }
                    if (apagar == true)
                    {
                        //MessageBox.Show("Si pasó ()");
                        if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals("()"))
                        {
                            //MessageBox.Show("Si pasó apagar");
                            if (contador < dtgtabla.RowCount - 2)
                            {
                                if (dtgtabla.Rows[contador + 2].Cells[2].Value.Equals("Separador de tokens"))
                                {
                                    //MessageBox.Show("Si pasó separador");
                                    contador = contador + 2;
                                    rs = "";
                                }
                                else
                                {
                                    rs = "Falta separador de tokens en la línea "
                                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                                    ", en el enunciado "
                                    + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                    return rs;
                                }
                            }
                            else
                            {
                                rs = "Falta separador de tokens en la línea "
                                    + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                                ", en el enunciado "
                                + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                return rs;
                            }
                        }
                        else if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Expresión"))
                        {
                            rs = "La instrucción de apagar no debe llevar una sobrecarga en la línea "
                                + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString() +
                            ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString()
                            + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                            return rs;
                        }
                    }
                    if (apagar == false)
                    {
                        if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Expresión"))
                        {
                            contador++;
                            if (contador < dtgtabla.RowCount - 1)
                            {
                                if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Separador de tokens"))
                                {
                                    contador++;
                                    rs = "";
                                }
                                else
                                {
                                    rs = "Falta separador de tokens en la línea "
                                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                                    ", en el enunciado "
                                    + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString()
                                    + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                    return rs;
                                }
                            }
                            else
                            {
                                rs = "Falta separador de tokens en la línea "
                                    + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                                ", en el enunciado "
                                + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString()
                                + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                return rs;
                            }
                        }
                        else
                        if (apagar == false)
                        {
                            rs = "Falta expresión para la instrucción en la linea "
                                + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                            ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                            return rs;
                        }
                    }
                }
                else
                {
                    rs = "Falta apertura \"(\" o cierre de \")\" para la instrucción en la linea "
                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                    ", en el enunciado "
                    + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    return rs;
                }
                apagar = false;
            }
            return rs;
        }
        public string metodos(int contador, DataGridView dtgtabla)
        {
            string rs = "", expresion = "";
            if (dtgtabla.Rows[contador].Cells[1].Value.Equals("funcion"))
            {
                if (contador < dtgtabla.RowCount - 1)
                {
                    if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Identificador"))
                    {
                        contador++;
                        if (contador < dtgtabla.RowCount - 1)
                        {
                            if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals("("))
                            {
                                rs = "Falta cierre de \")\" para el identificador en la línea "
                                    + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString()
                                + ", en el enunciado "
                                + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                                return rs;
                            }
                            expresion = dtgtabla.Rows[contador + 1].Cells[2].Value.ToString();
                            if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals("()") ||
                                expresion.Equals("Expresión"))
                            {
                                contador++;
                                if (contador < dtgtabla.RowCount - 1)
                                {
                                    if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals(";"))
                                    {
                                        contador++;
                                        rs = "La declaración de una función no debe llevar \";\", linea "
                                            + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                                        + ", en el enunciado "
                                        + dtgtabla.Rows[contador - 2].Cells[1].Value.ToString()
                                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString()
                                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                        return rs;
                                    }
                                }
                                //else
                                //  rs = "Ta bien";
                            }
                            else
                            {
                                rs = "Falta un apertura \"(\" y/o cierre de \")\" para el identificador en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                return rs;
                            }
                        }
                    }
                    else
                    {
                        rs = "Falta un identificador para la función en al línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                        return rs;
                    }
                }
            }
            return rs;
        }
        public string condicion(int contador, DataGridView dtgtabla)
        {
            string valor, rs = "";
            int contador2;
            valor = dtgtabla.Rows[contador].Cells[1].Value.ToString();
            contador2 = 0;
            valor = dtgtabla.Rows[contador].Cells[1].Value.ToString();
            contador2 = 0;
            if (contador2 < valor.Length)
            {
                if (dtgtabla.Rows[contador].Cells[1].Value.Equals("si"))
                {
                    rs = "Falta definir una condición en la línea " + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                    + ", en el enunciado "
                    + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    return rs;
                }
            }
            if (contador2 < valor.Length)
            {
                if (dtgtabla.Rows[contador].Cells[1].Value.Equals("si("))
                {
                    rs = "Falta cierre de \")\" para la condición en la línea "
                        + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                    + ", en el enunciado "
                    + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    return rs;
                }
            }
            if (contador2 < valor.Length - 3)
            {
                if (valor[contador2].Equals('s') && valor[contador2 + 1].Equals('i') && valor[contador2 + 2].Equals('(')
                    && valor[contador2 + 3].Equals(')'))
                {
                    rs = "Falta definir una condición en la línea " + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                    + ", en el enunciado "
                    + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    return rs;
                }
            }
            if (contador2 < valor.Length - 3)
            {
                if (valor[contador2].Equals('s') && valor[contador2 + 1].Equals('i') && valor[contador2 + 2].Equals('(')
                    && !valor[valor.Length - 1].Equals(')'))
                {
                    rs = "Falta cierre de \")\" para la condición en la línea "
                        + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                    + ", en el enunciado "
                    + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    return rs;
                }
            }
            if (contador2 < valor.Length - 3)
            {
                if (valor[contador2].Equals('s') && valor[contador2 + 1].Equals('i') && valor[contador2 + 2].Equals('(')
                    && valor[valor.Length - 1].Equals(')') && !dtgtabla.Rows[contador].Cells[2].Value.Equals("Condición"))
                {
                    rs = "Condición inválida para la condición \"si\" en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                    + ", en el enunciado "
                    + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    return rs;
                }
            }
            if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Condición"))
            {
                if (contador < dtgtabla.RowCount - 1)
                {
                    if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals(";"))
                    {
                        contador++;
                        rs = "La declaración de una condición no debe llevar \";\", linea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString()
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                        return rs;
                    }
                }
            }
            return rs;
        }
        #endregion
        public string Evaluar(DataGridView dtgtabla)
        {
            for (int contador = 0; contador < dtgtabla.RowCount; contador++)
            {
                //MessageBox.Show(dtgtabla.Rows[contador].Cells[1].Value.ToString());
                apagar = false;
                //generales
                if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Expresión"))
                {
                    return "1 Falta un identificador o instrucción previamente a la expresión en la línea "
                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                        ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                }
                if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Separador de tokens"))
                {
                    return "Separador de tokens innecesario encontrado, línea "
                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                        ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                }
                if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Identificador"))
                {
                    return "Falta un tipo de dato, o definición para el identificador en la línea "
                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                        ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                }
                if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Símbolo"))
                {
                    if (dtgtabla.Rows[contador].Cells[1].Value.Equals("="))
                    {
                        return "Falta un identificador para el símbolo en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                            ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    }else
                    {
                        return "Las operaciones deben hacerse sin espacios entre valores o variables, en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                            ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    }
                }
                if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Valor"))
                {
                    return "Falta expresión de asignación para el valor en la línea "
                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                        ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                }
                //clase
                //MessageBox.Show("Desde la clase " + dtgtabla.Rows[contador].Cells[1].Value);
                if (dtgtabla.Rows[contador].Cells[1].Value.Equals("clase"))
                {
                    if (contador < dtgtabla.RowCount - 1)
                    {
                        if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Identificador"))
                        {
                            contador++;
                            if (contador < dtgtabla.RowCount/* - 1*/)
                            {
                                if (contador < dtgtabla.RowCount - 1)
                                {
                                    if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Separador de tokens"))
                                    {
                                        return "La declaración de una clase no lleva \";\", línea "
                                        + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString() +
                                        ", en el enunciado " + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString()
                                        + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString();
                                    }
                                }
                            }
                            /*else
                                contador++;
                            MessageBox.Show(dtgtabla.Rows[contador].Cells[1].Value.ToString() + " " + contador);*/
                        }
                        else
                        {
                            return "Falta un identificador para la clase en la línea "
                                + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                        }
                    }
                    else
                    {
                        return "Falta un identificador para la clase en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    }
                }
                //Asignación
                if (contador < dtgtabla.RowCount - 1 || contador == 0 || contador == dtgtabla.RowCount - 1)
                {
                    if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Tipo de dato"))
                    {
                        if (contador < dtgtabla.RowCount - 1)
                        {
                            MessageBox.Show("Desde la asignación " + dtgtabla.Rows[contador+1].Cells[1].Value);
                            if (dtgtabla.Rows[contador + 1].Cells[2].Value.ToString().Equals("Símbolo")||
                                dtgtabla.Rows[contador + 1].Cells[1].Value.ToString() == "=")
                            {
                                return "Falta un identificador en la expresión en la línea " +
                                dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " " +
                            dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                            }
                            if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Valor"))
                            {
                                return "Falta símbolo de \"=\" en la expresión en la línea " +
                                dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                            /*+ dtgtabla.Rows[contador].Cells[1].Value.ToString()*/;
                            }
                            if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("No identificado"))
                            {
                                return "Identificador inválido, en la línea "
                                    + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                    + ", en el enunciado "
                    + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                    + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                            }
                            if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Identificador"))
                            {
                                //contador++;
                                if (contador+1 < dtgtabla.RowCount - 1)
                                {
                                    if (dtgtabla.Rows[contador + 2].Cells[2].Value.Equals("Valor"))
                                    {
                                        return "Falta símbolo de \"=\" en la expresión en la línea "
                                            + dtgtabla.Rows[contador+1].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            //+ dtgtabla.Rows[contador - 2].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador+1].Cells[1].Value.ToString();
                                    }
                                    if (/*dtgtabla.Rows[contador + 2].Cells[2].Value.Equals("Símbolo") &&*/
                                        dtgtabla.Rows[contador + 2].Cells[1].Value.Equals("="))
                                    {
                                        //contador++;
                                        if (contador+2 < dtgtabla.RowCount - 1)
                                        {
                                            if (dtgtabla.Rows[contador + 3].Cells[1].Value.ToString().Contains("(") || dtgtabla.Rows[contador + 3].Cells[1].Value.ToString().Contains(")"))
                                            {
                                                return "El valor de una variable no puede llevar paréntesis, en la línea "
                                                    + dtgtabla.Rows[contador+3].Cells[3].Value.ToString()
                                    + ", en el enunciado "
                                                        + dtgtabla.Rows[contador-1].Cells[1].Value.ToString() + " "
                                                        + dtgtabla.Rows[contador ].Cells[1].Value.ToString() + " "
                                                        + dtgtabla.Rows[contador+2].Cells[1].Value.ToString() + " "
                                                        + dtgtabla.Rows[contador + 3].Cells[1].Value.ToString();
                                            }
                                            if (dtgtabla.Rows[contador + 3].Cells[2].Value.Equals("Valor") ||
                                                dtgtabla.Rows[contador + 3].Cells[2].Value.Equals("Identificador"))
                                            {
                                                //contador++;
                                                if (contador+3 < dtgtabla.RowCount - 1)
                                                {
                                                    if (dtgtabla.Rows[contador + 4].Cells[2].Value.ToString().Equals("Símbolo"))
                                                    {
                                                        return "Las operaciones deben hacerse sin espacios entre valores o variables, en la línea "
                                                        + dtgtabla.Rows[contador+3].Cells[3].Value.ToString() +
                                                        ", en el enunciado " + dtgtabla.Rows[contador+3].Cells[1].Value.ToString() + " "
                                                        + dtgtabla.Rows[contador + 4].Cells[1].Value.ToString();
                                                    }
                                                    if (dtgtabla.Rows[contador + 4].Cells[2].Value.Equals("Separador de tokens"))
                                                    {
                                                        contador+=4;
                                                        /*MessageBox.Show("Si salió: "+ dtgtabla.Rows[contador - 3].Cells[1].Value.ToString()
                                                            + ", en"+ dtgtabla.Rows[contador].Cells[1].Value.ToString());*/
                                                    }
                                                    else
                                                    {
                                                        return "Falta separador de tokens en la línea "
                                                            + dtgtabla.Rows[contador+3].Cells[3].Value.ToString()
                                                        + ", en el enunciado "
                                                        + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                                                        + dtgtabla.Rows[contador +1].Cells[1].Value.ToString() + " "
                                                        + dtgtabla.Rows[contador +2].Cells[1].Value.ToString() + " "
                                                        + dtgtabla.Rows[contador+3].Cells[1].Value.ToString();
                                                    }

                                                }
                                                else
                                                {
                                                    return "Falta separador de tokens en la línea "
                                                        + dtgtabla.Rows[contador+3].Cells[3].Value.ToString()
                                                    + ", en el enunciado "
                                                    + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                                                    + dtgtabla.Rows[contador+1 ].Cells[1].Value.ToString() + " "
                                                    + dtgtabla.Rows[contador +2].Cells[1].Value.ToString() + " "
                                                    + dtgtabla.Rows[contador+3].Cells[1].Value.ToString();
                                                }
                                            }
                                            else
                                            {
                                                return "Asigne un valor correcto al tipo de dato en la línea "
                                                    + dtgtabla.Rows[contador+3].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador+1].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador+2].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador + 3].Cells[1].Value.ToString();
                                            }
                                        }
                                        else
                                        {
                                            return "Falta asignar el valor en la linea "
                                                + dtgtabla.Rows[contador+2].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador+1].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador+2].Cells[1].Value.ToString();
                                        }
                                    }
                                    else
                                    {
                                        return "Falta símbolo de \"=\" en la expresión en la línea "
                                        + dtgtabla.Rows[contador+2].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador+1].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador+2].Cells[1].Value.ToString();
                                    }
                                }
                                else
                                {
                                    return "Falta símbolo de \"=\" en la expresión en la línea "
                                        + dtgtabla.Rows[contador+1].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador+1].Cells[1].Value.ToString();
                                }
                            }
                            else
                            {
                                return "Falta la expresión de asignación para el tipo de dato en la linea "
                                    + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                                + ", en el enunciado "
                                + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                            }
                        }
                        else
                        {
                            return "Falta la expresión de asignación para el tipo de dato en la linea "
                                + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                        }
                    }
                    //Instrucción
                    //MessageBox.Show("Desde instrucción " + dtgtabla.Rows[contador].Cells[1].Value);
                    if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Instrucción"))
                    {
                        if (contador < dtgtabla.RowCount - 1)
                        {
                            if (dtgtabla.Rows[contador].Cells[1].Value.Equals("apagar"))
                            {
                                apagar = true;
                            }
                            if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals("()") &&
                            !dtgtabla.Rows[contador].Cells[1].Value.Equals("apagar"))
                            {
                                return "Falta sobrecarga para la instrucción en la linea "
                                + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString() +
                                ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString()
                                + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                            }
                            if (apagar == true)
                            {
                                if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals("()"))
                                {
                                    if (contador < dtgtabla.RowCount - 2)
                                    {
                                        if (dtgtabla.Rows[contador + 2].Cells[2].Value.Equals("Separador de tokens"))
                                        {
                                            contador = contador + 2;
                                        }
                                        else
                                        {
                                            return "Falta separador de tokens en la línea "
                                                + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                                            ", en el enunciado "
                                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                        }
                                    }
                                    else
                                    {
                                        return "Falta separador de tokens en la línea "
                                            + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                                        ", en el enunciado "
                                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                    }
                                }
                                else if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Expresión"))
                                {
                                    return "La instrucción de apagar no debe llevar una sobrecarga en la línea "
                                        + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString() +
                                    ", en el enunciado "
                                    + dtgtabla.Rows[contador].Cells[1].Value.ToString()
                                    + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                                }
                            }
                            if (apagar == false)
                            {
                                /*if(dtgtabla.Rows[contador + 1].Cells[1].Value.ToString().Substring(1, dtgtabla.Rows[contador + 1].Cells[1].Value.ToString().Length - 2).Contains("(")||
                                    dtgtabla.Rows[contador + 1].Cells[1].Value.ToString().Substring(1, dtgtabla.Rows[contador + 1].Cells[1].Value.ToString().Length - 2).Contains(")"))
                                {
                                    return "Las operaciones dentro de la expresión no pueden tener paréntesis, en la línea "
                                                + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString() +
                                            ", en el enunciado "
                                            + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                                }*/
                                if (dtgtabla.Rows[contador + 1].Cells[1].Value.ToString().Contains('(') &&
                                    dtgtabla.Rows[contador + 1].Cells[1].Value.ToString().Contains(')') &&
                                    dtgtabla.Rows[contador + 1].Cells[1].Value.ToString().Contains(' '))
                                {
                                    return "Las expresiones deben declararse sin espacios, en la línea "
                                                + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString() +
                                            ", en el enunciado "
                                            + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                                }
                                if (dtgtabla.Rows[contador + 1].Cells[1].Value.ToString().Contains('(') &&
                                    !dtgtabla.Rows[contador + 1].Cells[1].Value.ToString().Contains(')') || 
                                    !dtgtabla.Rows[contador + 1].Cells[1].Value.ToString().Contains('(') &&
                                    dtgtabla.Rows[contador + 1].Cells[1].Value.ToString().Contains(')'))
                                {
                                    return "Falta definir el cierre o apertura de la expresión, o la expresión es inválida (las expresiones no llevan " +
                                        "paréntesis dentro de si mismas) en la línea "
                                                + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString() +
                                            ", en el enunciado "
                                            + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                                }
                                if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Expresión"))
                                {
                                    //contador++;
                                    if(dtgtabla.Rows[contador+1].Cells[1].Value.ToString().Contains(' '))
                                    {
                                        return "Las expresiones deben declararse sin espacios, en la línea "
                                                + dtgtabla.Rows[contador+1].Cells[3].Value.ToString() +
                                            ", en el enunciado "
                                            + dtgtabla.Rows[contador+1].Cells[1].Value.ToString();
                                    }
                                    if (contador+1 < dtgtabla.RowCount - 1)
                                    {
                                        if (dtgtabla.Rows[contador + 2].Cells[2].Value.Equals("Separador de tokens"))
                                        {
                                            contador+=2;
                                            //MessageBox.Show(dtgtabla.Rows[contador].Cells[2].Value.ToString());
                                            //rs = "";
                                        }
                                        else
                                        {
                                            return "Falta separador de tokens en la línea "
                                                + dtgtabla.Rows[contador+2].Cells[3].Value.ToString() +
                                            ", en el enunciado "
                                            + dtgtabla.Rows[contador+1].Cells[1].Value.ToString()
                                            + dtgtabla.Rows[contador+2].Cells[1].Value.ToString();
                                        }
                                    }
                                    else
                                    {
                                        return "Falta separador de tokens en la línea "
                                            + dtgtabla.Rows[contador+1].Cells[3].Value.ToString() +
                                        ", en el enunciado "
                                        + dtgtabla.Rows[contador].Cells[1].Value.ToString()
                                        + dtgtabla.Rows[contador+1].Cells[1].Value.ToString();
                                    }
                                }
                                else
                                if (apagar == false)
                                {
                                    return "Falta expresión para la instrucción en la linea "
                                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                                    ", en el enunciado "
                                    + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                }
                            }
                        }
                        else
                        {
                            return "Falta apertura \"(\" o cierre de \")\" para la instrucción en la linea "
                                + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                            ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                        }
                        apagar = false;
                    }
                }
                //Generales al final
                /*if (contador < dtgtabla.RowCount - 1)
                {
                    //MessageBox.Show(dtgtabla.Rows[contador].Cells[2].Value.ToString());
                    if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Expresión"))
                    {
                        return "2 Falta un identificador o instrucción previamente a la expresión en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                            ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    }
                    if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Símbolo"))
                    {
                        return "Falta un identificador para el símbolo en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                            ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    }
                    if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Valor"))
                    {
                        return "Falta expresión de asignación para el valor en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                            ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    }
                }*/
            }
            return "";
        }
        public string copiaEvaluar(DataGridView dtgtabla)
        {
            int contador/*, contador2*/;
            bool apagar = false;
            string rs = "";
            //string valor, expresion;
            for (contador = 0; contador < dtgtabla.RowCount; contador++)
            {
                apagar = false;
                //generales
                if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Expresión"))
                {
                    rs = "Falta un identificador o instrucción previamente a la expresión en la línea "
                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                        ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    return rs;
                }
                if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Identificador"))
                {
                    rs = "Falta un tipo de dato, o definición para el identificador en la línea "
                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                        ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    return rs;
                }
                if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Símbolo"))
                {
                    rs = "Falta un identificador para el símbolo en la línea "
                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                        ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    return rs;
                }
                if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Valor"))
                {
                    rs = "Falta expresión de asignación para el valor en la línea "
                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                        ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    return rs;
                }
                //clase
                //MessageBox.Show("Desde la clase " + dtgtabla.Rows[contador].Cells[1].Value);
                if (dtgtabla.Rows[contador].Cells[1].Value.Equals("clase"))
                {
                    if (contador < dtgtabla.RowCount - 1)
                    {
                        //contador++;
                        if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Identificador"))
                        {
                            contador++;
                            if (contador < dtgtabla.RowCount/* - 1*/)
                            {
                                //contador++;
                                if (contador < dtgtabla.RowCount - 1)
                                {
                                    if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Separador de tokens"))
                                    {
                                        rs = "La declaración de una clase no lleva \";\", línea "
                                        + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString() +
                                        ", en el enunciado " + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString()
                                        + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString();
                                        return rs;
                                    }
                                }
                                //contador++;
                            }
                            /*else
                                contador++;
                            MessageBox.Show(dtgtabla.Rows[contador].Cells[1].Value.ToString() + " " + contador);*/
                        }
                        else
                        {
                            rs = "Falta un identificador para la clase en la línea "
                                + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                            return rs;
                        }
                    }
                    else
                    {
                        rs = "Falta un identificador para la clase en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                        + ", en el enunciado "
                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                        return rs;
                    }
                }
                //Asignación
                //MessageBox.Show("Desde la asignación "+ dtgtabla.Rows[contador].Cells[1].Value);
                if (contador < dtgtabla.RowCount - 1 || contador == 0)
                {
                    if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Tipo de dato"))
                    {
                        if (contador < dtgtabla.RowCount - 1)
                        {
                            if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Símbolo"))
                            {
                                rs = "Falta un identificador en la expresión en la línea " +
                                dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                return rs;
                            }
                            if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Valor"))
                            {
                                rs = "Falta símbolo de \"=\" en la expresión en la línea " +
                                dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                return rs;
                            }
                            if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Identificador"))
                            {
                                contador++;
                                if (contador < dtgtabla.RowCount - 1)
                                {
                                    if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Valor"))
                                    {
                                        rs = "Falta símbolo de \"=\" en la expresión en la línea "
                                            + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador - 2].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                        return rs;
                                    }
                                    if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Símbolo") &&
                                        dtgtabla.Rows[contador + 1].Cells[1].Value.Equals("="))
                                    {
                                        contador++;
                                        if (contador < dtgtabla.RowCount - 1)
                                        {
                                            if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Valor") ||
                                                dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Identificador"))
                                            {
                                                contador++;
                                                if (contador < dtgtabla.RowCount - 1)
                                                {
                                                    if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Separador de tokens"))
                                                    {
                                                        contador++;
                                                        //rs = "Ta bien";
                                                    }
                                                    else
                                                    {
                                                        rs = "Falta separador de tokens en la línea "
                                                            + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                                                        + ", en el enunciado "
                                                        + dtgtabla.Rows[contador - 3].Cells[1].Value.ToString() + " "
                                                        + dtgtabla.Rows[contador - 2].Cells[1].Value.ToString() + " "
                                                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                                                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                                        return rs;
                                                    }

                                                }
                                            }
                                            else
                                            {
                                                rs = "Asigne un valor correcto al tipo de dato en la línea "
                                                    + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador - 2].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                                                return rs;
                                            }
                                        }
                                        else
                                        {
                                            rs = "Falta asignar el valor en la linea "
                                                + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador - 2].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                            return rs;
                                        }
                                    }
                                }
                                else
                                {
                                    rs = "Falta símbolo de \"=\" en la expresión en la línea "
                                        + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                    return rs;
                                }
                            }
                        }
                        else
                        {
                            rs = "Falta la expresión de asignación para el tipo de dato en la linea "
                                + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                            return rs;
                        }
                    }
                    //Instrucción
                    //MessageBox.Show("Desde instrucción " + dtgtabla.Rows[contador].Cells[1].Value);
                    if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Instrucción"))
                    {
                        if (contador < dtgtabla.RowCount - 1)
                        {
                            if (dtgtabla.Rows[contador].Cells[1].Value.Equals("apagar"))
                            {
                                apagar = true;
                            }
                            if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals("()") &&
                            !dtgtabla.Rows[contador].Cells[1].Value.Equals("apagar"))
                            {
                                rs = "Falta sobrecarga para la instrucción en la linea "
                                + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString() +
                                ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString()
                                + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                                return rs;
                            }
                            if (apagar == true)
                            {
                                //MessageBox.Show("Si pasó ()");
                                if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals("()"))
                                {
                                    //MessageBox.Show("Si pasó apagar");
                                    if (contador < dtgtabla.RowCount - 2)
                                    {
                                        if (dtgtabla.Rows[contador + 2].Cells[2].Value.Equals("Separador de tokens"))
                                        {
                                            //MessageBox.Show("Si pasó separador");
                                            contador = contador + 2;
                                            rs = "";
                                        }
                                        else
                                        {
                                            rs = "Falta separador de tokens en la línea "
                                                + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                                            ", en el enunciado "
                                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                            return rs;
                                        }
                                    }
                                    else
                                    {
                                        rs = "Falta separador de tokens en la línea "
                                            + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                                        ", en el enunciado "
                                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                        return rs;
                                    }
                                }
                                else if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Expresión"))
                                {
                                    rs = "La instrucción de apagar no debe llevar una sobrecarga en la línea "
                                        + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString() +
                                    ", en el enunciado "
                                    + dtgtabla.Rows[contador].Cells[1].Value.ToString()
                                    + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                                    return rs;
                                }
                            }
                            if (apagar == false)
                            {
                                if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Expresión"))
                                {
                                    contador++;
                                    if (contador < dtgtabla.RowCount - 1)
                                    {
                                        if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Separador de tokens"))
                                        {
                                            contador++;
                                            rs = "";
                                        }
                                        else
                                        {
                                            rs = "Falta separador de tokens en la línea "
                                                + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                                            ", en el enunciado "
                                            + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString()
                                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                            return rs;
                                        }
                                    }
                                    else
                                    {
                                        rs = "Falta separador de tokens en la línea "
                                            + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                                        ", en el enunciado "
                                        + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString()
                                        + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                        return rs;
                                    }
                                }
                                else
                                if (apagar == false)
                                {
                                    rs = "Falta expresión para la instrucción en la linea "
                                        + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                                    ", en el enunciado "
                                    + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                    return rs;
                                }
                            }
                        }
                        else
                        {
                            rs = "Falta apertura \"(\" o cierre de \")\" para la instrucción en la linea "
                                + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                            ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                            return rs;
                        }
                        apagar = false;
                    }
                    //Métodos
                    //MessageBox.Show("Desde función " + dtgtabla.Rows[contador].Cells[1].Value);
                    /*if (dtgtabla.Rows[contador].Cells[1].Value.Equals("funcion"))
                    {
                        if (contador < dtgtabla.RowCount - 1)
                        {
                            if (dtgtabla.Rows[contador + 1].Cells[2].Value.Equals("Identificador"))
                            {
                                contador++;
                                if (contador < dtgtabla.RowCount - 1)
                                {
                                    if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals("("))
                                    {
                                        rs = "Falta cierre de \")\" para el identificador en la línea "
                                            + dtgtabla.Rows[contador + 1].Cells[3].Value.ToString()
                                        + ", en el enunciado "
                                        + dtgtabla.Rows[contador + 1].Cells[1].Value.ToString();
                                        return rs;
                                    }
                                    expresion = dtgtabla.Rows[contador + 1].Cells[2].Value.ToString();
                                    if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals("()") ||
                                        expresion.Equals("Expresión"))
                                    {
                                        contador++;
                                        if (contador < dtgtabla.RowCount - 1)
                                        {
                                            if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals(";"))
                                            {
                                                contador++;
                                                rs = "La declaración de una función no debe llevar \";\", linea "
                                                    + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                                                + ", en el enunciado "
                                                + dtgtabla.Rows[contador - 2].Cells[1].Value.ToString()
                                                + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString()
                                                + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                                return rs;
                                            }
                                        }
                                        //else
                                        //  rs = "Ta bien";
                                    }
                                    else
                                    {
                                        rs = "Falta un apertura \"(\" y/o cierre de \")\" para el identificador en la línea "
                                    + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                                + ", en el enunciado "
                                + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString() + " "
                                + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                        return rs;
                                    }
                                }
                            }
                            else
                            {
                                rs = "Falta un identificador para la función en al línea "
                                    + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                                + ", en el enunciado "
                                + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                return rs;
                            }
                        }
                    }*/
                    //condiciones

                    //MessageBox.Show("Desde condición " + dtgtabla.Rows[contador].Cells[1].Value);
                    /*valor = dtgtabla.Rows[contador].Cells[1].Value.ToString();
                    contador2 = 0;
                    if (contador2 < valor.Length)
                    {
                        if (dtgtabla.Rows[contador].Cells[1].Value.Equals("si"))
                        {
                            rs = "Falta definir una condición en la línea " + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                            return rs;
                        }
                    }
                    if (contador2 < valor.Length)
                    {
                        if (dtgtabla.Rows[contador].Cells[1].Value.Equals("si("))
                        {
                            rs = "Falta cierre de \")\" para la condición en la línea "
                                + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                            return rs;
                        }
                    }
                    if (contador2 < valor.Length - 3)
                    {
                        if (valor[contador2].Equals('s') && valor[contador2 + 1].Equals('i') && valor[contador2 + 2].Equals('(')
                            && valor[contador2 + 3].Equals(')'))
                        {
                            rs = "Falta definir una condición en la línea " + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                            return rs;
                        }
                    }
                    if (contador2 < valor.Length - 3)
                    {
                        if (valor[contador2].Equals('s') && valor[contador2 + 1].Equals('i') && valor[contador2 + 2].Equals('(')
                            && !valor[valor.Length - 1].Equals(')'))
                        {
                            rs = "Falta cierre de \")\" para la condición en la línea "
                                + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                            return rs;
                        }
                    }
                    if (contador2 < valor.Length - 3)
                    {
                        if (valor[contador2].Equals('s') && valor[contador2 + 1].Equals('i') && valor[contador2 + 2].Equals('(')
                            && valor[valor.Length - 1].Equals(')') && !dtgtabla.Rows[contador].Cells[2].Value.Equals("Condición"))
                        {
                            rs = "Condición inválida para la condición \"si\" en la línea "
                                    + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                            + ", en el enunciado "
                            + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                            return rs;
                        }
                    }
                    if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Condición"))
                    {
                        if (contador < dtgtabla.RowCount - 1)
                        {
                            if (dtgtabla.Rows[contador + 1].Cells[1].Value.Equals(";"))
                            {
                                contador++;
                                rs = "La declaración de una condición no debe llevar \";\", linea "
                                    + dtgtabla.Rows[contador].Cells[3].Value.ToString()
                                + ", en el enunciado "
                                + dtgtabla.Rows[contador - 1].Cells[1].Value.ToString()
                                + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                                return rs;
                            }
                        }
                    }*/
                }
                //Generales al final
                if (contador < dtgtabla.RowCount - 1)
                {
                    if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Expresión"))
                    {
                        rs = "Falta un identificador o instrucción previamente a la expresión en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                            ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                        return rs;
                    }
                    /*if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Identificador"))
                    {
                        rs = "1 Falta un tipo de dato, o definició para el identificador en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                            ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                        return rs;
                    }*/
                    if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Símbolo"))
                    {
                        rs = "Falta un identificador para el símbolo en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                            ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                        return rs;
                    }
                    if (dtgtabla.Rows[contador].Cells[2].Value.Equals("Valor"))
                    {
                        rs = "Falta expresión de asignación para el valor en la línea "
                            + dtgtabla.Rows[contador].Cells[3].Value.ToString() +
                            ", en el enunciado " + dtgtabla.Rows[contador].Cells[1].Value.ToString();
                        return rs;
                    }
                }
            }
            return rs;
        }
        #endregion
        public void comprobar(string texto, List<Tokens> tabla, DataGridView gtabla)
        {
            m.HacerLexicos(texto,tabla,gtabla);
            if (Evaluar(gtabla) != "")
            {
                MessageBox.Show(Evaluar(gtabla));
            }
        }
    }
}
