using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data {
    public class QueryStrings {
        public static string coach_to_swimmer = "SELECT cid, firstname, lastname, sid, swimmer_firstname, swimmer_lastname FROM (SELECT coaches.member_id as cid,swimmers.member_id as sid,firstname as swimmer_firstname, lastname as swimmer_lastname FROM coaches INNER JOIN coaches_has_workouts ON coaches.id=coaches_id INNER JOIN workouts ON workouts.id=coaches_has_workouts.workouts_id INNER JOIN swimmers_has_workouts ON workouts.id=swimmers_has_workouts.workouts_id INNER JOIN swimmers ON swimmers.id=swimmers_id INNER JOIN members ON members.id=swimmers.member_id) as jtable INNER JOIN members on cid=id;";
        public static string all_workouts_swimmers = "select * from swimmers_has_workouts;";
        public static string all_workouts_coaches = "select * from coaches_has_workouts;";
        public static string all_members = "select * from members;";
        public static string all_workouts = "select * from workouts;";
        public static string all_swimming_pools = "select * from swimming_pools;";
        public static string all_coaches = "select * from coaches;";
        public static string all_swimmers = "select * from swimmers;";
    }
}
