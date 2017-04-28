<%@ Page Title="Liste des catalogues" Language="C#" MasterPageFile="~/Layout_members.master" AutoEventWireup="true" CodeFile="ListCat.aspx.cs" Inherits="ListCat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="well" runat="server">
        <legend>Liste des catalogues</legend>   
        <table class="table table-bordered table-hover table-striped table-responsive table-condensed">
		    <thead>
			    <tr class="info"> <th>Designations</th> <th>Prix unitaire (Dh)</th> <th>Photo de produit</th> <th>Details</th> </tr>
		    </thead>
		    <tbody>
                <asp:Literal ID="tableLiteral" runat="server"></asp:Literal>
		    </tbody>
	    </table>
    </div>

    <asp:Button class="btn btn-sm btn-danger" ID="Button1" runat="server" Text="Deconnection" OnClick="Button1_Click" />

</asp:Content>

