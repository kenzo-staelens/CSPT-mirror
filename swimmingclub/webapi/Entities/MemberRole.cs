using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities {
    public class MemberRole {
        [ForeignKey("Member")]
        [Required]
        public Guid MemberId { get; set; }
        public Member Member { get; set; }

        [ForeignKey("Role")]
        [Required]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
