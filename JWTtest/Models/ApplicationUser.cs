using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace JWTtest.Models
{
    public class ApplicationUser :IdentityUser

    {
        [System.ComponentModel.DataAnnotations.Required, MaxLength(50)]
        public string FirstName { get; set; }
        [System.ComponentModel.DataAnnotations.Required, MaxLength(50)]

        public string LastName { get; set; }
    }
}
