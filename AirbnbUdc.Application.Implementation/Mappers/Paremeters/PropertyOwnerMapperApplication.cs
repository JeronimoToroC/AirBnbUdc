using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Application.Implementation.Mappers.Paremeters
{
    public class PropertyOwnerMapperApplication : MapperBaseApplication<PropertyOwnerDbModel, PropertyOwnerDTO>
    {
        public override PropertyOwnerDTO MapperT1toT2(PropertyOwnerDbModel input)
        {
            return new PropertyOwnerDTO
            {
                Id = input.PropertyOwnerId,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                CellPhone = input.CellPhone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<PropertyOwnerDTO> MapperT1toT2(IEnumerable<PropertyOwnerDbModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override PropertyOwnerDbModel MapperT2toT1(PropertyOwnerDTO input)
        {
            return new PropertyOwnerDbModel
            {
                PropertyOwnerId = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                CellPhone = input.CellPhone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<PropertyOwnerDbModel> MapperT2toT1(IEnumerable<PropertyOwnerDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}
