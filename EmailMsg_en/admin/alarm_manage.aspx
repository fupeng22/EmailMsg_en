<%@ Page Language="C#" AutoEventWireup="true" CodeFile="alarm_manage.aspx.cs" Inherits="admin_alarm_manage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Alarm type management</title>
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
                Alarm type list
            </td>
        </tr>
    </table>
    <table width="96%" border="1" align="center" cellpadding="0" cellspacing="0" bgcolor="#DFEFFF"
        bordercolorlight="#77AEEE">
        <tr>
            <td height="32" style="padding-left: 8px;">
                <span style="font-size: 9pt">Alarm type ID</span>
                <asp:TextBox ID="AlarmTypeID" runat="server" Columns="15"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="font-size: 9pt">Alarm type name</span>
                <asp:TextBox ID="AlarmTypeName" runat="server" Columns="15"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_Find" runat="server" Text=" Search " OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="10pt" OnClick="LinkButton1_Click">Add</asp:LinkButton></span>
            </td>
            <!--<asp:TextBox ID="Keywords" runat="server" Columns="30"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text=" 搜 索 " OnClick="Button1_Click" />&nbsp;<span class="gray">请输入文件名称或文件说明或文件分类或ID编号</span></td>-->
        </tr>
    </table>
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" Width="100%" DataKeyNames="cID" CellPadding="4"
                    AutoGenerateColumns="False" BackColor="#77AEEE" BorderColor="#77AEEE" BorderStyle="Solid"
                    OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="cID" HeaderText="ID"></asp:BoundField>
                        <asp:BoundField HeaderText="Alarm type name" DataField="AlarmTypeName" />
                        <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="cID" DataNavigateUrlFormatString="alarm_Info.aspx?ID={0}">
                            <ControlStyle Font-Underline="False" ForeColor="Blue" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                        <asp:TemplateField HeaderText="Operate">
                            <ItemTemplate>
                                <a href='del_alarm.aspx?Action=DelAlarm&AlarmID=<%#Eval("cID")%>' onclick="javascript:if(confirm('Are you sure you want to delete？')){return true;}else{return false;}">
                                    Delete</a>
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
                    AlwaysShow="True" FirstPageText="First" LastPageText="End" NextPageText="Next"
                    PageSize="15" PrevPageText="Pre" CustomInfoStyle="FONT-SIZE: 12px">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
    <br />
    <br />
    </form>
</body>
</html>
