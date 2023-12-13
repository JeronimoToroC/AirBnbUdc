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
    public class CustomerImplementationApplication : ICustomerApplication
    {
        ICustomerRepository _customerRepository;

        public CustomerImplementationApplication()
        {
            this._customerRepository = new CustomerImplementationRepository();
        }

        public CustomerDTO CreateRecord(CustomerDTO record)
        {
            CustomerMapperApplication mapper = new CustomerMapperApplication();
            CustomerDbModel mapped = mapper.MapperT2toT1(record);
            CustomerDbModel created = this._customerRepository.CreateRecord(mapped);
            return mapper.MapperT1toT2(created);
        }

        public int DeleteRecord(int recordId)
        {
            int deleted = this._customerRepository.DeleteRecord(recordId);
            return deleted;
        }

        public IEnumerable<CustomerDTO> GetAllRecords(string filter)
        {
            CustomerMapperApplication mapper = new CustomerMapperApplication();
            IEnumerable<CustomerDbModel> records = this._customerRepository.GetAllRecords(filter);
            return mapper.MapperT1toT2(records);
        }

        public CustomerDTO GetRecord(int recordId)
        {
            CustomerMapperApplication mapper = new CustomerMapperApplication();
            CustomerDbModel record = this._customerRepository.GetRecord(recordId);
            return mapper.MapperT1toT2(record);
        }

        public int UpdateRecord(CustomerDTO record)
        {
            CustomerMapperApplication mapper = new CustomerMapperApplication();
            CustomerDbModel mapped = mapper.MapperT2toT1(record);
            int updated = this._customerRepository.UpdateRecord(mapped);
            return updated;
        }
    }
}
