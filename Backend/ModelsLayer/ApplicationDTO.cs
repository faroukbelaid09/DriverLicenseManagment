using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class ApplicationDTO
    {
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public ApplicationDTO(int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            int ApplicationStatus, DateTime LastStatusDate, int PaidFees, int CreatedByUserID)
        {
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
        }
    }


    public class CreateApplicationDTO
    {
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public int ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public int PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        public CreateApplicationDTO(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID,
            int ApplicationStatus, DateTime LastStatusDate, int PaidFees, int CreatedByUserID)
        {
            this.ApplicantPersonID = ApplicantPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
        }
    }


    public class UpdateApplicationDTO
    {
        public int ApplicationID { get; set; }
        public int ApplicationStatus { get; set; }

        public UpdateApplicationDTO(int ApplicationID, int ApplicationStatus) 
        {
            this.ApplicationID = ApplicationID;
            this.ApplicationStatus = ApplicationStatus;
        }
    }
}