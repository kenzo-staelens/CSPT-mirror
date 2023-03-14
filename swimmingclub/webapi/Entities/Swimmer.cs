using System.ComponentModel.DataAnnotations;

namespace webapi.Entities {
    public class Swimmer : Member{
        [Required]
        public int FinalPoints { get; set; }

        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
