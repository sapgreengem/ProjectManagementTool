using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementTool
{
    public partial class ProjectDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var value = Convert.ToInt32(Request.QueryString["ProjectID"]);
            if (value > 0 || Request.QueryString["ProjectID"] != null)
            {
                using (PMTDBContext context = new PMTDBContext())
                {
                    Project project = context.Projects.FirstOrDefault(a => a.ProjectID == value);
                    ProjectName.Text = project.ProjectName;
                    CodeName.Text = project.CodeName;
                    Description.Text = project.Description;
                    Status.Text = project.Status;
                    StartDate.Text = project.StartDate.ToString();
                    EndDate.Text = project.EndDate.ToString();
                    Duration.Text = Convert.ToString((Convert.ToDateTime(project.EndDate) - Convert.ToDateTime(project.StartDate)).TotalDays);
                    ListBox1.Items.Add(project.FileName);

                    List<UsersUnderProject> usersUnderProject = context.UsersUnderProjects.Where(a => a.ProjectID == value).ToList();
                    List<User> user = new List<User>();
                    foreach (var item in usersUnderProject)
                    {
                        User addUser = context.Users.FirstOrDefault(a => a.UserID == item.UserID);
                        user.Add(addUser);
                    }
                    GridView1.DataSource = user.Select(a=> new { a.UserName, a.Designation.DesignationName}).ToList();
                    GridView1.DataBind();

                    GridView2.DataSource = context.Tasks.Where(a => a.ProjectID == value).Select(a => new {a.TaskDescription, a.TaskAssignedTo, a.Priority, a.TaskAssignedBy, a.DueDate, a.TaskID }).ToList();
                    GridView2.DataBind();
                    Label10.Text = "Task List (Total:"+ context.Tasks.Where(a => a.ProjectID == value).Count() + ")";
                    //context.Tasks.Where(a => a.ProjectID == value).Count();
                }
            }
            else
            {
                Response.Write("URL Error");
            }
            
        }
    }
}