public class Program
{
    private static int width = 8, height = 6;
    private static int goalX = 3, goalY = 3;
    public static void Main(string[] args)
    {
        HandleInput(args);

        Graph.Graph<float> graph = Graph.ExampleGraph.ExampleGraph7(width, height, goalX, goalY);
        // graph.PrintGraph();
        PrintGraph(graph, width, height);
    }

    private static void PrintGraph(Graph.Graph<float> graph, int width, int height)
    {
        int gap = 8;
        char[,] screenBuffer = new char[width * gap - gap / 2, height * gap - gap / 2];
        var nodes = graph.GetNodes();

        for (int i = 0; i < screenBuffer.GetLength(0); i++)
        {
            for (int j = 0; j < screenBuffer.GetLength(1); j++)
            {
                screenBuffer[i, j] = ' ';
            }
        }

        for (int i = 0; i < screenBuffer.GetLength(0); i += gap)
        {
            for (int j = 0; j < screenBuffer.GetLength(1); j += gap)
            {
                int x = i / gap, y = j / gap;
                int index = x * height + y;
                float data = graph.GetNodes()[index].data;
                string numStr = ToString(data, gap / 2);
                for (int j2 = 0; j2 < gap / 2; j2++)
                    screenBuffer[i, j + j2] = numStr[j2];
            }
        }

        for (int i = 0; i < screenBuffer.GetLength(0); i++)
        {
            for (int j = 0; j < screenBuffer.GetLength(1); j++)
            {
                System.Console.Write(screenBuffer[i, j]);
            }
            System.Console.Write('\n');
        }
    }

    static string ToString(float value, int precision)
    {
        string output = value.ToString();
        int index;
        if (output.Length > precision)
            index = precision;
        else
            index = output.Length;

        output = output.Substring(0, index);
        return output.PadRight(precision, '_');
    } //  most significant digit


    static void HandleInput(string[] args)
    {
        if (args.Length < 4)
            Exit("invalid input");
        width = ToString(args[0]);
        height = ToString(args[1]);
        goalX = ToString(args[2]);
        goalY = ToString(args[3]);
        if (width < 0 || height < 0 || goalX < 0 || goalY < 0
            || goalX > width - 1 || goalY > height - 1)
            Exit("invalid input");
    }
    static int ToString(string str)
    {
        int output;
        bool success = System.Int32.TryParse(str, out output);
        if (success)
            return output;
        else
            return -1;
    }
    public static void Exit(string msg)
    {
        System.Console.WriteLine(msg);
        System.Console.WriteLine("press any key to exit...");
        System.Console.ReadKey();
        System.Environment.Exit(0);
    }
}
