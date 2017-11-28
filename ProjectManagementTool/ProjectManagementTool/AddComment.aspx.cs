using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementTool
{
    public partial class AddComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.loadProjectDropdowns();
            }
        }
        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            var Id = Convert.ToInt32(DropDownList1.SelectedValue);
            DropDownList2.Items.Clear();
            using (PMTDBContext context = new PMTDBContext())
            {
                List<Task> task = context.Tasks.Where(a => a.ProjectID == Id).ToList();
                foreach (var item in task)
                {
                    var newItem = new ListItem();
                    newItem.Value = item.TaskID.ToString();
                    newItem.Text = item.TaskDescription.ToString();
                    DropDownList2.Items.Add(newItem);
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

        protected void Button1_Click1(object sender, EventArgs e)
        {
            using (PMTDBContext context = new PMTDBContext())
            {
                Comment comment = new Comment();
                comment.Comment1 = TextBox1.Text.ToString();
                comment.CommentDate = DateTime.Now;
                comment.TaskID = Convert.ToInt32(DropDownList2.SelectedValue);
                comment.UserID = 3;
                context.Comments.Add(comment);
                context.SaveChanges();
            }
            Response.Redirect("~/ViewComment.aspx?TaskID=" + DropDownList2.SelectedValue.ToString());
        }
    }
}