using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography;
namespace OnlineMedStore
{
    class Program
    {

        static List<User_Details> user_Details_List = new List<User_Details>();
        static List<Medicine_Details> medicine_DetailsList = new List<Medicine_Details>();
        static List<Order_Details> order_DetailsList = new List<Order_Details>();

        static User_Details login_user;
        private static string username;

        public static void Main()
        {

            AddDefaultData();   // for Default data's
            Console.WriteLine("Deepam Medicals");
            Console.WriteLine();
            // User Registration Process
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            string choice = "Yes";
            do
            {

                Console.WriteLine("Option 1 => Registration");
                Console.WriteLine("Option 2 => User Login");
                Console.WriteLine("Option 3 => Exit");
                Console.WriteLine();
                string options = Console.ReadLine();
                Console.WriteLine();

                switch (options)
                {
                    case "1":
                        {
                            User_Registration(); // calling the user registration method
                            break;
                        }
                    case "2":
                        {
                            User_Login(); // calling the user login method
                            break;

                        }
                    case "3":
                        {
                            Console.WriteLine("Thank You Visit Again");
                            Console.WriteLine();
                            choice = "no";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("invalid Option");
                            Console.WriteLine();
                            break;
                        }
                }
            } while (choice == "Yes");

        }
        public static void User_Registration() 
        {
            Console.WriteLine("Welcome - User Registration");
            Console.WriteLine();
            
            string username = "";
            bool check = false;
            while(!check)
            {
                Console.Write("Enter your name : ");
                username = Console.ReadLine().TrimEnd().TrimStart();

                foreach(char u in username)
                {
                    check = true;
                    if(char.IsPunctuation(u) || char.IsDigit(u))
                    {
                        check = false;
                        break;
                    }
                }
                if(!check)
                {
                    Console.WriteLine("Please enter the valid name!! Name should not contain special characters and numbers");
                    Console.WriteLine();
                }

            }
            Console.WriteLine("Hyy Welcome "+username);
            Console.WriteLine();
            

            int age;
            while(true)
            {
                Console.Write("Enter your Age : ");
                string ageInput = Console.ReadLine();
                Console.WriteLine();
                if(int.TryParse(ageInput, out age) && age > 0 && age<=120 )
                {
                    break;
                }
                else
                {
                    
                }
                Console.WriteLine("Please enter the valid Age");
            }
            
            string city;
            while(true)
            {
                Console.Write("Enter your City : ");
                city = Console.ReadLine();
                bool check1 = true;
                
                foreach(char c in city)
                {
                    if(!char.IsLetter(c) && city.Contains(" "))
                    {
                        check1 = false;
                        break;
                    }
                }
                if(check1 && !string.IsNullOrWhiteSpace(city))
                {
                    break;
                }
                Console.WriteLine("Please Enter the valid city name");
            }
            
            long phonenumber;
            while(true)
            {
                Console.Write("Enter your Phone number : ");
                string number = Console.ReadLine();
    
                if(number.Length == 10 && long.TryParse(number,out phonenumber))
                {
                    break;
                }

                Console.WriteLine("Please enter the valid Number");
            }

            int account_balance;
            while(true)
            {
                Console.Write("Enter Balance amount : ");
                if(int.TryParse(Console.ReadLine(),out account_balance) && account_balance > 0)
                {
                    break;
                }
                Console.WriteLine("Please enter the valid amount");
            }
            
            Console.WriteLine();
            // the information given by the users have been stored i list by creating a object
            User_Details users = new User_Details(username, age, city, phonenumber, account_balance);
            user_Details_List.Add(users);


            Console.WriteLine("Your Account Has been Successfully Created ");
            Console.WriteLine("Your User Id : " + users.User_Id);
            Console.WriteLine();
        }

        public static void User_Login()
        {

            Console.WriteLine("Welcome - Login");
            Console.WriteLine();
            // Asking user Id to check it is in list or note( they have registered or not)
            Console.Write("Please enter the User Id : ");
            string Cus_UserID = Console.ReadLine();
            Console.WriteLine();

            bool check = false;

            foreach (User_Details checker in user_Details_List)
            {
                if (checker.User_Id == Cus_UserID)
                {
                    check = true;
                    login_user = checker;
                    Console.WriteLine("* * WELCOME * *");
                    Console.WriteLine();
                    string choice1="yes";
                    do
                    {
                        Console.WriteLine("Option 1 => Show Medicine List");
                        Console.WriteLine("Option 2 => Purchase Medicine ");
                        Console.WriteLine("Option 3 => Cancel Purchase");
                        Console.WriteLine("Option 4 => Show Purchase History");
                        Console.WriteLine("Option 5 => Recharge");
                        Console.WriteLine("Option 6 => Show Wallet Balance");
                        Console.WriteLine("Option 7 => Exit");
                        Console.WriteLine();
                        string suboption = Console.ReadLine();
                        Console.WriteLine();
                        

                        switch (suboption)
                        {
                            case "1":
                                {
                                    Console.WriteLine(" * Available Medicines * ");
                                    Console.WriteLine();
                                    Show_Medicine_List();
                                    break;
                                }
                            case "2":
                                {
                                    Purchase_Medicines();
                                    break;
                                }
                            case "3" :
                                {
                                    Cancel_Purchase();
                                    break;
                                }
                            case "4":
                                {
                                    Show_Purchase_history();
                                    break;
                                }
                            case "5":
                                {
                                    Recharge();
                                    break;
                                }
                            case "6" :
                                {
                                    Show_Balance();
                                    break;
                                }

                            case "7":
                                {
                                    choice1="no";
                                    Console.WriteLine("Thank You");
                                    break;
                                }
                            default :
                                {
                                    Console.WriteLine("Invalid Option");
                                    Console.WriteLine();
                                    break;
                                }
                        }

                    }while(choice1=="yes");

                }
            }

            if (check == false)
            {
                Console.WriteLine("Invalid user id !! Enter the Correct ID starts with UID**** ");
                Console.WriteLine();
            }
        }

