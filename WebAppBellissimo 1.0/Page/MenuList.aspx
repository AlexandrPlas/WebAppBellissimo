<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MenuList.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.MenuList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/recept.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/lk.css" media="screen" />
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
    <asp:DropDownList runat="server" ID="DropDownListSort1" EnableViewState="true"  AutoPostBack="True">
        <asp:ListItem Selected="true">По алфавиту</asp:ListItem>
        <asp:ListItem>По цене</asp:ListItem>
        <asp:ListItem>По новизне</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList runat="server" ID="DropDownListSort2" EnableViewState="true"  AutoPostBack="True">
        <asp:ListItem Selected="true">по возрастанию</asp:ListItem>
        <asp:ListItem>по убыванию</asp:ListItem>
    </asp:DropDownList>
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <h2><a class="Name_prod" href='/Page/MenuPage.aspx?MenuId=<%# Eval("MenuId") %>'><%# Eval("Name") %></a></h2>
                <br />

                <table class="alignmentR">
                    <tr>
                        <td class="start">
                            В меню входят следующие рецепты:
                        </td>
                        <td>
                            <%# GetMenuDish(Convert.ToInt32(Eval("MenuId"))) %>
                            <a href='/Page/MenuPage.aspx?MenuId=<%# Eval("MenuId") %>'>Дополнительно...</a></h3>                        </td>
                    </tr>
                </table>


            </ItemTemplate>

            <SeparatorTemplate>
                <hr />
            </SeparatorTemplate>

            <FooterTemplate>
                <hr />
                <hr />
                <div class="footer">
                    <%
                        for (int i = 1; i <= MaxPage; i++)
                        {
                            Response.Write(
                                String.Format("<a href='/Page/ReceptsPage.aspx?page={0}' {1}>{2}</a>",
                                    i, i == CurrentPage ? "class='selected'" : "", i));
                        }
                    %>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
