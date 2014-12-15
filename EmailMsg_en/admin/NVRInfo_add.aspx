<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NVRInfo_add.aspx.cs" Inherits="admin_NVRInfo_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add NVR device</title>
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function openNew() {
            var num = Math.round(Math.random() * 10000);
            var strWidth = "400px";
            var strHeight = "600px";
            var robj = showModalDialog("group_select.aspx?temp=" + num, window, "dialogHeight='" + strHeight + "';dialogWidth='" + strWidth + "';status=no;scroll=yes;help=no");
            if (robj) {
                var jsonMsg = eval("(" + robj + ")");
                document.getElementById("GroupName").value = jsonMsg.GroupName;
                document.getElementById("hd_GroupId").value = jsonMsg.GroupId;
            }
        }  
    </script>
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
                Add NVR device
            </td>
        </tr>
    </table>
    <table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee"
        border="0">
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Device name：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="NVRName" runat="server" Columns="35" MaxLength="20"></asp:TextBox>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="NVRName"
                    Display="Dynamic" ErrorMessage="Enter device name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                IP：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="NVRIP" runat="server" Columns="35" MaxLength="20"></asp:TextBox>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="NVRIP"
                    Display="Dynamic" ErrorMessage="Enter IP" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Port：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="NVRPort" runat="server" Columns="35" MaxLength="20"></asp:TextBox>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="NVRPort"
                    Display="Dynamic" ErrorMessage="Enter port" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Department：
            </th>
            <td bgcolor="#ffffff">
                <input type="text" id="GroupName" name="GroupName" onclick="openNew();" runat="server"
                    readonly />
                <input type="hidden" runat="server" id="hd_GroupId" />
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="GroupName"
                    Display="Dynamic" ErrorMessage="Select department" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                User name：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="UserName" runat="server" Columns="35" MaxLength="20"></asp:TextBox>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="UserName"
                    Display="Dynamic" ErrorMessage="Enter user name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Password：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="UserPwd" runat="server" Columns="35" MaxLength="20" TextMode="Password"></asp:TextBox>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="UserPwd"
                    Display="Dynamic" ErrorMessage="Enter password" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                &nbsp;
            </th>
            <td bgcolor="#ffffff">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" />&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Return" OnClick="btnCancel_Click" CausesValidation="False">
                </asp:Button>
            </td>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
