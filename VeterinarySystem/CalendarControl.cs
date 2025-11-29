using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CalendarTest
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; } = string.Empty;
        public Color Color { get; set; }

        public Appointment()
        {
            Color = Color.LightBlue;
        }

        public override string ToString() => $"{Title} ({StartTime:HH:mm}-{EndTime:HH:mm})";
    }

    public partial class CalendarControl : UserControl
    {
        private readonly MonthCalendar _monthCalendar;
        private readonly ListBox _appointmentListBox;
        private readonly Button _btnAddAppointment;
        private readonly Button _btnEditAppointment;
        private readonly Button _btnDeleteAppointment;
        private readonly Label _lblSelectedDate;

        private readonly List<Appointment> _appointments;
        private int _nextId = 1;

        public IReadOnlyList<Appointment> Appointments => _appointments.AsReadOnly();

        public CalendarControl()
        {
            _appointments = new List<Appointment>();
            // initialize UI
            this.Size = new Size(780, 500);
            this.BackColor = Color.White;

            // MonthCalendar
            _monthCalendar = new MonthCalendar
            {
                Location = new Point(20, 20),
                MaxSelectionCount = 1
            };
            _monthCalendar.DateChanged += MonthCalendar_DateChanged;

            // Label for selected date
            _lblSelectedDate = new Label
            {
                Location = new Point(300, 20),
                Size = new Size(450, 30),
                Font = new Font("Arial", 14, FontStyle.Bold),
                Text = "Appointments for: " + DateTime.Today.ToString("MMMM dd, yyyy")
            };

            // ListBox for appointments
            _appointmentListBox = new ListBox
            {
                Location = new Point(300, 60),
                Size = new Size(450, 350),
                DrawMode = DrawMode.OwnerDrawFixed,
                ItemHeight = 60
            };
            _appointmentListBox.DrawItem += AppointmentListBox_DrawItem;
            _appointmentListBox.DoubleClick += BtnEditAppointment_Click;

            // Buttons
            _btnAddAppointment = new Button
            {
                Location = new Point(300, 430),
                Size = new Size(140, 40),
                Text = "Add",
                BackColor = Color.LightGreen
            };
            _btnAddAppointment.Click += BtnAddAppointment_Click;

            _btnEditAppointment = new Button
            {
                Location = new Point(450, 430),
                Size = new Size(140, 40),
                Text = "Edit"
            };
            _btnEditAppointment.Click += BtnEditAppointment_Click;

            _btnDeleteAppointment = new Button
            {
                Location = new Point(600, 430),
                Size = new Size(140, 40),
                Text = "Delete",
                BackColor = Color.LightCoral
            };
            _btnDeleteAppointment.Click += BtnDeleteAppointment_Click;

            this.Controls.AddRange(new Control[] {
                _monthCalendar, _lblSelectedDate, _appointmentListBox,
                _btnAddAppointment, _btnEditAppointment, _btnDeleteAppointment
            });

            LoadSampleData();
            UpdateAppointmentList();
        }

        public void LoadAppointments(IEnumerable<Appointment> items)
        {
            _appointments.Clear();
            _appointments.AddRange(items);
            _nextId = (_appointments.Any() ? _appointments.Max(a => a.Id) + 1 : 1);
            UpdateAppointmentList();
        }

        private void LoadSampleData()
        {
            _appointments.Add(new Appointment
            {
                Id = _nextId++,
                Title = "Team Meeting",
                StartTime = DateTime.Today.AddHours(9),
                EndTime = DateTime.Today.AddHours(10),
                Description = "Weekly team standup",
                Color = Color.LightBlue
            });

            _appointments.Add(new Appointment
            {
                Id = _nextId++,
                Title = "Dentist Appointment",
                StartTime = DateTime.Today.AddHours(14),
                EndTime = DateTime.Today.AddHours(15),
                Description = "Regular checkup",
                Color = Color.LightGreen
            });
        }

        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            _lblSelectedDate.Text = "Appointments for: " + _monthCalendar.SelectionStart.ToShortDateString();
            UpdateAppointmentList();
        }

        private void UpdateAppointmentList()
        {
            if (_monthCalendar == null || _appointmentListBox == null || _appointments == null)
                return;

            DateTime selectedDate = _monthCalendar.SelectionStart.Date;
            var dayAppointments = _appointments
                .Where(a => a.StartTime.Date == selectedDate)
                .OrderBy(a => a.StartTime)
                .ToList();

            _appointmentListBox.Items.Clear();
            foreach (var apt in dayAppointments)
            {
                _appointmentListBox.Items.Add(apt);
            }

            var appointmentDates = _appointments.Select(a => a.StartTime.Date).Distinct().ToArray();
            _monthCalendar.BoldedDates = appointmentDates;
        }

        private void AppointmentListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            var apt = (Appointment)_appointmentListBox.Items[e.Index];
            e.DrawBackground();

            using (SolidBrush brush = new SolidBrush(apt.Color))
            {
                e.Graphics.FillRectangle(brush, e.Bounds.Left + 5, e.Bounds.Top + 5, 10, e.Bounds.Height - 10);
            }

            string timeText = $"{apt.StartTime:HH:mm} - {apt.EndTime:HH:mm}";
            using Font titleFont = new Font("Arial", 10, FontStyle.Bold);
            using Font detailFont = new Font("Arial", 9);

            e.Graphics.DrawString(apt.Title, titleFont, Brushes.Black, e.Bounds.Left + 25, e.Bounds.Top + 5);
            e.Graphics.DrawString(timeText, detailFont, Brushes.Gray, e.Bounds.Left + 25, e.Bounds.Top + 25);
            e.Graphics.DrawString(apt.Description, detailFont, Brushes.DarkGray, e.Bounds.Left + 25, e.Bounds.Top + 42);

            e.DrawFocusRectangle();
        }

        private void BtnAddAppointment_Click(object sender, EventArgs e)
        {
            using (var dialog = new AppointmentDialog(_monthCalendar.SelectionStart))
            {
                if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    var newApt = dialog.Appointment;
                    newApt.Id = _nextId++;
                    _appointments.Add(newApt);
                    UpdateAppointmentList();
                }
            }
        }

        private void BtnEditAppointment_Click(object sender, EventArgs e)
        {
            if (_appointmentListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an appointment to edit.", "No Selection");
                return;
            }

            var selectedApt = (Appointment)_appointmentListBox.SelectedItem;
            using (var dialog = new AppointmentDialog(selectedApt))
            {
                if (dialog.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    var index = _appointments.FindIndex(a => a.Id == selectedApt.Id);
                    if (index >= 0)
                    {
                        _appointments[index] = dialog.Appointment;
                        UpdateAppointmentList();
                    }
                }
            }
        }

        private void BtnDeleteAppointment_Click(object sender, EventArgs e)
        {
            if (_appointmentListBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an appointment to delete.", "No Selection");
                return;
            }

            var result = MessageBox.Show("Delete this appointment?", "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var selectedApt = (Appointment)_appointmentListBox.SelectedItem;
                _appointments.RemoveAll(a => a.Id == selectedApt.Id);
                UpdateAppointmentList();
            }
        }
    }
}