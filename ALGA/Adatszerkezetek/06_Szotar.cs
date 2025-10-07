using System;

namespace OE.ALGA.Adatszerkezetek
{
    // 6. heti labor feladat - Tesztek: 06_SzotarTesztek.cs

    public class SzotarElem<K, T>
    {
        public K kulcs;
        public T tart;

        public SzotarElem(K kulcs, T tart)
        {
            this.kulcs = kulcs;
            this.tart = tart;
        }
    }

    public class HasitoSzotarTulcsordulasiTerulettel<K, T> : Szotar<K, T>
    {
        SzotarElem<K, T>[] E;
        Func<K, int> h;
        Lista<SzotarElem<K, T>> U = new LancoltLista<SzotarElem<K, T>>();

        public HasitoSzotarTulcsordulasiTerulettel(int meret, Func<K, int> hasitoFuggveny)
        {
            E = new SzotarElem<K, T>[meret];
            h = (x => Math.Abs(hasitoFuggveny(x)) % E.Length);
        }

        public HasitoSzotarTulcsordulasiTerulettel(int meret) : this(meret, x => x.GetHashCode())
        {
        }

        void KulcsKeres(K kulcs)
        {
            if (E[h(kulcs)] != null && E[h(kulcs)].kulcs = kulcs)
            {

            }
        }

        public void Beir(K kulcs, T ertek)
        {
            throw new NotImplementedException();
        }

        public T Kiolvas(K kulcs)
        {
            throw new NotImplementedException();
        }

        public void Torol(K kulcs)
        {
            throw new NotImplementedException();
        }
    }
}
