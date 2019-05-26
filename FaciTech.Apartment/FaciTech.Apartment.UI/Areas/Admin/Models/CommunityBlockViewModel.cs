using System.Collections.Generic;

namespace FaciTech.Apartment.UI.Areas.Admin.Models
{
    public class CommunityBlockViewModel
    {
        public string id { get; set; }
        public string block_name { get; set; }
        public int community_id { get; set; }
        public int no_of_floors { get; set; }
        public List<KeyValuePair<int,string>> Floors
        {
            get
            {
                List<KeyValuePair<int, string>> floors = new List<KeyValuePair<int, string>>();

                floors.Add(new KeyValuePair<int, string>(0,"Ground Floor"));
                for (int index = 1; index <= no_of_floors; index++)
                {
                    string floorName = "";
                    switch (index)
                    {
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
                                floorName = index.ToString() + "th Floor";
                                break;
                            }
                    }
                    floors.Add(new KeyValuePair<int, string>(index,floorName));
                }
                return floors;
            }
        }
    }
}