<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddProject.aspx.cs" Inherits="ProjectManagementTool.AddProject" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 132px;
        }
    </style>
</head>
<body>
    <h2>Add Project</h2>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Project Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Code Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr><tr>
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="Possible Start Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Enabled="false"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="Select" OnClick="Button2_Click" />
                    <asp:Calendar ID="Calendar1" runat="server" Visible="false"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label5" runat="server" Text="Possible End Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Enabled="false"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="Select" OnClick="Button3_Click" />
                    <asp:Calendar ID="Calendar2" runat="server" Visible="false"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label6" runat="server" Text="Duration(in Days)"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Enabled="false"></asp:TextBox>
                </td>
            </tr><tr>
                <td class="auto-style1">
                    <asp:Label ID="Label7" runat="server" Text="Upload File"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label8" runat="server" Text="Status"></asp:Label>
                </td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                        <asp:ListItem>Not Started</asp:ListItem>
                        <asp:ListItem>Started</asp:ListItem>
                        <asp:ListItem>Completed</asp:ListItem>
                        <asp:ListItem>Canceled</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Save" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
