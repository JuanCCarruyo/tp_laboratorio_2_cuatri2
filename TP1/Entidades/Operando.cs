using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        //Campos 
        private double numero;

        //Propiedades
        public string SetNumero
        {
            set { numero = Operando.ValidarNumero(value); }
        }

        //Metodos
        #region constructores
        public Operando()
        {
            this.numero = 0;
        }
        public Operando(double numero) //: this()
        {
            this.numero = numero;
        }
        public Operando(string strNumero) //: this()
        {
            this.SetNumero = strNumero;
        }
        #endregion

        private static double ValidarNumero(string strNumero)
        {
            double ret = 0;
            double n;
            bool isNumeric = double.TryParse(strNumero, out n);
            if (isNumeric == true)
            {
                ret = n;
            }
            return ret;
        }

        #region conversiones binarias
        private static bool EsBinario(string binario)
        {
            bool ret = true;
            foreach (var c in binario)
            {
                if (c != '0' && c != '1')
                {
                    ret = false;
                }
            }
            return ret;
        }

        public static string BinarioDecimal(string binario)
        {
            //Numero auxNum = new Numero();
            string ret;
            double retNum = 0;

            if (Operando.EsBinario(binario) == true)
            {
                string cadenaInvertida = "";
                for (int i = binario.Length - 1; i >= 0; i--)
                {
                    cadenaInvertida += binario[i];
                }

                for (int i = 0; i < cadenaInvertida.Length; i++)
                {
                    if (cadenaInvertida[i] == '1')
                    {
                        retNum += (double)Math.Pow(2, i);
                    }
                }
                ret = Math.Abs(retNum).ToString();
            }
            else
            {
                ret = "Valor inválido";
            }

            return ret;
        }

        public static string DecimalBinario(string numero)
        {
            string resto = "";
            string cadenaInvertida = ""; //como son string se va concatenando los numeros en los for
            double n;

            //   if (Numero.EsBinario(numero) == false) este chequeo no funciona porque toma numeros como "100" como binario y no hace la conversion
            //   {
            if (double.TryParse(numero, out n) == true)
            {
                n = Math.Abs(Math.Floor(n));
                for (; n >= 2;) //se repite siempre que el cociente sea >= 2
                {
                    resto += n % 2; //obtenemos el resto de la division 
                    n = (int)n / 2;    //obtenemos cociente
                }
                resto += n;

                for (int i = resto.Length - 1; i >= 0; i--)
                {
                    cadenaInvertida += resto[i];
                }
                //      }
            }
            else
            {
                cadenaInvertida = "Valor inválido";
            }

            return cadenaInvertida;
        }
        public static string DecimalBinario(double numero)
        {
            return Operando.DecimalBinario(numero.ToString());
        }

        #endregion

        #region operator overloads
        public static double operator +(Operando n1, Operando n2)
        {
            return n1.numero + n2.numero;
        }
        public static double operator -(Operando n1, Operando n2)
        {
            return n1.numero - n2.numero;
        }
        public static double operator *(Operando n1, Operando n2)
        {
            return n1.numero * n2.numero;
        }
        public static double operator /(Operando n1, Operando n2)
        {
            double resultado;
            if (n2.numero == 0)
            {
                resultado = double.MinValue;
            }
            else
            {
                resultado = n1.numero / n2.numero;
            }
            return resultado;
        }
        #endregion





    }
}
