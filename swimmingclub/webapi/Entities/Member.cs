using System.ComponentModel.DataAnnotations;
using Enums;

namespace webapi.Entities {
    public abstract class Member {

        [Key]
        [Required]
        public Guid Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required]
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
