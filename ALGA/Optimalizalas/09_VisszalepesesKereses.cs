//using System;

//namespace OE.ALGA.Optimalizalas
//{
//    // 9. heti labor feladat - Tesztek: 09VisszalepesesKeresesTesztek.cs

//    public class VisszalepesesOptimalizacio<T>
//    {
//        protected int n;
//        protected int[] M;
//        protected T[,] R;

//        protected Func<int, T, bool> ft;
//        protected Func<int, T, T[], bool> fk;
//        protected Func<T[], float> josag;

//        public int LepesSzam { get; protected set; }

//        private T[] O;

//        public VisszalepesesOptimalizacio(int n, int[] m, T[,] r, Func<int, T, bool> ft, Func<int, T, T[], bool> fk, Func<T[], float> josag)
//        {
//            this.n = n;
//            M = m;
//            R = r;
//            this.ft = ft;
//            this.fk = fk;
//            this.josag = josag;
//            this.O = new T[n];
//        }

//        public T[] OptimalisMegoldas()
//        {
//            LepesSzam = 0;
//            bool van = false;
//            T[] E = new T[n];

//            BackTrack(0, ref E, ref van, ref O);

//            if (van)
//            {
//                T[] result = new T[n];
//                Array.Copy(O, result, n);
//                return result;
//            }
//            else
//            {
//                throw new Exception("Nincs megoldása");
//            }
//        }

//        protected virtual void BackTrack(int szint, ref T[] E, ref bool van, ref T[] O)
//        {
//            int i = -1;

//            while (!van && i < M[szint] - 1)
//            {
//                LepesSzam++;
//                i++;

//                T kandidat = R[szint, i];

//                if (!ft(szint, kandidat))
//                {
//                    continue;
//                }

//                if (!fk(szint, kandidat, E))
//                {
//                    continue;
//                }

//                E[szint] = kandidat;

//                if (szint == n - 1)
//                {
//                    if (!van || josag(E) > josag(O))
//                    {
//                        Array.Copy(E, O, E.Length);
//                    }
//                    van = true;
//                }
//                else
//                {
//                    BackTrack(szint + 1, ref E, ref van, ref O);
//                }
//            }
//        }
//    }

//    public class VisszalepesesHatizsakPakolas
//    {
//        protected HatizsakProblema problema;

//        public int LepesSzam { get; protected set; }

//        public VisszalepesesHatizsakPakolas(HatizsakProblema problema)
//        {
//            this.problema = problema;
//        }

//        public virtual bool[] OptimalisMegoldas()
//        {
//            int n = problema.m;
//            int[] M = new int[n];
//            bool[,] R = new bool[n, 2];

//            for (int i = 0; i < n; i++)
//            {
//                M[i] = 2;
//                R[i, 0] = false;
//                R[i, 1] = true;
//            }

//            Func<int, bool, bool> ft = (szint, valasztas) => true;

//            Func<int, bool, bool[], bool> fk = (szint, valasztas, E) =>
//            {
//                int suly = 0;
//                for (int j = 0; j < szint; j++)
//                {
//                    if (E[j])
//                    {
//                        suly += problema.w[j];
//                    }
//                }
//                if (valasztas)
//                {
//                    suly += problema.w[szint];
//                }
//                return suly <= problema.Wmax;
//            };

//            Func<bool[], float> josag = (E) =>
//            {
//                float ossz = 0;
//                for (int i = 0; i < n; i++)
//                {
//                    if (E[i])
//                    {
//                        ossz += problema.p[i];
//                    }
//                }
//                return ossz;
//            };

//            var opt = new VisszalepesesOptimalizacio<bool>(n, M, R, ft, fk, josag);
//            bool[] eredmeny = opt.OptimalisMegoldas();
//            LepesSzam = opt.LepesSzam;

//            return eredmeny;
//        }

//        public float OptimalisErtek()
//        {
//            bool[] megoldas = OptimalisMegoldas();
//            float ossz = 0;

