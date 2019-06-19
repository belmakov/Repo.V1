﻿using System;

namespace FaciTech.Apartment.UI.Areas.Admin.Models
{
    public class CommunityViewModel
    {
        public string community_id { get; set; }
        public string community_name { get; set; }
        public string builder_name { get; set; }
        public Guid country { get; set; }
        public Guid city { get; set; }
        public Guid area { get; set; }
        public Guid sub_area { get; set; }
        public string address { get; set; }
        public string landmark { get; set; }
        public string location_link { get; set; }
        public string source { get; set; }
        public string association_name { get; set; }
        public string association_number { get; set; }
        public string bank_name { get; set; }
        public string account_number { get; set; }
        public string branch_address { get; set; }
        public string ifsc { get; set; }
        public string amenity_ids { get; set; }
    }
}