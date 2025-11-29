using System;
using System.Data;
using System.Data.SqlClient;
using VeterinarySystem.Models;

namespace VeterinarySystem.Data
{
    public static class PetRepository
    {
        // Adjust this connection string only if you want SQL authentication.
        private const string ConnectionString = "Server=localhost\\SQLEXPRESS;Database=VetClinic;Trusted_Connection=True;";

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
    }
}