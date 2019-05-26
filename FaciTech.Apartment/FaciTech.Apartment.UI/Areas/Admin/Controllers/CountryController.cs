using FaciTech.Apartment.Database;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FaciTech.Apartment.UI.Areas.Admin.Controllers
{
    public class CountryController : Controller
    {
        FaciTechContext _faciTechContext;
        public CountryController(FaciTechContext faciTechContext)
        {
            _faciTechContext = faciTechContext;
        }
        public JsonResult All()
        {
            return Json(_faciTechContext.Country.ToList());
        }
    }
}