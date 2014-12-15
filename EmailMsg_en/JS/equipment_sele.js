$(function () {
    var _$_TVGroup = $("#TVGroup");
    var QueryGroupURL = "equipment_sele.ashx?state=open";
    _$_TVGroup.tree({
        url: QueryGroupURL,
        onClick: function (node) {
            if (node.attributes) {
                var EquipmentId = node.attributes.EquipmentId; // node.id.replace("Equipment_", "");
                var EquipmentName = node.attributes.EquipmentName; // node.text.replace("[<font style='color:red;font-weight:bold'>设备</font>]", "");
                window.returnValue = '{"EquipmentId":"' + EquipmentId + '","EquipmentName":"' + EquipmentName + '"}';
                window.close();
            }
          
        }
    });
})