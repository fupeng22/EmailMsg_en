<%@ Page Language="C#" AutoEventWireup="true" CodeFile="alarm_example_graph_update.aspx.cs"
    Inherits="admin_alarm_example_graph_update" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit alarm-example graph</title>
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function openNew() {
            var num = Math.round(Math.random() * 10000);
            var strWidth = "400px";
            var strHeight = "600px";
            var robj = showModalDialog("ExampleGraphSele.aspx?temp=" + num, window, "dialogHeight='" + strHeight + "';dialogWidth='" + strWidth + "';status=no;scroll=yes;help=no");
            if (robj) {
                var jsonMsg = eval("(" + robj + ")");
                document.getElementById("txtExampleGraphId").value = jsonMsg.ExampleGraphId;
                document.getElementById("ExampleGraphName").value = jsonMsg.ExampleGraphName;
            }
        }

        function openNew1() {
            var num = Math.round(Math.random() * 10000);
            var strWidth = "400px";
            var strHeight = "600px";
            var robj = showModalDialog("AlarmTypeSele.aspx?temp=" + num, window, "dialogHeight='" + strHeight + "';dialogWidth='" + strWidth + "';status=no;scroll=yes;help=no");
            if (robj) {
                var jsonMsg = eval("(" + robj + ")");
                document.getElementById("txtAlarmTypeId").value = jsonMsg.AlarmTypeId;
                document.getElementById("AlarmTypeName").value = jsonMsg.AlarmTypeName;
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
                Edit alarm-example graph<input type="hidden" id="hd_cId" runat="server" />
            </td>
        </tr>
    </table>
    <table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee"
        border="0">
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Example graph name：
            </th>
            <td bgcolor="#ffffff">
                <input type="text" id="ExampleGraphName" name="ExampleGraphName" onclick="openNew();"
                    runat="server" readonly /><input type="hidden" id="txtExampleGraphId" name="txtExampleGraphId"
                        runat="server" />
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ExampleGraphName"
                    Display="Dynamic" ErrorMessage="Enter example graph name" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <th style="height: 30px; background-color: #dfefff;" align="right">
                Alarm type name：
            </th>
            <td bgcolor="#ffffff">
                <input type="text" id="AlarmTypeName" name="AlarmTypeName" onclick="openNew1();"
                    runat="server" readonly /><input type="hidden" id="txtAlarmTypeId" name="txtAlarmTypeId"
                        runat="server" />
                <span class="style2">&nbsp;&nbsp;*Required fields</span>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="AlarmTypeName"
                    Display="Dynamic" ErrorMessage="Enter alarm type name" ForeColor="Red"></asp:RequiredFieldValidator>
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
