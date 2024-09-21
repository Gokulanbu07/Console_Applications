using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccinationDrive
{
    public enum VaccineName{Covishield,Covaccine};
    public class Vaccine_Details
    {
        public static int s_vaccine_Id = 2003;
        public int NoOfDoseAvailable{get ; set ;}
        public string Vaccine_Id{get ; set ;}
        public VaccineName VaccineName{get ; set ;}

        public Vaccine_Details(VaccineName vaccine_name,int noofdoseavailable)
        {
            Vaccine_Id = "CID"+ ++s_vaccine_Id;
            VaccineName = vaccine_name;
            NoOfDoseAvailable = noofdoseavailable;
        }
    }
}