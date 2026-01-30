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
    public class clsApplication
    {
        public static List<LocalApplicationDTO> GetApplications()
        {
            return clsApplicationDataAccess.GetAllLocalApplications();
        }

        public static ApplicationDTO Find(int appID)
        {
            if (appID <= 0) 
            {
                return null;
            }

            return clsApplicationDataAccess.FindApplication(appID);
        }

        public static int Create(CreateApplicationDTO newApplication)
        {
            if (newApplication == null) 
            {
                return -1;
            }

            return clsApplicationDataAccess.CreateApplication(newApplication);
        }

        public static bool Update(UpdateApplicationDTO updatedApplication)
        {
            if (updatedApplication == null)
            {
                return false;
            }

            return clsApplicationDataAccess.UpdateApplicationStatus(updatedApplication);
        }
    }
}