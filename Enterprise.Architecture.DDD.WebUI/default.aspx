<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Enterprise.Architecture.DDD.WebUI._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
</head>
<body>
    <div class="row">
        <div class ="col-sm-10 col-sm-offset-1 jumbotron">
            <h2>Domain Driven Design Pattern Architecture Sample : Account Banking system</h2>
            <p>
                The Domain Model project will contain all of the
business logic within the application. Domain objects will live in here and will have relationships
to other objects to represent the banking domain the application is built around. The
project will also deﬁne contracts in the form of interfaces for domain object persistence and
retrieval; the Repository pattern will be employed for all persistence management needs. The Model project will not
have a reference to any other project ensuring, it remains free of any infrastructure concerns
and focuses squarely on the business domain.
            </p>
            <p>
                The Repository project will contain implementations
of the repository interfaces deﬁned in the Model project. The Repository has a
reference to the Model project in order to hydrate domain objects from the database as well
as to persist. The Repository project is concerned only with the responsibility of domain
object persistence and retrieval.
            </p>

            <p>
                The AppService project will act as the gateway into the application—the API if you will. The presentation layer will communicate with
the AppService via messages, which are simple data transfer objects. The AppService layer will also deﬁne view models, which
are ﬂattened views of the domain model used solely for the displaying of data.
            </p>

            <p>
                The UI.Web project is responsible for the
presentation and use experience needs of the application. This project talks only to the
AppService and receives strongly typed view models that have been created speciﬁcally for
the views of the user experience.
            </p>
            <h2>Entitiees</h2>
            <p>
                Entities are the things discussed previously in the Domain Model section, such as an order, customer,
and product in an e-commerce site and a blog, and post objects in a blogging application.
They encompass the data and behavior of the real entity in an abstract manner. Any logic pertaining
to an entity should be contained within it. Entities are the things that require an identity, which
will remain with it throughout its lifetime. Consider a borrower in terms of a loan application; a
borrower has a name, but names can change and can be duplicated, so you need to add a separate
identity that will stay with the borrower through its life in the loan application regardless of a name,
job, or address change. Typically, a system uses some kind of unique identiﬁer or auto-numbering
value for any entities that don’t have a natural way to identify them. Sometimes entities do have natural
keys, such as a Social Security number or an employee number. Not all the objects in your domain
model are unique and require an identity. For some objects, it’s the data that is of most importance,
not identity; these objects are called value objects.

            </p>
            <h2> values object</h2>
            <p>
                Value objects have no identity; they are of value because of their attributes only. Value objects generally
don’t live on their own; they are typically, but not always, attributes of an entity. If you cast
your mind back to the simple Bank Account application that you worked on in the Domain Model,
you remember that the Transaction object had no identity because it exists only in terms of the
Bank Account that it is associated with; it is a value object because, in this context, it doesn’t exist
on its own.

            </p>

            <h2>
Aggregate and aggregate root
            </h2>
            <p>
                Big systems or complex domains can have hundreds of entity and value objects, which have complex
relationships. The domain model needs a method of managing these associations; more importantly,
logical groups of entities and value objects need to deﬁne an interface that lets other entities work
with them. Without such a structure, the interaction between groups of objects can be confusing
and lead to problems later.

            </p>
        </div>
        <div class="col-sm-10 col-sm-offset-1">
            <img src="Content/DDD_Pattern_Diagram.png" />
        </div>

        <div class="col-lg-10 col-sm-offset-1">
            <form id="form1" runat="server">
    <div>
     
     <fieldset>
        <legend>Create New Account</legend>    
     <p>        
        Customer Ref:
        <asp:TextBox ID="txtCustomerRef" runat="server"></asp:TextBox>
                
        <asp:Button ID="btCreateAccount" runat="server" Text="Create Account" 
            onclick="btCreateAccount_Click" />
    </p>
    </fieldset>
    
    <fieldset>
        <legend>Account Detail</legend> 
        <p>
        <asp:DropDownList AutoPostBack="true" ID="ddlBankAccounts" runat="server" 
                onselectedindexchanged="ddlBankAccounts_SelectedIndexChanged"></asp:DropDownList>
        </p>        
        <p>
            Account No:
            <asp:Label ID="lblAccountNo" runat="server" />
        </p>
        <p>
            Customer Ref:
            <asp:Label ID="lblCustomerRef" runat="server" />
        </p>
        <p>
            Balance:
            <asp:Label ID="lblBalance" runat="server" />
        </p>
        <p>
            Amount
        £<asp:TextBox ID="txtAmount" runat="server" Width="60px"></asp:TextBox>
                
        &nbsp;<asp:Button ID="btnWithdrawal" runat="server" Text="Withdrawal" 
                onclick="btnWithdrawal_Click" />
        &nbsp;<asp:Button ID="btnDeposit" runat="server" Text="Deposit" 
                onclick="btnDeposit_Click" />
        </p>
        <p>
            Transfer
        £<asp:TextBox ID="txtAmountToTransfer" runat="server" Width="60px"></asp:TextBox>
                
        &nbsp;to
        <asp:DropDownList AutoPostBack="true" ID="ddlBankAccountsToTransferTo" runat="server"></asp:DropDownList>
        &nbsp;<asp:Button ID="btnTransfer" runat="server" Text="Commit" 
                onclick="btnTransfer_Click" />
        </p>
        <p>
            Transactions</p>
            <asp:Repeater ID="rptTransactions" runat="server">        
                <HeaderTemplate>
                    <table class="table table-striped table-bordered">
                    <tr>
                        <td>deposit</td>
                        <td>withdrawal</td>
                        <td>reference</td>
                    </tr>
                </HeaderTemplate> 
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Deposit")  %></td>
                        <td><%# Eval("Withdrawal")  %></td>
                        <td><%# Eval("Reference")  %></td>                
                        <td><%# Eval("Date")  %></td>
                    </tr>
                </ItemTemplate> 
                <FooterTemplate>
                    </table>
                </FooterTemplate>   
            </asp:Repeater>
    </fieldset>    
    </div> 
    </form>
        </div>
    </div>
    
</body>
</html>
