using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals {
    public class Swimmer : Member{
        private List<Workout> workouts;
        public List<Workout> Workouts {
            get {
                return workouts;
            }
        }

        public int FinalPoints { get; set; }

        public Swimmer() { }

        public void addWorkout(Workout workout) {
            this.workouts.Add(workout);
        }

        public void addWorkouts(List<Workout> workouts) {
            foreach (Workout workout in workouts) {
                this.workouts.Add(workout);
            }
        }
    }
}
