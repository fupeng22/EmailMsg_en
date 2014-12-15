<%@ Page Language="C#" AutoEventWireup="true" CodeFile="worker_Add.aspx.cs" Inherits="admin_worker_Add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Staff add page</title>
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
                Add staff information
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
                <asp:TextBox ID="WorkerName" runat="server" Columns="35" MaxLength="20"></asp:TextBox>
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="WorkerName"
                    Display="Dynamic" ErrorMessage="Enter Staff name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Department name：
            </th>
            <%--<td bgcolor="#ffffff">
                <asp:DropDownList ID="ddlGroupName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGroupName_SelectedIndexChanged">
                </asp:DropDownList>
                <span class="style2">&nbsp;&nbsp;*必填项</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlGroupName"
                    Display="Dynamic" ErrorMessage="请输入部门名称" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>--%>
             <td bgcolor="#ffffff">
                <input type="text" id="txtGroupName" name="txtGroupName" onclick="openNew();" runat="server"
                    readonly />
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGroupName"
                    Display="Dynamic" ErrorMessage="Select department name" ForeColor="Red"></asp:RequiredFieldValidator>
                <input type="hidden" id="hid_GroupId" name="hid_GroupId" runat="server" />
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
                Gender：
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
