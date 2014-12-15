<%@ Page Language="C#" AutoEventWireup="true" CodeFile="alarm_example_graph_view.aspx.cs"
    Inherits="admin_alarm_example_graph_view" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View alarm-example graph</title>
    <link href="../css/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <span style="padding: 7px"><span style="font-size: medium">Alarm ID:</span><asp:Label
        runat="server" ID="lblAlarmTypeId" ForeColor="Blue" Font-Bold="true" Font-Size="Medium"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <span style="font-size: medium">Alarm description:</span><asp:Label runat="server" ID="lblAlarmTypeName"
            ForeColor="Blue" Font-Bold="true" Font-Size="Medium"></asp:Label></span>
    <hr style="font-weight: bold; font-size: large" />
    <asp:Repeater ID="rpt_ExampleGraph" runat="server">
        <ItemTemplate>
            <a target="_blank" href='exampleGraphView.aspx?exampleGraphPath=<%#Eval("graphPath")%>'>
                <img src='<%#Eval("graphPath")%>' style="width: 350px; height: 200px" alt="Example graph" title="Click to view the original example graph"/></a>
        </ItemTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
