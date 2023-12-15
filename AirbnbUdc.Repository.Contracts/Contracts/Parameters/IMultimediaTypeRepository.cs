using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using System.Collections.Generic;

namespace AirbnbUdc.Repository.Contracts.Contracts.Parameters
{
    public interface IMultimediaTypeRepository
    {
        MultimediaTypeDbModel CreateRecord(MultimediaTypeDbModel record);
        int DeleteRecord(int recordId);
        int UpdateRecord(MultimediaTypeDbModel record);
        MultimediaTypeDbModel GetRecord(int recordId);
        IEnumerable<MultimediaTypeDbModel> GetAllRecords(string filter);

    }
}
