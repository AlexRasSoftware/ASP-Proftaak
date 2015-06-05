<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MediaSharingForm.aspx.cs" Inherits="ICT4Events_ASP_Groep_E_S24.MediaSharingForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MediaSharing</title>
    <link rel="stylesheet" type="text/css" href="stylesheet.css">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <asp:RadioButton ID="RadioButton1" runat="server" OnCheckedChanged="RadioButton1_CheckedChanged" Text="Alles" />
        <asp:RadioButton ID="RadioButton2" runat="server" Text="Berichten" />
        <asp:RadioButton ID="RadioButton3" runat="server" Text="Foto's" />
        <asp:RadioButton ID="RadioButton4" runat="server" Text="Video" />
        <asp:RadioButton ID="RadioButton5" runat="server" Text="Muziek" />
    
    </div>
        <asp:ListBox ID="ListBox1" runat="server" Height="158px" Width="286px"></asp:ListBox>
        <br />
        <asp:Button ID="Button3" runat="server" Text="Like" />
        <asp:Button ID="Button4" runat="server" Text="Reageer en meer" style="margin-left: 26px" />
        <br />
        <p>
            Nieuwe post</p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server" Width="208px"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Upload Bestand" />
        <asp:Button ID="Button2" runat="server" Text="Plaats post" />
        <br />
        <br />
        Zoeken<br />
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </form>
</body>
</html>
