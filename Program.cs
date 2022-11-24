using System;
using System.Collections.Generic;

namespace Graph
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            #region инициализация вершин и ребер
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);
            var v6 = new Vertex(6);
            var v7 = new Vertex(7);


            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);
            graph.AddVertex(v7);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v1, v4);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v3);
            graph.AddEdge(v3, v5);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v4, v6);
            graph.AddEdge(v5, v6);
            graph.AddEdge(v5, v4);
            graph.AddEdge(v5, v7);
            graph.AddEdge(v6, v7);
            #endregion

            PrintMatrix(graph, graph.GetMatrix());

            Vertex[] tmp = new Vertex[] { v1, v2, v3, v4, v5, v6, v7};
            for (int i = 0; i < tmp.Length; i++)
            {
                for (int j = 0; j < tmp.Length; j++)
                {
                    Console.WriteLine();
                    var way = graph.Wave(tmp[i], tmp[j]);
                    Console.Write($"Путь из пункта {tmp[i]} в пункт {tmp[j]}: ");
                    Console.WriteLine(PrintPatch(way));
                    Console.WriteLine($"Стоимость проезда: {graph.WayCost}");
                }
            }

            Console.ReadLine();
        }

        
        private static string PrintPatch(List<Vertex> way)
        {
            if (way != null) 
            {
                var res = "";
                for (int i = 0; i < way.Count; i++)
                {
                    if(i != way.Count - 1)
                    {
                        res += way[i].ToString() + " => ";
                    }
                    else
                    {
                        res += way[i].ToString();
                    }
                }
                return res; 
            }
            return "Невозможно проложить путь.";
        }

        private static void PrintMatrix(Graph graph, double[,] matrix)
        {
            Console.Write("_|  ");
            for (int i = 1; i < graph.VertexCount + 1; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            Console.Write("   ");
            for (int i = 1; i < graph.VertexCount + 1; i++)
            {
                Console.Write("__");
            }
            Console.WriteLine();
            for (int i = 0; i < graph.VertexCount; i++)
            {
                Console.Write(i + 1 + "|  ");
                for (int j = 0; j < graph.VertexCount; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
