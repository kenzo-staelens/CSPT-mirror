using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Data;
using Globals;
using Mysqlx.Crud;

namespace Logica {
    public class DataPreProcessor {

        private DataLoader _dl;
        public DataPreProcessor() {
            _dl = new();
        }

        public List<Workout> GetWorkouts() {
            return _dl.GetWorkouts();
        }

        public List<Workout> GetWorkouts(List<Workout> allworkouts, Swimmer swimmer) {
            var workouts = (from workout in allworkouts where !workout.Swimmers.Contains(swimmer) select workout).ToList();
            workouts.Sort();
            return workouts;
        }

        public List<Swimmer> GetSwimmers() {
            var swimmers = _dl.GetSwimmers();
            swimmers.Sort();
            return swimmers;
        }

        public void AddSwimmer(Swimmer swimmer) {
            _dl.AddSwimmer(swimmer);
        }

        public void AddWorkout(Workout workout) {
            _dl.AddWorkout(workout);
        }

        public List<Coach> GetCoaches() {
            return _dl.GetCoaches();
        }

        public List<SwimmingPool> GetPools() {
            return _dl.GetSwimmingPools();
        }

        public void Save() {
            _dl.Save();
        }
    }
}
