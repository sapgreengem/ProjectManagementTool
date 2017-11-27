<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewComment.aspx.cs" Inherits="ProjectManagementTool.ViewComment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100px;
        }
    </style>
</head>
<body>
    <h2>View Comments of a Task</h2>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label1" runat="server" Text="Project Name"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="ProjectName" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label2" runat="server" Text="Task"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="Task" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Comments"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/AddComment.aspx">New Comment</asp:HyperLink>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
