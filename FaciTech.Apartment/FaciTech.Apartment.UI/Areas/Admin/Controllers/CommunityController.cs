using FaciTech.Apartment.Database;
using FaciTech.Apartment.Database.Models;
using FaciTech.Apartment.UI.Areas.Admin.Models;
using FaciTech.Apartment.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FaciTech.Apartment.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommunityController : Controller
    {
        private readonly FaciTechContext _context;
        public CommunityController(FaciTechContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            CommunityWizardViewModel communityWizardViewModel = new CommunityWizardViewModel();
            var amenities = _context.Amenity.ToList();
            communityWizardViewModel.Map(amenities);
            return View(communityWizardViewModel);
        }
        public IActionResult Edit(Guid Id)
        {
            CommunityWizardViewModel communityWizardViewModel = new CommunityWizardViewModel();
            CommunityViewModel communityViewModel = new CommunityViewModel();
            var amenities = _context.Amenity.ToList();
            var communityLocation = _context.CommunityLocation.Where(e => e.Id == Id).FirstOrDefault();
            var community = _context.Community.Where(e => e.Id == Id).FirstOrDefault();


            communityWizardViewModel.Map(amenities);
            communityWizardViewModel.Map(community,communityLocation);

            return View("Create",communityWizardViewModel);
        }
        public JsonResult All()
        {
            var communities = _context.CommunityLocation.ToList();
            return Json(new ResponseModel(ResponseStatus.Success, "", communities));
        }
        public JsonResult Save([FromBody]CommunityViewModel communityViewModel)
        {
            Community community = new Community();
            if (communityViewModel.community_id.Length != 0)
            {
                community = _context.Community.Where(e => e.Id == Guid.Parse(communityViewModel.community_id.ToString())).FirstOrDefault();
            }
            switch (communityViewModel.source)
            {
                case "basic":
                    {
                        community.Name = communityViewModel.community_name;
                        community.BuilderName = communityViewModel.builder_name;
                        community.Address = communityViewModel.builder_name;
                        community.SubAreaId = communityViewModel.sub_area;
                        community.LocationLink = communityViewModel.landmark;
                        break;
                    }
                case "association":
                    {
                        community.AssociationNumber = communityViewModel.association_number;
                        community.AssociationName = communityViewModel.association_name;
                        community.AssociationBankAccountNumber = communityViewModel.account_number;
                        community.AssociationBankName = communityViewModel.bank_name;
                        community.AssociationBankBranchAddress = communityViewModel.branch_address;
                        community.AssociationBankIFSC = communityViewModel.ifsc;
                        break;
                    }
                case "amenity":
                    {
                        community.AmenityIds = communityViewModel.amenity_ids;
                        break;
                    }
            }

            if (communityViewModel.community_id.Length != 0)
            {
                //community.Id = Int32.Parse(communityViewModel.community_id.ToString());
                _context.Community.Update(community);
            }
            else
            {
                _context.Community.Add(community);
            }

            _context.SaveChanges();
            communityViewModel.community_id = community.Id.ToString();
            return Json(new ResponseModel(ResponseStatus.Success, "", communityViewModel));
        }
    }
}