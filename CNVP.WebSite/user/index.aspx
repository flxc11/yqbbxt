﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CNVP.WebSite.user.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <form id="ff" name="ff" action="?Action=Application" runat="server" enctype="multipart/form-data">
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
				当前位置：<a href="#">申报管理</a> > 发起申报单
			</div>
			<div class="main-form">
				<div class="table-type cnvp-tab-nav">
					<a href="javascript:;" class="index_tabshover">船舶载运固体散装货物申报单</a>
					<a href="javascript:;" id="scf-a">安全适运申报单</a>
				</div>
                <div class="cnvp-tab-panle">
                    <div class="table-1">
                        <div class="control-group">
                            <label for="in-out" class="control-label">进&nbsp;&nbsp;出&nbsp;&nbsp;港：</label>
                            <div class="controls controls-inline">
                                <asp:RadioButtonList ID="IO" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="0">进港</asp:ListItem>
                                    <asp:ListItem Value="1">出港</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">船　　名：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="ShipName" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入船名'" ></asp:TextBox>
                            </div>
                            <label for="in-out" class="control-label">航　　次：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="Saillings" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入船次'"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">国　　籍：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="Nationality" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入国籍'"></asp:TextBox>
                            </div>
                            <label for="in-out" class="control-label">经 营 人：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="Operator" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入经营人姓名'"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">始 发 港：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="StartPort" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入始发港'"></asp:TextBox>
                            </div>
                            <label for="in-out" class="control-label">抵港时间：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="ArrivedTime" runat="server" CssClass="easyui-datebox app-input" data-options="required:true,missingMessage:'请选择抵港时间',editable:false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">作业泊位：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="WorkBerth" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入作业泊位'"></asp:TextBox>
                            </div>
                            <label for="in-out" class="control-label">作业时间：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="WorkTime" runat="server" CssClass="easyui-datebox app-input" data-options="required:true,missingMessage:'请选择作业时间',editable:false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div>
                        <table width="100%" border="0" cellspacing="1" cellpadding="0" id="BulkFreight">
                          <tr id="Bf-ftr">
                            <td width="16%" height="40">散装货物运输名称 <em id="bulk-add">[+]</em><em id="bulk-subtraction">[-]</em></td>
                            <td width="12%">组别</td>
                            <td width="12%">类别</td>
                            <td width="12%">危规编号</td>
                            <td width="12%">总重量</td>
                            <td width="12%">卸货港</td>
                            <td width="12%">装载位置</td>
                            <td width="12%">备注</td>
                          </tr>
                          <tr class="bulkfright">
                            <td height="40" align="center" valign="middle"><input type="text" name="BfGoodsName" class="easyui-validatebox" required="true" /></td>
                            <td>
                                <select name="BfGoodsGroup">
                                    <option value="C组">C组</option>
                                    <option value="A组">A组</option>
                                </select>
                            </td>
                            <td><input type="text" name="Class" class="easyui-validatebox" /></td>
                            <td><input type="text" name="DangerousNo" class="easyui-validatebox" /></td>
                            <td><input type="text" name="BfTotalWeight" class="easyui-validatebox" required="true" /></td>
                            <td><input type="text" name="DischargingPort" class="easyui-validatebox" required="true" /></td>
                            <td><input type="text" name="Position" class="easyui-validatebox" required="true" /></td>
                            <td><input type="text" name="Remark" class="easyui-validatebox" tipPosition="left" /></td>
                          </tr>
                        </table>
                    </div>
                    <div class="table-1">
                        <div class="control-group">
                            <label for="in-out" class="control-label">申 报 员：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="Declarer" runat="server" CssClass="app-input"></asp:TextBox>
                            </div>
                            <label for="in-out" class="control-label">申报员证书编号：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="DecCertificateNo" MaxLength="30" runat="server" CssClass="app-input"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">船方：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="Ship" runat="server" CssClass="app-input"></asp:TextBox>
                            </div>
                            <label for="in-out" class="control-label">手机：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="Telphone" runat="server" CssClass="app-input"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">紧急联系人姓名：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="EmergencyName" runat="server" CssClass="app-input easyui-validatebox" data-options="required:true,missingMessage:'请输入紧急联系人姓名'"></asp:TextBox>
                            </div>
                            <label for="in-out" class="control-label">紧急联系人电话：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="EmergencyTel" runat="server" CssClass="app-input easyui-validatebox" data-options="required:true,missingMessage:'请输入紧急联系人电话'"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label">紧急联系人传真：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="EmergencyFax" runat="server" CssClass="app-input easyui-validatebox" data-options="required:true,missingMessage:'请输入紧急联系人传真'"></asp:TextBox>
                            </div>
                            <label for="in-out" class="control-label">紧急联系人邮件：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="RmergencyEmail" runat="server" CssClass="app-input easyui-validatebox" data-options="required:true,missingMessage:'请输入紧急联系人邮件'"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label1">1、<span>适航证书</span></label>
                            <div class="controls controls-inline">
                                <input type="file" class="input fl easyui-validatebox" id ="mfile0_0"  name="mfile0_0" required="true" missingMessage="请上传船舶证书" /> <span style="color: red;padding-left: 20px;">*</span>
                            </div>
                        </div>
                        <div class="control-group">
                        <label for="in-out" class="control-label1">2、<span>船舶证书</span></label>
                        <div class="controls controls-inline">
                            <input type="file" class="input fl easyui-validatebox" id ="mfile0_1"  name="mfile0_1" required="true" missingMessage="请上传船舶证书"  /> <span style="color: red;padding-left: 20px;">*</span>
                        </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label1">3、<span>配载图</span></label>
                            <div class="controls controls-inline">
                                <input type="file" class="input fl easyui-validatebox" id ="mfile0_2"  name="mfile0_2" required="true" missingMessage="请上传配载图"  /> <span style="color: red;padding-left: 20px;">*</span>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label1">4、<span>进/出港申报委托书</span></label>
                            <div class="controls controls-inline">
                                <input type="file" class="input fl easyui-validatebox" id ="mfile0_3"  name="mfile0_3"  />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label1">5、<span>保险证书类型</span></label>
                            <div class="controls controls-inline">
                                <input type="file" class="input fl easyui-validatebox" id ="mfile0_4"  name="mfile0_4" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label1">6、<span>其它</span></label>
                            <div class="controls controls-inline" id="MyFile0">
                                <input type="file" class="input fl easyui-validatebox" id ="mfile0_5"  name="mfile0_5" /><input type="button" value="增加" class="fl add1" onclick="addFile('MyFile0')" />
                            </div>
                        </div>
                    </div>
                    <div class="control-group">
                            <a href="javascript:void(0)" class="btn-submit" onclick="submitForm()">提交申报</a>
                            <a href="javascript:void(0)" class="btn-submit" onclick="javascript:history.go(-1)">返　　回</a>
                    </div>
                </div>
                <div class="cnvp-tab-panle cnvp-tabs-hide">
                    <div class="table-1 scf" id="scFile0">
                        <div class="control-group">
                            <label for="in-out" class="control-label2">散装货物运输名称：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="GoodsName" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入散装货物运输名称'" novalidate=true></asp:TextBox><span class="scwspan1">*</span>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">托运人：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="Shipper" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入托运人'" novalidate=true></asp:TextBox><span class="scwspan1">*</span>
                            </div>
                            <label for="in-out" class="control-label2">运输单证编号：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="TransportDocNo" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入运输单证编号'" novalidate=true></asp:TextBox><span class="scwspan1">*</span>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">收货人：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="Consignee" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入收货人'" novalidate=true></asp:TextBox><span class="scwspan1">*</span>
                            </div>
                            <label for="in-out" class="control-label2">承运人：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="Carrier" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入承运人'" novalidate=true></asp:TextBox><span class="scwspan1">*</span>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">运输工具的名称/方式：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="TransPort" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入运输工具的名称/方式'" novalidate=true></asp:TextBox><span class="scwspan1">*</span>
                            </div>
                            <label for="in-out" class="control-label2">指南或其他事项：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="Guide" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入指南或其他事项'" novalidate=true></asp:TextBox><span class="scwspan1">*</span>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">出发港口/地点：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="HomePort" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入出发港口/地点'" novalidate=true></asp:TextBox><span class="scwspan1">*</span>
                            </div>
                            <label for="in-out" class="control-label2">目的港口/地点：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="DestinationPort" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入目的港口/地点'" novalidate=true></asp:TextBox><span class="scwspan1">*</span>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">货物一般性的描述：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="Description" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入货物一般性的描述'" novalidate=true></asp:TextBox><span class="scwspan1">*</span>
                            </div>
                            <label for="in-out" class="control-label2">总重：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="TotalWeight" runat="server" CssClass="easyui-validatebox app-input" data-options="required:true,missingMessage:'请输入总重'" novalidate=true></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">货物组别：</label>
                            <div class="controls controls-inline">
                                <asp:DropDownList ID="GoodsGroup" runat="server" CssClass="select1">
                                    <asp:ListItem>C组</asp:ListItem>
                                    <asp:ListItem>A组</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <label for="in-out" class="control-label2">适运水分极限：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="MoistureLimit" runat="server" CssClass="app-input"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">货物相关特殊性质：</label>
                            <div class="controls controls-inline">
                                <asp:TextBox ID="ParticularNature" runat="server" CssClass="app-input"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="in-out" class="control-label2">额外证书：</label>
                        </div>
                        <div class="control-group">
                            <div class="controls-inline">
                                <label for="in-out" class="control-label1">1、<span>水份含量和适运水份极限证书</span></label>
                                <div class="controls-inline">
                                    <input type="file" class="input fl easyui-validatebox" id ="scwmfile0_1"  name="scwmfile0_1" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="controls-inline">
                                <label for="in-out" class="control-label1">2、<span>安全适运性评估报告</span></label>
                                <div class="controls-inline">
                                    <input type="file" class="input fl easyui-validatebox" id ="scwmfile0_2"  name="scwmfile0_2" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="controls-inline">
                                <label for="in-out" class="control-label1">3、<span>委托书</span></label>
                                <div class="controls-inline">
                                    <input type="file" class="input fl easyui-validatebox" id ="scwmfile0_3"  name="scwmfile0_3" />
                                </div>
                            </div>
                        </div>
                        <div class="control-group">
                            <div class="controls-inline">
                                <label for="in-out" class="control-label1">4、<span>其它</span></label>
                                <div class="controls-inline">
                                    <input type="file" class="input fl easyui-validatebox" id ="scwmfile0_4"  name="scwmfile0_4" /><input type="button" value="增加" class="fl add1" onclick="addFile1('scFile0')" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
			</div>
		</div>
	</div>
    
    </form>
