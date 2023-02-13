using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data {
    public class QueryStrings {
        public static string swimmers_has_workouts = "select * from swimmers_has_workouts order by swimmers_id;";
        public static string coaches_has_workouts = "select * from coaches_has_workouts order by coaches_id;";
        public static string all_members = "select * from members;";
        public static string all_workouts = "select workouts.*,coaches_id from workouts inner join coaches_has_workouts on workouts.id=workouts_id; ";
        public static string all_swimming_pools = "select * from swimming_pools;";
        public static string all_coaches = "select members.*,coaches.level from members inner join coaches on members.id = coaches.id;";
        public static string all_swimmers = "select members.*,swimmers.final_points from members inner join swimmers on members.id = swimmers.id;";
    }
}
