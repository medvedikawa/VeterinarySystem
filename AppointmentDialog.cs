CalendarTest\AppointmentDialog.cs
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalendarTest
{
    public class AppointmentDialog : Form
    {
        private TextBox _txtTitle;
        private DateTimePicker _dtpDate;
        private DateTimePicker _dtpStartTime;
        private DateTimePicker _dtpEndTime;
        private TextBox _txtDescription;
        private ComboBox _cmbColor;
        private Button _btnOk;
        private Button _btnCancel;
        private readonly bool _isNew;

        public Appointment Appointment { get; private set; }

        public AppointmentDialog(DateTime defaultDate)
        {
            _isNew = true;
            Appointment = new Appointment { StartTime = defaultDate.AddHours(9), EndTime = defaultDate.AddHours(10) };
            InitializeDialog();
        }

        public AppointmentDialog(Appointment existingAppointment)
        {
            _isNew = false;
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

            // Friendly beige theme and spacing
            this.BackColor = Color.FromArgb(237, 219, 186);
            this.Padding = new Padding(12);
            this.Font = new Font("Segoe UI", 9F);
            this.ForeColor = Color.FromArgb(94, 86, 81);

            int y = 18;

            var lblTitle = new Label { Text = "Title:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent };
            this.Controls.Add(lblTitle);
            _txtTitle = new TextBox { Location = new Point(110, y), Size = new Size(330, 22), Text = Appointment.Title, BackColor = Color.White };
            this.Controls.Add(_txtTitle);
            y += 36;

            var lblDate = new Label { Text = "Date:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent };
            this.Controls.Add(lblDate);
            _dtpDate = new DateTimePicker { Location = new Point(110, y), Size = new Size(200, 22), Value = Appointment.StartTime.Date };
            if (_isNew)
            {
                _dtpDate.MinDate = DateTime.Today;
            }
            this.Controls.Add(_dtpDate);
            y += 36;

            var lblStart = new Label { Text = "Start Time:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent };
            this.Controls.Add(lblStart);
            _dtpStartTime = new DateTimePicker
            {
                Location = new Point(110, y),
                Size = new Size(120, 22),
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true,
                Value = Appointment.StartTime
            };
            this.Controls.Add(_dtpStartTime);
            y += 36;

            var lblEnd = new Label { Text = "End Time:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent };
            this.Controls.Add(lblEnd);
            _dtpEndTime = new DateTimePicker
            {
                Location = new Point(110, y),
                Size = new Size(120, 22),
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true,
                Value = Appointment.EndTime
            };
            this.Controls.Add(_dtpEndTime);
            y += 36;

            var lblColor = new Label { Text = "Color:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent };
            this.Controls.Add(lblColor);
            _cmbColor = new ComboBox
            {
                Location = new Point(110, y),
                Size = new Size(150, 22),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            _cmbColor.Items.AddRange(new object[] { "Light Blue", "Light Green", "Light Yellow", "Light Pink", "Light Coral" });
            SetSelectedColor(Appointment.Color);
            this.Controls.Add(_cmbColor);
            y += 36;

            var lblDesc = new Label { Text = "Description:", Location = new Point(20, y), Size = new Size(80, 20), BackColor = Color.Transparent };
            this.Controls.Add(lblDesc);
            _txtDescription = new TextBox
            {
                Location = new Point(110, y),
                Size = new Size(330, 84),
                Multiline = true,
                Text = Appointment.Description,
                BackColor = Color.White
            };
            this.Controls.Add(_txtDescription);
            y += 96;

            _btnOk = new Button { Text = "OK", Location = new Point(290, y), Size = new Size(75, 30), DialogResult = DialogResult.OK, BackColor = Color.FromArgb(64, 120, 170), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            _btnOk.FlatAppearance.BorderSize = 0;
            _btnOk.Click += BtnOk_Click;
            this.Controls.Add(_btnOk);

            _btnCancel = new Button { Text = "Cancel", Location = new Point(375, y), Size = new Size(75, 30), DialogResult = DialogResult.Cancel, BackColor = Color.FromArgb(160, 82, 45), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
            _btnCancel.FlatAppearance.BorderSize = 0;
            this.Controls.Add(_btnCancel);

            this.AcceptButton = _btnOk;
            this.CancelButton = _btnCancel;

            // NOTE: removed the CalendarControl being added here; it caused overlapping UI
            // var calendar = new CalendarTest.CalendarControl { Dock = DockStyle.Fill };
            // this.Controls.Add(calendar);
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_txtTitle.Text))
            {
                MessageBox.Show("Please enter a title.", "Validation Error");
                this.DialogResult = DialogResult.None;
                return;
            }

            var startTime = _dtpDate.Value.Date.Add(_dtpStartTime.Value.TimeOfDay);
            var endTime = _dtpDate.Value.Date.Add(_dtpEndTime.Value.TimeOfDay);

            if (endTime <= startTime)
            {
                MessageBox.Show("End time must be after start time.", "Validation Error");
                this.DialogResult = DialogResult.None;
                return;
            }

            if (startTime < DateTime.Now)
            {
                MessageBox.Show("Appointments cannot start in the past. Please choose a future date/time.", "Validation Error");
                this.DialogResult = DialogResult.None;
                return;
            }

            Appointment.Title = _txtTitle.Text;
            Appointment.StartTime = startTime;
            Appointment.EndTime = endTime;
            Appointment.Description = _txtDescription.Text;
            Appointment.Color = GetSelectedColor();
        }

        private Color GetSelectedColor()
        {
            return _cmbColor.SelectedIndex switch
            {
                0 => Color.LightBlue,
                1 => Color.LightGreen,
                2 => Color.LightYellow,
                3 => Color.LightPink,
                4 => Color.LightCoral,
                _ => Color.LightBlue
            };
        }

        private void SetSelectedColor(Color color)
        {
            if (color == Color.LightBlue) _cmbColor.SelectedIndex = 0;
            else if (color == Color.LightGreen) _cmbColor.SelectedIndex = 1;
            else if (color == Color.LightYellow) _cmbColor.SelectedIndex = 2;
            else if (color == Color.LightPink) _cmbColor.SelectedIndex = 3;
            else if (color == Color.LightCoral) _cmbColor.SelectedIndex = 4;
            else _cmbColor.SelectedIndex = 0;
        }

        // Helper to show dialog with parent
        public DialogResult ShowDialog(IWin32Window owner)
        {
            return base.ShowDialog(owner);
        }
    }
}