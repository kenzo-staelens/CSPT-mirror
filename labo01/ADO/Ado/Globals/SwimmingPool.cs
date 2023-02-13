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

        public SwimmingPool(int id, string name, string city, string street, int zipcode, PoolLaneLength length) {
            this.id = id;
            this.Name = name;
            this.City = city;
            this.Street = street;
            this.ZipCode = zipcode;
            this.LaneLength = length;
        }

        public override string ToString() {
            return this.Name;
        }
    }
}
