


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
                // Update Minions Names and Ages
                var inputId = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int i = 0; i < inputId.Length; i++)
                {
                    string minionsId = File.ReadAllText("../../MinionsID.sql");
                    SqlCommand minId = new SqlCommand(minionsId, connection);
                    SqlParameter minions = new SqlParameter("@MinionsID", inputId[i]);
                    minId.Parameters.Add(minions);
                    minId.ExecuteNonQuery();
                }
                

                // Get Minions from database
                string getMinions = File.ReadAllText("../../GetMinions.sql");
                SqlCommand getMin = new SqlCommand(getMinions, connection);
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
