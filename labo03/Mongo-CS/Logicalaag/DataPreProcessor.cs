using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalaag;
using Globals;

namespace Logicalaag {
    public class DataPreProcessor {
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
            pools.Sort();
            return pools;
        }

        public void AddSwimmer(Swimmer swimmer) {
            _dl.AddSwimmer(swimmer);
        }

        public void AddWorkout(Workout workout) {
            _dl.AddWorkout(workout);
        }
    }
}
