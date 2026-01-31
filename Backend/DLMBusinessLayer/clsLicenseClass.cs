using DLMDataLayer;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMBusinessLayer
{
    public class clsLicenseClass
    {
        public static List<LicenseClassDTO> GetLicenseClasses() 
        {
            return clsLicenseClassDataAccess.GetLicenseClasses();
        }

        public static LicenseClassDTO GetLicenseClass(string className) 
        {
            if (string.IsNullOrEmpty(className)) { return null; }

            return clsLicenseClassDataAccess.GetLicenseClassByName(className);
        }

        public static List<string> GetClassesNames() 
        {
            return clsLicenseClassDataAccess.GetClassesNames();
        }
    }
}
