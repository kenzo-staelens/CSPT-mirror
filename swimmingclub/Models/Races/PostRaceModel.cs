using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.Races {
    public class PostRaceModel : BaseRaceModel{
        [Required]
        public Guid SwimmingPoolId { get; set; }
    }
}