        public static void Show_Medicine_List() // we are traversing the medicines from medicine list
        {
            foreach (Medicine_Details medicines in medicine_DetailsList)
            {
                Console.WriteLine("Medicine_ID : " + medicines.Medicine_ID);
                Console.WriteLine("Medicine Name : " + medicines.Medicine_Name);
                Console.WriteLine("Avalilable Count : " + medicines.Available_Count);
                Console.WriteLine("Price : " + medicines.Price);
                Console.WriteLine("Date Of Expiry : " + medicines.DateOfExpiry.ToString("MM/dd/yyyy"));
                Console.WriteLine();
            }
        }

        public static void Purchase_Medicines()
        {
            Console.WriteLine("Medicine Lists");
            Show_Medicine_List();
            Console.WriteLine();

            Console.Write("Select the medicine Using Medicine Id : ");
            string medicine_ID = Console.ReadLine();
            Console.WriteLine();

            bool check1 = false;
            foreach(Medicine_Details mediCheck in medicine_DetailsList)
            {
                if (mediCheck.Medicine_ID == medicine_ID) //checking medicine od with customer med id 
                {
                    check1 = true;
                    Console.Write("Number Of Counts you needed : ");
                    int counts = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (mediCheck.Available_Count >= counts)  // checking counts with medical counts
                    {
                        if (mediCheck.DateOfExpiry > DateTime.Now)  // checking expiry date of medicines
                        {
                            if (counts * mediCheck.Price < login_user.Balance) // checking the price of medicine with cus bal
                            {
                                mediCheck.Available_Count -= counts; // reducing the balance of customer
                                login_user.Balance -= counts * mediCheck.Price; // reducing the counts on medicines in medical

                                Order_Details orderObj = new Order_Details(login_user.User_Id, medicine_ID, counts, counts * mediCheck.Price, DateTime.Now, Order_Status.Purchased);
                                order_DetailsList.Add(orderObj);
                                Console.WriteLine("Medicine Purchased Successfully");
                                Console.WriteLine();
                                return;
                            }
                            else
                            {
                                Console.WriteLine("In sufficient fund Please Recharge your wallet");
                                Console.WriteLine();
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Medicine is Not Available");
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your entered count is not available.Please check the Medicine List for availablility");
                        Console.WriteLine();
                    }
                    break;
                }
            }
            if(check1==false)
            {
                Console.WriteLine("Invalid Medicine Id");
                Console.WriteLine();
            }
            
            
        }

        public static void Cancel_Purchase()
        {
            bool flags = false;
            foreach(Order_Details allOrders in order_DetailsList)
            {
                if(allOrders.User_Id == login_user.User_Id && allOrders.Order_Status == Order_Status.Purchased )
                {
                    flags = true;
                    Console.WriteLine("User Id : "+allOrders.User_Id+" "+"Order Id : "+allOrders.Order_ID+" "+"Order Date : "+allOrders.Order_Date.ToString("MM/dd/yyyy")+" "+"Medicine Id : "+allOrders.Medicine_ID+" ");
                }
            }
            if(!flags)
            {
                Console.WriteLine("There is no Purchase to cancel");
                return;
            }

                Console.WriteLine("Do you Need to Cancel Purchase Id (yes/no) : ");
                string answer = Console.ReadLine();
                if(answer == "yes")
                {
                    bool check = false;

                    Console.WriteLine("Enter the Order Id you need to cancel : ");
                    string orderId = Console.ReadLine();

                    foreach(Order_Details orders in order_DetailsList)
                    {
                        //checking the user user id with current login id and status is purchased
                        if(orders.Order_ID == orderId && orders.User_Id == login_user.User_Id && Order_Status.Purchased == orders.Order_Status)
                        {
                            check = true;
        
                            foreach(Medicine_Details medicine_count in medicine_DetailsList)
                            {
                                if(medicine_count.Medicine_ID == orders.Medicine_ID)
                                {
                                    medicine_count.Available_Count += orders.Medicine_count;
                                    login_user.Balance += orders.Total_Price;
                                    orders.Order_Status = Order_Status.Cancelled;
                                    Console.WriteLine(orders.Order_ID+" Order Has been Cancelled Successfully");
                                    Console.WriteLine();
                                    break;
                                }
                                
                            } 
                            break;
                        }
                    }
                    if(!check)
                    {
                        Console.WriteLine("Invalid Order ID..Please Provide the Correct Order ID you want to cancel");
                        Console.WriteLine("Here is your Purchase History");
                        Console.WriteLine();

                        foreach(Order_Details purchase_history in order_DetailsList)
                        {
                            if(purchase_history.User_Id == login_user.User_Id && purchase_history.Order_Status == Order_Status.Purchased)
                            {
                                Console.WriteLine("Order Id : "+purchase_history.Order_ID + " "+"Order Date : "+purchase_history.Order_Date.ToString("MM/dd/yyyy")+" "+"Medicine ID : "+purchase_history.Medicine_ID);
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("* * Thank you * *");
                    Console.WriteLine();
                }

        }

        public static void Show_Purchase_history()
        {
            Console.WriteLine("Purchase History");
            Console.WriteLine();

            bool check = false;
            foreach(Order_Details show_purchase in order_DetailsList)
            {
                if(login_user.User_Id == show_purchase.User_Id && show_purchase.Order_Status == Order_Status.Purchased)
                {
                    check = true;
                    Console.WriteLine("Order ID : "+show_purchase.Order_ID+" "+"Order Date : "+show_purchase.Order_Date.ToString("MM/dd/yyyy")+" "+"Medicine ID : "+show_purchase.Medicine_ID);
                }
            }

            if(!check)
            {
                Console.WriteLine("No purchase is Available");
                Console.WriteLine();
            }
        }

        public static void Recharge()
        {       double amount;
                bool flag = false;
            do{
                Console.Write("Enter the Amount to  be recharged : ");
                string recharge_amount = Console.ReadLine();
                if(double.TryParse(recharge_amount,out amount)&& amount > 0)
                {
                    flag = true;
                    login_user.Balance+=amount;
                    Console.WriteLine("Balance added Succcessfully");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Invalid Amount");
                }
            }while(!flag);
        }

        public static void Show_Balance()  
        {
            Console.WriteLine("Balance : "+login_user.Balance);
            Console.WriteLine();
        }
        public static void AddDefaultData()   // This for Default Details 
        {
            User_Details userObj1 = new User_Details("Ravi", 33, "Theni", 9877774440, 400);
            User_Details userObj2 = new User_Details("Baskaran", 33, "Chennai", 8847757470, 500);
            user_Details_List.Add(userObj1);
            user_Details_List.Add(userObj2);

            Medicine_Details mediObj1 = new Medicine_Details("Paracitamol", 40, 5, new DateTime(2023, 12, 30));
            Medicine_Details mediObj2 = new Medicine_Details("Calpol", 10, 5, new DateTime(2023, 11, 30));
            Medicine_Details mediObj3 = new Medicine_Details("Gelucil", 3, 40, new DateTime(2025, 04, 3));
            Medicine_Details mediObj4 = new Medicine_Details("Metrogel", 5, 50, new DateTime(2024, 12, 30));
            Medicine_Details mediObj5 = new Medicine_Details("Povidin Iodin", 10, 400, new DateTime(2026, 10, 30));
            medicine_DetailsList.Add(mediObj1);
            medicine_DetailsList.Add(mediObj2);
            medicine_DetailsList.Add(mediObj3);
            medicine_DetailsList.Add(mediObj4);
            medicine_DetailsList.Add(mediObj5);

            Order_Details orderObj1 = new Order_Details("UID1001", "MD2001", 3, 15, new DateTime(2023, 11, 13), Order_Status.Purchased);
            Order_Details orderObj2 = new Order_Details("UID1001", "MD2002", 2, 10, new DateTime(2023, 11, 13), Order_Status.Cancelled);
            Order_Details orderObj3 = new Order_Details("UID1001", "MD2003", 2, 100, new DateTime(2023, 11, 13), Order_Status.Purchased);
            Order_Details orderObj4 = new Order_Details("UID1002", "MD2004", 2, 120, new DateTime(2024, 01, 15), Order_Status.Cancelled);
            Order_Details orderObj5 = new Order_Details("UID1002", "MD2005", 5, 250, new DateTime(2025, 01, 15), Order_Status.Purchased);
            Order_Details orderObj6 = new Order_Details("UID1002", "MD2006", 3, 15, new DateTime(2024, 01, 15), Order_Status.Purchased);

            order_DetailsList.Add(orderObj1);
            order_DetailsList.Add(orderObj2);
            order_DetailsList.Add(orderObj3);
            order_DetailsList.Add(orderObj4);
            order_DetailsList.Add(orderObj5);
            order_DetailsList.Add(orderObj6);
        }

    }
}

