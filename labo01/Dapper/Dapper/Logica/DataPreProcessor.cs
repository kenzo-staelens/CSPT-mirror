using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Globals;
using Data;
using System.Data;

namespace Logica {
    public class DataPreProcessor {
        private DataLoader _dl;
        public DataPreProcessor(string server, string db, string user, string pw) {
            this._dl = new DataLoader("localhost", "test", "root", "Kids2506#");
        }

        public List<Swimmer> GetSwimmers(DataSet ds) {
            ds = this._dl.SelectData(Data.QueryStrings.all_swimmers,"swimmers");
            DataTable dt = ds.Tables["swimmers"];
            List<Swimmer> result = new List<Swimmer>();
            foreach (DataRow row in dt.Rows) {
                int points = Convert.ToInt32((System.UInt32)row["final_points"]);
                result.Add(new Swimmer(
                    (int)row["id"],
                    (DateTime)row["date_of_birth"],
                    (string)row["firstname"],
                    (string)row["lastname"],
                    ((string)row["gender"])[0],
                    points
                ));
            }
            return result;
        }

        public void SetWorkoutCoaches(List<Coach> coaches) {
            for(int i = 0; i < coaches.Count; i++) {
                for(int j = 0; j < coaches[i].Workouts.Count; j++) {
                    coaches[i].Workouts[j].Coach = coaches[i];
                }
            }
        }

        public void SetMemberWorkouts(List<Coach> coaches, List<Swimmer> swimmers, List<Workout> workouts) {
            foreach(Swimmer swimmer in swimmers) {
                DataSet ds = this._dl.SelectData($"select * from swimmers_has_workouts where swimmers_id={swimmer.Id} order by swimmers_id,workouts_id;", "shw");
                DataTable dt = ds.Tables["shw"];
                int workoutIdx = 0;
                foreach (DataRow row in dt.Rows) {
                    for (; workoutIdx < workouts.Count(); workoutIdx++) {
                        if (workouts[workoutIdx].Id == (int)row["workouts_id"]) {
                            swimmer.addWorkout(workouts[workoutIdx]);
                            break;
                        }
                    }
                }
            }

            foreach (Coach coach in coaches) {
                DataSet ds = this._dl.SelectData($"select * from coaches_has_workouts where coaches_id={coach.Id} order by coaches_id,workouts_id;", "chw");
                DataTable dt = ds.Tables["chw"];
                int workoutIdx = 0;
                foreach (DataRow row in dt.Rows) {
                    for (; workoutIdx < workouts.Count(); workoutIdx++) {
                        if (workouts[workoutIdx].Id == (int)row["workouts_id"]) {
                            coach.addWorkout(workouts[workoutIdx]);
                            break;
                        }
                    }
                }
            }
        }

        public List<Coach> GetCoaches(DataSet ds) {
            ds = this._dl.SelectData(Data.QueryStrings.all_coaches, "coaches");
            DataTable dt = ds.Tables["coaches"];
            List<Coach> result = new List<Coach>();

            foreach (DataRow row in dt.Rows) {
                Enum.TryParse((string)row["level"], out CoachLevel level);
                result.Add(new Coach(
                    (int)row["id"],
                    (DateTime)row["date_of_birth"],
                    (string)row["firstname"],
                    (string)row["lastname"],
                    ((string)row["gender"])[0],
                    level
                ));
            }
            return result;
        }

        public List<Workout> GetWorkouts(DataSet ds, List<SwimmingPool> swimmingPools) {
            ds = this._dl.SelectData(Data.QueryStrings.all_workouts, "workouts",ds);
            DataTable dt = ds.Tables["workouts"];
            List<Workout> result = new List<Workout>();
            foreach (DataRow row in dt.Rows) {
                SwimmingPool pool = null;
                for(int i = 0; i < swimmingPools.Count; i++) {
                    if ((int)row["swimming_pools_id"] == swimmingPools[i].id) {
                        pool = swimmingPools[i];
                        break;
                    }
                }
                Enum.TryParse((string)row["type"], out WorkoutType type);
                result.Add(new Workout(
                    (int)row["id"],
                    (int)row["coaches_id"],
                    (int)row["duration"],
                    (DateTime)row["schedule"],
                    pool,
                    type
                ));
            }
            return result;
        }

        public List<SwimmingPool> GetSwimmingPools(DataSet ds) {
            ds = this._dl.SelectData(Data.QueryStrings.all_swimming_pools, "swimmingPools");
            //return new List<SwimmingPool>();
            DataTable dt = ds.Tables["swimmingPools"];
            List<SwimmingPool> result = new List<SwimmingPool>();
            foreach (DataRow row in dt.Rows) {
                result.Add(new SwimmingPool(
                    (int)row["id"],
                    (string)row["name"],
                    (string)row["city"],
                    (string)row["street"],
                    (int)row["zip_code"],
                    (int)row["lane_length"] == 25 ? PoolLaneLength._25 : PoolLaneLength._50
                ));
            }
            return result;
        }
    }
}
