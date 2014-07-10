<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolidBulk.aspx.cs" Inherits="CNVP.WebSite.user.SolidBulk" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>船舶载运固体散装货物申报单</title>
    <style>
<!--

 /* Style Definitions */
 p.MsoNormal, li.MsoNormal, div.MsoNormal
	{margin:0cm;
	margin-bottom:.0001pt;
	text-align:justify;
	text-justify:inter-ideograph;
	font-size:10.5pt;
	font-family:"Times New Roman","serif";}
p.MsoHeader, li.MsoHeader, div.MsoHeader
	{mso-style-link:"页眉 Char";
	margin:0cm;
	margin-bottom:.0001pt;
	text-align:center;
	layout-grid-mode:char;
	border:none;
	padding:0cm;
	font-size:9.0pt;
	font-family:"Times New Roman","serif";}
p.MsoFooter, li.MsoFooter, div.MsoFooter
	{mso-style-link:"页脚 Char";
	margin:0cm;
	margin-bottom:.0001pt;
	layout-grid-mode:char;
	font-size:9.0pt;
	font-family:"Times New Roman","serif";}
p.MsoAcetate, li.MsoAcetate, div.MsoAcetate
	{margin:0cm;
	margin-bottom:.0001pt;
	text-align:justify;
	text-justify:inter-ideograph;
	font-size:9.0pt;
	font-family:"Times New Roman","serif";}
span.Char
	{mso-style-name:"页脚 Char";
	mso-style-link:页脚;}
span.Char0
	{mso-style-name:"页眉 Char";
	mso-style-link:页眉;}
 /* Page Definitions */
 @page WordSection1
	{size:841.9pt 595.3pt;
	margin:14.45pt 2.0cm 14.45pt 2.0cm;
	layout-grid:15.6pt;}
div.WordSection1
	{page:WordSection1;}
 /* List Definitions */
 ol
	{margin-bottom:0cm;}
ul
	{margin-bottom:0cm;}
-->
.MsoNormalTable {
    margin:0 auto;
}
</style>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/JqPrintArea.js"></script>
</head>
<body lang=ZH-CN style='text-justify-trim:punctuation'>
    <div id="app_print">
<div class=WordSection1 style='layout-grid:15.6pt'>

<p class=MsoNormal align=center style='text-align:center;line-height:14.0pt'><b><span
style='font-size:14.0pt;font-family:黑体'>船</span></b><b><span style='font-size:
14.0pt'> </span></b><b><span style='font-size:14.0pt;font-family:黑体'>舶</span></b><b><span
style='font-size:14.0pt'> </span></b><b><span style='font-size:14.0pt;
font-family:黑体'>载</span></b><b><span style='font-size:14.0pt'> </span></b><b><span
style='font-size:14.0pt;font-family:黑体'>运</span></b><b><span style='font-size:
14.0pt'> </span></b><b><span style='font-size:14.0pt;font-family:黑体'>固</span></b><b><span
style='font-size:14.0pt'> </span></b><b><span style='font-size:14.0pt;
font-family:黑体'>体</span></b><b><span style='font-size:14.0pt'> </span></b><b><span
style='font-size:14.0pt;font-family:黑体'>散</span></b><b><span style='font-size:
14.0pt'> </span></b><b><span style='font-size:14.0pt;font-family:黑体'>装</span></b><b><span
style='font-size:14.0pt'> </span></b><b><span style='font-size:14.0pt;
font-family:黑体'>货</span></b><b><span style='font-size:14.0pt'> </span></b><b><span
style='font-size:14.0pt;font-family:黑体'>物</span></b><b><span style='font-size:
14.0pt'> </span></b><b><span style='font-size:14.0pt;font-family:黑体'>申</span></b><b><span
style='font-size:14.0pt'> </span></b><b><span style='font-size:14.0pt;
font-family:黑体'>报</span></b><b><span style='font-size:14.0pt'> </span></b><b><span
style='font-size:14.0pt;font-family:黑体'>单</span></b></p>

