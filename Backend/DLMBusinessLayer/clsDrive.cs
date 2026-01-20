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
        public int CreateDriverDTO(CreateDriverDTO newDriver)
        {

            if(newDriver == null)
            {
                return -1;
            }

            return clsDriverDataAccess.CreateDriver(newDriver);
        }

        public DriverDTO FindDriver(int personId)
        {
            return clsDriverDataAccess.FindDriver(personId);
        }

        public int GetDriverID(int personId)
        {
            return clsDriverDataAccess.GetDriverID(personId);
        }

        public List<DriverDTO> GetDrivers()
        {
            return clsDriverDataAccess.GetDrivers();
        }
    }
}
