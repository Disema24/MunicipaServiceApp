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
        }

        // This runs when you click the "Report Issues" button
        private void btnReportIssues_Click(object sender, EventArgs e)
        {
            ReportIssueForm reportForm = new ReportIssueForm();
            reportForm.ShowDialog();
        }

        // Helper to get the next ID number
        public static int GetNextId()
        {
            return nextId++;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}