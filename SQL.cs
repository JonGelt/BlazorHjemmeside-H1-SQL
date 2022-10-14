using BlazorHjemmeside_H1_SQL.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;

namespace H1AfsluttendeOpgaveSuperVigtig.Data
{
    public class SQL
    {
        static string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HjemmesideDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection conn = new SqlConnection(connectionString);
        public List<Fisk> ReadFisk()
        {
            List<Fisk> FiskList = new List<Fisk>();
            SqlCommand command = new SqlCommand("Select * from [Fisk]", conn);
            conn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {

                while (reader.Read())
                {
                    Fisk f = new()
                    {
                    
                        FiskID = int.Parse(reader["fiskid"].ToString()),
                        Navn = reader["fisknavn"].ToString(),
                        Farve = reader["fiskfarve"].ToString(),
                        Vægt = double.Parse(reader["fiskvægt"].ToString()),
                        
                    };
                    FiskList.Add(f);
                }
            }
            conn.Close();
            return FiskList;
        }

        public bool CreateFisk(Fisk f)
        {
            using (conn)
            {
                var cmd = new SqlCommand(
                    "INSERT INTO [Fisk] " +
                    "VALUES (@navn, @farve, @vægt)", conn);
                cmd.Parameters.Add("@navn", SqlDbType.NVarChar).Value = f.Navn;
                cmd.Parameters.Add("@farve", SqlDbType.NVarChar).Value = f.Farve;
                cmd.Parameters.Add("@vægt", SqlDbType.Decimal).Value = f.Vægt;
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1) return true; else return false;
            }
        }

    }
}