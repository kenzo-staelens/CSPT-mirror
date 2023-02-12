using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace Data {
    public class DataLoader {
        private string _ConnectionString;
        public DataLoader(string ip, string database, string uid, string password) {
            //this._ConnectionString=$"Data Source = localhost; Initial Catalog = {database}; Integrated Security = SSPI";
            
            this._ConnectionString=$"SERVER={ip};DATABASE={database};UID={uid};pwd={password}";

        }

        public DataSet SelectData(string queryString, string datasetTableName) {
            using(MySqlConnection conn = new MySqlConnection(this._ConnectionString)) {
                conn.Open();
                DataSet dataSet = new DataSet();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(queryString, conn);
                dataAdapter.Fill(dataSet, datasetTableName);
                return dataSet;
            }
        }
    }
}
