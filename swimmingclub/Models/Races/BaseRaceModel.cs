using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.SwimmingPools;
using Models.Results;

namespace Models.Races {
    public class BaseRaceModel {
        //public Guid Id { get; set; }
        //[Required]
        //public Guid SwimmingPoolId { get; set; }
        //[ForeignKey("SwimmingPoolId")]
        //public virtual BaseSwimmingPoolModel SwimmingPool { get; set; }

        [Required]
        public DateTime Schedule { get; set; }

        [Required]
        public Stroke Stroke { get; set; }

        [Required]
        public int Distance { get; set; }

        [Required]
        public AgeCategory AgeCategory { get; set; }

        [Required]
        public Gender Gender { get; set; }

        //public virtual ICollection<BaseResultModel> Results { get; set; }
    }
}
