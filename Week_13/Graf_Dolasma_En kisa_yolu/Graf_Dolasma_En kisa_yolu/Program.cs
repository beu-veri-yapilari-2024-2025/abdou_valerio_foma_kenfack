using System.Linq;

public class Graph
{
    private Dictionary<char, List<(char, int)>> adjacentList;

    public Graph()
    {
        adjacentList = new Dictionary<char, List<(char, int)>>();
    }
    // Not eklemek için yardımcı bir fonksiyon
    private void AddNode(char c)
    {
        if (!adjacentList.ContainsKey(c))
        {
            adjacentList.Add(c, new List<(char, int)>());
            Console.WriteLine($"{c} Başarılı eklendi");
        }

    }
    // Düğümleri ve aralarındaki ağırlığı ekleme
    public void AddVerticeEdge(char from, char to, int weight)
    {
        AddNode(from);
        AddNode(to);

        // Yönlendirilmemiş bir grafik olduğu için her iki yöne de ağırlık ekliyoruz.
        adjacentList[from].Add((to, weight));
        adjacentList[to].Add((from, weight));
    }
    public void BFS(char start)
    {
        HashSet<char> visited = new HashSet<char>();
        Queue<char> queue = new Queue<char>();

        visited.Add(start);
        queue.Enqueue(start);

        while (queue.Count > 0)
        {
            char c = queue.Dequeue();
            Console.Write($"{c} ");

            foreach (var list in adjacentList[c])
            {
                if (!visited.Contains(list.Item1))
                {
                    queue.Enqueue(list.Item1);
                    visited.Add(list.Item1);
                }
            }
        }

    }
    public void DFS(char start)
    {
        HashSet<char> visited = new HashSet<char>();
        recursiveDFS(start, visited);
    }
    private void recursiveDFS(char node, HashSet<char> visited)
    {
        visited.Add(node);
        Console.Write($"{node} ");

        foreach (var list in adjacentList[node])
        {
            if (!visited.Contains(list.Item1))
            {
                recursiveDFS(list.Item1, visited);
            }
        }
    }
    public void Dijkstra(char start, char target)
    {
        // Mesafe tablosu: başlangıç ​​noktasından bilinen en kısa mesafe
        Dictionary<char, int> dist = new Dictionary<char, int>();

        // Öncelik sırası: (düğüm, mesafe)
        PriorityQueue<char, int> pq = new PriorityQueue<char, int>();

        // Mesafeleri başlat
        foreach (var node in adjacentList.Keys)
        {
            dist[node] = int.MaxValue;
        }

        // Başlangıç ​​noktasından kendisine olan uzaklık 0'dır.
        dist[start] = 0;
        pq.Enqueue(start, 0);

        // İşlem düğümleri
        while (pq.Count > 0)
        {
            char u = pq.Dequeue();
            if (u == target)
                break;

            foreach (var edge in adjacentList[u])
            {
                char v = edge.Item1;
                int w = edge.Item2;

                // Rahatlama adımı
                if (dist[u] != int.MaxValue && dist[u] + w < dist[v])
                {
                    dist[v] = dist[u] + w;
                    pq.Enqueue(v, dist[v]);
                }
            }
        }

        // Mesafeleri yazdır
        Console.WriteLine("Dijkstra en kısa yolu (" + start + "--->" + target + ")");
        foreach (var item in dist)
        {
            Console.WriteLine($"{start} -> {item.Key} = {item.Value}");
        }
    }

}
public class Program
{
    static void Main()
    {
        Graph graph = new Graph();
        graph.AddVerticeEdge('A', 'B', 4);
        graph.AddVerticeEdge('A', 'C', 2);
        graph.AddVerticeEdge('B', 'D', 5);
        graph.AddVerticeEdge('C', 'B', 1);
        graph.AddVerticeEdge('C', 'E', 7);
        graph.AddVerticeEdge('D', 'F', 3);
        graph.AddVerticeEdge('E', 'F', 2);
        graph.AddVerticeEdge('B', 'E', 6);

        Console.Write("BFS : ");
        graph.BFS('A');
        Console.Write("\nDFS : ");
        graph.DFS('A');
        Console.Write("\nDijkstra en kısa yolu");
        graph.Dijkstra('A', 'F');
    }
}