using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ass4
{
    public class DepartmentInfo
    {
        private static int s_department_id = 100;
        public string Department_Name{get ; set;}
        public int NumberOfSeats{get ; set ;}
        public string Department_Id{get ; set ;}

        public DepartmentInfo(string department_name,int numberOfSeats)
        {
            Department_Id = "DID"+ ++s_department_id;
            Department_Name = department_name;
            NumberOfSeats = numberOfSeats;
        }

        public DepartmentInfo(string ans)
        {
            string[] values = ans.Split(",");
            Department_Id = values[0];
            Department_Name = values[1];
            NumberOfSeats = int.Parse(values[2]);
        }
        
        public static void TakeAdmission(StudentInfo student,List<DepartmentInfo> departmentDetailsList,List<AdmissionInfo> admissionDetailList)
        {
                Console.WriteLine("Available Departments for Admission");
                Console.WriteLine();
                foreach(DepartmentInfo department in departmentDetailsList)
                {
                    Console.WriteLine("Department Id : "+department.Department_Id);
                    Console.WriteLine("Department Name : "+department.Department_Name);
                    Console.WriteLine("Number Of Seats Available : "+department.NumberOfSeats);
                }
                Console.Write("Choose the Department you Want to Join : ");
                string userDept = Console.ReadLine();

                int depart =departmentDetailsList.FindIndex(d => d.Department_Id==userDept);

                if(depart == -1)
                {
                    Console.WriteLine("Invalid Department Id or No Seats Available");
                    Console.WriteLine();
                }
                else
                {
                    double average = student.CheckEligibility(student.Chemistry,student.Maths,student.Physics);
                    if(average > 75.0)
                    {
                        if(departmentDetailsList[depart].NumberOfSeats > 0)
                        {
                            int departid = admissionDetailList.FindIndex(d =>d.Student_id == student.Student_id);

                            if(departid !=-1)
                            {
                                Console.WriteLine("You are Already admitted");
                            }
                            else
                            {
                                departmentDetailsList[depart].NumberOfSeats--;
                                
                                AdmissionInfo adObj = new AdmissionInfo(student.Student_id,departmentDetailsList[depart].Department_Id,DateTime.Now,Admission_Status.Booked);
                                admissionDetailList.Add(adObj);

                                Console.WriteLine("Admission Took successfully");
                                Console.WriteLine("Your admission Id is : "+adObj.Admission_Id);
                                Console.WriteLine();

                            }
                            
                        }

                    }

            }


        }


    }
}