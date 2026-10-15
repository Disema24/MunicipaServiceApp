using MunicipaServiceApp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MunicipalServiceApp
{
    public class EventsForm : Form
    {
        private EventManager eventManager;

        // Controls
        private Panel panelHeader;
        private Label lblTitle;
        private Label label1;
        private Label label2;
        private ComboBox cmbCategory;
        private DateTimePicker dtpDate;
        private CheckBox chkUseDate;
        private Button btnSearch;
        private Button btnClear;
        private ListBox lstEvents;
        private Button btnAddEvent;
        private Label lblRecommendations;
        private ListBox lstRecommendations;
        private Label lblSearchHistory;
        private ListBox lstSearchHistory;
        private Button btnBack;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;

        public EventsForm()
        {
            InitializeComponent();
            eventManager = new EventManager();
            this.Load += EventsForm_Load;
        }

        private void InitializeComponent()
        {
            this.panelHeader = new Panel();
            this.lblTitle = new Label();
            this.label1 = new Label();
            this.label2 = new Label();
            this.cmbCategory = new ComboBox();
            this.dtpDate = new DateTimePicker();
            this.chkUseDate = new CheckBox();
            this.btnSearch = new Button();
            this.btnClear = new Button();
            this.lstEvents = new ListBox();
            this.lblRecommendations = new Label();
            this.lstRecommendations = new ListBox();
            this.lblSearchHistory = new Label();
            this.lstSearchHistory = new ListBox();
            this.btnBack = new Button();
            this.panelHeader.SuspendLayout();
            this.SuspendLayout();

            // panelHeader
            this.panelHeader.BackColor = Color.FromArgb(0, 102, 204);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new Point(0, 0);
            this.panelHeader.Size = new Size(900, 65);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new Point(25, 16);
            this.lblTitle.Text = "📅 Local Events & Announcements";

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            this.label1.Location = new Point(25, 90);
            this.label1.Text = "Filter by Category:";

            // cmbCategory
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new Font("Segoe UI", 9.75F);
            this.cmbCategory.Location = new Point(145, 87);
            this.cmbCategory.Size = new Size(180, 25);

            // label2
            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            this.label2.Location = new Point(350, 90);
            this.label2.Text = "Filter by Date:";

            // chkUseDate
            this.chkUseDate.AutoSize = true;
            this.chkUseDate.Font = new Font("Segoe UI", 9F);
            this.chkUseDate.Location = new Point(450, 90);
            this.chkUseDate.Text = "Use?";
            this.chkUseDate.UseVisualStyleBackColor = true;

            // dtpDate
            this.dtpDate.Font = new Font("Segoe UI", 9.75F);
            this.dtpDate.Format = DateTimePickerFormat.Short;
            this.dtpDate.Location = new Point(520, 87);
            this.dtpDate.Size = new Size(140, 25);

            // btnSearch
            this.btnSearch.BackColor = Color.FromArgb(0, 102, 204);
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.Location = new Point(680, 85);
            this.btnSearch.Size = new Size(90, 30);
            this.btnSearch.Text = "🔍 Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += btnSearch_Click;

            // btnClear
            this.btnClear.BackColor = Color.FromArgb(108, 117, 125);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Location = new Point(780, 85);
            this.btnClear.Size = new Size(90, 30);
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += btnClear_Click;

            // lstEvents
            this.lstEvents.Font = new Font("Segoe UI", 10F);
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.ItemHeight = 17;
            this.lstEvents.Location = new Point(25, 130);
            this.lstEvents.Size = new Size(560, 310);
            this.lstEvents.DoubleClick += lstEvents_DoubleClick;

            // lblRecommendations
            this.lblRecommendations.AutoSize = true;
            this.lblRecommendations.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblRecommendations.ForeColor = Color.FromArgb(0, 102, 204);
            this.lblRecommendations.Location = new Point(610, 130);
            this.lblRecommendations.Text = "⭐ Recommended for You";

            // lstRecommendations
            this.lstRecommendations.Font = new Font("Segoe UI", 9.5F);
            this.lstRecommendations.FormattingEnabled = true;
            this.lstRecommendations.ItemHeight = 17;
            this.lstRecommendations.Location = new Point(610, 155);
            this.lstRecommendations.Size = new Size(260, 140);

            // lblSearchHistory
            this.lblSearchHistory.AutoSize = true;
            this.lblSearchHistory.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblSearchHistory.ForeColor = Color.FromArgb(108, 117, 125);
            this.lblSearchHistory.Location = new Point(610, 310);
            this.lblSearchHistory.Text = "🕐 Recent Searches";

            // lstSearchHistory
            this.lstSearchHistory.Font = new Font("Segoe UI", 9F);
            this.lstSearchHistory.FormattingEnabled = true;
            this.lstSearchHistory.ItemHeight = 15;
            this.lstSearchHistory.Location = new Point(610, 335);
            this.lstSearchHistory.Size = new Size(260, 109);

            // btnBack
            this.btnBack.BackColor = Color.FromArgb(108, 117, 125);
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBack.ForeColor = Color.White;
            this.btnBack.Location = new Point(25, 460);
            this.btnBack.Size = new Size(150, 38);
            this.btnBack.Text = "🔙 Back to Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += btnBack_Click;

            // btnAddEvent
            this.btnAddEvent = new Button();
            this.btnAddEvent.BackColor = Color.FromArgb(40, 167, 69);
            this.btnAddEvent.FlatStyle = FlatStyle.Flat;
            this.btnAddEvent.FlatAppearance.BorderSize = 0;
            this.btnAddEvent.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAddEvent.ForeColor = Color.White;
            this.btnAddEvent.Location = new Point(200, 460);
            this.btnAddEvent.Size = new Size(180, 38);
            this.btnAddEvent.Text = "➕ Add New Event";
            this.btnAddEvent.UseVisualStyleBackColor = false;
            this.btnAddEvent.Click += btnAddEvent_Click;
            this.Controls.Add(this.btnAddEvent);

            // statusStrip
            this.statusStrip = new StatusStrip();
            this.lblStatus = new ToolStripStatusLabel();
            this.lblStatus.Text = "Ready";
            this.statusStrip.Items.Add(this.lblStatus);
            this.statusStrip.BackColor = Color.FromArgb(230, 235, 240);
            this.Controls.Add(this.statusStrip);

            // EventsForm
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 244, 248);
            this.ClientSize = new Size(900, 520);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lstSearchHistory);
            this.Controls.Add(this.lblSearchHistory);
            this.Controls.Add(this.lstRecommendations);
            this.Controls.Add(this.lblRecommendations);
            this.Controls.Add(this.lstEvents);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.chkUseDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelHeader);
            this.Font = new Font("Segoe UI", 9.75F);
            this.Name = "EventsForm";
            this.Text = "Local Events & Announcements";
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void EventsForm_Load(object sender, EventArgs e)
        {
            cmbCategory.Items.Add("All Categories");
            foreach (var cat in eventManager.Categories)
            {
                cmbCategory.Items.Add(cat);
            }
            cmbCategory.SelectedIndex = 0;

            LoadEvents(eventManager.GetUpcomingEvents());
            LoadRecommendations();
            LoadSearchHistory();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string category = cmbCategory.SelectedItem?.ToString();
            if (category == "All Categories") category = null;

            DateTime? date = null;
            if (chkUseDate.Checked)
                date = dtpDate.Value.Date;

            var results = eventManager.SearchEvents(category, date);
            LoadEvents(results);
            LoadRecommendations();
            LoadSearchHistory();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbCategory.SelectedIndex = 0;
            chkUseDate.Checked = false;
            dtpDate.Value = DateTime.Today;
            LoadEvents(eventManager.GetUpcomingEvents());
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void LoadEvents(List<Event> events)
        {
            lstEvents.Items.Clear();
            if (events.Count == 0)
            {
                lstEvents.Items.Add("No events found matching your search.");
                lblStatus.Text = "0 events found";
                return;
            }
            foreach (var evt in events)
            {
                lstEvents.Items.Add(evt.ToString());
            }
            lblStatus.Text = $"{events.Count} event(s) displayed | Last updated: {DateTime.Now:HH:mm:ss}";
        }

        private void LoadRecommendations()
        {
            lstRecommendations.Items.Clear();
            var recs = eventManager.GetRecommendations();
            foreach (var evt in recs)
            {
                lstRecommendations.Items.Add($"⭐ {evt.Title} ({evt.EventDate:MMM dd})");
            }
        }

        private void LoadSearchHistory()
        {
            lstSearchHistory.Items.Clear();
            var history = eventManager.GetRecentSearches();
            if (history.Count == 0)
            {
                lstSearchHistory.Items.Add("No searches yet.");
                return;
            }
            foreach (var search in history)
            {
                lstSearchHistory.Items.Add(search);
            }
        }
        private void lstEvents_DoubleClick(object sender, EventArgs e)
        {
            if (lstEvents.SelectedIndex == -1) return;
            string selectedText = lstEvents.SelectedItem?.ToString();

            // Find the event that matches the selected text
            Event foundEvent = null;
            foreach (var evt in eventManager.GetUpcomingEvents())
            {
                if (evt.ToString() == selectedText)
                {
                    foundEvent = evt;
                    break;
                }
            }

            if (foundEvent != null)
            {
                string details = $"📌 {foundEvent.Title}\n\n" +
                                $"📂 Category: {foundEvent.Category}\n" +
                                $"📅 Date: {foundEvent.EventDate:dddd, dd MMMM yyyy}\n" +
                                $"📍 Location: {foundEvent.Location}\n" +
                                $"⚡ Priority: {GetPriorityText(foundEvent.Priority)}\n\n" +
                                $"📝 Description:\n{foundEvent.Description}";

                MessageBox.Show(details, "Event Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string GetPriorityText(int priority)
        {
            switch (priority)
            {
                case 1: return "🔴 High";
                case 2: return "🟡 Medium";
                case 3: return "🟢 Low";
                default: return "Normal";
            }
        }
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            AddEventForm addForm = new AddEventForm(eventManager);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh everything after adding
                cmbCategory.Items.Clear();
                cmbCategory.Items.Add("All Categories");
                foreach (var cat in eventManager.Categories)
                {
                    cmbCategory.Items.Add(cat);
                }
                cmbCategory.SelectedIndex = 0;
                LoadEvents(eventManager.GetUpcomingEvents());
                LoadRecommendations();
            }
        }
    }
}