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
    public class PropertyOwnerImplementationApplication : IPropertyOwnerApplication
    {
        IPropertyOwnerRepository _propertyOwnerRepository;

        public PropertyOwnerImplementationApplication()
        {
            this._propertyOwnerRepository = new PropertyOwnerImplementationRepository();
        }

        public PropertyOwnerDTO CreateRecord(PropertyOwnerDTO record)
        {
            PropertyOwnerMapperApplication mapper = new PropertyOwnerMapperApplication();
            PropertyOwnerDbModel mapped = mapper.MapperT2toT1(record);
            PropertyOwnerDbModel created = this._propertyOwnerRepository.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(int recordId)
        {
            int deleted = this._propertyOwnerRepository.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<PropertyOwnerDTO> GetAllRecords(string filter)
        {
            PropertyOwnerMapperApplication mapper = new PropertyOwnerMapperApplication();
            IEnumerable<PropertyOwnerDbModel> records = this._propertyOwnerRepository.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);
        }

        public PropertyOwnerDTO GetRecord(int recordId)
        {
            PropertyOwnerMapperApplication mapper = new PropertyOwnerMapperApplication();
            PropertyOwnerDbModel record = this._propertyOwnerRepository.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(PropertyOwnerDTO record)
        {
            PropertyOwnerMapperApplication mapper = new PropertyOwnerMapperApplication();
            PropertyOwnerDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._propertyOwnerRepository.UpdateRecord(mapped);
            return updated;
        }
    }
}
