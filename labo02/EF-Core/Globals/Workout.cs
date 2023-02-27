using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Globals {
    public class Workout {
        public int Id { get; set; }
        public Coach Coach {get; set;}
        public int Duration { get; set; }
        public DateTime Schedule { get; set; }
        public SwimmingPool Swimmingpool { get; set; }
        public WorkoutType Type { get; set; }
        public List<Swimmer> Swimmers { get; } = new();

        public void addSwimmer(Swimmer swimmer) {
            foreach(var _swimmer in Swimmers) {
                if (_swimmer.Equals(swimmer)) return;
            }
            Swimmers.Add(swimmer);
        }

        public void addSwimmers(List<Swimmer> swimmers) {
            foreach(var swimmer in swimmers) {
                addSwimmer(swimmer);
            }
        }

        public override string ToString() {
            return $"{Type} sessie [{Duration}'] in {Swimmingpool} op {Schedule}";
        }

        public int CompareTo(object? obj) {
            Workout workout2 = obj as Workout;
            if (workout2 != null) return this.Schedule.CompareTo(workout2.Schedule);
            else return 1;
        }
    }
}
