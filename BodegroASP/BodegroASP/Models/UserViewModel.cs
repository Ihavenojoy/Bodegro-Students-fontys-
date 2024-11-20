using System.ComponentModel.DataAnnotations;

namespace BodegroASP.Models
{
    public class UserViewModel
    {
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public bool IsActive { get; set; }
    }
}
