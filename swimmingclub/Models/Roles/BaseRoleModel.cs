using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Roles {
    public class BaseRoleModel {
        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string Description { get; set; }
    }
}
