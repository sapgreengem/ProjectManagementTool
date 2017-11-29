using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementTool
{
    public partial class MyProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserLogin"]);
            using (PMTDBContext context = new PMTDBContext())
            {
                IEnumerable<UsersUnderProject> usersUnderProject = context.UsersUnderProjects.Where(a => a.UserID == userId).ToList();
                List<Project> project = new List<Project>();
                foreach (var item in usersUnderProject)
                {
                    Project projectData = context.Projects.FirstOrDefault(a => a.ProjectID == item.ProjectID);
                    project.Add(projectData);
                }
                GridView1.DataSource = project.Select(a=> new {a.ProjectName, a.Description, a.StartDate, a.EndDate, a.Status, a.NumOfMember, a.NumOfTask, a.ProjectID }).ToList();
                GridView1.DataBind();
            }
        }
    }
}