namespace AirbnbUdc.Repository.Contracts.DbModel.Parameters
{
    public class PropertyOwnerDbModel
    {
      public long PropertyOwnerId { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; } 
        public string Photo { get; set; }
    }
}
