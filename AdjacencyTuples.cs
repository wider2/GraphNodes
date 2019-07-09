using System;
using System.Collections.Generic;

namespace GraphNodes
{
    //adjacency matrix
    //Vertices exist by themselves and edges are stored in the form of a matrix.
    class AdjacencyTuples
    {
        private List<Tuple<int, int>> adjacencyList;

        // creates an empty Adjacency List in constructor
        public AdjacencyTuples()
        {
            adjacencyList = new List<Tuple<int, int>>();
        }

        public void addEdge(int startVertex, int endVertex)
        {
            adjacencyList.Add(new Tuple<int, int>(startVertex, endVertex));
        }

        public bool removeEdge(int startVertex, int endVertex)
        {
            Tuple<int, int> edge = new Tuple<int, int>(startVertex, endVertex);
            return adjacencyList.Remove(edge);
        }
        
        public List<Tuple<int, int>> getEdges()
        {
            return adjacencyList;
        }

        public bool isNextVertexFound(int startVertex)
        {
            bool found = false;
            foreach (var edge in adjacencyList)
            {
                if (edge.Item1 == startVertex)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

    }
}