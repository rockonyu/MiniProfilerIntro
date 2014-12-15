using StackExchange.Profiling;
using StackExchange.Profiling.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MiniProfilerIntro.Models {
    public class ProfilerModel {
        //public static itunesdataEntities GetEntities() {
        //    var conn =  new EFProfiledDbConnection(GetConnection(), MiniProfiler.Current);
        //    return ObjectContextUtils.CreateObjectContext<itunesdataEntities>(conn);
        //}


        private static DbConnection GetConnection() {
            // Specify the provider name, server and database.
            string serverName = "austin-pc";
            string databaseName = "account";
            // Initialize the connection string builder for the
            // underlying provider.
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            // Set the properties for the data source.
            sqlBuilder.DataSource = serverName;
            sqlBuilder.InitialCatalog = databaseName;
            sqlBuilder.IntegratedSecurity = true;
            return new SqlConnection(sqlBuilder.ToString());
        }
    }
}