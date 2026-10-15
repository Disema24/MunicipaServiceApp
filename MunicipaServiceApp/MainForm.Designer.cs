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
            SuspendLayout();
            // 
            // btnReportIssues
            // 
            btnReportIssues.Location = new Point(12, 145);
            btnReportIssues.Margin = new Padding(3, 4, 3, 4);
            btnReportIssues.Name = "btnReportIssues";
            btnReportIssues.Size = new Size(108, 41);
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
            btnEvents.Location = new Point(12, 200);
            btnEvents.Margin = new Padding(3, 4, 3, 4);
            btnEvents.Name = "btnEvents";
            btnEvents.Size = new Size(296, 45);
            btnEvents.TabIndex = 1;
            btnEvents.Text = "📅 Events & Announcements";
            btnEvents.UseVisualStyleBackColor = false;
            btnEvents.Click += btnEvents_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(320, 300);
            Controls.Add(btnEvents);
            Controls.Add(btnReportIssues);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Municipal Services";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnReportIssues;
        private System.Windows.Forms.Button btnEvents;
    }
}