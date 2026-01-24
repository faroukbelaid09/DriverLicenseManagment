using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class ApplicationTypeDTO
    {
        public int ApplicationTypeID {  get; set; }
        public string ApplicationTypeTitle { get; set; }
        public int ApplicationFees { get; set; }

        public ApplicationTypeDTO(int applicationTypeID, string applicationTypeTitle, int applicationFees)
        {
            this.ApplicationTypeID = applicationTypeID;
            this.ApplicationTypeTitle = applicationTypeTitle;
            this.ApplicationFees = applicationFees;
        }
    }
}