using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph
{
    class Graph
    {
        private List<Vertex> V = new List<Vertex>();
        private List<Edge> E = new List<Edge>();
        private List<Vertex> way = new List<Vertex>();
        public double WayCost { get; set; } = 0;
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
            if (!E.Contains(edge))
            {
                E.Add(edge);
            }
        }

        /// <summary>
        /// Добавляет существующее ребро в список ребер.
        /// </summary>
        /// <param name="edge">Ребро</param>
        public void AddEdge(Edge edge)
        {
            if (!E.Contains(edge))
            {
                E.Add(edge);
            }
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
        private List<Vertex> GetVertexList(Vertex vertex)
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
        /// Создает список ребер, смежных с указанной вершиной.
        /// </summary>
        /// <param name="vertex">Вершина</param>
        /// <returns>Список смежных ребер</returns>
        private List<Edge> GetEdgesList(Vertex vertex)
        {
            var res = new List<Edge>();
            foreach (var edge in E)
            {
                if (edge.To == vertex && edge.From.Level == vertex.Level - 1 && way.Contains(edge.From)) 
                { 
                    if (!res.Contains(edge))
                    {
                        res.Add(edge);
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// Создает список со всеми вершинами, которые могут встречаться на пути от начала до конца.
        /// </summary>
        /// <param name="start">Начальная вершина</param>
        /// <param name="finish">Конечная вершина</param>
        /// <returns>Возвращает список всех вершин на пути к финишу.</returns>
        private List<Vertex> GetWayList(Vertex start, Vertex finish)
        {
            start.Level = 0;
            way.Add(start);

            for (int i = 0; i < way.Count; i++)
            {
                var vertex = way[i];
                foreach (var v in GetVertexList(vertex))
                {
                    if (!way.Contains(v))
                    {
                        v.Level = vertex.Level + 1;
                        way.Add(v);
                    }
                }
                if(way.Contains(finish)) break;
            }
            return way;
        }

        /// <summary>
        /// Находит маршрут между двумя вершинами. (Волновой алгоритм)
        /// </summary>
        /// <param name="start">Начальная вершина</param>
        /// <param name="finish">Конечная вершина</param>
        /// <returns>Если путь из start в finish существует, то возвращает список, состоящий из вершин пути, иначе возвращает null</returns>
        public List<Vertex> Wave(Vertex start, Vertex finish)
        {
            var resultWay = new List<Vertex>() { finish };
            WayCost = 0;
            way.Clear();
            way = GetWayList(start, finish);
            if (way.Contains(finish))
            { 
                var vertex = finish;

                while(vertex != start)
                {
                    var bestEdge = GetEdgesList(vertex).OrderBy(edge => edge.Weight).ElementAt(0);
                    vertex = bestEdge.From;
                    resultWay.Add(vertex);
                    WayCost += bestEdge.Weight;
                }

                resultWay.Reverse();
                return resultWay;
            }
            return null;
        }
    }
}
