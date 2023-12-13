using AirbnbUdC.Application.Contracts.DTO.Parameters;
using AirBnbUdC.GUI.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirBnbUdC.GUI.Mappers.Parameters
{
    public class PropertyOwnerMapperGUI : MapperBaseGUI<PropertyOwnerDTO, PropertyOwnerModel>
    {
        public override PropertyOwnerModel MapperT1toT2(PropertyOwnerDTO input)
        {
            return new PropertyOwnerModel
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                CellPhone = input.CellPhone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<PropertyOwnerModel> MapperT1toT2(IEnumerable<PropertyOwnerDTO> input)
        {
            foreach (var item in input)
            {
                yield return MapperT1toT2(item);
            }
        }

        public override PropertyOwnerDTO MapperT2toT1(PropertyOwnerModel input)
        {
            return new PropertyOwnerDTO
            {
                Id = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                CellPhone = input.CellPhone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<PropertyOwnerDTO> MapperT2toT1(IEnumerable<PropertyOwnerModel> input)
        {
            foreach (var item in input)
            {
                yield return MapperT2toT1(item);
            }
        }
    }
}