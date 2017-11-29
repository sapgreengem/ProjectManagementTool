using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementTool
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (PMTDBContext context = new PMTDBContext())
            {
                GridView1.DataSource = context.Projects.Where(a => a.EndDate > DateTime.Now).Select(a=> new { a.ProjectName, a.CodeName, a.StartDate, a.EndDate, a.Status}).ToList();
                GridView1.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
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
                GridView1.DataSource = joinData.OrderBy(a=> a.ProjectName).ToList();
                GridView1.DataBind();
            }
        }
    }
}