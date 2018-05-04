


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
                // Get Villain Name
                int villId = int.Parse(Console.ReadLine());
                string villName = File.ReadAllText("../../VillainName.sql");
                SqlCommand name = new SqlCommand(villName, connection);
                SqlParameter nameParam = new SqlParameter("@Id", villId);
                name.Parameters.Add(nameParam);
                var reader = name.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    string nameOfVillain = reader[0].ToString();
                    reader.Close();

                    // Get Minions Count 
                    string minCount = File.ReadAllText("../../MinionCount.sql");
                    SqlCommand count = new SqlCommand(minCount, connection);
                    SqlParameter num = new SqlParameter("@Villain", villId);
                    count.Parameters.Add(num);
                    var countReader = count.ExecuteReader();
                    int minions = 0;
                    countReader.Read();
                    minions += (int)countReader[0];
                    countReader.Close();
                    
                    // Villain delete and Minions release
                    string deleteVillain = File.ReadAllText("../../RemoveVillain.sql");
                    SqlCommand delete = new SqlCommand(deleteVillain, connection);
                    SqlParameter delParam = new SqlParameter("@villainId", villId);
                    delete.Parameters.Add(delParam);
                    delete.ExecuteNonQuery();
                    Console.WriteLine($"{nameOfVillain} was deleted");
                    Console.WriteLine($"{minions} minions released");
                }
                else
                {
                    Console.WriteLine("No such villain was found");
                }
            }
        }
    }
}
