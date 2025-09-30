using System;
using System.Collections;
using System.Collections.Generic;

namespace OE.ALGA.Adatszerkezetek
{
    // 4. heti labor feladat - Tesztek: 04_LancoltImplementacioTesztek.cs

    internal class LancElem<T>
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

        public LancoltSor()
        {
            fej = null;
            vege = null;
        }

        public bool Ures { get; }

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
}