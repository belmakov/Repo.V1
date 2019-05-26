
namespace FaciTech.Apartment.Database.Models
{
    public class Community
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubAreaId { get; set; }
        public string BuilderName { get; set; }
        public string Address { get; set; }
        public string Landmark { get; set; }
        public string LocationLink { get; set; }
        public string AssociationName { get; set; }
        public string AssociationNumber { get; set; }
        public string AssociationBankName { get; set; }
        public string AssociationBankAccountNumber { get; set; }
        public string AssociationBankBranchAddress { get; set; }
        public string AssociationBankIFSC { get; set; }
        public string AmenityIds { get; set; }
    }
}
