using FaciTech.Apartment.Database;
using FaciTech.Apartment.Database.Models;
using FaciTech.Apartment.UI.Areas.Admin.Models;
using FaciTech.Apartment.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FaciTech.Apartment.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommunityBlockController : Controller
    {
        private readonly FaciTechContext _context;
        public CommunityBlockController(FaciTechContext context)
        {
            _context = context;
        }
        public JsonResult Get(int communityId)
        {
            var communityBlocks = _context.Block.Where(e => e.Community.Id  == communityId).ToList();
            List<CommunityBlockViewModel> communityBlockViewModels = new List<CommunityBlockViewModel>();
            foreach (var block in communityBlocks)
            {
                communityBlockViewModels.Add(new CommunityBlockViewModel()
                {
                    id = block.Id.ToString(),
                    block_name = block.BlockName,
                    no_of_floors = block.NoOfFloors,
                    community_id = block.CommunityId
                });
            }
            return Json(new ResponseModel(ResponseStatus.Success, "", communityBlockViewModels));
        }
        public JsonResult Save([FromBody]CommunityBlockViewModel communityBlockViewModel)
        {
            Block block = new Block();
            block.BlockName = communityBlockViewModel.block_name;
            block.NoOfFloors = communityBlockViewModel.no_of_floors;
            block.CommunityId = communityBlockViewModel.community_id;

            if (communityBlockViewModel.id == null || communityBlockViewModel.id == "")
            {
                _context.Add(block);
            }
            else
            {
                block.Id = Int32.Parse(communityBlockViewModel.id);
                _context.Update(block);
            }
            communityBlockViewModel.id = block.Id.ToString();
            _context.SaveChanges();
            return Json(new ResponseModel(ResponseStatus.Success, "", communityBlockViewModel));
        }
    }
}