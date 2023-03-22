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
    }
}
