using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities {
    public class Result {
        [Required]
        public Guid SwimmerId { get; set; }
        public virtual Swimmer Swimmer { get; set; }
        

        [Required]
        public Guid RaceId { get; set; }
        public virtual Race Race { get; set; }

        [RegularExpression(@"^[0-9]{1,2}(:[0-9]{1,2}){2}$")]
        [Required]
        public string CurrentPersonalBest { get; set; }

        [RegularExpression(@"^[0-9]{1,2}(:[0-9]{1,2}){2}$")]
        [Required]
        public string RaceResult { get; set; }
    }
}
