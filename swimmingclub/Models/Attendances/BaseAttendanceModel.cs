using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Swimmers;
using Models.Workouts;

namespace Models.Attendances {
    public class BaseAttendanceModel {
        [Required]
        public bool Present { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }
    }
}
