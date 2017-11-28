using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementTool
{
    public partial class AssignResourcePerson : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.loadDropdowns();
            }
            this.loadData();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ( Convert.ToInt32(DropDownList1.SelectedValue) > 0 && Convert.ToInt32(DropDownList2.SelectedValue) > 0)
            {
                int ProjectId = Convert.ToInt32(DropDownList1.SelectedValue);
                using (PMTDBContext context = new PMTDBContext())
                {
                    UsersUnderProject usersUnderProject = new UsersUnderProject();
                    usersUnderProject.ProjectID = Convert.ToInt32(DropDownList1.SelectedValue);
                    usersUnderProject.UserID = Convert.ToInt32(DropDownList2.SelectedValue);
                    context.UsersUnderProjects.Add(usersUnderProject);
                    context.SaveChanges();

                    Project project = context.Projects.SingleOrDefault(a => a.ProjectID == ProjectId);
                    project.NumOfMember += 1;
                    context.SaveChanges();
                } 
            }
            else
            {
                Response.Write("Please Select Project and User");
            }
            this.loadDropdowns();
            this.loadData();
        }

        private void loadDropdowns()
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

                IEnumerable<User> user = context.Users.Where(a=> a.DesignationID != 1).ToList();
                foreach (var item in user)
                {
                    var newItem = new ListItem();
                    newItem.Value = item.UserID.ToString();
                    newItem.Text = item.UserName.ToString() +" "+ item.Designation.DesignationName.ToString();
                    DropDownList2.Items.Add(newItem);
                }
            }
        }

        private void loadData()
        {
            using (PMTDBContext context = new PMTDBContext())
            {
                IEnumerable<UsersUnderProject> usersUnderProject = context.UsersUnderProjects.ToList();
                List<Join_User_Project_UserUnderProject> joinData = new List<Join_User_Project_UserUnderProject>();
                foreach (var item in usersUnderProject)
                {
                    Join_User_Project_UserUnderProject addData = new Join_User_Project_UserUnderProject()
                    {
                        //AssignedID = item.AssignedID,
                        ProjectName = item.Project.ProjectName,
                        UserName = item.User.UserName,
                        DesignationName = item.User.Designation.DesignationName
                    };
                    joinData.Add(addData);
                }
                GridView1.DataSource = joinData.ToList();
                GridView1.DataBind();
            }
        }
    }
}