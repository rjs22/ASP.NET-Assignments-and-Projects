<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

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
                    <%-- Registration form --%>
                    <ul class="list-unstyled">
                        <li>
                            <h2 class="display-2 text-dark">Registration</h2>
                        </li>
                        <li>
                            <p>
                                <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
                            </p>
                        </li>
                        <li>
                            <asp:Label runat="server" CssClass="form-control-label text-dark">ID Number</asp:Label>

                            <asp:TextBox ID="txtID" runat="server" CssClass="form-control" />

                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="^\d{9}$"
                                ControlToValidate="txtID" ForeColor="Red" ErrorMessage="Value must be 9 numeric digits, no dashes or spaces" ValidationGroup="register" />

                            <asp:RequiredFieldValidator ID="reqID" ErrorMessage="Please enter valid ID number, no dashes or spaces" Display="Dynamic" ForeColor="Red"
                                ControlToValidate="txtID" runat="server" ValidationGroup="register" />
                        </li>

                        <li>
                            <asp:Label runat="server" CssClass="form-control-label text-dark">Email</asp:Label>

                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />

                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." ValidationGroup="register" />

                            <asp:RequiredFieldValidator ID="reqEmail" ErrorMessage="Please enter valid email" Display="Dynamic" ForeColor="Red"
                                ControlToValidate="txtEmail" runat="server" ValidationGroup="register" />

                        </li>
                        <li>
                            <asp:Label runat="server" CssClass="form-control-label text-dark">Password</asp:Label>

                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" />

                            <asp:RegularExpressionValidator runat="server" Display="Dynamic" ValidationExpression="^[\s\S]{8,}$"
                                ControlToValidate="txtPassword" ForeColor="Red" ErrorMessage="Minimum 8 characters required." ValidationGroup="register" />

                            <asp:RequiredFieldValidator ID="reqPass" ErrorMessage="Please enter a password" ForeColor="Red" ControlToValidate="txtPassword"
                                runat="server" ValidationGroup="register" />

                        </li>
                        <li>
                            <asp:Label runat="server" CssClass="form-control-label text-dark">Confirm Password</asp:Label>

                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" />

                            <asp:RequiredFieldValidator ID="reqConfPass" ErrorMessage="Please confirm your password" ForeColor="Red" ControlToValidate="txtConfirmPassword"
                                runat="server" ValidationGroup="register" />

                            <asp:CompareValidator ID="cmpPass" ErrorMessage="Passwords do not match." ForeColor="Red" ControlToCompare="txtPassword"
                                ControlToValidate="txtConfirmPassword" runat="server" ValidationGroup="register" />

                            <asp:Button ID="btnSubmit" ValidationGroup="register" CausesValidation="true" CssClass="mx-auto mt-5 btn btn-secondary " OnClick="BtnRegister_Click" Text="Submit" runat="server" />
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>
</body>
</html>
