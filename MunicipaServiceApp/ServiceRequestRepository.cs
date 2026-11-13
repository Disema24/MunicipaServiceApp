using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServiceApp
{
    public class ServiceRequestRepository
    {
        private ServiceRequestBST _bst = new ServiceRequestBST();
        private AVLTree _avl = new AVLTree();
        private MinHeap _priorityHeap = new MinHeap();
        private Graph _escalationGraph = new Graph();
        private SortedDictionary<string, ServiceRequest> _redBlackTree = new SortedDictionary<string, ServiceRequest>();

        private int _nextId = 1;

        public ServiceRequestRepository()
        {
            BuildEscalationGraph();
            SeedData();
        }

        private void BuildEscalationGraph()
        {
            _escalationGraph.AddEdge("Citizen", "CallCenter", 1);
            _escalationGraph.AddEdge("CallCenter", "WardCouncillor", 24);
            _escalationGraph.AddEdge("WardCouncillor", "LocalManager", 48);
            _escalationGraph.AddEdge("LocalManager", "CityDirector", 72);
            _escalationGraph.AddEdge("CallCenter", "Technician", 2);
            _escalationGraph.AddEdge("Technician", "LocalManager", 12);
        }

        public ServiceRequest Submit(string desc, string loc, RequestCategory cat, int priority)
        {
            var req = new ServiceRequest
            {
                Id = _nextId++,
                ReferenceNumber = $"SR-{reqIdFormatted()}",
                Description = desc,
                Location = loc,
                Category = cat,
                Priority = priority
            };

            _bst.Insert(req);
            _avl.Insert(req);
            _priorityHeap.Insert(req);
            _redBlackTree.Add(req.ReferenceNumber, req);

            return req;
        }

        private string reqIdFormatted()
        {
            return (_nextId - 1).ToString("D4");
        }

        public ServiceRequest TrackRequest(string refNum)
        {
            return _bst.Search(refNum.Trim().ToUpper());
        }

        public List<ServiceRequest> GetAllSorted() { return _avl.InOrder(); }
        public List<ServiceRequest> GetUrgentRequests() { return _priorityHeap.GetHeapList(); }
        public List<string> GetEscalationPath() { return _escalationGraph.BFS("Citizen"); }
        public List<string> GetMST() { return _escalationGraph.GetMST(); }

        private void SeedData()
        {
            Submit("Burst pipe flooding street", "12 Oak St", RequestCategory.Water, 9);
            Submit("Streetlight out", "45 Acacia Rd", RequestCategory.Electricity, 4);
            Submit("Pothole damaging cars", "Main Rd", RequestCategory.Roads, 7);
            Submit("Refuse not collected", "7 Sunbird Cl", RequestCategory.Refuse, 6);
            Submit("Sewage leak", "88 Protea Ave", RequestCategory.Sanitation, 10);
            Submit("Traffic light faulty", "Highway Intersection", RequestCategory.Roads, 8);
        }
    }
}