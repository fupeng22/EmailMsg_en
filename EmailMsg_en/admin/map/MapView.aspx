<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MapView.aspx.cs" Inherits="admin_map_MapView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Map design</title>
    <script src="../../Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../../JqueryUI/jquery.easyui.min.js" type="text/javascript"></script>
    <link href="../../JqueryUI/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../JqueryUI/themes/icon.css" rel="stylesheet" type="text/css" />
    <script src="../../JqueryUI/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Scripts/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="../../JS/MapView.js" type="text/javascript"></script>
    <link href="../../Css/MapPot.css" rel="stylesheet" type="text/css" />
</head>
<body id="body_Main" style="margin: 0px; position: absolute;">
    <img src="" id="img_Map" />
    <div id="menuForPots" class="easyui-menu" style="width: 100px;">
        <div id="mnu_AddMapPort" name="mnu_AddMapPort" iconcls="icon-add">
            Add equipment</div>
    </div>
    <div id="editMapPortMemu" class="easyui-menu" style="width: 100px;">
        <div id="mnu_UpdateMapPort_Detail" name="mnu_UpdateMapPort_Detail" iconcls="icon-edit">
            Edit equipment</div>
        <div id="mnu_DeleMapPort_Detail" name="mnu_DeleMapPort_Detail" iconcls="icon-remove">
            Delete equipment</div>
        <div id="mnu_ViewMapPort_Detail" name="mnu_ViewMapPort_Detail">
            Equipment properties</div>
    </div>
    <div id="div_MapPotAdd" style="padding: 2px">
        <table>
            <tr>
                <td>
                    Area:
                </td>
                <td colspan="7">
                    <font style="color: Red; font-weight: bold"><span id="span_GroupName_Add" name="span_GroupName_Add">
                    </span></font>
                </td>
            </tr>
            <tr>
                <td>
                    Map:
                </td>
                <td colspan="7">
                    <font style="color: Red; font-weight: bold"><span id="span_MapNameForMapPort_Add"
                        name="span_MapNameForMapPort_Add"></span></font>
                </td>
            </tr>
            <tr>
                <td>
                    X:
                </td>
                <td>
                    <input type="text" id="txtMapPortXPos_Add" name="txtMapPortXPos_Add" style="width: 50px"
                        readonly />
                </td>
                <td>
                    Y:
                </td>
                <td>
                    <input type="text" id="txtMapPortYPos_Add" name="txtMapPortYPos_Add" style="width: 50px"
                        readonly />
                </td>
                <td  style="display: none">
                    Width:
                </td>
                <td  style="display: none" > 
                    <input type="text" id="txtMapPortWidth_Add" name="txtMapPortWidth_Add" style="width: 50px"
                        value="30" />
                </td>
                <td style="display: none" >
                    Height:
                </td>
                <td style="display: none" >
                    <input type="text" id="txtMapPortHeight_Add" name="txtMapPortHeight_Add" style="width: 50px"
                        value="40" />
                </td>
            </tr>
            <tr>
                <td>
                    Custom name:
                </td>
                <td colspan="7">
                    <input type="text" id="txtMapPortCustomizeName_Add" name="txtMapPortCustomizeName_Add"
                        style="width: 340px" />
                </td>
            </tr>
            <tr>
                <td>
                    Equipment:
                </td>
                <td colspan="7">
                    <div id="CGEquipmentForMapPort_Add" style="width: 340px">
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <font style="color: Blue; font-weight: bold"><span>Note: only choose to map local equipment, and a point of a device</span></font>
                </td>
            </tr>
        </table>
    </div>
    <div id="div_MapPotUpdate" style="padding: 2px">
        <table>
            <tr>
                <td>
                    Area:
                </td>
                <td colspan="7">
                    <font style="color: Red; font-weight: bold"><span id="span_GroupName_Update" name="span_GroupName_Update">
                    </span></font>
                    <input type="hidden" id="hid_MapPotIdForUpdate" name="hid_MapPotIdForUpdate" />
                </td>
            </tr>
            <tr>
                <td>
                    Map:
                </td>
                <td colspan="7">
                    <font style="color: Red; font-weight: bold"><span id="span_MapNameForMapPort_Update"
                        name="span_MapNameForMapPort_Update"></span></font>
                </td>
            </tr>
            <tr>
                <td>
                    X:
                </td>
                <td>
                    <input type="text" id="txtMapPortXPos_Update" name="txtMapPortXPos_Update" style="width: 50px;"
                        readonly />
                </td>
                <td>
                    Y:
                </td>
                <td>
                    <input type="text" id="txtMapPortYPos_Update" name="txtMapPortYPos_Update" style="width: 50px"
                        readonly />
                </td>
                <td style="display: none">
                    Width:
                </td>
                <td  style="display: none">
                    <input  type="text" id="txtMapPortWidth_Update" name="txtMapPortWidth_Update" style="width: 50px" />
                </td>
                <td  style="display: none">
                    Height:
                </td>
                <td style="display: none" >
                    <input  type="text" id="txtMapPortHeight_Update" name="txtMapPortHeight_Update" style="width: 50px" />
                </td>
            </tr>
            <tr>
                <td>
                    Custom name:
                </td>
                <td colspan="7">
                    <input type="text" id="txtMapPortCustomizeName_Update" name="txtMapPortCustomizeName_Update"
                        style="width: 340px" />
                </td>
            </tr>
            <tr>
                <td>
                    Equipment:
                </td>
                <td colspan="7">
                    <div id="CGEquipmentForMapPort_Update" style="width: 340px">
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="8">
                    <font style="color: Blue; font-weight: bold"><span>Note: only choose to map local equipment, and a point of a device</span></font>
                </td>
            </tr>
        </table>
    </div>
    <input type="hidden" id="hid_MapId" name="hid_MapId" runat="server" />
    <input type="hidden" id="hid_MapName" name="hid_MapName" runat="server" />
    <input type="hidden" id="hid_MapPath" name="hid_MapPath" runat="server" />
    <input type="hidden" id="hid_GroupName" name="hid_GroupName" runat="server" />
</body>
</html>
