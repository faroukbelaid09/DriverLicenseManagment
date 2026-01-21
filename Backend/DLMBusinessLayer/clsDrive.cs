using DLMDataLayer;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLMBusinessLayer
{
    public class clsDrive
    {
        public static int CreateDriver(CreateDriverDTO newDriver)
        {

            if(newDriver == null)
            {
                return -1;
            }

            return clsDriverDataAccess.CreateDriver(newDriver);
        }

        public static DriverDTO FindDriverByPersonId(int personId)
        {
            return clsDriverDataAccess.FindDriver(personId);
        }

        public static DriverDTO FindDriverById(int driverId)
        {
            return clsDriverDataAccess.FindDriverById(driverId);
        }

        public static int GetDriverID(int personId)
        {
            return clsDriverDataAccess.GetDriverID(personId);
        }

        public static List<DriverDTO> GetDrivers()
        {
            return clsDriverDataAccess.GetDrivers();
        }
    }
}