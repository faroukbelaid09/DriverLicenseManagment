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

        public ApplicationTypeDTO(int appTypeId, string appTypeTitle, int appTypeFee) 
        {
            this.ApplicationTypeID = appTypeId;
            this.ApplicationTypeTitle = appTypeTitle;
            this.ApplicationFees = appTypeFee;
        } 
    }
}
