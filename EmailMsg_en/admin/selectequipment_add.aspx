<%@ Page Language="C#" AutoEventWireup="true" CodeFile="selectequipment_add.aspx.cs"
    Inherits="admin_selectequipment_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>筛选选设备信息添加页面</title>
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function openNew() {
            var num = Math.round(Math.random() * 10000);
            var strWidth = "400px";
            var strHeight = "600px";
            var robj = showModalDialog("equipment_sele.aspx?temp=" + num, window, "dialogHeight='" + strHeight + "';dialogWidth='" + strWidth + "';status=no;scroll=yes;help=no");
            if (robj) {
                var jsonMsg = eval("(" + robj + ")");
                document.getElementById("txtEuipmentId").value = jsonMsg.EquipmentId;
                document.getElementById("txtEquipment").value = jsonMsg.EquipmentName;
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
                添加筛选设备信息
            </td>
        </tr>
    </table>
    <table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee"
        border="0">
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Staff name：
            </th>
            <td bgcolor="#ffffff">
                <asp:DropDownList ID="ddlWorkerName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlWorkerName_SelectedIndexChanged">
                </asp:DropDownList>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlWorkerName"
                    Display="Dynamic" ErrorMessage="Enter staff name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <%-- <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                设备名称：
            </th>
            <td bgcolor="#ffffff">
                <asp:DropDownList ID="ddlEquipmentName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEquipmentName_SelectedIndexChanged">
                </asp:DropDownList>
                <span class="style2">&nbsp;&nbsp;*必填项</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlEquipmentName"
                    Display="Dynamic" ErrorMessage="请输入设备姓名" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>--%>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Equipment name：
            </th>
            <td bgcolor="#ffffff">
                <input type="text" id="txtEquipment" name="txtEquipment" onclick="openNew();" runat="server"
                    readonly /><input type="hidden" id="txtEuipmentId" name="txtEuipmentId" runat="server" />
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEquipment"
                    Display="Dynamic" ErrorMessage="Enter equipment name" ForeColor="Red"></asp:RequiredFieldValidator>
                <input type="hidden" id="hid_Equipment" name="hid_Equipment" runat="server" />
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
