<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mail forwarding management system</title>
    <link href="Css/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
        .style2
        {
            color: #FF0000;
        }
    </style>
   <%-- <script src="Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="JqueryUI/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="JqueryUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="JqueryUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="JqueryUI/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="JS/Login.js" type="text/javascript"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="left" cellpadding="0" cellspacing="0" height="750" width="100%" bgcolor="#e5f6cf">
            <tr>
                <td valign="middle">
                    <table align="center" cellpadding="0" cellspacing="0" height="290" width="545" background="images/admin/member_login.jpg"
                        style="margin-left: 15px">
                        <tr>
                            <td valign="bottom" width="545">
                                <table align="right" cellpadding="0" cellspacing="0" style="height: 200px; width: 300px;
                                    margin-left: 0px">
                                    <tr>
                                        <td class="huise" style="width: 85px; height: 30px;" valign="middle">
                                            User name：
                                        </td>
                                        <td colspan="2" class="style1">
                                            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUser"
                                                ErrorMessage="* Required fields" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="huise" height="30" style="width: 85px;" valign="middle">
                                            Password：
                                        </td>
                                        <td colspan="2" height="30">
                                            <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd"
                                                ErrorMessage="* Required fields" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="huise" style="width: 85px; height: 30px;" valign="middle">
                                            Verification code：
                                        </td>
                                        <td style="text-align: left;" class="style1">
                                            <asp:TextBox ID="txtVali" runat="server" Width="94px" Font-Size="9pt"></asp:TextBox>
                                            <img id="Img1" src="CheckCode.aspx" alt="看不清，请点击我！" onclick="this.src=this.src+'?'"
                                                style="width: 65px; height: 22px" />&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnOK" runat="server" Font-Size="9pt" Text="Login" OnClick="btnOK_Click"
                                                CausesValidation="False" /><span style="color: #ff0000"> </span>
                                            <asp:Button ID="btnCancle" runat="server" Font-Size="9pt" Text="Cancel" OnClick="btnCancle_Click"
                                                CausesValidation="False" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 16px">
                                            <span class="style2">Note: the verification code is not clear, please click the picture</span>
                                        </td>
                                        <td colspan="3" height="45">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
