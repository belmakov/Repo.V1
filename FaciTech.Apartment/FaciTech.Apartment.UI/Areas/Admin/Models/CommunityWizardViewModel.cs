using FaciTech.Apartment.Database.Models;
using System.Collections.Generic;

namespace FaciTech.Apartment.UI.Areas.Admin.Models
{
    public class CommunityWizardViewModel
    {
        public List<List<AmenityViewModel>> AmenityViewModels { get; set; }
        public CommunityViewModel CommunityViewModel { get; set; }
        public void Map(List<Amenity> amenities)
        {
            AmenityViewModels = new List<List<AmenityViewModel>>();
            List<AmenityViewModel> amenityViewModelsRow = null;
            int colsAdded = 5;
            foreach (var amenity in amenities)
            {
                
                if (colsAdded == 5)
                {
                    colsAdded = 0;
                    amenityViewModelsRow = new List<AmenityViewModel>();
                    AmenityViewModels.Add(amenityViewModelsRow);
                }
                colsAdded++;
                amenityViewModelsRow.Add(new AmenityViewModel() { Id = amenity.Id.ToString(), Name = amenity.Name });
            }
        }
        public void Map(Community community,CommunityLocation communityLocation)
        {
            CommunityViewModel = new CommunityViewModel();
            CommunityViewModel.community_id = community.Id.ToString();
            CommunityViewModel.community_name = community.Name;
            CommunityViewModel.association_name = community.AssociationName;
            CommunityViewModel.association_number = community.AssociationNumber;
            CommunityViewModel.account_number = community.AssociationBankAccountNumber;
            CommunityViewModel.address = community.Address;
            CommunityViewModel.amenity_ids = community.AmenityIds;
            CommunityViewModel.area = communityLocation.AreaId;
            CommunityViewModel.bank_name = community.AssociationBankName;
            CommunityViewModel.branch_address = community.AssociationBankBranchAddress;
            CommunityViewModel.sub_area = communityLocation.SubAreaId;
            CommunityViewModel.city = communityLocation.CityId;
            CommunityViewModel.country = communityLocation.CountryId;
            CommunityViewModel.ifsc = community.AssociationBankIFSC;
            CommunityViewModel.landmark = community.Landmark;
            CommunityViewModel.location_link = community.LocationLink;

            string amenityString = "," + CommunityViewModel.amenity_ids + ",";

            foreach (var amenityList in AmenityViewModels)
            {
                foreach (var amenity in amenityList)
                {
                    if (amenityString.IndexOf("," + amenity.Id.ToString() + ",") >= 0)
                    {
                        amenity.Selected = true;
                    }

                }
            }
        }
    }
}