using AirbnbUdc.Repository.Contracts.Contracts.Parameters;
using AirbnbUdc.Repository.Contracts.DbModel.Parameters;
using AirbnbUdc.Repository.Implementation.DataModel;
using AirbnbUdc.Repository.Implementation.Mappers.Parameters;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AirbnbUdc.Repository.Implementation.Implementation.Parameters
{
    public class CustomerImplementationRepository: ICustomerRepository
    {
        public CustomerDbModel CreateRecord(CustomerDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    if (!db.Customer.Any(x => x.FirstName.Equals(record.FirstName)))
                    {
                        CustomerMapperRepository mapper = new CustomerMapperRepository();
                        Customer dbRecord = mapper.MapperT2toT1(record);
                        db.Customer.Add(dbRecord);
                        db.SaveChanges();
                        record.CustomerId = dbRecord.Id;
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
                    Customer record = db.Customer.FirstOrDefault(x => x.Id == recordId);
                    if (record != null)
                    {
                        db.Customer.Remove(record);
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
        public IEnumerable<CustomerDbModel> GetAllRecords(string filter)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var records = (
                    from c in db.Customer
                    where c.FirstName.Contains(filter)
                    select c
                    );
                //var recordsLambda = db.Country.Where(x => x.CountryName.Contains(filter));

                CustomerMapperRepository mapper = new CustomerMapperRepository();
                return mapper.MapperT1toT2(records);
            }
        }

        public CustomerDbModel GetRecord(int recordId)
        {
            using (Core_DBEntities db = new Core_DBEntities())
            {
                var record = db.Customer.Find(recordId);

                CustomerMapperRepository mapper = new CustomerMapperRepository();
                return mapper.MapperT1toT2(record);
            }
        }

        /// <summary>
        /// Método para actualizar un registro de Country en la base de datos
        /// </summary>
        /// <param name="record">Registro con nuevos datos</param>
        /// <returns>1 cuando se actualiza, 0 cuando no se actualiza o una excepciòn</returns>
        public int UpdateRecord(CustomerDbModel record)
        {
            try
            {
                using (Core_DBEntities db = new Core_DBEntities())
                {
                    CustomerMapperRepository mapper = new CustomerMapperRepository();
                    Customer dbRecord = mapper.MapperT2toT1(record);
                    db.Customer.Attach(dbRecord);
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
