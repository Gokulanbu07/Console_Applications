using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Eb_Bill_Calculator;

namespace Ass3{
    class Program{

            public static List <Eb_Bill> Customer_List = new List<Eb_Bill>();

            static Eb_Bill login_user;
            public static void Main()
            {
                FileHandling.Create();
                Console.WriteLine(" * * EB BILL CALCULATION * * ");
                bool choice = false;
            do{
                Console.WriteLine("MAIN MENU");
                Console.WriteLine();
                Console.WriteLine("1.Registration");
                Console.WriteLine("2.Login");
                Console.WriteLine("3.Exit");
                Console.Write("Enter the option you needed : ");
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
                        
                    case "3":
                    {
                        choice = true;
                        Console.WriteLine("ThankYou visit Again");
                        break;
                    }
                }
                

                }while(!choice);
                
                FileHandling.WriteToCsv();
                    

            }

            public static void Registration()
            {
                Console.WriteLine("Welcome to Registration");
                Console.WriteLine();

                string user_name = "";
                bool check = false;
                while(!check)
                {
                    
                    Console.Write("Enter the User Name : ");
                    user_name = Console.ReadLine().TrimStart().TrimEnd();

                    foreach(char u in user_name)
                    {
                        check = true;  
                        if(char.IsPunctuation(u) || char.IsDigit(u) || user_name.Contains(" "))
                        {
                            check = false;
                            break;
                        }
                    }
                    if(!check)
                    {
                        Console.WriteLine("Enter the valid User name pls");
                        Console.WriteLine();
                    }
                }

                long phone_number = 0 ;
                bool check1 = false;
                while(!check1)
                {
                    Console.Write("Enter the Phone number Please : ");
                    string number = Console.ReadLine();

                    if(number.Length == 10 && long.TryParse(number,out phone_number))
                    {
                        break;
                    }
                    Console.WriteLine("Enter the valid 10 digit number");
                    Console.WriteLine();
                }

                string mail_Id = "";
                bool check2 = false;
                while(!check2)
                {
                    Console.Write("Enter the email id : ");
                    string mail_id = Console.ReadLine();
                    
                    if(Regex.IsMatch(mail_id,@"^[a-z][a-z0-9_.+]+@gmail\.com$",RegexOptions.IgnoreCase) && !mail_id.Contains(" "))
                    {
                        check2 = true;
                    }
                    else
                    {
                    Console.WriteLine("Enter the valid email Id please");
                    Console.WriteLine();
                    }
                }  

                Eb_Bill eb_bills = new Eb_Bill(user_name,phone_number,mail_Id);
                Customer_List.Add(eb_bills);

                Console.WriteLine("You have been successfully Registered");
                Console.WriteLine("Your Meter Id has been genereated Successfully : "+eb_bills.Meter_ID);
                Console.WriteLine();

            }

            public static void Login()
            {
                Console.WriteLine("Welcome to Login Page");
                Console.WriteLine();

                Console.Write("Enter the Meter ID : ");
                string meter_Id = Console.ReadLine();
                Console.WriteLine();

                bool check = false;

                foreach(Eb_Bill meterId in Customer_List)
                {
                    if(meterId.Meter_ID == meter_Id)
                    {
                        check = true;
                        login_user = meterId;

                        bool flag = true;
                        do
                        {
                            Console.WriteLine("Sub - Menu");
                            Console.WriteLine();
                            Console.WriteLine("Option 1 => calculate amount");
                            Console.WriteLine("Option 2 => User Details");
                            Console.WriteLine("Option 3 => Exit");
                            Console.Write("Enter the option you needed : ");
                            string option = Console.ReadLine();
                            Console.WriteLine();

                            switch(option)
                            {
                                case "1":
                                {
                                    CalculateAmount();
                                    break;
                                                        
                                }

                                case "2" :
                                {
                                    User_details();            
                                    break;
                                }

                                case "3":
                                {
                                    flag= false;
                                    break;
                                }
                                default :
                                {
                                    Console.WriteLine("Please enter the valid option");
                                    Console.WriteLine();
                                    break;
                                }
                            }
                        }while(flag);
                        break;
                    }
                    if(!check)
                    {
                        Console.WriteLine("Please Enter the valid Meter Id ");
                        Console.WriteLine();
                    }
                        
                }

            }

            public static void CalculateAmount()
            {
                double unit = 0;
                bool check = false;
                while(!check)
                {

                    Console.Write("Enter the Unit for Eb_Bill : ");
                    string units = Console.ReadLine();
                    if(double.TryParse(units,out unit) && !units.Contains(" ") && unit > 0)
                    {
                        check = true;
                    }
                    else
                    {
                    Console.WriteLine("Enter the valid units");
                    Console.WriteLine();
                    }
                }
                
                    double total = unit * 5;
                    Console.WriteLine("Your Bill Id : "+login_user.Meter_ID);
                    Console.WriteLine("User Name : "+login_user.UserName);
                    Console.WriteLine("Your EB Bill Amount is : "+total);
                    Console.WriteLine();
            
            }
            public static void User_details()
            {
                Console.WriteLine("WELCOME");
                Console.WriteLine();
                Console.WriteLine("Meter Id : "+login_user.Meter_ID);
                Console.WriteLine("User Name : "+login_user.UserName);
                Console.WriteLine("Phone_Number : "+login_user.PhoneNumber);
                Console.WriteLine("Mail Id : "+login_user.Mail_Id);
                Console.WriteLine();
            }
    }
}







                        

                        






                    