<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="OrderView.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.LKView.OrderView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/recept.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/lk.css" media="screen" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="recept">
        <table>
            <tr>
                <td>
                    <h3>
                        <asp:Label ID="Label1" Text="Заказ №" runat="server" /><%# CheckOrders.OrderId %>
                    </h3>
                </td>
                <td>
                    <asp:Button ID="ButtonRemOrder" runat="server" Text="Удалить заказ из истории" OnClick="ButtonRemOrder_Click" /><br />
                </td>
            </tr>
        </table>



        <table class="alignmentU">
            <tr>
                <td>Стоимость:
                </td>
                <td>
                    <%#  Math.Round(CheckOrders.Price, 2) %> руб
                </td>
            </tr>
        </table>

        <h3>Список заказанных рецептов</h3>
        <br />
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <h3><a href='/Page/ReceptView.aspx?DishId=<%# Eval("DishId") %>'><%# Eval("Name") %></a></h3>
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
                       
                            <%# Math.Round((decimal)Eval("Price"), 2) %> руб       
                        </td>
                    </tr>
                    <tr>
                        <td>Количество:
                       
                            <%# CountDish(Convert.ToInt32(Eval("DishId"))) %>      
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

    </div>
</asp:Content>
