using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Coaches {
    public class PutCoachModel : BaseCoachModel{
        public Guid Id { get; set; }
        [Required]
        public List<string> RoleNames { get; set; }
    }
}
