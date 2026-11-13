namespace MunicipalServiceApp
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnReportIssues = new Button();
            btnEvents = new Button();
            btnServiceRequest = new Button();
            SuspendLayout();
            // 
            // btnReportIssues
            // 
            btnReportIssues.Location = new Point(10, 109);
            btnReportIssues.Name = "btnReportIssues";
            btnReportIssues.Size = new Size(94, 31);
            btnReportIssues.TabIndex = 0;
            btnReportIssues.Text = "Report Issues";
            btnReportIssues.UseVisualStyleBackColor = true;
            btnReportIssues.Click += btnReportIssues_Click;
            // 
            // btnEvents
            // 
            btnEvents.BackColor = Color.FromArgb(0, 102, 204);
            btnEvents.FlatAppearance.BorderSize = 0;
            btnEvents.FlatStyle = FlatStyle.Flat;
            btnEvents.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEvents.ForeColor = Color.White;
            btnEvents.Location = new Point(9, 158);
            btnEvents.Name = "btnEvents";
            btnEvents.Size = new Size(259, 34);
            btnEvents.TabIndex = 1;
            btnEvents.Text = "📅 Events & Announcements";
            btnEvents.UseVisualStyleBackColor = false;
            btnEvents.Click += btnEvents_Click;
            // 
            // btnServiceRequest
            // 
            btnServiceRequest.Location = new Point(12, 146);
            btnServiceRequest.Name = "btnServiceRequest";
            btnServiceRequest.Size = new Size(75, 23);
            btnServiceRequest.TabIndex = 2;
            btnServiceRequest.Text = "Service Request Satus";
            btnServiceRequest.UseVisualStyleBackColor = true;
            btnServiceRequest.Click += button1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(280, 225);
            Controls.Add(btnServiceRequest);
            Controls.Add(btnEvents);
            Controls.Add(btnReportIssues);
            Name = "MainForm";
            Text = "Municipal Services";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnReportIssues;
        private System.Windows.Forms.Button btnEvents;
        private Button btnServiceRequest;
    }
}