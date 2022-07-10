namespace Graph
{
    public static class ExampleGraph
    {
        public static Graph<Graph.NodeData> ExampleGraph7(
            int width, int height,
            int goalX, int goalY)
        {
            var graph = new Graph<Graph.NodeData>();
            Graph<Graph.NodeData>.Node[,] nodes = new Graph<Graph.NodeData>.Node[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    nodes[i, j] = new Graph<Graph.NodeData>.Node(graph, $"Node[{i}, {j}]");
                    nodes[i, j].data = new NodeData();
                }
            //  -1-1 -1.0 -1+1
            //  .0-1 .0.0 .0+1
            //  +1-1 +1.0 +1+1
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    graph.Connect(nodes[i, j],
                        nodes[i - 1, j - 1], nodes[i - 1, j - 0], nodes[i - 1, j + 1],
                        nodes[i - 0, j - 1], /*                */ nodes[i - 0, j + 1],
                        nodes[i + 1, j - 1], nodes[i + 1, j - 0], nodes[i + 1, j + 1]);
                }
            }
            for (int i = 1; i < width - 1; i++)
            {
                // nodes[i, height-1], node[i, 0]
                graph.Connect(nodes[i, 0],
                nodes[i - 1, 0], nodes[i - 1, 0 + 1],
                /*            */ nodes[i - 0, 0 + 1],
                nodes[i + 1, 0], nodes[i + 1, 0 + 1]);

                graph.Connect(nodes[i, height - 1],
                nodes[i - 1, height - 1 - 1], nodes[i - 1, height - 1 - 0],
                nodes[i - 0, height - 1 - 1], /*                */
                nodes[i + 1, height - 1 - 1], nodes[i + 1, height - 1 - 0]);
            }
            for (int j = 1; j < height - 1; j++)
            {
                //nodes[0, j], nodes[width-1, j]
                graph.Connect(nodes[0, j],
                nodes[0 + 0, j - 1], /*                */ nodes[0 + 0, j + 1],
                nodes[0 + 1, j - 1], nodes[0 + 1, j - 0], nodes[0 + 1, j + 1]);

                graph.Connect(nodes[width - 1, j],
                nodes[width - 1 - 1, j - 1], nodes[width - 1 - 1, j - 0], nodes[width - 1 - 1, j + 1],
                nodes[width - 1 - 0, j - 1], /*                       */ nodes[width - 1 - 0, j + 1]);
            }

            graph.Connect(nodes[0, 0],
            /*                */ nodes[0 - 0, 0 + 1],
            nodes[0 + 1, 0 - 0], nodes[0 + 1, 0 + 1]);

            graph.Connect(nodes[width - 1, 0],
            nodes[width - 1 - 1, 0 - 0], nodes[width - 1 - 1, 0 + 1],
            /*                        */ nodes[width - 1 - 0, 0 + 1]);

            graph.Connect(nodes[0, height - 1],
            nodes[0 - 0, height - 1 - 1], /*                */
            nodes[0 + 1, height - 1 - 1], nodes[0 + 1, height - 1 - 0]);

            graph.Connect(nodes[width - 1, height - 1],
            nodes[width - 1 - 1, height - 1 - 1], nodes[width - 1 - 1, height - 1 - 0],
            nodes[width - 1 - 0, height - 1 - 1] /*                                 */);

            SetSourceAndGoal(graph);

            return graph;

            void SetSourceAndGoal(
                Graph.Graph<Graph.NodeData> graph)
            {
                for (int i = 0; i < width; i++)
                    for (int j = 0; j < height; j++)
                    {
                        var currentNode = nodes[i, j];
                        if (currentNode.data == null) continue;
                        currentNode.data.stepDist = ChebyshevDistance(goalX, goalY, i, j);
                    }
            }
            static int ChebyshevDistance(int x1, int y1, int x2, int y2) =>
                (int)MathF.Max(Math.Abs(x1 - x2), Math.Abs(y1 - y2));


        }
        public static Graph<int> ExampleGraph6()
        {
            GraphData graphData = new GraphData(8,
            0, 0, 0, 0, 0, 0, 0, 0, // 1
            1, 0, 0, 0, 0, 0, 0, 0, // 2
            9, 0, 0, 0, 0, 0, 0, 0, // 3
            0, 5, 0, 0, 0, 0, 0, 0, // 4
            0, 5, 0, 0, 0, 0, 0, 0, // 5
            0, 0, 0, 5, 0, 0, 0, 0, // 6
            0, 0, 0, 5, 0, 0, 0, 0, // 7
            0, 0, 1, 0, 0, 0, 5, 0);// 8
            return new Graph<int>(graphData);
        }
        public static Graph<int> ExampleGraph5()
        {
            GraphData graphData = new GraphData(5,
            0, 0, 0, 0, 0,
            1, 0, 0, 0, 0,
            0, 1, 0, 0, 0,
            0, 4, 1, 0, 0,
            0, 4, 0, 1, 0);
            return new Graph<int>(graphData);
        }
        public static Graph<int> ExampleGraph4()
        {
            Graph<int> graph = new Graph<int>();
            Graph<int>.Node S = graph.CreateNode("S");
            Graph<int>.Node A = graph.CreateNode("A");
            Graph<int>.Node B = graph.CreateNode("B");
            Graph<int>.Node C = graph.CreateNode("C");
            Graph<int>.Node D = graph.CreateNode("D");
            Graph<int>.Node E = graph.CreateNode("E");
            Graph<int>.Node G = graph.CreateNode("G");
            graph.Connect(S, A, 3);
            graph.Connect(S, B, 5);
            graph.Connect(A, B, 4); // 2->4
            graph.Connect(A, D, 3);
            graph.Connect(B, C, 4);
            graph.Connect(D, G, 5);
            graph.Connect(C, E, 6);
            return graph;
        }
        public static Graph<int[]>? ExampleGraph3()
        {
            Graph<int[]> graph = new Graph<int[]>();
            Graph<int[]>.Node[]? nodes = graph.CreateNodeMulti(5);
            if (nodes == null) return null;
            graph.Connect(nodes[0], nodes[1], nodes[2]);
            graph.Connect(nodes[1], nodes[3]);
            return graph;
        }
        public static Graph<int>? ExampleGraph2()
        {
            Graph<int> graph = new Graph<int>();
            Graph<int>.Node[]? nodes = graph.CreateNodeMulti(5);
            if (nodes == null) return null;
            graph.Connect(nodes[0], nodes[1], nodes[2]);
            graph.Connect(nodes[1], nodes[3]);
            graph.DeleteNode(nodes[1]);
            return graph;
        }
        public static Graph<int> ExampleGraph1()
        {
            Graph<int> graph = new Graph<int>();
            Graph<int>.Node A = graph.CreateNode("A");
            Graph<int>.Node B = graph.CreateNode("B");
            Graph<int>.Node C = graph.CreateNode("C");
            Graph<int>.Node D = graph.CreateNode("D");
            Graph<int>.Node E = graph.CreateNode("E");
            graph.Connect(A, B, C);
            graph.Connect(B, D);
            graph.DeleteNode(B);
            return graph;
        }

    }
}