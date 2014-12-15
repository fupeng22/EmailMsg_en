<%@ Page Language="C#" AutoEventWireup="true" CodeFile="worker_Info.aspx.cs" Inherits="admin_worker_Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Personnel detail information</title>
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="7">
            </td>
        </tr>
    </table>
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="30" class="title_top" align="center">
                Personnel information
            </td>
        </tr>
    </table>
    <table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee"
        border="0">
        <tr>
            <th style="width: 120px; height: 30px; background-color: #dfefff;" align="right">
                ID：
            </th>
            <td bgcolor="#ffffff">
                <asp:Label ID="ShowWorkerID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Staff name：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="WorkerName" runat="server" Columns="35" MaxLength="20"></asp:TextBox>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="WorkerName"
                    Display="Dynamic" ErrorMessage="Enter Staff name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Department name：：
            </th>
            <td bgcolor="#ffffff">
                <asp:DropDownList ID="ddlGroupName" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlGroupName"
                    Display="Dynamic" ErrorMessage="Select department name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                E-mail：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="Email" runat="server" Columns="35" MaxLength="50"></asp:TextBox>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Email"
                    Display="Dynamic" ErrorMessage="Invalid e-mail format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Gender
            </th>
            <td bgcolor="#ffffff">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem Value="0">Male</asp:ListItem>
                    <asp:ListItem Value="1">Female</asp:ListItem>
                </asp:DropDownList>
                &nbsp;
                <br />
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Phone Number：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="Tel" runat="server" Columns="35" MaxLength="50"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Address：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="Address" runat="server" Columns="35" MaxLength="200"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                &nbsp;
            </th>
            <td bgcolor="#ffffff">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Edit" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Return" OnClick="btnCancel_Click" CausesValidation="False">
                </asp:Button>
            </td>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
