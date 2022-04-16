<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="netframeworkdemo.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <script type="text/javascript" language="javascript">
        function disbtn() {           
            document.getElementById('MainContent_btndisablecheck').setAttribute("disabled", "disabled");
    }
    </script>
    <asp:Button ID="btndisablecheck" Text="Click Me!"  runat="server" OnClick="btndisablecheck_Click" />
</asp:Content>
