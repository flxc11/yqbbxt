<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyDetail.aspx.cs" Inherits="CNVP.WebSite.user.ApplyDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=CNVP.Config.UIConfig.SoftName %></title>
    <link rel="stylesheet" href="/css/Global.css" />
    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/themes/default/easyui.css" />
    <link rel="stylesheet" href="/themes/icon.css" />
    <script src="/js/jquery.js"></script>
    <script src="/js/jquery.easyui.min.js"></script>
    <script src="/js/easyui-lang-zh_CN.js"></script>
    <script src="/js/cnvp.js"></script>
</head>
<body>
    <form id="ff" name="ff" action="?Action=EditApply" runat="server" enctype="multipart/form-data">
    <div class="wrap-header">
    	<div class="header">
    		<div class="lg-info">
    			<h2>您好!欢迎使用本系统</h2>
    			<a href="#">
    				<span class="manager"><%=UserLoginInfo.UserLoginName %></span>
    			</a>
    			<a href="login.aspx">
    				<span class="lg-out">退 出</span>
    			</a>
    		</div>
    	</div>
    </div>
    <div class="main-l">
		<!--#include file="/control/userleft.html" -->
	</div>
	<div class="main-r">
		<div class="mainScroll">
			<div class="position">
				当前位置：<a href="#">申报管理</a> > 编辑申报单
			</div>
			<div class="main-form">
				<div class="table-type">
					<a href="javascript:;" class="index_tabshover">船舶载运固体散装货物申报单</a>
					<a href="solidbulk.aspx" target="_blank">打印固体散装货物申报单</a>
				</div>
                <div class="cnvp-tab-panle">
                    <div class="table-1">
                        <div class="control-group">
                            <input type="hidden" name="applyId" value="<%=applyId %>" />
                            <input type="hidden" name="scwId" value="<%=scwId %>" />
                            <input type="hidden" name="applyGuid" value="<%=applyGuid %>" />
                            <label for="in-out" class="control-label">出&nbsp;&nbsp;入&nbsp;&nbsp;港：</label>
                            <div class="controls controls-inline"><%=strIO %></div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">船　　名：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="ShipName" runat="server" Text="Label"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label">航　　次：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Saillings" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">国　　籍：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Nationality" runat="server" Text="Label"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label">经 营 人：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Operator" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">始 发 港：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="StartPort" runat="server" Text="Label"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label">抵港时间：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="ArrivedTime" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">作业泊位：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="WorkBerth" runat="server" Text="Label"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label">作业时间：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="WorkTime" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div>
                        <table width="100%" border="0" cellspacing="1" cellpadding="0" id="BulkFreight">
                          <tr id="Bf-ftr">
                            <td width="16%" height="40">散装货物运输名称</td>
                            <td width="12%">组别</td>
                            <td width="12%">类别</td>
                            <td width="12%">危规编号</td>
                            <td width="12%">总重量</td>
                            <td width="12%">卸货港</td>
                            <td width="12%">装载位置</td>
                            <td width="12%">备注</td>
                          </tr>
                            <asp:Repeater ID="rptBulk" runat="server">
                                <ItemTemplate>
                                    <tr class="bulkfright">
                                        <td height="40" align="center" valign="middle"><%#Eval("BfGoodsName")%></td>
                                        <td><%#Eval("BfGoodsGroup")%></td>
                                        <td><%#Eval("Class")%></td>
                                        <td><%#Eval("DangerousNo")%></td>
                                        <td><%#Eval("BfTotalWeight")%></td>
                                        <td><%#Eval("DischargingPort")%></td>
                                        <td><%#Eval("Position")%></td>
                                        <td><%#Eval("Remark")%></td>
                                      </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </div>
                    <div class="table-1">
                        <div class="control-group">
                            <label for="in-out" class="control-label">申 报 员：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Declarer" runat="server" Text="Label"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label">申报员证书编号：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="DecCertificateNo" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">船方：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Ship" runat="server" Text="Label"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label">手机：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Telphone" runat="server" Text="Label"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group" style="text-align:left;padding-left:79px;">
                            附件：
                            1、<a href="<%=mfile0_0 %>" target="_blank">适航证书</a>&nbsp;&nbsp;
                            2、<a href="<%=mfile0_1 %>" target="_blank">船舶证书</a>&nbsp;&nbsp;
                            3、<a href="<%=mfile0_2 %>" target="_blank">配载图</a>&nbsp;&nbsp;
                            4、<a href="<%=mfile0_3 %>" target="_blank">进/出港申报委托书</a>&nbsp;&nbsp;
                            5、<a href="<%=mfile0_4 %>" target="_blank">保险证书类型</a>
                        </div>
                    </div>
                    
                </div>
                <div class="table-type">
					<a href="javascript:;" class="index_tabshover">安全适运申报单</a>
					<a href="javascript:;">打印安全适运申报单</a>
				</div>
                <div class="cnvp-tab-panle">
                    <div class="table-1 scf">
                        <div class="control-group">
                            <label for="in-out" class="control-label2">散装货物运输名称：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="GoodsName" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">托运人：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Shipper" runat="server"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label2">运输单证编号：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="TransportDocNo" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">收货人：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Consignee" runat="server"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label2">承运人：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Carrier" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">运输工具的名称/方式：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="TransPort" runat="server"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label2">指南或其他事项：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Guide" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">出发港口/地点：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="HomePort" runat="server"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label2">目的港口/地点：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="DestinationPort" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">货物一般性的描述：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Description" runat="server"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label2">总重：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="TotalWeight" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">货物组别：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="GoodsGroup" runat="server"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label2">适运水分极限：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="MoistureLimit" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">货物相关特殊性质：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="ParticularNature" runat="server"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label2">额外证书：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="ExatrCertificate" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">额外证书其他说明：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="ExatrCertificateDec" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="control-group">
                    <a href="javascript:void(0)" class="btn-submit" onclick="javascript:history.go(-1)">返　　回</a>
                </div>
			</div>
		</div>
	</div>
    
    </form>
