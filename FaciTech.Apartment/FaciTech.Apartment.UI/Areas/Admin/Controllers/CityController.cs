using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FaciTech.Apartment.Database;
using Microsoft.AspNetCore.Mvc;

namespace FaciTech.Apartment.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        FaciTechContext _faciTechContext;
        public CityController(FaciTechContext faciTechContext)
        {
            _faciTechContext = faciTechContext;
        }
        public JsonResult Index(Guid stateId)
        {
            return Json(_faciTechContext.City.Where(e => e.StateId == stateId).ToList());
        }
    }
}