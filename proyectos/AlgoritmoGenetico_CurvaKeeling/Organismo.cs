using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace algoritmos_geneticos
{
    public class Organismo
    {
        Random r = new Random();
        public int[] croma1 = new int[20];
        public int[] croma2 = new int[20];
        public int[] croma3 = new int[20];
        public double a1, a2, a3;
        public double adecuacion; 
        public void ConvBin(double num, int []crom)
        {
            if (num<0)
                crom[0] = 0; 
            else
                crom[0] = 1;
            num = Math.Abs(num);
            for (int i= 0; i < 19; i++)
            {
                if (num>=Math.Pow(2,9-i))
                {
                    crom[i + 1] = 1;
                    num -= Math.Pow(2, 9 - i);
                }
                else
                    crom[i + 1] = 0;
            }
        }
        public double ConvDec(int []crom)
        {
            double num = 0;
            for (int i = 1; i < 20; i++)
            {
                if (crom[i] == 1)
                    num += Math.Pow(2, 10 - i);
            }
            if (crom[0] == 0)
                num = num * -1;
            return num;
        }
        public void ConversionCromosoma()
        {
            a1=ConvDec(croma1);
            a2=ConvDec(croma2);
            a3=ConvDec(croma3);
        }
        public void Adecuar(Double[,] puntos)
        {
            adecuacion = 0;
            double y;
            int t = 0;
            for (t=0; t < 20; t++)
            {
                y = a1 * t + a2*Math.Sin(a3*t) + 316; 
                adecuacion +=  Math.Abs(puntos[1, t] - y);
            }
        }
    }
}
