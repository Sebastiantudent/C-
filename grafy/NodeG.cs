using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pr.domowaGrafy
{
    internal class NodeG
    {
        public List<NodeG> sasiedzi=new List<NodeG>();
        public int data;
        public bool odwiedzony;
        public NodeG(int liczba)
        {
            
            this.data = liczba;
            this.odwiedzony = false;
        }
        public override string ToString()
        {
            return this.data.ToString();
        }
        public void polacz(NodeG drugi)
        {
            this.sasiedzi.Add(drugi);

            drugi.sasiedzi.Add(this);
        }
    }
}
