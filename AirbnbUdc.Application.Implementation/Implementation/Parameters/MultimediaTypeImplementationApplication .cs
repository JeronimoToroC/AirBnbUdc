using AirbnbUdc.Application.Implementation.Mappers.Paremeters;
using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.Implementation.Parameters;
using AirbnbUdC.Application.Contracts.Contracts.Parameters;
using AirbnbUdC.Application.Contracts.DTO.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Application.Implementation.Implementation.Parameters
{
    public class MultimediaTypeImplementationApplication : IMultimediaTypeApplication
    {
        IMultimediaTypeRepository _multimediaTypeRepository;

        public MultimediaTypeImplementationApplication()
        {
            this._multimediaTypeRepository = new MultimediaTypeImplementationRepository();
        }

        public MultimediaTypeDTO CreateRecord(MultimediaTypeDTO record)
        {
            MultimediaTypeMapperApplication mapper = new MultimediaTypeMapperApplication();
            MultimediaTypeDbModel mapped = mapper.MapperT2toT1(record);
            MultimediaTypeDbModel created = this._multimediaTypeRepository.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(int recordId)
        {
            int deleted = this._multimediaTypeRepository.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<MultimediaTypeDTO> GetAllRecords(string filter)
        {
            MultimediaTypeMapperApplication mapper = new MultimediaTypeMapperApplication();
            IEnumerable<MultimediaTypeDbModel> records = this._multimediaTypeRepository.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);
        }

        public MultimediaTypeDTO GetRecord(int recordId)
        {
            MultimediaTypeMapperApplication mapper = new MultimediaTypeMapperApplication();
            MultimediaTypeDbModel record = this._multimediaTypeRepository.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(MultimediaTypeDTO record)
        {
            MultimediaTypeMapperApplication mapper = new MultimediaTypeMapperApplication();
            MultimediaTypeDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._multimediaTypeRepository.UpdateRecord(mapped);
            return updated;
        }
    }
}
