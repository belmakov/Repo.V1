using FaciTech.Apartment.Database;
using FaciTech.Apartment.UI.Models;
using FaciTech.Apartment.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace FaciTech.Apartment.UI.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly FaciTechContext _context;
        public AccountController(FaciTechContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View("Index");
        }
        [HttpPost]
        public JsonResult Authenticate([FromBody] LoginViewModel loginViewModel)
        {
            ResponseModel responseModel = null;
            try
            {
                string userName = loginViewModel.Username;
                var autheticatedUser = _context.User.Where(e => e.Username == userName).FirstOrDefault();
                string password = loginViewModel.Password.Hash(autheticatedUser.Salt);

                if (autheticatedUser != null && autheticatedUser.Password == password)
                {
                    responseModel = new ResponseModel(ResponseStatus.Success);
                }
                else
                {
                    responseModel = new ResponseModel(ResponseStatus.Error, "Invalid Username or Password");
                }
            }
            catch (Exception ex)
            {
                responseModel = new ResponseModel(ResponseStatus.Error, "Unknow error while autheticating");
            }
            return Json(responseModel);
        }
    }
}