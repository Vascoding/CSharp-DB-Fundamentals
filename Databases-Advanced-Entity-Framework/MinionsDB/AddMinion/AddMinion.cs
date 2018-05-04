

namespace AddMinion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data.SqlClient;

    class AddMinion
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
                Console.Write("Minion: ");
                
                var inputMinion = Console.ReadLine().Split().ToArray();
                string minionName = inputMinion[0];
                string minionAge = inputMinion[1];
                string Town = inputMinion[2];
                Console.Write("Villain: ");
                var inputVillain = Console.ReadLine();
                string minion = $@"select Name from Minions where Name = '{minionName}'";
                string town = $@"select Name from Towns where Name = '{Town}'";
                string villain = $@"select Name from Villains where Name =  '{inputVillain}'";
                string insertTown = $@"declare @id int = (select MAX(id) from Towns) + 1
                                    insert into Towns (Id, Name)
                                    values
                                    (@id, '{Town}')";
                string InsetMinion = $@"declare @id int = (select MAX(id) from Minions) + 1
                                       insert into Minions (Id, Name, Age)
                                       values (@id, '{minionName}', {minionAge})";
                string InsertVillain = $@"declare @id int = (select MAX(id) from Villains) + 1
                                       insert into Villains(id, Name, Evilnessfactor)
                                       values (@id, '{inputVillain}', 'evil')";
                string minionVillain = $@"declare @MinionID int = (select Id from Minions where Name = '{minionName}')
                                        declare @VillainID int = (select Id from Villains where Name = '{inputVillain}')
                                        insert into MinionsVillains (MinionId, VillainId)
                                        values (@MinionID, @VillainID)";
                string minionVillainID = $@"select m.id, v.Id from MinionsVillains as mv
                                        join Minions as m
                                        on m.id = mv.MinionId
                                        join Villains as v
                                        on v.Id = mv.VillainId
                                        where m.name = '{minionName}' and v.Name = '{inputVillain}'
                                        ";
                

                SqlCommand m = new SqlCommand(minion, connection);
                SqlCommand t = new SqlCommand(town, connection);
                SqlCommand v = new SqlCommand(villain, connection);
                SqlCommand MiVi = new SqlCommand(minionVillainID, connection);
                
                var minName = m.ExecuteReader();
                var townName = t.ExecuteReader();
                var villainName = v.ExecuteReader();
                var miviID = MiVi.ExecuteReader();
                if (!townName.HasRows)
                {
                    Console.WriteLine($"Town {Town} was added to the database.");
                    SqlCommand insTown = new SqlCommand(insertTown, connection);
                    insTown.ExecuteReader();                  
                }
                
                if (!villainName.HasRows)
                {
                    Console.WriteLine($"Villain {inputVillain} was added to the database.");
                    SqlCommand insVillain = new SqlCommand(InsertVillain, connection);
                    insVillain.ExecuteReader();           
                }
                if (!minName.HasRows)
                {
                    
                    SqlCommand insMinion = new SqlCommand(InsetMinion, connection);
                    insMinion.ExecuteReader();
                         

                }
                if (!miviID.HasRows)
                {
                    Console.WriteLine($"Successfully added {minionName} to be minion of {inputVillain}");
                    SqlCommand InsVillMin = new SqlCommand(minionVillain, connection);
                    InsVillMin.ExecuteReader();
                }
               
                
            }
        }
    }
}
