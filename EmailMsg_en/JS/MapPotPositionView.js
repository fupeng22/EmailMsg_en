function ResetAlarmToNormal(mapPotId) {
    //后台更改为已阅读
    $.ajax({
        type: "GET",
        url: "MapPotView.ashx?EquipmentId=" + encodeURI($("#hid_EquipmentId").val()),
        data: "",
        async: true,
        cache: false,
        beforeSend: function (XMLHttpRequest) {

        },
        success: function (msg) {
            var JSONMsg = eval("(" + msg + ")");
            if (JSONMsg.result.toLowerCase() == 'ok') {
                //复原图标为蓝色
                $("#imgAlarmPot_" + mapPotId).attr("class", "mp iconA");
                //并更新此提示信息内容
                $('#span_MapPotSet_' + mapPotId).tooltip({
                    content: function () {
                        var bOK = false;
                        var strRet = "";

                        $.ajax({
                            type: "GET",
                            url: "LoadMapPotProperty.ashx?MapPotId=" + encodeURI(this.id.replace("span_MapPotSet_", "")),
                            data: "",
                            async: false,
                            cache: false,
                            beforeSend: function (XMLHttpRequest) {

                            },
                            success: function (msg) {
                                var JSONmsg = eval("(" + msg + ")");
                                strRet = "<table><tr><td>" + JSONmsg[0].MapPotName.toString() + "</td></tr><tr><td>" + JSONmsg[0].EquipmentName + "</td></tr></table>";
                                bOK = true;
                            },
                            complete: function (XMLHttpRequest, textStatus) {

                            },
                            error: function () {

                            }
                        });
                        return strRet;
                    },
                    trackMouse: true,
                    onShow: function () {
                        var t = $(this);
                        t.tooltip('tip').unbind().bind('mouseenter', function () {
                            t.tooltip('show');
                        }).bind('mouseleave', function () {
                            t.tooltip('hide');
                        });
                    }
                });
                $.messager.alert("Infomation", JSONMsg.message, "info");
            } else {
                $.messager.alert("Infomation", JSONMsg.message, "error");
            }
        },
        complete: function (XMLHttpRequest, textStatus) {

        },
        error: function () {

        }
    });

}


