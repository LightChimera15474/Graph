using System;
namespace Graph
{
    class Edge
    {
        public Vertex From { get; set; }
        public Vertex To { get; set; }
        public double Weight { get; set; }

        public Edge(Vertex from, Vertex to, double weight = 1)
        {
            if (from is null)
            {
                throw new ArgumentNullException(nameof(from));
            }
            if (to is null)
            {
                throw new ArgumentNullException(nameof(to));
            }

            From = from;
            To = to;
            Weight = weight;
        }
    }
}
