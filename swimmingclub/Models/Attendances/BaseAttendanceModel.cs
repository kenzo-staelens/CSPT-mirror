using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Swimmers;
using Models.Workouts;

namespace Models.Attendances {
    public class BaseAttendanceModel {
        public Guid Id { get; set; }

        [Required]
        public Guid SwimmerId { get; set; }
        [ForeignKey("SwimmerId")]

        public virtual BaseSwimmerModel Swimmer { get; set; }

        [Required]
        public Guid WorkoutId { get; set; }
        [ForeignKey("WorkoutId")]
        public virtual BaseWorkoutModel Workout { get; set; }

        [Required]
        public bool Present { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }
    }
}
