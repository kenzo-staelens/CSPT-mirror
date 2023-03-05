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
            BsonClassMap.RegisterClassMap<Member>();
            BsonClassMap.RegisterClassMap<Workout>();
            BsonClassMap.RegisterClassMap<SwimmingPool>();
            _client = new MongoClient("mongodb://localhost");
            _db = _client.GetDatabase("test");
        }


    }
}
