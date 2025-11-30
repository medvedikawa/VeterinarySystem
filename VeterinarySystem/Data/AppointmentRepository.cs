using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;

namespace VeterinarySystem.Data
{
    public static class AppointmentRepository
    {
        private const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=VetClinic;Trusted_Connection=True;TrustServerCertificate=True;";

        // Returns all appointments from the Appointments table.
        public static List<Calendar.Appointment> GetAll()
        {
            var list = new List<Calendar.Appointment>();

            using var conn = new SqlConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT a.appointmentID, a.title, a.appointmentDate, a.startTime, a.endTime, a.color, a.description, a.status, a.createdDate,
                       a.petID, p.petName
                FROM dbo.Appointments a
                LEFT JOIN dbo.petInfo p ON a.petID = p.petID;";

            using var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                var apt = new Calendar.Appointment();

                // Id
                if (!rdr.IsDBNull(0))
                    apt.Id = rdr.GetInt32(0);

                // Title
                if (!rdr.IsDBNull(1))
                    apt.Title = rdr.GetString(1);

                // appointmentDate + startTime -> StartTime
                DateTime date = rdr.IsDBNull(2) ? DateTime.MinValue : rdr.GetDateTime(2);
                TimeSpan startTs = rdr.IsDBNull(3) ? TimeSpan.Zero : rdr.GetTimeSpan(3);
                TimeSpan endTs = rdr.IsDBNull(4) ? TimeSpan.Zero : rdr.GetTimeSpan(4);

                if (date != DateTime.MinValue)
                {
                    apt.StartTime = date.Date + startTs;
                    apt.EndTime = date.Date + endTs;
                }
                else
                {
                    // fallback
                    apt.StartTime = DateTime.Now;
                    apt.EndTime = DateTime.Now.AddHours(1);
                }

                // Color (stored as name)
                if (!rdr.IsDBNull(5))
                {
                    var colorName = rdr.GetString(5);
                    try
                    {
                        var c = Color.FromName(colorName);
                        apt.Color = c.IsEmpty ? Color.LightBlue : c;
                    }
                    catch
                    {
                        apt.Color = Color.LightBlue;
                    }
                }
                else
                {
                    apt.Color = Color.LightBlue;
                }

                // Description
                if (!rdr.IsDBNull(6))
                    apt.Description = rdr.GetString(6);

                // PetId and PetName (may be null)
                if (!rdr.IsDBNull(9))
                    apt.PetId = rdr.GetInt32(9);
                if (!rdr.IsDBNull(10))
                    apt.PetName = rdr.GetString(10);

                list.Add(apt);
            }

            return list;
        }

        // ⭐ NEW: Save appointment to database
        public static void Save(Calendar.Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            using var conn = new SqlConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO dbo.Appointments 
                (title, appointmentDate, startTime, endTime, color, description, petID, status, createdDate)
                VALUES 
                (@title, @appointmentDate, @startTime, @endTime, @color, @description, @petID, 'Scheduled', GETDATE());";

            cmd.Parameters.Add("@title", SqlDbType.VarChar, 100).Value = (object?)appointment.Title ?? DBNull.Value;
            cmd.Parameters.Add("@appointmentDate", SqlDbType.Date).Value = appointment.StartTime.Date;
            cmd.Parameters.Add("@startTime", SqlDbType.Time).Value = appointment.StartTime.TimeOfDay;
            cmd.Parameters.Add("@endTime", SqlDbType.Time).Value = appointment.EndTime.TimeOfDay;
            cmd.Parameters.Add("@color", SqlDbType.VarChar, 50).Value = appointment.Color.Name ?? "LightBlue";
            cmd.Parameters.Add("@description", SqlDbType.VarChar, 500).Value = (object?)appointment.Description ?? DBNull.Value;
            cmd.Parameters.Add("@petID", SqlDbType.Int).Value = appointment.PetId.HasValue ? (object)appointment.PetId.Value : DBNull.Value;

            cmd.ExecuteNonQuery();
        }

        // ⭐ NEW: Update appointment in database
        public static void Update(Calendar.Appointment appointment)
        {
            if (appointment == null)
                throw new ArgumentNullException(nameof(appointment));

            using var conn = new SqlConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE dbo.Appointments 
                SET title = @title, appointmentDate = @appointmentDate, startTime = @startTime, 
                    endTime = @endTime, color = @color, description = @description, petID = @petID
                WHERE appointmentID = @appointmentID;";

            cmd.Parameters.Add("@appointmentID", SqlDbType.Int).Value = appointment.Id;
            cmd.Parameters.Add("@title", SqlDbType.VarChar, 100).Value = (object?)appointment.Title ?? DBNull.Value;
            cmd.Parameters.Add("@appointmentDate", SqlDbType.Date).Value = appointment.StartTime.Date;
            cmd.Parameters.Add("@startTime", SqlDbType.Time).Value = appointment.StartTime.TimeOfDay;
            cmd.Parameters.Add("@endTime", SqlDbType.Time).Value = appointment.EndTime.TimeOfDay;
            cmd.Parameters.Add("@color", SqlDbType.VarChar, 50).Value = appointment.Color.Name ?? "LightBlue";
            cmd.Parameters.Add("@description", SqlDbType.VarChar, 500).Value = (object?)appointment.Description ?? DBNull.Value;
            cmd.Parameters.Add("@petID", SqlDbType.Int).Value = appointment.PetId.HasValue ? (object)appointment.PetId.Value : DBNull.Value;

            cmd.ExecuteNonQuery();
        }

        // ⭐ NEW: Delete appointment from database
        public static void Delete(int appointmentId)
        {
            using var conn = new SqlConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM dbo.Appointments WHERE appointmentID = @appointmentID;";
            cmd.Parameters.Add("@appointmentID", SqlDbType.Int).Value = appointmentId;

            cmd.ExecuteNonQuery();
        }

        // Return list of pet id/name pairs for the pet search combobox
        public static List<(int Id, string Name)> GetPetNames()
        {
            var list = new List<(int Id, string Name)>();

            using var conn = new SqlConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT petID, petName FROM dbo.petInfo ORDER BY petName;";

            using var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                int id = rdr.IsDBNull(0) ? 0 : rdr.GetInt32(0);
                string name = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1);
                list.Add((id, name));
            }

            return list;
        }
    }
}