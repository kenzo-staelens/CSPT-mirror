using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data {
    public class DataLoader {
        private string _ConnectionString;
        public DataLoader(string ip, string database, string uid, string password) {
            this._ConnectionString = $"SERVER={ip};DATABASE={database};UID={uid};pwd={password}";
        }

        public DataSet SelectData(string queryString, string datasetTableName) {
            return SelectData(queryString, datasetTableName, new DataSet());
        }

        public DataSet SelectData(string queryString, string datasetTableName, DataSet dataSet) {
            using (var conn = new MySqlConnection(_ConnectionString)) {
                IDataReader rdr = conn.ExecuteReader(new CommandDefinition(queryString));
                return ConvertDataReaderToDataSet(rdr, datasetTableName, dataSet);
            }
        }

        public DataSet ConvertDataReaderToDataSet(IDataReader data, string tablename, DataSet ds) {
            ds.Tables.Add(tablename);
            ds.Tables[tablename].Load(data);
            return ds;
        }
    }
}
