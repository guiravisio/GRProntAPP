using Microsoft.AspNetCore.Identity;
using System;

namespace GRProntAPP.Models
{
    public class UserProfile : IdentityUser
    {
        public required string FullName { get; set; }
        public required string Role { get; set; } // Admin, Doctor, User
        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
