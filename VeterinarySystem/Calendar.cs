using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VeterinarySystem.Data;

namespace VeterinarySystem
{
    public partial class Calendar : UserControl
    {
        public Calendar()
        {
            InitializeComponent();
            var calendar = new CalendarControl
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(calendar);
        }

        // Appointment model
        public class Appointment
        {
            public int Id { get; set; }
            public string Title { get; set; } = string.Empty;
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string Description { get; set; } = string.Empty;
            public Color Color { get; set; }
            public int? PetId { get; set; }
            public string PetName { get; set; } = string.Empty;

            public Appointment()
            {
                Color = Color.LightBlue;
            }

            public override string ToString()
            {
                return Title;
            }
        }


        // Main Calendar UserControl
        public partial class CalendarControl : UserControl
        {
            private MonthCalendar monthCalendar;
            private ListBox appointmentListBox;
            private Button btnAddAppointment;
            private Button btnEditAppointment;
            private Button btnDeleteAppointment;
            private Label lblSelectedDate;
            private List<Appointment> appointments;
            private int nextId = 1;

            public CalendarControl()
            {
                // Initialize data first
                appointments = new List<Appointment>();

                InitializeComponent();

                // Load from database and then update the UI
                LoadAppointmentsFromDatabase();
                UpdateAppointmentList();
            }

            private void InitializeComponent()
            {
                this.Size = new Size(780, 500);
                this.BackColor = Color.White;

                // Month Calendar
                monthCalendar = new MonthCalendar
                {
                    Location = new Point(20, 20),
                    MaxSelectionCount = 1
                };
                monthCalendar.DateChanged += MonthCalendar_DateChanged;

                // Label for selected date
                lblSelectedDate = new Label
                {
                    Location = new Point(300, 20),
                    Size = new Size(450, 30),
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    Text = "Appointments for: " + monthCalendar.SelectionStart.ToString("MMMM dd, yyyy")
                };

                // ListBox for appointments
                appointmentListBox = new ListBox
                {
                    Location = new Point(300, 60),
                    Size = new Size(450, 350),
                    DrawMode = DrawMode.OwnerDrawFixed,
                    ItemHeight = 60
                };
                appointmentListBox.DrawItem += AppointmentListBox_DrawItem;
                // double-click opens read-only details
                appointmentListBox.DoubleClick += AppointmentListBox_DoubleClick;

                // Buttons
                btnAddAppointment = new Button
                {
                    Location = new Point(300, 430),
                    Size = new Size(140, 40),
                    Text = "Add",
                    BackColor = Color.LightGreen
                };
                btnAddAppointment.Click += BtnAddAppointment_Click;

                btnEditAppointment = new Button
                {
                    Location = new Point(450, 430),
                    Size = new Size(140, 40),
                    Text = "Edit"
                };
                // Edit button allows editing (persisting is still in-memory for now)
                btnEditAppointment.Click += BtnEditAppointment_Click;

                btnDeleteAppointment = new Button
                {
                    Location = new Point(600, 430),
                    Size = new Size(140, 40),
                    Text = "Delete",
                    BackColor = Color.LightCoral
                };
                btnDeleteAppointment.Click += BtnDeleteAppointment_Click;

                // Add controls to form
                this.Controls.AddRange(new Control[] {
            monthCalendar, lblSelectedDate, appointmentListBox,
            btnAddAppointment, btnEditAppointment, btnDeleteAppointment
        });
            }

