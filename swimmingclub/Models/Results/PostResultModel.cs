using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Results {
    public  class PostResultModel : BaseResultModel{
        [Required]
        public Guid SwimmerId { get; set; }
        [Required]
        public Guid RaceId { get; set; }
    }
}
