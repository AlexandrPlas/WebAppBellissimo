<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReceptsPage.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.ReceptsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/recept.css" media="screen" /></asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentMenuBox" runat="server">
    <ul class="menu">
        <li>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx"><span>Главная</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink2" class="active" runat="server" NavigateUrl="~/Page/ReceptsPage.aspx"><span>Рецепты</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Page/MenuList.aspx"><span>Меню</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Page/About.aspx"><span>О нас</span></asp:HyperLink></li>
    </ul>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="recept">

        <div style="margin-bottom: 10px;">
            <asp:DropDownList runat="server" ID="DropDownListSort1" EnableViewState="true" AutoPostBack="True">
                <asp:ListItem Selected="true">По алфавиту</asp:ListItem>
                <asp:ListItem>По цене</asp:ListItem>
                <asp:ListItem>По новизне</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList runat="server" ID="DropDownListSort2" EnableViewState="true" AutoPostBack="True">
                <asp:ListItem Selected="true">по возрастанию</asp:ListItem>
                <asp:ListItem>по убыванию</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="inner-content">
            <div class="portfolio-page">
                <div class="portfolio-box">


                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                            <div class="project-post">
                                <div class="view view-first">

                                    <asp:Image ID="ImageRecept" runat="server" ImageUrl='<%# GetImageUrl(Convert.ToInt32(Eval("DishId"))) %>' />
                                    <%--<asp:Image ID="ImageRecept" runat="server" ImageUrl='~/images/image6.jpg' />--%>


                                    <div class="mask">
                                        <div class="top-post">
                                            <h2><a class="Name_prod" href='/Page/ReceptView.aspx?DishId=<%# Eval("DishId") %>'><%# Eval("Name") %></a></h2>
                                            <div class="post-border"></div>
                                            <div class="alignmentNew">
                                            <table >
                                                <%--<tr>
                                                    <td>
                                                        <label>Основа: </label>

                                                        <%# Eval("Base") %>
                                                    </td>
                                                </tr>--%>

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
                                                </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>

                        <FooterTemplate>
                            <hr />
                            <hr />

                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
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

    </div>
</asp:Content>
