using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementTool
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (PMTDBContext context = new PMTDBContext())
            {
                if (context.Users.Where(a => a.Email == TextBox1.Text.ToString()).Where(a=> a.Password == TextBox2.Text.ToString()).Count() == 1)
                {
                    User user = context.Users.FirstOrDefault(a => a.Email == TextBox1.Text.ToString() && a.Password == TextBox2.Text.ToString());
                    if (user.DesignationID == 1)
                    {
                        Session["UserLogin"] = user.UserID;
                        Session["Designation"] = user.DesignationID;
                        Session["UserName"] = user.UserName +" "+ user.Designation.DesignationName;
                        Response.Redirect("/AddUser.aspx", false);
                    }
                    else if (user.DesignationID == 2)
                    {
                        Session["UserLogin"] = user.UserID;
                        Session["Designation"] = user.DesignationID;
                        Session["UserName"] = user.UserName + " " + user.Designation.DesignationName;
                        Response.Redirect("/ViewMyProjects.aspx", false);
                    }
                    else if (user.DesignationID != 1)
                    {
                        Session["UserLogin"] = user.UserID;
                        Session["Designation"] = user.DesignationID;
                        Session["UserName"] = user.UserName + " " + user.Designation.DesignationName;
                        Response.Redirect("/ViewMyProjects.aspx",false);
                    }
                }
                else
                {
                    Response.Write("Wrong Email or Password");
                }
            }
        }
    }
}