using Models.Races;
using Models.Swimmers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Results {
    public class BaseResultModel {
        [RegularExpression(@"^[0-9]{1,2}(:[0-9]{1,2}){2}$")]
        [Required]
        public string CurrentPersonalBest { get; set; }

        [RegularExpression(@"^[0-9]{1,2}(:[0-9]{1,2}){2}$")]
        [Required]
        public string RaceResult { get; set; }
    }
}
