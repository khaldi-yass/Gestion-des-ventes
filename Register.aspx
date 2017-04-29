<%@ Page Title="Inscription" Language="C#" MasterPageFile="~/Layout.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container" runat="server">
        
        <div class="row" runat="server">
            <form id="form1" runat="server" class="form-horizontal well col-md-8 col-md-offset-2">
                <fieldset>
                    <legend>Formulaire d'inscription</legend>
                    
                   <div class="row">
                       <asp:Label class="col-md-4 control-label" ID="Label2" runat="server" Text="Nom:"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control" ID="tnom" runat="server"></asp:TextBox>
                        </div>
                       <asp:RequiredFieldValidator class="col-md-4 control-label" ID="RequiredFieldValidator1" runat="server" ControlToValidate="tnom" Display="Dynamic" ErrorMessage="Nom requis!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="row">
                        <asp:Label class="col-md-4 control-label" ID="Label3" runat="server" Text="Prenom:"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control" ID="tprenom" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator class="col-md-4 control-label" ID="RequiredFieldValidator2" runat="server" ControlToValidate="tprenom" ErrorMessage="Prenom requis!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="row">
                        <asp:Label class="col-md-4 control-label" ID="Label4" runat="server" Text="Login:"></asp:Label>
                        <div class="col-md-4">
                        <asp:TextBox class="form-control" ID="tlogin" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator class="col-md-4 control-label" ID="RequiredFieldValidator4" runat="server" ControlToValidate="tlogin" ErrorMessage="Login requis!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="row">
                    <asp:Label class="col-md-4 control-label" ID="Label5" runat="server" Text="Mot de passe:"></asp:Label>
                        <div class="col-md-4">
                        <asp:TextBox class="form-control" ID="tpass" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator class="col-md-4 control-label" ID="RequiredFieldValidator5" runat="server" ControlToValidate="tpass" Display="Dynamic" ErrorMessage="Mot de passe requis!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="row">
                    <asp:Label class="col-md-4 control-label" ID="Label6" runat="server" Text="Resaisir le mot de passe:"></asp:Label>
                        <div class="col-md-4">
                        <asp:TextBox class="form-control" ID="tcheckpass" runat="server" TextMode="Password"></asp:TextBox>
                        </div>
                        <asp:CompareValidator class="col-md-4 control-label" ID="CompareValidator1" runat="server" ControlToCompare="tpass" ControlToValidate="tcheckpass" ErrorMessage="Mots de passes non identiques!" ForeColor="Red"></asp:CompareValidator>
                    </div>

                    <div class="row">
                        <asp:Label class="col-md-4 control-label" ID="Label7" runat="server" Text="Email"></asp:Label>
                        <div class="col-md-4">
                        <asp:TextBox class="form-control" ID="temail" runat="server"></asp:TextBox>
                        </div>

                        <asp:RequiredFieldValidator class="col-md-4 control-label" ID="RequiredFieldValidator3" runat="server" ControlToValidate="temail" Display="Dynamic" ErrorMessage="Email requis!" ForeColor="Red"></asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator class="col-md-4 control-label" ID="RegularExpressionValidator1" runat="server" ControlToValidate="temail" ErrorMessage="Veuillez entrer un email valide!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </div>

                    <div class="row">
                        <asp:Label class="col-md-4 control-label" ID="Label8" runat="server" Text="Ville:"></asp:Label>
                        <div class="col-md-4">
                            <asp:DropDownList class="form-control" ID="SelectVille" runat="server" OnSelectedIndexChanged="SelectVille_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <asp:RequiredFieldValidator class="col-md-4 control-label" ID="RequiredFieldValidator6" runat="server" ControlToValidate="SelectVille" Display="Dynamic" ErrorMessage="Ville requis!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>

                    <div class="row">
                    <asp:Label class="col-md-4 control-label" ID="Label9" runat="server" Text="Telephone:"></asp:Label>
                        <div class="col-md-4">
                            <asp:TextBox class="form-control" ID="ttel" runat="server"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator class="col-md-4 control-label" ID="RequiredFieldValidator7" runat="server" ControlToValidate="ttel" ErrorMessage="Telephone requis!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>


                    <br />
                    <div class="row col-md-offset-4">
                        <asp:Button class="btn btn-success"   ID="Button1" runat="server" OnClick="Button1_Click" Text="S'enregister" />
                        <input class="btn btn-default" id="Reset1" type="reset" value="Vider" /></td>
                    </div>

                    <hr />
                    <div class="row text-center">
                        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Login.aspx">Deja membre?</asp:HyperLink>
                    </div>
                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>