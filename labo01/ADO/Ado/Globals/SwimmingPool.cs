using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals {
    public class SwimmingPool {
        public int id { get; }
        public string Name { get; }
        public string City { get; }
        public int ZipCode { get; }
        public string Street { get; }

        public PoolLaneLength LaneLength { get; }

        public SwimmingPool() {

        }

        public override string ToString() {
            return this.Name;
        }
    }
}
