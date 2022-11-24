using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
    class Graph
    {
        private List<Vertex> V = new List<Vertex>();
        private List<Edge> E = new List<Edge>();
        public int VertexCount => V.Count;

        /// <summary>
        /// Добовляет новую вершину в список вершин.
        /// </summary>
        /// <param name="vertex">вершина</param>
        public void AddVertex(Vertex vertex)
        {
            if (vertex is null)
            {
                throw new ArgumentNullException(nameof(vertex));
            }
            if (!V.Contains(vertex))
            {
                V.Add(vertex);
            }
        }

        /// <summary>
        /// Создает и добавляет новое ребро из вершины 1 в вершину 2 с указаным весом.
        /// </summary>
        /// <param name="from">Вершина 1 (откуда)</param>
        /// <param name="to">Вершина 2 (куда)</param>
        /// <param name="weight">Вес ребра (по умолчанию 1)</param>
        public void AddEdge(Vertex from, Vertex to, double weight = 1)
        {
            var edge = new Edge(from, to, weight);
            E.Add(edge);
        }

        /// <summary>
        /// Создает таблицу смежности вершин с указанием весов.
        /// </summary>
        /// <returns>Двумерная матрица смежности с весами типа double.</returns>
        public double[,] GetMatrix()
        {
            var res = new double[V.Count, V.Count];
            foreach (var edge in E)
            {
                res[edge.From.ID - 1, edge.To.ID - 1] = edge.Weight;
            }
            return res;
        }

        /// <summary>
        /// Создает список смежности для указаной вершины.
        /// </summary>
        /// <param name="vertex">Вершина</param>
        /// <returns>Список смежных вершин.</returns>
        public List<Vertex> GetVertexList(Vertex vertex)
        {
            var res = new List<Vertex>();
            foreach (var edge in E)
            {
                if (edge.From == vertex)
                {
                    res.Add(edge.To);
                }
            }
            return res;
        }

        /// <summary>
        /// Проверяет, есть ли путь между указаными вершинами.
        /// </summary>
        /// <param name="start">Начальная вершина</param>
        /// <param name="finish">Конечная вершина</param>
        /// <returns>Значение true, если путь существует и значение false, если его нет.</returns>
        public bool CheckWay(Vertex start, Vertex finish)
        { 
            var res = new List<Vertex>();
            res.Add(start);

            for (int i = 0; i < res.Count; i++)
            {
                var vertex = res[i];
                foreach (var v in GetVertexList(vertex))
                {
                    if (!res.Contains(v))
                    {
                        res.Add(v);
                    }
                }
            }
            return res.Contains(finish);
        }

    }
}
