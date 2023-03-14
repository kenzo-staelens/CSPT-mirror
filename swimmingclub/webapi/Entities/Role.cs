using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace webapi.Entities {
    public class Role : IdentityRole<Guid>{
        
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string Description { get; set; }

        public virtual ICollection<MemberRole> MemberRoles { get; set; }
    }
}
