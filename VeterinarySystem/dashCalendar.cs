using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace VeterinarySystem
{
    public partial class dashCalendar : UserControl
    {
        private Panel calendarCard;
        private Panel weekDaysPanel;
        private Panel timelinePanel;
        private Label lblMonthYear;
        private Button btnPrev;
        private Button btnNext;
        private Button btnAddAppointment;
        private List<TimelineAppointment> appointments = new();
        private DateTime selectedDate = DateTime.Today;

        public dashCalendar()
        {
            InitializeComponent();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            BuildRuntimeUI();
            LoadSampleData();
            RefreshCalendar();
        }

        private void BuildRuntimeUI()
        {
            this.BackColor = Color.FromArgb(240, 242, 245);
            this.Padding = new Padding(20);

            // Calendar Card (mini calendar)
            calendarCard = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(420, 320),
                // MATCHED sidebar design color (panel3 / panel4 BackColor in usrSidebar.Designer.cs)
                BackColor = Color.White
            };
            calendarCard.Paint += DrawRoundedCard;

            // Month/Year header
            lblMonthYear = new Label
            {
                Text = selectedDate.ToString("MMMM, yyyy"),
                Location = new Point(20, 20),
                Size = new Size(320, 25),
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50)
            };

            btnPrev = new Button
            {
                Text = "‹",
                Location = new Point(370, 18),
                Size = new Size(30, 30),
                Font = new Font("Segoe UI", 14F),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White, // sidebar-like warm color
                ForeColor = Color.FromArgb(94, 86, 81),    // contrasting text color
                Cursor = Cursors.Hand
            };
            btnPrev.FlatAppearance.BorderSize = 0;
            btnPrev.FlatAppearance.MouseOverBackColor = Color.FromArgb(222, 200, 160);
            btnPrev.Click += (s, e) => ChangeMonth(-1);

            btnNext = new Button
            {
                Text = "›",
                Location = new Point(405, 18),
                Size = new Size(30, 30),
                Font = new Font("Segoe UI", 14F),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.White, // match prev for consistency
                ForeColor = Color.FromArgb(94, 86, 81),
                Cursor = Cursors.Hand,
                Visible = true
            };
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatAppearance.MouseOverBackColor = Color.FromArgb(222, 200, 160);
            btnNext.Click += (s, e) => ChangeMonth(1);

            // Week days header
            weekDaysPanel = new Panel
            {
                Location = new Point(10, 60),
                Size = new Size(400, 30),
                BackColor = Color.White
            };

            calendarCard.Controls.AddRange(new Control[] { lblMonthYear, btnPrev, btnNext, weekDaysPanel });

            // Timeline Panel (moved to left by UpdateLayout)
            timelinePanel = new Panel
            {
                Location = new Point(20, 20),
                Size = new Size(320, 640),
                BackColor = Color.White,
                AutoScroll = true
            };
            timelinePanel.Paint += DrawRoundedCard;

            // Add appointment button (kept floating)
            btnAddAppointment = new Button
            {
                Text = "+",
                Size = new Size(40, 40),
                Location = new Point(380, 990),
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(100, 149, 237),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAddAppointment.FlatAppearance.BorderColor = Color.FromArgb(220, 220, 220);
            btnAddAppointment.Paint += (s, e) =>
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var path = new GraphicsPath();
                path.AddEllipse(0, 0, btnAddAppointment.Width - 1, btnAddAppointment.Height - 1);
                btnAddAppointment.Region = new Region(path);
            };

            this.Controls.AddRange(new Control[] { timelinePanel, calendarCard, btnAddAppointment });

            // wire resize to update layout so the control adapts when hosted
            this.Resize += (s, e) => UpdateLayout();
            UpdateLayout();

            // create week-day labels and calendar after layout established
            CreateWeekDaysHeader();
            RefreshCalendar();
        }

        private void UpdateLayout()
        {
            const int pad = 20;
            const int gap = 16;
            int availableWidth = Math.Max(400, this.ClientSize.Width - pad * 2);
            int availableHeight = Math.Max(320, this.ClientSize.Height - pad * 2);

            // Keep minimum widths
            int minCalendarWidth = 300;
            int minTimelineWidth = 220;

            // Compute maximum timeline width possible while preserving min calendar width
            int maxTimelinePossible = availableWidth - minCalendarWidth - gap;
            if (maxTimelinePossible < minTimelineWidth)
            {
                // Not enough space for min calendar; fallback to proportional split
                int timelineWidthFallback = Math.Max(minTimelineWidth, (int)(availableWidth * 0.6));
                timelineWidthFallback = Math.Min(timelineWidthFallback, availableWidth - gap - 200);
                int calendarWidthFallback = availableWidth - timelineWidthFallback - gap;
                timelinePanel.Location = new Point(pad, pad);
                timelinePanel.Size = new Size(timelineWidthFallback, Math.Max(320, (int)(availableHeight * 0.52)));

                calendarCard.Location = new Point(timelinePanel.Right + gap, pad);
                calendarCard.Size = new Size(Math.Max(minCalendarWidth, calendarWidthFallback), timelinePanel.Height);
            }
            else
            {
                // Maximize timeline: give it the maximum space available while keeping calendar at minimum
                int timelineWidth = Math.Max(minTimelineWidth, maxTimelinePossible);
                // cap it so calendar still has at least minCalendarWidth
                timelineWidth = Math.Min(timelineWidth, availableWidth - minCalendarWidth - gap);

                int calendarWidth = availableWidth - timelineWidth - gap;

                // Decide calendar card height
                int calendarCardHeight = Math.Max(320, (int)(availableHeight * 0.52));

                // Position timeline (left) and calendar (right). Timeline takes as much width as possible.
                timelinePanel.Location = new Point(pad, pad);
                timelinePanel.Size = new Size(timelineWidth, calendarCardHeight);

                calendarCard.Location = new Point(timelinePanel.Right + gap, pad);
                calendarCard.Size = new Size(calendarWidth, calendarCardHeight);
            }

            // month navigation relative to calendar width
            int navX = Math.Max(8, calendarCard.ClientSize.Width - 70 - calendarCard.Padding.Right - 6);
            btnPrev.Location = new Point(navX, 18);
            btnNext.Location = new Point(navX + 35, 18);

            // week header width matches calendar inner width
            weekDaysPanel.Location = new Point(10, 50);
            weekDaysPanel.Size = new Size(calendarCard.Width - 20, 30);

            // place add button bottom-right of timelinePanel
            btnAddAppointment.Location = new Point(timelinePanel.Right - btnAddAppointment.Width - 12, timelinePanel.Bottom - btnAddAppointment.Height - 12);

            // refresh to recreate calendar buttons and timeline items to fit new sizes
            RefreshCalendar();
        }

        private void CreateWeekDaysHeader()
        {
            weekDaysPanel.Controls.Clear();

            string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            int dayWidth = Math.Max(32, (calendarCard.ClientSize.Width - 20) / 7);

            for (int i = 0; i < 7; i++)
            {
                var lbl = new Label
                {
                    Text = days[i],
                    Location = new Point(i * dayWidth, 0),
                    Size = new Size(dayWidth, 30),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 8F),
                    ForeColor = Color.Gray
                };
                weekDaysPanel.Controls.Add(lbl);
            }
        }

        private void CreateCalendarGrid()
        {
            // Remove existing day buttons (RefreshCalendar typically clears prior)
            var firstDay = new DateTime(selectedDate.Year, selectedDate.Month, 1);
            int startDayOfWeek = (int)firstDay.DayOfWeek;
            int daysInMonth = DateTime.DaysInMonth(selectedDate.Year, selectedDate.Month);

            int dayWidth = Math.Max(32, (calendarCard.ClientSize.Width - 20) / 7);
            int dayHeight = 40;
            int startY = 80;

            for (int day = 1; day <= daysInMonth; day++)
            {
                int position = startDayOfWeek + day - 1;
                int row = position / 7;
                int col = position % 7;

                var date = new DateTime(selectedDate.Year, selectedDate.Month, day);
                bool isToday = date.Date == DateTime.Today;
                bool isSelected = date.Date == selectedDate.Date;

                var dayBtn = new Button
                {
                    Text = day.ToString(),
                    Location = new Point(10 + col * dayWidth, startY + row * dayHeight),
                    Size = new Size(dayWidth - 4, dayHeight - 4),
                    Font = new Font("Segoe UI", 9F, isToday ? FontStyle.Bold : FontStyle.Regular),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = isToday ? Color.FromArgb(59, 130, 246) : Color.White,
                    ForeColor = isToday ? Color.White : Color.FromArgb(80, 80, 80),
                    Cursor = Cursors.Hand,
                    Tag = date
                };

                dayBtn.FlatAppearance.BorderSize = 0;

                if (isToday)
                {
                    dayBtn.Paint += (s, e) =>
                    {
                        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        using var path = GetRoundedRectPath(new Rectangle(0, 0, dayBtn.Width, dayBtn.Height), 8);
                        dayBtn.Region = new Region(path);
                    };
                }

                dayBtn.Click += (s, e) =>
                {
                    selectedDate = (DateTime)dayBtn.Tag;
                    RefreshCalendar();
                };

                calendarCard.Controls.Add(dayBtn);
            }
        }

        //private Panel CreateTodayAppointmentCard()
        //{
        //    var todayApt = appointments.FirstOrDefault(a => a.Time.Date == DateTime.Today && a.Time.Hour >= DateTime.Now.Hour);

        //    var card = new Panel
        //    {
        //        Size = new Size(Math.Max(280, calendarCard.Width - 60), 45),
        //        BackColor = Color.Black,
        //        Cursor = Cursors.Hand
        //    };

        //    card.Paint += (s, e) =>
        //    {
        //        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
        //        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //        using var path = GetRoundedRectPath(new Rectangle(0, 0, card.Width - 1, card.Height - 1), 8);
        //        card.Region = new Region(path);
        //    };

        //    if (todayApt != null)
        //    {
        //        var avatar = new Panel
        //        {
        //            Size = new Size(32, 32),
        //            Location = new Point(8, 7),
        //            BackColor = todayApt.AvatarColor
        //        };
        //        avatar.Paint += (s, e) =>
        //        {
        //            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
        //            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //            using var path = new GraphicsPath();
        //            path.AddEllipse(0, 0, 32, 32);
        //            avatar.Region = new Region(path);
        //            using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        //            e.Graphics.DrawString(todayApt.Initials, new Font("Segoe UI", 8F, FontStyle.Bold),
        //                Brushes.White, new RectangleF(0, 0, 32, 32), sf);
        //        };

        //        var lblName = new Label
        //        {
        //            Text = todayApt.Title,
        //            Location = new Point(48, 10),
        //            Size = new Size(200, 18),
        //            Font = new Font("Segoe UI", 9F, FontStyle.Bold),
        //            ForeColor = Color.FromArgb(50, 50, 50)
        //        };

        //        var lblTime = new Label
        //        {
        //            Text = todayApt.Time.ToString("hh:mm tt"),
        //            Location = new Point(48, 26),
        //            Size = new Size(100, 14),
        //            Font = new Font("Segoe UI", 7.5F),
        //            ForeColor = Color.Gray
        //        };

        //        var chevron = new Label
        //        {
        //            Text = "›",
        //            Location = new Point(card.Width - 30, 12),
        //            Size = new Size(20, 20),
        //            Font = new Font("Segoe UI", 14F),
        //            ForeColor = Color.LightGray,
        //            Anchor = AnchorStyles.Top | AnchorStyles.Right
        //        };

        //        card.Resize += (s, e) => chevron.Location = new Point(card.Width - 30, 12);

        //        card.Controls.AddRange(new Control[] { avatar, lblName, lblTime, chevron });
        //    }

        //    return card;
        //}

        private void RefreshTimeline()
        {
            if (timelinePanel == null) return;
            timelinePanel.Controls.Clear();

            var todayApts = appointments
                .Where(a => a.Time.Date == selectedDate.Date)
                .OrderBy(a => a.Time)
                .ToList();

            int yPos = 12;
            int hourStart = 8;
            int hourEnd = 18;

            for (int hour = hourStart; hour <= hourEnd; hour++)
            {
                // Time label
                var lblTime = new Label
                {
                    Text = $"{hour:D2}:00",
                    Location = new Point(12, yPos),
                    Size = new Size(50, 20),
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.Gray
                };
                timelinePanel.Controls.Add(lblTime);

                // Timeline line
                var line = new Panel
                {
                    Location = new Point(72, yPos + 8),
                    Size = new Size(1, 60),
                    BackColor = Color.FromArgb(230, 230, 230)
                };
                timelinePanel.Controls.Add(line);

                // Check for appointments at this hour
                var hourApts = todayApts.Where(a => a.Time.Hour == hour).ToList();

                foreach (var apt in hourApts)
                {
                    var aptCard = CreateTimelineCard(apt);
                    aptCard.Location = new Point(90, yPos - 5);
                    timelinePanel.Controls.Add(aptCard);
                    yPos += 10;
                }

                yPos += 60;
            }
        }

        private Panel CreateTimelineCard(TimelineAppointment apt)
        {
            var card = new Panel
            {
                Size = new Size(Math.Max(220, timelinePanel.Width - 140), 55),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            card.Paint += (s, e) =>
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var pen = new Pen(Color.FromArgb(230, 230, 230));
                using var path = GetRoundedRectPath(new Rectangle(0, 0, card.Width - 1, card.Height - 1), 8);
                e.Graphics.DrawPath(pen, path);
            };

            var avatar = new Panel
            {
                Size = new Size(40, 40),
                Location = new Point(8, 8),
                BackColor = apt.AvatarColor
            };
            avatar.Paint += (s, e) =>
            {
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using var path = new GraphicsPath();
                path.AddEllipse(0, 0, 40, 40);
                avatar.Region = new Region(path);
                using var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(apt.Initials, new Font("Segoe UI", 9F, FontStyle.Bold),
                    Brushes.White, new RectangleF(0, 0, 40, 40), sf);
            };

            var lblName = new Label
            {
                Text = apt.Title,
                Location = new Point(56, 12),
                Size = new Size(150, 18),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(50, 50, 50)
            };

            var lblSubtitle = new Label
            {
                Text = apt.Subtitle,
                Location = new Point(56, 30),
                Size = new Size(150, 16),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray
            };

            var chevron = new Label
            {
                Text = "›",
                Location = new Point(card.Width - 30, 17),
                Size = new Size(20, 20),
                Font = new Font("Segoe UI", 14F),
                ForeColor = Color.LightGray,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            card.Resize += (s, e) => chevron.Location = new Point(card.Width - 30, 17);

            card.Controls.AddRange(new Control[] { avatar, lblName, lblSubtitle, chevron });
            card.Click += (s, e) => MessageBox.Show($"{apt.Title}\n{apt.Subtitle}\n{apt.Time:f}", "Appointment");

            return card;
        }

        private void DrawRoundedCard(object sender, PaintEventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime) return;

            var panel = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using var path = GetRoundedRectPath(new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 12);
            panel.Region = new Region(path);

            using var pen = new Pen(Color.FromArgb(230, 230, 230));
            e.Graphics.DrawPath(pen, path);
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            var path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void ChangeMonth(int direction)
        {
            selectedDate = selectedDate.AddMonths(direction);
            RefreshCalendar();
        }

        private void RefreshCalendar()
        {
            // Clear existing calendar day buttons
            var buttonsToRemove = calendarCard.Controls.OfType<Button>()
                .Where(b => b != btnPrev && b != btnNext && b.Tag is DateTime)
                .ToList();

            foreach (var btn in buttonsToRemove)
                calendarCard.Controls.Remove(btn);

            // Recreate week header (layout might have changed)
            CreateWeekDaysHeader();

            // Recreate calendar grid
            CreateCalendarGrid();

            // Update month label
            lblMonthYear.Text = selectedDate.ToString("MMMM, yyyy");

            // Update today card
            var oldCard = calendarCard.Controls.OfType<Panel>().FirstOrDefault(p => p.Location.Y >= 240);
            if (oldCard != null) calendarCard.Controls.Remove(oldCard);

            //var newCard = CreateTodayAppointmentCard();
            // position today card near bottom of calendar card
            //int cardY = Math.Max((calendarCard.Height - newCard.Height - 20), (int)(calendarCard.Height * 0.65));
            //newCard.Location = new Point(20, cardY);
            //calendarCard.Controls.Add(newCard);

            // Ensure navigation controls and header sit on top (not covered by recently added day buttons)
            lblMonthYear.BringToFront();
            btnPrev.BringToFront();
            btnNext.BringToFront();
            weekDaysPanel.BringToFront();

            RefreshTimeline();
        }

        private void LoadSampleData()
        {
            var today = DateTime.Today;
            appointments = new List<TimelineAppointment>
                {
                    new TimelineAppointment
                    {
                        Id = 1, Title = "Nino", Subtitle = "Vaccination",
                        Time = today.AddHours(9), AvatarColor = Color.FromArgb(100,149,237), Initials = "NI"
                    },
                    new TimelineAppointment
                    {
                        Id = 2, Title = "Sassy", Subtitle = "Check-up",
                        Time = today.AddHours(11), AvatarColor = Color.FromArgb(255,105,180), Initials = "SA"
                    },
                    new TimelineAppointment
                    {
                        Id = 3, Title = "Jimmy", Subtitle = "Surgery",
                        Time = today.AddHours(14), AvatarColor = Color.FromArgb(255,105,180), Initials = "JI"
                    },
                    new TimelineAppointment
                    {
                        Id = 4, Title = "Donut", Subtitle = "Follow-up",
                        Time = today.AddHours(15), AvatarColor = Color.FromArgb(100,149,237), Initials = "DO"
                    }
                };
        }
    }

    public class TimelineAppointment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public DateTime Time { get; set; }
        public Color AvatarColor { get; set; }
        public string Initials { get; set; }

        public TimelineAppointment()
        {
            AvatarColor = Color.FromArgb(100, 149, 237);
        }
    }
}