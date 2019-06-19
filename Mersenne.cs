namespace EstresAPI
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public static class Mersenne
    {
        //public const int N_PRIMOS_MERSENNE = 7;

        public static List<string> CalcularMersenne(int N_PRIMOS_MERSENNE)
        {
            List<string> lista = new List<string>();
            var primosMersenne = new List<ulong>(N_PRIMOS_MERSENNE);
            var tiempo = Stopwatch.StartNew();

            primosMersenne.AddRange(PrimosMersenne().Take(N_PRIMOS_MERSENNE));

            tiempo.Stop();

            foreach (var p in primosMersenne)
            {
                lista.Add(p.ToString());
            }

            lista.Add(string.Format("\nHa tardado {0} ms para hallar {1} números primos de Mersenne.",
                tiempo.ElapsedMilliseconds, 
                N_PRIMOS_MERSENNE));

            return lista;
        }

        public static IEnumerable<ulong> Factores(ulong número)
        {
            var máximoFactorPosible = número / 2;

            for (ulong posibleFactor = 2; posibleFactor <= máximoFactorPosible; posibleFactor++)
            {
                if (número % posibleFactor == 0)
                {
                    yield return posibleFactor;
                }
            }
        }

        public static bool EsPrimo(ulong número)
        {
            return número < 2 ? false : !Factores(número).AsParallel().Any();
        }

        public static IEnumerable<ulong> PrimosMersenne()
        {
            return from exponente in Enumerable.Range(2, int.MaxValue - 1)
                   let posiblePrimo = Convert.ToUInt64(Math.Pow(2D, exponente)) - 1UL
                   where EsPrimo(posiblePrimo)
                   select posiblePrimo;
        }
    }
}
