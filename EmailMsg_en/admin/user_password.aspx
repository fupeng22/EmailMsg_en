<%@ Page Language="C#" AutoEventWireup="true" CodeFile="user_password.aspx.cs" Inherits="admin_user_password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update password</title>
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
                Update password
            </td>
        </tr>
    </table>
    <table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee"
        border="0">
        <tr>
            <th style="width: 120px; height: 30px; background-color: #dfefff;" align="right">
                User name：
            </th>
            <td bgcolor="#ffffff">
                <asp:Label ID="ShowUserName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                New password：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="UserPassword" runat="server" Columns="35" MaxLength="20"></asp:TextBox>
                <span class="style2">&nbsp;&nbsp;*Required fields</span><br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="UserPassword"
                    Display="Dynamic" ErrorMessage="Enter password" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator runat="server" ControlToValidate="UserPassword" Display="Dynamic"
                    ValidationExpression="[a-zA-Z0-9_]{4,20}" ErrorMessage="The password input error. Password length is 4-20, can be used for the character (A-Z A-Z 0-9) and the underscore '_', do not use spaces。"
                    ID="Regularexpressionvalidator2" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                &nbsp;
            </th>
            <td bgcolor="#ffffff">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Confirm" />
                <input id="Reset1" type="reset" value="Reset default" onclick="return Reset1_onclick()" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
