<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Enterprise.Architecture.TS.WebUI._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="row">
    
        <div class="jumbotron col-sm-11 col-sm-offset-1">
            <h1> Transaction script BLL Pattern</h1>
            <p>
              One of the strengths of the Transaction Script pattern is that it is simple to understand; it can be fast
to get new team members up to speed without prior knowledge of the pattern. As new requirements
arise, it is easy to add more methods to the class without fear of impacting or breaking existing
functionality.</p>
<p>The Transaction Script Pattern is a great for small applications with little or no logic that are not
likely to grow in feature set, and for teams with junior developers who are not comfortable with
object oriented programming concepts.
</p>

        </div>
        <div class="col-sm-10 col-sm-offset-1">
            <img src="Content/Transaction_Script_Diagram_View.png" />
        </div>
        <div class="col-sm-8 col-sm-offset-1">
             <fieldset>
            <legend>Create Employee</legend>                 
            <p>        
            Name
            <br />
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            </p>
            <p>
            Holiday entitlement
            <br />
            <asp:TextBox ID="txtEntitlement" runat="server"></asp:TextBox>                               
            </p>
            <p>
            <asp:Button ID="btnAddEmployee" runat="server" Text="Add Employee" onclick="btnAddEmployee_Click" />
            </p>
        </fieldset>
        
        <fieldset>
            <legend>Employees</legend>          
                <asp:DropDownList ID="ddlEmployees" runat="server" AutoPostBack="true"
                        onselectedindexchanged="ddlEmployees_SelectedIndexChanged">                                               
                </asp:DropDownList>
                <br />
            <br />
            Holidays Booked<br />
            <asp:Repeater ID="rptHolidaysBooked" runat="server">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <td>From </td>
                            <td>To</td>
                            <td>Day(s) taken</td>
                        </tr>
                </HeaderTemplate> 
                <ItemTemplate>
                        <tr>
                            <td><%# Eval("From", "{0:d}") %></td>
                            <td><%# Eval("To", "{0:d}")%></td>
                            <td><%# Eval("DaysTaken") %></td>
                        </tr>
                </ItemTemplate> 
                <FooterTemplate>
                    </table>
                </FooterTemplate> 
            </asp:Repeater>
                <p>
                Book Holiday
                </p>
                <p>
                <table>
                    <tr>
                        <td>From</td>
                        <td>To</td>
                    </tr>
                    <tr>
                        <td><asp:Calendar ID="calFrom" runat="server"></asp:Calendar></td>
                        <td><asp:Calendar ID="calTo" runat="server"></asp:Calendar></td>
                    </tr>
                </table>     
                <asp:Button ID="btnBookHoliday" runat="server" Text="Book Holiday" 
                        onclick="btnBookHoliday_Click" />                                 
                </p>
                <p>
                    <strong><asp:Label ID="lblBookingResult" runat="server"></asp:Label></strong>
                </p>
        </fieldset>        

        </div>
       
    
    </div>    
    </form>
</body>
</html>
