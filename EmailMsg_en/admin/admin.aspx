<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin.aspx.cs" Inherits="admin_admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Mail forwarding management main page</title>
    <link href="../Css/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #__01
        {
            height: 812px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center" id="__01" border="0" cellpadding="0" cellspacing="0" width="1003">
        <!-- <tr>
                            <td width="10">
                                &nbsp;</td>
                            <td width="144">
                                &nbsp;</td>
                            <td width="55">
                                &nbsp;</td>
                            <td class="huise" width="770">
                                &nbsp;</td>
                        </tr>-->
        <tr>
            <td colspan="2">
                <img alt="" border="0" height="93" src="../images/guanli_01.jpg" usemap="#Map" width="1003" />
            </td>
        </tr>
        <tr>
            <td>
                <img alt="" height="33" src="../images/guanli_02.jpg" width="182" />
            </td>
            <td background="../images/guanli_03.jpg" height="33" width="821">
                <table cellpadding="0" cellspacing="0" width="589">
                    <tr>
                        <td width="41">
                            &nbsp;
                        </td>
                        <td class="huise" width="546">
                            Location：Mail forwarding management system &gt; <span class="hong">Management mode pages</span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td background="../images/guanli_04.jpg" colspan="2" height="420" valign="top">
                <table cellpadding="0" cellspacing="0" width="981">
                </table>
                <table cellpadding="0" cellspacing="0" style="width: 991px">
                    <tr>
                        <td style="width: 185px; height: 374px; vertical-align: top;">
                            <asp:TreeView ID="TreeView1" runat="server" ImageSet="Simple" Width="86px" align="center"
                                Height="16px">
                                <ParentNodeStyle Font-Bold="False" />
                                <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
                                <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                                    VerticalPadding="0px" />
                                <Nodes>
                                    <asp:TreeNode Text="Basic information" Value="Basic information">
                                        <asp:TreeNode Text="Department management" Value="Department management" NavigateUrl="~/admin/group_manage.aspx"
                                            Target="mainFrame"></asp:TreeNode>
                                        <asp:TreeNode Text="People management" Value="People management" NavigateUrl="~/admin/worker_manage.aspx"
                                            Target="mainFrame"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="NVR management" Value="NVR management">
                                        <asp:TreeNode Text="NVR management" Value="NVR management" NavigateUrl="~/admin/NVRInfo_manage.aspx"
                                            Target="mainFrame"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="Equipment management" Value="Equipment management">
                                        <asp:TreeNode Text="Equipment type" Value="Equipment type" NavigateUrl="~/admin/equipmenttype_manage.aspx"
                                            Target="mainFrame"></asp:TreeNode>
                                        <asp:TreeNode Text="Equipment information" Value="Equipment information" NavigateUrl="~/admin/equipmentinfo_manage.aspx"
                                            Target="mainFrame"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="Alarm management" Value="Alarm management">
                                        <asp:TreeNode Text="Example graph" Value="Example graph" NavigateUrl="~/admin/example_graph_manage.aspx"
                                            Target="mainFrame"></asp:TreeNode>
                                        <asp:TreeNode Text="Alarm type" Value="Alarm type" NavigateUrl="~/admin/alarm_manage.aspx"
                                            Target="mainFrame"></asp:TreeNode>
                                        <asp:TreeNode Text="Alarm setting" Value="Alarm setting" NavigateUrl="~/admin/alarm_example_graph_manage.aspx"
                                            Target="mainFrame"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="Screening information" Value="Screening information">
                                        <asp:TreeNode Text="Alarm type" Value="Alarm type" NavigateUrl="~/admin/selectalarm_manage.aspx"
                                            Target="mainFrame"></asp:TreeNode>
                                        <asp:TreeNode Text="Position equipment" Value="Position equipment" NavigateUrl="~/admin/selectequipment_manage.aspx"
                                            Target="mainFrame"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="Receive message" Value="Receive message">
                                        <asp:TreeNode Text="Receive message" Value="Receive message" NavigateUrl="~/admin/receivemsg_manage.aspx"
                                            Target="mainFrame"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="User management" Value="User management">
                                        <asp:TreeNode Text="Modify password" Value="Modify password" NavigateUrl="~/admin/user_password.aspx" Target="mainFrame">
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="User management" Value="User management" NavigateUrl="~/admin/user_manage.aspx" Target="mainFrame">
                                        </asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="Map management" Value="Map management">
                                        <asp:TreeNode Text="Map design" Value="Map design" NavigateUrl="~/admin/map/mapMain.aspx" Target="_blank">
                                        </asp:TreeNode>
                                        <asp:TreeNode Text="Map monitor" Value="Map monitor" NavigateUrl="~/admin/map/MapPotViewMain.aspx"
                                            Target="_blank"></asp:TreeNode>
                                    </asp:TreeNode>
                                    <asp:TreeNode Text="About" Value="About">
                                        <asp:TreeNode Text="Login out" Value="Login out" NavigateUrl="~/Default.aspx"></asp:TreeNode>
                                    </asp:TreeNode>
                                </Nodes>
                                <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" HorizontalPadding="0px"
                                    NodeSpacing="0px" VerticalPadding="0px" />
                            </asp:TreeView>
                        </td>
                        <td style="height: 374px; vertical-align: top;">
                            <iframe id="iframe1" name="mainFrame" style="width: 802px; height: 625px" frameborder="0">
                            </iframe>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td background="../images/guanli_05.jpg" colspan="2" height="62" valign="top">
                <table align="center" cellpadding="0" cellspacing="0" height="39" width="488">
                    <tr>
                        <td align="center" height="39">
                            <span class="huise">公司网址：www.chinabetter.com &nbsp;&nbsp; 上海贝通电子科技有限公司 版权所有</span>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <!-- End ImageReady Slices -->
    <map name="Map">
        <!--<area coords="820,63,906,89" href="../Default.aspx" shape="RECT" />-->
        <area coords="909,61,994,89" href="../Default.aspx" shape="RECT" />
    </map>
    </form>
</body>
</html>
