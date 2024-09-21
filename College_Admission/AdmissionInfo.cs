using System;
using System.Collections.Generic;

namespace Ass4
{
    public enum Admission_Status { Select, Booked, Cancelled }
    public class AdmissionInfo
    {
        private static int s_Admission_Id = 1000;
        public string Student_id { get; set; }
        public string Department_id { get; set; }
        public DateTime Admission_Date { get; set; }
        public string Admission_Id { get; set; }
        public Admission_Status Admission_Status { get; set; }

        public AdmissionInfo(string student_id, string department_id, DateTime admission_date, Admission_Status admission_Status)
        {
            Admission_Id = "AID" + ++s_Admission_Id;
            Student_id = student_id;
            Department_id = department_id;
            Admission_Date = admission_date;
            Admission_Status = admission_Status;
        } 

        public AdmissionInfo(string ans)
        {
            string[] values = ans.Split(",");
            Admission_Id = values[0];
            s_Admission_Id = int.Parse(values[0].Remove(0,3));
            Student_id = values[1];
            Department_id = values[2];
            Admission_Date = DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            Admission_Status = Enum.Parse<Admission_Status>(values[4]);
        }  
    }

}
