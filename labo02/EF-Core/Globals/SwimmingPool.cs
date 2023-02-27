using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals {
    public class SwimmingPool {
        public int Id { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Name { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string City { get; set; }

        public int ZipCode { get; set; }

        [Column(TypeName = "varchar(45)")]
        public string Street { get; set; }
        public PoolLaneLength LaneLength { get; set; }

        public override string ToString() {
            return this.Name;
        }
    }
}
