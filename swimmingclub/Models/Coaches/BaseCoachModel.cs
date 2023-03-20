using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using Models.Workouts;

namespace Models.Coaches {
    public class BaseCoachModel : BaseMemberModel {
        
        [Required]
        public Level Level { get; set; }

        public virtual ICollection<BaseWorkoutModel> Workouts { get; set; }
    }
}
