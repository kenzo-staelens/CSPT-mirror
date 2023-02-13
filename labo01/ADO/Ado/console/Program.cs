using Data;
using Globals;
using Logica;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

public class Program {
    private static void Main(string[] args) {

        DataPreProcessor dpp = new DataPreProcessor("localhost", "test", "root", "Kids2506#");
        DataSet ds = new DataSet();
        List<SwimmingPool> pools = dpp.GetSwimmingPools(ds);
        List<Swimmer> swimmers = dpp.GetSwimmers(ds);
        List<Coach> coaches = dpp.GetCoaches(ds);
        List<Workout> workouts = dpp.GetWorkouts(ds, pools);
        dpp.SetMemberWorkouts(coaches, swimmers, workouts);
        dpp.SetWorkoutCoaches(coaches);

        foreach(var val in coaches) {
            Console.WriteLine($"-- {val} --");
        }
    }
}