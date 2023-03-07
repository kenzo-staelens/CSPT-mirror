using Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logicalaag {
    public interface IDataPreProcessor {
        public List<Swimmer> GetSwimmers();
        public List<Workout> GetWorkouts();
        public void MergeWorkouts(List<Swimmer> swimmers, List<Workout> workouts);
        public List<Workout> GetWorkouts(List<Workout> allworkouts, Swimmer swimmer);
        public List<Coach> GetCoaches();
        public List<SwimmingPool> GetPools();
        public void AddSwimmer(Swimmer swimmer);
        public void AddWorkout(Workout workout);
        public void UpdateSwimmer(Swimmer swimmer);
        public void UpdateSwimmers(List<Swimmer> swimmers);
        public void UpdateWorkout(Workout workout);
    }
}
