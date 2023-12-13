using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using AirbnbUdc.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirbnbUdc.Repository.Implementation.Implementation.Parameters
{
    public class PropertyOwnerImplementationRepository: IPropertyOwnerRepository
    {
        public PropertyOwnerDbModel CreateRecord(PropertyOwnerDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.PropertyOwner.Any(x => x.FirstName.Equals(record.FirstName)))
                    {
                        PropertyOwnerMapperRepository mapper = new PropertyOwnerMapperRepository();
                        PropertyOwner dbRecord = mapper.MapperT2toT1(record);
                        db.PropertyOwner.Add(dbRecord);
                        db.SaveChanges();
                        record.PropertyOwnerId = dbRecord.Id;
                    }
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return record;
        }

        /// <summary>
        /// Método para eliminar un registro de Country en la base de datos
        /// </summary>
        /// <param name="recordId">Id del registro a eliminar</param>
        /// <returns>1 cuando se elimina, 0 cuando no existe, o excepción</returns>
        public int DeleteRecord(int recordId)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    PropertyOwner record = db.PropertyOwner.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.PropertyOwner.Remove(record);
                        db.SaveChanges();
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (System.Exception e)
            {
                // porque se tiene como llave foránea en otra tabla
                throw e;
            }
        }

        /// <summary>
        /// Método para obtener todos los registros de Country en la base de datos
        /// </summary>
        /// <returns>Listado de registros con países</returns>
        public IEnumerable<PropertyOwnerDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.PropertyOwner
                    where c.FirstName.Contains(filter)
                    select c
                    );
                //var recordsLambda = db.Country.Where(x => x.CountryName.Contains(filter));

                PropertyOwnerMapperRepository mapper = new PropertyOwnerMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public PropertyOwnerDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.PropertyOwner.Find(recordId);

                PropertyOwnerMapperRepository mapper = new PropertyOwnerMapperRepository();
                return mapper.MapperT1toT2(record);
            }
        }

        /// <summary>
        /// Método para actualizar un registro de Country en la base de datos
        /// </summary>
        /// <param name="record">Registro con nuevos datos</param>
        /// <returns>1 cuando se actualiza, 0 cuando no se actualiza o una excepciòn</returns>
        public int UpdateRecord(PropertyOwnerDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    PropertyOwnerMapperRepository mapper = new PropertyOwnerMapperRepository();
                    PropertyOwner dbRecord = mapper.MapperT2toT1(record);
                    db.PropertyOwner.Attach(dbRecord);
                    db.Entry(dbRecord).State = EntityState.Modified;
                    return db.SaveChanges();
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }

        }
    }
}
