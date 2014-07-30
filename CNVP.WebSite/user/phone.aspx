<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="phone.aspx.cs" Inherits="CNVP.WebSite.user.phone" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name='viewport' content='width=device-width, minimum-scale=1.0, maximum-scale=1.0' />
    <title>审批详细单</title>
    <link rel="stylesheet" href="/css/Global.css" />
</head>
<body>
    <h1 style="text-align:center; line-height:40px; font-size:14px;">审批详细单</h1>
    <table width="90%" border="0" cellspacing="1" cellpadding="5" bgcolor="#cccccc" align="center">
      <tbody>
        <tr>
          <td bgcolor="#FFFFFF" width="50%">进 / 出港：<%=IO %></td>
          <td bgcolor="#FFFFFF" width="50%">船名：<%=ShipName %></td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">航次：<%=Saillings %></td>
          <td bgcolor="#FFFFFF">经营人：<%=Operator %></td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">始发港：<%=StartPort %></td>
          <td bgcolor="#FFFFFF">抵港时间：<%=ArrivedTime %></td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">作业泊位：<%=WorkBerth %></td>
          <td bgcolor="#FFFFFF">审批单状态：<%=AppState %></td>
        </tr>
        <tr>
          <td bgcolor="#FFFFFF">&nbsp;</td>
          <td bgcolor="#FFFFFF">&nbsp;</td>
        </tr>
      </tbody>
    </table>
</body>
</html>
