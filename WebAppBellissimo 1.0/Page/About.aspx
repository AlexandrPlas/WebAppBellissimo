<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" type="text/css" href="/css/about.css" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentMenuBox" runat="server">
    <ul class="menu">
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"><span>Главная</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Page/ReceptsPage.aspx"><span>Рецепты</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Page/MenuList.aspx"><span>Меню</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink4"  class="active" runat="server" NavigateUrl="~/Page/About.aspx"><span>О нас</span></asp:HyperLink></li>
    </ul>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="MyAbout3" >
        <img src="../images/face.png" alt="Наши милые мордашки" width="60%" />
        </div>
</asp:Content>
