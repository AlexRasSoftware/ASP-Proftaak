﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MateriaalverhuurForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.MateriaalverhuurForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="stylesheet.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Materiaal Verhuur</h1>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Type Huuritem"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlHuurItemType" runat="server" Width="133px" AutoPostBack="True" OnSelectedIndexChanged="ddlHuurItemType_SelectedIndexChanged" >
        </asp:DropDownList>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Merk"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlMerken" runat="server" Width="136px" AutoPostBack="True" OnSelectedIndexChanged="ddlMerken_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        Volgnummer<br />
        <asp:DropDownList ID="ddlVolgnummers" runat="server" Width="136px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnKiesHuurItem" runat="server" Height="38px" style="margin-left: 0px" Text="Kies" Width="85px" OnClick="btnKiesHuurItem_Click" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Gekozen Items"></asp:Label>
        <br />
        <asp:ListBox ID="lbGekozenItems" runat="server" Height="234px" style="margin-left: 0px" Width="426px"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="btnVerwijderItem" runat="server" Text="Verwijder Item" />
        <br />
        <asp:Button ID="btnBevestig" runat="server" Text="Bevestigen" />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
