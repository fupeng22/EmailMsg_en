<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapPotPositionView.aspx.cs" Inherits="admin_map_MapPotPostionView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../../JqueryUI/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="../../JqueryUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../JqueryUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../../JqueryUI/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../JS/MapPotView.js" type="text/javascript"></script>
    <link href="../../Css/MapPot.css" rel="stylesheet" type="text/css" />
</head>
<body id="body_Main" style="margin: 0px; position: absolute;">
    <img src="" id="img_Map" />
    <div id="editMapPortMemu" class="easyui-menu" style="width: 100px;">
        <div id="mnu_ViewMapPort_Detail" name="mnu_ViewMapPort_Detail">
            设备点属性</div>
    </div>
    <input type="hidden" id="hid_MapId" name="hid_MapId" runat="server" />
    <input type="hidden" id="hid_MapName" name="hid_MapName" runat="server" />
    <input type="hidden" id="hid_MapPath" name="hid_MapPath" runat="server" />
    <input type="hidden" id="hid_GroupName" name="hid_GroupName" runat="server" />
    <input type="hidden" id="hid_MapPotId" name="hid_MapPotId" runat="server" />
</body>
</html>
