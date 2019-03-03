using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignmnt.Models
{
    public class ViewModelD
    {
        public ViewModelD() { 
            this.cascade = new List<Assignmnt.Models.Cascade>();
            this.student = new tblstud();
        }
        public List<Assignmnt.Models.Cascade> cascade { get; set; }
        public tblstud student { get; set; }
       // public int StateId { get; set; }
    }
}