</body>
<script>
    $(function() {
        if ($("input[type='radio'][name='IO']:checked").val() == "1") {
            $("#scf-a").css("display", "inline-block");
            $('.scf input.easyui-validatebox').validatebox('enableValidation');  //激活安全适运申报单验证
        }
        $(".del-img").on("click", function() {
            $(this).parents("div.control-group")
            .find("div.clear1").remove();
            $(this).parents("div.control-group")
            .find('input.easyui-validatebox').validatebox('enableValidation');
        })
    })
    $.extend($.fn.validatebox.defaults.rules, {
        Character: {
            validator: function (value) {
                    return !/\,/i.test(value);
                },
                message: '内容中不能包含逗号'
        }
    })
    function submitForm(){
        var rslt1 = /^\s*$/.test($("#Declarer").val());
        var rslt2 = /^\s*$/.test($("#Ship").val());
        if( rslt1 && rslt2 ) {
            alert("申报员或船方至少需要填一项");
            $("#Declarer").focus();
            return false;
        } else if (!rslt1) {
            if(/^\s*$/.test($("#DecCertificateNo").val())) {
                alert("申报员证书编号不能为空");
                $("#DecCertificateNo").focus();
                return false;
            }
        } else if (!rslt2) {
            if(/^\s*$/.test($("#Telphone").val())) {
                alert("手机号码不能为空");
                $("#Telphone").focus();
                return false;
            }
        }
        if ($("#ff").form("validate")) {
            function doSubmit() {
                $("#ff").attr("action", "ApplyDetail.aspx?Action=EditApply");
                $("#ff").submit();
            }
            setTimeout(doSubmit,0);
        } else {
           $.messager.alert("信息","输入不合法，请检查后再提交！");
        }
    }
</script>
</html>