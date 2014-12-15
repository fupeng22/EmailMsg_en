<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapMain.aspx.cs" Inherits="admin_map_MapMain" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Electronic map management main page</title>
    <script src="../../Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../../JqueryUI/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="../../JqueryUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../JqueryUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../../JqueryUI/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../JS/MapMain.js" type="text/javascript"></script>
</head>
<body>
    <div id="layout_Main" class="easyui-layout" data-options="fit:true,border:false">
        <div region="west" split="true" style="width: 200px;" border="false">
            <div id="layout_Sub1" class="easyui-layout" data-options="fit:true,border:false">
                <div region="north" split="true" style="height: 350px; padding: 2px" border="true">
                    <div id="TVGroup" name="TVGroup" fit="true">
                    </div>
                </div>
                <div region="center" border="false" split="true" style="height: 20px;">
                    <center>
                        <font style="color: Red; font-weight: bold">【<span id="span_AreaName"></span>】Map infomation</font></center>
                </div>
                <div region="south" split="true" border="false">
                    <div id="layout_Sub2" class="easyui-layout" data-options="fit:true,border:false">
                        <div region="center" border="false" split="true" style="height: 60px;">
                            <a href="javascript:void(0)" id="btnAddMap" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-add'">
                                Add map</a>|<a href="javascript:void(0)" id="btnUpdateMap" class="easyui-linkbutton"
                                    data-options="plain:true,iconCls:'icon-edit'">Edit map</a><br />
                            <a href="javascript:void(0)" id="btnDeleteMap" class="easyui-linkbutton" data-options="plain:true,iconCls:'icon-remove'">
                                Delete map</a>
                        </div>
                        <div region="south" split="true" style="height: 160px;" border="false">
                            <div id="DG_MapInfo" fit="true" style="width: 800px; height: 600px">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div region="center" border="false" split="true">
            <div id="layout_Sub3" class="easyui-layout" data-options="fit:true,border:false">
                <div region="north" split="true" style="height: 68px;" border="true">
                    <span style="float: left">
                        <center>
                            <font style="color: Red; font-weight: bold; font-size: 22px">【<span id="span_Area_Detail"></span>】Map【<span
                                id="span_MapName"></span>】Detail</font></center>
                    </span><span style="float: right; color: Blue; font-weight: bold; font-size: 15px">Double click the map blank area to add equipment, right click equipment can be modified or delete some equipment, you can drag the equipment manual positioning</span>
                </div>
                <div region="center" border="false" split="true" style="height: 70px;">
                    <iframe id="iframeMapView" style="width: 99%; height: 98%; margin: 0px"></iframe>
                </div>
            </div>
        </div>
    </div>
    <div id="div_MapAdd">
        <form method="post" id="form_MapAdd" enctype="multipart/form-data">
        <table>
            <tr>
                <td>
                    Area:
                </td>
                <td>
                    <span id="span_AreaName_MapAdd" style="font-weight: bold; color: Red"></span>
                    <input type="hidden" id="hid_AreaId_MapAdd" name="hid_AreaId_MapAdd" />
                </td>
            </tr>
            <tr>
                <td>
                    Map name:
                </td>
                <td>
                    <input type="text" id="txtMapName_Add" name="txtMapName_Add" style="width: 300px" />
                </td>
            </tr>
            <tr>
                <td>
                    Map path:
                </td>
                <td>
                    <input type="file" id="mapFile_Add" name="mapFile_Add" />
                </td>
            </tr>
        </table>
        </form>
    </div>
    <div id="div_MapUpdate" style="padding: 2px">
        <form method="post" id="form_MapUpdate" enctype="multipart/form-data">
        <table>
            <tr>
                <td>
                    Area:
                </td>
                <td>
                    <span id="span_AreaName_MapUpdate" style="font-weight: bold; color: Red"></span>
                    <input type="hidden" id="hid_AreaId_MapUpdate" name="hid_AreaId_MapUpdate" />
                    <input type="hidden" id="hid_MapId_MapUpdate" name="hid_MapId_MapUpdate" />
                </td>
            </tr>
            <tr>
                <td>
                    Map name:
                </td>
                <td>
                    <input type="text" id="txtMapName_Update" name="txtMapName_Update" style="width: 340px" />
                </td>
            </tr>
            <tr>
                <td>
                    Old map path:
                </td>
                <td>
                    <input type="text" id="mapFilePath_Old" name="mapFilePath_Old" style="width: 340px"
                        readonly />
                </td>
            </tr>
            <tr>
                <td>
                    New map path:
                </td>
                <td>
                    <input type="file" id="mapFile_Update" name="mapFile_Update" /><a href="javascript:void(0)"
                        id="btnClearNewMapFile" class="easyui-linkbutton" data-options="plain:false,iconCls:'icon-remove'">清除地图文件</a>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <font style="color: Blue; font-weight: bold">Note: do not choose a new map file will retain the old map file</font>
                </td>
            </tr>
        </table>
        </form>
    </div>
</body>
</html>
