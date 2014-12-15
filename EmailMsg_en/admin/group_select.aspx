<%@ Page Language="C#" AutoEventWireup="true" CodeFile="group_select.aspx.cs" Inherits="admin_group_select" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function toFather(value, text) {
            window.returnValue = '{"GroupName":"' + text + '","GroupId":"' + value + '"}';
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="0" Style="position: relative"
            ImageSet="Simple" CollapseImageUrl="~/image/decrease.bmp" ExpandImageUrl="~/image/add.bmp"
            OnTreeNodePopulate="TreeView1_TreeNodePopulate">
            <ParentNodeStyle Font-Bold="False" />
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                VerticalPadding="0px" />
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                NodeSpacing="0px" VerticalPadding="2px" />
        </asp:TreeView>
    </div>
    </form>
</body>
</html>
