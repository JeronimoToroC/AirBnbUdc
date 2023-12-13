using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirbnbUdc.Repository.Contracts.Contracts.Parameters
{
    public interface ICustomerRepository
    {
        CustomerDbModel CreateRecord(CustomerDbModel record);
        int DeleteRecord(int recordId);
        int UpdateRecord(CustomerDbModel record);
        CustomerDbModel GetRecord(int recordId);
        IEnumerable<CustomerDbModel> GetAllRecords(string filter);
    }
}
