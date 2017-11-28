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
            loadDesignations();
            this.loadUser();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(TextBoxName.Text)
                && !String.IsNullOrWhiteSpace(TextBoxEmail.Text)
                && !String.IsNullOrWhiteSpace(TextBoxPassword.Text)
                && RadioButtonList1.SelectedItem != null
                && ListBox1.SelectedValue != null)
            {
                using (PMTDBContext context = new PMTDBContext())
                {
                    User user = new User();
                    user.UserName = TextBoxName.Text.ToString();
                    user.Email = TextBoxEmail.Text.ToString();
                    user.Password = TextBoxPassword.Text.ToString();
                    user.Status = RadioButtonList1.SelectedItem.ToString();
                    user.DesignationID = Convert.ToInt32(ListBox1.SelectedValue);
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            else
            {
                Label6.Text = "Fill All Info";
                //Response.Write("Fill All Info");
            }
            
            this.loadUser();
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

        private void loadUser()
        {
            using (PMTDBContext context = new PMTDBContext())
            {
                IEnumerable<User> user = context.Users.ToList();
                List<Join_Users_Designations> joinData = new List<Join_Users_Designations>();
                foreach (var item in user)
                {
                    Join_Users_Designations addData = new Join_Users_Designations()
                    {
                        UserName = item.UserName,
                        Email = item.Email,
                        Status = item.Status,
                        DesignationName = item.Designation.DesignationName
                    };
                    joinData.Add(addData);
                }
                GridView1.DataSource = joinData.ToList();
                GridView1.DataBind();
            }
        }

        protected void TextBoxEmail_TextChanged(object sender, EventArgs e)
        {
            using (PMTDBContext context = new PMTDBContext())
            {
                if (context.Users.Where(a=> a.Email == TextBoxEmail.Text).Count() > 0)
                {
                    Label6.Text = "Email already Exists";
                    //Response.Write("Email already Exists");
                }
                else
                {
                    TextBoxPassword.Text = TextBoxEmail.Text.ToString() + 123;
                }
            }
        }
    }
}