<p class=MsoNormal align=center style='text-align:center;line-height:14.0pt'><b><span
lang=EN-US style='font-size:14.0pt'>Declaration Form for Solid Bulk Cargoes
Carried By Ship</span></b></p>

<table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0
 style='border-collapse:collapse' align="center">
 <tr>
  <td width=225 valign=top style='width:168.45pt;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='line-height:12.0pt'><span style='font-size:9.0pt;
  font-family:宋体'>船</span><span lang=EN-US style='font-size:9.0pt'>&nbsp;&nbsp;&nbsp;
  </span><span style='font-size:9.0pt;font-family:宋体'>名：</span></p>
  <p class=MsoNormal style='line-height:12.0pt'><span lang=EN-US
  style='font-size:9.0pt'>Ship’s Name:<u>&nbsp; </u></span><u><span lang=EN-US
  style='font-size:12.0pt'>&nbsp;</span></u><u><span lang=EN-US
  style='font-size:9.0pt'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></u></p>
  </td>
  <td width=198 valign=top style='width:148.8pt;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='line-height:12.0pt'><span style='font-size:9.0pt;
  font-family:宋体'>航</span><span lang=EN-US style='font-size:9.0pt'>&nbsp;&nbsp;&nbsp;
  </span><span style='font-size:9.0pt;font-family:宋体'>次：</span></p>
  <p class=MsoNormal style='line-height:12.0pt'><span lang=EN-US
  style='font-size:9.0pt'>Voyage No.:<u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  </u></span></p>
  </td>
  <td width=104 valign=top style='width:78.0pt;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='line-height:12.0pt'><span style='font-size:9.0pt;
  font-family:宋体'>□进港</span></p>
  <p class=MsoNormal style='line-height:12.0pt'><span lang=EN-US
  style='font-size:9.0pt'>Arrival</span></p>
  </td>
  <td width=246 valign=top style='width:184.25pt;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='line-height:12.0pt'><span style='font-size:9.0pt;
  font-family:宋体'>始发港：</span><span lang=EN-US style='font-size:9.0pt'>&nbsp;&nbsp;&nbsp;&nbsp;
  </span><span lang=EN-US style='font-size:12.0pt'>&nbsp;&nbsp;</span></p>
  <p class=MsoNormal style='line-height:12.0pt'><span lang=EN-US
    style='font-size:9.0pt'>Port</span><span lang=EN-US style='font-size:9.0pt'>
   of Departure</span><span lang=EN-US style='font-size:9.0pt'>:<u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  </u></span></p>
  </td>
  <td width=228 valign=top style='width:171.1pt;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='line-height:12.0pt'><span style='font-size:9.0pt;
  font-family:宋体'>抵港时间：</span><span style='font-size:9.0pt'> </span><span
  lang=EN-US style='font-size:12.0pt'>&nbsp;&nbsp;</span></p>
  <p class=MsoNormal style='line-height:12.0pt'><span lang=EN-US
  style='font-size:9.0pt'>Time of Arrival:<u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  &nbsp;&nbsp;&nbsp;</u></span></p>
  </td>
 </tr>
 <tr>
  <td width=225 valign=top style='width:168.45pt;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='line-height:12.0pt'><span style='font-size:9.0pt;
  font-family:宋体'>国</span><span lang=EN-US style='font-size:9.0pt'>&nbsp;&nbsp;&nbsp;
  </span><span style='font-size:9.0pt;font-family:宋体'>籍：</span><span
  lang=EN-US style='font-size:9.0pt'>&nbsp;&nbsp; </span></p>
  <p class=MsoNormal style='line-height:12.0pt'><span lang=EN-US
  style='font-size:9.0pt'>Nationality:<u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  </u></span></p>
  </td>
  <td width=198 valign=top style='width:148.8pt;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='line-height:12.0pt'><span style='font-size:9.0pt;
  font-family:宋体'>经</span><span style='font-size:9.0pt'> </span><span
  style='font-size:9.0pt;font-family:宋体'>营</span><span style='font-size:9.0pt'>
  </span><span style='font-size:9.0pt;font-family:宋体'>人：</span></p>
  <p class=MsoNormal style='line-height:12.0pt'><span lang=EN-US
  style='font-size:9.0pt'>Manager:<u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  </u></span></p>
  </td>
  <td width=104 valign=top style='width:78.0pt;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='line-height:12.0pt'><span style='font-size:9.0pt;
  font-family:宋体'>□出港</span></p>
  <p class=MsoNormal style='line-height:12.0pt'><span lang=EN-US
  style='font-size:9.0pt'>Departure</span></p>
  </td>
  <td width=246 valign=top style='width:184.25pt;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='line-height:12.0pt'><span style='font-size:9.0pt;
  font-family:宋体'>作业泊位：</span></p>
  <p class=MsoNormal style='line-height:12.0pt'><span lang=EN-US
  style='font-size:9.0pt'>Berth:<u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  </u></span></p>
  </td>
  <td width=228 valign=top style='width:171.1pt;padding:0cm 5.4pt 0cm 5.4pt'>
  <p class=MsoNormal style='line-height:12.0pt'><span style='font-size:9.0pt;
  font-family:宋体'>作业时间：</span><span lang=EN-US style='font-size:9.0pt'>&nbsp;&nbsp;&nbsp;
  </span></p>
  <p class=MsoNormal style='line-height:12.0pt'><span lang=EN-US
  style='font-size:9.0pt'>Time of Loading:<u>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  </u></span></p>
  </td>
 </tr>
