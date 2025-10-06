using System;
using System.Collections;
using System.Collections.Generic;

namespace OE.ALGA.Adatszerkezetek
{
    // 4. heti labor feladat - Tesztek: 04_LancoltImplementacioTesztek.cs

    public class LancElem<T>
    {
        public T tart;
        public LancElem<T>? kov;

        public LancElem(T tart, LancElem<T>? kov )
        {
            this.tart = tart;
            this.kov = kov;
        }
    }

    public class LancoltVerem<T> : Verem<T>
    {
        LancElem<T>? fej;

        public LancoltVerem()
        {
            fej = null;
        }
        public bool Ures
        {
            get
            {
                return fej == null;
            }
        }

        public T Felso()
        {
            if ( fej != null )
            {
                return fej.tart;
            }
            else
            {
                throw new NincsElemKivetel();
            }
        }

        public void Verembe(T ertek)
        {
            LancElem<T> uj = new LancElem<T>(ertek, fej);
            fej = uj;
        }

        public T Verembol()
        {
            if (fej != null)
            {
                T ertek = fej.tart;
                fej = fej.kov;
                return ertek;
            }
            else
            {
                throw new NincsElemKivetel();
            }
        }
    }

    public class LancoltSor<T> : Sor<T>
    {
        LancElem<T>? fej;
        LancElem<T>? vege;
        int n = 0;

        public LancoltSor()
        {
            fej = null;
            vege = null;
        }

        public bool Ures
        {
            get
            {
                return fej == null;
            }
        }

        public void Felszabadit()
        {
            while ( fej != null )
            {
                LancElem<T>? q = fej;
                fej = fej.kov;
                q = null;
            }
            vege = null;
        }

        public T Elso()
        {
            if (fej != null)
            {
                return fej.tart;
            }
            else
            {
                throw new NincsElemKivetel();
            }
        }

        public void Sorba(T ertek)
        {
            LancElem<T> uj = new LancElem<T>(ertek, null);
            if (vege != null)
            {
                vege.kov = uj;
            }
            else
            {
                fej = uj;
            }
            vege = uj;
        }

        public T Sorbol()
        {
            if (fej != null)
            {
                T ertek = fej.tart;
                LancElem<T>? q = fej;
                fej = fej.kov;
                if (fej != null)
                {
                    vege = null;
                }
                q = null;
                return ertek;
            }
            else
            {
                throw new NincsElemKivetel();
            }

        }
    }

    public class LancoltLista<T> : Lista<T>, IEnumerable<T>
    {
        LancElem<T>? fej;
        int n = 0;
        public int Elemszam { get { return n; } }

        public LancoltLista()
        {
            fej = null;
        }

        public void Felszabadit()
        {
            while (fej != null)
            {
                LancElem<T>? p = fej;
                fej = fej.kov;
                p = null;
            }
            n = 0;
        }

        public void Bejar(Action<T> muvelet)
        {
            LancElem<T>? p = fej;
            while (p != null)
            {
                muvelet(p.tart);
                p = p.kov;
            }
        }

        public void Beszur(int index, T ertek)
        {
            if (index < 0 || index > n)
            {
                throw new HibasIndexKivetel();
            }
            if (index == 0)
            {
                LancElem<T> uj = new LancElem<T>(ertek, fej);
                fej = uj;
            }
            else
            {
                LancElem<T>? p = fej;
                for (int i = 0; i < index - 1; i++)
                {
                    p = p.kov!;
                }
                LancElem<T> uj = new LancElem<T> (ertek, p.kov);
                p.kov = uj;
            }
            n++;
        }

        public void Hozzafuz(T ertek)
        {
            LancElem<T> uj = new LancElem<T>(ertek, null);
            if (fej == null)
            {
                fej = uj;
            }
            else
            {
                LancElem<T>? p = fej;
                while (p.kov != null)
                {
                    p = p.kov;
                }
                p.kov = uj;
            }
            n++;
        }

        public T Kiolvas(int index)
        {
            if (index < 0 || index >= n)
            {
                throw new HibasIndexKivetel();
            }
            LancElem<T>? p = fej;
            int i = 0;
            while (p != null && i < index)
            {
                p = p.kov;
                i++;
            }
            if (p != null)
            {
                return p.tart;
            }
            else
            {
                throw new HibasIndexKivetel();
            }
        }

        public void Modosit(int index, T ertek)
        {
            if (index < 0 || index >= n)
            {
                throw new HibasIndexKivetel();
            }
            LancElem<T>? p = fej;
            int i = 0;
            while (p != null && i < index)
            {
                p = p.kov;
                i++;
            }
            if (p != null)
            {
                p.tart = ertek;
            }
            else
            {
                throw new HibasIndexKivetel();
            }
        }

        public void Torol(T ertek)
        {
            LancElem<T>? p = fej;
            LancElem<T>? e = null;
            do
            {
                while (p != null && !p.tart.Equals(ertek))
                {
                    e = p;
                    p = p.kov;
                }
                if (p != null)
                {
                    LancElem<T>? q = p.kov;
                    if (e == null)
                    {
                        fej = q;
                    }
                    else
                    {
                        e.kov = q;
                    }
                    n--;
                    p = null;
                    p = q;
                }
            }
            while (p != null);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new LancoltListaBejaro<T>(fej);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class LancoltListaBejaro<T> : IEnumerator<T>
    {
        LancElem<T>? fej;
        LancElem<T>? aktualisElem;

        public T Current { get { return aktualisElem.tart; } }

        object IEnumerator.Current => Current;

        public LancoltListaBejaro(LancElem<T>? fej)
        {
            this.fej = fej;
            //aktualisElem = null;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (aktualisElem == null)
            {
                aktualisElem = fej;
            }
            else
            {
                aktualisElem = aktualisElem.kov;
            }
            return aktualisElem != null;
        }

        public void Reset()
        {
            aktualisElem = fej;
        }
    }
}