using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace algoritmos_geneticos
{
    // Fernando Mejía 
    class Program
    {
        static void Main(string[] args)
        {
            Random R = new Random();
            Double[,] puntos = new Double[20,20];
            puntos[0, 0] = 1;
            puntos[1, 0] = 5.3965793;
            puntos[0, 1] = 2;
            puntos[1, 1] = 5.115095852;
            puntos[0, 2] = 3;
            puntos[1, 2] = 5.797020835;
            puntos[0, 3] = 4;
            puntos[1, 3] = 6.137046464;
            puntos[0, 4] = 5;
            puntos[1, 4] = 6.237719319;
            puntos[0, 5] = 6;
            puntos[1, 5] = 5.87909785;
            puntos[0, 6] = 7;
            puntos[1, 6] = 5.648236381;
            puntos[0, 7] = 8;
            puntos[1, 7] = 6.259102037;
            puntos[0, 8] = 9;
            puntos[1, 8] = 5.645278305;
            puntos[0, 9] = 10;
            puntos[1, 9] = 5.562336226;
            puntos[0, 10] = 11;
            puntos[1, 10] = 6.052973467;
            puntos[0, 11] = 12;
            puntos[1, 11] = 6.490443952;
            puntos[0, 12] = 13;
            puntos[1, 12] = 6.412974698;
            puntos[0, 13] = 14;
            puntos[1, 13] = 6.028038;
            puntos[0, 14] = 15;
            puntos[1, 14] = 6.36707985;
            puntos[0, 15] = 16;
            puntos[1, 15] = 6.653722681;
            puntos[0, 16] = 17;
            puntos[1, 16] = 6.844798733;
            puntos[0, 17] = 18;
            puntos[1, 17] = 6.064360562;
            puntos[0, 18] = 19;
            puntos[1, 18] = 6.213998837;
            puntos[0, 19] = 20;
            puntos[1, 19] = 6.412077495;
            Algoritmogen alg = new Algoritmogen ();
            alg.Algoritmo(R,puntos);
            Console.ReadLine();
        }
    }
}
