using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals {
    public class Member : IComparable{
        public int Id { get; }
        public DateTime DateOfBirth { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public char Gender { get; }

        public Member() { }

        public int CompareTo(object? obj) {
            throw new NotImplementedException();
        }

        public bool Equals(Member other) {
            return this.Id == other.Id;
        }

        /* gethashcode is default in object
        public override int GetHashCode() {
            return 0;
        }*/

        public override string ToString() {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
