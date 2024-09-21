using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Transactions;
using College_Application;

namespace Ass4{
    class Program{

           public static List <StudentInfo> studentDetailsList = new List<StudentInfo>();
           public static List <DepartmentInfo> departmentDetailsList = new List<DepartmentInfo>();
           public static List <AdmissionInfo> admissionDetailsList = new List<AdmissionInfo>();

            static StudentInfo login_user; 
        public static void Main()
        {
            FileHandling.Create();
            FileHandling.ReadFromCsv();

            StreamReader sm1 = new StreamReader("College_Application/StudentInfo.csv");
            string data1 = sm1.ReadLine();
           
            if(data1 == null)
            {
                Default_Data();
            }

            StreamReader sm2 = new StreamReader("College_Application/DepartmentInfo.csv");
            string data2 = sm2.ReadLine();
           
            if(data2 == null)
            {
                Default_Data();
            }

            StreamReader sm3 = new StreamReader("College_Application/AdmissionInfo.csv");
            string data3 = sm3.ReadLine(); 
           
            if(data3 == null)
            {
                Default_Data();
            }


                
            Console.WriteLine("Syncfusion  College of Engineering and Technology");
            Console.WriteLine();
             bool check = false;
        do{
            Console.WriteLine(" Option 1 => Registration");
            Console.WriteLine(" Option 2 => Student Login");
            Console.WriteLine(" Option 3 => Department wise seat availabilty");
            Console.WriteLine(" Option 4 => Exit");
            Console.WriteLine();
            Console.Write("Enter the Option you need to proceed : ");
            string options = Console.ReadLine();
            Console.WriteLine();

                switch(options)
                {
                    case "1":
                    { 
                        Registration();
                        break;
                    }
                    case "2" :
                    {
                        Student_Login();
                        break;   
                    }



                    case "3":
                    {
                        Department_Wise_Availability();
                        break;
                    }
                    case "4":
                    {
                        check = true;
                        break;
                    }
                    default :
                    {
                        Console.WriteLine("Please enter the valid Option");
                        Console.WriteLine();
                        break;
                    }

                }
            }while(check == false);

            FileHandling.WriteToCsv();
            
        }

        public static void Registration()
        {

            Console.Write("Do you need to register (yes or no) : ");
            string select = Console.ReadLine();
            Console.WriteLine();
            if(!select.Equals("Yes",StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Thank You !! Here is you Main Menu ");
                Console.WriteLine();
            }
            Console.WriteLine("Syncfusion college of engineering and Technology Welcomes You");
            Console.WriteLine();

            string student_name = "";
            bool check = false;
            while(!check)
            {
                Console.Write("Please enter the student Name : ");
                student_name = Console.ReadLine().Trim();

                foreach(char s in student_name)
                {
                    if(char.IsPunctuation(s) || char.IsDigit(s) || !student_name.Contains(" "))
                    {
                        check = true;
                        break;
                    }
                }
                if(!check)
                {
                    Console.WriteLine("Please enter the valid Name in valid Format");
                    Console.WriteLine();
                }

            }

            string father_name = "";
            bool check1 = false;
            while(!check1)
            {
                Console.Write("Please enter the father student Name : ");
                father_name = Console.ReadLine().Trim();

                foreach(char f in father_name)
                {
                    if(char.IsPunctuation(f) || char.IsDigit(f) || !student_name.Contains(" "))
                    {
                        check1 = true;
                        break;
                    }
                }
                if(!check1)
                {
                    Console.WriteLine("Please enter the valid Name in valid Format");
                    Console.WriteLine();
                }
            }

            string dob;
            DateTime date;
            while(true)
            {
                Console.Write("Please enter your date of birth in format(MM/dd/yyyy) : ");
                dob = Console.ReadLine().Trim();

                if(DateTime.TryParseExact(dob,"MM/dd/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out date))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter the dob in correct format as given");
                    Console.WriteLine();
                }
            }

            string gender_input = "";
            Gender gender;
            while(true)
            {
                Console.Write("Enter student Gender : ");
                gender_input = Console.ReadLine().Trim();

                if(Enum.TryParse(gender_input ,true,out gender))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter tha valid gender");
                    Console.WriteLine();
                }
            }

            double ph_mark = 0;
            bool check2 = false;
            while(!check2)
            {
                Console.Write("Enter the Physics mark : ");
                if(double.TryParse(Console.ReadLine(),out ph_mark) && ph_mark >= 0)
                {
                    check2 = true;
                    break;
                }
                Console.WriteLine("Mark should be in positive integer");
                Console.WriteLine();
            }

            double ch_mark = 0;
            bool check3 = false;
            while(!check3)
            {
                Console.Write("Enter the chemistry mark : ");
                if(double.TryParse(Console.ReadLine(),out ch_mark) && ch_mark >= 0)
                {
                    check3 = true;
                    break;
                }
                Console.WriteLine("Mark should be in positive integer");
                Console.WriteLine();
            }

            double math_mark = 0;
            bool check4 = false;
            while(!check4)
            {
                Console.WriteLine("Enter the maths mark : ");
                if(double.TryParse(Console.ReadLine(),out math_mark) && math_mark >= 0)
                {
                    check4 = true;
                    break;
                }
                Console.WriteLine("Mark should be in positive integer");
                Console.WriteLine();
            }

            StudentInfo student = new StudentInfo(student_name,father_name,DateTime.Parse(dob),Enum.Parse<Gender>(gender_input),ph_mark,ch_mark,math_mark);
            studentDetailsList.Add(student);

            Console.WriteLine("You have sucessfully registered !!");
            Console.WriteLine("Your student Id is : "+student.Student_id);
            Console.WriteLine();

   
        }

