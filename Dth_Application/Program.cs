using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Data.Common;

namespace Dth_Recharge
{

    class Program
    {

        static List<User_Registration> user_RegistrationList = new List<User_Registration>();
        static List<Pack_Detail> pack_DetailsList = new List<Pack_Detail>();
        static List<Recharge_History> recharge_HistoryList = new List<Recharge_History>();

        static User_Registration login_user;


        public static void Main()
        {
            

            AddDefaultData();
            string choice = "no";

            Console.WriteLine("* * ONLINE DTH RECHARGE APPLICATION * *");
            Console.WriteLine();
            do
            {

                choice = "yes";
                Console.WriteLine("Main Menu");
                Console.WriteLine();
                Console.WriteLine("Select => 1.User Registration");
                Console.WriteLine("Select => 2.User Login");
                Console.WriteLine("Select => 3.Exit");
                Console.WriteLine();
                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        {
                            User_Registration();
                            break;
                        }
                    case "2":
                        {
                            Login();
                            break;
                        }
                    case "3":
                        {
                            choice = "no";
                            Console.WriteLine("Thank You ");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please Enter the valid Option");
                            break;
                        }
                }
            } while (choice == "yes");

        }

        public static void User_Registration()
        {
            Console.WriteLine("Welcome - User Registration");
            Console.WriteLine();

            string username = "";
            bool check = false;
            while (!check)
            {
                Console.Write("Enter your name : ");
                username = Console.ReadLine().TrimEnd().TrimStart();

                foreach (char u in username)
                {
                    check = true;
                    if (char.IsPunctuation(u) || char.IsDigit(u))
                    {
                        check = false;
                        break;
                    }
                }
                if (!check)
                {
                    Console.WriteLine("Please enter the valid name!! Name should not contain special characters and numbers");
                    Console.WriteLine();
                }

            }
            Console.WriteLine("Hyy Welcome " + username);
            Console.WriteLine();

            long phonenumber;
            while (true)
            {
                Console.Write("Enter your Phone number : ");
                string number = Console.ReadLine();

                if (number.Length == 10 && long.TryParse(number, out phonenumber))
                {
                    break;
                }

                Console.WriteLine("Please enter the valid Number");

            }

            string mail_Id = "";
            bool choice1 = false;
            while (!choice1)
            {
                Console.Write("Enter your Mail ID : ");
                mail_Id = Console.ReadLine().Trim();

                if (Regex.IsMatch(mail_Id, @"^[a-z][a-z0-9_.+-]+@gmail\.com$", RegexOptions.IgnoreCase) && !mail_Id.Contains(" "))
                {
                    choice1 = true;
                }
                else
                {
                    Console.WriteLine("Please enter the valid Mail ID please!!");
                    Console.WriteLine();
                }
            }

            int wallet_balance;
            while (true)
            {
                Console.Write("Enter wallet amount : ");
                if (int.TryParse(Console.ReadLine(), out wallet_balance) && wallet_balance > 0)
                {
                    break;
                }
                Console.WriteLine("Please enter the valid amount");
            }

            User_Registration DthObj = new User_Registration(username, phonenumber, mail_Id, wallet_balance);
            user_RegistrationList.Add(DthObj);
            Console.WriteLine();
            Console.WriteLine("Registration Successfully,Your User ID is : " + DthObj.User_Id);
            Console.WriteLine();

            InsertUserDetails(DthObj.UserName, DthObj.Mail_Id, DthObj.Number.ToString(), DthObj.Wallet_Balance);

        }



