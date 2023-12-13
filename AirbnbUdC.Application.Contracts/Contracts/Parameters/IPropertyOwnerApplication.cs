using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdC.Application.Contracts.Contracts.Parameters
{
    public interface IPropertyOwnerApplication
    {
        PropertyOwnerDTO CreateRecord(PropertyOwnerDTO record);
        int DeleteRecord(int recordId);
        int UpdateRecord(PropertyOwnerDTO record);
        PropertyOwnerDTO GetRecord(int recordId);
        IEnumerable<PropertyOwnerDTO> GetAllRecords(string filter);
    }
}
