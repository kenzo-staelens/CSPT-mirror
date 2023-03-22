using Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities {
    public class Workout {
        [Required]
        public Guid Id { get; set; }


        [Required]
        [ForeignKey("Coach")]
        public Guid CoachId { get; set; }
        public virtual Coach Coach { get; set; }

        [Required] //dit is blijkbaar nog een navigation
        [ForeignKey("SwimmingPool")]
        public Guid SwimmingPoolId { get; set; }
        public virtual SwimmingPool SwimmingPool { get; set; }

        [Required]
        public DateTime Schedule { get; set; }

        [Required]
        public WorkoutType WorkoutType { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int Duration { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