$(function () {
    var MapAdd_dlg = null;
    var QueryAvialableEquipmentByMapIdURL = "";
    var imgs = ["iconA", "iconB", "iconC", "iconD", "iconE", "iconF", "iconG", "iconH", "iconI", "iconJ"];

    $("#img_Map").attr("src", $("#hid_MapPath").val());
    $("#body_Main").css("background", "url('" + $("#hid_MapPath").val() + "') no-repeat");

    setTimeout(function () {
        var width = $("#img_Map").css("width");
        var height = $("#img_Map").css("height");

        $("#img_Map").css("display", "none");
        $("#img_Map").remove();

        $("#body_Main").css("width", width);
        $("#body_Main").css("height", height);
        $("#body_Main").css("left", "0px");
        $("#body_Main").css("top", "0px");

        ReloadMapPortInfo();

        setTimeout(function () {
            location.href = "#span_MapPotSet_" + $("#hid_MapPotId").val();
        }, 400);

    }, 300);

    function ReloadMapPortInfo() {
        $("span[customize=1]").remove();
        $.ajax({
            type: "GET",
            url: "LoadMapPotDetail.ashx?MapId=" + encodeURI(encodeURI($("#hid_MapId").val())),
            data: "",
            async: true,
            cache: false,
            beforeSend: function (XMLHttpRequest) {

            },
            success: function (msg) {
                var iCurr = 0;
                var JSONMsg = eval("(" + msg + ")");
                if (JSONMsg.result.toLowerCase() == 'ok') {
                    var mapPotsInfo = JSONMsg.data;
                    if (mapPotsInfo.length > 0) {
                        for (var i = 0; i < mapPotsInfo.length; i++) {
                            //$("#body_Main").append("<span name=span_MapPotSet_" + mapPotsInfo[i].id + " thisId=" + mapPotsInfo[i].Id + " customize='1' id='span_MapPotSet_" + mapPotsInfo[i].Id + "' style='position:absolute;left:" + mapPotsInfo[i].posX + "px;top:" + mapPotsInfo[i].posY + "px;border:1px solid #ccc;width:60px;height:80px;background-color: Red;'>" + mapPotsInfo[i].MapPotName + "</br><input type='checkbox' curId=" + mapPotsInfo[i].Id + " id='chk_mapPortCurSele" + mapPotsInfo[i].Id + "' MapId=" + mapPotsInfo[i].MapId + " EquipmentId=" + mapPotsInfo[i].EquipmentId + " MapPotName='" + mapPotsInfo[i].MapPotName + "' posX=" + mapPotsInfo[i].posX + " posY='" + mapPotsInfo[i].posY + "' /></span>");
                            //$("#body_Main").append("<span name=span_MapPotSet_" + mapPotsInfo[i].id + " thisId=" + mapPotsInfo[i].Id + " customize='1' id='span_MapPotSet_" + mapPotsInfo[i].Id + "' style='position:absolute;left:" + mapPotsInfo[i].posX + "px;top:" + mapPotsInfo[i].posY + "px;border:1px solid #ccc;width:60px;height:80px;background-color: Red;'>" + mapPotsInfo[i].MapPotName + "</br><input type='checkbox' curId=" + mapPotsInfo[i].Id + " id='chk_mapPortCurSele" + mapPotsInfo[i].Id + "' MapId=" + mapPotsInfo[i].MapId + " EquipmentId=" + mapPotsInfo[i].EquipmentId + " MapPotName='" + mapPotsInfo[i].MapPotName + "' posX=" + mapPotsInfo[i].posX + " posY='" + mapPotsInfo[i].posY + "' Width='" + mapPotsInfo[i].Width + "' Height='" + mapPotsInfo[i].Height + "' /><br/>" + mapPotsInfo[i].EquipmentName + "</span>");
                            if ($("#hid_MapPotId").val() == mapPotsInfo[i].Id) {
                                $("#body_Main").append("<span  name=span_MapPotSet_" + mapPotsInfo[i].Id + " thisId=" + mapPotsInfo[i].Id + " customize='1' id='span_MapPotSet_" + mapPotsInfo[i].Id + "' style='position:absolute;text-align:center;left:" + mapPotsInfo[i].posX + "px;top:" + mapPotsInfo[i].posY + "px;'>" + "<img  class='mpCur iconMpCur'   id='imgAlarmPot_" + mapPotsInfo[i].Id + "'  src='imgs/transparent.png' />" + "</br><input type='checkbox' curId=" + mapPotsInfo[i].Id + " id='chk_mapPortCurSele" + mapPotsInfo[i].Id + "' MapId=" + mapPotsInfo[i].MapId + " EquipmentId=" + mapPotsInfo[i].EquipmentId + " MapPotName='" + mapPotsInfo[i].MapPotName + "' posX=" + mapPotsInfo[i].posX + " posY='" + mapPotsInfo[i].posY + "' Width='" + mapPotsInfo[i].Width + "' Height='" + mapPotsInfo[i].Height + "' /><br/><span style='color:Red; font-weight:bold' id='span_Display" + mapPotsInfo[i].Id + "'>" + "" + "</span></span>");
                            } else {
                                $("#body_Main").append("<span  name=span_MapPotSet_" + mapPotsInfo[i].Id + " thisId=" + mapPotsInfo[i].Id + " customize='1' id='span_MapPotSet_" + mapPotsInfo[i].Id + "' style='position:absolute;text-align:center;left:" + mapPotsInfo[i].posX + "px;top:" + mapPotsInfo[i].posY + "px;'>" + "<img  class='mp " + imgs[iCurr] + "'  id='imgAlarmPot_" + mapPotsInfo[i].Id + "' src='imgs/transparent.png' />" + "</br><input type='checkbox' curId=" + mapPotsInfo[i].Id + " id='chk_mapPortCurSele" + mapPotsInfo[i].Id + "' MapId=" + mapPotsInfo[i].MapId + " EquipmentId=" + mapPotsInfo[i].EquipmentId + " MapPotName='" + mapPotsInfo[i].MapPotName + "' posX=" + mapPotsInfo[i].posX + " posY='" + mapPotsInfo[i].posY + "' Width='" + mapPotsInfo[i].Width + "' Height='" + mapPotsInfo[i].Height + "' /><br/><span style='color:blue; font-weight:bold' id='span_Display" + mapPotsInfo[i].Id + "'>" + "" + "</span></span>");
                            }
                            $('#span_MapPotSet_' + mapPotsInfo[i].Id).bind('click', function (e) {
                                var currSeleMapPot = e.target.id.replace("span_MapPotSet_", "chk_mapPortCurSele");
                                var allMapPotsChk = $("input[curId]");
                                $.each(allMapPotsChk, function (i, item) {
                                    var thisId = $(item).attr("id");
                                    if (currSeleMapPot == thisId) {
                                        $("#" + thisId).attr("checked", true);
                                    } else {
                                        $("#" + thisId).attr("checked", false);
                                    }
                                });
                            }).bind('contextmenu', function (e) {
                                e.preventDefault();
                                e.stopPropagation();
                                //                                var currSeleMapPot = e.currentTarget.id.replace("span_MapPotSet_", "chk_mapPortCurSele");
                                //                                var allMapPotsChk = $("input[curId]");
                                //                                $.each(allMapPotsChk, function (i, item) {
                                //                                    var thisId = $(item).attr("id");
                                //                                    if (currSeleMapPot == thisId) {
                                //                                        $("#" + thisId).attr("checked", true);
                                //                                    } else {
                                //                                        $("#" + thisId).attr("checked", false);
                                //                                    }
                                //                                });

                                //                                $('#editMapPortMemu').menu('show', {
                                //                                    left: e.pageX,
                                //                                    top: e.pageY
                                //                                });
                            }).tooltip({
                                content: function () {
                                    var bOK = false;
                                    var strRet = "";

                                    if ($("#hid_MapPotId").val() == this.id.replace("span_MapPotSet_", "")) {//当前为报警点
                                        var tmpMapPotId = this.id.replace("span_MapPotSet_", "");
                                        $.ajax({
                                            type: "GET",
                                            url: "LoadMapPotProperty.ashx?MapPotId=" + encodeURI(tmpMapPotId),
                                            data: "",
                                            async: false,
                                            cache: false,
                                            beforeSend: function (XMLHttpRequest) {

                                            },
                                            success: function (msg) {
                                                var JSONmsg = eval("(" + msg + ")");
   
                                                $.ajax({
                                                    type: "GET",
                                                    url: "LoadMapPotProperty.ashx?MapPotId=" + tmpMapPotId,
                                                    data: "",
                                                    async: false,
                                                    cache: false,
                                                    beforeSend: function (XMLHttpRequest) {

                                                    },
                                                    success: function (msg) {
                                                        var JSONmsg = eval("(" + msg + ")");
                                                        strRet = "<table>" + "<tr><td><input type='button' onclick='javascript:ResetAlarmToNormal(" + JSONmsg[0].Id + ")" + "' value='报警复位'/></td></tr>"
                                                        strRet = strRet + "<tr><td>" + JSONmsg[0].MapPotName.toString() + "</td></tr><tr><td>" + JSONmsg[0].EquipmentName + "</td></tr></table>";
                                                        bOK = true;
                                                    },
                                                    complete: function (XMLHttpRequest, textStatus) {

                                                    },
                                                    error: function () {

                                                    }
                                                });

                                                //console.info(JSONmsg[0].MapPotName + "---" + JSONmsg[0].EquipmentName);
                                                //strRet = "<table><tr><td>" + JSONmsg[0].MapPotName.toString() + "</td></tr><tr><td>" + JSONmsg[0].EquipmentName + "</td></tr></table>";
                                                //console.info(strRet);
                                                //bOK = true;
                                            },
                                            complete: function (XMLHttpRequest, textStatus) {

                                            },
                                            error: function () {

                                            }
                                        });
                                    } else {
                                        $.ajax({
                                            type: "GET",
                                            url: "LoadMapPotProperty.ashx?MapPotId=" + encodeURI(this.id.replace("span_MapPotSet_", "")),
                                            data: "",
                                            async: false,
                                            cache: false,
                                            beforeSend: function (XMLHttpRequest) {

                                            },
                                            success: function (msg) {
                                                var JSONmsg = eval("(" + msg + ")");
                                                //console.info(JSONmsg[0].MapPotName + "---" + JSONmsg[0].EquipmentName);
                                                strRet = "<table><tr><td>" + JSONmsg[0].MapPotName.toString() + "</td></tr><tr><td>" + JSONmsg[0].EquipmentName + "</td></tr></table>";
                                                //console.info(strRet);
                                                bOK = true;
                                            },
                                            complete: function (XMLHttpRequest, textStatus) {

                                            },
                                            error: function () {

                                            }
                                        });
                                    }

                                    return strRet;
                                },
                                trackMouse: true,
                                onShow: function () {
                                    var t = $(this);
                                    t.tooltip('tip').unbind().bind('mouseenter', function () {
                                        t.tooltip('show');
                                    }).bind('mouseleave', function () {
                                        t.tooltip('hide');
                                    });
                                }
                            });

                            iCurr = iCurr + 1;
                            if (iCurr == imgs.length) {
                                iCurr = 0;
                            }
                        }
                    }
                } else {
                    $.messager.alert("Infomation", JSONMsg.message, "error");
                }
            },
            complete: function (XMLHttpRequest, textStatus) {

            },
            error: function () {

            }
        });
    }

    //    function ReloadMapPortInfo() {
    //        $("span[customize=1]").remove();
    //        $.ajax({
    //            type: "GET",
    //            url: "LoadMapPotDetail.ashx?MapId=" + encodeURI(encodeURI($("#hid_MapId").val())),
    //            data: "",
    //            async: true,
    //            cache: false,
    //            beforeSend: function (XMLHttpRequest) {

    //            },
    //            success: function (msg) {
    //                var JSONMsg = eval("(" + msg + ")");
    //                if (JSONMsg.result.toLowerCase() == 'ok') {
    //                    var mapPotsInfo = JSONMsg.data;
    //                    if (mapPotsInfo.length > 0) {
    //                        for (var i = 0; i < mapPotsInfo.length; i++) {
    //                            //$("#body_Main").append("<span name=span_MapPotSet_" + mapPotsInfo[i].id + " thisId=" + mapPotsInfo[i].Id + " customize='1' id='span_MapPotSet_" + mapPotsInfo[i].Id + "' style='position:absolute;left:" + mapPotsInfo[i].posX + "px;top:" + mapPotsInfo[i].posY + "px;border:1px solid #ccc;width:60px;height:80px;background-color: Red;'>" + mapPotsInfo[i].MapPotName + "</br><input type='checkbox' curId=" + mapPotsInfo[i].Id + " id='chk_mapPortCurSele" + mapPotsInfo[i].Id + "' MapId=" + mapPotsInfo[i].MapId + " EquipmentId=" + mapPotsInfo[i].EquipmentId + " MapPotName='" + mapPotsInfo[i].MapPotName + "' posX=" + mapPotsInfo[i].posX + " posY='" + mapPotsInfo[i].posY + "' /></span>");
    //                            $("#body_Main").append("<span name=span_MapPotSet_" + mapPotsInfo[i].id + " thisId=" + mapPotsInfo[i].Id + " customize='1' id='span_MapPotSet_" + mapPotsInfo[i].Id + "' style='position:absolute;left:" + mapPotsInfo[i].posX + "px;top:" + mapPotsInfo[i].posY + "px;border:1px solid #ccc;width:60px;height:80px;background-color: Red;'>" + mapPotsInfo[i].MapPotName + "</br><input type='checkbox' curId=" + mapPotsInfo[i].Id + " id='chk_mapPortCurSele" + mapPotsInfo[i].Id + "' MapId=" + mapPotsInfo[i].MapId + " EquipmentId=" + mapPotsInfo[i].EquipmentId + " MapPotName='" + mapPotsInfo[i].MapPotName + "' posX=" + mapPotsInfo[i].posX + " posY='" + mapPotsInfo[i].posY + "' Width='" + mapPotsInfo[i].Width + "' Height='" + mapPotsInfo[i].Height + "' /><br/>" + mapPotsInfo[i].EquipmentName + "</span>");
    //                            $('#span_MapPotSet_' + mapPotsInfo[i].Id).bind('click', function (e) {
    //                                var currSeleMapPot = e.target.id.replace("span_MapPotSet_", "chk_mapPortCurSele");
    //                                var allMapPotsChk = $("input[curId]");
    //                                $.each(allMapPotsChk, function (i, item) {
    //                                    var thisId = $(item).attr("id");
    //                                    if (currSeleMapPot == thisId) {
    //                                        $("#" + thisId).attr("checked", true);
    //                                    } else {
    //                                        $("#" + thisId).attr("checked", false);
    //                                    }
    //                                });
    //                            }).bind('contextmenu', function (e) {
    //                                e.preventDefault();
    //                                e.stopPropagation();
    //                                var currSeleMapPot = e.target.id.replace("span_MapPotSet_", "chk_mapPortCurSele");
    //                                var allMapPotsChk = $("input[curId]");
    //                                $.each(allMapPotsChk, function (i, item) {
    //                                    var thisId = $(item).attr("id");
    //                                    if (currSeleMapPot == thisId) {
    //                                        $("#" + thisId).attr("checked", true);
    //                                    } else {
    //                                        $("#" + thisId).attr("checked", false);
    //                                    }
    //                                });

    //                                $('#editMapPortMemu').menu('show', {
    //                                    left: e.pageX,
    //                                    top: e.pageY
    //                                });
    //                            });
    //                        }
    //                    }
    //                } else {
    //                    $.messager.alert("提示信息", JSONMsg.message, "error");
    //                }
    //            },
    //            complete: function (XMLHttpRequest, textStatus) {

    //            },
    //            error: function () {

    //            }
    //        });
    //    }

});