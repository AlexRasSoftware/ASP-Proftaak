<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToegangscontroleForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.ToegangscontroleForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label2" runat="server" Font-Size="XX-Large" Text="Toegangscontrole"></asp:Label>
        <br />
        <asp:Label ID="Label1" runat="server" Text="Aanwezigen:"></asp:Label>
&nbsp;<asp:Label ID="LabelAanwezigen" runat="server" Text="0"></asp:Label>
        <br />
        <asp:ListBox ID="ListBoxAanwezig" runat="server" Height="120px" style="margin-bottom: 0px" Width="300px"></asp:ListBox>
    
    </div>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="Label3" runat="server" Text="Afwezigen: "></asp:Label>
        <asp:Label ID="LabelAfwezig" runat="server" Text="0"></asp:Label>
        <br />
        <asp:ListBox ID="ListBoxAfwezig" runat="server" Height="120px" Width="300px"></asp:ListBox>
        <asp:Label ID="Label4" runat="server" Text="Lijsten sorteren op:"></asp:Label>
        <asp:Button ID="ButtonSorteerRFID" runat="server" style="margin-left: 12px" Text="RFID" />
        <asp:Button ID="ButtonSorteerNaam" runat="server" style="margin-left: 13px" Text="Naam" />
        <br />
        <br />
        Wanneer de barcodescanner niet werkt, kunt u altijd nog handmatig inchecken!<br />
        <br />
        Barcode:<br />
        <asp:TextBox ID="TextBoxCheckIn" runat="server" Width="300px"></asp:TextBox>
        <asp:Button ID="ButtonCheckInUit" runat="server" style="margin-left: 27px" Text="Check In/Uit" />
    </form>
</body>
</html>
