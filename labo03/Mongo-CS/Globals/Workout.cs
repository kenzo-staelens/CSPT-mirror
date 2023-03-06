using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Globals {
    public class Workout : IComparable{
        public int Id { get; set; }
        public Coach Coach {get; set;}
        public int Duration { get; set; }
        public DateTime Schedule { get; set; }
        public SwimmingPool Swimmingpool { get; set; }
        public WorkoutType Type { get; set; }

        public override string ToString() {
            return $"{Type} sessie [{Duration}'] in {Swimmingpool} op {Schedule}";
        }

        public int CompareTo(object? obj) {
            Workout workout2 = obj as Workout;
            if (workout2 != null) return this.Schedule.CompareTo(workout2.Schedule);
            else return 1;
        }

        public bool Equals(Workout other) {
            if (other == null) return false;
            if (this.Id == other.Id) return true;
            return false;
        }
    }
}
