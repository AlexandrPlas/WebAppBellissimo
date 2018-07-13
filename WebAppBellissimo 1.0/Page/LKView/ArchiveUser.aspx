<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ArchiveUser.aspx.cs" Inherits="WebAppBellissimo_1._0.Page.LKView.ArchiveUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/recept.css" media="screen" />
    <link rel="stylesheet" type="text/css" href="/css/lk.css" media="screen" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="recept">

        <h2>История заказов</h2>
        <br />

        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <h3><a href='/Page/LKView/OrderView.aspx?OrderId=<%# Eval("OrderId") %>'>Заказ №<%# Eval("OrderId") %></a></h3>
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
                            <%#  Math.Round((decimal)Eval("Price"), 2) %> руб
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
