using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public enum Dose_number{Dose1 = 1,Dose2 = 2,Dose3 = 3}
    public class Vaccination_Details
    {
        public static int s_vaccination_Id = 3003;
        public string Registration_number{get ; set ;}
        public string Vaccine_Id{get; set;}
        public int Dose_number{get; set;}
        public DateTime Vaccination_Date{get ; set ;}
        public string Vaccination_ID{get ; set ;}

        public Vaccination_Details(string registration_number,string vaccine_Id,int dose,DateTime vaccination_date)
        {
            Vaccination_ID = "VID"+ ++s_vaccination_Id;
            Registration_number = registration_number;
            Vaccine_Id = vaccine_Id;
            Dose_number = dose;
            Vaccination_Date = vaccination_date;
        }
    }
}