using System;

namespace OE.ALGA.Optimalizalas
{
    // 7. heti labor feladat - Tesztek: 07_NyersEroTesztek.cs

    public class NyersEro<T>
    {
        int m;
        Func<int, T> generator;
        Func<T, float> josag;

        public int LepesSzam { get;private set; }

        public NyersEro(int m, Func<int, T> generator, Func<T, float> josag)
        {
            this.m = m;
            this.generator = generator;
            this.josag = josag;
        }

        public T OptimalisMegoldas()
        {
            T o = generator(1);
            for (int i = 2; i <= m; i++)
            {
                T x = generator(i);
                LepesSzam++;
                if (josag(x) > josag(o))
                {
                    o = x;
                }
            }
            return o;
        }
    }

    public class HatizsakProblema<T>
    {
        public int m;
        public int Wmax;
        public int[] w;
        public double[] p;

        public HatizsakProblema(int m, int wmax, int[] w, double[] p)
        {
            this.m = m;
            Wmax = wmax;
            this.w = w;
            this.p = p;
        }

        public double OsszErtek(bool[] pakolas)
        {
            double s = 0;
            int n = pakolas.Length;

            for (int i = 1;  i < n; i++)
            {
                if (pakolas[i])
                {
                    s += p[i];    
                }
            }

            return s;
        }

        public int OsszSuly(bool[] pakolas)
        {
            int s = 0;
            int n = pakolas.Length;

            for (int i = 1; i < n; i++)
            {
                if (pakolas[i])
                {
                    s += w[i];
                }
            }

            return s;
        }

        public bool Ervenyes(bool[] pakolas)
        {
            int n = pakolas.Length;
            int s = OsszSuly(pakolas);
            double e = OsszErtek(pakolas);

            if (s <= e)
            {
                return true;
            }

            return false;
        }
    }
}
