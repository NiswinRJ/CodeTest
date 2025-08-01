using UserBehaviourAPI;

namespace UserBehaviourAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Email { get; set; } 
        public string ContentType { get; set; } 
        public DateTime JoiningDate { get; set; }
    }
}

// dotnet add package Microsoft.EntityFrameworkCore --version 9.0.0
//dotnet add package Microsoft.EntityFrameworkCore.Design --version 9.0.0
//dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.0
//dotnet add package Pomelo.EntityFrameworkCore.MySql --version 9.0.0-preview.3.efcore.9.0.0