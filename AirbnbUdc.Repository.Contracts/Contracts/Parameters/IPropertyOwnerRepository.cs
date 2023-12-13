using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirbnbUdc.Repository.Contracts.Contracts.Parameters
{
    public interface IPropertyOwnerRepository
    {
        PropertyOwnerDbModel CreateRecord(PropertyOwnerDbModel record);
        int DeleteRecord(int recordId);
        int UpdateRecord(PropertyOwnerDbModel record);
        PropertyOwnerDbModel GetRecord(int recordId);
        IEnumerable<PropertyOwnerDbModel> GetAllRecords(string filter);
    }
}
