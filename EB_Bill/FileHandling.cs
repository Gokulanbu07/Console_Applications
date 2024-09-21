using System;
using System.IO;
using Ass3;

namespace Eb_Bill_Calculator
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("Eb_Bill_Calculator"))
            {
                Console.WriteLine("Creating...");
                Directory.CreateDirectory("Eb_Bill_Calculator");
            }
            else
            {
                Console.WriteLine("Already Created Directory");
            }

            if(!File.Exists("Eb_Bill_Calculator/Eb_Bill.csv"))
            {
                Console.WriteLine("Creating file");
                File.Create("Eb_Bill_Calculator/Eb_Bill.csv");
            }
        }

        public static void WriteToCsv()
        {
            string[] bills = new string[Program.Customer_List.Count];
            for(int i = 0;i<Program.Customer_List.Count;i++)
            {
                bills[i] = Program.Customer_List[i].Meter_ID+","+Program.Customer_List[i].UserName+","+Program.Customer_List[i].PhoneNumber+","+Program.Customer_List[i].Mail_Id;
            }
            File.WriteAllLines("Eb_Bill_Calculator/Eb_Bill.csv",bills);
        }
    }
}