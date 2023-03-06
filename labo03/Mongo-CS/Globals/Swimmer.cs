using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals {
    public class Swimmer : Member {
        private List<Workout> _workouts = new();

        public int FinalPoints { get; set; }
        public List<Workout> Workouts { get { return _workouts; } set{_workouts=value;} }

        public void addWorkout(Workout workout) {
            foreach (var _workout in Workouts) {
                if (workout.Equals(_workout)) return;
            }
            Workouts.Add(workout);
        }

        public void addWorkouts(List<Workout> workouts) {
            foreach (var workout in workouts) {
                addWorkout(workout);
            }
        }
    }
}
