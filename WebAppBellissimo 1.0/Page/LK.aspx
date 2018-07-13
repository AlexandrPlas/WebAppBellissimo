<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="LK.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.LK" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/recept.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/lk.css" media="screen" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentMenuBox" runat="server">
    <ul class="menu">
        <li>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Default.aspx"><span>Главная</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Page/ReceptsPage.aspx"><span>Рецепты</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Page/MenuList.aspx"><span>Меню</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Page/About.aspx"><span>О нас</span></asp:HyperLink></li>
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="recept">
        <table>
            <tr>
                <td>
                    <h2>Данные пользователя</h2>
                    <br />

                    <table class="alignmentU">
                        <tr>
                            <td>Имя:
                            </td>
                            <td>
                                <%# UserAct.FirstName %>             
                            </td>
                        </tr>

                        <tr>
                            <td>Фамилия:
                            </td>
                            <td>
                                <%# UserAct.LastName %>
                            </td>
                        </tr>

                        <tr>
                            <td>Email:
                            </td>
                            <td>
                                <%# UserAct.email %>
                            </td>
                        </tr>

                        <tr>
                            <td>Адрес:
                            </td>
                            <td>
                                <%# UserAct.Adress %>
                            </td>
                        </tr>

                        <tr>
                            <td>Контактный телефон:
                            </td>
                            <td>
                                <%# UserAct.Telephone %>
                            </td>
                        </tr>
                    </table>
                </td>



                

            </tr>

        </table>

    </div>

    <div class="menu-box" id="orderV_menu" style="right: 30px;">
            <ul class="menu">
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Page/LKView/RedactUser.aspx"><span>Редактировать профиль</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Page/LKView/OrderUser.aspx"><span>Текущие заказы</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Page/LKView/ArchiveUser.aspx"><span>История заказов</span></asp:HyperLink></li>
            </ul>
        </div>
</asp:Content>
