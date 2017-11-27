using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementTool
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (PMTDBContext context = new PMTDBContext())
            {
                IEnumerable<Designation> designation = context.Designations.ToList();
                foreach (var item in designation)
                {
                    Response.Write(item.DesignationName +" "+item.DesignationID);
                }

                //foreach (var item in context.Designations.ToList())
                //{
                //    ListBox1.Items.Add(item.Designation1);
                //}
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write(ListBox1.SelectedValue);
        }
    }
}