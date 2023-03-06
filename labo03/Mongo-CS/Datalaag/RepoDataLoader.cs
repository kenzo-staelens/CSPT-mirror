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

            string conString = "mongodb://localhost/test";

            swimmerRepo = new MongoDbRepository<Swimmer>(conString);
            coachRepo = new MongoDbRepository<Coach>(conString);
            workoutRepo = new MongoDbRepository<Workout>(conString);
            poolRepo = new MongoDbRepository<SwimmingPool>(conString);
            SetAutoIncrements();

            var p = new SwimmingPool() { City = "c" , Id=1, LaneLength=PoolLaneLength._50, Name="name", Street="street", ZipCode=1001};
            var c = new Coach() { Id = 1, DateOfBirth = DateTime.Now, FirstName = "c", LastName = "last", Gender = 'F', Level = CoachLevel.INITIATOR };
            var w = new Workout() { Id = 1, Duration = 5, Coach = c, Schedule = DateTime.Now, Swimmingpool = p, Type = WorkoutType.ENDURANCE };
            var s = new Swimmer() { Id = 6, FirstName = "abc", LastName = "def", DateOfBirth = DateTime.Now, Gender = 'M', FinalPoints = 0, Workouts = new List<Workout>() { w } };
            
            //AddWorkout(w);
            //AddSwimmer(s);
            //AddSwimmingPool(p);
            //AddCoach(c);

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

        public void AddCoach(Coach coach) {
            coach.Id = _nextCoachId;
            coachRepo.Add(coach);
            _nextCoachId++;
        }

        public void AddSwimmingPool(SwimmingPool pool) {
            pool.Id = _nextPoolId;
            poolRepo.Add(pool);
            _nextPoolId++;
        }

        public void UpdateSwimmer(Swimmer swimmer) {
            swimmerRepo.Update(swimmer);
        }

        public void UpdateWorkout(Workout workout) {
            workoutRepo.Update(workout);
        }
    }
}
