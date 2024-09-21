using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using Ass4;
using System.Data.Common;


namespace College_Application
{
    public class FileHandling
    {
        public static void Create()
        {
            if(!Directory.Exists("College_Application "))
            {
               Console.WriteLine("Creating...");
               Directory.CreateDirectory("College_Application"); 
            }
            else
            {
                Console.WriteLine("College Application Directory already Exits");
            }

            // File for Student Info

            if(!File.Exists("College_Application/StudentInfo.csv"))
            {
                Console.WriteLine("Creating...");
                File.Create("College_Application/StudentInfo.csv").Close();
            }
            else
            {
                Console.WriteLine("studentDetail File already Exits");
            }

            // File for Department

            if(!File.Exists("College_Application/DepartmentInfo.csv"))
            {
                Console.WriteLine("Creating...");
                File.Create("College_Application/DepartmentInfo.csv").Close();
            }

            // File for Admission

             if(!File.Exists("College_Application/AdmissionInfo.csv"))
            {
                Console.WriteLine("Creating...");
                File.Create("College_Application/AdmissionInfo.csv").Close();
            }
                       
        }

        public static void WriteToCsv()
        {       // Student Info
            string[] students = new string[Program.studentDetailsList.Count];
            for(int i = 0;i<Program.studentDetailsList.Count;i++)
            {
                students[i] = Program.studentDetailsList[i].Student_id+","+ Program.studentDetailsList[i].Name+","+ Program.studentDetailsList[i].FatherName+","+ Program.studentDetailsList[i].Dob+","+ Program.studentDetailsList[i].Gender+","+ Program.studentDetailsList[i].Physics+","+ Program.studentDetailsList[i].Chemistry+","+ Program.studentDetailsList[i].Maths;
            }
            File.WriteAllLines("College_Application/StudentInfo.csv",students);

            // Department Info

            string[] departments = new string[Program.departmentDetailsList.Count];
            for(int i = 0;i<Program.departmentDetailsList.Count;i++)
            {
                departments[i] = Program.departmentDetailsList[i].Department_Id+","+Program.departmentDetailsList[i].Department_Name+","+Program.departmentDetailsList[i].NumberOfSeats;
            }
            File.WriteAllLines("College_Application/DepartmentInfo.csv",departments);


            // Admissions Info

            string[] admissions = new string[Program.admissionDetailsList.Count];
            for(int i = 0;i<Program.admissionDetailsList.Count;i++)
            {
                admissions[i] = Program.admissionDetailsList[i].Admission_Id+","+Program.admissionDetailsList[i].Student_id+","+Program.admissionDetailsList[i].Department_id+","+Program.admissionDetailsList[i].Admission_Date.ToString("dd/MM/yyyy")+","+Program.admissionDetailsList[i].Admission_Status;
            }
            File.WriteAllLines("College_Application/AdmissionInfo.csv",admissions);
        }

        public static void ReadFromCsv()
        {
            string[] students = File.ReadAllLines("College_Application/StudentInfo.csv");
            foreach(var ans in students)
            {
                StudentInfo sI = new StudentInfo(ans);
                Program.studentDetailsList.Add(sI);
            }

            string[] departments = File.ReadAllLines("College_Application/DepartmentInfo.csv");
            foreach(var ans in departments)
            {
                DepartmentInfo dI = new DepartmentInfo(ans);
                Program.departmentDetailsList.Add(dI);
            }

            string[] admission = File.ReadAllLines("College_Application/AdmissionInfo.csv");
            foreach(var ans in admission)
            {
                AdmissionInfo aI = new AdmissionInfo(ans);
                Program.admissionDetailsList.Add(aI);

            }
        }
    }
}