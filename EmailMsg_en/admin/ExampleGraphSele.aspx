<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExampleGraphSele.aspx.cs"
    Inherits="admin_ExampleGraphSele" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select example graph</title>
    <link href="../Css/admin.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.4.min.js" type="text/javascript"></script>
    <style type="text/css">
        .style1
        {
            height: 32px;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            function confirmSele(ExampleGraphId, ExampleGraphName) {
                window.returnValue = '{"ExampleGraphId":"' + ExampleGraphId + '","ExampleGraphName":"' + ExampleGraphName + '"}';
                window.close();
            }

            var btnSele = $(".cls_btnSele");
            $.each(btnSele, function (i, item) {
                $(item).click(function () {
                    confirmSele($(item).attr("ExampleGraphId"), $(item).attr("ExampleGraphName"));
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td height="30" class="title_top" align="center">
                Example graph list
            </td>
        </tr>
    </table>
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" Width="100%" DataKeyNames="cId" CellPadding="4"
                    AutoGenerateColumns="False" BackColor="#77AEEE" BorderColor="#77AEEE" BorderStyle="Solid"
                    OnRowDataBound="GridView1_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="cId" HeaderText="ID"></asp:BoundField>
                        <asp:BoundField HeaderText="Example graph name" DataField="graphName" />
                        <asp:TemplateField HeaderText="Operate">
                            <ItemTemplate>
                                <input class="cls_btnSele" type="button" examplegraphid='<%#Eval("cId")%>' examplegraphname='<%#Eval("graphName")%>'
                                    value="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle HorizontalAlign="Center" BackColor="White" />
                    <HeaderStyle BackColor="#A5C8F0" Font-Size="13px" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td style="height: 26px;">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" HorizontalAlign="Center" OnPageChanged="AspNetPager1_PageChanged"
                    ShowCustomInfoSection="Left" Width="100%" meta:resourceKey="AspNetPager1" Style="font-size: 14px"
                    InputBoxStyle="width:19px" CustomInfoHTML="Total:<b><font color='red'>%RecordCount%</font></b> Current:<font color='red'><b>%CurrentPageIndex%/%PageCount%</b></font>   Order %StartRecordIndex%-%EndRecordIndex%"
                    AlwaysShow="True" FirstPageText="First" LastPageText="End" NextPageText="Next" PageSize="15"
                    PrevPageText="Pre" CustomInfoStyle="FONT-SIZE: 12px">
                </webdiyer:AspNetPager>
            </td>
        </tr>
    </table>
    <br />
    <br />
    </form>
</body>
</html>
