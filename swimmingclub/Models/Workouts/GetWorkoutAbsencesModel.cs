using Models.Attendances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Workouts {
    public class GetWorkoutAbsencesModel{
        public DateTime Schedule { get; set; }
        public string CoachFirstName { get; set; }
        public string CoachLastName { get; set; }
        public List<string> SwimmerNames { get; set; }
    }
}
