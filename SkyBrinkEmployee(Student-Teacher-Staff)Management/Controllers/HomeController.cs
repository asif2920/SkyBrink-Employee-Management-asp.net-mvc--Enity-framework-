using SkyBrinkEmployee_Student_Teacher_Staff_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SkyBrinkEmployee_Student_Teacher_Staff_Management.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStudent()
        {
            return View();
        }

        // Get emoloyess from database
        public ActionResult GetStudentDetails()
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var employees = dc.Students.OrderBy(a => a.FirstName).ToList();
                return Json(new { data = employees }, JsonRequestBehavior.AllowGet);
            }

        }

        // Reading all the information for students for the Index Dashboard
        public ActionResult GetStudentResult()
        {
            return Json(Result(), JsonRequestBehavior.AllowGet);
        }
        public List<StudentResult> Result()
        {
            List<StudentResult> stdResult = new List<StudentResult>();
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                // Display Bar chart
                var list = dc.Students.ToList();
                List<int> repartitions = new List<int>();
                var depts = list.Select(a => a.Department).Distinct();


                foreach (var item in depts)
                {
                    stdResult.Add(new StudentResult()
                    {
                        stdName = item.ToString(),
                        marksObtained = list.Count(a => a.Department == item)
                    });
                }
            }
            return stdResult;
        }

        // For showing into the Dashboard of Teachers Results

        public ActionResult GetTeacherResult()
        {
            return Json(ResultTeacher(), JsonRequestBehavior.AllowGet);
        }

        public List<TeacherResult> ResultTeacher()
        {
            List<TeacherResult> stdResult = new List<TeacherResult>();
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                // Display Bar chart
                var list = dc.Teachers.ToList();
                List<int> repartitions = new List<int>();
                var depts = list.Select(a => a.Department).Distinct();


                foreach (var item in depts)
                {
                    stdResult.Add(new TeacherResult()
                    {
                        dept = item.ToString(),
                        count = list.Count(a => a.Department == item)
                    });
                }
            }
            return stdResult;
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            bool Status = false;
            string message = "";

            if (ModelState.IsValid)
            {
                #region Email exists or not
                var isExist = IsEmailExist(user.EmailId);
                #endregion
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                else
                {
                    #region Password hashing
                    user.Password = Crypto.Hash(user.Password);
                    user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);
                    #endregion
                    #region Saving to database
                    using (MyDatabaseEntities dc = new MyDatabaseEntities())
                    {
                        dc.Users.Add(user);
                        dc.SaveChanges();
                    }
                    #endregion
                    return View("Index");
                }
            }
            else
            {
                message = "Invalid Request";
                ViewBag.Message = message;
                ViewBag.Status = Status;
                return View(user);
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin userlogin)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Users.Where(a => a.EmailId == userlogin.EmailId).FirstOrDefault();
                if (v != null && userlogin.Password != null)
                {
                    if (string.Compare(Crypto.Hash(userlogin.Password), v.Password) == 0)
                    {
                        return View("LoginSuccess");
                    }
                    else
                    {
                        return View("Login");
                    }


                }
                else
                {
                    return View("Login");
                }
            }

        }

        [HttpGet]
        public ActionResult LoginSuccess()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View("Index");
        }


        // For getting the add. edit and delete form
        [HttpGet]
        public ActionResult Save(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Students.Where(a => a.Id == id).FirstOrDefault();
                return View(v);
            }
        }

        // Method for adding or updating values in the database
        [HttpPost]
        public ActionResult Save(Student emp)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MyDatabaseEntities dc = new MyDatabaseEntities())
                {
                    if (emp.Id > 0)
                    {
                        //Edit data
                        var v = dc.Students.Where(a => a.Id == emp.Id).FirstOrDefault();
                        v.FirstName = emp.FirstName;
                        v.LastName = emp.LastName;
                        v.EmailAddress = emp.EmailAddress;
                        v.Department = emp.Department;
                        v.PhoneNumber = emp.PhoneNumber;
                    }
                    else
                    {
                        //Save the data
                        dc.Students.Add(emp);
                    }
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        // Delete form
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Students.Where(a => a.Id == id).FirstOrDefault();
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
                var v = dc.Students.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.Students.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult { Data = new { status = status } };
        }

        public ActionResult TechnicalDetails()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        private bool IsEmailExist(string emailId)
        {
            using (MyDatabaseEntities dc = new MyDatabaseEntities())
            {
                var v = dc.Users.Where(a => a.EmailId == emailId).FirstOrDefault();
                return v == null ? false : true;
            }
        }
    }
}