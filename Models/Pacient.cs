using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GRProntAPP.Models
{
    public class Patient
    {
        public Patient()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsActive = true;
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [MaxLength(20)]
        public string? Gender { get; set; }

        [Required]
        [MaxLength(20)]
        public string? CPF { get; set; }

        [MaxLength(50)]
        public string? RG { get; set; }

        [EmailAddress]
        [MaxLength(200)]
        public string Email { get; set; }

        [Phone]
        [MaxLength(50)]
        public string Mobile { get; set; }

        // Endereço
        [MaxLength(200)]
        public string? Street { get; set; }

        [MaxLength(20)]
        public string? Number { get; set; }

        [MaxLength(100)]
        public string? Complement { get; set; }

        [MaxLength(100)]
        public string? Neighborhood { get; set; }

        [MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(100)]
        public string? State { get; set; }

        [MaxLength(20)]
        public string? ZipCode { get; set; }

        [MaxLength(100)]
        public string? EmergencyContactName { get; set; }

        [Phone]
        [MaxLength(50)]
        public string? EmergencyContactPhone { get; set; }

        [MaxLength(100)]
        public string? Occupation { get; set; }

        [MaxLength(50)]
        public string? Nationality { get; set; }

        // Informações médicas
        [MaxLength(3)]
        public string? BloodType { get; set; }

        public string? Allergies { get; set; }

        public string? MedicalHistory { get; set; }

        [MaxLength(200)]
        public string? InsuranceProvider { get; set; }

        public string? Notes { get; set; }

        // Auditoria
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
