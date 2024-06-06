using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=SRV2\\PUPILS;Initial Catalog=326134715_shop;Integrated Security=True;Encrypt=False";
            DataAccess dataAccess = new DataAccess();
            string toContinue = "y";
            while (toContinue == "y")
            {
                dataAccess.InsertCategory(connectionString);
                Console.WriteLine("Whould you like to continue? y/n");
                toContinue = Console.ReadLine();
            }

            dataAccess.ReadCategory(connectionString);

        }
    }
}
