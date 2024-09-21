using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Bank_Application{
    class Program{

        public static List<Customers_Details> customers_Details_List = new List<Customers_Details>();

        public static Customers_Details login_user;
        public static void Main()
        {
            FileHandling.Create();
            FileHandling.ReadFromCsv();
            Console.WriteLine();
            Console.WriteLine("* * * * * WELCOME TO HDFC BANK * * * * * *");
            Console.WriteLine();
                string choice = "yes";
            do{
                Console.WriteLine("  Main Menu  ");
                Console.WriteLine();
                Console.WriteLine("Option 1 => Registration");
                Console.WriteLine("Option 2 => Login");
                Console.WriteLine("Option 3 => Exit");
                Console.Write("Please select the Option you need to proceed : ");
                string option = Console.ReadLine();
                Console.WriteLine();

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
                        Console.WriteLine("Thank you !Have a Nice Day !!");
                        Console.WriteLine();
                        break;
                    }
                    default :
                    {
                        Console.WriteLine("You have entered wrong options");
                        Console.WriteLine();
                        break;
                    }

                }
            }while(choice == "yes");

            FileHandling.WriteToCsv();
            

        }

        public static void Registration() 
        {
            string option;
            bool valid = false;
            while(!valid)
            {
            Console.Write("Do want to Register? (yes or no) : ");
            option = Console.ReadLine().ToLower();
            Console.WriteLine(); 
            if(option == "yes")
            {
                valid = true;
            }
            else if(option == "no")
            {
                Console.WriteLine("Thank You !! Here is Your Main Menu ");
                Console.WriteLine();
                return;
            }
            else
            {
                Console.WriteLine("Please enter the valid Option (yes or no)");
                Console.WriteLine();
                
            }
            }
            Console.WriteLine(" * * Welcome to Registration * * ");
            Console.WriteLine();
           
            Console.WriteLine();
           
            string customer_name = "";
            bool flag = false;
            while(!flag)
            {
                Console.Write("Enter the Your Name : ");
                customer_name = Console.ReadLine().TrimStart().TrimEnd();
                Console.WriteLine();
  
                foreach(char n in customer_name)
                {
                    flag = true;
                    if(char.IsPunctuation(n) || char.IsDigit(n) || customer_name.Contains(" "))
                    {
                        flag = false;
                        break;
                    }
                }
                if(!flag)
                {
                    Console.WriteLine("Enter the valid Name");
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 
                }
            }
            Console.WriteLine("Customer Name : "+customer_name);
            Console.WriteLine();
            // gender
            string input =""; 
            Gender gender;
            while(true)
            {
                Console.Write("Enter your Gender : ");
                input = Console.ReadLine().ToLower();
                Console.WriteLine();

                if(Enum.TryParse(input,true,out gender) && Enum.IsDefined(typeof(Gender),gender))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter the valid Gender");
                    Console.WriteLine();
                }
            }

            int balance  = 0;
            bool check = false;
            while(!check)
            {
                Console.Write("Enter the Balance : ");
                if(int.TryParse(Console.ReadLine(),out balance) && balance >=0)
                {
                    check = true;
                    break;
                }
                Console.WriteLine("Please enter the valid amount");
                Console.WriteLine();
            }

            long phone_number;
            while(true)
            {
                Console.WriteLine();
                Console.Write("Enter your Phone number : ");
                string number = Console.ReadLine().TrimStart().TrimEnd();
                Console.WriteLine();

                if(number.Length == 10 && long.TryParse(number,out phone_number))
                {
                    break;
                }
                Console.WriteLine("Enter the valid number : ");
                Console.WriteLine();
            }

            string email = "";
            bool choice1 = false;
            while(!choice1)
            {
                Console.Write("Enter your Mail ID : ");
                email = Console.ReadLine().Trim();
                Console.WriteLine();

                if(Regex.IsMatch(email,@"^[a-z][a-z0-9_.+-]+@gmail\.com$",RegexOptions.IgnoreCase) && !email.Contains(" "))
                {
                    choice1 = true;
                }
                else
                {
                Console.WriteLine("Please enter the valid email ID please!!");
                Console.WriteLine();
                }
            }
              
            string dateofbirth ;
            DateTime date;
            while(true)
            {
                Console.Write("Enter your DOB (MM/dd/yyyy): ");
                dateofbirth = Console.ReadLine().Trim();
                Console.WriteLine();

                if(DateTime.TryParseExact(dateofbirth,"MM/dd/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out date))
                {
                    int age = DateTime.Now.Year - date.Year;
                    if(date > DateTime.Now.AddYears(-age))age--;
                    if(age > 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Age Must be greater than 5");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Enter a Valid Date Of Birth");
                    Console.WriteLine();
                }
            }    
            
            Customers_Details users = new Customers_Details(customer_name,gender,balance ,phone_number,email,dateofbirth);
            customers_Details_List.Add(users);

            Console.WriteLine("Registraion Successfull and your customer id is : "+users.Customer_Id);
            Console.WriteLine();
        }

        public static void Login()
        {
            string option ;
            bool valid = false;
            while(!valid)
            {
                Console.WriteLine("Do You Want to Login (Yes/No) : ");
                option = Console.ReadLine().Trim();
                Console.WriteLine();
                if(option == "yes")
                {
                    valid = true;
                }
                else if(option == "no")
                {
                    Console.WriteLine("Thankyou here is your Main Menu ");
                    Console.WriteLine();
                    return;
                }
                else
                {
                    Console.WriteLine("Please enter the valid Option (yes or no)");
                    Console.WriteLine();
                }
            }
                
            
                Console.Write("Enter the Customer Id Please : ");
                string customer_Id = Console.ReadLine();
                Console.WriteLine();

                bool check = false;

                foreach(Customers_Details customer in customers_Details_List)
                {
                    if(customer.Customer_Id == customer_Id)
                    {
                        check = true;
                        login_user = customer;

                            bool flag1 = true;
                        do{
                            Console.WriteLine("Sub Menu");
                            Console.WriteLine();
                            Console.WriteLine("Option 1 => Deposit");
                            Console.WriteLine("Option 2 => Withdraw");
                            Console.WriteLine("Option 3 => Exit");
                            Console.Write("Please Select the Option you need to Proceed");
                            string option1 = Console.ReadLine();
                            Console.WriteLine();

                            switch(option1)
                            {
                                case "1" :
                                {
                                    Deposit();
                                    break;
                                }
                                case "2" :
                                {
                                    Withdraw();
                                    break;
                                }
                                case "3" :
                                {
                                    flag1 = false;
                                    break;
                                }
                                default :
                                {
                                    Console.WriteLine("Invalid Option ! Please Proceed with Valid Option");
                                    Console.WriteLine();
                                    break;
                                }

                            }
                        }while(flag1 == true);
                        
                    }
                    if(!check)
                    {
                        Console.WriteLine("Invalid Customer Id");
                        Console.WriteLine();
                    }
                }
            
            
        }

        public static void Deposit()
        {
            Console.WriteLine(" Welcome to Deposit Page ");
            Console.WriteLine();
                double amount;
                bool check = false;
            do{
                Console.WriteLine("Enter the amount to Deposit in your account : ");
                Console.WriteLine();
                string deposit_amount = Console.ReadLine();
                Console.WriteLine();

                if(double.TryParse(deposit_amount,out amount) && amount > 0)
                {
                    check = true;
                    login_user.Balance += amount;
                    Console.WriteLine("Your Balance has Added Successfully");
                    Console.WriteLine();
                    Console.WriteLine("Your Current Balance is : "+login_user.Balance);
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter the valid amount with greater than amount 0 ");
                    Console.WriteLine();
                }

                
            }while(check);
            
        }

        public static void Withdraw()
        {
            double amount;
            bool check = false;
            do{
                Console.WriteLine("Welcome to Withdraw Page");
                Console.WriteLine();

                Console.Write("Enter the amount you need to withdraw from your account : ");
                Console.WriteLine();
                if(double.TryParse(Console.ReadLine(),out amount))
                {
                    if(amount > login_user.Balance)
                    {
                        Console.WriteLine("Insufficient fund");
                        Console.WriteLine();
                        break;
                    }
                    else if(amount < 0)
                    {
                        Console.WriteLine("Amount should be positive amount");
                        Console.WriteLine();
                        break;
                    }
                    else
                    {
                        login_user.Balance = login_user.Balance - amount;
                        check = true;
                        Console.WriteLine("Withdraw Successfully ");
                        Console.WriteLine();
                        Console.Write("Your Current Balance amount : "+login_user.Balance);
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.WriteLine();
                }

                
            }while(!check);
            

            
        }

        public static void Balance()
        {
            Console.WriteLine("Welcome to Balance Page");
            Console.WriteLine();
            Console.WriteLine("Your Current Balance is : "+login_user.Balance);
            Console.WriteLine();
        }


        

    }
}
