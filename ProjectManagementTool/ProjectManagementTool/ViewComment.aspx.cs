using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementTool
{
    public partial class ViewComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var value = Convert.ToInt32(Request.QueryString["TaskID"]);
            if (value > 0 || Request.QueryString["TaskID"] != null)
            {
                using (PMTDBContext context = new PMTDBContext())
                {
                    Task task = context.Tasks.FirstOrDefault(a => a.TaskID == value);
                    Task.Text = task.TaskDescription.ToString();
                    ProjectName.Text = task.Project.ProjectName.ToString();
                }
                using (PMTDBContext context = new PMTDBContext())
                {
                    GridView1.DataSource = context.Comments.Where(a => a.TaskID == value).Select(a => new { a.Comment1, a.CommentDate }).ToList();
                    GridView1.DataBind();
                    Label3.Text = "Comments (Total: "+ context.Comments.Where(a => a.TaskID == value).Count() + ")";
                }
            }
            else
            {
                Response.Write("URL ERROR");
            }
                
        }
    }
}