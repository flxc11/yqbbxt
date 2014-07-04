<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="userheader.ascx.cs" Inherits="CNVP.WebSite.control.userheader1" %>
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