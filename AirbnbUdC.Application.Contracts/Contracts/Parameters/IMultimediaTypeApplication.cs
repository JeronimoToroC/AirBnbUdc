using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System.Collections.Generic;

namespace AirbnbUdC.Application.Contracts.Contracts.Parameters
{
    public interface IMultimediaTypeApplication
    {
        MultimediaTypeDTO CreateRecord(MultimediaTypeDTO record);
        int DeleteRecord(int recordId);
        int UpdateRecord(MultimediaTypeDTO record);
        MultimediaTypeDTO GetRecord(int recordId);
        IEnumerable<MultimediaTypeDTO> GetAllRecords(string filter);
    }
}
