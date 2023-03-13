using Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities {
    public class Workout {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey("Coach")]
        [Required]
        public Guid CoachId { get; set; }
        public Coach Coach { get; set; }

        [ForeignKey("SwimmingPool")]
        [Required]
        public Guid SwimmingPoolId { get; set; }
        public SwimmingPool SwimmingPool { get; set; }

        [Required]
        public DateTime Schedule { get; set; }

        [Required]
        public WorkoutType WorkoutType { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public int Duration { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
    }
}
