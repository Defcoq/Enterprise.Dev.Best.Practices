<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Entreprise.Architecture.WebUI._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <div class="jumbotron">
            <h1> How To layering Enterprise application </h1>
            <p>
                This example explain code sample to layer entreprise application by applying good design pattern, in we use a MVP, DDD, Repository ecc..
            </p>

        </div>
    
        <asp:DropDownList AutoPostBack="true" ID="ddlCustomerType" runat="server" >
            <asp:ListItem Value="0">Standard</asp:ListItem> 
            <asp:ListItem Value="1">Trade</asp:ListItem> 
        </asp:DropDownList>
                
        <asp:Label ID="lblErrorMessage" runat="server" ></asp:Label> 
    
        <asp:Repeater ID="rptProducts" runat="server" >
            <HeaderTemplate>
                <table class="table table-striped table-bordered">
                    <tr>
                        <td>Name</td>
                        <td>RRP</td>
                        <td>Selling Price</td>
                        <td>Discount</td>
                        <td>Savings</td>
                    </tr>
                    <tr>
                        <td colspan="5"><hr /></td>
                    </tr>
            </HeaderTemplate> 
            <ItemTemplate>
                    <tr>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("RRP")%></td>
                        <td><%# Eval("SellingPrice") %></td>
                        <td><%# Eval("Discount") %></td>
                        <td><%# Eval("Savings") %></td>
                    </tr>
            </ItemTemplate> 
            <FooterTemplate>
                </table>
            </FooterTemplate> 
        </asp:Repeater>
    </div>
    </form>
</body>
</html>
