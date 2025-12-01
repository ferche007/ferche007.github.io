using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algoritmos_geneticos
{
    public class Poblacion
    {
        public Organismo[] poblacion = new Organismo[190];
        public Organismo[] cruzado = new Organismo[30];
        public void PrimeraGeneracion(Random R, Double[,] puntos)
        {
            for (int i = 0; i < 150; i++)
            {
                Organismo org = new Organismo();
                for (int a = 0; a < 20; a++)
                {
                    org.croma1[a] = R.Next(0, 2);
                    org.croma2[a] = R.Next(0, 2);
                    org.croma3[a] = R.Next(0, 2);
                }
                org.ConversionCromosoma();
                org.Adecuar(puntos);
                poblacion[i] = org;
            }
            Organismo nuevo = new Organismo();
            for (int i = 0; i < 40; i++)
                poblacion[150 + i] = nuevo;
            List<Organismo> copia = new List<Organismo>();
            for (int i = 0; i < 190; i++)
                copia.Add(poblacion[i]);
            poblacion = copia.OrderBy(x => x.adecuacion).ToArray();
        }
        public void Adecuacion(Double[,]puntos) 
            {
            for (int i = 0; i < 190; i++)
            {
                poblacion[i].a1 = poblacion[i].ConvDec(poblacion[i].croma1);
                poblacion[i].a2 = poblacion[i].ConvDec(poblacion[i].croma2);
                poblacion[i].a3 = poblacion[i].ConvDec(poblacion[i].croma3);
                poblacion[i].Adecuar(puntos);
            }
            List<Organismo> copia = new List<Organismo>();
            for (int i = 0; i < 190; i++)
                    copia.Add(poblacion[i]);
                poblacion = copia.OrderBy(x => x.adecuacion).ToArray();
            Console.WriteLine(poblacion[0].adecuacion);
        }
        public void SeleccionarCruzamiento(Random R)
        {
            bool[] seleccionados=new bool[150];
            for(int i=0;i<150;i++)
            seleccionados[i]=false;
            int indice=0;
            for(int i =0;i<12;)
            {
               indice = R.Next(0, 20);
               if (!seleccionados[indice])
               {
                seleccionados[indice] = true;
                cruzado[i]=poblacion[indice];
                i++;
               }
            }
            for(int i =0;i<5;)
            {
               indice = R.Next(20, 40);
               if (!seleccionados[indice])
               {
                seleccionados[indice] = true;
                cruzado[i+12]=poblacion[indice];
                i++;
               }
            }
                for(int i =0;i<3;)
            {
               indice = R.Next(40, 60);
               if (!seleccionados[indice])
               {
                seleccionados[indice] = true;
                cruzado[i+17]=poblacion[indice];
                i++;
               }
            }
            for (int i = 0; i < 4;)
            {
                indice = R.Next(60, 90);
                if (!seleccionados[indice])
                {
                    seleccionados[indice] = true;
                    cruzado[i + 20] = poblacion[indice];
                    i++;
                }
            }
            for (int i = 0; i < 3;)
            {
                indice = R.Next(90, 120);
                if (!seleccionados[indice])
                {
                    seleccionados[indice] = true;
                    cruzado[i + 24] = poblacion[indice];
                    i++;
                }
            }
            for (int i = 0; i < 3;)
            {
                indice = R.Next(120, 150);
                if (!seleccionados[indice])
                {
                    seleccionados[indice] = true;
                    cruzado[i + 27] = poblacion[indice];
                    i++;
                }
            }
        }
        public void Cruza(Random R)
        {
            bool[] asul=new bool[30]; 
            for(int i=0; i<30;i++)
            asul[i]=false; 
            for (int x = 0; x < 30;x=x+2) 
            {
                int corte=R.Next(1,20); 
                int m=R.Next(0, 30),n=R.Next(0,30);
                if(!asul[m])
                {                                                   
                    asul[m]=true;
                }
                else
                {
                    while (asul[m])
                    m=R.Next(0,30);               
                }
                if(!asul[n])
                {
                    asul[n]=true;
                }
                else
                {
                    while (asul[n])
                    n=R.Next(0,30);               
                }
                for (int i = 0; i < corte; i++)
                    poblacion[150 + x].croma1[i] = cruzado[m].croma1[i]; 
                for (int k=corte; k < 20; k++)
                    poblacion[150 + x].croma1[k] = cruzado[n].croma1[k]; 
                for(int i=0;i<corte;i++)
                    poblacion[151+x].croma1[i]=cruzado[n].croma1[i];
                for(int k=corte;k<20;k++)
                    poblacion[151+x].croma1[k]=cruzado[m].croma1[k];

                corte = R.Next(1, 20);
                for (int i = 0; i < corte; i++)
                    poblacion[150 + x].croma2[i] = cruzado[m].croma2[i]; 
                for (int k = corte; k < 20; k++)
                    poblacion[150 + x].croma2[k] = cruzado[n].croma2[k]; 
                for (int i = 0; i < corte; i++)
                    poblacion[151 + x].croma2[i] = cruzado[n].croma2[i];
                for (int k = corte; k < 20; k++)
                    poblacion[151 + x].croma2[k] = cruzado[m].croma2[k];

                corte = R.Next(1, 20);
                for (int i = 0; i < corte; i++)
                    poblacion[150 + x].croma3[i] = cruzado[m].croma3[i]; 
                for (int k = corte; k < 20; k++)
                    poblacion[150 + x].croma3[k] = cruzado[n].croma3[k]; 
                for (int i = 0; i < corte; i++)
                    poblacion[151 + x].croma3[i] = cruzado[n].croma3[i];
                for (int k = corte; k < 20; k++)
                    poblacion[151 + x].croma3[k] = cruzado[m].croma3[k];
            }
        }
        public void mutar(Random R)
        {
            int mutacion, casilla, elegir, random, random2;
            for (int i = 189; i >= 180; i--)
            {
                elegir = R.Next(1, 4); // cuantos cromosomas
                mutacion = R.Next(0, 150); // que organismos 
                casilla = R.Next(0, 20); // que cromosoma
                random = R.Next(0, 2); // 0 o 1

                if (elegir == 1)
                {
                    random2 = R.Next(1,4); // a1, a2 o a3
                    switch (random2)
                    {
                        case 1:
                            poblacion[i] = poblacion[mutacion];
                            poblacion[i].croma1[casilla] = random;
                            break;
                        case 2:
                            poblacion[i] = poblacion[mutacion];
                            poblacion[i].croma2[casilla] = random;
                            break;
                        case 3:
                            poblacion[i] = poblacion[mutacion];
                            poblacion[i].croma3[casilla] = random;
                            break;
                    }
                }
                if (elegir == 2)
                {
                    random2 = R.Next(1,4);
                    switch (random2)
                    {
                        case 1:
                            poblacion[i] = poblacion[mutacion];
                            poblacion[i].croma1[casilla] = random;
                            poblacion[i] = poblacion[mutacion];
                            poblacion[i].croma2[casilla] = random;
                            break;
                        case 2:
                            poblacion[i] = poblacion[mutacion];
                            poblacion[i].croma1[casilla] = random;
                            poblacion[i] = poblacion[mutacion];
                            poblacion[i].croma3[casilla] = random;
                            break;
                        case 3:
                            poblacion[i] = poblacion[mutacion];
                            poblacion[i].croma2[casilla] = random;
                            poblacion[i] = poblacion[mutacion];
                            poblacion[i].croma3[casilla] = random;
                            break;
                    }
                }
                if (elegir == 3)
                {
                    poblacion[i] = poblacion[mutacion];
                    poblacion[i].croma1[casilla] = random;
                    poblacion[i] = poblacion[mutacion];
                    poblacion[i].croma2[casilla] = random;
                    poblacion[i] = poblacion[mutacion];
                    poblacion[i].croma3[casilla] = random;
                }
            }
        }
    }
}
