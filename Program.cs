using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v2, v4);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v4, v5);
            graph.AddEdge(v5, v4);
            #endregion

            var matrix = graph.GetMatrix();
            PrintMatrix(graph, matrix);
            var t = graph.CheckWay(v5, v3);
            Console.ReadLine();
        }

        private static void PrintPath(List<Vertex> path)
        {
            foreach (var vertex in path)
            {
                Console.Write($"=> {vertex} ");
            }
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
