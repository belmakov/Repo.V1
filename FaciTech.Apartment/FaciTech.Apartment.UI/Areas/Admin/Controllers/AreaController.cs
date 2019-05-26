using FaciTech.Apartment.Database;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FaciTech.Apartment.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AreaController : Controller
    {
        FaciTechContext _faciTechContext;
        public AreaController(FaciTechContext faciTechContext)
        {
            _faciTechContext = faciTechContext;
        }
        public JsonResult Index(int cityId)
        {
            return Json(_faciTechContext.Area.Where(e => e.CityId == cityId).ToList());
        }
    }
}