        public static void Login()
        {
            Console.WriteLine("WELCOME TO LOGIN PAGE");
            Console.WriteLine();

            Console.WriteLine("USER LOGIN");
            Console.WriteLine();
            Console.Write("Enter the User Id Please : ");
            string userId = Console.ReadLine();
            Console.WriteLine();
            bool check = false;

            foreach (User_Registration checker in user_RegistrationList)
            {
                if (checker.User_Id == userId)
                {
                    check = true;
                    login_user = checker;
                    Console.WriteLine("* * WELCOME * *");
                    Console.WriteLine();
                    string choice1 = "yes";

                    do
                    {
                        Console.WriteLine("Option 1 => Current Package");
                        Console.WriteLine("Option 2 => Pack Recharge");
                        Console.WriteLine("Option 3 => Wallet Recharge");
                        Console.WriteLine("Option 4 => View Pack Recharge History");
                        Console.WriteLine("Option 5 => Show Wallet Balance");
                        Console.WriteLine("Option 6 => Exit");
                        Console.Write("Enter the Option need : ");
                        string option = Console.ReadLine();
                        Console.WriteLine();

                        switch (option)
                        {
                            case "1":
                                {
                                    Current_pack();
                                    break;
                                }
                            case "2":
                                {
                                    Pack_Recharge();
                                    break;
                                }

                            case "3":
                                {
                                    Wallet_recharge();
                                    break;
                                }
                            case "4":
                                {
                                    Recharge_History();
                                    break;
                                }
                            case "5":
                                {
                                    Wallet_Balance();
                                    break;
                                }
                            case "6":
                                {
                                    choice1 = "no";
                                    Console.WriteLine();
                                    break;
                                }

                        }
                    } while (choice1 == "yes");
                }

            }
            if (!check)
            {
                Console.WriteLine("Invalid User Id!! Enter the Correct Id starts With UID**** ");
                Console.WriteLine();
            }
        }



        public static void Pack_Recharge()
        {
            bool choice1 = false;
            do
            {
                choice1 = true;
                Console.WriteLine("Available Packs");
                Console.WriteLine();
                foreach (Pack_Detail pack in pack_DetailsList)
                {
                    Console.WriteLine("Pack Id : " + pack.Pack_iD + " " + "Pack Name : " + pack.Pack_name + " " + "Pack Price : " + pack.Price + " " + "Pack Validity : " + pack.Validity + " " + "No of Channels : " + pack.No_of_channels);
                    Console.WriteLine();
                }
                bool flag = false;
                do
                {
                    flag = true;
                    Console.Write("Choose the pack you want to recharge : ");
                    string choose_ID = Console.ReadLine();
                    Console.WriteLine();
                    bool check = false;

                    foreach (Pack_Detail choosen_pack in pack_DetailsList)
                    {
                        if (choosen_pack.Pack_iD == choose_ID)
                        {
                            check = true;
                            if (choosen_pack.Price <= login_user.Wallet_Balance)
                            {
                                Recharge_History pack_Recharge = new Recharge_History(login_user.User_Id, choosen_pack.Pack_iD, DateTime.Now, choosen_pack.Price, DateTime.Now.AddDays(choosen_pack.Validity), choosen_pack.No_of_channels);
                                recharge_HistoryList.Add(pack_Recharge);
                                login_user.Wallet_Balance -= choosen_pack.Price;
                                Console.WriteLine("Recharge has successfully Completed");
                                Console.WriteLine();

                                // Insert the recharge history into the database immediately
                                InsertRechargeHistory(pack_Recharge.User_Id, pack_Recharge.Recharge_Id, pack_Recharge.Pack_ID, pack_Recharge.Recharge_Amount, pack_Recharge.Recharge_Date, pack_Recharge.Valid_time, pack_Recharge.No_of_channels,login_user.Wallet_Balance);
                            }
                            else
                            {
                                Console.WriteLine("Insufficient fund Please Recharge your Wallet");
                                Console.WriteLine();
                            }
                            break;
                        }
                    }
                    if (!check)
                    {
                        Console.WriteLine("Invalid Pack Id !! Try Again");
                        Console.WriteLine();
                    }
                } while (!flag);
            } while (!choice1);
        }

