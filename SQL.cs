using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BlazorHjemmeside_H1_SQL
{
    public static class SQL
    {


        private static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static bool SqlConnectionOK()
        {

           

            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
        }

        // Create, Read, Update og Delete (CRUD)

        //1) Create, Data der skal creates i en tabel (det hedder insert på sql'sk)
        public static void insert(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
        }

        //2) Read, Data der skal læses fra en tabel (det hedder select på sql'sk)

        //2a) DataAdapter og DataTable, returnere DataTable
        public static DataTable ReadTable(string sql)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                DataTable records = new DataTable();

                //Create new DataAdapter
                using (SqlDataAdapter a = new SqlDataAdapter(sql, con))
                {
                    //Use DataAdapter to fill DataTable records
                    con.Open();
                    a.Fill(records);
                }

                return records;
            }
        }

        //2b) Read med Datareader, udskriver med Console.WriteLine()
        public static void DataReader()
        {
            Console.WriteLine("DataReader");
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from Kunder", con);

                SqlDataReader reader = cmd.ExecuteReader();
                //Er der rækker?
                Console.WriteLine(reader.HasRows);

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string navn = reader.GetString(1);
                    string adr = reader.GetString(2);
                    int alder = reader.GetInt32(3);

                    Console.WriteLine($"Id: {id} navn: {navn} adresse: {adr} - alder: {alder}");
                }

            }
        }


    }
}
