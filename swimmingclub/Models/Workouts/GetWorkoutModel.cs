using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Workouts {
    public class GetWorkoutModel : BaseWorkoutModel {
        public string CoachFirstName { get; set; }
        public string CoachLastName { get; set; }
        public string SwimmingPoolName { get; set; }
        public Guid Id { get; set; }
    }
}
