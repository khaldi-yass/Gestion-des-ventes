<%@ Page Title="Convertisseur" Language="C#" MasterPageFile="~/Layout_members.master" AutoEventWireup="true" CodeFile="Convertisseur.aspx.cs" Inherits="Convertisseur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="well" runat="server">
        <legend>Convertisseur de devise</legend>

        <div class="row">
           <div class="col-md-6">
                <asp:Label class="control-label col-md-6" ID="Label1" runat="server" Text="Devise d'entrée"></asp:Label>
               <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
           </div>

            <div class="col-md-6">
                <asp:Label class="control-label col-md-6" ID="Label2" runat="server" Text="Devise de sortie"></asp:Label>
               <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server"></asp:TextBox>
           </div>
        </div>

        <hr />
        <div class="row text-center">
            <asp:Button CssClass="btn btn-success" ID="Button1" runat="server" Text="Convertir" />
       </div>
        <hr />
       <div class="row text-center">
           <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" Enabled="false"></asp:TextBox>
       </div>
    </div>


</asp:Content>

