<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="cit386final.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" >Zipcode:</asp:Label>
            <br />
            <asp:TextBox runat="server" ID="txtsearch"></asp:TextBox>
            <asp:Button runat="server" ID="btnsearch" Text="search" OnClick="btnsearch_Click" />
            <br />
            <asp:Label runat="server" ID="lblstcity" Visible="false"></asp:Label>
            <br />
            <asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
            <br />
            <asp:Label runat="server" ID="lblnumber" Visible="false"></asp:Label>
            <br />
            <asp:Image runat="server" ID="imgState" Visible="false" />
        </div>
    </form>
</body>
</html>
