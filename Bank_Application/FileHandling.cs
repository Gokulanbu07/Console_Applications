using System;
using System.ComponentModel.DataAnnotations;
using System.IO;


namespace Bank_Application
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("Bank_Application"))
            {
                Console.WriteLine("Creating Directory");
                Directory.CreateDirectory("Bank_Application");
            }
            else
            {
                Console.WriteLine("Already Directory Exits");
            }

            // Customer_Detail

            if(!File.Exists("Bank_Application/Customer_Details.csv"))
            {
                Console.WriteLine("Created Application");
                File.Create("Bank_Application/Customer_Details.csv").Close();
            }
        }

        public static void WriteToCsv()
        {
            string[] customer = new string[Program.customers_Details_List.Count];
            for(int i = 0;i<Program.customers_Details_List.Count;i++)
            {
                customer[i] = Program.customers_Details_List[i].Customer_Id+","+Program.customers_Details_List[i].Customer_name+","+Program.customers_Details_List[i].Gender+","+Program.customers_Details_List[i].Balance+","+Program.customers_Details_List[i].Phone_number+","+Program.customers_Details_List[i].Email+","+Program.customers_Details_List[i].DateOfBirth;;
            }
            File.WriteAllLines("Bank_Application/Customer_Details.csv",customer);
        }

        public static void ReadFromCsv()
        {
            string[] customers = File.ReadAllLines("Bank_Application/Customer_Details.csv");
            foreach(var ans in customers)
            {
                Customers_Details Cd = new Customers_Details(ans);
                Program.customers_Details_List.Add(Cd);
            }   
        }
    }
}