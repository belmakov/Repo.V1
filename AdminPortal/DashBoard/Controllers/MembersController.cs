using System;
using System.Linq;
using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DashBoard.Controllers
{
    public class MembersController : Controller
    {
        private readonly AdminDatabaseContext _adminDatabaseContext;

        public MembersController(AdminDatabaseContext adminDatabaseContext)
        {
            _adminDatabaseContext = adminDatabaseContext;
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var member = _adminDatabaseContext.Members.Include(m => m.Apartment).First(m => m.Id == id);
            return View("Views/Communities/Members/Edit.cshtml",
                new MemberViewModel
                {
                    Id = member.Id,
                    Name = member.Name,
                    //TODO Add code to link to contact 
                    //Email = member.Email,
                    IsAssociationMember = member.IsAssociationMember,
                    //PhoneNumber1 = member.PhoneNumber1,
                    //PhoneNumber2 = member.PhoneNumber2,
                    ApartmentId = member.Apartment.Id
                });
        }

        [HttpPost]
        public IActionResult Edit(MemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var member = _adminDatabaseContext.Members.First(m => m.Id == model.Id);
                member.Name = model.Name;
                //TODO Add code to link contact
                //member.Email = model.Email;
                member.IsAssociationMember = model.IsAssociationMember;
                //member.PhoneNumber1 = model.PhoneNumber1;
                //member.PhoneNumber2 = model.PhoneNumber2;
                _adminDatabaseContext.SaveChanges();
                return RedirectToAction("Index", "Members", new {id = model.ApartmentId});
            }
            return View("Views/Communities/Members/Edit.cshtml", model);
        }

        [HttpGet]
        public IActionResult Create(Guid apartmentId)
        {
            var model = new MemberViewModel {ApartmentId = apartmentId};
            return View("Views/Communities/Members/Create.cshtml", model);
        }

        [HttpPost]
        public IActionResult Create(MemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var member = new Member
                {
                    Name = model.Name,
                    //Email = model.Email,
                    IsAssociationMember = model.IsAssociationMember,
                    //PhoneNumber1 = model.PhoneNumber1,
                    //PhoneNumber2 = model.PhoneNumber2,
                    Apartment = _adminDatabaseContext.Flats.First(f => f.Id == model.ApartmentId)
                };
                _adminDatabaseContext.Members.Add(member);
                _adminDatabaseContext.SaveChanges();
                return RedirectToAction("Index", "Members", new {id = model.ApartmentId});
            }
            return View("Views/Communities/Members/Create.cshtml", model);
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var member = _adminDatabaseContext.Members.Include(m => m.Apartment).First(m => m.Id == id);
            return View("Views/Communities/Members/Delete.cshtml", new MemberViewModel
            {
                Id = member.Id,
                Name = member.Name,
                //TODO add code to link to contact
                //Email = member.Email,
                ApartmentId = member.Apartment.Id
            });
        }

        [HttpPost]
        public IActionResult Delete(MemberViewModel model)
        {
            var member = _adminDatabaseContext.Members.First(m => m.Id == model.Id);
            _adminDatabaseContext.Members.Remove(member);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index", "Members", new {id = model.ApartmentId});
        }

        public IActionResult Index(Guid id)
        {
            var members = _adminDatabaseContext.Members.Include(m => m.Apartment).AsNoTracking()
                .Where(m => m.Apartment.Id == id);
            return View("Views/Communities/Members/Index.cshtml",
                new MemberCollectionViewModel
                {
                    ApartmentId = id,
                    MemberInfos = members.Select(m =>
                        new MemberViewModel
                        {
                            Id = m.Id,
                            Name = m.Name,
                            IsAssociationMember = m.IsAssociationMember,
                            //TODO add code to link to contact
                            //Email = m.Email,
                            //PhoneNumber1 = m.PhoneNumber1,
                            //PhoneNumber2 = m.PhoneNumber2
                        })
                }
            );
        }
    }
}