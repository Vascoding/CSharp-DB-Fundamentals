
using System.IO;

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
                                                            Integrated Security=true;");
            connection.Open();
            using (connection)
            {
                string findTowns = File.ReadAllText("../../ChangeTownName.sql");
                string selectTowns = File.ReadAllText("../../SelectTownName.sql");
                SqlCommand findTown = new SqlCommand(findTowns, connection);
                string countryName = Console.ReadLine();
                SqlCommand selectTown = new SqlCommand(selectTowns, connection);
                SqlParameter cName = new SqlParameter("@countryName", countryName);
                SqlParameter sName = new SqlParameter("@selectCountryName", countryName);
                selectTown.Parameters.Add(sName);
                findTown.Parameters.Add(cName);
                findTown.ExecuteNonQuery();

                if (findTown.ExecuteNonQuery() <= 0)
                {
                    Console.WriteLine("No town names were affected.");
                }

                else
                {
                    Console.WriteLine($"{findTown.ExecuteNonQuery()} town names were affected.");
                    var reader = selectTown.ExecuteReader();
                    using (reader)
                    {
                        var list = new List<string>();
                        while (reader.Read())
                        {
                            list.Add(reader[0].ToString().ToUpper());
                        }
                        Console.Write("[");
                        Console.Write(string.Join(", ", list));
                        Console.WriteLine("]");
                    }
                }
            }
        }
    }
}
