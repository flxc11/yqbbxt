<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Notice.aspx.cs" Inherits="CNVP.WebSite.user.Notice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>审批通知单</title>
    <style>
        @media print {
        @page {
            margin: 0;
        }
        .noprint {
            　　display: none;
        }
    }
    </style>
</head>
<body>
    <table width="600" border="0" align="center" cellpadding="0" cellspacing="0">
      <tbody>
        <tr>
          <td>
              <h1 style="text-align:center">审批通知单</h1>
              </td>
        </tr>
        <tr>
          <td style="line-height:24px;">尊敬的用户您好！您在我局提交的船舶运输申报已获得审批，请带齐证件和材料尽快来我局办事窗口办理！</td>
        </tr>
        <tr>
          <td style="text-align:right;line-height:40px;">温州海事局<br /><%=DateTime.Now.ToString("yyyy-MM-dd") %></td>
        </tr>
        <tr>
          <td style="text-align:center; line-height:40px;">二维码在线查看详细</td>
        </tr>
        <tr>
          <td style="text-align:center;"><img src="GetQRCode.ashx?t=<%=AppGuid %>" /></td>
        </tr>
      </tbody>
    </table>
    <div class="noprint" style="cursor:pointer; line-height:60px; text-align: center;" onclick="window.print();">打印</div>
</body>
</html>
