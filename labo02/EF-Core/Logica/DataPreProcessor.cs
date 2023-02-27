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

        private List<Workout> GetWorkouts() {
            var workouts = _dl.GetWorkouts();
            var coaches = _dl.GetCoaches();
            return null;
        }

        public List<Swimmer> GetSwimmers() {
            var swimmers = _dl.GetSwimmers();
            
            return swimmers;
        }
    }
}