//            for (int i = 0; i < megoldas.Length; i++)
//            {
//                if (megoldas[i])
//                {
//                    ossz += problema.p[i];
//                }
//            }
//            return ossz;
//        }
//    }

//    public class SzetvalasztasEsKorlatozasOptimalizacio<T> : VisszalepesesOptimalizacio<T>
//    {
//        Func<int, T[], float> fb;

//        public SzetvalasztasEsKorlatozasOptimalizacio(int n, int[] m, T[,] r, Func<int, T, bool> ft, Func<int, T, T[], bool> fk, Func<T[], float> josag, Func<int, T[], float> fb) : base(n, m, r, ft, fk, josag)
//        {
//            this.fb = fb;
//        }

//        protected override void BackTrack(int szint, ref T[] E, ref bool van, ref T[] O)
//        {
//            for (int i = 0; i < M[szint]; i++)
//            {
//                LepesSzam++;
//                T kandidat = R[szint, i];

//                if (!ft(szint, kandidat))
//                {
//                    continue;
//                }

//                if (!fk(szint, kandidat, E))
//                {
//                    continue;
//                }

//                E[szint] = kandidat;
//                float becsultertek = josag(E) + fb(szint, E);
//                bool tovabb = !(van && becsultertek <= josag(O));

//                if (van && becsultertek <= josag(O))
//                {
//                    continue;
//                }

//                if (szint == n - 1)
//                {
//                    if (!van || josag(E) > josag(O))
//                    {
//                        Array.Copy(E, O, n);
//                    }
//                    van = true;
//                }
//                else
//                {
//                    BackTrack(szint + 1, ref E, ref van, ref O);
//                }
//            }
//        }
//    }

//    public class SzetvalasztasEsKorlatozasHatizsakPakolas : VisszalepesesHatizsakPakolas
//    {

//        public SzetvalasztasEsKorlatozasHatizsakPakolas(HatizsakProblema problema) : base(problema)
//        {
//        }

//        public override bool[] OptimalisMegoldas()
//        {
//            int n = problema.m;
//            int[] M = new int[n];
//            bool[,] R = new bool[n, 2];

//            for (int i = 0; i < n; i++)
//            {
//                M[i] = 2;
//                R[i, 0] = false;
//                R[i, 1] = true;
//            }

//            Func<int, bool, bool> ft = (szint, valasztas) => true;

//            Func<int, bool, bool[], bool> fk = (szint, valasztas, E) =>
//            {
//                int suly = 0;
//                for (int j = 0; j < szint; j++)
//                {
//                    if (E[j])
//                    {
//                        suly += problema.w[j];
//                    }
//                }
//                if (valasztas)
//                {
//                    suly += problema.w[szint];
//                }
//                return suly <= problema.Wmax;
//            };

//            Func<bool[], float> josag = (E) =>
//            {
//                float ossz = 0;
//                for (int i = 0; i < n; i++)
//                    if (E[i]) ossz += problema.p[i];
//                return ossz;
//            };

//            Func<int, bool[], float> fb = (szint, E) =>
//            {
//                int suly = 0;

//                for (int i = 0; i <= szint; i++)
//                {
//                    if (E[i])
//                    {
//                        suly += problema.w[i];
//                    }
//                }

//                int fennMarado = problema.Wmax - suly;
//                float ossz = 0;

//                for (int i = szint + 1; i < n; i++)
//                {
//                    if (problema.w[i] <= fennMarado)
//                    {
//                        ossz += problema.p[i];
//                        fennMarado -= problema.w[i];
//                    }
//                }
//                return ossz;
//            };

//            var opt = new SzetvalasztasEsKorlatozasOptimalizacio<bool>(n, M, R, ft, fk, josag, fb);
//            bool[] eredmeny = opt.OptimalisMegoldas();
//            LepesSzam = opt.LepesSzam;

//            return eredmeny;
//        }
//    }
//}
