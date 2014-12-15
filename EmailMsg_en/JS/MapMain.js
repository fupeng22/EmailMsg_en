$(function () {
    var _$_TVGroup = $("#TVGroup");
    var _$_datagrid = $("#DG_MapInfo");
    var QueryGroupURL = "MapMain.ashx?type=0";

    var MapAdd_dlg = null;
    //返回所选区域ID
    function getGroupSele() {
        return (_$_TVGroup.tree("getSelected") ? _$_TVGroup.tree("getSelected").id.substring(4) : -1);
    }

    function getMapSele() {
        var obj = [4];
        obj[0] = -1;
        obj[1] = -1;
        obj[2] = "";
        obj[3] = "";
        var sele = _$_datagrid.datagrid("getSelected");
        if (sele) {
            obj[0] = sele.GroupId;
            obj[1] = sele.Id;
            obj[2] = sele.MapName;
            obj[3] = sele.MapPath;
        }
        return obj;
    }

    _$_TVGroup.tree({
        url: QueryGroupURL,
        onClick: function (node) {
            $("#span_AreaName").html(node.text);
            QueryURL = "MapMain.ashx?type=1&GroupId=" + node.id.substring(4);
            window.setTimeout(function () {
                $.extend(_$_datagrid.datagrid("options"), {
                    url: QueryURL
                });
                _$_datagrid.datagrid("reload");
            }, 100); //延迟100毫秒执行，时间可以更短
        }
    });

    var QueryURL = "MapMain.ashx?type=1&GroupId=" + getGroupSele();

    _$_datagrid.datagrid({
        iconCls: 'icon-save',
        nowrap: true,
        autoRowHeight: false,
        autoRowWidth: false,
        striped: true,
        collapsible: true,
        url: QueryURL,
        sortName: 'MapName',
        sortOrder: 'desc',
        remoteSort: true,
        singleSelect: true,
        border: false,
        idField: 'Id',
        columns: [[
					{ field: 'MapName', title: 'Map name', width: 90, sortable: true,
					    sorter: function (a, b) {
					        return (a > b ? 1 : -1);
					    }
					},
                    { field: 'GroupName', title: 'Area', width: 80, sortable: true,
                        sorter: function (a, b) {
                            return (a > b ? 1 : -1);
                        }
                    }
				]],
        pagination: false,
        pageList: [15, 20, 25, 30, 35, 40, 45, 50],
        onSortColumn: function (sort, order) {
            //_$_datagrid.datagrid("reload");
        },
        onClickRow: function (rowIndex, rowData) {
            $("#iframeMapView").attr("src", "MapView.aspx?MapId=" + encodeURI(rowData.Id) + "&MapName=" + encodeURI(rowData.MapName) + "&GroupName=" + encodeURI(_$_TVGroup.tree("getSelected").text) + "&MapPath=" + encodeURI(rowData.MapPath));
            $("#span_Area_Detail").html(rowData.GroupName);
            $("#span_MapName").html(rowData.MapName);
        }
    });

    $("#btnAddMap").click(function () {
        var GroupIdSele = getGroupSele();

        if (GroupIdSele == -1) {
            $.messager.alert("Infomation", "Select a map area", "error");
            return false;
        }

        $("#txtMapName_Add").val("");
        $("#mapFile_Add").val("");

        $("#hid_AreaId_MapAdd").val(GroupIdSele);
        $("#span_AreaName_MapAdd").html((_$_TVGroup.tree("getSelected") ? _$_TVGroup.tree("getSelected").text : ""));

        MapAdd_dlg = $('#div_MapAdd').dialog({
            buttons: [{
                text: 'Save',
                iconCls: 'icon-ok',
                handler: function () {
                    $('#form_MapAdd').form('submit', {
                        url: "MapAdd.ashx",
                        onSubmit: function () {
                            if ($("#txtMapName_Add").val() == "" || $("#mapFile_Add").val() == "") {
                                $.messager.alert("Infomation", "Please fill in the complete information (names of maps, map file)", "error");
                                return false;
                            }
                            var win = $.messager.progress({
                                title: 'Wait',
                                msg: 'Processing……'
                            });
                        },
                        success: function (data) {
                            $.messager.progress('close');
                            var msg = eval("(" + data + ")");
                            if (msg.result == "ok") {
                                _$_datagrid.datagrid("reload");
                                MapAdd_dlg.dialog("close");
                                $.messager.alert("Infomation", msg.message, "info");
                            } else {
                                $.messager.alert("Infomation", msg.message, "error");
                                return false;
                            }

                        }
                    });
                }
            }, {
                text: 'Close',
                iconCls: 'icon-cancel',
                handler: function () {
                    MapAdd_dlg.dialog('close');
                }
            }],
            title: 'Add map',
            modal: true,
            resizable: true,
            cache: false,
            closed: true,
            width: 500,
            height: 150
        });

        $('#div_MapAdd').dialog("open");
    });

    $("#btnUpdateMap").click(function () {
        var GroupIdSele = getGroupSele();
        if (GroupIdSele == -1) {
            $.messager.alert("Infomation", "Select a map area", "error");
            return false;
        }

        //获取所选择的的地图
        var obj = getMapSele();
        if (obj[1] == -1) {
            $.messager.alert("Infomation", "Select a map", "error");
            return false;
        }

        $("#mapFilePath_Old").val("");
        $("#txtMapName_Update").val("")
        $("#mapFile_Update").val("");

        $("#hid_AreaId_MapUpdate").val(GroupIdSele);
        $("#span_AreaName_MapUpdate").html((_$_TVGroup.tree("getSelected") ? _$_TVGroup.tree("getSelected").text : ""));


        $("#hid_MapId_MapUpdate").val(obj[1]);
        $("#txtMapName_Update").val(obj[2]);
        $("#mapFilePath_Old").val(obj[3]);

        MapAdd_dlg = $('#div_MapUpdate').dialog({
            buttons: [{
                text: 'Save',
                iconCls: 'icon-ok',
                handler: function () {
                    $('#form_MapUpdate').form('submit', {
                        url: "MapUpdate.ashx",
                        onSubmit: function () {
                            if ($("#txtMapName_Update").val() == "" || ($("#mapFilePath_Old").val() == "" && $("#mapFile_Update").val() == "")) {
                                $.messager.alert("Infomation", "Please fill in the complete information (names of maps, map file)", "error");
                                return false;
                            }
                            var win = $.messager.progress({
                                title: 'Wait',
                                msg: 'Processing……'
                            });
                        },
                        success: function (data) {
                            $.messager.progress('close');
                            var msg = eval("(" + data + ")");
                            if (msg.result == "ok") {
                                _$_datagrid.datagrid("reload");
                                MapAdd_dlg.dialog("close");
                                $.messager.alert("Infomation", msg.message, "info");
                            } else {
                                $.messager.alert("Infomation", msg.message, "error");
                                return false;
                            }

                        }
                    });
                }
            }, {
                text: 'Close',
                iconCls: 'icon-cancel',
                handler: function () {
                    MapAdd_dlg.dialog('close');
                }
            }],
            title: 'Edit Map',
            modal: true,
            resizable: true,
            cache: false,
            closed: true,
            width: 600,
            height: 230
        });

        $('#div_MapUpdate').dialog("open");
    });

    $("#btnClearNewMapFile").click(function () {
        $("#mapFile_Update").val("");
    });

    $("#btnDeleteMap").click(function () {
        var GroupIdSele = getGroupSele();
        if (GroupIdSele == -1) {
            $.messager.alert("Infomation", "Select a map area", "error");
            return false;
        }

        //获取所选择的的地图
        var obj = getMapSele();
        if (obj[1] == -1) {
            $.messager.alert("Infomation", "Select a map", "error");
            return false;
        }

        $.ajax({
            type: "POST",
            url: "MapDele.ashx?Id=" + encodeURI(obj[1]),
            data: "",
            async: true,
            cache: false,
            beforeSend: function (XMLHttpRequest) {

            },
            success: function (msg) {
                var JSONMsg = eval("(" + msg + ")");
                if (JSONMsg.result.toLowerCase() == 'ok') {
                    $.messager.alert('Infomation', JSONMsg.message, 'info');
                    _$_datagrid.datagrid("reload");
                } else {
                    $.messager.alert("Infomation", JSONMsg.message, "error");
                }
            },
            complete: function (XMLHttpRequest, textStatus) {

            },
            error: function () {

            }
        });
    });

//    $("#btnddd").click(function () {
//        $.ajax({
//            type: "GET",
//            url: "http://api.map.baidu.com/geodata/v3/geotable/list?ak=gxF36PjOj7CqjGFijqbrq610",
//            data: "",
//            async: true,
//            cache: false,
//            dataType: "jsonp",
//            beforeSend: function (XMLHttpRequest) {

//            },
//            success: function (data) {
//                console.info(data);
//                /*                 eval("data=" + data);*/
//                var text = "执行状态:" + data.status + "<br/>";
//                text += "结果：" + data.message + "<br/>";
//                var tables = data.geotables;
//                text += "您在LBS云建立了" + data.size + "张表<br/>";
//                $("#showContainer").html(text);

//                var tablesHTML = "<tr><td>id</td><td>表名</td><td>数据类型</td><td>修改时间</td><td>创建时间</td><td>是否发布到检索</td></tr>";
//                for (var i = 0; i < tables.length; i++) {
//                    var leixing = tables[i].geotype;
//                    if (leixing == 1) {
//                        leixing = "点";
//                    } else if (leixing == 2) {
//                        leixing = "线";
//                    } else {
//                        leixing = "面";
//                    }
//                    tablesHTML += "<tr><td>" + tables[i].id + "</td><td>" + tables[i].name + "</td><td>" + leixing + "</td><td>" + tables[i].create_time + "</td><td>" + tables[i].modify_time + "</td><td>" + (tables[i].is_published == 1 ? "是" : "否") + "</td></tr>";
//                }
//                $("#tablesDetail").html(tablesHTML);
//            },
//            complete: function (XMLHttpRequest, textStatus) {

//            },
//            error: function () {

//            }
//        });
//    });
});