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
        public Guid CoachId { get; set; }
        [ForeignKey("CoachId")]
        public virtual BaseCoachModel Coach { get; set; }

        [Required]
        public  Guid SwimmingPoolId { get; set; }
        [ForeignKey("SwimmingPoolId")]
        public BaseSwimmerModel SwimmingPool { get; set; }

        [Required]
        public DateTime Schedule { get; set; }

        [Required]
        public WorkoutType WorkoutType { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int Duration { get; set; }

        public virtual ICollection<BaseAttendanceModel> Attendances { get; set; }
    }
}
