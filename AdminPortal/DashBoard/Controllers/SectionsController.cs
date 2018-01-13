using System;
using System.Collections.Generic;
using System.Linq;
using DashBoard.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DashBoard.Controllers
{
    public class SectionsController : Controller
    {
        private readonly AdminDatabaseContext _adminDatabaseContext;

        public SectionsController(AdminDatabaseContext adminDatabaseContext)
        {
            _adminDatabaseContext = adminDatabaseContext;
        }

        public IActionResult Index()
        {
            return View(_adminDatabaseContext.Sections);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["REGION_NAMES"] = new SelectList(_adminDatabaseContext.Regions.Select(r => r.Name));
            return View();
        }

        [HttpPost]
        public IActionResult Create(SectionViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            if (_adminDatabaseContext.Sections.Any(r =>
                r.Name.Equals(viewModel.Name) && r.Zone == viewModel.Zone))
                return View(viewModel);
            var comm = new Community
            {
                Name = "Brigade Millennium",
                Blocks = new List<Block>
                    {
                        new Block
                        {
                            Name = "B1",
                            Flats = new List<Flat>
                            {
                                new Flat
                                {
                                    IsRented = false,
                                    FlatMembers = new List<Member>
                                    {
                                        new Member
                                        {
                                            IsAssociationMember = false,
                                            Name = "Dileep",
                                            PhoneNumbers = "8105089899"
                                        }
                                    },
                                    Helpers = new List<PersonalHelper>
                                    {
                                        new PersonalHelper
                                        {
                                            Name = "Mary",
                                            Role = "Maid",
                                            ContactDetails = new Address
                                            {
                                                City = "Bangalore",
                                                LocationOrArea = "JP Nagar 8th Phase",
                                                Phone = "1234567890",
                                                PinCode = "560076",
                                                State = "Karnataka",
                                                Street = "Kothanur Dinne",
                                                ApartmentName = "1st Cross"
                                            }
                                        }
                                    },
                                    Number = "BM-01",
                                    ParkingSlots = new List<ParkingSlot>
                                    {
                                        new ParkingSlot
                                        {
                                            FloorName = "Basement",
                                            Number = "B1",
                                        }
                                    }
                                }
                            }
                        }
                    },
                AmcItems = new List<AmcItem>
                    {
                        new AmcItem
                        {
                            Name = "GenSet"
                        }
                    },
                Ameneties = new List<Amenety>
                    {
                       new Amenety
                       {
                           Name = "Club House"
                       }
                    },
                Association = new Association
                {
                    Name = "B M A",
                    AssociationMembers = new List<Member>
                        {
                            new Member
                            {
                                Name = "Dileep",
                                IsAssociationMember = true,
                                PhoneNumbers = "8105089899"
                            }
                        },
                    President = new Member
                    {
                        Name = "Dileep"
                    },
                    Secretary = new Member
                    {
                        Name = "Dileep"
                    },
                    Treasurers = new List<Member>
                        {
                            new Member
                            {
                                Name = "Dileep"
                            }
                        }
                },
                Vendors = new List<Vendor>
                    {
                        new Vendor
                        {
                            Name = "vendor 1",
                            Pupose = "Cleaning",
                            Address = new Address
                            {
                                ApartmentName = "aaa",
                                City = "BLR"
                            },
                            Schedule = DateTime.Now
                        }
                    },
                ParkingLayout = new ParkingLayout
                {
                    ParkingSlots = new List<ParkingSlot>
                        {
                            new ParkingSlot
                            {
                                FloorName = "F2",
                                Number = "KA 25 B 12345"
                            }
                        }
                }
            };
            var sec = new Section
            {
                Name = viewModel.Name,
                Zone = viewModel.Zone,
                Region = _adminDatabaseContext.Regions.FirstOrDefault(r => r.Name == viewModel.Region)
            };
            sec.Communities = new List<Community>
            {
                comm
            };
            _adminDatabaseContext.Sections.Add(sec);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var section = _adminDatabaseContext.Sections.First(s => s.Id == id);
            return View(new SectionViewModel
            {
                Id = id,
                Zone = section.Zone,
                Name = section.Name
            });
        }

        [HttpPost]
        public IActionResult Edit(SectionViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);
            if (_adminDatabaseContext.Sections.Any(r =>
                r.Name.Equals(viewModel.Name) && r.Zone == viewModel.Zone))
                return View(viewModel);
            var section = _adminDatabaseContext.Sections.First(s => s.Id == viewModel.Id);
            section.Name = viewModel.Name;
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var section = _adminDatabaseContext.Sections.First(s => s.Id == id);
            return View(new SectionViewModel
            {
                Id = id,
                Zone = section.Zone,
                Name = section.Name,
                Region = _adminDatabaseContext.Regions.First(r => r.Id == section.Region.Id).Name
            });

        }

        [HttpPost]
        public IActionResult Delete(int id, SectionViewModel viewModel)
        {
            var section = _adminDatabaseContext.Sections.First(s => s.Id == id);
            _adminDatabaseContext.Sections.Remove(section);
            _adminDatabaseContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}