</table>

<table class=MsoNormalTable border=1 cellspacing=0 cellpadding=0 style='width:750.6pt;border-collapse:collapse;border:none;' align="center">
 <tr style='height:28.1pt'>
  <td width=206 colspan=2 style='width:154.25pt;border-top:1.5pt;border-left:
  1.5pt;border-bottom:1.0pt;border-right:1.0pt;border-color:windowtext;
  border-style:solid;padding:0cm 5.4pt 0cm 5.4pt;height:28.1pt'>
  <p class=MsoNormal align=center style='text-align:center;text-autospace:none'><span
  style='font-size:9.0pt;font-family:宋体'>散装货物运输名称</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>Bulk Cargo Shipping Name</span></p>
  </td>
  <td width=95 style='width:70.9pt;border-top:solid windowtext 1.5pt;
  border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:28.1pt'>
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:9.0pt;font-family:宋体'>组别</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>Group</span></p>
  </td>
  <td width=92 style='width:69.0pt;border-top:solid windowtext 1.5pt;
  border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:28.1pt'>
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:9.0pt;font-family:宋体'>类别</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>Class</span></p>
  </td>
  <td width=97 colspan=2 style='width:72.75pt;border-top:solid windowtext 1.5pt;
  border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:28.1pt'>
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:9.0pt;font-family:宋体'>危规编号</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>UN No.</span></p>
  </td>
  <td width=123 style='width:92.1pt;border-top:solid windowtext 1.5pt;
  border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:28.1pt'>
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:9.0pt;font-family:宋体'>总</span><span style='font-size:9.0pt'>
  </span><span style='font-size:9.0pt;font-family:宋体'>重</span><span
  style='font-size:9.0pt'> </span><span style='font-size:9.0pt;font-family:
  宋体'>量</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>Weight in Total</span></p>
  </td>
  <td width=109 style='width:81.9pt;border-top:solid windowtext 1.5pt;
  border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:28.1pt'>
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:9.0pt;font-family:宋体'>卸</span><span style='font-size:9.0pt'>
  </span><span style='font-size:9.0pt;font-family:宋体'>货</span><span
  style='font-size:9.0pt'> </span><span style='font-size:9.0pt;font-family:
  宋体'>港</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>Port of Discharging</span></p>
  </td>
  <td width=126 colspan=2 style='width:94.5pt;border-top:solid windowtext 1.5pt;
  border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:28.1pt'>
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:9.0pt;font-family:宋体'>装载位置</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>Location of Stowage</span></p>
  </td>
  <td width=154 style='width:115.2pt;border-top:solid windowtext 1.5pt;
  border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:28.1pt'>
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:9.0pt;font-family:宋体'>备</span><span lang=EN-US
  style='font-size:9.0pt'>&nbsp; </span><span style='font-size:9.0pt;
  font-family:宋体'>注</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>Remarks</span></p>
  </td>
 </tr>
 <tr style='height:13.55pt'>
  <td width=206 colspan=2 style='width:154.25pt;border-top:none;border-left:
  solid windowtext 1.5pt;border-bottom:solid windowtext 1.0pt;border-right:
  solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:13.55pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:12.0pt'>&nbsp;</span></p>
  </td>
  <td width=95 style='width:70.9pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:13.55pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:12.0pt'>&nbsp;</span></p>
  </td>
  <td width=92 style='width:69.0pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:13.55pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:12.0pt'>&nbsp;</span></p>
  </td>
  <td width=97 colspan=2 style='width:72.75pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:13.55pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:12.0pt'>&nbsp;</span></p>
  </td>
  <td width=123 style='width:92.1pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:13.55pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:12.0pt'>&nbsp;</span></p>
  </td>
  <td width=109 style='width:81.9pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:13.55pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:12.0pt'>&nbsp;</span></p>
  </td>
  <td width=126 colspan=2 style='width:94.5pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:13.55pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:12.0pt'>&nbsp;</span></p>
  </td>
  <td width=154 style='width:115.2pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:13.55pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
 </tr>
 <tr style='height:13.05pt'>
  <td width=206 colspan=2 style='width:154.25pt;border-top:none;border-left:
  solid windowtext 1.5pt;border-bottom:solid windowtext 1.0pt;border-right:
  solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:13.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=95 style='width:70.9pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:13.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=92 style='width:69.0pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:13.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=97 colspan=2 style='width:72.75pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:13.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=123 style='width:92.1pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:13.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=109 style='width:81.9pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:13.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=126 colspan=2 style='width:94.5pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:13.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=154 style='width:115.2pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:13.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
 </tr>
 <tr style='height:11.85pt'>
  <td width=206 colspan=2 style='width:154.25pt;border-top:none;border-left:
  solid windowtext 1.5pt;border-bottom:solid windowtext 1.0pt;border-right:
  solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:11.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=95 style='width:70.9pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:11.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=92 style='width:69.0pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:11.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=97 colspan=2 style='width:72.75pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:11.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=123 style='width:92.1pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:11.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=109 style='width:81.9pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:11.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=126 colspan=2 style='width:94.5pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:11.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=154 style='width:115.2pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:11.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
 </tr>
 <tr style='height:12.05pt'>
  <td width=206 colspan=2 style='width:154.25pt;border-top:none;border-left:
  solid windowtext 1.5pt;border-bottom:solid windowtext 1.0pt;border-right:
  solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:12.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=95 style='width:70.9pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:12.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=92 style='width:69.0pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:12.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=97 colspan=2 style='width:72.75pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:12.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=123 style='width:92.1pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:12.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=109 style='width:81.9pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:12.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=126 colspan=2 style='width:94.5pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:12.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=154 style='width:115.2pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:12.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
 </tr>
 <tr style='height:10.85pt'>
  <td width=206 colspan=2 style='width:154.25pt;border-top:none;border-left:
  solid windowtext 1.5pt;border-bottom:solid windowtext 1.0pt;border-right:
  solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:10.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=95 style='width:70.9pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:10.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=92 style='width:69.0pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:10.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=97 colspan=2 style='width:72.75pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:10.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=123 style='width:92.1pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:10.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=109 style='width:81.9pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:10.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=126 colspan=2 style='width:94.5pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:10.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=154 style='width:115.2pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:10.85pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
 </tr>
 <tr style='height:11.05pt'>
  <td width=206 colspan=2 style='width:154.25pt;border-top:none;border-left:
  solid windowtext 1.5pt;border-bottom:solid windowtext 1.0pt;border-right:
  solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;height:11.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=95 style='width:70.9pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:11.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=92 style='width:69.0pt;border-top:none;border-left:none;border-bottom:
  solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;padding:0cm 5.4pt 0cm 5.4pt;
  height:11.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=97 colspan=2 style='width:72.75pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:11.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=123 style='width:92.1pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:11.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=109 style='width:81.9pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:11.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=126 colspan=2 style='width:94.5pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:11.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=154 style='width:115.2pt;border-top:none;border-left:none;
  border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:11.05pt'>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
 </tr>
 <tr style='height:83.6pt'>
  <td width=787 colspan=9 style='width:590.4pt;border-top:none;border-left:
  solid windowtext 1.5pt;border-bottom:none;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:83.6pt'>
  <p class=MsoNormal><span style='font-size:9.0pt;font-family:宋体'>兹声明根据船舶装载固体散装货物安全和防污染规定，本轮具备装载上述货物的适装条件，货物配装符合要求，货物资料齐全。申报内容准确无误。</span></p>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>I hereby declare
  that, in accordance with the provisions of the safe transportation of solid
  bulk cargoes by ships and pollution prevention, this ship has met the
  requirements of fitness for carrying the above declared goods; Cargo stowage
  is properly planned according to the requirements; The documentation of the cargo
  is complete and the contents of the declaration are true and correct.</span></p>
  <p class=MsoNormal><span style='font-size:9.0pt;font-family:宋体'>附送以下单证、资料</span></p>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>The following
  documents and information are submitted in addition.</span></p>
  </td>
  <td width=214 colspan=2 rowspan=2 style='width:160.2pt;border-top:none;
  border-left:none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.5pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:83.6pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>&nbsp;</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>&nbsp;</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>&nbsp;</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>&nbsp;</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>&nbsp;</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>&nbsp;</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span
  style='font-size:9.0pt;font-family:宋体'>主</span><span style='font-size:9.0pt'>
  </span><span style='font-size:9.0pt;font-family:宋体'>管</span><span
  style='font-size:9.0pt'> </span><span style='font-size:9.0pt;font-family:
  宋体'>机</span><span style='font-size:9.0pt'> </span><span style='font-size:
  9.0pt;font-family:宋体'>关</span><span style='font-size:9.0pt'> </span><span
  style='font-size:9.0pt;font-family:宋体'>签</span><span style='font-size:9.0pt'>
  </span><span style='font-size:9.0pt;font-family:宋体'>证</span><span
  style='font-size:9.0pt'> </span><span style='font-size:9.0pt;font-family:
  宋体'>栏</span></p>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>Remarks by the Administration</span></p>
  </td>
 </tr>
 <tr style='height:66.2pt'>
  <td width=98 style='width:73.7pt;border-top:none;border-left:solid windowtext 1.5pt;
  border-bottom:solid windowtext 1.0pt;border-right:none;padding:0cm 5.4pt 0cm 5.4pt;
  height:66.2pt'>
  <p class=MsoNormal align=right style='text-align:right;word-break:break-all'><span
  lang=EN-US style='font-size:9.0pt'>&nbsp;</span></p>
  </td>
  <td width=368 colspan=4 style='width:276.35pt;border:none;border-bottom:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:66.2pt'>
  <p class=MsoNormal style='margin-bottom:7.8pt'><span style='font-size:9.0pt;
  font-family:宋体'>轮船长</span><span lang=EN-US style='font-size:9.0pt'>/</span><span
  style='font-size:9.0pt;font-family:宋体'>申报员</span><span lang=EN-US
  style='font-size:9.0pt'>:</span></p>
  <p class=MsoNormal style='text-indent:18.0pt;word-break:break-all'><u><span
  lang=EN-US style='font-size:12.0pt'>&nbsp;&nbsp; </span></u><span lang=EN-US
  style='font-size:9.0pt'>Master / Declarator: &nbsp;<u>&nbsp;</u></span><u><span
  lang=EN-US style='font-size:12.0pt'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span></u></p>
  <p class=MsoNormal style='word-break:break-all'><span lang=EN-US
  style='font-size:9.0pt'>&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><s><span
  style='font-size:9.0pt;font-family:宋体'>船长</span></s><span lang=EN-US
  style='font-size:9.0pt'>/</span><span style='font-size:9.0pt;font-family:
  宋体'>申报员证书编号</span><span lang=EN-US style='font-size:9.0pt'>:</span></p>
  <p class=MsoNormal style='word-break:break-all'><u><span lang=EN-US
  style='font-size:9.0pt'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  &nbsp;&nbsp;&nbsp;</span></u><span lang=EN-US style='font-size:9.0pt'>Certificate
  No.:<u>&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</u></span></p>
  </td>
  <td width=320 colspan=4 style='width:240.35pt;border-top:none;border-left:
  none;border-bottom:solid windowtext 1.0pt;border-right:solid windowtext 1.0pt;
  padding:0cm 5.4pt 0cm 5.4pt;height:66.2pt'>
  <p class=MsoNormal align=center style='text-align:center'><span lang=EN-US
  style='font-size:9.0pt'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span><span
  style='font-size:9.0pt;font-family:宋体'>船舶</span><span lang=EN-US
  style='font-size:9.0pt'>/</span><span style='font-size:9.0pt;font-family:
  宋体'>代理人（盖章）</span></p>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ship / Agent (Seal)</span></p>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  </span><span style='font-size:9.0pt;font-family:宋体'>日期</span><span
  lang=EN-US style='font-size:9.0pt'>: </span></p>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  Date:</span></p>
  </td>
 </tr>
 <tr style='height:26.05pt'>
  <td width=1001 colspan=11 style='width:750.6pt;border:solid windowtext 1.5pt;
  border-top:none;padding:0cm 5.4pt 0cm 5.4pt;height:26.05pt'>
  <p class=MsoNormal style='margin-left:18.0pt;text-indent:-18.0pt'><span
  lang=EN-US style='font-size:12.0pt'>1.<span style='font:7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  </span></span><span style='font-size:9.0pt;font-family:宋体'>紧急联系人姓名、电话、传真、电子邮箱：</span><span
  lang=EN-US style='font-size:9.0pt'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  </span><span lang=EN-US style='font-size:12.0pt'>&nbsp;&nbsp;&nbsp;&nbsp;</span></p>
  <p class=MsoNormal><span lang=EN-US style='font-size:9.0pt'>Emergency Contact
  Person’s Name, Telephone No., Fax, and E-mail:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
  </span><span lang=EN-US>&nbsp;</span></p>
  </td>
 </tr>
 <tr height=0>
  <td width=98 style='border:none'></td>
  <td width=107 style='border:none'></td>
  <td width=95 style='border:none'></td>
  <td width=92 style='border:none'></td>
  <td width=75 style='border:none'></td>
  <td width=22 style='border:none'></td>
  <td width=123 style='border:none'></td>
  <td width=109 style='border:none'></td>
  <td width=66 style='border:none'></td>
  <td width=60 style='border:none'></td>
  <td width=154 style='border:none'></td>
 </tr>
</table>

<table class=MsoNormalTable border=0 cellspacing=0 cellpadding=0
 style='border-collapse:collapse' align="center">
    <tr>
        <td>
            <p class=MsoNormal style='line-height:12.0pt'><span style='font-size:9.0pt;
font-family:宋体'>此申报单一式三份，其中两份退申报人留持并分送港口作业部门，一份留主管机关存查。</span></p>

<p class=MsoNormal style='line-height:12.0pt'><span lang=EN-US
style='font-size:9.0pt'>This declaration should be made in tripartite, one is
kept by the Administration for file, and two for the declarer and port operator
respectively.</span></p>

<p class=MsoNormal style='text-indent:607.05pt;line-height:12.0pt'><b><span
style='font-family:宋体'>中华人民共和国海事局监</span></b></p>
        </td>
    </tr>
</table>


</div>
</div>
    <script>
        $(function () {
            $("#biuuu_button").on("click", function () {
                alert(1);
                $("#app_print").printArea();
            });
        })
        
    </script>
    <div style="text-align: center; margin-top:30px;"><a href="javascript:;" id="biuuu_button">打印申报单</a></div>
</body>
</html>
