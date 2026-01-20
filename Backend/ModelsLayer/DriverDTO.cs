using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class DriverDTO
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public string CreatedDate { get; set; }

        public DriverDTO(int driverId, int personId, int createdId, string createdDate)
        {
            this.DriverID = driverId;
            this.PersonID = personId;
            this.CreatedByUserID = createdId;
            this.CreatedDate = createdDate;
        }
    }
}
