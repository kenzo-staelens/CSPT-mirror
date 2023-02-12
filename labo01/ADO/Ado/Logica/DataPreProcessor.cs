using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Globals;
using Data;
using System.Data;
using MySqlX.XDevAPI.Relational;

namespace Logica {
    public class DataPreProcessor {
        private DataLoader _dl;
        public DataPreProcessor(string server, string db, string user, string pw) {
            this._dl = new DataLoader("localhost", "test", "root", "Kids2506#");
        }

        public List<Swimmer> GetSwimmers() {
            DataSet ds = this._dl.SelectData(Data.QueryStrings.all_swimmers,"table"); // add inner join members to query
            DataTable dt = ds.Tables["table"];
            List<Swimmer> result = new List<Swimmer>();
            foreach (DataRow row in dt.Rows) {
                //result.add(new swimmer...);
            }
            return result;
        }
    }
}
