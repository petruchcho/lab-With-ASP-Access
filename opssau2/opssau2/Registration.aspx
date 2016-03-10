<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="opssau2.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Олимпиадное программирование в СГАУ</title>
    <meta charset="utf-8">
    <link href="css/style.css" rel="stylesheet">
    <link rel="icon" type="image/jpg" href="images/icon.jpg" />
          <script src="js/valid_reg.js"></script>
</head>

<body>
    <div class="wrapper">

        <header class="header">
            <h1>
                <a href="http://ssau.ru">
                    <img src="images/ssau_logo.png" width="100" height="50" alt="СГАУ"></a>Олимпиадное программирование в СГАУ</h1>
        </header>

        <div class="middle">

            <div class="container">
                <main class="content">
                    <h2>Регистрация на IX Самарскую областную межвузовскую олимпиаду по программированию 2016</h2>
                    <form id = 'registration_form' method="POST" runat="server">
                        <p>
                            <label for="login_field"></label>
                        </p>
                        <p>
                            Название команды:
                            <input class='input edittext' type='text' runat="server" id="login_field"/>
                        </p>
                        <p>
                            <p>
                                Город:&nbsp;
                                <asp:DropDownList ID="cityDropDown" class='input edittext' runat="server" DataSourceID="SqlDataSource1" DataTextField="Название" DataValueField="Название">
                                </asp:DropDownList>
                            </p>
                            <p>
                                Другой:&nbsp;
                                <input class='input edittext' runat="server" type="text" id="city_text"/>
                            </p>
                            <hr/>
                            <p>
                                ФИО капитана команды:
                                <input class='input edittext' type="text" runat="server" id="captain_name"/>
                            </p>
                            <p>
                                Email капитана команды:
                                <input class='input edittext' type="text" runat="server" id="captain_email"/>
                            </p>
                            <p>
                                Телефон капитана команды:
                                <input class='input edittext' type="text" runat="server" id="captain_number"/>
                            </p>
                            <hr>
                            <p>
                                ФИО второго участника:
                                <input class='input edittext' type="text" runat="server" id="second"/>
                            </p>
                            <hr>
                            <p>
                                ФИО третьего участника:
                                <input class='input edittext' type="text" runat="server" id="third"/>
                            </p>
                            <p>
                                <hr>
                                &nbsp;<asp:Button Text="Submit" runat="server" OnClientClick="return validateForm(document.forms.registration_form, true);" OnClick="Registrate" CssClass="input button" />
                                &nbsp;</p>
                    </form>

                </main><!-- .content -->
            </div>
            <!-- .container-->

            <aside class="left-sidebar">
                <a href="about.html">
                    <h3>О нашей деятельности</h3>
                </a>
                <a href="Default.aspx">
                    <h3>Новости</h3>
                </a>
                <a href="recent_contests.html">
                    <h3>Последние соревнования</h3>
                </a>
                <a href="lessons.html">
                    <h3>Лекции и уроки</h3>
                </a>
                <a href="Registration.aspx">
                    <h3>Регистрация на предстоящее соревнование</h3>
                </a>
                <a href="help.html">
                    <h3>Форум</h3>
                </a>

                <br>
                <hr>
                <br>

                <iframe src="https://calendar.google.com/calendar/embed?showTitle=0&amp;showNav=0&amp;showPrint=0&amp;showTabs=0&amp;showCalendars=0&amp;showTz=0&amp;mode=AGENDA&amp;height=200&amp;wkst=1&amp;bgcolor=%23FFFFFF&amp;src=br1o1n70iqgrrbc875vcehacjg%40group.calendar.google.com&amp;color=%2329527A&amp;ctz=Europe%2FSamara" style="border: solid 1px #777" width="279" height="300" frameborder="0" scrolling="no"></iframe>

            </aside>
            <!-- .left-sidebar -->

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OPSSAU_CONNECTION_STRING %>" ProviderName="<%$ ConnectionStrings:OPSSAU_CONNECTION_STRING.ProviderName %>" SelectCommand="SELECT [Название] FROM [Город] ORDER BY [Код]"></asp:SqlDataSource>

        </div>
        <!-- .middle-->
    </div>

    <script src="js/valid_reg.js"></script>
</body>
</html>
