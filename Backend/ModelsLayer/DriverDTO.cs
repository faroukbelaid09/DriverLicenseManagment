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
        public DateTime CreatedDate { get; set; }

        public DriverDTO(int driverId, int personId, int createdId, DateTime createdDate)
        {
            this.DriverID = driverId;
            this.PersonID = personId;
            this.CreatedByUserID = createdId;
            this.CreatedDate = createdDate;
        }
    }

    public class CreateDriverDTO
    {
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public CreateDriverDTO(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
        }
    }

    public class UpdateDriverDTO
    {
        public int DriverID { get; set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public UpdateDriverDTO(int driverId, int personId, int createdId, DateTime createdDate)
        {
            this.DriverID = driverId;
            this.PersonID = personId;
            this.CreatedByUserID = createdId;
            this.CreatedDate = createdDate;
        }
    }
}
