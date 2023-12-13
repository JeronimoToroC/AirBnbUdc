using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdC.Application.Contracts.DTO.Parameters
{
    public class PropertyOwnerDTO
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Photo { get; set; }
    }
}
