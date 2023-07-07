using Microsoft.AspNetCore.Identity;

namespace Waitrose.Models
{
    public class AppEmployee : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Salary { get; set; }
        public bool IsDeactive { get; set; }
    }
}
