using Enums;
using Models.Attendances;
using Models.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Swimmers {
    public class BaseSwimmerModel : BaseMemberModel {
        [Required]
        public int FinalPoints { get; set; }
    }
}
