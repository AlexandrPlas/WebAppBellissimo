<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReceptView.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.ReceptView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/recept.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/addToCart.css" media="screen" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentMenuBox" runat="server">
    <ul class="menu">
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"><span>Главная</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink2"  class="active" runat="server" NavigateUrl="~/Page/ReceptsPage.aspx"><span>Рецепты</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Page/MenuList.aspx"><span>Меню</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Page/About.aspx"><span>О нас</span></asp:HyperLink></li>
      
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="recept">
        <h2>
            <asp:Label class="Name_prod" Text="<%# DishPage.Name %>" runat="server" />
        </h2>


        <div class="alignmentB">
            <asp:Button ID="ButtonCheck" Text="Добавить в корзину" runat="server" OnClick="ButtonCheck_Click" />
            <asp:TextBox ID="CountDish" runat="server" Text="1" />
            порцию(ий)
            <br />
        </div>

        <asp:Repeater ID="imageRepeat" runat="server">
            <ItemTemplate>
                <asp:Image CssClass="ImageRecept" ID="ImageRecept" runat="server" ImageUrl="<%# Container.DataItem %>" />
            </ItemTemplate>
        </asp:Repeater>
        <br />
        
        <table class="alignmentV">
            
            <tr>
                <td>
                    <label>Основа: </label>
                    <%# DishPage.Base %>
                </td>
            </tr>

            <tr>
                <td>
                    <label>Сложность приготовления: </label>
                    <%# DishPage.Difficult %>
                </td>
            </tr>

            <tr>
                <td>
                    <label>Тип: </label>
                    <%# GetKind(Convert.ToInt32(DishPage.KindId)) %>        

                </td>
            </tr>

            <tr>
                <td>
                    <label>Стоимость: </label>
                     <%# Math.Round((double)DishPage.Price , 2) %> руб      

                </td>
            </tr>
        </table>

        <table class="alignmentV">
            <tr>
                <td>
                    <label class="recept_label">Рецепт: </label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Literal Text="<%# ReceptPage %>" runat="server" />
                </td>
            </tr>
        </table>
       
        <asp:Repeater ID="RepeatRecall" runat="server">
            <HeaderTemplate>
                <h3 class="recept_label">Отзывы</h3>
            </HeaderTemplate>

            <ItemTemplate>
                <table class="alignmentR">
                    <tr>
                        <td>
                            <b><%# GetUser(Convert.ToInt32(Eval("UserId"))) %></b> пишет:<br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%# Eval("Text") %>
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
        <asp:Label Text="Напишите нам отзыв" ID="RecallLabel" runat="server" />
        <asp:TextBox TextMode="MultiLine" ID="RecallTextbox" runat="server" Height="115" Width="400" /><br />
        <asp:Button ID="RecallButton" Text="Отправить" runat="server" OnClick="RecallButton_Click" />
    </div>
</asp:Content>
