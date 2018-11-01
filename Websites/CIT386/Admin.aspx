<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

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
            <h2 class="display-2 text-dark text-center">User List</h2>
            <div class="row justify-content-center">

                <asp:GridView runat="server" ID="gvUserList" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="UserID" DataSourceID="sdsUserList" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="Gainsboro" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="UserID" HeaderText="UserID" ReadOnly="True" SortExpression="UserID" />
                        <asp:BoundField DataField="UserEmail" HeaderText="UserEmail" SortExpression="UserEmail" />
                        <asp:BoundField DataField="UserFirst" HeaderText="UserFirst" SortExpression="UserFirst" />
                        <asp:BoundField DataField="UserLast" HeaderText="UserLast" SortExpression="UserLast" />
                        <asp:BoundField DataField="UserPhone" HeaderText="UserPhone" SortExpression="UserPhone" />
                        <asp:CheckBoxField DataField="IsInstructor" HeaderText="IsInstructor" SortExpression="IsInstructor" />
                        <asp:CheckBoxField DataField="IsVerified" HeaderText="IsVerified" SortExpression="IsVerified" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="sdsUserList" ConnectionString="<%$ ConnectionStrings:CIT386ConnectionString %>" DeleteCommand="DELETE FROM [User] WHERE [UserID] = @UserID" InsertCommand="INSERT INTO [User] ([UserID], [UserEmail], [UserFirst], [UserLast], [UserPhone], [IsInstructor], [IsVerified]) VALUES (@UserID, @UserEmail, @UserFirst, @UserLast, @UserPhone, @IsInstructor, @IsVerified)" SelectCommand="SELECT [UserID], [UserEmail], [UserFirst], [UserLast], [UserPhone], [IsInstructor], [IsVerified] FROM [User]" UpdateCommand="UPDATE [User] SET [UserEmail] = @UserEmail, [UserFirst] = @UserFirst, [UserLast] = @UserLast, [UserPhone] = @UserPhone, [IsInstructor] = @IsInstructor, [IsVerified] = @IsVerified WHERE [UserID] = @UserID">
                    <DeleteParameters>
                        <asp:Parameter Name="UserID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="UserID" Type="Int32" />
                        <asp:Parameter Name="UserEmail" Type="String" />
                        <asp:Parameter Name="UserFirst" Type="String" />
                        <asp:Parameter Name="UserLast" Type="String" />
                        <asp:Parameter Name="UserPhone" Type="String" />
                        <asp:Parameter Name="IsInstructor" Type="Boolean" />
                        <asp:Parameter Name="IsVerified" Type="Boolean" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="UserEmail" Type="String" />
                        <asp:Parameter Name="UserFirst" Type="String" />
                        <asp:Parameter Name="UserLast" Type="String" />
                        <asp:Parameter Name="UserPhone" Type="String" />
                        <asp:Parameter Name="IsInstructor" Type="Boolean" />
                        <asp:Parameter Name="IsVerified" Type="Boolean" />
                        <asp:Parameter Name="UserID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>

            <h2 class="display-2 text-dark text-center">Schedule</h2>
            <div class="row justify-content-center">
                <asp:GridView runat="server" ID="gvSchedule" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="AppointmentID" DataSourceID="sdsSchedule" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="AppointmentID" HeaderText="AppointmentID" ReadOnly="True" SortExpression="AppointmentID" />
                        <asp:BoundField DataField="StudentID" HeaderText="StudentID" SortExpression="StudentID" />
                        <asp:BoundField DataField="InstructorID" HeaderText="InstructorID" SortExpression="InstructorID" />
                        <asp:BoundField DataField="RoomID" HeaderText="RoomID" SortExpression="RoomID" />
                        <asp:BoundField DataField="AppointmentDate" HeaderText="AppointmentDate" SortExpression="AppointmentDate" />
                        <asp:BoundField DataField="AppointmentDescription" HeaderText="AppointmentDescription" SortExpression="AppointmentDescription" />
                        <asp:BoundField DataField="AppointmentComplete" HeaderText="AppointmentComplete" SortExpression="AppointmentComplete" />
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
                <asp:SqlDataSource runat="server" ID="sdsSchedule" ConnectionString="<%$ ConnectionStrings:CIT386ConnectionString %>" DeleteCommand="DELETE FROM [Appointment] WHERE [AppointmentID] = @AppointmentID" InsertCommand="INSERT INTO [Appointment] ([AppointmentID], [StudentID], [InstructorID], [RoomID], [AppointmentDate], [AppointmentDescription], [AppointmentComplete]) VALUES (@AppointmentID, @StudentID, @InstructorID, @RoomID, @AppointmentDate, @AppointmentDescription, @AppointmentComplete)" SelectCommand="SELECT * FROM [Appointment]" UpdateCommand="UPDATE [Appointment] SET [StudentID] = @StudentID, [InstructorID] = @InstructorID, [RoomID] = @RoomID, [AppointmentDate] = @AppointmentDate, [AppointmentDescription] = @AppointmentDescription, [AppointmentComplete] = @AppointmentComplete WHERE [AppointmentID] = @AppointmentID">
                    <DeleteParameters>
                        <asp:Parameter Name="AppointmentID" Type="Int32" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="AppointmentID" Type="Int32" />
                        <asp:Parameter Name="StudentID" Type="Int32" />
                        <asp:Parameter Name="InstructorID" Type="Int32" />
                        <asp:Parameter Name="RoomID" Type="Int32" />
                        <asp:Parameter Name="AppointmentDate" Type="DateTime" />
                        <asp:Parameter Name="AppointmentDescription" Type="String" />
                        <asp:Parameter Name="AppointmentComplete" Type="DateTime" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="StudentID" Type="Int32" />
                        <asp:Parameter Name="InstructorID" Type="Int32" />
                        <asp:Parameter Name="RoomID" Type="Int32" />
                        <asp:Parameter Name="AppointmentDate" Type="DateTime" />
                        <asp:Parameter Name="AppointmentDescription" Type="String" />
                        <asp:Parameter Name="AppointmentComplete" Type="DateTime" />
                        <asp:Parameter Name="AppointmentID" Type="Int32" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
        </div>
    </form>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>
</body>
</html>
