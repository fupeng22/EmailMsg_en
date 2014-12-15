<%@ Page Language="C#" AutoEventWireup="true" CodeFile="group_manage.aspx.cs" Inherits="admin_group_manage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Department information management</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />
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
                Department information list
            </td>
        </tr>
    </table>
    <table width="96%" border="1" align="center" cellpadding="0" cellspacing="0" bgcolor="#DFEFFF"
        bordercolorlight="#77AEEE">
        <tr>
            <td height="32" style="padding-left: 8px;">
                <asp:Button ID="Button1" runat="server" Text="Add depart" OnClick="Button1_Click" Height="29px" />&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Delete depart" OnClick="Button2_Click" Height="29px" />&nbsp;
                <asp:Button ID="Button4" runat="server" Text="Add root" OnClick="Button4_Click" Height="30px" />&nbsp;
                <asp:Button ID="Button3" runat="server" Text="Edit depart" OnClick="Button3_Click" Height="30px" />&nbsp;
            </td>
        </tr>
    </table>
    <table border="0" align="left" cellpadding="0" cellspacing="10" style="width: 98%">
        <tr>
            <td>
                <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="0" OnTreeNodePopulate="TreeView1_TreeNodePopulate"
                    Style="position: relative" ImageSet="Simple" CollapseImageUrl="~/image/decrease.bmp"
                    ExpandImageUrl="~/image/add.bmp" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                    <ParentNodeStyle Font-Bold="False" />
                    <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                    <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                        VerticalPadding="0px" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
                        NodeSpacing="0px" VerticalPadding="2px" />
                </asp:TreeView>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
