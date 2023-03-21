using Enums;
using Models.Attendances;
using Models.Coaches;
using Models.Swimmers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Workouts {
    public class BaseWorkoutModel {
        [Required]
        public string CoachFirstName { get; set; }
        [Required]
        public string CoachLastName { get; set; }

        [Required]
        public string SwimmingPoolName { get; set; }

        [Required]
        public DateTime Schedule { get; set; }

        [Required]
        public WorkoutType WorkoutType { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int Duration { get; set; }
    }
}