        public static void Student_Login()
        {
            Console.Write("Do you need to register (yes or no) : ");
            string select = Console.ReadLine();
            Console.WriteLine();
            if(select.Equals("No",StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Thank You !! Here is you Main Menu ");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("WELCOME - LOGIN");
            Console.WriteLine();
                
            Console.Write("Please enter the Student Id : ");
            string Student_id = Console.ReadLine().Trim();

            foreach(StudentInfo id in studentDetailsList)
            {
                if(id.Student_id == Student_id)
                {
                    login_user = id;
                    bool check = false;
                    do{
                        check = true;
                        Console.WriteLine(" SUB MENU");
                        Console.WriteLine();
                        Console.WriteLine("Option => 1.Check Eligibilty");
                        Console.WriteLine("Option => 2.Show Details");
                        Console.WriteLine("Option => 3.Take Admission");
                        Console.WriteLine("Option => 4.Cancel Admission");
                        Console.WriteLine("Option => 5.Show Admission Details");
                        Console.WriteLine("Option => 6.Exit");
                        Console.WriteLine("Enter the Option you need To Proceed : ");
                        string subOption = Console.ReadLine();

                        switch(subOption)
                        {
                            case "1" :
                            {
                                CheckEligibility();
                                break;
                            }
                            case "2" :
                            {
                                ShowDetails();
                                break;
                            }
                            case "3" :
                            {
                                Take_Admission();
                                break;
                            }
                            case "4" :
                            {
                                CancelAdmission();
                                break;
                            }
                            case "5" :
                            {
                                ShowAdmissionDetails();
                                break;
                            }
                            case "6" :
                            {
                                check = false;
                                break;
                            }
                            default :
                            {
                                Console.WriteLine("Please enter the valid Option");
                                break;
                            }
                        }    
                    }while(check);
                }
                else
                {
                        Console.WriteLine("Please enter the valid Id");
                        Console.WriteLine();
                    }
                    
                    
            }
       
        }
        public static void Department_Wise_Availability()
        {
            Console.WriteLine("Seat Availablility");
            Console.WriteLine();

            foreach(DepartmentInfo seats in departmentDetailsList)
            {
                Console.WriteLine("Department Name : "+seats.Department_Name);
                Console.WriteLine("Department Id : "+seats.Department_Id);
                Console.WriteLine();
            }

        }

        public static void CheckEligibility()
        {
            double average  = (login_user.Physics+login_user.Chemistry+login_user.Maths)/3;
            if(average >75.0)
            {
                Console.WriteLine("Student is Eligible");
                Console.WriteLine();
            }
            else
            {
            Console.WriteLine("Student is not Eligible");
            Console.WriteLine();
            }
            
        }

        public static void ShowDetails()
        {
            Console.WriteLine("STUDENT DETAILS");
            Console.WriteLine();

            Console.WriteLine("Student Name : "+login_user.Name);
            Console.WriteLine("Father Name : "+login_user.FatherName);
            Console.WriteLine("Student Id : "+login_user.Student_id);
            Console.WriteLine("DOB : "+login_user.Dob);
            Console.WriteLine("Gender "+login_user.Gender);
            Console.WriteLine("Physics Mark : "+login_user.Physics);
            Console.WriteLine("Chemistry Mark : "+login_user.Chemistry);
            Console.WriteLine("Maths Mark : "+login_user.Maths);
            Console.WriteLine();
        }

        public static void Take_Admission()
        {
            Console.WriteLine("WELCOME");
            Console.WriteLine();
            Console.WriteLine("Available Department");
            Console.WriteLine();

            foreach(DepartmentInfo depart in departmentDetailsList)
            {
                // displaying the departments by traversing in department list
                Console.WriteLine("Department name : "+depart.Department_Name);
                Console.WriteLine("Department Id : "+depart.Department_Id);
                Console.WriteLine("No of Seats Available : "+depart.NumberOfSeats);
                Console.WriteLine();
            }

                // asking to choose the department id
                Console.WriteLine("Please Enter the department Id : ");
                string userdepId = Console.ReadLine().Trim();
                bool check = false;
                foreach(DepartmentInfo checker in departmentDetailsList)
                {
                    if(checker.Department_Id == userdepId)
                    {
                        double average  = (login_user.Physics+login_user.Chemistry+login_user.Maths)/3;
                        if(average > 75.0)
                        {
                            if(checker.NumberOfSeats <= 0)
                            {
                                Console.WriteLine("There is no seat Available in this Department");
                                Console.WriteLine();
                            }
                            else
                            {
                                bool flag =false;
                                foreach(AdmissionInfo admission in admissionDetailsList)
                                {
                                    if(admission.Student_id == login_user.Student_id)
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                if(flag)
                                {
                                    Console.WriteLine("You have already taken admission");
                                    Console.WriteLine();
                                }
                                else
                                {
                            
                                    checker.NumberOfSeats--;

                                    AdmissionInfo newAdd = new AdmissionInfo(login_user.Student_id,checker.Department_Id,DateTime.Now,Admission_Status.Booked);
                                    admissionDetailsList.Add(newAdd);

                                    Console.WriteLine("Admission took Successfully.Your Admission Id is : "+newAdd.Admission_Id);
                                    Console.WriteLine();
                                    break;
                                }
                            }                
                        }    
                        else
                        {
                            Console.WriteLine("Student is not Eligible");
                            Console.WriteLine();
                        }   
                        break;
                    } 

                }
                if(!check)
                {
                    Console.WriteLine("Not Available");
                }
            
        }
    
        public static void CancelAdmission()
        {
            Console.WriteLine("Cancel Admission");
            Console.WriteLine();
            foreach(AdmissionInfo checker in admissionDetailsList)
            {
                if(checker.Student_id == login_user.Student_id && checker.Admission_Status == Admission_Status.Booked)
                {
                    Console.WriteLine("student Id : "+checker.Student_id);
                    Console.WriteLine("Department Id : "+checker.Department_id);
                    Console.WriteLine("Admission ID : "+checker.Admission_Id);
                    Console.WriteLine("Admission Date : "+checker.Admission_Date);
                    Console.WriteLine("Admission status : "+checker.Admission_Status);

                    checker.Admission_Status = Admission_Status.Cancelled;

                    foreach(DepartmentInfo addseat in departmentDetailsList)
                    {
                        if(addseat.Department_Id == checker.Department_id)
                        {
                            addseat.NumberOfSeats++;
                            Console.WriteLine("Admission Cancelled Successfully");
                            Console.WriteLine();
                            break;
                        }

                    }
                    break;

                }
            }
        }

        public static void ShowAdmissionDetails()
        {
            Console.WriteLine("WELCOME");
            Console.WriteLine();
            foreach(AdmissionInfo showadd in admissionDetailsList)
            {
                if(showadd.Student_id == login_user.Student_id && showadd.Admission_Status == Admission_Status.Booked)
                {
                Console.WriteLine("Details");
                Console.WriteLine("Student ID : "+showadd.Student_id);
                Console.WriteLine("Department ID : "+showadd.Department_id);
                Console.WriteLine("Admission Id : "+showadd.Admission_Id);
                Console.WriteLine("Admission Date : "+showadd.Admission_Date);
                Console.WriteLine("Admission status : "+showadd.Admission_Status);
                Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("No admission founded");
                    Console.WriteLine();
                    
                }
            }
            

        }

        public static void Default_Data()
        {
            StudentInfo std1 = new StudentInfo("Ravichandran E","Ettaparajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            StudentInfo std2 = new StudentInfo("Baskaran S", "Sethurajan",new DateTime(1999,11,11),Gender.Male,95,95,95);
            studentDetailsList.Add(std1);
            studentDetailsList.Add(std2);

            DepartmentInfo dep1 = new DepartmentInfo("EEE",29);
            DepartmentInfo dep2 = new DepartmentInfo("CSE",29);
            DepartmentInfo dep3 = new DepartmentInfo("MECH",30);
            DepartmentInfo dep4 = new DepartmentInfo("ECE",30);
            departmentDetailsList.Add(dep1);
            departmentDetailsList.Add(dep2);
            departmentDetailsList.Add(dep3);
            departmentDetailsList.Add(dep4);

            AdmissionInfo adm1 = new AdmissionInfo("SF3001","DID101",new DateTime(2022,05,11),Admission_Status.Booked); 
            AdmissionInfo adm2 = new AdmissionInfo("SF3002","DID102",new DateTime(2022,05,12),Admission_Status.Booked);
            admissionDetailsList.Add(adm1);
            admissionDetailsList.Add(adm2);
            


        }
    }
    
    }
        
                                    

                                    
                                        





