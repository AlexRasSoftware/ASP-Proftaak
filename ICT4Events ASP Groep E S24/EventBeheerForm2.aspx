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
        <asp:ImageButton ID="imbtnCalendarStart" runat="server" Height="24px" ImageUrl="~/Plaatjes/CalendarImg.png" OnClick="imbtnCalendarStart_Click" Width="24px" />
        <asp:Calendar ID="calStart" runat="server" OnSelectionChanged="calStart_SelectionChanged" Visible="False"></asp:Calendar>
        <br />
        Datum Eind:
        <asp:TextBox ID="tbEvDaEind" runat="server"></asp:TextBox>
        <asp:ImageButton ID="imbtnCalendarEind" runat="server" Height="24px" ImageUrl="~/Plaatjes/CalendarImg.png" OnClick="imbtnCalendarEind_Click" Width="24px" />
        <asp:Calendar ID="calEind" runat="server" OnSelectionChanged="calEind_SelectionChanged" Visible="False"></asp:Calendar>
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
