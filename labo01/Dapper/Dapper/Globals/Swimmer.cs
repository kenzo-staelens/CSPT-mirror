using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

        public Swimmer(int id, DateTime dateOfBirth, string firstName, string lastName, char gender, int points) : base(id, dateOfBirth, firstName, lastName, gender) {
            this.workouts = new List<Workout>();
            this.FinalPoints = points;
        }

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
