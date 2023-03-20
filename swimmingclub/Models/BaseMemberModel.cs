using Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {
    public class BaseMemberModel {
        public Guid Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required]
        [RegularExpression(@"^[A-Z][a-z ]+$")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}
