<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AnalisaMercadosCliente.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Existing Books:<br />
    
        <asp:TextBox ID="txtBooks" runat="server" Height="90px" 
            style="text-align: left" Width="1000px" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        Books with Updates<br />
        <asp:TextBox ID="txtUpdBooks" runat="server" Height="71px" 
            TextMode="MultiLine" Width="1000px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btSend" runat="server" onclick="btSend_Click" 
            style="text-align: center" Text="Send Request" />
    
    </div>
    </form>
</body>
</html>
