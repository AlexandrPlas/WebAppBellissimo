<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="NewDishPage.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.Adminka.NewDishPage" %>
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
                    <h2>Добавить новый рецепт</h2>
                    <br />
                        
                       <table class="alignmentU">
                        <tr>
                            <asp:Label ID="DishLabel" runat="server" text=""></asp:Label>

                        </tr>
                       
                       <tr>
                       <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <table class="alignmentU">
                                <tr>
                                    <td>Продукт: 
                                    </td>
                                    <td>
                                        <%# Eval("Product") %>          
                                    </td>
                                </tr>

                                <tr>
                                    <td>Масса, грамм: 
                                    </td>
                                    <td>
                                       <%# Eval("PrMass") %> руб
                                    </td>
                                </tr>
                            </table>

                            
                        </ItemTemplate>


                    </asp:Repeater>
                       </tr>

                        <tr>
                            <td>Наименование</td>
                            <td>
                                <asp:TextBox ID="Name" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Основа</td>
                            <td>
                                <asp:TextBox ID="Base" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Сложность (от 0 до 6)</td>
                            <td>
                                <asp:TextBox ID="Difficult" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Вид блюда</td>
                            <td>
                                <asp:DropDownList ID="Kind" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Описание</td>
                            <td>
                                <asp:TextBox ID="MText" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Добавить продукт</td>
                            <td>
                                <asp:TextBox ID="Product" runat="server" />
                            </td>
                            <td>
                                <asp:TextBox ID="gramm" runat="server" Text="Грамм" 
                                onkeydown ="if (this.value == 'Грамм') this.value = '';" onclick="if (this.value == 'Грамм') this.value = ''"/>
                            </td>
                        </tr>

                        <tr>
                            <td>Стоимость рецепта</td>
                            <td>
                                <asp:TextBox ID="price" runat="server" Text="" />
                            </td>
                        </tr>
                        
                        

                    </table>
                    <input type="file" id="File1" name="File1" runat="server" />
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Продолжить" />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Добавить новый продукт" />
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
