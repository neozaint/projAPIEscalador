using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstresAPI
{
    public class Fibonacci
    {
        public string respuesta;
        public string tipoFiboncci = "0";
        public Double numero = 0;
        public Double primero, segundo, tercero;
        public Double fib;

        #region Algoritmo Recursivo
        public Double CalcularFiboncciConRecursividad(Double Num)
        {
            if (Num == 0)
                return 0;
            else
                if (Num == 1)
                return 1;
            else
                return fib =CalcularFiboncciConRecursividad(Num - 1) + CalcularFiboncciConRecursividad(Num - 2);
        }
        #endregion

        #region Algoritmo Iterativo
        public string CalcularFibonacciIterativamente(int numero)
        {
            if (numero == 0)
                tercero = 0;
            else
                tercero = 1;

            primero = 0;
            segundo = 1;

            for (int i = 2; numero >= i; i++)
            {
                tercero = primero + segundo;
                primero = segundo;
                segundo = tercero;
            }
            return "*El Fibonacci de: " + numero + " es " + tercero;
        }
        #endregion
    }
}
