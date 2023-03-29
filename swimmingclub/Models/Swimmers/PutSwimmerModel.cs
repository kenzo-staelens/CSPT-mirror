using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Swimmers {
    public class PutSwimmerModel : BaseSwimmerModel{
        public Guid Id { get; set; }
        [Required]
        public List<string> RoleNames { get; set; }
    }
}
