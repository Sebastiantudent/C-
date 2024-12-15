using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr.domowaGrafy
{
    internal class Graf
    {
        
        public List<NodeG> nodes = new List<NodeG>();

        public List<NodeG> Wszerz(NodeG start)
        {
            List<NodeG> odwiedzone = new List<NodeG>() { start };
            for (int i = 0; i < odwiedzone.Count; i++)
            {
                var tmp = odwiedzone[i];
                for (int j = 0; j < tmp.sasiedzi.Count; j++)
                {
                    if (!odwiedzone.Contains(tmp.sasiedzi[j]))
                        odwiedzone.Add(tmp.sasiedzi[j]);
                }
            }
            return odwiedzone;
        }
        public void wGlab(NodeG start,List<NodeG> odwiedzone)
        {
            
            if(start == null|| start.odwiedzony)
            {
                return;
            }

            start.odwiedzony = true;
            odwiedzone.Add(start);
            foreach (NodeG sasiad in start.sasiedzi)
            {
                if(!sasiad.odwiedzony)
                    wGlab(sasiad,odwiedzone);
            }
            
            
        }
        
    }
}