</body>
<script>
    $(function() {
        $('.scf input.easyui-validatebox').validatebox('disableValidation');  //让安全适运申报单失效

        $("#bulk-add").on("click", function() {
            var add_list = '<tr class="bulkfright"><td height="40" align="center" valign="middle"><input type="text" name="BfGoodsName" class="easyui-validatebox" /></td><td><select name="BfGoodsGroup"><option value="A组">A组</option><option value="C组">C组</option></select></td><td><input type="text" name="Class" class="easyui-validatebox" required="true" /></td><td><input type="text" name="DangerousNo" class="easyui-validatebox" required="true" /></td><td><input type="text" name="BfTotalWeight" class="easyui-validatebox" required="true" /></td><td><input type="text" name="DischargingPort" class="easyui-validatebox" required="true" /></td><td><input type="text" name="Position" class="easyui-validatebox" required="true" /></td><td><input type="text" name="Remark" class="easyui-validatebox" required="true" tipPosition="left" /></td></tr>';
            $("#BulkFreight").append(add_list);
            $(".bulkfright input[type='text']").validatebox({
                required: true,
                validType: 'Character'
            })
        });
        $("#bulk-subtraction").on("click", function() {
            if ($(".bulkfright").length > 1) {
                $(".bulkfright").last().remove();
            };
        })
        $("#IO").on("click", function() {
            if ($("input[type='radio'][name='IO']:checked").val() == "1") {
                $("#scf-a").css("display", "inline-block");
                $('.scf input.easyui-validatebox').validatebox('enableValidation');  //激活安全适运申报单验证
            } else {
                $("#scf-a").css("display", "none");
                $('.scf input.easyui-validatebox').validatebox('disableValidation');
            };
        });
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
                $("#ff").attr("action", "index.aspx?Action=Application");
                $("#ff").submit();
            }
            setTimeout(doSubmit,0);
        } else {
           $.messager.alert("信息","输入不合法，请检查后再提交！");
        }
    }
    function addFile(id) {
        var inputstr = "";
        var i = 1;
        var index = id.substring(6);
        while (true) {
            if (document.getElementById("mfile" + index + "_" + i) == null) break;
            else i++;
        }
        var inputid = "mfile" + index + "_" + i;
        var str = "<br /><INPUT type=\"file\" class=\"input fl\" id=\"" + inputid + "\" name=\"" + inputid + "\" /><INPUT id=\"r" + inputid + "\" type=\"button\" class=\"fl add1\" value=\"删除\" onclick=removeFile(\"" + inputid + "\") />";
        document.getElementById(id).insertAdjacentHTML("beforeEnd", str);

    }
    function addFile1(id) {
        var inputstr = "";
        var i = 1;
        var index = id.substring(6);
        while (true) {
            if (document.getElementById("scwmfile" + index + "_" + i) == null) break;
            else i++;
        }
        var inputid = "scwmfile" + index + "_" + i;
        var str = "<div class='control-group'><div class='controls-inline'><label for='in-out' class='control-label1'>&nbsp;</label><div class='controls-inline'><input type=\"file\" class=\"input fl\" id=\"" + inputid + "\" name=\"" + inputid + "\" /><input id=\"r" + inputid + "\" type=\"button\" class=\"fl add1\" value=\"删除\" onclick=removeFile(\"" + inputid + "\") /></div></div></div>";
        document.getElementById(id).insertAdjacentHTML("beforeEnd", str);

    }
    function removeFile(id) {
        var obj = document.getElementById(id);
        var obj1 = document.getElementById("r" + id);
        if (obj != null && obj1 != null) {
            //obj.removeNode(true);
            //obj1.removeNode(true);
            obj.parentNode.removeChild(obj);
            obj1.parentNode.removeChild(obj1);
        }
    }

</script>
</html>
