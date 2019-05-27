using System;

namespace FaciTech.Apartment.UI.Areas.Admin.Models
{
    public class UnitViewModel
    {
        public string id { get; set; }
        public string flat { get; set; }
        public string block { get; set; }
        public Guid block_id { get; set; }
        public string floor
        {
            get
            {
                string floorName = "";
                switch (floor_number)
                {
                    case 0:
                        {
                            floorName = "Ground Floor";
                            break;
                        }
                    case 1:
                        {
                            floorName = "1st Floor";
                            break;
                        }
                    case 2:
                        {
                            floorName = "2nd Floor";
                            break;
                        }
                    case 3:
                        {
                            floorName = "3rd Floor";
                            break;
                        }
                    default:
                        {
                            floorName = floor_number.ToString() + "th Floor";
                            break;
                        }
                }
                return floorName;
            }
        }
        public int floor_number { get; set; }
        public string specification { get; set; }
    }
}