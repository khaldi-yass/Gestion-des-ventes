<%@ Page Title="Votre panier" Language="C#" MasterPageFile="~/Layout_members.master" AutoEventWireup="true" CodeFile="Panier.aspx.cs" Inherits="Panier" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="well" runat="server">
        <legend>Votre panier</legend> 
        
        <asp:GridView CssClass="table table-bordered table-hover table-striped table-responsive table-condensed" ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" AllowSorting="True" Visible="true">
            <Columns>
                <asp:BoundField DataField="designation" HeaderText="Designation" SortExpression="designation" />
                <asp:BoundField DataField="prixU" HeaderText="Prix unitaire (DH)" SortExpression="prixU" />
                <asp:ImageField DataImageUrlField="photo" HeaderText="Photo article">
                </asp:ImageField>
                <asp:BoundField DataField="qteArticle" HeaderText="Quantité" SortExpression="qteArticle" />
                <asp:BoundField DataField="dateCmd" HeaderText="Date de commande" SortExpression="dateCmd" />
            </Columns>
            <RowStyle Width="150px" />
        </asp:GridView>
                               
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:conString %>" SelectCommand="SELECT a.designation, a.prixU, a.photo, c.qteArticle, c.dateCmd FROM commande AS c INNER JOIN article AS a ON c.numArticle = a.numArticle WHERE (c.numClient = (SELECT numClient FROM client WHERE (login = @login)))" >
            <SelectParameters>
                <asp:SessionParameter Name="login" SessionField="login" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
                               
    </div>



</asp:Content>

