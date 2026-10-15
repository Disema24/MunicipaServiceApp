using MunicipaServiceApp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServiceApp
{
    public class AddEventForm : Form
    {
        private EventManager eventManager;
        private Event createdEvent;

        private Panel panelHeader;
        private Label lblTitle;
        private Label label1, label2, label3, label4, label5, label6;
        private TextBox txtTitle, txtLocation;
        private ComboBox cmbCategory, cmbPriority;
        private DateTimePicker dtpDate;
        private RichTextBox rtbDescription;
        private Button btnSave, btnCancel;

        public Event CreatedEvent { get { return createdEvent; } }

        public AddEventForm(EventManager manager)
        {
            eventManager = manager;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.label4 = new Label();
            this.label5 = new Label();
            this.label6 = new Label();
            this.txtTitle = new TextBox();
            this.txtLocation = new TextBox();
            this.cmbCategory = new ComboBox();
            this.cmbPriority = new ComboBox();
            this.dtpDate = new DateTimePicker();
            this.rtbDescription = new RichTextBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(0, 102, 204);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Size = new Size(500, 60);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(20, 15);
            this.lblTitle.Text = "➕ Add New Event";

            // label1 - Title
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            this.label1.Location = new Point(30, 85);
            this.label1.Text = "Title:";

            // txtTitle
            this.txtTitle.Font = new Font("Segoe UI", 9.75F);
            this.txtTitle.Location = new Point(130, 82);
            this.txtTitle.Size = new Size(320, 25);

            // label2 - Category
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            this.label2.Location = new Point(30, 125);
            this.label2.Text = "Category:";

            // cmbCategory
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbCategory.Font = new Font("Segoe UI", 9.75F);
            this.cmbCategory.Location = new Point(130, 122);
            this.cmbCategory.Size = new Size(200, 25);

            // label3 - Date
            this.label3.AutoSize = true;
            this.label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            this.label3.Location = new Point(30, 165);
            this.label3.Text = "Event Date:";

            // dtpDate
            this.dtpDate.Font = new Font("Segoe UI", 9.75F);
            this.dtpDate.Format = DateTimePickerFormat.Long;
            this.dtpDate.Location = new Point(130, 162);
            this.dtpDate.Size = new Size(200, 25);

            // label4 - Location
            this.label4.AutoSize = true;
            this.label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            this.label4.Location = new Point(30, 205);
            this.label4.Text = "Location:";

            // txtLocation
            this.txtLocation.Font = new Font("Segoe UI", 9.75F);
            this.txtLocation.Location = new Point(130, 202);
            this.txtLocation.Size = new Size(320, 25);

            // label5 - Priority
            this.label5.AutoSize = true;
            this.label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            this.label5.Location = new Point(30, 245);
            this.label5.Text = "Priority:";

            // cmbPriority
            this.cmbPriority.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbPriority.Font = new Font("Segoe UI", 9.75F);
            this.cmbPriority.Location = new Point(130, 242);
            this.cmbPriority.Size = new Size(200, 25);
            this.cmbPriority.Items.AddRange(new object[] { "🔴 High", "🟡 Medium", "🟢 Low" });
            this.cmbPriority.SelectedIndex = 1;

            // label6 - Description
            this.label6.AutoSize = true;
            this.label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            this.label6.Location = new Point(30, 285);
            this.label6.Text = "Description:";

            // rtbDescription
            this.rtbDescription.Font = new Font("Segoe UI", 9.75F);
            this.rtbDescription.Location = new Point(130, 282);
            this.rtbDescription.Size = new Size(320, 90);

            // btnSave
            this.btnSave.BackColor = Color.FromArgb(40, 167, 69);
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(130, 390);
            this.btnSave.Size = new Size(150, 40);
            this.btnSave.Text = "💾 Save Event";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += btnSave_Click;

            // btnCancel
            this.btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(300, 390);
            this.btnCancel.Size = new Size(150, 40);
            this.btnCancel.Text = "❌ Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += btnCancel_Click;

            // AddEventForm
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.ClientSize = new Size(500, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtbDescription);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelHeader);
            this.Font = new Font("Segoe UI", 9.75F);
            this.Name = "AddEventForm";
            this.Text = "Add New Event";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a title for the event.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Please enter or select a category.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                MessageBox.Show("Please enter a location.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(rtbDescription.Text))
            {
                MessageBox.Show("Please provide a description.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbDescription.Focus();
                return;
            }

            // Get priority value
            int priority = 2;
            if (cmbPriority.SelectedIndex == 0) priority = 1;
            else if (cmbPriority.SelectedIndex == 2) priority = 3;

            // Create the event
            int newId = eventManager.GetNextEventId();
            createdEvent = new Event(newId, txtTitle.Text, cmbCategory.Text,
                dtpDate.Value.Date, txtLocation.Text, rtbDescription.Text, priority);

            eventManager.AddEvent(createdEvent);

            MessageBox.Show("✅ Event added successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}