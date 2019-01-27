using System;
using System.Collections.Generic;

namespace CommunityMgmtPortal.Models
{
    public partial class User : BaseEntity
    {
        public User()
        {
            AmenityCreatedByNavigation = new HashSet<Amenity>();
            AmenityTypeCreatedByNavigation = new HashSet<AmenityType>();
            AmenityTypeUpdatedByNavigation = new HashSet<AmenityType>();
            AmenityUpdatedByNavigation = new HashSet<Amenity>();
            AreaCreatedByNavigation = new HashSet<Area>();
            AreaSupervisor = new HashSet<Area>();
            AreaUpdatedByNavigation = new HashSet<Area>();
            BlockCreatedByNavigation = new HashSet<Block>();
            BlockUpdatedByNavigation = new HashSet<Block>();
            CityCreatedByNavigation = new HashSet<City>();
            CityUpdatedByNavigation = new HashSet<City>();
            CommunityCreatedByNavigation = new HashSet<Community>();
            CommunityUpdatedByNavigation = new HashSet<Community>();
            ContactCreatedByNavigation = new HashSet<Contact>();
            ContactUpdatedByNavigation = new HashSet<Contact>();
            CountryCreatedByNavigation = new HashSet<Country>();
            CountryUpdatedByNavigation = new HashSet<Country>();
            InverseCreatedByNavigation = new HashSet<User>();
            InverseUpdatedByNavigation = new HashSet<User>();
            LocationCreatedByNavigation = new HashSet<Location>();
            LocationUpdatedByNavigation = new HashSet<Location>();
            RegionCreatedByNavigation = new HashSet<Region>();
            RegionTypeCreatedByNavigation = new HashSet<RegionType>();
            RegionTypeUpdatedByNavigation = new HashSet<RegionType>();
            RegionUpdatedByNavigation = new HashSet<Region>();
            SubAreaCreatedByNavigation = new HashSet<SubArea>();
            SubAreaSupervisor = new HashSet<SubArea>();
            SubAreaUpdatedByNavigation = new HashSet<SubArea>();
            TenantAmenityEntitlementCreatedByNavigation = new HashSet<TenantAmenityEntitlement>();
            TenantAmenityEntitlementUpdatedByNavigation = new HashSet<TenantAmenityEntitlement>();
            TenantCreatedByNavigation = new HashSet<Tenant>();
            TenantUpdatedByNavigation = new HashSet<Tenant>();
            UnitCreatedByNavigation = new HashSet<Unit>();
            UnitUpdatedByNavigation = new HashSet<Unit>();
        }

        public string UserName { get; set; }
        public Guid ContactId { get; set; }

        public Contact Contact { get; set; }
        public User CreatedByNavigation { get; set; }
        public User UpdatedByNavigation { get; set; }
        public ICollection<Amenity> AmenityCreatedByNavigation { get; set; }
        public ICollection<AmenityType> AmenityTypeCreatedByNavigation { get; set; }
        public ICollection<AmenityType> AmenityTypeUpdatedByNavigation { get; set; }
        public ICollection<Amenity> AmenityUpdatedByNavigation { get; set; }
        public ICollection<Area> AreaCreatedByNavigation { get; set; }
        public ICollection<Area> AreaSupervisor { get; set; }
        public ICollection<Area> AreaUpdatedByNavigation { get; set; }
        public ICollection<Block> BlockCreatedByNavigation { get; set; }
        public ICollection<Block> BlockUpdatedByNavigation { get; set; }
        public ICollection<City> CityCreatedByNavigation { get; set; }
        public ICollection<City> CityUpdatedByNavigation { get; set; }
        public ICollection<Community> CommunityCreatedByNavigation { get; set; }
        public ICollection<Community> CommunityUpdatedByNavigation { get; set; }
        public ICollection<Contact> ContactCreatedByNavigation { get; set; }
        public ICollection<Contact> ContactUpdatedByNavigation { get; set; }
        public ICollection<Country> CountryCreatedByNavigation { get; set; }
        public ICollection<Country> CountryUpdatedByNavigation { get; set; }
        public ICollection<User> InverseCreatedByNavigation { get; set; }
        public ICollection<User> InverseUpdatedByNavigation { get; set; }
        public ICollection<Location> LocationCreatedByNavigation { get; set; }
        public ICollection<Location> LocationUpdatedByNavigation { get; set; }
        public ICollection<Region> RegionCreatedByNavigation { get; set; }
        public ICollection<RegionType> RegionTypeCreatedByNavigation { get; set; }
        public ICollection<RegionType> RegionTypeUpdatedByNavigation { get; set; }
        public ICollection<Region> RegionUpdatedByNavigation { get; set; }
        public ICollection<SubArea> SubAreaCreatedByNavigation { get; set; }
        public ICollection<SubArea> SubAreaSupervisor { get; set; }
        public ICollection<SubArea> SubAreaUpdatedByNavigation { get; set; }
        public ICollection<TenantAmenityEntitlement> TenantAmenityEntitlementCreatedByNavigation { get; set; }
        public ICollection<TenantAmenityEntitlement> TenantAmenityEntitlementUpdatedByNavigation { get; set; }
        public ICollection<Tenant> TenantCreatedByNavigation { get; set; }
        public ICollection<Tenant> TenantUpdatedByNavigation { get; set; }
        public ICollection<Unit> UnitCreatedByNavigation { get; set; }
        public ICollection<Unit> UnitUpdatedByNavigation { get; set; }
    }
}
