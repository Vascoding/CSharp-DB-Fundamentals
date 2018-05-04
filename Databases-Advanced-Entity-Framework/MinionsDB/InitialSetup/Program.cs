
namespace GetVillainsNames
{
    using System.IO;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    class GetVillainsNames
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"
                                                            Server=.\SQLExpress;
                                                            Integrated Security=true;");
            connection.Open();
            using (connection)
            {
                string createDB = @"CREATE DATABASE MinionsDB";
                SqlCommand create = new SqlCommand(createDB, connection);
                create.ExecuteNonQuery();

                string createTables = File.ReadAllText("../../CreateTables.sql");
                SqlCommand createTab = new SqlCommand(createTables, connection);
                createTab.ExecuteNonQuery();
            }
        }
    }
}