        public static void InsertRechargeHistory(string User_Id, string Recharge_Id, string Pack_ID, double Recharge_Amount, DateTime Recharge_Date, DateTime Valid_time, int No_of_channels,double wallet_balance)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Recharge_History (User_Id, Recharge_Id, Pack_ID, Recharge_Amount, Recharge_Date, Valid_time, No_of_channels , wallet_balance) VALUES (@User_Id, @Recharge_Id, @Pack_ID, @Recharge_Amount, @Recharge_Date, @Valid_time, @No_of_channels, @wallet_balance)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@User_Id", User_Id);
                    cmd.Parameters.AddWithValue("@Recharge_Id", Recharge_Id);
                    cmd.Parameters.AddWithValue("@Pack_ID", Pack_ID);
                    cmd.Parameters.AddWithValue("@Recharge_Amount", Recharge_Amount);
                    cmd.Parameters.AddWithValue("@Recharge_Date", Recharge_Date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@Valid_time", Valid_time.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@No_of_channels", No_of_channels);
                    cmd.Parameters.AddWithValue("@wallet_balance",wallet_balance);  
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public static void Current_pack()
        {
            Console.WriteLine("WELCOME THIS IS YOUR CURRENT PACK");
            Console.WriteLine();
            bool check = false;

            foreach (Recharge_History pack in recharge_HistoryList)
            {
                if (pack.User_Id == login_user.User_Id)
                {
                    check = true;
                    Console.WriteLine("User ID : " + pack.User_Id);
                    Console.WriteLine("Pack ID : " + pack.Pack_ID);
                    Console.WriteLine("Recharge amount" + pack.Recharge_Amount);
                    Console.WriteLine("Valid Till : " + pack.Valid_time.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Number of channels : " + pack.No_of_channels);
                    Console.WriteLine();
                    break;

                }
            }
            if (!check)
            {
                Console.WriteLine("There is No History Found");
                Console.WriteLine();
            }

        }

        /*public static void Pack_Recharge()
        {
            bool choice1 = false;
            do
            {
                choice1 = true;
                Console.WriteLine("Available Packs");
                Console.WriteLine();
                foreach (Pack_Detail pack in pack_DetailsList)
                {
                    Console.WriteLine("Pack Id : " + pack.Pack_iD + " " + "Pack Name : " + pack.Pack_name + " " + "Pack Price : " + pack.Price + " " + "Pack Validity : " + pack.Validity + " " + "No of Channels : " + pack.No_of_channels);
                    Console.WriteLine();
                }
                bool flag = false;
                do
                {
                    flag = true;
                    Console.Write("Choose the pack you want to recharge : ");
                    string choose_ID = Console.ReadLine();
                    Console.WriteLine();
                    bool check = false;

                    foreach (Pack_Detail choosen_pack in pack_DetailsList)
                    {
                        if (choosen_pack.Pack_iD == choose_ID)
                        {
                            check = true;
                            if (choosen_pack.Price <= login_user.Wallet_Balance)
                            {
                                Recharge_History pack_Recharge = new Recharge_History(login_user.User_Id, choosen_pack.Pack_iD, DateTime.Now, choosen_pack.Price, DateTime.Now.AddDays(choosen_pack.Validity), choosen_pack.No_of_channels);
                                recharge_HistoryList.Add(pack_Recharge);
                                login_user.Wallet_Balance -= choosen_pack.Price;
                                Console.WriteLine("Recharge has successfully Completed");
                                Console.WriteLine();

                                InsertRechargeHistory(pack_Recharge.User_Id,pack_Recharge.Recharge_Id, pack_Recharge.Pack_ID, pack_Recharge.Recharge_Amount, pack_Recharge.Recharge_Date, pack_Recharge.Valid_time, pack_Recharge.No_of_channels);


                            }
                            else
                            {
                                Console.WriteLine("Insufficient fund Please Recharge your Wallet");
                                Console.WriteLine();
                            }
                            break;
                        }
                    }
                    if (!check)
                    {
                        Console.WriteLine("Invalid Pack Id !! Try Again");
                        Console.WriteLine();
                    }
                } while (!flag);

            } while (!choice1);
        }*/

        public static void Wallet_recharge()
        {
            Console.WriteLine("Wallet Recharge");
            Console.WriteLine();
            double amount;
            bool check = false;
            while (!check)
            {
                Console.WriteLine("Enter the Amount");
                if (double.TryParse(Console.ReadLine(), out amount) && amount > 0)
                {
                    check = true;
                    login_user.Wallet_Balance += amount;
                    Console.WriteLine("Wallet Recharged Successfully");
                    Console.WriteLine();
                    break;
                }
                Console.WriteLine("Enter the valid Amount to recharge.Please Recharge the wallet greater than 0rs");
                Console.WriteLine();
            }


        }

        public static void Recharge_History()
        {
            Console.WriteLine("* * Package History * *");
            Console.WriteLine();
            bool check = false;
            foreach (Recharge_History history in recharge_HistoryList)
            {
                if (history.User_Id == login_user.User_Id)
                {
                    check = true;
                    Console.WriteLine("Recharge Id : " + history.Recharge_Id);
                    Console.WriteLine("Pack Id : " + history.Pack_ID);
                    Console.WriteLine("Recharge Amount : " + history.Recharge_Amount);
                    Console.WriteLine("Recharge Date : " + history.Recharge_Date.ToString("dd/MM/yyyy"));
                    Console.WriteLine("Validity Till : " + history.Valid_time.ToString("dd/MM/yyyy"));
                    Console.WriteLine("No of Channels : " + history.No_of_channels);
                    Console.WriteLine();
                    break;
                }


            }
            if (!check)
            {
                Console.WriteLine("No History Found");
                Console.WriteLine();
            }


        }
        public static void Wallet_Balance()
        {
            Console.WriteLine("Wallet Balance : " + login_user.Wallet_Balance);
            Console.WriteLine();
        }

        public static void AddDefaultData()
        {

            Pack_Detail pack1 = new Pack_Detail("RC150", "Pack 1", 150, 28, 40);
            Pack_Detail pack2 = new Pack_Detail("RC300", "Pack 2", 300, 56, 75);
            Pack_Detail pack3 = new Pack_Detail("RC150", "Pack 3", 500, 28, 200);
            Pack_Detail pack4 = new Pack_Detail("RC1500", "Pack 4", 1500, 365, 200);
            pack_DetailsList.Add(pack1);
            pack_DetailsList.Add(pack2);
            pack_DetailsList.Add(pack3);
            pack_DetailsList.Add(pack4);

        }

        public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Database=dth_application;Uid=root;Pwd=Ghf@2024;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

        public static void InsertUserDetails(string userName, string mail_Id, string number, double wallet_balance)
        {
            using (MySqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO UserDetails (UserName, mail_Id, number, wallet_balance) VALUES (@UserName, @mail_Id, @number, @wallet_balance)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@mail_Id", mail_Id);
                cmd.Parameters.AddWithValue("@number", number);
                cmd.Parameters.AddWithValue("@wallet_balance", wallet_balance);
                cmd.ExecuteNonQuery();
            }
        }

/*public static void InsertRechargeHistory(string User_Id, string Recharge_Id, string Pack_ID, double Recharge_Amount, DateTime Recharge_Date, DateTime Valid_time, int No_of_channels)
        {
            try
            {
                using (MySqlConnection connection = GetConnection())
                {
                    connection.Open();
                    string query = "INSERT INTO Recharge_History (User_Id, Recharge_Id, Pack_Id,Recharge_Amount,Recharge_Date,Valid_time,No_of_channels) VALUES (@User_Id, @Recharge_Id, @Pack_Id,@Recharge_Amount, @Recharge_Date, @Valid_time, @No_of_channels)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@User_Id", User_Id);
                    cmd.Parameters.AddWithValue("@Recharge_Id", Recharge_Id);
                    cmd.Parameters.AddWithValue("@Pack_ID", Pack_ID);
                    cmd.Parameters.AddWithValue("@Recharge_Amount", Recharge_Amount);
                    cmd.Parameters.AddWithValue("@Recharge_Date", Recharge_Date);
                    cmd.Parameters.AddWithValue("@Valid_time", Valid_time);
                    cmd.Parameters.AddWithValue("@No_of_channels", No_of_channels);
                    cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }



        }*/




    }
}
