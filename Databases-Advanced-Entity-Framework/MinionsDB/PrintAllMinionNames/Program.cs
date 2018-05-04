
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
                string selectNames = File.ReadAllText("../../SelectMinions.sql");
                SqlCommand command = new SqlCommand(selectNames, connection);
                var reader = command.ExecuteReader();
                var list = new List<string>();
                var ordered = new List<string>();
                using (reader)
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            list.Add(reader[0].ToString());
                        }
                    }
                    
                }
                while (list.Count > 1)
                {
                    ordered.Add(list.First());
                    ordered.Add(list.Last());
                    list.RemoveAt(0);
                    list.RemoveAt(list.Count - 1);
                }
                if (list.Count == 1)
                {
                    ordered.Add(list[0]);
                }
                Console.WriteLine(string.Join("\n", ordered));
                
            }
        }
    }
}
