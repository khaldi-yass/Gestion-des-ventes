<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TestAjax.aspx.cs" Inherits="Tests_TestAjax" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h1 style="height: 128px">
                    <asp:Label ID="Label1" runat="server" style="font-size: x-large; color: #FF6699" Text="Hello world"></asp:Label>
                </h1>
                <h1 style="height: 128px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Internal button" />
                </h1>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="DropDownList1" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="External button" />
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem>Hello</asp:ListItem>
                <asp:ListItem>World</asp:ListItem>
            </asp:DropDownList>
        </p>
    </div>
    </form>
</body>
</html>
