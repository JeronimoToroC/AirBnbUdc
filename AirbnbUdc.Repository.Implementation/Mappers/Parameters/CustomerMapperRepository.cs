using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Repository.Implementation.Mappers.Parameters
{
    internal class CustomerMapperRepository : BaseMapperRepository<Customer, CustomerDbModel>
    {
        public override CustomerDbModel MapperT1toT2(Customer input)
        {
            CustomerMapperRepository customerMapper = new CustomerMapperRepository();
            return new CustomerDbModel
            {
                CustomerId = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                CellPhone = input.Cellphone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<CustomerDbModel> MapperT1toT2(IEnumerable<Customer> input)
        {
            IList<CustomerDbModel> list = new List<CustomerDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        public override Customer MapperT2toT1(CustomerDbModel input)
        {
            return new Customer
            {
                Id = input.CustomerId,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.CellPhone, 
                Photo = input.Photo,
            };
        }

        public override IEnumerable<Customer> MapperT2toT1(IEnumerable<CustomerDbModel> input)
        {
            IList<Customer> list = new List<Customer>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }

    }
}
