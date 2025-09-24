using System;
using System.Collections;
using System.Collections.Generic;

namespace OE.ALGA.Adatszerkezetek
{
    // 3. heti labor feladat - Tesztek: 03_TombImplementacioTesztek.cs

    public class TombVerem<T> : Verem<T>
    {
        T[] E;
        int n = 0;

        public TombVerem(int meret)
        {
            E = new T[meret];
        }

        public bool Ures
        {
            get
            {
                return n == 0;
            }
        }

        public T Felso()
        {
            if (!Ures)
            {
                return E[n - 1];
            }
            else
            {
                throw new NincsElemKivetel();
            }
        }

        public void Verembe(T ertek)
        {
            if (n < E.Length)
            {
                E[n] = ertek;
                n++;
            }
            else
            {
                throw new NincsHelyKivetel();
            }
        }

        public T Verembol()
        {
            if (!Ures)
            {
                return E[--n];
            }
            else
            {
                throw new NincsElemKivetel();
            }
        }
    }

    public class TombSor<T> : Sor<T>
    {
        T[] E;
        int e = 0;
        int u = 0;
        int n = 0;

        public bool Ures
        {
            get
            {
                return n == 0;
            }
        }

        public TombSor(int meret)
        {
            E = new T[meret];
        }

        public T Elso()
        {
            if (!Ures)
            {
                return E[(e % E.Length) + 1];
            }
            else
            {
                throw new NincsElemKivetel();
            }
        }

        public void Sorba(T ertek)
        {
            if (n < E.Length)
            {
                n++;
                u = (u % E.Length) + 1;
                E[u] = ertek;
            }
            else
            {
                throw new NincsHelyKivetel();
            }
        }

        public T Sorbol()
        {
            if (!Ures)
            {
                n--;
                e = (e % E.Length) + 1;
                return E[e];
            }
            else
            {
                throw new NincsElemKivetel();
            }
        }
    }

    public class TombLista<T> : Lista<T>
    {
        T[] E;
        int n = 0;

        public TombLista(int meret)
        {
            E = new T[meret];
        }

        public int Elemszam { get { return E.Length; } }

        public void Bejar(Action<T> muvelet)
        {
            for (int i = 0; i < n; i++)
            {
                muvelet(E[i]);
            }
        }

        public void Beszur(int index, T ertek)
        {
            if (index <= n - 1)
            {
                if (n == E.Length)
                {
                    MeretNoveles();
                }
                n++;
                for (int i = n; i > index + 1; i--)
                {
                    E[i] = E[i - 1];
                }
                E[index] = ertek;
            }
            else
            {
                throw new HibasIndexKivetel();
            }
        }

        public void Hozzafuz(T ertek)
        {
            Beszur(n + 1, ertek);
        }

        public T Kiolvas(int index)
        {
            if (index <= n)
            {
                return E[index];
            }
            else
            {
                throw new HibasIndexKivetel();
            }
        }

        public void Modosit(int index, T ertek)
        {
            if (index <= n)
            {
                E[index] = ertek;
            }
            else
            {
                throw new HibasIndexKivetel();
            }
        }

        public void Torol(T ertek)
        {
            int db = 0;
            for (int i = 0;  i < n; i++)
            {
                if (E[i]!.Equals(ertek))
                {
                    db++;
                }
                else
                {
                    E[i - db] = E[i];
                }
            }
            n = n - db;
        }

        private void MeretNoveles()
        {
            T[] EMasolat = E;
            E = new T[EMasolat.Length * 2];
            for (int i = 0; i > n; i++)
            {
                E[i] = EMasolat[i];
            }
            Array.Clear(EMasolat);
        }
    }

    public class TombListaBejaro<T> : IEnumerator<T>
    {
        T[] E;
        int n;
        int aktualisIndex = -1;
        T current;
        public T Current => current;

        object IEnumerator.Current => Current;

        public TombListaBejaro(T[] E, int n)
        {
            this.E = E;
            this.n = n;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            while(++aktualisIndex < n)
            {
                current = E[aktualisIndex];
                return true;
            }
            return false;
        }

        public void Reset()
        {
            aktualisIndex = -1;
        }
    }
}
