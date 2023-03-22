using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Attendances {
    public class GetAttendanceModel : BaseAttendanceModel{
        public Guid SwimmerId { get; set; }
        public Guid WorkoutId { get; set; }
        public string SwimmerFirstName { get; set; }//?
        public string SwimmerLastName { get; set; }//?
        public string SwimmingPoolName { get; set; }
        public DateTime Schedule { get; set; }
    }
}
