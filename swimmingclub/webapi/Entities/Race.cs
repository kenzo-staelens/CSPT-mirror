using Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.Entities {
    public class Race {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [ForeignKey("SwimmingPool")]
        [Required]
        public Guid SwimmingPoolId { get; set; }
        public SwimmingPool SwimmingPool { get; set; }

        [Required]
        public DateTime Schedule { get; set; }

        [Required]
        public Stroke Stroke { get; set; }

        [Required]
        public int Distance { get; set; }

        [Required]
        public AgeCategory AgeCategory { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public ICollection<Result> Results { get; set; }
    }
}
