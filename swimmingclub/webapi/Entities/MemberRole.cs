using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities {
    public class MemberRole : IdentityUserRole<Guid>{
        public virtual Member Member { get; set; }
        public virtual Role Role { get; set; }

    }
}
