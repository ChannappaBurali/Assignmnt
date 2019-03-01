using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignmnt.Models;
namespace Assignmnt.Controllers
{   
    public class DefaultController : Controller
    {
        StudentDBEntities sd = new StudentDBEntities();
        Cascade cmd = new Cascade();
        // GET: Default
        public ActionResult Index()
        {
            foreach (var state in sd.tblstates)
            {
                cmd.States.Add(new SelectListItem { Text = state.name, Value = state.id.ToString() });
            }
            return View(cmd);            
        }
        [HttpPost]
        public ActionResult Index( int? stateId, int? cityId)
        {            
            foreach (var state in sd.tblstates)
            {
                cmd.States.Add(new SelectListItem { Text = state.name, Value = state.id.ToString() });
            }
           
                if (stateId.HasValue)
                {
                    var cities = (from city in sd.tblcities
                                  where city.stateid == stateId.Value
                                  select city).ToList();
                    foreach (var city in cities)
                    {
                        cmd.Cities.Add(new SelectListItem { Text = city.name, Value = city.id.ToString() });
                    }
                }
            return View(cmd);
        }
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