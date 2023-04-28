using LessonTask.Domain.Commons;
using LessonTask.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace LessonTask.Domain.Entities
{
    public class User : Auditable
    {
       public string FirstName { get;set; }
       public string LastName { get;set; }

       [Required]
       public string Email { get;set; }
       [Required]
       public string Password { get;set; }
       public Role UserRole { get; set; } = Role.User;
    }
}
