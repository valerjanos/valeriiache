using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SpecflowTestProject
{
    public class SqlHelper
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionString;
        private SqlConnection _sqlConnection;

        public SqlHelper()
        {
            _sqlConnectionString = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-43QBMCH",
                InitialCatalog = "Shop",
                IntegratedSecurity = true
            };
        }

        public void OpenConnection()
        {
            _sqlConnection = new SqlConnection(_sqlConnectionString.ConnectionString);
            _sqlConnection.Open();
        }

        public void CloseConnection()
        {
            _sqlConnection.Close();
        }

        public void ExecuteNonQuery(string request)
        {
            //INSERT INTO [Shop].[dbo].[Clients] (id,FirstName,LastName,PhoneNumber) VALUES (1,'Petya','Pupkin',123456)
            var command = new SqlCommand(request, _sqlConnection);
            command.ExecuteNonQuery();
        }

        public void Insert(string table, Dictionary<string, string> parameters)
        {
            var columns = string.Empty;
            var values = string.Empty;
            foreach (var parameter in parameters)
            {
                columns += $"{parameter.Key},";
                values += $"{parameter.Value},";
            }

            var command = new SqlCommand($"INSERT INTO {table} ({columns.TrimEnd(',')}) VALUES ({values.TrimEnd(',')})", _sqlConnection);
            command.ExecuteNonQuery();
        }

        public bool IsRowExistedInTable(string table, Dictionary<string, string> parameters)
        {
            var whereParameters = string.Empty;
            foreach (var parameter in parameters)
            {
                whereParameters += $" AND {parameter.Key}={parameter.Value}";
            }

            var sqlDataAdapter = new SqlDataAdapter($"SELECT * FROM {table} WHERE {whereParameters.Substring(5)}", _sqlConnection);
            var dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable.Rows.Count > 0;
           
        }
       
    }
}
