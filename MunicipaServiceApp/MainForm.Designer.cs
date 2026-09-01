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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(320, 225);
            Controls.Add(btnReportIssues);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "Municipal Services";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        private System.Windows.Forms.Button btnReportIssues;
    }
}