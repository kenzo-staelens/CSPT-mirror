using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Globals;

namespace Datalaag {
    public class DataLoader {
        private MongoClient _client;
        private IMongoDatabase _db;
        public DataLoader() {
            BsonClassMap.RegisterClassMap<Coach>();
            BsonClassMap.RegisterClassMap<Swimmer>();
            BsonClassMap.RegisterClassMap<Workout>();
            BsonClassMap.RegisterClassMap<SwimmingPool>();
            _client = new MongoClient("mongodb://localhost");
            _db = _client.GetDatabase("test");
            IMongoCollection<Swimmer> swimmers = _db.GetCollection<Swimmer>("swimmers");
            var w = new Workout() { Id=1,Duration=5,Coach=null, Schedule=DateTime.Now, Swimmingpool=null, Type=WorkoutType.ENDURANCE};
            var s = new Swimmer() { FirstName="abc", LastName="def", DateOfBirth = DateTime.Now, Gender='M', FinalPoints=0,Workouts=new List<Workout>() { w }, Id=1};
            swimmers.InsertOne(s);
            var t = swimmers.Find(x=>true).Single();
            Console.WriteLine($"{t.FirstName} {t.LastName} {t.DateOfBirth} {t.Gender} {t.FinalPoints} {t.Id} \n");
            Console.WriteLine($"{t.Workouts[0].Id} {t.Workouts[0].ToString()}");
        }


    }
}
