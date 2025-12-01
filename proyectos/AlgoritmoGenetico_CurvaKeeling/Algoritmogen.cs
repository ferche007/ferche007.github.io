using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoritmos_geneticos
{
    public class Algoritmogen
    {
        Poblacion p = new Poblacion();
        List<Poblacion> generaciones = new List<Poblacion>();
        public void Algoritmo(Random R, Double[,]puntos )
        {
            p.PrimeraGeneracion(R, puntos);
            for (int i = 0; i < 20; i++)
            {
                generaciones.Add(p);
                if (i % 50 == 0)
                {
                    p.mutar(R);
                }
                p.Adecuacion(puntos);
                p.SeleccionarCruzamiento(R);
                p.Cruza(R);
            }
            p.Adecuacion(puntos);
            Console.Write(p.poblacion[0].a1 + " " + p.poblacion[0].a2 + " "+p.poblacion[0].a3);
        }
    }
}