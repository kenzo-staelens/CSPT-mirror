using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Globals {
    public class Member : IComparable {
        public int Id { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }

        public int CompareTo(object? obj) {
            Member member2 = obj as Member;
            if (member2!= null) return $"{this.LastName} {this.FirstName}".CompareTo($"{member2.LastName} {member2.FirstName}");
            else return 1;
        }

        public bool Equals(Member other) {
            return this.Id == other.Id;
        }

        public override string ToString() {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
