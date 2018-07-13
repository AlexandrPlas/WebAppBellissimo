<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BasketPage.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.LKView.BasketPage" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/recept.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/lk.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/addToCart.css" media="screen" />
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
    <div id="recept">

        <asp:Label ID="HeadBasket" runat="server" Text=""></asp:Label>

        <table class="alignmentR">
            <tr>
                <td>Общая стоимость:
                </td>
                <td>
                    <%# Math.Round(CheckOrders.Price, 2) %> руб
                </td>
                <td>
                    <asp:Button ID="ButtonCheck" runat="server" Text="Очистить корзину" OnClick="ButtonRemOrder_Click" /><br />
                </td>
            </tr>
        </table>

        <asp:Panel runat="server" id="basket">
            <h2 style="font-size: 20pt;">Список заказанных рецептов</h2>
        <br />
        <table class="alignmentR">
            <tr>
                    <td>
                        Наименование

                    </td>
                    <td>
                        Кол-во порций
                    </td>
                    <td>
                        Цена (руб)
                    </td>
                </tr>
        <asp:Repeater ID="Repeater1" runat="server">

            <ItemTemplate>
                 <tr>
                    <td>
                       <h3><a href='/Page/ReceptView.aspx?DishId=<%# Eval("DishId") %>'><%# Eval("Name") %></a></h3>
                    </td>
                    <td>
                       <%# CountDish(Convert.ToInt32(Eval("DishId"))) %> 
                    </td>
                    <td>
                       <%# Math.Round((decimal)Eval("Price"), 2)  %>
                    </td>
                     <td>
                         <asp:Button ID="Button1" CssClass="yellowBtn" CommandArgument='<%# Eval("DishId") %>' Text="Удалить" runat="server" OnClick="DeleteDish_Click" />
                    </td>
                </tr>



                <%--<h3><a href='/Page/ReceptView.aspx?DishId=<%# Eval("DishId") %>'><%# Eval("Name") %></a></h3>
                <asp:Button CommandArgument='<%# Eval("DishId") %>' Text="Удалить" runat="server" OnClick="DeleteDish_Click" />
                <br />

                <table class="alignmentU">
                    <tr>
                        <td>Основа:
                        
                            <%# Eval("Base") %>        
                        </td>
                    </tr>

                    <tr>
                        <td>Сложность приготовления:
                        
                            <%# Eval("Difficult") %>
                        </td>
                    </tr>

                    <tr>
                        <td>Тип:
                       
                            <%# GetKind(Convert.ToInt32(Eval("KindId"))) %>
                        </td>
                    </tr>

                    <tr>
                        <td>Цена:
                            <%# Eval("Price") %> руб       
                        </td>
                    </tr>
                    <tr>
                        <td>Количество:
                            <%# CountDish(Convert.ToInt32(Eval("DishId"))) %>      
                        </td>
                    </tr>
                </table>--%>

            </ItemTemplate>

            <%--<SeparatorTemplate>
                <hr />
            </SeparatorTemplate>

            <FooterTemplate>
                <hr />
                <hr />
            </FooterTemplate>--%>
        </asp:Repeater>
                        </table>

        <h2 style="font-size: 20pt;">Список заказанных меню</h2>
        <br />
        <table class="alignmentR">
            <tr>
                    <td>
                        Наименование

                    </td>
                    <td>
                        Кол-во порций
                    </td>
                    <td>
                        Цена (руб)
                    </td>
                </tr>
        <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>

                <tr>
                    <td>
                       <h3><a href='/Page/MenuPage.aspx?MenuId=<%# Eval("MenuId") %>'><%# Eval("Name") %></a></h3>
                    </td>
                    <td>
                       <%# CountMenu(Convert.ToInt32(Eval("MenuId"))) %>   
                    </td>
                    <td>
                       <%#  Math.Round((decimal)Eval("Price"), 2) %>    
                    </td>
                    <td>
                       <asp:Button ID="Button2" CssClass="yellowBtn"  CommandArgument='<%# Eval("MenuId") %>' Text="Удалить" runat="server" OnClick="DeleteMenu_Click" />   
                    </td>
                </tr>


                <%--<h2><a class="Name_prod" href='/Page/MenuPage.aspx?MenuId=<%# Eval("MenuId") %>'><%# Eval("Name") %></a></h2>
                <asp:Button CommandArgument='<%# Eval("MenuId") %>' Text="Удалить" runat="server" OnClick="DeleteMenu_Click" />
                <br />

                <table class="alignmentR">
                    <tr>
                        <td class="start">В меню входят следующие рецепты:
                        </td>
                        <td>
                            <%# GetMenuDish(Convert.ToInt32(Eval("MenuId"))) %>
                            <a href='/Page/ReceptView.aspx?DishId=<%# Eval("MenuId") %>'>Дополнительно...</a></h3>                        </td>
                    </tr>
                    <tr>
                        <td>Цена:
                            <%# Eval("Price") %> руб       
                        </td>
                    </tr>
                    <tr>
                        <td>Количество:
                            <%# CountMenu(Convert.ToInt32(Eval("MenuId"))) %>      
                        </td>
                    </tr>
                </table>--%>


            </ItemTemplate>

           <%-- <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>

            <FooterTemplate>
                <hr />
                <hr />
            </FooterTemplate>--%>
        </asp:Repeater>
            </table>
        </asp:Panel>

        
            </div>
</asp:Content>
