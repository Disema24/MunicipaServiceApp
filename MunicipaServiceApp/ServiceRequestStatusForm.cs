using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServiceApp
{
    public class ServiceRequestStatusForm : Form
    {
        private ServiceRequestRepository _repo = new ServiceRequestRepository();

        private void InitializeComponent()
        {

        }

        public ServiceRequestStatusForm()
        {
            Text = "Service Request Status";
            Width = 1000;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(245, 247, 250);

            TabControl tabs = new TabControl();
            tabs.Dock = DockStyle.Fill;

            // TAB 1: Dashboard
            TabPage tab1 = new TabPage("Dashboard (AVL Tree)");
            tab1.BackColor = Color.White;
            ListBox lstAll = new ListBox();
            lstAll.Dock = DockStyle.Fill;
            lstAll.Font = new Font("Consolas", 11);
            foreach (var r in _repo.GetAllSorted())
            {
                lstAll.Items.Add(r.ToString());
            }
            tab1.Controls.Add(lstAll);

            // TAB 2: Track Request
            TabPage tab2 = new TabPage("Track Request (BST)");
            tab2.BackColor = Color.White;

            Panel pnlTrack = new Panel();
            pnlTrack.Dock = DockStyle.Top;
            pnlTrack.Height = 60;
            pnlTrack.Padding = new Padding(10);

            Label lbl = new Label();
            lbl.Text = "Enter Ref Number (e.g., SR-0002):";
            lbl.AutoSize = true;
            lbl.Location = new Point(10, 15);

            TextBox txtSearch = new TextBox();
            txtSearch.Location = new Point(220, 12);
            txtSearch.Width = 150;

            Button btnSearch = new Button();
            btnSearch.Text = "Search";
            btnSearch.Location = new Point(380, 10);
            btnSearch.BackColor = Color.FromArgb(30, 90, 160);
            btnSearch.ForeColor = Color.White;
            btnSearch.FlatStyle = FlatStyle.Flat;

            Label lblResult = new Label();
            lblResult.Dock = DockStyle.Fill;
            lblResult.Font = new Font("Segoe UI", 11);
            lblResult.Padding = new Padding(20);

            btnSearch.Click += (s, e) =>
            {
                var req = _repo.TrackRequest(txtSearch.Text);
                if (req != null)
                {
                    lblResult.Text = "FOUND:\n\nReference: " + req.ReferenceNumber +
                                     "\nStatus: " + req.Status +
                                     "\nCategory: " + req.Category +
                                     "\nPriority: " + req.Priority +
                                     "\nDescription: " + req.Description;
                }
                else
                {
                    lblResult.Text = "Request not found. Please check the reference number.";
                }
            };

            pnlTrack.Controls.Add(lbl);
            pnlTrack.Controls.Add(txtSearch);
            pnlTrack.Controls.Add(btnSearch);
            tab2.Controls.Add(lblResult);
            tab2.Controls.Add(pnlTrack);

            // TAB 3: Heaps & Graphs
            TabPage tab3 = new TabPage("Heaps & Graphs");
            tab3.BackColor = Color.White;

            SplitContainer split = new SplitContainer();
            split.Dock = DockStyle.Fill;
            split.Orientation = Orientation.Horizontal;

            ListBox lstUrgent = new ListBox();
            lstUrgent.Dock = DockStyle.Fill;
            lstUrgent.Font = new Font("Consolas", 10);
            foreach (var r in _repo.GetUrgentRequests())
            {
                lstUrgent.Items.Add("Priority " + r.Priority + " | " + r.ReferenceNumber + " | " + r.Description);
            }

            Panel pnlHeap = new Panel();
            pnlHeap.Dock = DockStyle.Fill;
            Label lblHeap = new Label();
            lblHeap.Text = "Priority Queue (Min-Heap) - Most Urgent First:";
            lblHeap.Dock = DockStyle.Top;
            lblHeap.Height = 25;
            lblHeap.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            pnlHeap.Controls.Add(lstUrgent);
            pnlHeap.Controls.Add(lblHeap);

            ListBox lstGraph = new ListBox();
            lstGraph.Dock = DockStyle.Fill;
            lstGraph.Font = new Font("Consolas", 10);

            lstGraph.Items.Add("--- BFS Traversal from 'Citizen' ---");
            foreach (var node in _repo.GetEscalationPath())
            {
                lstGraph.Items.Add("Visited: " + node);
            }

            lstGraph.Items.Add("\n--- Minimum Spanning Tree (Kruskal's) ---");
            foreach (var edge in _repo.GetMST())
            {
                lstGraph.Items.Add(edge);
            }

            Panel pnlGraph = new Panel();
            pnlGraph.Dock = DockStyle.Fill;
            Label lblGraph = new Label();
            lblGraph.Text = "Graph Traversal (BFS) & Minimum Spanning Tree (MST):";
            lblGraph.Dock = DockStyle.Top;
            lblGraph.Height = 25;
            lblGraph.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            pnlGraph.Controls.Add(lstGraph);
            pnlGraph.Controls.Add(lblGraph);

            split.Panel1.Controls.Add(pnlHeap);
            split.Panel2.Controls.Add(pnlGraph);
            tab3.Controls.Add(split);

            tabs.TabPages.Add(tab1);
            tabs.TabPages.Add(tab2);
            tabs.TabPages.Add(tab3);

            Controls.Add(tabs);
        }
    }
}