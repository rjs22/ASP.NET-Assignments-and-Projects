<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.2.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="CustStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <div class="container-fluid">
        <div class="row">
            <div class="mx-auto">
                <%-- ASPX login cotrol --%>
                <checkboxstyle cssclass="form-control-label text-light" horizontalalign="Center" />
                <labelstyle cssclass="form-control-label text-light" verticalalign="Middle" />
                <table cellspacing="0" cellpadding="1" style="border-collapse: collapse;">
                    <tr>
                        <td>
                            <table cellpadding="0">
                                <tr>
                                    <td class=" display-2 text-light" align="center" colspan="2" style="border-width: 3px; border-style: solid; height: 75px;">Log In</td>
                                </tr>
                                <tr>
                                    <td class="form-control-label text-light" align="right" valign="middle">
                                        <asp:Label runat="server" AssociatedControlID="Email" ID="UserNameLabel">Email:</asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="form-control mt-3 ml-1 text-dark" ID="Email"></asp:TextBox>

                                        <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                            ControlToValidate="Email" ForeColor="Red" ErrorMessage="Invalid email address." ValidationGroup="login" />

                                        <asp:RequiredFieldValidator CssClass="text-danger" runat="server" ControlToValidate="Email" ErrorMessage="Email is required."
                                            ValidationGroup="login" ID="UserNameRequired">*Email is required</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="form-control-label text-light" align="right" valign="middle">
                                        <asp:Label runat="server" AssociatedControlID="Password" ID="PasswordLabel">Password:</asp:Label></td>
                                    <td>
                                        <asp:TextBox runat="server" TextMode="Password" CssClass="form-control mt-3 ml-1 text-dark" ID="Password"></asp:TextBox>
                                        
                                        <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="^[\s\S]{8,}$"
                                            ControlToValidate="Password" ForeColor="Red" ErrorMessage="Minimum 8 characters required." ValidationGroup="login" />
                                        
                                        <asp:RequiredFieldValidator CssClass="text-danger" runat="server" ControlToValidate="Password" ErrorMessage="Password is required."
                                            ValidationGroup="login" ID="PasswordRequired">*Password is required</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="form-control-label text-light" align="center" colspan="2">
                                        <asp:CheckBox runat="server" Text="Remember me next time." ID="RememberMe"></asp:CheckBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button runat="server" Text="Log In" ValidationGroup="login" CausesValidation="true"
                                            CssClass="btn btn-secondary mr-3 mt-2" Width="250px" ID="LoginButton" OnClick="LoginButton_Click"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: Red;"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <titletextstyle cssclass=" display-2 text-light" borderwidth="3px" height="75px" />
                <textboxstyle cssclass="form-control mt-3 ml-1 text-light" />
                <loginbuttonstyle cssclass=" btn btn-secondary mr-3 mt-2" width="250px" />
                <a href="Register.aspx" class="text-secondary" style="margin-left: 50px;">Not a member? Register now!</a>
            </div>
        </div>
    </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>
</body>
</html>
