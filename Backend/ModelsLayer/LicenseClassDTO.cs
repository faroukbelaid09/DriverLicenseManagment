using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class LicenseClassDTO
    {
        public int LicenseClassID { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int MinimumAllowedAge { get; set; }
        public int DefaultValidityLength { get; set; }
        public int ClassFees { get; set; }

        public LicenseClassDTO(int LicenseClassID, string ClassName, string ClassDescription, int MinimumAllowedAge
            , int DefaultValidityLength, int ClassFees) 
        {
            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;
            this.ClassDescription = ClassDescription;
        }
    }
}
