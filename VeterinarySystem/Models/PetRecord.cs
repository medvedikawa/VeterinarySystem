using System;

namespace VeterinarySystem.Models
{
    public class PetRecord
    {
        public int PetID { get; set; }
        public string? PetName { get; set; }
        public string? PetSpecies { get; set; }
        public string? PetBreed { get; set; }
        public string? PetGender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? PetAge { get; set; }
        public decimal? PetWeight { get; set; }
        public string? MedicalHistory { get; set; }
        public byte[]? PetImage { get; set; }
        public string? OwnerName { get; set; }
        public string? Address { get; set; }
        public string? ContactNo { get; set; }
        public bool IsActive { get; set; } = true;
    }
}