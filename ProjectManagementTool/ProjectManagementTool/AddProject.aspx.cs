using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProjectManagementTool
{
    public partial class AddProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //using (PMTDBContext context = new PMTDBContext())
            //{
            //    GridView1.DataSource = context.Projects.ToList();
            //    GridView1.DataBind();
            //}
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Calendar1.Visible == false)
            {
                Calendar1.Visible = true;
            }
            else
            {
                Calendar1.Visible = false;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Calendar2.Visible == false)
            {
                Calendar2.Visible = true;
            }
            else
            {
                Calendar2.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string fileName = Path.GetFileName(postedFile.FileName);
            int fileSize = postedFile.ContentLength;
            string filepath = Server.MapPath("~/uploads");

            if (FileUpload1.HasFile)
            {
                if (fileSize < 4000000)
                {
                    FileUpload1.SaveAs(filepath + "\\" + DateTime.Now.ToFileTime() + " " + FileUpload1.FileName);

                    using (PMTDBContext context = new PMTDBContext())
                    {
                        Project project = new Project();
                        project.ProjectName = ProjectName.Text.ToString();
                        project.CodeName = CodeName.Text.ToString();
                        project.Description = Description.Text.ToString();
                        project.StartDate = Convert.ToDateTime(StartDate.Text);
                        project.EndDate = Convert.ToDateTime(EndDate.Text);
                        project.Status = RadioButtonList1.SelectedValue.ToString();
                        project.FileName = DateTime.Now.ToFileTime() + " " + FileUpload1.FileName.ToString();
                        project.NumOfMember = 0;
                        project.NumOfTask = 0;
                        context.Projects.Add(project);
                        context.SaveChanges();
                    }
                    Response.Redirect("~/AddProject.aspx");
                }
                else
                {
                    Label9.Text = "File size is too large";
                }
            }
            else
            {
                Label9.Text = "No file selected";
            } 
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            StartDate.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            EndDate.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
            TextBox4.Text =Convert.ToString((Convert.ToDateTime(EndDate.Text) - Convert.ToDateTime(StartDate.Text)).TotalDays);

        }
    }
}