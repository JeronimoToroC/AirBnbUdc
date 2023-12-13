using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Application.Implementation.Mappers.Paremeters
{
    public class CustomerMapperApplication : MapperBaseApplication<CustomerDbModel, CustomerDTO>
    {
        public override CustomerDTO MapperT1toT2(CustomerDbModel input)
        {
            return new CustomerDTO
            {
                Id = input.CustomerId,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                CellPhone = input.CellPhone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<CustomerDTO> MapperT1toT2(IEnumerable<CustomerDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override CustomerDbModel MapperT2toT1(CustomerDTO input)
        {
            return new CustomerDbModel
            {
                CustomerId = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                CellPhone = input.CellPhone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<CustomerDbModel> MapperT2toT1(IEnumerable<CustomerDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
