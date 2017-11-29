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
    <h1>Logged In as : <% Response.Write( Session["UserName"].ToString()); %></h1>
    <div>
        <a href="AssignResourcePerson.aspx">Assign Person</a>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a href="ViewMyProjects.aspx">My Projects</a>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="/Logout.aspx">Logout</a>
    </div>
    
    <h2>Add Project</h2>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Project Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ProjectName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="Code Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="CodeName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Description" runat="server"></asp:TextBox>
                </td>
            </tr><tr>
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="Possible Start Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="StartDate" runat="server" Enabled="false"></asp:TextBox>
                    <asp:Button ID="Button2" runat="server" Text="Select" OnClick="Button2_Click" />
                    <asp:Calendar ID="Calendar1" runat="server" Visible="false" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label5" runat="server" Text="Possible End Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="EndDate" runat="server" Enabled="false"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Text="Select" OnClick="Button3_Click" />
                    <asp:Calendar ID="Calendar2" runat="server" Visible="false" OnSelectionChanged="Calendar2_SelectionChanged"></asp:Calendar>
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
                <td class="auto-style1">
                    <asp:Label ID="Label9" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Save" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    
    </div>
        <br />
        <h3>Projects List</h3>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProjectID" DataSourceID="SqlDataSource1" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <Columns>
                <asp:BoundField DataField="ProjectID" HeaderText="ProjectID" SortExpression="ProjectID" InsertVisible="False" ReadOnly="True" Visible="False" />
                <asp:BoundField DataField="ProjectName" HeaderText="ProjectName" SortExpression="ProjectName" />
                <asp:BoundField DataField="CodeName" HeaderText="CodeName" SortExpression="CodeName" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="StartDate" HeaderText="StartDate" SortExpression="StartDate" />
                <asp:BoundField DataField="EndDate" HeaderText="EndDate" SortExpression="EndDate" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="FileName" HeaderText="FileName" InsertVisible="False" SortExpression="FileName" />
                <asp:BoundField DataField="NumOfMember" HeaderText="NumOfMember" InsertVisible="False" ReadOnly="true" SortExpression="NumOfMember" />
                <asp:BoundField DataField="NumOfTask" HeaderText="NumOfTask" InsertVisible="False" ReadOnly="true" SortExpression="NumOfTask" />
                <asp:CommandField HeaderText="Action" ShowEditButton="True" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PMTDBConnectionString %>" DeleteCommand="DELETE FROM [Projects] WHERE [ProjectID] = @ProjectID" InsertCommand="INSERT INTO [Projects] ([ProjectName], [CodeName], [Description], [StartDate], [EndDate], [Status], [FileName], [NumOfMember], [NumOfTask]) VALUES (@ProjectName, @CodeName, @Description, @StartDate, @EndDate, @Status, @FileName, @NumOfMember, @NumOfTask)" SelectCommand="SELECT * FROM [Projects]" UpdateCommand="UPDATE [Projects] SET [ProjectName] = @ProjectName, [CodeName] = @CodeName, [Description] = @Description, [StartDate] = @StartDate, [EndDate] = @EndDate, [Status] = @Status, [FileName] = @FileName, [NumOfMember] = @NumOfMember, [NumOfTask] = @NumOfTask WHERE [ProjectID] = @ProjectID">
            <DeleteParameters>
                <asp:Parameter Name="ProjectID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ProjectName" Type="String" />
                <asp:Parameter Name="CodeName" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="FileName" Type="String" />
                <asp:Parameter Name="NumOfMember" Type="Int32" />
                <asp:Parameter Name="NumOfTask" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProjectName" Type="String" />
                <asp:Parameter Name="CodeName" Type="String" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="StartDate" Type="DateTime" />
                <asp:Parameter Name="EndDate" Type="DateTime" />
                <asp:Parameter Name="Status" Type="String" />
                <asp:Parameter Name="FileName" Type="String" />
                <asp:Parameter Name="NumOfMember" Type="Int32" />
                <asp:Parameter Name="NumOfTask" Type="Int32" />
                <asp:Parameter Name="ProjectID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
