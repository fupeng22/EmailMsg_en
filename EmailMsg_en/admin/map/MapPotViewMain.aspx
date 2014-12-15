<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapPotViewMain.aspx.cs" Inherits="admin_map_MapPotViewMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Real time monitoring and alarm information</title>
    <script src="../../Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../../JqueryUI/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="../../JqueryUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../JqueryUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../../JqueryUI/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../JS/MapPotViewMain.js" type="text/javascript"></script>
</head>
<body>
    <div id="layout_Main" class="easyui-layout" data-options="fit:true,border:false">
        <div region="north" split="false" style="height: 35px; padding: 2px" border="true">
            Select Map：<input type="text" id="ddlMapSele" name="ddlMapSele" style="width: 400px" /></div>
        <div region="center" border="false" split="true">
            <iframe id="iframeMapPotView" style="width: 99%; height: 99%; margin: 0px"></iframe>
        </div>
    </div>
</body>
</html>
