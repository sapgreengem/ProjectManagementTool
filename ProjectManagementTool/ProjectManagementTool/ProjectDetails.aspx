<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectDetails.aspx.cs" Inherits="ProjectManagementTool.ProjectDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 127px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="float: left">
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
                            <asp:Label ID="Label2" runat="server" Text="Code Name"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="CodeName" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Description" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label4" runat="server" Text="Status"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Status" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label5" runat="server" Text="Possible Start Date"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="StartDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label6" runat="server" Text="Possible End Date"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="EndDate" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label7" runat="server" Text="Duration"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Duration" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label8" runat="server" Text="Uploaded Files"></asp:Label>
                        </td>
                        <td>
                            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label9" runat="server" Text="Assigned Members"></asp:Label>
                        </td>
                        <td>
                            <asp:GridView ID="GridView1" runat="server">
                            </asp:GridView>
                        </td>
                    </tr>
                </table>

            </div>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Task List"></asp:Label>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:HyperLink ID="CreateTask" runat="server" NavigateUrl="~/AddTask.aspx">Create Task</asp:HyperLink>
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView2" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="TaskID" HtmlEncode="False" DataFormatString="<a href='ViewComment.aspx?TaskID={0}'>View Comments</a>" HeaderText="Action" />
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>

            </div>
        </div>
    </form>
</body>
</html>
