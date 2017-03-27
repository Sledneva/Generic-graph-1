using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericGraph_2
{
    public class Graph<V, E>
    {

        public IList<V> vertexes;
        public E[,] edges;
        private List<int> visitedVertexes;

        public Graph()
        {
            vertexes = new List<V>();

        }
        public void NewVertex(V vertex)
        {
            vertexes.Add(vertex);
            if (edges == null)
            {
                edges = new E[1, 1];
            }
            else
                edges = TransformMatrix.ResizeMatrix(edges, edges.GetLength(0) + 1, edges.GetLength(1) + 1);
        }

        public void DeleteVertex(int index)
        {
            vertexes.RemoveAt(index);
            edges = TransformMatrix.ReduceMatrix(index, index, edges);
        }



        public int[] FindRelatedIndexes(int vertexIndex)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < edges.GetLength(0); i++)
                if (IsEdgeSet(i, vertexIndex) && i != vertexIndex)
                    result.Add(i);
            return result.ToArray();
        }

        public bool IsEdgeSet(int from, int to)
        {
            if (edges[from, to] != null)
                return !edges[from, to].Equals(default(E));
            return false;
        }

        public void NewEdge(int from, int to, E edge)
        {
            edges[from, to] = edge;
        }



        public void DeleteEdge(int from, int to)
        {
            edges[from, to] = default(E);
        }

        public override string ToString()
        {
            string result = "";
            result += "\nVertexes:\n";
            vertexes.ToList().ForEach(x => result += x.ToString() + " \n");
            result += "\nEdges:\n";
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                for (int k = 0; k < edges.GetLength(1); k++)
                    if (IsEdgeSet(i, k))
                        result += i + "---" + k + " : " + edges[i, k].ToString() + " \n";
            }
            return result;
        }

        public void PreDepth(int startInd, Action<V> act)
        {
            act(vertexes[startInd]);
            visitedVertexes = new List<int>();
            Depth(startInd, act);
        }
        private void Depth(int startInd, Action<V> act)
        {
            visitedVertexes.Add(startInd);
            foreach (int n in FindRelatedIndexes(startInd))
            {
                if (!visitedVertexes.Contains(n))
                {
                    act(vertexes[n]);
                    Depth(n, act);
                }
            }
        }

        public void Width(int startInd, Action<V> act)
        {
            act(vertexes[startInd]);
            visitedVertexes = new List<int>();
            visitedVertexes.Add(startInd);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(startInd);
            while (queue.Count != 0)
            {
                int temp = queue.Dequeue();
                foreach (int n in FindRelatedIndexes(temp))
                {
                    if (!visitedVertexes.Contains(n))
                    {
                        act(vertexes[n]);
                        visitedVertexes.Add(n);
                        queue.Enqueue(n);
                    }
                }
            }
        }

        public int ReturnId(V vertex)
        {
            int id = 0;
            foreach (V vert in vertexes)
            {
                if (vertex.Equals(vert))
                {
                    id = vertexes.IndexOf(vert);
                }
            }
            return id;
        }

        public V ReturnVert(int index)
        {
            return vertexes[index];
        }
    }
}