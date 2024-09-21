using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee_Pay_Roll
{
    public enum Location {Chennai,Banglaore,Hyderabad,Mysore,Calicut,dubai,America,France,Mumbai}
    public enum Gender{Male,Female,others}
    public class Employee_Details
    {
        private static int s_employee_Id = 1000;
        public string Employee_Name {get; set ;}
        public string Gender_input{get ; set;}
        public string Employee_Role{get; set;}
        public string Work_Location{get; set;}
        public string Team_Name{get ; set;}
        public string DateOfJoining{get; set;}        
        public string Employee_id{get ; set;}

        public Employee_Details(string employee_name,string gender_input,string employee_role,string work_location,string team_name,string dateOfJoining)
        {
            Employee_id = "SF"+ ++s_employee_Id;
            Employee_Name = employee_name;
            Gender_input = gender_input;
            Employee_Role = employee_role;
            Work_Location = work_location;
            Team_Name = team_name;
            DateOfJoining = dateOfJoining;

            
            
    }
}
}
