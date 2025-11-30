VeterinarySystem\Calendar.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            public string Title { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public string Description { get; set; }
            public Color Color { get; set; }

            public Appointment()
            {
                Color = Color.LightBlue;
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
                // Initialize data first (so methods that reference appointments won't throw)
                appointments = new List<Appointment>();

                InitializeComponent();

                // Load sample data and then update the UI
                LoadSampleData();
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
                appointmentListBox.DoubleClick += BtnEditAppointment_Click;

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

                // NOTE: Do NOT call UpdateAppointmentList() here — appointments is initialized in the constructor
            }

            private void LoadSampleData()
            {
                // Add some sample appointments
                appointments.Add(new Appointment
                {
                    Id = nextId++,
                    Title = "Team Meeting",
                    StartTime = DateTime.Today.AddHours(9),
                    EndTime = DateTime.Today.AddHours(10),
                    Description = "Weekly team standup",
                    Color = Color.LightBlue
                });

                appointments.Add(new Appointment
                {
                    Id = nextId++,
                    Title = "Dentist Appointment",
                    StartTime = DateTime.Today.AddHours(14),
                    EndTime = DateTime.Today.AddHours(15),
                    Description = "Regular checkup",
                    Color = Color.LightGreen
                });
            }

            private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
            {
                lblSelectedDate.Text = "Appointments for: " + monthCalendar.SelectionStart.ToShortDateString();
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
                        var newApt = dialog.Appointment;
                        newApt.Id = nextId++;
                        appointments.Add(newApt);
                        UpdateAppointmentList();
                    }
                }
            }

            private void BtnEditAppointment_Click(object sender, EventArgs e)
            {
                if (appointmentListBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select an appointment to edit.", "No Selection");
                    return;
                }

                var selectedApt = (Appointment)appointmentListBox.SelectedItem;
                using (var dialog = new AppointmentDialog(selectedApt))
                {
                    if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
                    {
                        var index = appointments.FindIndex(a => a.Id == selectedApt.Id);
                        if (index >= 0)
                        {
                            appointments[index] = dialog.Appointment;
                            UpdateAppointmentList();
                        }
                    }
                }
            }

            private void BtnDeleteAppointment_Click(object sender, EventArgs e)
            {
                if (appointmentListBox.SelectedItem == null)
                {
                    MessageBox.Show("Please select an appointment to edit.", "No Selection");
                    return;
                }

                var result = MessageBox.Show("Delete this appointment?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var selectedApt = (Appointment)appointmentListBox.SelectedItem;
                    appointments.RemoveAll(a => a.Id == selectedApt.Id);
                    UpdateAppointmentList();
                }
            }
        }

        // Dialog for adding/editing appointments
        public class AppointmentDialog : Form
        {
            private TextBox txtTitle;
            private DateTimePicker dtpDate;
            private DateTimePicker dtpStartTime;
            private DateTimePicker dtpEndTime;
            private TextBox txtDescription;
            private ComboBox cmbColor;
            private Button btnOk;
            private Button btnCancel;
            private bool isNew; // tracks whether dialog is for a new appointment

            public Appointment Appointment { get; private set; }

            public AppointmentDialog(DateTime defaultDate)
            {
                isNew = true;
                Appointment = new Appointment { StartTime = defaultDate.AddHours(9), EndTime = defaultDate.AddHours(10) };
                InitializeDialog();
            }

            public AppointmentDialog(Appointment existingAppointment)
            {
                isNew = false;
                Appointment = new Appointment
                {
                    Id = existingAppointment.Id,
                    Title = existingAppointment.Title,
                    StartTime = existingAppointment.StartTime,
                    EndTime = existingAppointment.EndTime,
                    Description = existingAppointment.Description,
                    Color = existingAppointment.Color
                };
                InitializeDialog();
            }

            private void InitializeDialog()
            {
                this.Text = "Appointment Details";
                this.Size = new Size(480, 420);
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
                txtTitle = new TextBox { Location = new Point(110, y), Size = new Size(330, 22), Text = Appointment.Title, BackColor = Color.White };
                this.Controls.Add(txtTitle);
                y += 36;

                // Date
                this.Controls.Add(new Label { Text = "Date:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent });
                dtpDate = new DateTimePicker { Location = new Point(110, y), Size = new Size(200, 22), Value = Appointment.StartTime.Date };
                if (isNew)
                {
                    dtpDate.MinDate = DateTime.Today;
                }
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
                cmbColor.Items.AddRange(new object[] { "Light Blue", "Light Green", "Light Yellow", "Light Pink", "Light Coral" });
                cmbColor.SelectedIndex = 0;
                this.Controls.Add(cmbColor);
                y += 36;

                // Description
                this.Controls.Add(new Label { Text = "Description:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent });
                txtDescription = new TextBox
                {
                    Location = new Point(110, y),
                    Size = new Size(330, 84),
                    Multiline = true,
                    Text = Appointment.Description,
                    BackColor = Color.White
                };
                this.Controls.Add(txtDescription);
                y += 96;

                // Buttons
                btnOk = new Button { Text = "OK", Location = new Point(290, y), Size = new Size(75, 30), DialogResult = DialogResult.OK, BackColor = Color.FromArgb(64, 120, 170), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                btnOk.FlatAppearance.BorderSize = 0;
                btnOk.Click += BtnOk_Click;
                this.Controls.Add(btnOk);

                btnCancel = new Button { Text = "Cancel", Location = new Point(375, y), Size = new Size(75, 30), DialogResult = DialogResult.Cancel, BackColor = Color.FromArgb(160, 82, 45), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                btnCancel.FlatAppearance.BorderSize = 0;
                this.Controls.Add(btnCancel);

                this.AcceptButton = btnOk;
                this.CancelButton = btnCancel;
            }

            private void BtnOk_Click(object sender, EventArgs e)
            {
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

                // Disallow booking in the past (no appointments start earlier than now)
                if (startTime < DateTime.Now)
                {
                    MessageBox.Show("Appointments cannot start in the past. Please choose a future date/time.", "Validation Error");
                    this.DialogResult = DialogResult.None;
                    return;
                }

                Appointment.Title = txtTitle.Text;
                Appointment.StartTime = startTime;
                Appointment.EndTime = endTime;
                Appointment.Description = txtDescription.Text;
                Appointment.Color = GetSelectedColor();
            }

            private Color GetSelectedColor()
            {
                switch (cmbColor.SelectedIndex)
                {
                    case 0: return Color.LightBlue;
                    case 1: return Color.LightGreen;
                    case 2: return Color.LightYellow;
                    case 3: return Color.LightPink;
                    case 4: return Color.LightCoral;
                    default: return Color.LightBlue;
                }
            }
        }
    }
}