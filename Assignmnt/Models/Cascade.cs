using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignmnt.Models
{
    public class Cascade
    {
        public Cascade()
        {            
            this.States = new List<SelectListItem>();
            this.Cities = new List<SelectListItem>();
        }
      
        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public tblstud getstu { get; set; }

        public int StateId { get; set; }
        public int CityId { get; set; }

    }
}