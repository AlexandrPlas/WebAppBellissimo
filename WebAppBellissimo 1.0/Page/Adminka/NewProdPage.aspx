<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NewProdPage.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.Adminka.NewProdPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" type="text/css" href="/css/recept.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/lk.css" media="screen" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentMenuBox" runat="server">
    <ul class="menu">
        <li>
            <asp:HyperLink ID="HyperLink5" class="active" runat="server" NavigateUrl="~/Default.aspx"><span>Главная</span></asp:HyperLink></li>
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
                    <h2>Добавить новый продукт</h2>
                    <br />

                       <table class="alignmentU">
                        <tr>
                            <td>Наименование</td>
                            <td>
                                <asp:TextBox ID="Name" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Калории</td>
                            <td>
                                <asp:TextBox ID="Kal" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Жиры</td>
                            <td>
                                <asp:TextBox ID="Fat" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Белки</td>
                            <td>
                                <asp:TextBox ID="Bel" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Углеводы</td>
                            <td>
                                <asp:TextBox ID="Ca" runat="server" /></td>
                        </tr>
                        <tr>
                            <td>Цена</td>
                            <td>
                                <asp:TextBox ID="price" runat="server" /></td>
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
