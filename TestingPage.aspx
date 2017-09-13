<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestingPage.aspx.cs" Inherits="TestingCSV.TestingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            
            <br />
<asp:Button ID="Button1" runat="server" Text="Import" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Export to text file" Width="118px" />
            <br />
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
