using System.ComponentModel.DataAnnotations;

namespace webapi.Entities {
    public class Role {
        
        [Key]
        [Required]
        public Guid Id { get; set; }
        
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string Description { get; set; }

        public ICollection<MemberRole> MemberRoles { get; set; }
    }
}
