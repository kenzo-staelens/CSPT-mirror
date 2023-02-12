using Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

public class Program {
    private static void Main(string[] args) {

        string beast = "SELECT cid, firstname, lastname, sid, swimmer_firstname, swimmer_lastname FROM (SELECT coaches.member_id as cid,swimmers.member_id as sid,firstname as swimmer_firstname, lastname as swimmer_lastname FROM coaches INNER JOIN coaches_has_workouts ON coaches.id=coaches_id INNER JOIN workouts ON workouts.id=coaches_has_workouts.workouts_id INNER JOIN swimmers_has_workouts ON workouts.id=swimmers_has_workouts.workouts_id INNER JOIN swimmers ON swimmers.id=swimmers_id INNER JOIN members ON members.id=swimmers.member_id) as jtable INNER JOIN members on cid=id;";
        string mini = "select * from members;";
        DataLoader dl = new DataLoader("localhost", "test", "root", "Kids2506#");

        string tablename = "table";
        DataSet dataSet = dl.SelectData(mini, "table");
        DataTable table = dataSet.Tables[tablename];

        foreach (DataRow row in table.Rows) {
            Console.WriteLine($"{row[1]} {row[2]}");
        }
    }
}