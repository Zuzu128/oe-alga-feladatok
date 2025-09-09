using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OE.ALGA.Paradigmak
{
    public interface IVegrehajthato
    {
        void Vegrehajtas();
    }

    public class FeladatTarolo<T> where T : IVegrehajthato
    {
        T[] tarolo;
        int n;

        public FeladatTarolo(int meret)
        {
            tarolo = new T[meret];
        }

        public void Felvesz(T elem)
        {
            if (n < tarolo.Length)
            {
                tarolo[n] = elem;
                n++;
            }
            else
                throw new TaroloMegteltKivetel();
        }
    }

    public class TaroloMegteltKivetel : Exception
    {

    }
}
