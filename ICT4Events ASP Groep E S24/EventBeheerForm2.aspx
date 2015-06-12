<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventBeheerForm2.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.EventBeheerForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h3>Pas event aan</h3>
        <br />
        Naam:
        <asp:TextBox ID="tbEvNaam" runat="server"></asp:TextBox>
        <br />
        Datum Start: <asp:TextBox ID="tbEvDatStart" runat="server"></asp:TextBox>
        <br />
        Datum Eind:
        <asp:TextBox ID="tbEvDaEind" runat="server"></asp:TextBox>
        <br />
        Locatie:
        <asp:TextBox ID="tbEvLocatie" runat="server"></asp:TextBox>
    
        <br />
        <br />
        <asp:Button ID="btnPasEvAan" runat="server" Text="Pas Aan" />
        <br />
    
    </div>

    <div>

    </div>
    </form>
</body>
</html>
