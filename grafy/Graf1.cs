using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr.domowaGrafy
{
    internal class Graf1
    {
        
        List<NoteG1> node = new List<NoteG1>();
        List<Edge> Edges = new List<Edge>();
        public Graf1(Edge k)
        {
            
            this.node.Add(k.start);
            this.node.Add(k.end);
            this.Edges.Add(k);

        }
        void Add(Edge k)
        {
            
            if(!this.node.Contains(k.start))
            {
                this.node.Add(k.start);
                this.node.Add(k.end);
                this.Edges.Add(k);

            }
            if (!this.node.Contains(k.end))
            {
                this.node.Add(k.end);
                this.Edges.Add(k);
            }



        }
        int IleNowychWezlow(Edge k)
        {
            int wynik = 0;
            if(!this.node.Contains(k.start))
            {
                wynik++;
            }
            if (!this.node.Contains(k.end))
            {
                wynik++;
            }
            return wynik;
        }
        void Join(Graf1 g1)
        {
            
            for(int i= 0; i < this.Edges.Count; i++)
            {
                this.Add(g1.Edges[i]);
            }
        }
        //List<Element>, Dict<NoteG1,T<int,NodeG1>>, Dict<NoteG1,Element>

         List<Element> AlgorytmDijkstry(NoteG1 start)
        {
            var tabelka = this.PrzygotujTabelke(start);
            var S = new List<NoteG1>();
            int i = 1;
            foreach (var e in this.Edges)
            {
                var kandydaci = tabelka.Where(e => !S.Contains(e.węzeł)).ToList();
                var kandydat = kandydaci.OrderBy(e => e.dystans).First();
                if (kandydat != null) {
                    tabelka[i].dystans += kandydat.dystans;
                    kandydat.poprzednik = tabelka[i].poprzednik;
                    i++;
                }
                else
                {
                    break;
                }

            }
            return tabelka;
        }
        // nie void
        List<Element> PrzygotujTabelke(NoteG1 start)
        {
            List<Element> S = new List<Element>();
            S[0].węzeł = start;
            S[0].dystans = 0;
            int i = 1;
            foreach (NoteG1 e in this.node) {
                S[i].węzeł = e;
                i++;
            }

            return S;
        }
       

    }
}
