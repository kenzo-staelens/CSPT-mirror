using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities {
    public class Attendance {
        [ForeignKey("Swimmer")]
        [Required]
        public Guid SwimmerId { get; set; }
        public Swimmer Swimmer { get; set; }

        [ForeignKey("Workout")]
        [Required]
        public Guid WorkoutId { get; set; }
        public Workout Workout { get; set; }

        [Required]
        public bool Present { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }
    }
}
