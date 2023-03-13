using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities {
    public class Result {
        [ForeignKey("Swimmer")]
        [Required]
        public Guid SwimmerId { get; set; }
        public Swimmer Swimmer { get; set; }

        [ForeignKey("Race")]
        [Required]
        public Guid RaceId { get; set; }
        public Race Race { get; set; }

        [RegularExpression(@"^[0-9]{1,2}(:[0-9]{1,2}){2}$")]
        [Required]
        public string CurrentPersonalBest { get; set; }

        [RegularExpression(@"^[0-9]{1,2}(:[0-9]{1,2}){2}$")]
        [Required]
        public string RaceResult { get; set; }
    }
}
