using System;
using Npgsql;

class Program
{
    static void Main()
    {
        var connStr = "Host=ep-lucky-sea-a8kkctiw-pooler.eastus2.azure.neon.tech;Port=5432;Database=neondb;Username=neondb_owner;Password=npg_gEiMeP8Wcxs9;SslMode=Require";
        using var conn = new NpgsqlConnection(connStr);
        conn.Open();
        
        using (var cmd2 = new NpgsqlCommand("SELECT column_name FROM information_schema.columns WHERE table_name='Dm_DichVu' OR table_name='dm_dichvu';", conn))
        using (var reader2 = cmd2.ExecuteReader())
        {
            Console.WriteLine("\n--- Columns in Dm_DichVu ---");
            while (reader2.Read())
            {
                Console.WriteLine(reader2.GetString(0));
            }
        }
    }
}
