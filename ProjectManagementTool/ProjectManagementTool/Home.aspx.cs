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
                if (context.Users.Where(a => a.Email == TextBox1.Text.ToString() && a.Password == TextBox2.Text.ToString()).Where(a => a.DesignationID == 1).Count() == 1)
                {
                    Response.Redirect("/AddUser.aspx");
                }
                else if (context.Users.Where(a => a.Email == TextBox1.Text.ToString() && a.Password == TextBox2.Text.ToString()).Where(a => a.DesignationID != 1).Count() == 1)
                {
                    Response.Redirect("/ViewMyProjects.aspx");
                }
                else
                {
                    Response.Write("Wrong Email or Password");
                }

                //context.Users.Where(a => a.Email == TextBox1.Text.ToString() && a.Password == TextBox2.Text.ToString()).Where(a => a.DesignationID == 1);
            }
        }
    }
}