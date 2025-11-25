//using System;

//namespace OE.ALGA.Adatszerkezetek
//{
//    // 12. heti labor feladat - Tesztek: 12_SulyozottGrafTesztek.cs
//    public class SulyozottEgeszGrafEl : EgeszGrafEl, SulyozottGrafEl<int>
//    {
//        public float Suly { get; }

//        public SulyozottEgeszGrafEl(int honnan, int hova, float suly) : base(honnan, hova)
//        {
//            this.Suly = suly;
//        }
//    }

//    public class CsucsmatrixSulyozottEgeszGraf : SulyozottGraf<int, SulyozottEgeszGrafEl>
//    {
//        int n;
//        float[,] M;

//        public CsucsmatrixSulyozottEgeszGraf(int n)
//        {
//            this.n = n;
//            for (int i = 0; i < n; i++)
//            {
//                for (int j = 0; j < n; j++)
//                {
//                    M[i, j] = float.NaN;
//                }
//            }
//        }

//        public int CsucsokSzama => throw new NotImplementedException();

//        public int ElekSzama => throw new NotImplementedException();

//        public Halmaz<int> Csucsok => throw new NotImplementedException();

//        public Halmaz<SulyozottEgeszGrafEl> Elek => throw new NotImplementedException();

//        public float Suly(int honnan, int hova)
//        {
//            throw new NotImplementedException();
//        }

//        public Halmaz<int> Szomszedai(int csucs)
//        {
//            throw new NotImplementedException();
//        }

//        public void UjEl(int honnan, int hova, float suly)
//        {
//            M[honnan, hova] = suly;
//        }

//        public bool VezetEl(int honnan, int hova)
//        {
//            return !float.IsNaN(M[honnan, hova]);
//        }
//    }

//    public class Utkereses
//    {
//        public static Szotar<V, float> Dijkstra<V, E>(SulyozottGraf<V, E> g, V start)
//        {
//            Szotar<V, float> L = new HasitoSzotarTulcsordulasiTerulettel<V, float>(g.CsucsokSzama);
//            Szotar<V, V> P = new HasitoSzotarTulcsordulasiTerulettel<V, V>(g.CsucsokSzama);
//            KupacPrioritasosSor<V> S = new KupacPrioritasosSor<V>(g.CsucsokSzama, (ez, ennel) => L.Kiolvas(ez) < L.Kiolvas(ennel));

//            g.Csucsok.Bejar(x =>
//            {
//                L.Beir(x, float.MaxValue);
//                S.Sorba(x);
//            });
//            L.Beir(start, 0);
//            S.Frissit(start);
//        }
//    }

//    public class FeszitoFaKereses
//    {
//        public static Halmaz<E> Kruskal<V, E>(SulyozottGraf<V, E> g) where E : SulyozottGrafEl<V>, IComparable
//        {
//            Halmaz<E> A = new FaHalmaz<E>();
//            Szotar<V, int> vhalmaz = new HasitoSzotarTulcsordulasiTerulettel<V, int>(g.CsucsokSzama);
//            int i = 0;
//            g.Csucsok.Bejar(x => { vhalmaz.Beir(x, i++); });
//        }
//    }
//}
