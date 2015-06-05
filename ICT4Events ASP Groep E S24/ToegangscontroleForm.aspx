<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToegangscontroleForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.ToegangscontroleForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Toegangscontrole</title>
    <link rel="stylesheet" type="text/css" href="stylesheet.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label2" runat="server" Font-Size="Medium" Text="Toegangscontrole"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Aanwezigen:"></asp:Label>
        <asp:Label ID="LabelAanwezigen" runat="server" Text="0"></asp:Label>
    
    </div>
        <asp:ListBox ID="ListBoxAanwezig" runat="server" Height="120px" style="margin-bottom: 0px; margin-left: 0px;" Width="300px"></asp:ListBox>
    
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label3" runat="server" Text="Afwezigen: "></asp:Label>
        <asp:Label ID="LabelAfwezig" runat="server" Text="0"></asp:Label>
        <br />
        <asp:ListBox ID="ListBoxAfwezig" runat="server" Height="120px" Width="300px"></asp:ListBox>
        <br />
        <br />
        Wanneer de barcodescanner niet werkt, kunt u altijd nog handmatig inchecken!<br />
        <br />
        Barcode:<br />
        <asp:TextBox ID="TextBoxCheckIn" runat="server" Width="300px"></asp:TextBox>
        <asp:Button ID="ButtonCheckInUit" runat="server" style="margin-left: 0px" Text="Check In/Uit" OnClick="ButtonCheckInUit_Click" />
    </form>
</body>
</html>
