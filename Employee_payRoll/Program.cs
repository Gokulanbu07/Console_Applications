using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime;
using System.Xml.Serialization;

namespace Employee_Pay_Roll{

    
    class Program{

        public static List<Employee_Details> employee_Details_List = new List<Employee_Details>();

        public static Employee_Details login_user ;
        public static void Main()
        {
            FileHandling.Create();

            Console.WriteLine();
            Console.WriteLine("* * GEMINI ENTERPRISES * *");
            Console.WriteLine();
            string choice = "yes";
            do{
                Console.WriteLine("MAIN MENU");
                Console.WriteLine();
                Console.WriteLine("Option 1 => Registration");
                Console.WriteLine("Option 2 => Login");
                Console.WriteLine("Option 3 => Exit");
                Console.WriteLine("Enter the Option you needed : ");
                string option = Console.ReadLine();

                switch(option)
                {
                    case "1" :
                    {
                        Registration();
                        break;
                    }
                    case "2" :
                    {
                        Login();
                        break;
                    }
                    case "3" :
                    {
                        choice = "no";
                        Console.WriteLine("Thank you Visit Again");
                        Console.WriteLine();
                        break;
                    }
                    default :
                    {
                        Console.WriteLine("You have entered wrong option.Please press the correct key");
                        Console.WriteLine();
                        break;
                    }
                }
            }while(choice == "yes");

            FileHandling.WriteToCsv();
            
        }
        
        public static void Registration()
        {
            Console.WriteLine();
            Console.WriteLine(" * * WELCOME * * ");
            Console.WriteLine();

            string employee_name = "";
            bool check = false;
            while(!check)
            {
                Console.Write("Enter the Employee Name : ");
                employee_name = Console.ReadLine().Trim();

                foreach(char e in employee_name)
                {
                    check = true;
                    if(char.IsPunctuation(e) || char.IsDigit(e) || employee_name.Contains(" "))
                    {
                        check = false;
                        break;
                    }
                }
                if(!check)
                {
                    Console.WriteLine("Invalid Name!! name should not contain any special Characters");
                    Console.WriteLine();
                }
            }
            Console.WriteLine("The Employee name is : "+employee_name);
            Console.WriteLine();
                // Gender
            string gender_input = "";
            Gender gender;
            bool choice = false;
            do
            {
                Console.Write("Enter your Gender : ");
                gender_input = Console.ReadLine().Trim();
                Console.WriteLine();

                if(Enum.TryParse(gender_input,true,out gender))
                {
                    choice = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter the valid Gender !!");
                    Console.WriteLine();
                }
            }while(!choice);
            
            string employee_role = "" ;
            bool check3 = false;
            while(!check)
            {
                Console.WriteLine("Enter the Employee's Role : ");
                employee_role = Console.ReadLine();

                foreach(char e in employee_role)
                {
                    check3 = true;
                    if(char.IsPunctuation(e) || char.IsDigit(e) && !employee_role.Contains(" "))
                    {
                        check3 = false;
                        break;
                    }
                }
                if(!check)
                {
                    Console.WriteLine("Invalid Role!!");
                    Console.WriteLine();

                }
            }
 
            string work_location = "";
            Location location;
            bool check4 = false;
            while(!check4)
            {
                Console.Write("Enter the Employee's Work Location : ");
                work_location = Console.ReadLine().TrimStart().TrimEnd();

                if(Enum.TryParse(work_location,true,out location))
                {
                    check4 = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Employee location not found !!");
                    Console.WriteLine();
                }
            }

            string team_name = "";
            bool check5 = false;
            while(!check5)
            {
                Console.Write("Enter the Employee's Team Name : ");
                team_name = Console.ReadLine();
                check5 = true;
                foreach(char e in team_name)
                {
                    if(char.IsPunctuation(e) || char.IsDigit(e) || team_name.Contains(" "))
                    {
                        check5 = false;
                        break;
                    }
                }
                if(!check5)
                {
                    Console.WriteLine("Invalid Format!!");
                    Console.WriteLine();
                }
            }

            string dateOfJoining;
            DateTime date;
            while(true)
            {
                Console.WriteLine("Enter the employee's Joining Date");
                dateOfJoining = Console.ReadLine();

                if(DateTime.TryParseExact(dateOfJoining,"dd/MM/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out date))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter the valid Date Please");
                    Console.WriteLine();
                }
            }

            Employee_Details employees = new Employee_Details(employee_name,gender_input,employee_role,work_location,team_name,dateOfJoining);
            employee_Details_List.Add(employees);

            Console.WriteLine("You have successfully registered the Employee's Details and the Employee's Id is : "+ employees.Employee_id);
            Console.WriteLine();

        }

