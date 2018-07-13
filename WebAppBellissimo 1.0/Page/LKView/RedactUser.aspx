<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="RedactUser.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.LKView.RedactUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/recept.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/lk.css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="recept">
        <table>
            <tr>
                <td>
                    <h2>Редактировать профиль</h2>
                    <br />

                       <table class="alignmentU">
                        <tr>
                            <td>Имя</td>
                            <td>
                                <asp:TextBox ID="FirstName" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Фамилия</td>
                            <td>
                                <asp:TextBox ID="LastName" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>E-mail</td>
                            <td>
                                <asp:TextBox ID="email" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Номер телефона</td>
                            <td>
                                <asp:TextBox ID="Telephone" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Адрес</td>
                            <td>
                                <asp:TextBox ID="Adress" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Пароль</td>
                            <td>
                                <asp:TextBox ID="password" TextMode="Password" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Повторите пароль</td>
                            <td>
                                <asp:TextBox ID="pass2" TextMode="Password" runat="server" /></td>
                        </tr>

                    </table>

                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Отправить" />

                    <br />
                    <asp:Label ID="RegOut" runat="server" Text=""></asp:Label>
                </td>

            </tr>

        </table>

    </div>

    <div class="menu-box" id="orderV_menu" style="right: 30px;">
            <ul class="menu">
                <li>
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Page/LKView/RedactUser.aspx"><span>Редактировать профиль</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Page/LKView/OrderUser.aspx"><span>Текущие заказы</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Page/LKView/ArchiveUser.aspx"><span>История заказов</span></asp:HyperLink></li>
            </ul>
        </div>

</asp:Content>
