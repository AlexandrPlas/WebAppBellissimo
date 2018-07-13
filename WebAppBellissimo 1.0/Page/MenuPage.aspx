<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MenuPage.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.MenuPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/recept.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/addToCart.css" media="screen" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentMenuBox" runat="server">
    <ul class="menu">
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"><span>Главная</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Page/ReceptsPage.aspx"><span>Рецепты</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink3"  class="active" runat="server" NavigateUrl="~/Page/MenuList.aspx"><span>Меню</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Page/About.aspx"><span>О нас</span></asp:HyperLink></li>
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="recept">

        <h2>
            <asp:Label CssClass="Name_menu" Text="<%# MenuPage1.Name %>" runat="server" />
        </h2>

         <div class="alignmentB">
            <asp:Button ID="ButtonCheck" Text="Добавить в корзину" runat="server" OnClick="ButtonCheck_Click" />
            <asp:TextBox ID="CountDish" runat="server" Text="1" />
            порцию(ий)
            <br />
        </div>

        <table class="alignmentR">
            <tr>
                <td >Стоимость:
                </td>
                <td>
                    <%# Math.Round(MenuPage1.Price , 2)%> руб               
                </td>
            </tr>

            <tr>
                <td>Комментарий:
                </td>
                <td>
                   <asp:Literal Text="<%# MenuPage1.Text %>" runat="server" />
                </td>
            </tr>
        </table>

        <br />
        <br />

        <div id="list_recept">
            <h3><i>Список рецептов в меню</i></h3>
        </div>
        <br />
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>

                <h3><a class="Name_prod" href='/Page/ReceptView.aspx?DishId=<%# Eval("DishId") %>'><%# Eval("Name") %></a></h3>

                <table>
                    <tr>
                        <td>
                            <asp:Image CssClass="ImageRecept" ID="ImageRecept" runat="server" ImageUrl='<%# GetImageUrl(Convert.ToInt32(Eval("DishId"))) %>' />
                        </td>
                        <td>
                            <table class="alignment">
                                <tr>
                                    <td>
                                        <label>Основа: </label>
                                        <%# Eval("Base") %>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <label>Сложность приготовления: </label>
                                        <%# Eval("Difficult") %>

                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <label>Тип: </label>
                                        <%# GetKind(Convert.ToInt32(Eval("KindId"))) %>   

                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <label>Стоимость: </label>
                                        <%# Math.Round((decimal)Eval("Price") , 2) %> руб      

                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>

            </ItemTemplate>

            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>

            <FooterTemplate>
                <hr />
                <hr />
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <br />
    </div>
</asp:Content>
