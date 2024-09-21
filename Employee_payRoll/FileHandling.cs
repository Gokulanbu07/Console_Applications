using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Pay_Roll
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("Employee_Pay_Roll"))
            {
                Console.WriteLine("Creating...");
                Directory.CreateDirectory("Employee_Pay_Roll");
            }
            else
            {
                Console.WriteLine("Already Created");
            }

            if(!File.Exists("Employee_Pay_Roll/Employee_Details.csv"))
            {
                Console.WriteLine("Creating File....");
                File.Create("Employee_Pay_Roll/Employee_Details.csv");
            }
        }

        public static void WriteToCsv()
        {
            string[] employee_Details = new string[Program.employee_Details_List.Count];
            for(int i = 0;i<Program.employee_Details_List.Count;i++)
            {
                employee_Details[i] = Program.employee_Details_List[i].Employee_id+","+Program.employee_Details_List[i].Employee_Name+","+Program.employee_Details_List[i].Gender_input+","+Program.employee_Details_List[i].Employee_Role+","+Program.employee_Details_List[i].Work_Location+","+Program.employee_Details_List[i].Team_Name+","+Program.employee_Details_List[i].DateOfJoining;
            }
            File.WriteAllLines("Employee_Pay_Roll/Employee_Details.csv",employee_Details);
        }
    }
}