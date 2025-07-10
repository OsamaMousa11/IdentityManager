using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityManager.Models.IdentityEntityy
{
    public class ApplicationUser:IdentityUser<Guid>
    {
        [Required]
        public string Name { get; set; }
    }
}
