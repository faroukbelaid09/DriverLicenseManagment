using DLMDataLayer;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DLMBusinessLayer
{
    public class clsApplicationTypes
    {
        public static ApplicationTypeDTO GetApplicationTypeById(int appTypeId)
        {
            return clsApplicationTypesDataAccess.GetApplicationTypeById(appTypeId);
        }

        public static bool UpdateApplicationTypes(ApplicationTypeDTO applicationTypeDTO)
        {
            return clsApplicationTypesDataAccess.UpdateApplicationType(applicationTypeDTO);
        }

        public static List<ApplicationTypeDTO> GetAllApplicationTypes() 
        {
            return clsApplicationTypesDataAccess.GetAllApplicationTypes();
        }
    }
}
