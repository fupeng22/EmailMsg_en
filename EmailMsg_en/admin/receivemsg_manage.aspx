<%@ Page Language="C#" AutoEventWireup="true" CodeFile="receivemsg_manage.aspx.cs"
    Inherits="admin_receivemsg_manage" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Receiving information management</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/DateAndTime.js"></script>
    <script type="text/javascript" src="../Scripts/Calendar_1.js" language="javascript"></script>
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
                Receiving information list
            </td>
        </tr>
    </table>
    <table width="96%" border="1" align="center" cellpadding="0" cellspacing="0" bgcolor="#DFEFFF"
        bordercolorlight="#77AEEE">
        <tr>
            <td style="padding-left: 8px;" class="style1">
                <span style="font-size: 9pt">Start time</span>
                <input type="text" id="beginTime" onfocus="calendar()" runat="server" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span style="font-size: 9pt">End time</span>
                <input type="text" id="endTime" onfocus="calendar()" runat="server" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_Find" runat="server" Text=" Search " OnClick="Button1_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button_Del" runat="server" Text=" Delete " OnClick="ButtonDel_Click" />
                <!--<asp:Label ID="lblPageSum" runat="server" Style="left: 428px; top: 23px;" ></asp:Label>
        <asp:RadioButton ID="rdoBtnCheckTrue" runat="server" AutoPostBack="True" GroupName="checkState"
             OnCheckedChanged="rdoBtnCheckTrue_CheckedChanged" Text="已经处理信息" />
        <asp:RadioButton ID="rdoBtnCheckFalse" runat="server" AutoPostBack="True" GroupName="checkState"
             OnCheckedChanged="rdoBtnCheckFalse_CheckedChanged" Text="未被处理信息" />
        <asp:RadioButton ID="rdoBtnCheckAll" runat="server" AutoPostBack="True" Checked="True"
             GroupName="checkState" OnCheckedChanged="rdoBtnCheckAll_CheckedChanged" Text="显示同类型所有接收信息" />-->
                <!--
        <asp:TextBox ID="Keywords" runat="server" Columns="30"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text=" 搜 索 " OnClick="Button1_Click" />&nbsp;<span class="gray">请输入文件名称或文件说明或文件分类或ID编号</span></td>-->
        </tr>
        <tr>
            <td height="32" style="padding-left: 8px;" align="center">
                <asp:RadioButton ID="RadioButton1" runat="server" AutoPostBack="True" GroupName="checkState"
                    OnCheckedChanged="rdoBtnCheckTrue_CheckedChanged" Text="发现但未在库中发现接收者" />
                <asp:RadioButton ID="RadioButton2" runat="server" AutoPostBack="True" GroupName="checkState"
                    OnCheckedChanged="rdoBtnCheckFalse_CheckedChanged" Text="未发现的报警类型" />
                <asp:RadioButton ID="RadioButton4" runat="server" AutoPostBack="True" GroupName="checkState"
                    Text="发现接收者，但发送邮件失败" OnCheckedChanged="RadioButton4_CheckedChanged" />
                <asp:RadioButton ID="RadioButton5" runat="server" AutoPostBack="True" GroupName="checkState"
                    Text="发送邮件成功" OnCheckedChanged="RadioButton5_CheckedChanged" />
                <asp:RadioButton ID="RadioButton6" runat="server" AutoPostBack="True" GroupName="checkState"
                    Text="执行GetDeviceID失败" OnCheckedChanged="RadioButton6_CheckedChanged" />
                <br />
                <asp:RadioButton ID="RadioButton3" runat="server" AutoPostBack="True" Checked="True"
                    GroupName="checkState" OnCheckedChanged="rdoBtnCheckAll_CheckedChanged" Text="显示同类型所有接收信息" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" Width="100%" DataKeyNames="ID" CellPadding="4"
                    AutoGenerateColumns="False" BackColor="#77AEEE" BorderColor="#77AEEE" BorderStyle="Solid"
                    OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                        <asp:BoundField HeaderText="Receive content" DataField="ReceiveMsg" />
                        <asp:BoundField HeaderText="Receive time" DataField="ReceiveTime" />
                        <%--<asp:BoundField HeaderText="是否处理" DataField="IsResult" />--%>
                        <asp:BoundField HeaderText="Result description" DataField="IsResultDes" />
                        <asp:HyperLinkField HeaderText="Detail" Text="View detail" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="receivemsg_Info.aspx?ID={0}">
                            <ControlStyle Font-Underline="False" ForeColor="Blue" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:HyperLinkField>
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
