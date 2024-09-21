using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Ass4
{
    public enum Gender{Male,Female,Transgender}
    public class StudentInfo
    {
        private static int s_student_id = 3000;

        public string Name{get ; set ;}
        public string FatherName{get ; set ;}
        public DateTime Dob{get; set ;}
        public Gender Gender{get ; set;}
        public double Physics{get ; set;}
        public double Chemistry{get ; set ;}
        public double Maths{get ; set ;}
        public string Student_id{get ; set ;}

        public StudentInfo(string name,string fatherName,DateTime dob,Gender gender,double physics,double chemistry,double maths)
        {
            Student_id ="SF"+ ++s_student_id;
            Name = name;
            FatherName = fatherName;
            Dob = dob;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }

        public StudentInfo(string ans)
        {
            string[] values = ans.Split(",");
            Student_id = values[0];
            s_student_id = int.Parse(values[0].Remove(0,2)) ;
            Name = values[1];
            FatherName = values[2];
            Dob = DateTime.Parse(values[3]);
            Gender = Enum.Parse<Gender>(values[4]);
            Physics = int.Parse(values[5]);
            Chemistry = int.Parse(values[6]);
            Maths = int.Parse(values[7]);
        }













        public double CheckEligibility(double physics,double chemistry,double maths)
        {
            double average = (physics+chemistry+maths)/3;

            return average;
        }

        public void ShowDetails(List<StudentInfo> stu,int ind)
        {
            Console.WriteLine("Student Id : "+stu[ind].Student_id);
            Console.WriteLine("Name : "+stu[ind].Name);
            Console.WriteLine("Father Name : "+stu[ind].FatherName);
            Console.WriteLine("DOB : "+stu[ind].Dob);
            Console.WriteLine("Gender : "+stu[ind].Gender);
            Console.WriteLine("Physics Mark : "+stu[ind].Physics);
            Console.WriteLine("Chemistry Mark : "+stu[ind].Chemistry);
            Console.WriteLine("Maths Mark : "+Maths);
        }
        

    }
}