using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Waitrose.Models
{
    public class AppUser : IdentityUser
    {
        public bool IsDeactive { get; set; }
    }
}
