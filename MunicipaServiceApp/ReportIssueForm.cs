using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MunicipalServiceApp
{
    public partial class ReportIssueForm : Form
    {
        private string? attachmentPath = null;

        public ReportIssueForm()
        {
            InitializeComponent();

            // Add categories to the dropdown
            cmbCategory.Items.AddRange(new string[] {
                "Sanitation",
                "Roads",
                "Utilities (Water/Electricity)",
                "Street Lighting",
                "Waste Management",
                "Other"
            });
            cmbCategory.SelectedIndex = -1;

            // Attach events to update the progress bar as user types
            txtLocation.TextChanged += UpdateProgressAndMessage;
            cmbCategory.SelectedIndexChanged += UpdateProgressAndMessage;
            rtbDescription.TextChanged += UpdateProgressAndMessage;

            // Update the message for the first time
            UpdateProgressAndMessage(null, null);
        }

        // Attach File Button
        private void btnAttach_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Document Files|*.pdf;*.doc;*.docx;*.txt|All Files|*.*";
                openFileDialog.Title = "Attach an image or document";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    attachmentPath = openFileDialog.FileName;
                    lblAttachment.Text = Path.GetFileName(attachmentPath);
                }
            }
        }

        // Submit Button
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter a location.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }
            if (cmbCategory.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a category.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please provide a description.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return;
            }

            // Safe null handling for category and attachment
            string category = cmbCategory.SelectedItem?.ToString() ?? "Other";
            string attachment = attachmentPath ?? "";

            // Create the issue
            int id = MainForm.GetNextId();
            Issue newIssue = new Issue(id, txtLocation.Text, category, rtbDescription.Text, attachment);
            MainForm.Issues.Add(newIssue);

            // Success message (Engagement feature)
            MessageBox.Show("✅ Thank you for reporting! Your issue has been logged.", "Submission Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblEncouragement.Text = "🎉 Great job! You're making a difference!";

            this.Close();
        }

        // Back Button
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // The Progress Bar and Encouragement Message updater
        private void UpdateProgressAndMessage(object? sender, EventArgs? e)
        {
            int progress = 0;
            if (!string.IsNullOrWhiteSpace(txtLocation.Text)) progress += 25;
            if (cmbCategory.SelectedIndex != -1) progress += 25;
            if (!string.IsNullOrWhiteSpace(rtbDescription.Text)) progress += 25;
            if (!string.IsNullOrEmpty(attachmentPath)) progress += 25;

            progressBar.Value = progress;

            string message = "";
            if (progress == 0) message = "Start by telling us where the issue is.";
            else if (progress <= 25) message = "Good! Now select a category.";
            else if (progress <= 50) message = "Almost there! Describe the issue in detail.";
            else if (progress <= 75) message = "Great! Attach a photo if you have one.";
            else if (progress < 100) message = "You're nearly done! Complete all fields.";
            else message = "🌟 Perfect! Ready to submit. Click 'Submit'.";

            lblEncouragement.Text = message;
        }

        private void ReportIssueForm_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}