            private void LoadAppointmentsFromDatabase()
            {
                try
                {
                    var dbList = AppointmentRepository.GetAll();

                    appointments = dbList ?? new List<Appointment>();

                    // ensure nextId is above highest DB id to avoid collisions for in-memory additions
                    if (appointments.Any())
                    {
                        nextId = appointments.Max(a => a.Id) + 1;
                    }
                }
                catch (Exception ex)
                {
                    // don't crash the UI — show message and keep in-memory list
                    MessageBox.Show("Failed to load appointments from database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
            {
                lblSelectedDate.Text = "Appointments for: " + monthCalendar.SelectionStart.ToShortDateString();

                // reload from database so user sees new entries without restarting
                LoadAppointmentsFromDatabase();

                UpdateAppointmentList();
            }

            private void UpdateAppointmentList()
            {
                // Guard in case control isn't fully initialized yet
                if (monthCalendar == null || appointmentListBox == null || appointments == null)
                    return;

                DateTime selectedDate = monthCalendar.SelectionStart.Date;
                var dayAppointments = appointments
                    .Where(a => a.StartTime.Date == selectedDate)
                    .OrderBy(a => a.StartTime)
                    .ToList();

                appointmentListBox.Items.Clear();
                foreach (var apt in dayAppointments)
                {
                    appointmentListBox.Items.Add(apt);
                }

                // Update calendar bold dates
                var appointmentDates = appointments.Select(a => a.StartTime.Date).Distinct().ToArray();
                monthCalendar.BoldedDates = appointmentDates;
            }

            private void AppointmentListBox_DrawItem(object sender, DrawItemEventArgs e)
            {
                if (e.Index < 0) return;

                var apt = (Appointment)appointmentListBox.Items[e.Index];
                e.DrawBackground();

                // Draw colored rectangle
                using (SolidBrush brush = new SolidBrush(apt.Color))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds.Left + 5, e.Bounds.Top + 5, 10, e.Bounds.Height - 10);
                }

                // Draw appointment details
                string timeText = $"{apt.StartTime:HH:mm} - {apt.EndTime:HH:mm}";
                Font titleFont = new Font("Arial", 10, FontStyle.Bold);
                Font detailFont = new Font("Arial", 9);

                e.Graphics.DrawString(apt.Title, titleFont, Brushes.Black, e.Bounds.Left + 25, e.Bounds.Top + 5);
                e.Graphics.DrawString(timeText, detailFont, Brushes.Gray, e.Bounds.Left + 25, e.Bounds.Top + 25);
                e.Graphics.DrawString(apt.Description, detailFont, Brushes.DarkGray, e.Bounds.Left + 25, e.Bounds.Top + 42);

                e.DrawFocusRectangle();
            }

            private void BtnAddAppointment_Click(object sender, EventArgs e)
            {
                using (var dialog = new AppointmentDialog(monthCalendar.SelectionStart))
                {
                    if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
                    {
                        try
                        {
                            var newApt = dialog.Appointment;
                            
                            // ⭐ Save to database FIRST
                            AppointmentRepository.Save(newApt);
                            
                            // Then reload from database to get the auto-generated ID
                            LoadAppointmentsFromDatabase();
                            UpdateAppointmentList();
                            
                            // ✅ Success message
                            MessageBox.Show("✅ Appointment saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"❌ Failed to save appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            // Edit button -> open editable dialog
            private void BtnEditAppointment_Click(object sender, EventArgs e)
            {
                if (appointmentListBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select an appointment to edit.", "No Selection");
                    return;
                }

                var selectedApt = (Appointment)appointmentListBox.SelectedItem;
                using (var dialog = new AppointmentDialog(selectedApt, true)) // allow edit
                {
                    if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
                    {
                        try
                        {
                            // ⭐ Update in database
                            AppointmentRepository.Update(dialog.Appointment);
                            
                            // Reload from database
                            LoadAppointmentsFromDatabase();
                            UpdateAppointmentList();
                            
                            // ✅ Success message
                            MessageBox.Show("✅ Appointment updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"❌ Failed to update appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

            private void BtnDeleteAppointment_Click(object sender, EventArgs e)
            {
                if (appointmentListBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select an appointment to delete.", "No Selection");
                    return;
                }

                var result = MessageBox.Show("Delete this appointment?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        var selectedApt = (Appointment)appointmentListBox.SelectedItem;
                        
                        // ⭐ Delete from database
                        AppointmentRepository.Delete(selectedApt.Id);
                        
                        // Reload from database
                        LoadAppointmentsFromDatabase();
                        UpdateAppointmentList();
                        
                        // ✅ Success message
                        MessageBox.Show("✅ Appointment deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"❌ Failed to delete appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            private void AppointmentListBox_DoubleClick(object sender, EventArgs e)
            {
                if (appointmentListBox.SelectedItem == null)
                    return;

                var selectedApt = (Appointment)appointmentListBox.SelectedItem;
                using (var dialog = new AppointmentDialog(selectedApt, false)) // read-only dialog
                {
                    dialog.ShowDialog(FindForm());
                }
            }
        }

        // Dialog for adding/editing/viewing appointments
        public class AppointmentDialog : Form
        {
            private TextBox txtTitle;
            private DateTimePicker dtpDate;
            private DateTimePicker dtpStartTime;
            private DateTimePicker dtpEndTime;
            private TextBox txtDescription;
            private ComboBox cmbColor;
            private ComboBox cmbPet;
            private Button btnOk;
            private Button btnCancel;
            private bool isNew; // tracks whether dialog is for a new appointment
            private bool isEditable; // controls whether fields may be edited

            public Appointment Appointment { get; private set; }

            public AppointmentDialog(DateTime defaultDate)
            {
                isNew = true;
                isEditable = true;
                Appointment = new Appointment { StartTime = defaultDate.AddHours(9), EndTime = defaultDate.AddHours(10) };
                InitializeDialog();
            }

            // existingAppointment with explicit editable flag
            public AppointmentDialog(Appointment existingAppointment, bool allowEdit)
            {
                isNew = false;
                isEditable = allowEdit;
                Appointment = new Appointment
                {
                    Id = existingAppointment.Id,
                    Title = existingAppointment.Title,
                    StartTime = existingAppointment.StartTime,
                    EndTime = existingAppointment.EndTime,
                    Description = existingAppointment.Description,
                    Color = existingAppointment.Color,
                    PetId = existingAppointment.PetId,
                    PetName = existingAppointment.PetName
                };
                InitializeDialog();
            }

            private void InitializeDialog()
            {
                this.Text = "Appointment Details";
                this.Size = new Size(520, 480);
                this.StartPosition = FormStartPosition.CenterParent;
                this.FormBorderStyle = FormBorderStyle.FixedDialog;
                this.MaximizeBox = false;
                this.MinimizeBox = false;

                // Apply warm beige theme and spacing
                this.BackColor = Color.FromArgb(237, 219, 186);
                this.Padding = new Padding(12);
                this.Font = new Font("Segoe UI", 9F);
                this.ForeColor = Color.FromArgb(94, 86, 81);

                int y = 18;

                // Title
                this.Controls.Add(new Label { Text = "Title:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent });
                txtTitle = new TextBox { Location = new Point(110, y), Size = new Size(380, 22), Text = Appointment.Title, BackColor = Color.White };
                txtTitle.ReadOnly = !isEditable;
                this.Controls.Add(txtTitle);
                y += 36;

                // Pet selector (searchable combobox)
                this.Controls.Add(new Label { Text = "Pet:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent });
                cmbPet = new ComboBox
                {
                    Location = new Point(110, y),
                    Size = new Size(300, 22),
                    DropDownStyle = ComboBoxStyle.DropDown
                };
                cmbPet.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbPet.AutoCompleteSource = AutoCompleteSource.CustomSource;
                cmbPet.Enabled = isEditable;
                this.Controls.Add(cmbPet);

                // load pet names into combobox
                try
                {
                    var pets = AppointmentRepository.GetPetNames();
                    var source = pets.Select(p => new { Id = p.Id, Name = p.Name }).ToList();
                    cmbPet.DisplayMember = "Name";
                    cmbPet.ValueMember = "Id";
                    cmbPet.DataSource = source;

                    // build autocomplete source
                    var ac = new AutoCompleteStringCollection();
                    ac.AddRange(source.Select(s => s.Name).ToArray());
                    cmbPet.AutoCompleteCustomSource = ac;

                    // set current selection if exists
                    if (Appointment.PetId.HasValue)
                    {
                        cmbPet.SelectedValue = Appointment.PetId.Value;
                    }
                    else if (!string.IsNullOrEmpty(Appointment.PetName))
                    {
                        cmbPet.Text = Appointment.PetName;
                    }
                }
                catch
                {
                    // ignore pet-loading errors to avoid blocking the dialog
                }

                y += 36;

                // Date
                this.Controls.Add(new Label { Text = "Date:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent });
                dtpDate = new DateTimePicker { Location = new Point(110, y), Size = new Size(200, 22), Value = Appointment.StartTime.Date };
                if (isNew)
                {
                    dtpDate.MinDate = DateTime.Today;
                }
                dtpDate.Enabled = isEditable;
                this.Controls.Add(dtpDate);
                y += 36;

                // Start Time
                this.Controls.Add(new Label { Text = "Start Time:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent });
                dtpStartTime = new DateTimePicker
                {
                    Location = new Point(110, y),
                    Size = new Size(120, 22),
                    Format = DateTimePickerFormat.Time,
                    ShowUpDown = true,
                    Value = Appointment.StartTime
                };
                dtpStartTime.Enabled = isEditable;
                this.Controls.Add(dtpStartTime);
                y += 36;

                // End Time
                this.Controls.Add(new Label { Text = "End Time:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent });
                dtpEndTime = new DateTimePicker
                {
                    Location = new Point(110, y),
                    Size = new Size(120, 22),
                    Format = DateTimePickerFormat.Time,
                    ShowUpDown = true,
                    Value = Appointment.EndTime
                };
                dtpEndTime.Enabled = isEditable;
                this.Controls.Add(dtpEndTime);
                y += 36;

                // Color
                this.Controls.Add(new Label { Text = "Color:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent });
                cmbColor = new ComboBox
                {
                    Location = new Point(110, y),
                    Size = new Size(150, 22),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cmbColor.Items.AddRange(new object[] { "LightBlue", "LightGreen", "LightYellow", "LightPink", "LightCoral" });
                // select color by name if possible
                var colorName = Appointment.Color.IsEmpty ? "LightBlue" : Appointment.Color.Name;
                var idx = cmbColor.Items.IndexOf(colorName);
                cmbColor.SelectedIndex = idx >= 0 ? idx : 0;
                cmbColor.Enabled = isEditable;
                this.Controls.Add(cmbColor);
                y += 36;

                // Description
                this.Controls.Add(new Label { Text = "Description:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent });
                txtDescription = new TextBox
                {
                    Location = new Point(110, y),
                    Size = new Size(380, 120),
                    Multiline = true,
                    Text = Appointment.Description,
                    BackColor = Color.White
                };
                txtDescription.ReadOnly = !isEditable;
                this.Controls.Add(txtDescription);
                y += 132;

                // Buttons
                btnOk = new Button { Text = "OK", Location = new Point(320, y), Size = new Size(75, 30), DialogResult = DialogResult.OK, BackColor = Color.FromArgb(64, 120, 170), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                btnOk.FlatAppearance.BorderSize = 0;
                btnOk.Click += BtnOk_Click;
                this.Controls.Add(btnOk);

                btnCancel = new Button { Text = isEditable ? "Cancel" : "Close", Location = new Point(405, y), Size = new Size(85, 30), DialogResult = DialogResult.Cancel, BackColor = Color.FromArgb(160, 82, 45), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                btnCancel.FlatAppearance.BorderSize = 0;
                this.Controls.Add(btnCancel);

                this.AcceptButton = btnOk;
                this.CancelButton = btnCancel;

                // If not editable, hide OK (or disable) to prevent accidental edits
                if (!isEditable)
                {
                    btnOk.Visible = false;
                }
            }

            private void BtnOk_Click(object sender, EventArgs e)
            {
                if (!isEditable)
                {
                    // should not happen because OK is hidden, but guard anyway
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }

                // ⭐ NEW: Require pet selection
                if (cmbPet.SelectedItem == null || (cmbPet.SelectedValue == null && string.IsNullOrWhiteSpace(cmbPet.Text)))
                {
                    MessageBox.Show("Please select a pet for this appointment.", "Pet Required");
                    this.DialogResult = DialogResult.None;
                    cmbPet.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Please enter a title.", "Validation Error");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                var startTime = dtpDate.Value.Date.Add(dtpStartTime.Value.TimeOfDay);
                var endTime = dtpDate.Value.Date.Add(dtpEndTime.Value.TimeOfDay);

                if (endTime <= startTime)
                {
                    MessageBox.Show("End time must be after start time.", "Validation Error");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                // Disallow booking in the past for new appointments
                if (isNew && startTime < DateTime.Now)
                {
                    MessageBox.Show("Appointments cannot start in the past. Please choose a future date/time.", "Validation Error");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                Appointment.Title = txtTitle.Text;
                Appointment.StartTime = startTime;
                Appointment.EndTime = endTime;
                Appointment.Description = txtDescription.Text;

                // Capture pet selection (if any)
                try
                {
                    if (cmbPet.SelectedItem != null)
                    {
                        var val = (int)cmbPet.SelectedValue;
                        Appointment.PetId = val;
                        Appointment.PetName = cmbPet.Text;
                    }
                    else if (!string.IsNullOrWhiteSpace(cmbPet.Text))
                    {
                        Appointment.PetName = cmbPet.Text;
                        Appointment.PetId = null;
                    }
                }
                catch
                {
                    Appointment.PetName = cmbPet.Text;
                    Appointment.PetId = null;
                }

                var sel = cmbColor.SelectedItem as string ?? "LightBlue";
                try
                {
                    var c = Color.FromName(sel);
                    Appointment.Color = c.IsEmpty ? Color.LightBlue : c;
                }
                catch
                {
                    Appointment.Color = Color.LightBlue;
                }
            }
        }
    }
}