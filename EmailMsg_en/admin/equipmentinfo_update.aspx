<%@ Page Language="C#" AutoEventWireup="true" CodeFile="equipmentinfo_update.aspx.cs"
    Inherits="admin_equipmentinfo_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Device</title>
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function openNew() {
            var num = Math.round(Math.random() * 10000);
            var strWidth = "400px";
            var strHeight = "600px";
            var robj = showModalDialog("group_select.aspx?temp=" + num, window, "dialogHeight='" + strHeight + "';dialogWidth='" + strWidth + "';status=no;scroll=yes;help=no");
            if (robj) {
                var jsonMsg = eval("(" + robj + ")");
                document.getElementById("txtGroupName").value = jsonMsg.GroupName;
                document.getElementById("hid_GroupId").value = jsonMsg.GroupId;
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
                Edit device infomation
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
                <asp:TextBox ID="EquipmentName" runat="server" Columns="35" MaxLength="20"></asp:TextBox>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="EquipmentName"
                    Display="Dynamic" ErrorMessage="Enter device name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Conn type：
            </th>
            <td bgcolor="#ffffff">
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem Value="0">0:232直连</asp:ListItem>
                    <asp:ListItem Value="1">1:232转tcp/ip</asp:ListItem>
                    <asp:ListItem Value="2">2:485直连</asp:ListItem>
                    <asp:ListItem Value="3">3:485转tcp/ip</asp:ListItem>
                    <asp:ListItem Value="4">4:设备直发</asp:ListItem>
                </asp:DropDownList>
                &nbsp; <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="DropDownList2"
                    Display="Dynamic" ErrorMessage="Select conn type" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Hanging device number：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="EquipmentID" runat="server" Columns="35" MaxLength="50"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                IP：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="EquipmentIP" runat="server" Columns="35" MaxLength="50"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Port：
            </th>
            <td bgcolor="#ffffff">
                <asp:TextBox ID="EquipmentPort" runat="server" Columns="35" MaxLength="50"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Department：
            </th>
            <td bgcolor="#ffffff">
                <input type="text" id="txtGroupName" name="txtGroupName" onclick="openNew();" runat="server"
                    readonly />
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGroupName"
                    Display="Dynamic" ErrorMessage="Select department" ForeColor="Red"></asp:RequiredFieldValidator>
                <input type="hidden" id="hid_GroupId" name="hid_GroupId" runat="server" />
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Device type：
            </th>
            <td bgcolor="#ffffff">
                <asp:DropDownList ID="ddlEquipmentType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEquipmentType_SelectedIndexChanged">
                </asp:DropDownList>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlEquipmentType"
                    Display="Dynamic" ErrorMessage="Select device type" ForeColor="Red"></asp:RequiredFieldValidator>
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
        </tr>
    </table>
    <input type="hidden" id="hid_EquipmentId" name="hid_EquipmentId"  runat="server"/>
    </form>
</body>
</html>
