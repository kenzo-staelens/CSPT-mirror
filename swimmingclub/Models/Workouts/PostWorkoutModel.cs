using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Workouts {
    public class PostWorkoutModel : BaseWorkoutModel{
        [Required]
        public Guid SwimmingPoolId { get; set; }

        [Required]
        public Guid CoachId { get; set; }
    }
}
