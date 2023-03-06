using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Globals;
using SharpRepository.MongoDbRepository;
using SharpRepository.Repository.FetchStrategies;
using System.Runtime.CompilerServices;

namespace Datalaag {
    public class RepoDataLoader {
        private MongoDbRepository<Swimmer> swimmerRepo;
        private MongoDbRepository<Coach> coachRepo;
        private MongoDbRepository<Workout> workoutRepo;
        private MongoDbRepository<SwimmingPool> poolRepo;
        private int _nextSwimmerId;
        private int _nextCoachId;
        private int _nextWorkoutId;
        private int _nextPoolId;

        public RepoDataLoader() {
            BsonClassMap.RegisterClassMap<Coach>();
            BsonClassMap.RegisterClassMap<Swimmer>();
            BsonClassMap.RegisterClassMap<Workout>();
            BsonClassMap.RegisterClassMap<SwimmingPool>();

            swimmerRepo = new MongoDbRepository<Swimmer>("mongodb://localhost/test");
            coachRepo = new MongoDbRepository<Coach>();
            workoutRepo = new MongoDbRepository<Workout>();
            poolRepo = new MongoDbRepository<SwimmingPool>();

            var w = new Workout() { Id = 1, Duration = 5, Coach = null, Schedule = DateTime.Now, Swimmingpool = null, Type = WorkoutType.ENDURANCE };
            var s = new Swimmer() { Id = 6, FirstName = "abc", LastName = "def", DateOfBirth = DateTime.Now, Gender = 'M', FinalPoints = 0, Workouts = new List<Workout>() { w } };
            AddWorkout(w);
            SetAutoIncrements();
        }

        private void SetAutoIncrements() {
            _nextSwimmerId = (from swimmer in GetSwimmers() orderby swimmer.Id descending select swimmer.Id).FirstOrDefault() + 1;
            _nextCoachId = (from swimmer in GetCoaches() orderby swimmer.Id descending select swimmer.Id).FirstOrDefault() + 1;
            _nextWorkoutId = (from swimmer in GetWorkouts() orderby swimmer.Id descending select swimmer.Id).FirstOrDefault() + 1;
            _nextPoolId = (from swimmer in GetSwimmingPools() orderby swimmer.Id descending select swimmer.Id).FirstOrDefault() + 1;
        }

        public List<Swimmer> GetSwimmers() {
            return swimmerRepo.GetAll().ToList();
        }

        public List<Coach> GetCoaches() {
            return coachRepo.GetAll().ToList();
        }

        public List<Workout> GetWorkouts() {
            return workoutRepo.GetAll().ToList();
        }

        public List<SwimmingPool> GetSwimmingPools() {
            return poolRepo.GetAll().ToList();
        }

        public void AddSwimmer(Swimmer swimmer) {
            swimmer.Id = _nextSwimmerId;
            swimmerRepo.Add(swimmer);
            _nextSwimmerId++;
        }

        public void AddWorkout(Workout workout) {
            workout.Id = _nextWorkoutId;
            workoutRepo.Add(workout);
            _nextWorkoutId++;
        }

        public void UpdateSwimmer(Swimmer swimmer) {
            swimmerRepo.Update(swimmer);
        }

        public void UpdateWorkout(Workout workout) {

        }
    }
}
