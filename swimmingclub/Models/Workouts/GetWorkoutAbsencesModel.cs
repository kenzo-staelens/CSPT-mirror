using Models.Attendances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Workouts {
    public class GetWorkoutAbsencesModel : BaseWorkoutModel{
        public List<GetAttendanceModel> Absences { get; set; }
    }
}
