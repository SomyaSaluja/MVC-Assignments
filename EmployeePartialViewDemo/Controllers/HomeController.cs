using EmployeePartialViewDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EmployeePartialViewDemo.Controllers
{
    public class HomeController : Controller
    {
        
        public static List<EntityEmployee> empList = new List<EntityEmployee>(){
             new EntityEmployee{EmpID = 1, FirstName = "Mark", LastName = "Jacobs"},  
                new EntityEmployee{EmpID = 2, FirstName = "Alice", LastName = "Lice"},  
                new EntityEmployee{EmpID = 3, FirstName = "Jennifer", LastName = "Lopez"},  
                new EntityEmployee{EmpID = 4, FirstName = "Selena", LastName = "Gomez"}  
        };
       
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult GetResultByAjax()
        {
           return PartialView("DemoPartial", empList);
        }

        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                EntityEmployee emp = new EntityEmployee()
                {
                    EmpID = empList.Count + 1,
                    FirstName = "",
                    LastName = ""

                };
                return View("Index", emp);
            }
            else {
                EntityEmployee employee = new EntityEmployee();
                employee = empList.FirstOrDefault(emp => emp.EmpID == id);
                return View("Index", employee);
            }
            
               //return PartialView("Detail", employee);
        }

        
        public ActionResult UpdateRecord(EntityEmployee model)
        {
            var newEmployee = empList.FirstOrDefault(emp => emp.EmpID == model.EmpID);
            if (newEmployee == null)
            {
                empList.Add(newEmployee);
            }
            else
            {
                int id = model.EmpID;
                string fName = model.FirstName;
                string lName = model.LastName;
                bool status = UpdateEmployeeList(id, fName, lName);      
            }

            return PartialView("DemoPartial", empList);
        }

        public bool UpdateEmployeeList(int id, string fName, string lName)
        {
            var employee = empList.FirstOrDefault(eid => eid.EmpID == id);
            if (employee == null)
            {
                return false;
            }
            else
            {
                employee.EmpID = id;
                employee.FirstName = fName;
                employee.LastName = lName;
                return true;
            }
          
        }
       
        public bool DeleteEmployee(int id)
        {
            
            var employee = empList.Where(eid => eid.EmpID == id).FirstOrDefault();
            if (employee == null)
            {
                return false;
            }
            else
            {
               empList.Remove(employee);
                return true;
            }
        }

        public ActionResult AddEmployee(int id)
        {
            if (id == 0)
            {
                EntityEmployee employee = new EntityEmployee()
                {
                    EmpID = empList.Count + 1,
                    FirstName = "",
                    LastName = ""

                };
                
                return View("Index" , employee);
            }
            else
            {
                var employeeList = empList.FirstOrDefault(e => e.EmpID == id);
                return PartialView("DemoPartial", employeeList);
            }       
        }
    }
}
