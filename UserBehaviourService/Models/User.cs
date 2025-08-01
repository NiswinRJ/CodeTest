using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using UserBehaviourAPI;

namespace UserBehaviourAPI.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } =string.Empty;
        [Required]
        public string ContentType { get; set; } =string.Empty;
        [Required]
        [JsonRequired] public DateTime JoiningDate { get; set; }
    }
}

// dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
//dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
//dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0
//dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0-preview.3.efcore.9.0.0