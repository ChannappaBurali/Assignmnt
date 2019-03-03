using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignmnt.Models;
using System.Data;

namespace Assignmnt.Controllers
{
    public class DefaultController : Controller
    {
        StudentDBEntities sd = new StudentDBEntities();
        Cascade cmd = new Cascade();
        
        // GET: Default
        public ActionResult Index()
        {
            State_Bind();
            //foreach (var state in sd.tblstates)
            //{
            //    cmd.States.Add(new SelectListItem { Text = state.name, Value = state.id.ToString() });
            //}
            return View();
        }
        [HttpPost]
        public ActionResult Index(Cascade cas)
        {
            tblstud stud = new tblstud();
            if (ModelState.IsValid)
            {
                try
                {
                    stud.name = cas.getstu.name;
                    stud.address = cas.getstu.address;
                    stud.gender = cas.getstu.gender;
                    stud.stateid = cas.StateId;
                    stud.cityid = cas.CityId;
                    cas.getstu = stud;
                    sd.tblstuds.Add(stud);
                    sd.SaveChanges();
                    State_Bind();
                }
                catch
                {
                    State_Bind();
                    return View(cas);
                }
            }
           
            return View(cas);
            
        }
        public void State_Bind()
        {
            List<tblstate> statelist = sd.tblstates.ToList();
            // ViewBag.statelist = new SelectList(statelist, "id", "name");
            ViewBag.statelist = sd.tblstates.Select(x => new SelectListItem { Text = x.name.ToString(), Value = x.id.ToString() }).ToList();
        }

        public ActionResult City_Bind(int stateId)
        {
            sd.Configuration.ProxyCreationEnabled = false;
            //List<SelectListItem> statelist = new List<SelectListItem>();
            //sd.tblcities.Where().Select(s => new { Id = s.id, Name = s.name }).ToList(),
            List<tblcity> cityl = sd.tblcities.Where(s => s.stateid == stateId).ToList();
            //foreach (var state in sd.tblstates)
            //{
            //    statelist.Add(new SelectListItem { Text = state.name, Value = state.id.ToString() });
            //}

            //if (stateId.HasValue)
            //{
            //    var cities = (from city in sd.tblcities
            //                  where city.stateid == stateId.Value
            //                  select city).ToList();
            //    foreach (var city in cities)
            //    {
            //        cityl.Add(new SelectListItem {Value = city.id.ToString(), Text = city.name });
            //    }
            //}
            return Json(cityl, JsonRequestBehavior.AllowGet);

        }
        //public ActionResult Index( int? stateId, int? cityId)
        //{            
        //    foreach (var state in sd.tblstates)
        //    {
        //        cmd.States.Add(new SelectListItem { Text = state.name, Value = state.id.ToString() });
        //    }

        //        if (stateId.HasValue)
        //        {
        //            var cities = (from city in sd.tblcities
        //                          where city.stateid == stateId.Value
        //                          select city).ToList();
        //            foreach (var city in cities)
        //            {
        //                cmd.Cities.Add(new SelectListItem { Text = city.name, Value = city.id.ToString() });
        //            }
        //        }
        //    return View(cmd);
        //}
        //public ActionResult ViewModelDemo()
        //{
        //    //Data _dummyData = new Data();
        //    //ViewModelDemo vmDemo = new ViewModelDemo();
        //    //vmDemo.allCourses = _dummyData.GetAllCourse();
        //    //vmDemo.allDepartments = _dummyData.GetAllDepartment();
        //    //vmDemo.allEmployees = _dummyData.GetAllEmployee();
        //    return View(vmDemo);
    }
}   