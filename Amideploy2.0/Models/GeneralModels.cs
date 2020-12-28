using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Amideploy2._0.Models
{
    public class Releasetickets
    {
        public string releaseno { get; set; }
        public DateTime createddate { get; set; }
        public string createdby { get; set; }
        public Boolean isactive { get; set; }
    }

    public class Deployementdata
    {
        public string ComponentName { get; set; }
        public string DEV { get; set; }
        public string LT { get; set; }
        public string QA { get; set; }
        public string PROD { get; set; }

    }

    public class Releasecomponent
    {
        public string Application { get; set; }
        public string ComponentName { get; set; }
        public string Action { get; set; }
        



    }

    public class Releasedetails
    {
        public string Releaseno { get; set; }
        public string ComponentName { get; set; }
        public string Version { get; set; }




    }

    

    public class Releaseno
    {
        [Required(ErrorMessage = "Releaseno is Required")]
        [Display(Name = "Releaseticketno")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Release Ticket Number Required Minimum 3 and Maximum 15 Characters")]
        [DataType(DataType.Text)]

        public string Component { get; set; }
        [Required(ErrorMessage = "Component is Required")]
        [Display(Name = "Component")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Component Required Minimum 3 and Maximum 15 Characters")]
        [DataType(DataType.Text)]

        public string Releaseticketno { get; set; }

        public List<SelectListItem> Releaseticket { get; set; }
        public List<SelectListItem> Application { get; set; }
        public List<SelectListItem> Releasecomponent { get; set; }
        public List<SelectListItem> Buildversion { get; set; }

        

    }

   

}