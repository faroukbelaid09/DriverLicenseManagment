using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class LocalApplicationDTO
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public string DrivingClass { get; set; }
        public string NationalNo { get; set; }
        public string FullName { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int PassedTests { get; set; }
        public int ApplicationStatus { get; set; }

        public LocalApplicationDTO(int LocalDrivingLicenseApplicationID, string DrivingClass, string NationalNo,
            string FullName, DateTime ApplicationDate, int PassedTests, int ApplicationStatus)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.DrivingClass = DrivingClass;
            this.NationalNo = NationalNo;
            this.FullName = FullName;
            this.ApplicationDate = ApplicationDate;
            this.PassedTests = PassedTests;
            this.ApplicationStatus = ApplicationStatus;
        }
    }



    public class CreateLocalApplicationDTO 
    {
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }
        
        public CreateLocalApplicationDTO(int ApplicationID, int LicenseClassID)
        {
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }
    }



    public class FindLocalApplicationDTO
    {
        public int LocalDrivingLicenseApplicationID { get; set; }
        public int ApplicationID { get; set; }
        public int LicenseClassID { get; set; }

        public FindLocalApplicationDTO(int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            this.ApplicationID = ApplicationID;
            this.LicenseClassID = LicenseClassID;
        }
    }
}
