﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementTool
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserLogin"] = null;
            Session["Designation"] = null;
            Session["UserName"] = null;
            Response.Redirect("/Home.aspx");
        }
    }
}