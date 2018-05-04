
namespace GetVillainsNames
{
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
                                                            Integrated Security=true;
                                                        MultipleActiveResultSets=True;");
            connection.Open();
            using (connection)
            {
                Console.Write("Input Villain ID: ");
                int villainID = int.Parse(Console.ReadLine());
                string query = $@"select v.Name, m.Id, m.Name, m.Age from MinionsVillains as mv
                                join Minions as m
                                on m.id = mv.MinionId
                                join Villains as v
                                on v.Id = mv.VillainId
                                where v.Id = {villainID}
                                ";
                string villain = $@"select Name from Villains 
                                    where Id = {villainID}";

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlCommand command = new SqlCommand(villain, connection);
                var reader = cmd.ExecuteReader();
                var vill = command.ExecuteScalar();
                if (!reader.HasRows)
                {
                    if (vill == null)
                    {
                        Console.WriteLine($"No villain with ID {villainID} exists in the database.");
                        return;
                    }
                    Console.WriteLine($"Villain: {vill}");
                    Console.WriteLine("(no minions)");
                    return;
                }
                using (reader)
                {
                    reader.Read();
                    Console.WriteLine($"Villain: {reader[0]}");
                    int index = 1;
                    while (reader.Read())
                    {
                        Console.WriteLine($"{index}. {reader[2]} {reader[3]}");
                        index++;
                    }
                }
            }
        }
    }
}
