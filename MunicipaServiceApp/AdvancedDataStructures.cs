using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServiceApp
{
    // 1. BINARY SEARCH TREE
    public class BSTNode
    {
        public ServiceRequest Data;
        public BSTNode Left, Right;
        public BSTNode(ServiceRequest data) { Data = data; }
    }

    public class ServiceRequestBST
    {
        public BSTNode Root;

        public void Insert(ServiceRequest req)
        {
            Root = InsertRec(Root, req);
        }

        private BSTNode InsertRec(BSTNode root, ServiceRequest req)
        {
            if (root == null) return new BSTNode(req);
            int cmp = string.CompareOrdinal(req.ReferenceNumber, root.Data.ReferenceNumber);
            if (cmp < 0) root.Left = InsertRec(root.Left, req);
            else if (cmp > 0) root.Right = InsertRec(root.Right, req);
            return root;
        }

        public ServiceRequest Search(string refNumber)
        {
            return SearchRec(Root, refNumber);
        }

        private ServiceRequest SearchRec(BSTNode root, string refNumber)
        {
            if (root == null) return null;
            int cmp = string.CompareOrdinal(refNumber, root.Data.ReferenceNumber);
            if (cmp == 0) return root.Data;
            if (cmp < 0) return SearchRec(root.Left, refNumber);
            return SearchRec(root.Right, refNumber);
        }
    }

    // 2. AVL TREE
    public class AVLNode
    {
        public ServiceRequest Data;
        public AVLNode Left, Right;
        public int Height;
        public AVLNode(ServiceRequest data) { Data = data; Height = 1; }
    }

    public class AVLTree
    {
        public AVLNode Root;
        public void Insert(ServiceRequest req) { Root = InsertRec(Root, req); }

        private AVLNode InsertRec(AVLNode node, ServiceRequest req)
        {
            if (node == null) return new AVLNode(req);
            if (req.Id < node.Data.Id) node.Left = InsertRec(node.Left, req);
            else if (req.Id > node.Data.Id) node.Right = InsertRec(node.Right, req);
            else return node;

            node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));
            int balance = GetBalance(node);

            if (balance > 1 && req.Id < node.Left.Data.Id) return RightRotate(node);
            if (balance < -1 && req.Id > node.Right.Data.Id) return LeftRotate(node);
            if (balance > 1 && req.Id > node.Left.Data.Id)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }
            if (balance < -1 && req.Id < node.Right.Data.Id)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }
            return node;
        }

        private int Height(AVLNode N) { return N == null ? 0 : N.Height; }
        private int GetBalance(AVLNode N) { return N == null ? 0 : Height(N.Left) - Height(N.Right); }

        private AVLNode RightRotate(AVLNode y)
        {
            AVLNode x = y.Left;
            AVLNode T2 = x.Right;
            x.Right = y; y.Left = T2;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            return x;
        }

        private AVLNode LeftRotate(AVLNode x)
        {
            AVLNode y = x.Right;
            AVLNode T2 = y.Left;
            y.Left = x; x.Right = T2;
            x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
            return y;
        }

        public List<ServiceRequest> InOrder()
        {
            var list = new List<ServiceRequest>();
            InOrderRec(Root, list);
            return list;
        }
        private void InOrderRec(AVLNode root, List<ServiceRequest> list)
        {
            if (root != null)
            {
                InOrderRec(root.Left, list);
                list.Add(root.Data);
                InOrderRec(root.Right, list);
            }
        }
    }

    // 3. MIN HEAP
    public class MinHeap
    {
        private List<ServiceRequest> _heap = new List<ServiceRequest>();

        public void Insert(ServiceRequest req)
        {
            _heap.Add(req);
            int i = _heap.Count - 1;
            while (i > 0)
            {
                int parent = (i - 1) / 2;
                if (_heap[i].Priority < _heap[parent].Priority)
                {
                    var temp = _heap[i]; _heap[i] = _heap[parent]; _heap[parent] = temp;
                    i = parent;
                }
                else break;
            }
        }

        public List<ServiceRequest> GetHeapList() { return _heap.OrderBy(x => x.Priority).ToList(); }
    }

    // 4. GRAPH
    public class Edge
    {
        public string Target { get; set; }
        public int Weight { get; set; }
        public Edge(string target, int weight) { Target = target; Weight = weight; }
    }

    public class Graph
    {
        private Dictionary<string, List<Edge>> _adjacencyList = new Dictionary<string, List<Edge>>();

        public void AddEdge(string source, string destination, int weight)
        {
            if (!_adjacencyList.ContainsKey(source)) _adjacencyList[source] = new List<Edge>();
            if (!_adjacencyList.ContainsKey(destination)) _adjacencyList[destination] = new List<Edge>();
            _adjacencyList[source].Add(new Edge(destination, weight));
            _adjacencyList[destination].Add(new Edge(source, weight));
        }

        public List<string> BFS(string start)
        {
            var visited = new HashSet<string>();
            var queue = new Queue<string>();
            var result = new List<string>();
            if (!_adjacencyList.ContainsKey(start)) return result;

            visited.Add(start);
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                result.Add(current);
                foreach (var edge in _adjacencyList[current])
                {
                    if (!visited.Contains(edge.Target))
                    {
                        visited.Add(edge.Target);
                        queue.Enqueue(edge.Target);
                    }
                }
            }
            return result;
        }

        public List<string> GetMST()
        {
            var result = new List<string>();
            var edges = new List<Tuple<string, string, int>>();

            foreach (var kvp in _adjacencyList)
                foreach (var edge in kvp.Value)
                    edges.Add(new Tuple<string, string, int>(kvp.Key, edge.Target, edge.Weight));

            edges = edges.OrderBy(e => e.Item3).ToList();
            var parent = new Dictionary<string, string>();
            foreach (var node in _adjacencyList.Keys) parent[node] = node;

            string Find(string i)
            {
                if (parent[i] == i) return i;
                return Find(parent[i]);
            }

            void Union(string i, string j)
            {
                string rootI = Find(i);
                string rootJ = Find(j);
                if (rootI != rootJ) parent[rootI] = rootJ;
            }

            foreach (var edge in edges)
            {
                string rootSource = Find(edge.Item1);
                string rootTarget = Find(edge.Item2);
                if (rootSource != rootTarget)
                {
                    result.Add($"{edge.Item1} - {edge.Item2} (Weight: {edge.Item3})");
                    Union(edge.Item1, edge.Item2);
                }
            }
            return result;
        }
    }
}