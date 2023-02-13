using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals {
    public class Coach : Member{
        private List<Workout> workouts;
        public List<Workout> Workouts { get {
                return workouts;
            }
        }

        public CoachLevel Level { get; }

        public Coach(int id, DateTime dateOfBirth, string firstName, string lastName, char gender, CoachLevel level)
            : base(id, dateOfBirth, firstName, lastName,gender) {
            this.workouts= new List<Workout>();
            this.Level = level;
            Console.WriteLine(firstName);
        }

        public void addWorkout(Workout workout) {
            this.workouts.Add(workout);
        }

        public void addWorkouts(List<Workout> workouts) {
            foreach(Workout workout in workouts) {
                this.workouts.Add(workout);
            }
        }
    }
}
