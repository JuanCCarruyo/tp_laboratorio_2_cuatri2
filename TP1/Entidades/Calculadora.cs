using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        //Metodos
        public static double Operar(Operando num1, Operando num2, char operador)
        {
            double resultado = 0;

            
                Calculadora.ValidarOperador(operador);

                switch (operador.ToString())
                {
                    case "+":
                    default:
                        resultado = num1 + num2;
                        break;
                    case "-":
                        resultado = num1 - num2;
                        break;
                    case "/":
                        resultado = num1 / num2;
                        break;
                    case "*":
                        resultado = num1 * num2;
                        break;
                }
            

            return resultado;
        }

        private static string ValidarOperador(char operador)
        {
            string op = operador.ToString();
            switch (op)
            {
                case "+":
                case "-":
                case "/":
                case "*":
                    break;

                default:
                    op = "+";
                    break;
            }

            return op;

        }
    }
}
