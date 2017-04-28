<%@ Page Title="Connexion" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container" runat="server">
        <div class="row" runat="server">
            <asp:Label ID="errorLabel" class="col-md-6 col-md-offset-3" runat="server" style="font-size: large; font-weight: 700; color: #FF0000"></asp:Label>
        </div>
        
        <div class="row" runat="server">
            <form id="form1" runat="server" class="form-horizontal well col-md-8 col-md-offset-2">
                <fieldset>
                    <legend>Authentification</legend>

                    <div class="row">
                        <asp:Label class="col-md-4 control-label" ID="Label1" runat="server" Text="Login"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control" ID="tLogin" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator class="col-md-4 control-label" ID="RequiredFieldValidator1" runat="server" ControlToValidate="tLogin" Display="Dynamic" ErrorMessage="Login obligatoire" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                   <div class="row">
                        <asp:Label class="col-md-4 control-label" ID="Label2" runat="server" Text="Mot de passe:"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control" ID="tPass" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator class="col-md-4 control-label" ID="RequiredFieldValidator2" runat="server" ControlToValidate="tPass" Display="Dynamic" ErrorMessage="Mot de passe obligatoire" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <br />
                    <div class="row col-md-offset-4">
                        <asp:Button class="btn btn-success" ID="Blogin" runat="server" OnClick="Blogin_Click" Text="Connexion" />
                        <input class="btn btn-default" id="Reset1" type="reset" value="reset" />
                    </div>

                    <hr />
                    <div class="row text-center">
                        <asp:HyperLink ID="registerLink" runat="server" NavigateUrl="~/Register.aspx">Pas encore membre?</asp:HyperLink>
                    </div>
                </fieldset>
    </form>
        </div>
    </div>
    


</asp:Content>

