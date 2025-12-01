using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using VeterinarySystem.Models;

namespace VeterinarySystem.Data
{
    public static class PetRepository
    {
        // Using Microsoft.Data.SqlClient with TrustServerCertificate enabled
        private const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=VetClinic;Trusted_Connection=True;TrustServerCertificate=True;Connection Timeout=60;";

        public static void Save(PetRecord pet)
        {
            if (pet == null) throw new ArgumentNullException(nameof(pet));

            using var conn = new SqlConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText =
                @"INSERT INTO petInfo
                  (petName, petSpecies, petBreed, petGender, dateOfBirth, petAge, petWeight, medicalHistory, petImage, ownerName, address, contactNo, isActive)
                  VALUES
                  (@petName, @petSpecies, @petBreed, @petGender, @dateOfBirth, @petAge, @petWeight, @medicalHistory, @petImage, @ownerName, @address, @contactNo, @isActive);";

            cmd.Parameters.Add("@petName", SqlDbType.VarChar, 50).Value = (object?)pet.PetName ?? DBNull.Value;
            cmd.Parameters.Add("@petSpecies", SqlDbType.VarChar, 10).Value = (object?)pet.PetSpecies ?? DBNull.Value;
            cmd.Parameters.Add("@petBreed", SqlDbType.VarChar, 100).Value = (object?)pet.PetBreed ?? DBNull.Value;
            cmd.Parameters.Add("@petGender", SqlDbType.VarChar, 10).Value = (object?)pet.PetGender ?? DBNull.Value;
            cmd.Parameters.Add("@dateOfBirth", SqlDbType.Date).Value = (object?)pet.DateOfBirth ?? DBNull.Value;
            cmd.Parameters.Add("@petAge", SqlDbType.SmallInt).Value = (object?)pet.PetAge ?? DBNull.Value;
            cmd.Parameters.Add("@petWeight", SqlDbType.Float).Value = (object?)pet.PetWeight ?? DBNull.Value;
            cmd.Parameters.Add("@medicalHistory", SqlDbType.NVarChar).Value = (object?)pet.MedicalHistory ?? DBNull.Value;
            cmd.Parameters.Add("@petImage", SqlDbType.VarBinary).Value = (object?)pet.PetImage ?? DBNull.Value;
            cmd.Parameters.Add("@ownerName", SqlDbType.VarChar, 100).Value = (object?)pet.OwnerName ?? DBNull.Value;
            cmd.Parameters.Add("@address", SqlDbType.VarChar, 200).Value = (object?)pet.Address ?? DBNull.Value;
            cmd.Parameters.Add("@contactNo", SqlDbType.VarChar, 20).Value = (object?)pet.ContactNo ?? DBNull.Value;
            cmd.Parameters.Add("@isActive", SqlDbType.Bit).Value = pet.IsActive;

            cmd.ExecuteNonQuery();
        }

        // ⭐ FIX: Ensure GetRecentPets handles edge cases
        public static List<PetRecord> GetRecentPets(int count = 4)
        {
            var list = new List<PetRecord>();

            try
            {
                using var conn = new SqlConnection(ConnectionString);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = $@"
                    SELECT TOP {count} 
                        petID, petName, petSpecies, petBreed, petGender, dateOfBirth, 
                        petAge, petWeight, medicalHistory, petImage, ownerName, address, 
                        contactNo, isActive
                    FROM dbo.petInfo
                    ORDER BY petID DESC;";

                using var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    var pet = new PetRecord
                    {
                        PetID = rdr.GetInt32(0),
                        PetName = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                        PetSpecies = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2),
                        PetBreed = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3),
                        PetGender = rdr.IsDBNull(4) ? string.Empty : rdr.GetString(4),
                        DateOfBirth = rdr.IsDBNull(5) ? (DateTime?)null : rdr.GetDateTime(5),
                        PetAge = rdr.IsDBNull(6) ? (int?)null : rdr.GetInt16(6),
                        PetWeight = rdr.IsDBNull(7) ? (decimal?)null : (decimal)rdr.GetDouble(7),
                        MedicalHistory = rdr.IsDBNull(8) ? string.Empty : rdr.GetString(8),
                        PetImage = rdr.IsDBNull(9) ? null : (byte[])rdr.GetValue(9),
                        OwnerName = rdr.IsDBNull(10) ? string.Empty : rdr.GetString(10),
                        Address = rdr.IsDBNull(11) ? string.Empty : rdr.GetString(11),
                        ContactNo = rdr.IsDBNull(12) ? string.Empty : rdr.GetString(12),
                        IsActive = rdr.IsDBNull(13) ? true : rdr.GetBoolean(13)
                    };
                    list.Add(pet);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading recent pets: {ex.Message}");
            }

            return list;
        }
        public static PetRecord GetById(int petID)
        {
            using var conn = new SqlConnection(ConnectionString);
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
        SELECT petID, petName, petSpecies, petBreed, petGender, dateOfBirth, 
               petAge, petWeight, medicalHistory, petImage, ownerName, address, 
               contactNo, isActive
        FROM dbo.petInfo
        WHERE petID = @petID;";

            cmd.Parameters.Add("@petID", SqlDbType.Int).Value = petID;

            using var rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                return new PetRecord
                {
                    PetID = rdr.GetInt32(0),
                    PetName = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                    PetSpecies = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2),
                    PetBreed = rdr.IsDBNull(3) ? string.Empty : rdr.GetString(3),
                    PetGender = rdr.IsDBNull(4) ? string.Empty : rdr.GetString(4),
                    DateOfBirth = rdr.IsDBNull(5) ? (DateTime?)null : rdr.GetDateTime(5),
                    PetAge = rdr.IsDBNull(6) ? (int?)null : rdr.GetInt16(6),
                    PetWeight = rdr.IsDBNull(7) ? (decimal?)null : (decimal)rdr.GetDouble(7),
                    MedicalHistory = rdr.IsDBNull(8) ? string.Empty : rdr.GetString(8),
                    PetImage = rdr.IsDBNull(9) ? null : (byte[])rdr.GetValue(9),
                    OwnerName = rdr.IsDBNull(10) ? string.Empty : rdr.GetString(10),
                    Address = rdr.IsDBNull(11) ? string.Empty : rdr.GetString(11),
                    ContactNo = rdr.IsDBNull(12) ? string.Empty : rdr.GetString(12),
                    IsActive = rdr.IsDBNull(13) ? true : rdr.GetBoolean(13)
                };
            }
            return null;
        }
        public static List<PetRecord> GetAllActivePets()
        {
            var list = new List<PetRecord>();

            try
            {
                using var conn = new SqlConnection(ConnectionString);
                conn.Open();

                using var cmd = conn.CreateCommand();
                cmd.CommandText = @"
            SELECT petID, petName, ownerName
            FROM dbo.petInfo
            WHERE isActive = 1
            ORDER BY petName;";  // Alphabetical order!

                using var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    var pet = new PetRecord
                    {
                        PetID = rdr.GetInt32(0),
                        PetName = rdr.IsDBNull(1) ? string.Empty : rdr.GetString(1),
                        OwnerName = rdr.IsDBNull(2) ? string.Empty : rdr.GetString(2)
                    };
                    list.Add(pet);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading pets: {ex.Message}");
            }

            return list;
        }
    }
}