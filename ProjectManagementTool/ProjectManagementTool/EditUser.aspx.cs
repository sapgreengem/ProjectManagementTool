using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementTool
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var value = Convert.ToInt32(Request.QueryString["UserID"]);
                if (value > 0 || Request.QueryString["UserID"] != null)
                {
                    this.loadDesignations();
                    this.loadUser(value);
                }
                else
                {
                    Response.Write("URL error");
                }
            }
        }

        private void loadUser(int id)
        {
            using (PMTDBContext context = new PMTDBContext())
            {
                User user = context.Users.FirstOrDefault(a=> a.UserID == id);
                TextBoxEmail.Text = user.Email.ToString();
                TextBoxName.Text = user.UserName.ToString();
            }
        }
        private void loadDesignations()
        {
            using (PMTDBContext context = new PMTDBContext())
            {
                IEnumerable<Designation> designation = context.Designations.ToList();
                foreach (var item in designation)
                {
                    var newItem = new ListItem();
                    newItem.Value = item.DesignationID.ToString();
                    newItem.Text = item.DesignationName.ToString();
                    ListBox1.Items.Add(newItem);
                }
            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            var value = Convert.ToInt32(Request.QueryString["UserID"]);
            if (value > 0 || Request.QueryString["UserID"] != null)
            {
                if (RadioButtonList1.SelectedItem != null && ListBox1.SelectedValue != null)
                {
                    if (!String.IsNullOrWhiteSpace(TextBoxName.Text.ToString()) && !String.IsNullOrWhiteSpace(TextBoxEmail.Text.ToString()))
                    {
                        using (PMTDBContext context = new PMTDBContext())
                        {
                            User user = context.Users.FirstOrDefault(a => a.UserID == value);
                            if (user != null)
                            {
                                user.UserName = TextBoxName.Text.ToString();
                                user.Email = TextBoxEmail.Text.ToString();
                                user.Password = TextBoxEmail.Text.ToString() + "123";
                                user.Status = RadioButtonList1.SelectedItem.ToString();
                                user.DesignationID = Convert.ToInt32(ListBox1.SelectedValue);
                                context.SaveChanges();
                                Response.Redirect("/AddUser.aspx");
                            }
                        }
                    }
                    else
                    {
                        Label6.Text = "No field can be empty";
                    }
                }
                else
                {
                    Label6.Text = "Select Status and Designation";
                }
            }
            else
            {
                Response.Write("URL error");
            }
            
        }
    }
}