using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals {
    public class Workout : IComparable{

        public int Id { get; }
        public Coach Coach { get;}
        public int Duration { get; }
        public DateTime Schedule { get; }
        public SwimmingPool SwimmingPool { get; }
        public WorkoutType Type { get; }

        public int CompareTo(object? obj) {
            throw new NotImplementedException();
        }

        public override string ToString() {
            return $"{Type} sessie [{Duration}'] in {SwimmingPool} op {Schedule}";
        }
    }
}
