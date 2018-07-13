<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppBellissimo_1._0.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="/css/about.css" media="screen" />
</asp:Content>

<asp:Content ContentPlaceHolderID="ContentMenuBox" runat="server">
    <ul class="menu">
        <li>
            <asp:HyperLink ID="HyperLink1" class="active" runat="server" NavigateUrl="~/Default.aspx"><span>Главная</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Page/ReceptsPage.aspx"><span>Рецепты</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Page/MenuList.aspx"><span>Меню</span></asp:HyperLink></li>
        <li>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Page/About.aspx"><span>О нас</span></asp:HyperLink></li>
    </ul>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <%-- <div class="MyAbout0">

        <div class="MyAbout">
            Добро пожаловать на сервис доставки <i class="MyAboutInglish">Bellissimo</i>
            <br />
            Мы - люди, которые разделяют идею, что еда должна быть вкусной, полезной и домашней. 
        <br />
            Современный ритм жизни большого города часто не позволяет готовить дома - заботы, дела и усталость отнимают Ваше время. 
        <br />
            Мы можем помочь Вам сэкономить Ваше время. 
        <br />
            Как это работает? Несколько простых шагов:
        <br />
            <div style="margin-left: 5%;">
                1. Закажите на сайте рецепт или набор рецептов
            <br />
                2. Дождитесь заказа
            <br />
                3. Следуйте простым инструкциям
            <br />
                4. Готовьте быстро и легко
            <br />
                5. Наслаждайтесь домашней едой!
            <br />
            </div>
            <i class="MyAboutInglish">Bellissimo</i> - быстро решение кулинарного вопроса.
        <br />
        </div>
    </div>--%>

     <div class="MyAbout0">

         <div class="MyAbout">
            Добро пожаловать на сервис доставки <i class="MyAboutInglish">Bellissimo</i>
            <br />
            Мы - люди, которые разделяют идею, что еда должна быть вкусной, полезной и домашней. 
        <br />
            Современный ритм жизни большого города часто не позволяет готовить дома - заботы, дела и усталость отнимают Ваше время. 
        <br />
            Мы можем помочь Вам сэкономить Ваше время. 
        <br />
            Как это работает? Несколько простых шагов:
        <br />
            <div style="margin-left: 5%;">
                1. Закажите на сайте рецепт или набор рецептов
            <br />
                2. Дождитесь заказа
            <br />
                3. Следуйте простым инструкциям
            <br />
                4. Готовьте быстро и легко
            <br />
                5. Наслаждайтесь домашней едой!
            <br />
            </div>
            <i class="MyAboutInglish">Bellissimo</i> - быстро решение кулинарного вопроса.
        <br />
        </div>

   
          </div>
    

    <asp:Label ID="test1" runat="server" />
</asp:Content>
