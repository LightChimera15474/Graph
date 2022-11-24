using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Vertex
    {
        public int ID { get; set; }

        public Vertex(int id)
        {
            ID = id;
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
