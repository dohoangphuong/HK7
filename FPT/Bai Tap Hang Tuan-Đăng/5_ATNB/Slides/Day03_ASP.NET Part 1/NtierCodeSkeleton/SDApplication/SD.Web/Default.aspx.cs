﻿using System;
using System.Web;
using System.Web.Security;

namespace SD.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if ( !HttpContext.Current.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();

            }
            else
            {
                this.lblUserName.Text ="Welcome !" +  User.Identity.Name;

            }
            
        }
    }
}
