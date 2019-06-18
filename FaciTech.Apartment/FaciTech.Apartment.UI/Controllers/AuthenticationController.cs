using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FaciTech.Apartment.Database;
using FaciTech.Apartment.Database.Models;
using FaciTech.Apartment.UI.Models;
using FaciTech.Apartment.Utils;

namespace FaciTech.Apartment.UI.Controllers
{
    [Produces("application/json")]
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly FaciTechContext _context;

        public AuthenticationController(FaciTechContext context)
        {
            _context = context;
        }

        // GET: api/Authentication
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Authentication/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Authentication
        [HttpPost]
        public ActionResult<ResponseModel> PostLogin(LoginUserModel loginUser)
        {
            ResponseModel responseModel = null;
            try
            {
                string userName = loginUser.userName;
                var autheticatedUser = _context.User.Where(e => e.Username == userName).FirstOrDefault();
                string password = loginUser.password.Hash(autheticatedUser.Salt);

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
            return responseModel;
        }

        private bool UserExists(Guid id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
