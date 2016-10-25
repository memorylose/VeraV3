﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Vera.UI.Index" %>

<%@ Register Src="Shares/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="Shares/HeaderSignature.ascx" TagName="HeaderSignature" TagPrefix="uc2" %>
<%@ Register Src="Shares/BlogName.ascx" TagName="BlogName" TagPrefix="uc3" %>
<%@ Register Src="Shares/UserInfo.ascx" TagName="UserInfo" TagPrefix="uc4" %>
<%@ Register Src="Shares/HotArticles.ascx" TagName="HotArticles" TagPrefix="uc5" %>
<%@ Register Src="Shares/Footer.ascx" TagName="Footer" TagPrefix="uc6" %>
<%@ Register Src="Shares/ArticleType.ascx" TagName="ArticleType" TagPrefix="uc7" %>

<%@ Register Src="Shares/ArticleDate.ascx" TagName="ArticleDate" TagPrefix="uc8" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>薇拉生活坊</title>
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/NewIndex.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <div class="container">
                <div class="row">
                    <div class="col-md-2 header-col"></div>
                    <div class="col-md-8 header-col"></div>
                    <div class="col-md-2 header-col">
                        <uc1:Header ID="Header1" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <uc3:BlogName ID="BlogName1" runat="server" />
            </div>
            <div class="row header-word">
                <uc2:HeaderSignature ID="HeaderSignature1" runat="server" />
            </div>
        </div>
        <div class="container">
            <div class="row bt-center">
                <div class="col-md-3 bt-padding">
                    <div class="l-personal-name">个人信息</div>
                    <div class="l-personal-content">
                        <img src="/images/people.jpg" class="l-personal-img" />
                    </div>
                    <div class="l-personal-detail">
                        <uc4:UserInfo ID="UserInfo2" runat="server" />
                    </div>
                    <div class="l-personal-name">文章分类</div>
                    <div class="l-personal-detail">
                        <uc7:ArticleType ID="ArticleType1" runat="server" />
                    </div>
                    <div class="l-personal-name">文章存档</div>
                    <div class="l-personal-detail">
                        <uc8:ArticleDate ID="ArticleDate1" runat="server" />
                    </div>
                    <div class="l-personal-name">阅读排行</div>
                    <div class="l-personal-detail">
                        <uc5:HotArticles ID="HotArticles1" runat="server" />
                    </div>
                </div>
                <div class="col-md-9 r-content">
                    <div class="l-personal-name" style="margin-left: 20px;">欢迎来到我的生活坊</div>
                    <%=ArticleListhtml %>
                    <div class="r-content-d test" style="">
                        <%--<a class="pager test">1</a>--%>
                        <div class="pager-e">1</div>
                        <div class="pager-d"><a href="">2</a></div>
                        <div class="pager-d"><a href="">3</a></div>
                        <div class="pager-d"><a href="">4</a></div>
                        <div class="pager-d"><a href="">下一页</a></div>
                        <div style="clear: both;"></div>
                    </div>
                   

 <div style="clear:both;"></div>
                    <%-- <%=PageDevisionhtml %>--%>
                </div>
            </div>
        </div>
        <div class="footer">
            <uc6:Footer ID="Footer2" runat="server" />
        </div>
    </form>
</body>
</html>
