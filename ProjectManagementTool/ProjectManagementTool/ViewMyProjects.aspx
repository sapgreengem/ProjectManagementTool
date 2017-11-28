<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMyProjects.aspx.cs" Inherits="ProjectManagementTool.MyProjects" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Projects Where I am involved</h2>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server">
            <Columns>
                <asp:BoundField DataField="ProjectID" HtmlEncode="False" DataFormatString="<a target='_blank' href='ProjectDetails.aspx?ProjectID={0}'>View Details</a>" HeaderText="Action" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
