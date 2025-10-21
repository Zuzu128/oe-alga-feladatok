//using System;

//namespace OE.ALGA.Optimalizalas
//{
//    // 8. heti labor feladat - Tesztek: 08_DinamikusProgramozasTesztek.cs

//    public class DinamikusHatizsakPakolas
//    {
//        HatizsakProblema problema;
//        public int LepesSzam { get; private set; }

//        public DinamikusHatizsakPakolas(HatizsakProblema problema)
//        {
//            this.problema = problema;
//        }

//        private int[,] TablazatFeltoltes()
//        {
//            int n = problema.m;
//            int Wmax = problema.Wmax;
//            int[,] F = new int[n+1, Wmax + 1];
//            LepesSzam = 0;

//            for (int t = 0;  t <= n; t++)
//            {
//                F[t, 0] = 0;
//                LepesSzam++;
//            }

//            for (int h = 0; h <= Wmax; h++)
//            {
//                F[0, h] = 0;
//                LepesSzam++;
//            }

//            for ( int t = 1;  t <= n; t++)
//            {
//                for (int h = 1; h <= Wmax; h++)
//                {
//                    LepesSzam++;

//                    if (h >= problema.w[t - 1])
//                    {
//                        F[t, h] = (int)Math.Max(F[t, h - 1], F[t - 1, h - problema.w[t - 1]] + problema.p[t - 1]);
//                    }

//                    else
//                    {
//                        F[t, h] = F[t - 1, h];
//                    }
//                }
//            }
//            return F;
//        }
//    }
//}
