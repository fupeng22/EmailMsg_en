<%@ Page Language="C#" AutoEventWireup="true" CodeFile="equipmenttype_Info.aspx.cs"
    Inherits="admin_equipmenttype_Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Device type</title>
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
                Device type infomation
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
                <asp:Label ID="ShowEquipmentTypeID" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Device type name：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="EquipmentTypeName" runat="server" Columns="35" MaxLength="20"></asp:TextBox>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EquipmentTypeName"
                    Display="Dynamic" ErrorMessage="Enter device type name" ForeColor="Red"></asp:RequiredFieldValidator>
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
