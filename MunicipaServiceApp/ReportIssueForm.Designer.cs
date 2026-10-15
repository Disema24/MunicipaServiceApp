namespace MunicipalServiceApp
{
    partial class ReportIssueForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtLocation = new TextBox();
            cmbCategory = new ComboBox();
            rtbDescription = new RichTextBox();
            btnAttach = new Button();
            lblAttachment = new Label();
            btnSubmit = new Button();
            btnBack = new Button();
            progressBar = new ProgressBar();
            lblEncouragement = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(120, 38);
            txtLocation.Margin = new Padding(3, 4, 3, 4);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(250, 27);
            txtLocation.TabIndex = 0;
            // 
            // cmbCategory
            // 
            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Location = new Point(120, 88);
            cmbCategory.Margin = new Padding(3, 4, 3, 4);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(250, 28);
            cmbCategory.TabIndex = 1;
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(120, 138);
            rtbDescription.Margin = new Padding(3, 4, 3, 4);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(250, 99);
            rtbDescription.TabIndex = 2;
            rtbDescription.Text = "";
            // 
            // btnAttach
            // 
            btnAttach.Location = new Point(120, 250);
            btnAttach.Margin = new Padding(3, 4, 3, 4);
            btnAttach.Name = "btnAttach";
            btnAttach.Size = new Size(100, 38);
            btnAttach.TabIndex = 3;
            btnAttach.Text = "Attach File";
            btnAttach.UseVisualStyleBackColor = true;
            btnAttach.Click += btnAttach_Click;
            // 
            // lblAttachment
            // 
            lblAttachment.AutoSize = true;
            lblAttachment.Location = new Point(230, 259);
            lblAttachment.Name = "lblAttachment";
            lblAttachment.Size = new Size(116, 20);
            lblAttachment.TabIndex = 4;
            lblAttachment.Text = "No file attached";
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.LightGreen;
            btnSubmit.Location = new Point(120, 350);
            btnSubmit.Margin = new Padding(3, 4, 3, 4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(120, 44);
            btnSubmit.TabIndex = 5;
            btnSubmit.Text = "Submit Report";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(260, 350);
            btnBack.Margin = new Padding(3, 4, 3, 4);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(110, 44);
            btnBack.TabIndex = 6;
            btnBack.Text = "Back to Menu";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(120, 300);
            progressBar.Margin = new Padding(3, 4, 3, 4);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(250, 25);
            progressBar.TabIndex = 7;
            // 
            // lblEncouragement
            // 
            lblEncouragement.AutoSize = true;
            lblEncouragement.Font = new Font("Arial", 10F, FontStyle.Italic);
            lblEncouragement.Location = new Point(120, 331);
            lblEncouragement.Name = "lblEncouragement";
            lblEncouragement.Size = new Size(237, 16);
            lblEncouragement.TabIndex = 8;
            lblEncouragement.Text = "Start by telling us where the issue is.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 41);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 9;
            label1.Text = "Location:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 91);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 10;
            label2.Text = "Category:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 141);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 11;
            label3.Text = "Description:";
            label3.Click += label3_Click;
            // 
            // ReportIssueForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 438);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblEncouragement);
            Controls.Add(progressBar);
            Controls.Add(btnBack);
            Controls.Add(btnSubmit);
            Controls.Add(lblAttachment);
            Controls.Add(btnAttach);
            Controls.Add(rtbDescription);
            Controls.Add(cmbCategory);
            Controls.Add(txtLocation);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReportIssueForm";
            Text = "Report an Issue";
            Load += ReportIssueForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Button btnAttach;
        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblEncouragement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}