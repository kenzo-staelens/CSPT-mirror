using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Datalaag;
using Globals;

namespace Logicalaag {
    public class DataPreProcessor : IDataPreProcessor{
        private RepoDataLoader _dl;
        public DataPreProcessor() {
            _dl = new RepoDataLoader();
        }

        public List<Swimmer> GetSwimmers() {
            var swimmers  = _dl.GetSwimmers();
            swimmers.Sort();
            return swimmers;
        }

        public List<Workout> GetWorkouts() {
            var workouts = _dl.GetWorkouts();
            workouts.Sort();
            return workouts;
        }

        public void MergeWorkouts(List<Swimmer> swimmers, List<Workout> workouts) {
            //hier waren wat issues met references
            foreach (var swimmer in swimmers) {
                foreach (var workout in workouts) {
                    for (int i = 0; i < swimmer.Workouts.Count(); i++) {
                        if (swimmer.Workouts[i].Equals(workout)) swimmer.Workouts[i] = workout;
                    }
                }
            }
        }

        public List<Workout> GetWorkouts(List<Workout> allworkouts, Swimmer swimmer) {
            var workouts = (from workout in allworkouts where !swimmer.Workouts.Contains(workout) select workout).ToList();
            workouts.Sort();
            return workouts;
        }

        public List<Coach> GetCoaches() {
            var coaches = _dl.GetCoaches();
            coaches.Sort();
            return coaches;
        }

        public List<SwimmingPool> GetPools() {
            var pools = _dl.GetSwimmingPools();
            return pools;
        }

        public void AddSwimmer(Swimmer swimmer) {
            _dl.AddSwimmer(swimmer);
        }

        public void AddWorkout(Workout workout) {
            _dl.AddWorkout(workout);
        }

        public void UpdateSwimmer(Swimmer swimmer) {
            _dl.UpdateSwimmer(swimmer);
        }

        public void UpdateSwimmers(List<Swimmer> swimmers) {
            _dl.UpdateSwimmers(swimmers);
        }

        public void UpdateWorkout(Workout workout) {
            _dl.UpdateWorkout(workout);
        }
    }
}
