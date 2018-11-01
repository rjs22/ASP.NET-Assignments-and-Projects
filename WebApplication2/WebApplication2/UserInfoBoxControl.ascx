<%@ Control ClassName="UserInfoBoxControl" Language="C#" AutoEventWireup="true" CodeBehind="~/UserInfoBoxControl.ascx.cs" Inherits="WebApplication2.UserInfoBoxControl" %>

<form>
<b>Information about <%= this.UserName %></b>
<br /><br />
<%= this.UserName %> is <%= this.UserAge %> years old and lives in <%= this.UserCountry %>
</form>