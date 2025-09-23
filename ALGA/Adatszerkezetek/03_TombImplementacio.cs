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
        public int Elemszam => throw new NotImplementedException();

        public void Bejar(Action<T> muvelet)
        {
            throw new NotImplementedException();
        }

        public void Beszur(int index, T ertek)
        {
            throw new NotImplementedException();
        }

        public void Hozzafuz(T ertek)
        {
            throw new NotImplementedException();
        }

        public T Kiolvas(int index)
        {
            throw new NotImplementedException();
        }

        public void Modosit(int index, T ertek)
        {
            throw new NotImplementedException();
        }

        public void Torol(T ertek)
        {
            throw new NotImplementedException();
        }
    }
}
