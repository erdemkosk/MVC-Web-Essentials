using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSimplifier.MailHelpers.Models
{
    public class InformationsAboutIp
    {
        public string Ip { get; set; }
        public string Country_code { get; set; }
        public string Country_name { get; set; }
        public string Region_code { get; set; }
        public string Region_name { get; set; }
        public string City { get; set; }
        public string Zip_code { get; set; }
        public string Time_zone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }


    }
}
