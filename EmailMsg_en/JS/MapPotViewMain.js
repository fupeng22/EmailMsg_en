$(function () {
    var GetAllMapInfoURL = "MapMain.ashx?type=2";

    var LoadDefaulMapSeleURL = "MapPotViewMain.ashx?type=1";
    var AddDefaultSeleMapURL = "MapPotViewMain.ashx?type=2&defaultMapSele=";

    $('#ddlMapSele').combogrid({
        panelWidth: 400,
        idField: 'Id',
        textField: 'MapDes',
        url: GetAllMapInfoURL,
        editable: false,
        mode: "remote",
        //multiple:true,
        pagination: false,
        columns: [[
					{ field: 'Id', title: 'ID', width: 40 },
                    { field: 'MapDes', title: 'Map', width: 320 }
				]],
        onSelect: function (rowIndex, rowData) {
            //console.info(rowData);
            $.ajax({
                type: "GET",
                url: AddDefaultSeleMapURL+encodeURI(rowData.Id),
                data: "",
                async: true,
                cache: false,
                beforeSend: function (XMLHttpRequest) {

                },
                success: function (msg) {
                    
                },
                complete: function (XMLHttpRequest, textStatus) {

                },
                error: function () {

                }
            });
            $("#iframeMapPotView").attr("src", "MapPotView.aspx?MapId=" + encodeURI(rowData.Id));
        },
        onLoadSuccess: function (data) {
            $.ajax({
                type: "GET",
                url: LoadDefaulMapSeleURL,
                data: "",
                async: true,
                cache: false,
                beforeSend: function (XMLHttpRequest) {

                },
                success: function (msg) {
                    $('#ddlMapSele').combogrid('setValue', msg);
                    $("#iframeMapPotView").attr("src", "MapPotView.aspx?MapId=" + encodeURI(msg));
                },
                complete: function (XMLHttpRequest, textStatus) {

                },
                error: function () {

                }
            });
        }
    });
});