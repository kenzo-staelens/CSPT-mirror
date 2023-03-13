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
    public class DataLoader {
        private MongoClient _client;
        private IMongoDatabase _db;

        private IMongoCollection<Swimmer> swimmers;
        private IMongoCollection<Coach> coaches;
        private IMongoCollection<Workout> workouts;
        private IMongoCollection<SwimmingPool> swimmingpools;
        private int _nextSwimmerId;
        private int _nextCoachId;
        private int _nextWorkoutId;
        private int _nextPoolId;

        public DataLoader() {
            BsonClassMap.RegisterClassMap<Coach>();
            BsonClassMap.RegisterClassMap<Swimmer>();
            BsonClassMap.RegisterClassMap<Workout>();
            BsonClassMap.RegisterClassMap<SwimmingPool>();

            _client = new MongoClient("mongodb://localhost");
            _db = _client.GetDatabase("test");

           swimmers = _db.GetCollection<Swimmer>("swimmers");
           coaches = _db.GetCollection<Coach>("coaches");
           workouts = _db.GetCollection<Workout>("workouts");
           swimmingpools = _db.GetCollection<SwimmingPool>("swimmingpools");

            var w = new Workout() { Id = 1, Duration = 5, Coach = null, Schedule = DateTime.Now, Swimmingpool = null, Type = WorkoutType.ENDURANCE };
            var s = new Swimmer() { Id = 6, FirstName = "abc", LastName = "def", DateOfBirth = DateTime.Now, Gender = 'M', FinalPoints = 0, Workouts = new List<Workout>() { w } };
            SetAutoIncrements();
            //addSwimmer(s);
            addWorkout(w);
        }

        private void SetAutoIncrements() {
            //dit kon ook met lin
            //verkeerde file
            _nextSwimmerId = (from swimmer in GetSwimmers() orderby swimmer.Id descending select swimmer.Id).FirstOrDefault() + 1;
            _nextCoachId = (from swimmer in GetCoaches() orderby swimmer.Id descending select swimmer.Id).FirstOrDefault() + 1;
            _nextWorkoutId = (from swimmer in GetWorkouts() orderby swimmer.Id descending select swimmer.Id).FirstOrDefault() + 1;
            _nextPoolId = (from swimmer in GetSwimmingPools() orderby swimmer.Id descending select swimmer.Id).FirstOrDefault() + 1;

        }

        public List<Swimmer> GetSwimmers() {
            return swimmers.Find(x => true).ToList();
        }

        public List<Coach> GetCoaches() {
            return coaches.Find(x => true).ToList();
        }
        public List<Workout> GetWorkouts() {
            return workouts.Find(x => true).ToList();
        }
        public List<SwimmingPool> GetSwimmingPools() {
            return swimmingpools.Find(x => true).ToList();
        }

        public void addSwimmer(Swimmer swimmer) {
            swimmer.Id = _nextSwimmerId;
            swimmers.InsertOne(swimmer);
            _nextSwimmerId++;
        }

        public void addWorkout(Workout workout) {
            workout.Id = _nextWorkoutId;
            workouts.InsertOne(workout);
            _nextWorkoutId++;
        }
    }
}
