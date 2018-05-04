
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
                                                            Database=MinionsDB;  
                                                            Integrated Security=true;");
            connection.Open();
            using (connection)
            {
                var inputId = int.Parse(Console.ReadLine());
                // Update Minions Names and Ages
                string minionsId = File.ReadAllText("../../UpdateAge.sql");
                SqlCommand minId = new SqlCommand(minionsId, connection);
                SqlParameter minions = new SqlParameter("@minionId", inputId);
                minId.Parameters.Add(minions);
                minId.ExecuteNonQuery();
                
                // Get Minions from database
                string getMinions = File.ReadAllText("../../GetMinions.sql");
                SqlCommand getMin = new SqlCommand(getMinions, connection);
                SqlParameter minionId = new SqlParameter("@ID", inputId);
                getMin.Parameters.Add(minionId);
                var reader = getMin.ExecuteReader();

                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]} {reader[1]}");
                        }
                    }
                }
            }
        }
    }
}
