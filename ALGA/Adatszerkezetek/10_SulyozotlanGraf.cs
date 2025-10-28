using System;

namespace OE.ALGA.Adatszerkezetek
{
    // 10. heti labor feladat - Tesztek: 10_SulyozatlanGrafTesztek.cs

    public class EgeszGrafEl : GrafEl<int>, IComparable
    {
        public int Honnan { get; }
        public int Hova { get; }

        public EgeszGrafEl(int honnan, int hova)
        {
            this.Honnan = honnan;
            this.Hova = hova;
        }

        public virtual int CompareTo(object? obj)
        {
            if (obj != null && obj is EgeszGrafEl b)
            {
                if (Honnan != b.Honnan)
                {
                    return Honnan.CompareTo(b.Honnan);
                }
                else
                {
                    return Hova.CompareTo(b.Hova);
                }
            }
            else
            {
                throw new InvalidOperationException();
            }
        }
    }

    public class CsucsmatrixSulyozatlanEgeszGraf : SulyozatlanGraf<int, EgeszGrafEl>
    {
        int n;
        bool[,] M;

        public CsucsmatrixSulyozatlanEgeszGraf(int n)
        {
            this.n = n;
            M = new bool[n, n];
        }

        public int CsucsokSzama
        {
            get
            {
                return n;
            }
        }

        public int ElekSzama
        {
            get
            {
                int count = 0;
                for(int i = 0; i <n; i++)
                {
                    for (int j = 0; j <n; j++)
                    {
                        if (M[i, j])
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
        }

        public Halmaz<int> Csucsok
        {
            get
            {
                Halmaz<int> csucsok = new FaHalmaz<int>();
                for (int cs = 0; cs < n; cs++)
                {
                    csucsok.Beszur(cs);
                }
                return csucsok;
            }
        }

        public Halmaz<EgeszGrafEl> Elek => throw new NotImplementedException();

        public Halmaz<int> Szomszedai(int csucs)
        {
            throw new NotImplementedException();
        }

        public void UjEl(int honnan, int hova)
        {
            M[honnan, hova] = true;
        }

        public bool VezetEl(int honnan, int hova)
        {
            throw new NotImplementedException();
        }
    }
}