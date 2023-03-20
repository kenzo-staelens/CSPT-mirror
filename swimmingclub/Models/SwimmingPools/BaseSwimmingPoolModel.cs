using Enums;
using Models.Races;
using Models.Workouts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SwimmingPools {
    public class BaseSwimmingPoolModel {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        public string Street { get; set; }

        [StringLength(50)]
        [Required]
        public string City { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public LaneLength LaneLength { get; set; }

        public virtual ICollection<BaseWorkoutModel> Workouts { get; set; }
        public virtual ICollection<BaseRaceModel> Races { get; set; }
    }
}
