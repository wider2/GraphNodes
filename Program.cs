using System;
using System.Collections.Generic;

namespace GraphNodes
{
    class Program
    {
        private static int startVertex;
        private static int endVertex;
        private static int countEdge;
        private static List<Tuple<int, int>> passedList;

        private static int pathNumber = 0;
        private static Dictionary<int, List<int>> pathResultList;

        static void Main(string[] args)
        {
            pathResultList = new Dictionary<int, List<int>>();

            AdjacencyTuples adjacencyTuples = new AdjacencyTuples();

            adjacencyTuples.addEdge(1, 2);
            adjacencyTuples.addEdge(2, 4);
            adjacencyTuples.addEdge(1, 3);
            adjacencyTuples.addEdge(4, 5);
            adjacencyTuples.addEdge(3, 4);
            adjacencyTuples.addEdge(4, 6);

            passedList = new List<Tuple<int, int>>();
            List<Tuple<int, int>> edgesList = adjacencyTuples.getEdges();


            foreach (var line in edgesList)
            {
                if (!isEdgePassed(line.Item1, line.Item2))
                {
                    pathNumber += 1;

                    startVertex = line.Item1;
                    endVertex = line.Item2;
                    setPassedEdge(startVertex, endVertex);
                    List<int> pathList = new List<int>();
                    pathList.Add(startVertex);
                    pathList.Add(endVertex);

                    countEdge = 0;
                    do
                    {
                        startVertex = endVertex;
                        foreach (var edge in edgesList)
                        {
                            if (!isEdgePassed(edge.Item1, edge.Item2))
                            {
                                if (edge.Item1 == startVertex)
                                {
                                    endVertex = edge.Item2;
                                    setPassedEdge(startVertex, endVertex);
                                    pathList.Add(endVertex);
                                    break;
                                }
                            }
                        }
                        countEdge++;
                    } while (countEdge <= edgesList.Count);

                    pathResultList[pathNumber] = new List<int>();
                    pathResultList[pathNumber].AddRange(pathList);
                }
            }


            //show results
            foreach (var item in pathResultList)
            {
                Console.Write("\nPath " + item.Key + ": ");

                var destination = item.Value.ToArray();
                for (int i = 0; i < destination.Length; i++)
                {
                    if (i > 0) Console.Write(",");
                    Console.Write(destination[i]);
                }
            }

            Console.Write("\nPress enter to quit.");
            Console.ReadLine();
        }

        static void setPassedEdge(int startVertex, int endVertex)
        {
            passedList.Add(new Tuple<int, int>(startVertex, endVertex));
        }

        static bool isEdgePassed(int startVertex, int endVertex)
        {
            bool result = false;
            foreach (var edge in passedList)
            {
                if (edge.Item1 == startVertex && edge.Item2 == endVertex)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

    }
}
