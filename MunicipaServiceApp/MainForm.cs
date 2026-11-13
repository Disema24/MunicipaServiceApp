using MunicipalServiceApp;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MunicipalServiceApp
{
    public partial class MainForm : Form
    {
        // Static list to store all issues
        public static List<Issue> Issues = new List<Issue>();
        private static int nextId = 1;

        public MainForm()
        {
            InitializeComponent();

            // 🔥 THIS LINE CONNECTS THE BUTTON TO THE CODE AUTOMATICALLY 🔥
            this.btnServiceRequest.Click += new EventHandler(this.btnServiceRequest_Click);
        }

        // This runs when you click the "Report Issues" button
        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssueForm reportForm = new ReportIssueForm();
            reportForm.ShowDialog();
        }

        // This runs when you click the "Events" button
        private void btnEvents_Click(object sender, EventArgs e)
        {
            EventsForm eventsForm = new EventsForm();
            eventsForm.ShowDialog();
        }

        // This runs when you click the "Service Request Status" button (Part 3)
        private void btnServiceRequest_Click(object sender, EventArgs e)
        {
            // Added a MessageBox so you can see the button click is working!
            MessageBox.Show("Button clicked");

            ServiceRequestStatusForm statusForm = new ServiceRequestStatusForm();
            statusForm.ShowDialog();
        }

        // Helper to get the next ID number
        public static int GetNextId()
        {
            return nextId++;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        // Satisfies the designer file to prevent errors
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}