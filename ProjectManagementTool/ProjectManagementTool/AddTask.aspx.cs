using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementTool
{
    public partial class AddTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.loadProjectDropdowns();
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Id = Convert.ToInt32(DropDownList1.SelectedValue);
            DropDownList2.Items.Clear();
            DropDownList3.Items.Clear();
            using (PMTDBContext context = new PMTDBContext())
            {
                List<UsersUnderProject> usersUnderProject = context.UsersUnderProjects.Where(a => a.ProjectID == Id).ToList();
                List<User> user = new List<User>();
                foreach (var item in usersUnderProject)
                {
                    User addUser = context.Users.FirstOrDefault(a => a.UserID == item.UserID);
                    user.Add(addUser);
                }
                this.loadUserDropdown(user.ToList());
            }


            using (PMTDBContext context = new PMTDBContext())
            {
                Project project = context.Projects.FirstOrDefault(a => a.ProjectID == Id);
                int days = Convert.ToInt32((Convert.ToDateTime(project.EndDate) - Convert.ToDateTime(project.StartDate)).TotalDays);

                DateTime date = Convert.ToDateTime(project.StartDate);
                for (int i = 0; i < days; i++)
                {
                    var newItem = new ListItem();
                    date = date.AddDays(1);
                    newItem.Text = date.ToShortDateString();
                    newItem.Value = date.ToShortDateString();
                    DropDownList3.Items.Add(newItem);
                }
            }

        }
        private void loadProjectDropdowns()
        {
            using (PMTDBContext context = new PMTDBContext())
            {
                IEnumerable<Project> project = context.Projects.ToList();
                foreach (var item in project)
                {
                    var newItem = new ListItem();
                    newItem.Value = item.ProjectID.ToString();
                    newItem.Text = item.ProjectName.ToString();
                    DropDownList1.Items.Add(newItem);
                }
            }
        }

        private void loadUserDropdown(List<User> user)
        {
            foreach (var item in user)
            {
                var newItem = new ListItem();
                newItem.Value = item.UserID.ToString();
                newItem.Text = item.UserName.ToString() + " " + item.Designation.DesignationName.ToString();
                DropDownList2.Items.Add(newItem);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (PMTDBContext context = new PMTDBContext())
            {
                Task task = new Task();
                task.TaskDescription = TextBox1.Text.ToString();
                task.DueDate = Convert.ToDateTime(DropDownList3.SelectedValue);
                task.Priority = DropDownList4.SelectedItem.Text.ToString();
                task.TaskAssignedTo = DropDownList2.SelectedItem.Text.ToString();
                task.ProjectID = Convert.ToInt32(DropDownList1.SelectedValue);

                User user = context.Users.FirstOrDefault(a => a.UserID == 3);
                task.TaskAssignedBy = user.UserName.ToString();

                context.Tasks.Add(task);
                context.SaveChanges();
            }
            Response.Redirect("~/ProjectDetails.aspx?ProjectID="+DropDownList1.SelectedValue.ToString());
        }
    }
}