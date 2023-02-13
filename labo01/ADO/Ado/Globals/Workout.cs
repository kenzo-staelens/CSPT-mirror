using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals {
    public class Workout : IComparable {

        private int _coachid;
        private Coach? _coach;
        public int Id { get; }
        public Coach Coach {
            get {
                return this._coach;
            }
            set {
                if (value.Id == _coachid) {
                    _coach = value;
                }
            }
        }
        public int Duration { get; }
        public DateTime Schedule { get; }
        public SwimmingPool Swimmingpool { get; }
        public WorkoutType Type { get; }

        public Workout(int id, int coachid, int duration, DateTime schedule, SwimmingPool pool, WorkoutType type) {
            Id = id;
            Duration = duration;
            Schedule = schedule;
            Swimmingpool = pool;
            Type = type;
            _coach = null;
        }

        public int CompareTo(object? obj) {
            throw new NotImplementedException();
        }

        public override string ToString() {
            return $"{Type} sessie [{Duration}'] in {Swimmingpool} op {Schedule}";
        }
    }
}
