using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MySql.Data.MySqlClient;

namespace WellArchitectedServices.MySQL
{
    public class AppDb : IDisposable
    {

        public MySqlConnection Connection;

        public AppDb()
        {
            Connection = new MySqlConnection(AppConfig.Config["Data:ConnectionString"]);
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}