        public static void Login()
        {
            Console.WriteLine("Welcome To Login Page");
            Console.WriteLine();
            Console.Write("Enter the Employee ID : ");
            string employee_id = Console.ReadLine();
            Console.WriteLine();

            bool check = false;

            foreach(Employee_Details employee in employee_Details_List)
            {
                if(employee.Employee_id == employee_id)
                {
                    check = true;
                    login_user = employee;

                    bool flag = true;
                    do{
                        Console.WriteLine("Sub Menu");
                        Console.WriteLine();
                        Console.WriteLine("1.Calculate Salary");
                        Console.WriteLine("2.Display Details");
                        Console.WriteLine("3.Exit");
                        Console.Write("Select the Option you needed : ");
                        string subOption = Console.ReadLine();
                        Console.WriteLine();
                        switch(subOption)
                        {
                            case "1" :
                            {
                                Salary_Calculation();
                                break;
                            }
                            case "2" :
                            {
                                Display_details();
                                break;
                            }
                            case "3" :
                            {
                                flag = false;
                                break;
                            }
                            default :
                            {
                                Console.WriteLine("Invalid Option");
                                Console.WriteLine();
                                break;
                            }
                        }
                    }while(flag == true);
                }
                if(!check)
                {
                    Console.WriteLine("Invalid Customer ID");
                    Console.WriteLine();
                }
            }  
        }
        public static void Salary_Calculation()
        {
            int working_days = 0;
            bool check6 = false;
            while(!check6)
            {
                Console.WriteLine("Enter the No of working Days");
                string input = Console.ReadLine();
                if(int.TryParse(input,out working_days) && working_days > 0  && working_days <= DateTime.DaysInMonth(DateTime.Now.Year,DateTime.Now.Month) )
                {
                    check6 = true;
                }
                else
                {
                    Console.WriteLine("Enter the valid working Days");
                    Console.WriteLine();
                }
            }

            int no_of_leave_taken = 0;
            bool check7 = false;
            while(!check7)
            {
                Console.WriteLine("Enter the number leave days : ");
                string input = Console.ReadLine();
                if(int.TryParse(input,out no_of_leave_taken) && no_of_leave_taken >= 0 && no_of_leave_taken < working_days)
                {
                    check7 = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid no of leaves");
                    Console.WriteLine();
                }
            }

            double perday = 500.0;
            int attendance = working_days - no_of_leave_taken;
            double salary = attendance * perday;
            Console.WriteLine("Your salary is : "+salary);

            
        }

        public static void Display_details()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine();
            Console.WriteLine("Employee Details");
            Console.WriteLine();
            Console.WriteLine("Employee Id : "+login_user.Employee_id);
            Console.WriteLine("Employee Name : "+login_user.Employee_Name);
            Console.WriteLine("Employee Role : "+login_user.Employee_Role);
            Console.WriteLine("Employee team_Name : "+login_user.Team_Name);
            Console.WriteLine("Employee work Location : "+login_user.Work_Location);
            Console.WriteLine("Date of Joining : "+login_user.DateOfJoining);
            Console.WriteLine();
        }
    }
}
