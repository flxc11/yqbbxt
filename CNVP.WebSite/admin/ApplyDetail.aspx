<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyDetail.aspx.cs" Inherits="CNVP.WebSite.admin.ApplyDetail" %>

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
    <form id="ff" name="ff" action="?Action=EditState" method="post" runat="server">
    <div class="wrap-header">
    	<div class="header">
    		<div class="lg-info">
    			<h2>您好!欢迎使用本系统</h2>
    			<a href="#">
    				<span class="manager"><%=LoginInfo.LoginName %></span>
    			</a>
    			<a href="login.aspx">
    				<span class="lg-out">退 出</span>
    			</a>
    		</div>
    	</div>
    </div>
    <div class="main-l">
		<!--#include file="/control/adminleft.html" -->
	</div>
	<div class="main-r">
		<div class="mainScroll">
			<div class="position">
				当前位置：<a href="#">申报管理</a> > 编辑申报单
			</div>
			<div class="main-form">
				<div class="table-type">
					<a href="javascript:;" class="index_tabshover">船舶载运固体散装货物申报单</a>
				</div>
                <div class="cnvp-tab-panle">
                    <div class="table-1">
                        <div class="control-group">
                            <input type="hidden" name="applyGuid" value="<%=applyGuid %>" />
                            <input type="hidden" name="applyState" value="<%=_appState %>" />
                            <input type="hidden" name="appPage" value="<%=appPage %>" />
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
                                <asp:Label ID="Declarer" runat="server" Text="&nbsp;"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label">申报员证书编号：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="DecCertificateNo" runat="server" Text="&nbsp;"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">船方：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Ship" runat="server" Text="&nbsp;"></asp:Label>
                            </div>
                            <label for="in-out" class="control-label">手机：</label>
                            <div class="controls controls-inline">
                                <asp:Label ID="Telphone" runat="server" Text="&nbsp;"></asp:Label>
                            </div>
                        </div>
                        <div class="control-group" style="text-align:left;padding-left:79px;">
                            附件：
                            1、<a href="<%=mfile0_0 %>" target="_blank">适航证书</a>&nbsp;&nbsp;
                            2、<a href="<%=mfile0_1 %>" target="_blank">船舶证书</a>&nbsp;&nbsp;
                            3、<a href="<%=mfile0_2 %>" target="_blank">配载图</a>&nbsp;&nbsp;
                            <%=mfile0_3 %>
                            <%=mfile0_4 %>
                            6、<a href="/user/other.aspx?AppGuid=<%=applyGuid %>&imgtype=1" target="_blank">其它</a>
                        </div>
                    </div>
                <div class="control-group">
                    <label class="control-label2" style="color: red">船报审批意见：</label>
                    <div class="controls controls-inline">
                        <asp:TextBox ID="AppOpinions" runat="server" Height="100px" TextMode="MultiLine" Width="565px"></asp:TextBox>
                    </div>
                </div>
                </div>
                <asp:Panel ID="Panel1" runat="server">
                    <div class="table-type">
					<a href="javascript:;" class="index_tabshover">安全适运申报单</a>
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
                    <label class="control-label2" style="color: red">货报审批意见：</label>
                    <div class="controls controls-inline">
                        <asp:TextBox ID="ScwOpinions" runat="server" Height="100px" TextMode="MultiLine" Width="565px"></asp:TextBox>
                    </div>
                </div>
                </asp:Panel>
                <div class="control-group" style="padding-top:20px;">
                    <label for="in-out" class="control-label2" style="color: red">审批单审批状态：</label>
                    <div class="controls controls-inline">
                        <asp:RadioButtonList ID="AppState" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0">待审批</asp:ListItem>
                            <asp:ListItem Value="1">已审批</asp:ListItem>
                            <asp:ListItem Value="2">材料补正</asp:ListItem>
                            <asp:ListItem Value="3">不予备案</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div class="control-group">
                     <label class="control-label2">&nbsp;</label>
                    <div class="controls controls-inline">
                        <a href="javascript:void(0)" class="btn-submit" onclick="submitForm();return false;">审批申报</a>
                        <a href="javascript:void(0)" class="btn-submit" onclick="javascript:history.go(-1)">返　　回</a>
                    </div>
                </div>
			</div>
		</div>
	</div>
    
    </form>
</body>
<script>
    function submitForm() {
        $("#ff").attr("action", "ApplyDetail.aspx?Action=EditState");
        $("#ff").submit();
    }
</script>
</html>
