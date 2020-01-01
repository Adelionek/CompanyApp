using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyApp.Models.ViewModel;
using CompanyApp.Models.EntityManager;
using System.Web.Security;
using CompanyApp.Models.DB;

namespace CompanyApp.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserSingupView USV)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                if (!UM.IsLoginNameExist(USV.username))
                {
                    UM.AddUserAccount(USV);
                    FormsAuthentication.SetAuthCookie(USV.firstName+ " "+USV.lastName, false);
                    return RedirectToAction("Welcome", "Home");
                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginView ULV, string returnUrl)
        {
            if (ModelState.IsValid)//checks if required fields are supplied
            {
                //create an instance of UserManager and call GetUserPassword by passing user LoginName
                UserManager um = new UserManager();
                string password = um.GetUserPassword(ULV.username);

                if (string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("", "The user login or password provided is incorrect");
                }
                else
                {
                    if (ULV.passwd.Equals(password))
                    {
                        FormsAuthentication.SetAuthCookie(ULV.username, false);
                        return RedirectToAction("Welcome", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            }
            return View(ULV);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ManageUser()
        {
            //string firstName = User.Identity.Name;
            //UserManager UM = new UserManager();
            var entities = new CompanyDBEntities();
            return View(entities.Users.ToList());
        }

        public ActionResult ManageUser2()
        {
            //string firstName = User.Identity.Name;
            //UserManager UM = new UserManager();
            var entities = new CompanyDBEntities();
            return View(entities.Users.ToList());
        }
    }
}