using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Net.Mail;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
namespace VaccinationDrive{
    class Program{

        static List<Benificiary> Benificiary_List = new List<Benificiary>();
        static List<Vaccine_Details> vaccine_Details_List = new List<Vaccine_Details>();

        static List<Vaccination_Details> vaccination_Details_List = new List<Vaccination_Details>();

        static Benificiary login_user;

        public static void Main()
        {

            Console.WriteLine("Vaccination Drive");
            Console.WriteLine();
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
                           Benificiary_Registartion(); // calling the user registration method
                            break;
                        }
                    case "2":
                        {
                            Login(); // calling the user login method
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
            }while(choice == "Yes");

        }

        public static void Benificiary_Registartion()
        {
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

            string gender1 = "";
            Gender gender;
            while(true)
            {
                Console.WriteLine("Enter your Gender: ");
                gender1 = Console.ReadLine();
                if(Enum.TryParse(gender1,true,out gender))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please Enter the Correct Gender");
                }
             }

            long mobile_number;
            while(true)
            {
                Console.Write("Enter your Phone number : ");
                string number = Console.ReadLine();
    
                if(number.Length == 10 && long.TryParse(number,out mobile_number))
                {
                    break;
                }

                Console.WriteLine("Please enter the valid Number");
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

            Benificiary users = new Benificiary(username,age,gender,mobile_number,city);
            Benificiary_List.Add(users);
            Console.WriteLine("Registration has Successfully Completed");
            Console.WriteLine("Your Registration number is : "+users.Registration_number);
            Console.WriteLine();


        }
        public static void Login()
        {
            Add_Default_data();
            bool flag = false;
        
                //ask registration no from user:
                Console.WriteLine("Enter your Registration No: ");
                string registrationNumber = Console.ReadLine().ToUpper();
                
                foreach(Benificiary user in Benificiary_List)
                {
                    // check the user registration no is present or not:
                    if(user.Registration_number == registrationNumber)
                    {
                        flag = true;
                        login_user = user;
                        Console.WriteLine("Login Successful: ");
                        bool check= false;
                        do
                        {
                            //show the submenu:
                            Console.WriteLine("Sub Menu: ");
                            Console.WriteLine();
                            Console.WriteLine("Option 1 => Show My Details: ");
                            Console.WriteLine("Option 2 => Take Vaccination: ");
                            Console.WriteLine("Option 3 => My vaccination history: ");
                            Console.WriteLine("Option 4 => NextDue Date: ");
                            Console.WriteLine("Option 5 => Exit:");

                            //ask the user to choose the submenu options:
                            Console.WriteLine("Enter the Option to choose the sub menu:");
                            string subOption = Console.ReadLine().Trim();
                            switch(subOption)
                            {
                                case "1":
                                {
                                    //method call for user detailst:
                                    Show_Details();
                                    break;
                                }
                                case "2":
                                {
                                    // method calling for take vaccination:
                                    Take_Vaccination();
                                    break;
                                }
                                case "3":
                                {
                                    //method calling for My vaccinationHistory:
                                    Vaccination_History();
                                    break;
                                }
                                case "4":
                                {
                                    //method calling for DueDate:
                                    NextDueDate();
                                    break;
                                }
                                case "5":
                                {
                                    check = true;
                                    break;
                                }
                                default:
                                {
                                    Console.WriteLine("Enter the Correct Option:");
                                    break;
                                }
                            }
                        }while(!check);
                        
                        
                    }
                }
                if(!flag)
                {
                    Console.WriteLine("PLease Enter the valid Registration NO");
                }
           
        }

        public static void Show_Details()
        {
            Console.WriteLine("Welcome !! Here is Your Details");
            Console.WriteLine();
            Console.WriteLine(""+login_user.Name);
            Console.WriteLine(""+login_user.Age);
            Console.WriteLine(""+login_user.Registration_number);
            Console.WriteLine(""+login_user.City);
            Console.WriteLine(""+login_user.Gender);
            Console.WriteLine(""+login_user.Mobile_Number);
            Console.WriteLine();
        }

