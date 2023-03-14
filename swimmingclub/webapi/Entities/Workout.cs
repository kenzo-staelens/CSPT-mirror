using Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities {
    public class Workout {
        [Required]
        public Guid Id { get; set; }


        [Required]
        public virtual Coach Coach { get; set; }

        [Required]
        public SwimmingPool SwimmingPool { get; set; }

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
