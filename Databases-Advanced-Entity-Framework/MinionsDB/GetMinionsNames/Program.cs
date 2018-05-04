


namespace EmployeesFullInformation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;
    using System.Runtime.Remoting.Messaging;
    class Startup
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"
    Server=.\SQLExpress;
    Database=MinionsDB;  
    Integrated Security=true");
            connection.Open();
            using (connection)
            {
                string query = @"select v.Name, count(m.Id) from MinionsVillains as mv
join Minions as m
on m.id = mv.MinionId
join Villains as v
on v.Id = mv.VillainId
group by v.Name
having count(m.id) > 3
";
                SqlCommand cmd = new SqlCommand(query, connection);
                var reader = cmd.ExecuteReader();
                using (reader)
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
