using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Authentication;
using System.Text;

namespace BDDTestProject.BusinessLayer
{
   public static  class IdentityManagment
   {


       private static bool autheticated;

        public static bool Login(string username, string password)
        {

            autheticated = (username == "aaa" && password == "123");

            return autheticated;

        }

        public static bool Logout()
        {

            autheticated = false;

            return autheticated;

        }

        public static bool IsAuthenticated()
        {

            if (autheticated == false)
            {

                throw  new AuthenticationException("hata");
            }

            return autheticated;
        }


    }
}
