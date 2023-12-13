using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirbnbUdc.Repository.Implementation.Mappers.Parameters
{
    internal class PropertyOwnerMapperRepository : BaseMapperRepository<PropertyOwner, PropertyOwnerDbModel>
    {
        public override PropertyOwnerDbModel MapperT1toT2(PropertyOwner input)
        {
            PropertyOwnerMapperRepository propertyOwnerMapper = new PropertyOwnerMapperRepository();
            return new PropertyOwnerDbModel
            {
                PropertyOwnerId = input.Id,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                CellPhone = input.Cellphone,
                Photo = input.Photo,
            };
        }

        public override IEnumerable<PropertyOwnerDbModel> MapperT1toT2(IEnumerable<PropertyOwner> input)
        {
            IList<PropertyOwnerDbModel> list = new List<PropertyOwnerDbModel>();
            foreach (var item in input)
            {
                list.Add(MapperT1toT2(item));
            }
            return list;
        }

        public override PropertyOwner MapperT2toT1(PropertyOwnerDbModel input)
        {
            return new PropertyOwner
            {
                Id = input.PropertyOwnerId,
                FirstName = input.FirstName,
                FamilyName = input.FamilyName,
                Email = input.Email,
                Cellphone = input.CellPhone, 
                Photo = input.Photo,
            };
        }

        public override IEnumerable<PropertyOwner> MapperT2toT1(IEnumerable<PropertyOwnerDbModel> input)
        {
            IList<PropertyOwner> list = new List<PropertyOwner>();
            foreach (var item in input)
            {
                list.Add(MapperT2toT1(item));
            }
            return list;
        }

    }
}
