using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Globals;
using SharpRepository.MongoDbRepository;

namespace Datalaag {
    public class RepoDataLoader {
        //private MongoClient _client;
        //private IMongoDatabase _db;
        //private IMongoCollection<Swimmer> swimmers;
        //private IMongoCollection<Workout> workouts;

        private MongoDbRepository<Swimmer,int> swimmerRepo;
        private MongoDbRepository<Coach,int> coachRepo;
        private MongoDbRepository<Workout,int> workoutRepo;
        private MongoDbRepository<SwimmingPool,int> poolRepo;
        private int _nextSwimmerId;
        private int _nextCoachId;
        private int _nextWorkoutId;
        private int _nextPoolId;

        public RepoDataLoader() {
            BsonClassMap.RegisterClassMap<Coach>();
            BsonClassMap.RegisterClassMap<Swimmer>();
            BsonClassMap.RegisterClassMap<Workout>();
            BsonClassMap.RegisterClassMap<SwimmingPool>();

            //string conString = "mongodb://localhost/test";
            string conString = "mongodb+srv://kenzostael:ODhp5AzGaFdNmNbt@cluster0.s6xuzvf.mongodb.net/test";

            //_client = new MongoClient("mongodb://localhost");
            //_db = _client.GetDatabase("test");
            //swimmers = _db.GetCollection<Swimmer>("Swimmer");
            //workouts = _db.GetCollection<Workout>("Workout");

            try {
                swimmerRepo = new MongoDbRepository<Swimmer, int>(conString);
                coachRepo = new MongoDbRepository<Coach, int>(conString);
                workoutRepo = new MongoDbRepository<Workout, int>(conString);
                poolRepo = new MongoDbRepository<SwimmingPool, int>(conString);
                SetAutoIncrements();
            }
            catch (Exception ex) {
                conString = "mongodb://localhost/test";
                swimmerRepo = new MongoDbRepository<Swimmer, int>(conString);
                coachRepo = new MongoDbRepository<Coach, int>(conString);
                workoutRepo = new MongoDbRepository<Workout, int>(conString);
                poolRepo = new MongoDbRepository<SwimmingPool, int>(conString);
                SetAutoIncrements();
            }
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
            //var filter = Builders<Swimmer>.Filter.Eq(s => s.Id, swimmer.Id);
            //swimmers.ReplaceOne(filter,swimmer);
            swimmerRepo.Update(swimmer);
        }
        public void UpdateSwimmers(List<Swimmer> swimmerlist) {
            foreach (var swimmer in swimmerlist) {
                UpdateSwimmer(swimmer);

            }
        }

        public void UpdateWorkout(Workout workout) {
            //var filter = Builders<Workout>.Filter.Eq(s => s.Id, workout.Id);
            //workouts.ReplaceOne(filter, workout);
            workoutRepo.Update(workout);
        }
    }
}
