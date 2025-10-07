using System;

namespace OE.ALGA.Adatszerkezetek
{
    // 5. heti labor feladat - Tesztek: 05_BinarisKeresoFaTesztek.cs

    public class FaElem<T> where T : IComparable
    {
        public T tart;
        public FaElem<T>? bal;
        public FaElem<T>? jobb;

        public FaElem(T tart, FaElem<T>? bal, FaElem<T>? jobb)
        {
            this.tart = tart;
            this.bal = bal;
            this.jobb = jobb;
        }
    }

    public class FaHalmaz<T> : Halmaz<T> where T : IComparable
    {
        FaElem<T>? gyoker;

        void ReszfaBejarasPreorder(FaElem<T>? p, Action<T> muvelet)
        {
            if (p != null)
            {
                muvelet(p.tart);
                ReszfaBejarasPreorder(p.bal, muvelet);
                ReszfaBejarasPreorder(p.jobb, muvelet);
            }
        }

        void ReszfaBejarasInorder(FaElem<T>? p, Action<T> muvelet)
        {
            if (p != null)
            {
                ReszfaBejarasInorder(p.bal, muvelet);
                muvelet(p.tart);
                ReszfaBejarasInorder(p.jobb, muvelet);
            }
        }

        void ReszfaBejarasPostorder(FaElem<T>? p, Action<T> muvelet)
        {
            if (p != null)
            {
                ReszfaBejarasPostorder(p.bal, muvelet);
                ReszfaBejarasPostorder(p.jobb, muvelet);
                muvelet(p.tart);
            }
        }

        public void Bejar(Action<T> muvelet)
        {
            ReszfaBejarasPreorder(gyoker, muvelet);
        }

        FaElem<T> ReszfabaBeszur(FaElem<T>? p, T ertek)
        {
            if (p == null)
            {
                FaElem<T> uj = new FaElem<T>(ertek, null, null);
                return uj;
            }
            else
            {
                if (p.tart.CompareTo(ertek) > 0)
                {
                    p.bal = ReszfabaBeszur(p.bal, ertek);
                }
                else
                {
                    if (p.tart.CompareTo(ertek) < 0)
                    {
                        p.jobb = ReszfabaBeszur(p.jobb, ertek);
                    }
                }
                return p;
            }
        }

        public void Beszur(T ertek)
        {
            gyoker = ReszfabaBeszur(gyoker, ertek);
        }

        public bool Eleme(T ertek)
        {
            throw new NotImplementedException();
        }

        public void Torol(T ertek)
        {
            throw new NotImplementedException();
        }
    }
}
