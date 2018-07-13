<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.AdminPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="/css/recept.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/lk.css" media="screen" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentMenuBox" runat="server">
    <ul class="menu">
        <li>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Default.aspx"><span>Главная</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Page/ReceptsPage.aspx"><span>Рецепты</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Page/MenuList.aspx"><span>Меню</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Page/About.aspx"><span>О нас</span></asp:HyperLink></li>
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="recept">
        <table>
            <tr>
                <td>
                    <h2>Текущие заказы</h2>
                    <br />
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <h3>Заказ №<%# Eval("OrderId") %></h3>
                            <br />
                            <table class="alignmentU">
                                <tr>
                                    <td>Состояние:
                                    </td>
                                    <td>
                                        <%# Eval("State") %>          
                                    </td>
                                </tr>

                                <tr>
                                    <td>Стоимость:
                                    </td>
                                    <td>
                                       <%# Math.Round((decimal)Eval("Price"), 2) %> руб
                                    </td>
                                </tr>
                            </table>

                            
                        </ItemTemplate>

                        <SeparatorTemplate>
                            <hr />
                        </SeparatorTemplate>

                        <FooterTemplate>
                            <hr />
                            
                            <div class="footer">
                    <%
                        for (int i = 1; i <= MaxPage; i++)
                        {
                            Response.Write(
                                String.Format("<a href='/Page/AdminPage.aspx?page={0}' {1}>{2}</a>",
                                    i, i == CurrentPage ? "class='selected'" : "", i));
                        }
                    %>
                </div>
                            <hr />
                        </FooterTemplate>
                    </asp:Repeater>
                </td>
            </tr>
        </table>

    </div>

<div class="menu-box" id="orderV_menu" style="right: 30px;">
            <ul class="menu">
            <li>
                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Page/AdminPage.aspx"><span>Заказы</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Page/Adminka/ProductAd.aspx"><span>Ингридиенты</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Page/Adminka/DishsAd.aspx"><span>Рецепты</span></asp:HyperLink></li>
                <li>
                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Page/Adminka/MenusAd.aspx"><span>Меню</span></asp:HyperLink></li>
            </ul>
        </div>
</asp:Content>
