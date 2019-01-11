using SkyBrinkEmployee_Student_Teacher_Staff_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SkyBrinkEmployee_Student_Teacher_Staff_Management.Controllers
{
    public class AdminController : Controller
    {
        // Reading all the information for Employees
        public ActionResult GetEmployeeeResult()
        {
            return Json(EmpResult(), JsonRequestBehavior.AllowGet);
        }
        public List<EmployeeResult> EmpResult()
        {
            List<EmployeeResult> empResult = new List<EmployeeResult>();
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                // Display Bar chart
                var list = dc.Employees.ToList();
                List<int> repartitions = new List<int>();
                var depts = list.Select(a => a.Department).Distinct();


                foreach (var item in depts)
                {
                    //repartitions.Add(list.Count(a => a.Department == item));
                    empResult.Add(new EmployeeResult()
                    {
                        dept = item.ToString(),
                        count = list.Count(a => a.Department == item)
                    });
                }
            }
            return empResult;
        }

        // Reading all the information for Employees
        public ActionResult GetRevenueResult()
        {
            return Json(RevResult(), JsonRequestBehavior.AllowGet);
        }
        public List<RevenueResult> RevResult()
        {
            List<RevenueResult> revResult = new List<RevenueResult>();
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                // Display Bar chart
                var list = dc.Revenues.ToList();
                foreach (var i in list)
                {
                    revResult.Add(new RevenueResult()
                    {
                        dept = i.Department.ToString(),
                        count = Convert.ToInt32(i.Profit)
                    });
                }


            }
            return revResult;
        }

        public ActionResult GetEmployeeView()
        {
            return View();
        }

        // Get emoloyess from database
        public ActionResult GetEmployeeDetails()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var employees = dc.Employees.OrderBy(a => a.FirstName).ToList();
                return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
            }

        }


        // For getting the add. edit and delete form
        [HttpGet]
        public ActionResult SaveEmployeeView(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Employees.Where(a => a.Id == id).FirstOrDefault();
                return View(v);
            }
        }

        // Method for adding or updating values in the database
        [HttpPost]
        public ActionResult SaveEmployee(Employee emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    if (emp.Id > 0)
                    {
                        //Edit data
                        var v = dc.Employees.Where(a => a.Id == emp.Id).FirstOrDefault();
                        v.FirstName = emp.FirstName;
                        v.LastName = emp.LastName;
                        v.EmailAddress = emp.EmailAddress;
                        v.Department = emp.Department;
                        v.PhoneNumber = emp.PhoneNumber;
                        v.Designation = emp.Designation;
                    }
                    else
                    {
                        //Save the data
                        dc.Employees.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        // Delete form
        [HttpGet]
        public ActionResult DeleteEmployeeView(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Employees.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        // Delete emoloyee from record
        [HttpPost]
        public ActionResult DeleteEmployee(int id)
        {
            bool status = false;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Employees.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Employees.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }


        // Faculty Members Data Table
        public ActionResult GetInstructorView()
        {
            return View();
        }

        // Get emoloyess from database
        public ActionResult GetInstructorDetails()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var instructors = dc.Teachers.OrderBy(a => a.FirstName).ToList();
                return Json(new { data = instructors }, JsonRequestBehavior.AllowGet);
            }

        }


        // For getting the add. edit and delete form
        [HttpGet]
        public ActionResult SaveInstructorView(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Teachers.Where(a => a.Id == id).FirstOrDefault();
                return View(v);
            }
        }

        // Method for adding or updating values in the database
        [HttpPost]
        public ActionResult SaveInstructors(Teacher teacher)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    if (teacher.Id > 0)
                    {
                        //Edit data
                        var v = dc.Teachers.Where(a => a.Id == teacher.Id).FirstOrDefault();
                        v.FirstName = teacher.FirstName;
                        v.LastName = teacher.LastName;
                        v.EmailId = teacher.EmailId;
                        v.Department = teacher.Department;
                        v.PhoneNumber = teacher.PhoneNumber;
                    }
                    else
                    {
                        //Save the data
                        dc.Teachers.Add(teacher);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        // Delete form
        [HttpGet]
        public ActionResult DeleteInstructorView(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Teachers.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        // Delete emoloyee from record
        [HttpPost]
        public ActionResult DeleteInstructor(int id)
        {
            bool status = false;
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Teachers.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Teachers.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}