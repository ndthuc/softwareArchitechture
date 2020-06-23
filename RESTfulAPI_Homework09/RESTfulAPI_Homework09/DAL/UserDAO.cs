using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Configuration;
using RESTfulAPI_Homework09.Models;

namespace RESTfulAPI_Homework09.DAL
{
    public class UserDAO
    {
        private static String strCon = ConfigurationManager.ConnectionStrings["tin415de2171609ConnectionString"].ConnectionString;
        private ArtDBDataContext db = new ArtDBDataContext();

        bool SearchUser(RegisterUser register)
        {
            User user = db.Users.Where(us => us.UserName == register.UserName).SingleOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool CheckLoginSuccessful(LoginUser loginUser)
        {
            User user = db.Users.Where(us => us.UserName == loginUser.UserName
            && us.Password == loginUser.Password).SingleOrDefault();
            if (user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        bool CheckRegisterSuccessful(RegisterUser register)
        {
            if (SearchUser(register) && register.Password == register.ConfirmPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User Insert(RegisterUser newRegisterUser)
        {

            if (CheckRegisterSuccessful(newRegisterUser))
            {
                User newUser = new User();
                newUser.UserID = 0;
                newUser.UserName = newRegisterUser.UserName;
                newUser.Password = newRegisterUser.Password;
                try
                {
                    db.Users.InsertOnSubmit(newUser);
                    db.SubmitChanges();
                    return newUser;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }

        public LoginUser GetUser(LoginUser loginUser)
        {
            if (CheckLoginSuccessful(loginUser))
            {
                return loginUser;
            }
            else
            {
                return null;
            }
        }
    }
}