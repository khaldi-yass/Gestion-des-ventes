<%@ Page Title="Liste des catalogues" EnableViewState="false" Language="C#" MasterPageFile="~/Layout_members.master" AutoEventWireup="true" CodeFile="ListCat.aspx.cs" Inherits="ListCat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <div class="well" runat="server">
        <legend>Liste des catalogues</legend> 
        
        <div class="row">
            <label class="control-label col-md-3">Selectionner une categorie</label>
            <asp:DropDownList class="form-control col-md-3" ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="update_table"></asp:DropDownList>   
        </div>

        <br />

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Literal ID="tableLiteral" runat="server">Hello world</asp:Literal>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>     
                               
    </div>

</asp:Content>

