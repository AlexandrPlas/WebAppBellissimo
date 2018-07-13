<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Regestrate.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.Regestrate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/table.css" media="screen" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentMenuBox" runat="server">
    <ul class="menu">
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"><span>Главная</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Page/ReceptsPage.aspx"><span>Рецепты</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Page/MenuList.aspx"><span>Меню</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Page/About.aspx"><span>О нас</span></asp:HyperLink></li>
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="table">

        <table class="alignment">
            <tr>
                <td>
                    <label for="FirstName">Имя</label>
                </td>
                <td>
                    <asp:TextBox ID="FirstName" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="LastName">Фамилия</label>
                </td>
                <td>
                    <asp:TextBox ID="LastName" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="email">E-mail</label>
                </td>
                <td>
                    <asp:TextBox ID="email" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="Telephone">Номер телефона</label>
                </td>
                <td>
                    <asp:TextBox ID="Telephone" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <label for="Adress">Адрес</label></td>
                <td>
                    <asp:TextBox ID="Adress" runat="server" /></td>
            </tr>
            <tr>
                <td>
                    <label for="password">Пароль</label></td>
                <td>
                    <asp:TextBox ID="password" TextMode="Password" runat="server" /></td>
            </tr>
            <tr>
                <td>
                    <label for="pass2">Повторите пароль</label></td>
                <td>
                    <asp:TextBox ID="pass2" TextMode="Password" runat="server" /></td>
            </tr>

        </table>
        <asp:Button ID="OkButtonReg" runat="server" Text="Регистрация" OnClick="OkButton_Click" />

        <br />
        <asp:Label ID="RegOut" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
