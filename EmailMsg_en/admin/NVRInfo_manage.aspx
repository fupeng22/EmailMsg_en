<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NVRInfo_manage.aspx.cs" Inherits="admin_NVRInfo_manage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NVR device management</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 32px;
        }
    </style>
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
                NVR device list
            </td>
        </tr>
    </table>
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="title_top" align="center">
                <a href="NVRInfo_add.aspx">Add</a>
            </td>
        </tr>
    </table>
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" Width="100%" DataKeyNames="cId" CellPadding="4"
                    AutoGenerateColumns="False" BackColor="#77AEEE" BorderColor="#77AEEE" BorderStyle="Solid"
                    OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="NVRName" HeaderText="Device name"></asp:BoundField>
                        <asp:BoundField DataField="NVRIP" HeaderText="IP"></asp:BoundField>
                        <asp:BoundField HeaderText="Port" DataField="NVRPort" />
                        <asp:BoundField HeaderText="Department" DataField="GroupName" />
                        <asp:BoundField HeaderText="User name" DataField="UserName" />
                        <asp:TemplateField HeaderText="Operate">
                            <ItemTemplate>
                                <a href='NVRInfo_update.aspx?cId=<%#Eval("cId")%>'>Edit</a>&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;<a
                                        href='del_NVRInfo.aspx?cId=<%#Eval("cId")%>' onclick="javascript:if(confirm('Are you sure you want to delete？')){return true;}else{return false;}">Delete</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle HorizontalAlign="Center" BackColor="White" />
                    <HeaderStyle BackColor="#A5C8F0" Font-Size="13px" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 26px;">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Center" OnPageChanged="AspNetPager1_PageChanged"
                    ShowCustomInfoSection="Left" Width="100%" meta:resourceKey="AspNetPager1" Style="font-size: 14px"
                    InputBoxStyle="width:19px" CustomInfoHTML="Total:<b><font color='red'>%RecordCount%</font></b> Current:<font color='red'><b>%CurrentPageIndex%/%PageCount%</b></font>   Order %StartRecordIndex%-%EndRecordIndex%"
                    AlwaysShow="True" FirstPageText="First" LastPageText="End" NextPageText="Next" PageSize="15"
                    PrevPageText="Pre" CustomInfoStyle="FONT-SIZE: 12px">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
    <br />
    <br />
    </form>
</body>
</html>
