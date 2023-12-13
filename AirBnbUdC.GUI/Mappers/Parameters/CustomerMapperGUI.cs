using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirBnbUdC.GUI.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBnbUdC.GUI.Mappers.Parameters
{
    public class CustomerMapperGUI : MapperBaseGUI<CustomerDTO, CustomerModel>
    {
        public override CustomerModel MapperT1toT2(CustomerDTO input)
        {
            return new CustomerModel
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                CellPhone = input.CellPhone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<CustomerModel> MapperT1toT2(IEnumerable<CustomerDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override CustomerDTO MapperT2toT1(CustomerModel input)
        {
            return new CustomerDTO
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                CellPhone = input.CellPhone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<CustomerDTO> MapperT2toT1(IEnumerable<CustomerModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}