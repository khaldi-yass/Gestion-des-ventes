<%@ Page Title="Details du produit" Language="C#" MasterPageFile="~/Layout_members.master" AutoEventWireup="true" CodeFile="Details.aspx.cs" Inherits="Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="well" runat="server">
        <legend>Details sur le produit:</legend>   
        
        <div class="row container-fluid" runat="server">
            <div class="col-md-7">

                <div class="row">
                    <span class="col-md-4 control-label">Designation: </span>
                    <asp:Label ID="ldesignation" runat="server" Text="Label"></asp:Label>
                </div>
                <hr />
                <div class="row">
                    <span class="col-md-4 control-label">Prix unitaire: </span>
                    <asp:Label ID="lprix" runat="server" Text="Label"></asp:Label>
                </div>
                <hr />
                <div class="row">
                    <span class="col-md-4 control-label">Stock: </span>
                    <asp:Label ID="lstock" runat="server" Text="Label"></asp:Label>
                </div>
                <hr />
                <div class="row">
                    <span class="col-md-4 control-label">Numero de l'article: </span>
                    <asp:Label ID="lnumArticle" runat="server" Text="Label"></asp:Label>
                </div>
            </div>
            <div class="col-md-5">
                <asp:Image ID="Image1" runat="server" CssClass="img img-responsive" ImageAlign="Middle" Width="300px" />
            </div>
        </div>

        <hr />
        <div class="row text-center">
            <asp:HyperLink class="btn btn-primary" ID="HyperLink1" runat="server" NavigateUrl="~/ListCat.aspx">Retour aux articles</asp:HyperLink>
        </div>
            
    </div>
    

</asp:Content>

