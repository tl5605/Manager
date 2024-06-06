using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    internal class DataAccess
    {
        public int InsertPtoduct(string connectionString)
        {
            string productName, price, categoryId, description;

            Console.WriteLine("insert productName");
            productName = Console.ReadLine();
            Console.WriteLine("insert price");
            price = Console.ReadLine();
            Console.WriteLine("insert categoryId");
            categoryId = Console.ReadLine();
            Console.WriteLine("insert description");
            description = Console.ReadLine();

            string query = "INSERT INTO PRODUCT(PRODUCT_NAME, PRICE, CATEGORY_ID, DESCRIPTION)" +
                            "VALUES(@productName, @price, @categoryId, @description)";

            using(SqlConnection cn = new SqlConnection(connectionString))
            using(SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@productName", SqlDbType.NChar, 20).Value = productName;
                cmd.Parameters.Add("@price", SqlDbType.Int, 20).Value = price;
                cmd.Parameters.Add("@categoryId", SqlDbType.Int, 20).Value = categoryId;
                cmd.Parameters.Add("@description", SqlDbType.NChar, 100).Value = description;

                try
                {
                    cn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    cn.Close();
                    return rowsAffected;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return -1;
            }
        }

        public void ReadProducts(string connectionString)
        {
            string query = "SELECT * FROM PRODUCTS";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        Console.WriteLine("\t{1}\t{2}\t{3}\t{4}",
                       
                            reader[0], reader[1], reader[2], reader[3], reader[4]);
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public int InsertCategory(string connectionString)
        {
            string categoryName;

            Console.WriteLine("insert categoryName");
            categoryName = Console.ReadLine();

            string query = "INSERT INTO CATEGORY(CATEGORY_NAME)" +
                            "VALUES(@categoryName)";

            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@categoryName", SqlDbType.NChar, 20).Value = categoryName;
           
                try
                {
                    cn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    cn.Close();
                    return rowsAffected;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return -1;
            }
        }

        public void ReadCategory(string connectionString)
        {
            string query = "SELECT * FROM CATEGORY";
            using (SqlConnection cn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                try
                {
                    cn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine("\t{1}",

                            reader[0], reader[1]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}
