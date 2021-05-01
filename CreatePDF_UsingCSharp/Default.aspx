<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CreatePDF_UsingCSharp.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Using iTextSharp</title>
</head>
<body>
    <h3>Using iTextSharp</h3>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="btnReport" runat="server" Text="Generate Report" OnClick = "GeneratePDF" />
    </div>
    <br />
    <div>
    <asp:Button ID="Button1" runat="server" Text="Generate Table Report" OnClick = "GenerateTablePDF" />
    </div>
    </form>
</body>
</html>
