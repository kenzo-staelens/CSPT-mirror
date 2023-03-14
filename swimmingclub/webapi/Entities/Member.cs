using System.ComponentModel.DataAnnotations;
using Enums;
using Microsoft.AspNetCore.Identity;

namespace webapi.Entities {
    public abstract class Member : IdentityUser<Guid> {

        [StringLength(50, MinimumLength = 2)]
        [Required]
        [RegularExpression(@"^[A-Z][a-z ]+$")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public virtual ICollection<MemberRole> MemberRoles { get; set; }
    }
}
