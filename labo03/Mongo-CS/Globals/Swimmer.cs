using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals {
    public class Swimmer : Member {
        private List<Workout> _workouts = new();

        public int FinalPoints { get; set; }
        public List<Workout> Workouts { get { return _workouts; } set{_workouts=value;} }
    }
}
