using System.ComponentModel.DataAnnotations;

namespace JWTtest.Models
{
    public class AddRoleModel
    {
        [Required]
        public string User_Id { get; set; }
        [Required]

        public string Role { get; set; }
    }
}
