using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdC.Application.Contracts.Contracts.Parameters
{
    public interface ICustomerApplication
    {
        CustomerDTO CreateRecord(CustomerDTO record);
        int DeleteRecord(int recordId);
        int UpdateRecord(CustomerDTO record);
        CustomerDTO GetRecord(int recordId);
        IEnumerable<CustomerDTO> GetAllRecords(string filter);
    }
}
