<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<%@ Register TagPrefix="My" TagName="UserInfoBoxControl" Src="~/UserInfoBoxControl.ascx"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="HelloWorldLabel"></asp:Label>
            <br /><br />
            <asp:TextBox runat="server" ID="TextInput" />
            <asp:Button runat="server" ID="GreenButton" Text="Say Hello!" OnClick="GreenButton_Click" />
            <asp:DropDownList runat="server" id="GreetList" autopostback="true" onselectedindexchanged="GreetList_SelectedIndexChanged">
                <asp:ListItem value="no one">No one</asp:ListItem>
                <asp:ListItem value="world">World</asp:ListItem>
                <asp:ListItem value="universe">Universe</asp:ListItem>
            </asp:DropDownList>
            
        </div>
    </form>
</body>
</html>
