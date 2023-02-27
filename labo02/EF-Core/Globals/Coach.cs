using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals {
    public class Coach : Member{
        private List<Workout> _workouts = new();

        public CoachLevel Level { get; set; }
        public List<Workout> Workouts { get { return _workouts; } }

        public void AddWorkout(Workout workout) {
            if (workout.Coach == this) return;
            workout.Coach.Workouts.Remove(workout);
            workout.Coach = this;
            
        }

        public void AddWorkouts(List<Workout> workouts) {
            foreach(var workout in workouts) {
                AddWorkout(workout);
            }
        }
    }
}