        public static void Take_Vaccination()
        {
            bool check = false;
            Console.WriteLine("Enter the valid Vaccine Id : ");
            string vaccine_id = Console.ReadLine();

            foreach(Vaccine_Details checker in vaccine_Details_List)
            {
                if(checker.Vaccine_Id == vaccine_id)
                {
                    check = true;
                    bool vaccinationcheck = false;
                    bool noOfVaccine_check = false;
                    int noOfVaccine = 0;

                    foreach(Vaccination_Details history in vaccination_Details_List)
                    {
                        if(history.Registration_number == login_user.Registration_number)
                        {
                            if(history.Vaccination_ID == vaccine_id)
                            {
                                vaccinationcheck= true;
                                Console.WriteLine("Registartion number : "+history.Registration_number);
                                Console.WriteLine("Vaccination ID : "+history.Vaccination_ID);
                                Console.WriteLine("Vaccination_ date : "+history.Vaccination_Date);
                                Console.WriteLine("Vaccine Id : "+history.Vaccine_Id);
                                Console.WriteLine("Dose_number"+history.Dose_number);

                                if(history.Dose_number ==3)
                                {
                                    noOfVaccine_check = true;
                                    break;
                                }
                                noOfVaccine = history.Dose_number;
                            }

                        }
                        bool vaccinationcheck1 = false;

                        if(noOfVaccine_check)
                        {
                            Console.WriteLine("Sorry you have Vaccinated 3 doses.You can't take Vaccine");

                            Console.WriteLine();
                            break;
                        }
                        else
                        {
                            foreach(Vaccination_Details history2 in vaccination_Details_List)
                            {
                                if(history.Registration_number == login_user.Registration_number)
                                {
                                    if(history.Vaccination_Date.AddDays(30) < DateTime.Now)
                                    {
                                        Vaccination_Details vaccineObj = new Vaccination_Details(login_user.Registration_number,checker.Vaccine_Id,noOfVaccine+=1,DateTime.Now);
                                        vaccination_Details_List.Add(vaccineObj);
                                        checker.NoOfDoseAvailable--;
                                        Console.WriteLine("Vaccination Successfully completed");
                                        Console.WriteLine();
                                        vaccinationcheck = true;
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Your Due has been not completed");
                                        break;
                                    }
                                }
                                else
                                {
                                    if(history.Vaccination_Date.AddDays(30) < DateTime.Now)
                                    {
                                        Console.WriteLine("You have selected a different vaccine. You can vaccine with" +checker.VaccineName+" "+" his "+history.Dose_number +" dose vaccine type");
                                        Vaccination_Details vaccineObj = new Vaccination_Details(login_user.Registration_number,history.Vaccine_Id,noOfVaccine++,DateTime.Now);
                                        vaccination_Details_List.Add(vaccineObj);
                                        checker.NoOfDoseAvailable--;
                                        Console.WriteLine("Successfully Completed");
                                        vaccinationcheck = true;
                                        break;

                                    }
                                    else
                                    {
                                        Console.WriteLine("Your due date is not arrived");
                                        Console.WriteLine();
                                        break;
                                    }
                                }
                            }
                        }

                        
                    }
                    if(!vaccinationcheck)
                    {
                        if(login_user.Age > 14)
                        {
                            Vaccination_Details newuser = new Vaccination_Details(login_user.Registration_number,checker.Vaccine_Id,(int)Dose_number.Dose1,DateTime.Now);
                            vaccination_Details_List.Add(newuser);
                            checker.NoOfDoseAvailable--;
                            Console.WriteLine("Vaccinated Successfully");
                            break;

                        }
                    }
                    if(vaccinationcheck)
                    {
                        break;
                    }
                }
            }
            if(!check)
            {
                Console.WriteLine("Please enter the valid Id number");
            }
               
        }

        public static void Vaccination_History()
        {
            bool vaccine_history = false;
            foreach(Vaccination_Details history in vaccination_Details_List)
            {
                if( history.Registration_number== login_user.Registration_number) //check the vaccination history.
                {
                    vaccine_history = true;
                    Console.WriteLine("Vaccine ID : "+history.Vaccine_Id+" "+" User RegistrationNo : "+history.Registration_number+" "+" VaccinationID : "+history.Vaccination_ID+" Dose No: "+(int)history.Dose_number+" "+" VaccinationDate : "+history.Vaccination_Date.ToString("dd/MM/yyyy"));
                    Console.WriteLine();
                }
            }
            if(!vaccine_history)
            {
                Console.WriteLine("Vaccination History Not Found");
            }
        }

        public static void NextDueDate()
        {
            bool check = false;
            int noOfDose = 0;
            foreach(Vaccination_Details vacciHistory in vaccination_Details_List)
            {
                if(vacciHistory.Registration_number == login_user.Registration_number)
                {
                    check = true;
                    if(vacciHistory.Vaccination_Date.AddDays(30) > DateTime.Now)
                    {
                        noOfDose = vacciHistory.Dose_number;
                        if(noOfDose == 3)
                        {
                            Console.WriteLine("You have Completed all the Vaccination.Thanks for your Participation in drive");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Your Due Date is : "+vacciHistory.Vaccination_Date.AddDays(30).ToString("MM/dd/yyyy"));
                    }
                }
                else
                {
                    Console.WriteLine("your Due Date is Completed");
                }

            }
        }

        public static void GetVaccineDetail()
        {
            foreach(Vaccine_Details vaccines in vaccine_Details_List)
            {
                Console.WriteLine("Vaccine_Id : "+vaccines.Vaccine_Id);
                Console.WriteLine("Vaccine Name : "+vaccines.VaccineName);
                Console.WriteLine("No Of Dose Available : "+vaccines.NoOfDoseAvailable);
                Console.WriteLine();
            }
        }
        

        
        
        
        
        
        
        
        public static void Add_Default_data()
        {
            Benificiary user1 = new Benificiary("Ravichandran",21,Gender.Male,8484484123,"Chennai");
            Benificiary user2 = new Benificiary("Baskaran",22,Gender.Male,8482444323,"Chennai");
            Benificiary_List.Add(user1);
            Benificiary_List.Add(user2);

            Vaccine_Details vaccine1 = new Vaccine_Details(VaccineName.Covishield,50);
            Vaccine_Details vaccine2 = new Vaccine_Details(VaccineName.Covaccine,50);
            vaccine_Details_List.Add(vaccine1);
            vaccine_Details_List.Add(vaccine2);

            Vaccination_Details vaccination1 = new Vaccination_Details("BID1001","CID2001",(int)Dose_number.Dose1,new DateTime(2024,03,31));
            Vaccination_Details vaccination2 = new Vaccination_Details("BID1001","CID2001",(int)Dose_number.Dose2,new DateTime(2024,04,30));
            Vaccination_Details vaccination3 = new Vaccination_Details("BID1002","CID2002",(int)Dose_number.Dose3,new DateTime(2024,03,04));
            vaccination_Details_List.Add(vaccination1);
            vaccination_Details_List.Add(vaccination2);
            vaccination_Details_List.Add(vaccination3);
        }
    }

}
