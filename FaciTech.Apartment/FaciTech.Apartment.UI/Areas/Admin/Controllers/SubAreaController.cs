using FaciTech.Apartment.Database;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FaciTech.Apartment.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubAreaController : Controller
    {
        FaciTechContext _faciTechContext;
        public SubAreaController(FaciTechContext faciTechContext)
        {
            _faciTechContext = faciTechContext;
        }
        public JsonResult Index(int areaId)
        {
            return Json(_faciTechContext.SubArea.Where(e => e.AreaId == areaId).ToList());
        }
    }
}