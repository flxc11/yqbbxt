<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyList.aspx.cs" Inherits="CNVP.WebSite.admin.ApplyList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title><%=CNVP.Config.UIConfig.SoftName %></title>
    <link rel="stylesheet" href="/css/Global.css" />
    <link rel="stylesheet" href="/themes/default/easyui.css" />
    <link rel="stylesheet" href="/css/style.css" />
    <link rel="stylesheet" href="/themes/icon.css" />
    <script src="/js/jquery.js"></script>
    <script src="/js/jquery.easyui.min.js"></script>
    <script src="/js/easyui-lang-zh_CN.js"></script>
    <script src="/js/cnvp.js"></script>
    <script src="/js/jQuery.query.js"></script>
</head>
<body>
    <form id="form1" runat="server">
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
        <div id="tb"></div>
    </div>
    </form>
</body>
<script>
    function getWidth(percent) {
        //return document.body.clientWidth * percent ;
        return $(".main-r").width() * percent;
    }
    var tips = ["待审批申报单", "已审批申报单", "已退回申报单", "全部申报单列表"];
    var _state = decrypt(encodeURI($.query.get("State")));
    var fields = "Id,Guid,IO,ShipName,Saillings,Operator,StartPort,ArrivedTime,WorkBerth,AppState";
    var flag = true;
    // var grid = $('#tb');
    // var options = grid.datagrid('getPager').data("pagination").options;
    // var curr = options.pageNumber;
    // var total = options.total;
    // var max = Math.ceil(total/options.pageSize);
    //var page = $.query.get("page");
    $('#tb').datagrid({
        title: '当前位置：申报管理 > ' + tips[_state != "" && _state != "undefined" && _state != "%20" ? _state : 3],
        width: 'auto',
        height: 'auto',
        nowrap: false,
        striped: true,  //是否显示斑马线效果
        url: '/user/userjson.aspx',
        queryParams: {
            action: 'GetApplyList',
            easyGrid_Sort: fields,
            State: _state,
            Time: new Date().getTime()
        },
        idField: 'Id',
        fix: false,
        frozenColumns: [[

        ]],
        columns: [[
            { field: 'ck', checkbox: true, width: getWidth(0.05) },
            {
                title: '序号', field: 'ooo', width: getWidth(0.05), align: 'center',
                formatter: function (value, row, index) {
                    return index + 1;
                }
            },
            {
                title: '出/入港', field: 'IO', width: getWidth(0.05), align: 'center',
                formatter: function (value, row, index) {
                    if (row.IO == "1") {
                        return "出港";
                    } else {
                        return "入港";
                    };
                }
            },
            { title: '船名', field: 'ShipName', width: getWidth(0.1), align: 'center' },
            { title: '航次', field: 'Saillings', width: getWidth(0.1), align: 'center' },
            { title: '经营人', field: 'Operator', width: getWidth(0.15), align: 'center' },
            { title: '始发港', field: 'StartPort', width: getWidth(0.1), align: 'center' },
            {
                title: '抵港时间', field: 'ArrivedTime', width: getWidth(0.1), align: 'center',
                formatter: function (value, row, index) {
                    return Common.TimeFormatter(row.ArrivedTime, row, index);
                }
            },
            { title: '作业泊位', field: 'WorkBerth', width: getWidth(0.1), align: 'center' },
            {
                title: '状态', field: 'AppState', width: getWidth(0.05), align: 'center',
                formatter: function (value, row, index) {
                    if (row.AppState == "0") {
                        return "待审批";
                    } else if (row.AppState == "1") {
                        return "已审批";
                    } else if (row.AppState == "2") {
                        return "已退回";
                    };
                }
            },
            {
                title: '操作', field: 'xxx', width: getWidth(0.05), align: 'center',
                formatter: function (value, row, index) {
                    return "<a href='ApplyDetail.aspx?guid=" + row.Guid + "&page=" + $('#tb').datagrid('getPager').data("pagination").options.pageNumber + "&State=" + $.query.get("State") + "'>查看</a>";
                }
            }
        ]],
        pagination: true,
        pageSize: 10,
        pageNumber: parseInt($.query.get("page")) || 1,
        pageList: [10, 15, 20],//可以设置每页记录条数的列表  
        rownumbers: false,
        toolbar: [{
            id: 'btndelete',
            text: '删除',
            iconCls: 'icon-cancel',
            handler: function () {
                $('#btndelete').linkbutton('enable');
                //---
                var idsstr = "";
                var ids = new Array();
                var rows = $('#tb').datagrid('getSelections');
                if (rows.length < 1) {
                    $.messager.alert('信息窗口', '请选择要删除的数据!', 'info');
                } else {
                    var cand = true;
                    for (var i = 0; i < rows.length; i++) {
                        ids.push(rows[i].Guid);
                    }
                    idsstr = ids.join(',');
                    if (cand) {
                        $.messager.confirm('删除窗口', '注意：删除时会连同安全适运单一起删除,你确定要删除吗?', function (r) {
                            if (r) {
                                //--s-执行删除操作
                                $.ajax({
                                    type: "POST",
                                    url: "/user/userjson.aspx?Time=" + new Date().getTime(),
                                    data: {
                                        action: "Delete",
                                        Guid: idsstr
                                    },
                                    dataType: "json",
                                    cache: false,
                                    success: function (msg) {
                                        if (msg.result == "1") {
                                            $.messager.alert('信息窗口', '删除成功!', 'info', function () {
                                                //重新加载当前页
                                                $('#tb').datagrid('reload');
                                            });
                                        } else {
                                            $.messager.alert('信息窗口', '删除失败!', 'info');
                                        }
                                    }
                                });
                                //--e-执行删除操作
                            }
                        })
                    } else {
                        $.messager.alert('信息窗口', '你选择的数据中有ID为0的数据，此数据为系统数据，不能删除!', 'info');
                    }
                }
                //---
            }
        }
            //-------------  
            , '-', {
                id: 'btnquery',
                text: '查询',
                iconCls: 'icon-search',
                handler: function () {
                    $('#btnquery').linkbutton('enable');
                    alert('查询');

                }
            }
        ]
    });
    var p = $('#tb');
    var opts = p.datagrid('options');
    var pager = p.datagrid('getPager');

    pager.pagination({
        //pageNumber:2,
        beforePageText: '第',//页数文本框前显示的汉字
        afterPageText: '页    共 {pages} 页',
        displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
    });

</script>
</html>
