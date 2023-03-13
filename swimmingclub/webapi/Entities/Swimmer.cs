using System.ComponentModel.DataAnnotations;

namespace webapi.Entities {
    public class Swimmer : Member{
        [Required]
        public int FinalPoints { get; set; }

        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}
