using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompanyApp.Models.DB;
using CompanyApp.Models.ViewModel;

namespace CompanyApp.Models.EntityManager
{
    public class UserManager
    {
        public void AddUserAccount(UserSingupView user)
        {
            using (CompanyDBEntities db = new CompanyDBEntities())
            {
                User usr = new User();
                usr.firstName = user.firstName;
                usr.lastName = user.lastName;
                usr.username = user.username;
                usr.passwd = user.passwd;
                usr.role_id = 2;
                usr.dateOfBirth = user.dateOfBirth;

                db.Users.Add(usr);
                db.SaveChanges();
            }
        }

        public string GetUserPassword(string loginName)
        {
            using (CompanyDBEntities db = new CompanyDBEntities())
            {
                var user = db.Users.Where(o => o.username.ToLower().Equals(loginName));
                    if (user.Any())
                        return user.FirstOrDefault().passwd;
                    else
                        return string.Empty;
            }
        }

        public bool IsUserInRole(string loginName, string roleName)
        {
            using (CompanyDBEntities db = new CompanyDBEntities())
            {
                //LINQ EXPRESSION
                User usr = db.Users.Where(o =>
                o.username.ToLower().Equals(loginName))?.FirstOrDefault(); //what is "?" for ?

                if (usr != null)
                {
                    var roles = from q in db.Users
                                join r in db.Roles on q.role_id equals r.roleID
                                where q.userID.Equals(usr.userID) && r.roleName.Equals(roleName)

                                select r.roleName;

                    if (roles != null)
                    {
                        return roles.Any();
                    }
                }
                return false;
            }
        }





        public string getUserName(int id)
        {
            using (CompanyDBEntities db = new CompanyDBEntities())
            {
                var user = db.Users.Where(o => o.userID == id);
                if (user.Any())
                    return user.FirstOrDefault().firstName;
                else
                    return string.Empty;
            }
        }
        public string getUserLastName(int id)
        {
            using (CompanyDBEntities db = new CompanyDBEntities())
            {
                var user = db.Users.Where(o => o.userID == id);
                if (user.Any())
                    return user.FirstOrDefault().lastName;
                else
                    return string.Empty;
            }
        }

        public bool IsLoginNameExist(string loginName)
        {
            using (CompanyDBEntities db = new CompanyDBEntities())
            {
                return db.Users.Where(o => o.username.Equals(loginName)).Any();
            }
        }
    }
}