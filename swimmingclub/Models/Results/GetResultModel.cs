using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Results {
    public class GetResultModel : BaseResultModel{
        public string SwimmerFirstName { get; set; }
        public string SwimmerLastName { get; set; }
        public string SwimmingPoolName { get; set; }
        public Guid SwimmerId { get; set; }
        public Guid RaceId { get; set; }
        public DateTime Schedule { get; set; }
    }
}
