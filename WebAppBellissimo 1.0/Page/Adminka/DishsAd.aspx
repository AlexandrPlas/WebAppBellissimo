<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DishsAd.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.Adminka.DishsAd" EnableEventValidation="false" %>

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
                    <h2>Список рецептов</h2>
                </td>
                <td>
                    <h3><a class="add-btn" style="padding-left: 20px;text-decoration: none;font-family: Nautilus;" href="/Page/Adminka/NewDishPage.aspx">Добавить</a></h3>
                </td>
            </tr>
        </table>

        <asp:DropDownList runat="server" ID="DropDownListSort1" EnableViewState="true" AutoPostBack="True">
            <asp:ListItem Selected="true">По алфавиту</asp:ListItem>
            <asp:ListItem>По цене</asp:ListItem>
            <asp:ListItem>По новизне</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="DropDownListSort2" EnableViewState="true" AutoPostBack="True">
            <asp:ListItem Selected="true">по возрастанию</asp:ListItem>
            <asp:ListItem>по убыванию</asp:ListItem>
        </asp:DropDownList>
         <br />
  
        <table class="alignmentR" style="font-size: 14pt; width: 70%; "border-collapse: collapse; border: 1px solid black;" border="1" cellpadding="5">
            <tr>
                <td>Наименование

                </td>
                <td>Доп. инфо
                </td>
                <td>Цена (руб)
                </td>
            </tr>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <tr>
                        <td>
                           <a class="Name_prod" href='/Page/ReceptView.aspx?DishId=<%# Eval("DishId") %>'><%# Eval("Name") %></a>
                        </td>
                        <td>
                            <label>Основа: </label>

                                        <%# Eval("Base") %>     </br>    
                            <label>Сложность приготовления: </label>

                                        <%# Eval("Difficult") %></br>
                            <label>Тип: </label>

                                        <%# GetKind(Convert.ToInt32(Eval("KindId"))) %>
                        </td>
                        <td>
                            <%# Math.Round((decimal)Eval("Price"), 2) %>
                        </td>
                        <td>
                            <asp:Button CssClass="yellowBtn"  CommandArgument='<%# Eval("DishId") %>' Text="Удалить" runat="server" OnClick="Delete_Click" />
                        </td>
                    </tr>             
                

            </ItemTemplate>


            <FooterTemplate>
                <hr />
                
                <div class="footer">
                    <%
                        for (int i = 1; i <= MaxPage; i++)
                        {
                            Response.Write(
                                String.Format("<a href='/Page/Adminka/DishAd.aspx?page={0}' {1}>{2}</a>",
                                    i, i == CurrentPage ? "class='selected'" : "", i));
                        }
                    %>
                </div>
                <hr />
            </FooterTemplate>
        </asp:Repeater>
            </table>
            

    </div>
    <br/><br/>
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
