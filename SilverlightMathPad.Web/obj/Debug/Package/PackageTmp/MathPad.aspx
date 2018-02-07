<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MathPad.aspx.cs" Inherits="SilverlightMathPad.Web.MathPad" %>

<link href="Styles.css" type="text/css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="http://www.quizmine.com/tabasset/main/ddlevelsfiles/ddlevelsmenu-base-Menu.css" />
<link rel="stylesheet" type="text/css" href="http://www.quizmine.com/tabasset/main/ddlevelsfiles/ddlevelsmenu-topbar-Menu.css" />
<link rel="stylesheet" type="text/css" href="http://www.quizmine.com/tabasset/main/ddlevelsfiles/ddlevelsmenu-sidebar-Menu.css" />
<script type="text/javascript" src="http://www.quizmine.com/tabasset/ddlevelsfiles/ddlevelsmenu1.js"> 
</script>
<style type="text/css">
    .style11
    {
        border-top-style: solid;
    }
</style>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MathPad</title>
    <style type="text/css">
        html, body
        {
            height: 100%;
            overflow: auto;
        }
        body
        {
            padding: 0;
            margin: 0;
        }
        #silverlightControlHost
        {
            height: 100%;
            text-align: center;
        }
    </style>
    <script type="text/javascript" src="Silverlight.js"></script>
    <script type="text/javascript">
        function onSilverlightError(sender, args) {
            var appSource = "";
            if (sender != null && sender != 0) {
                appSource = sender.getHost().Source;
            }

            var errorType = args.ErrorType;
            var iErrorCode = args.ErrorCode;

            if (errorType == "ImageError" || errorType == "MediaError") {
                return;
            }

            var errMsg = "Unhandled Error in Silverlight Application " + appSource + "\n";

            errMsg += "Code: " + iErrorCode + "    \n";
            errMsg += "Category: " + errorType + "       \n";
            errMsg += "Message: " + args.ErrorMessage + "     \n";

            if (errorType == "ParserError") {
                errMsg += "File: " + args.xamlFile + "     \n";
                errMsg += "Line: " + args.lineNumber + "     \n";
                errMsg += "Position: " + args.charPosition + "     \n";
            }
            else if (errorType == "RuntimeError") {
                if (args.lineNumber != 0) {
                    errMsg += "Line: " + args.lineNumber + "     \n";
                    errMsg += "Position: " + args.charPosition + "     \n";
                }
                errMsg += "MethodName: " + args.methodName + "     \n";
            }

            throw new Error(errMsg);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table style="height: 100%; width: 100%">
        <tr>
            <td align="center" valign="top">
                <table border="2px" style="height: 185px; width: 940px">
                    <tr>
                        <td align="center" valign="top">
                            <div>
                                <table cellspacing="0" cellpadding="0" align="center" style="height: 185px; width: 940px"
                                    class="styleTableMainHeader">
                                    <tr>
                                        <td>
                                            <table class="styleTableTDDefaultWhiteMain " width="768" align="center" border="0">
                                                <tr>
                                                    <td width="52%">
                                                        <table class="styleTableTDDefaultWhiteMain ">
                                                            <tr>
                                                                <td>
                                                                    <a href="http://www.quizmine.com/default.aspx">
                                                                        <img src="http://www.quizmine.com/siteimages/QuizmineLogo.jpg" border="0" align="left"></a>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="font-size: 8pt; color: #007800; text-align: center">
                                                                    <strong><span style="color: #CC0000">Empowering Math &amp; Science Learning </span><span
                                                                        style="color: #6600CC">(Quiz, Animation &amp; Video)</span></strong>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td width="48%">
                                                        <table id="tableHome" width="100%">
                                                            <tr>
                                                                <td align="right">
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <a id="hrefComunity" runat="server" href="#">Community </a><a id="EnableStudentSuccess"
                                                                                    visible="false" href="http://www.quizmine.com/help_students.aspx" runat="server">
                                                                                    Enabling Student Success</a>
                                                                            </td>
                                                                            <div id="dvHelp" runat="server" visible="false">
                                                                                <td align="right">
                                                                                    <a id="hrefHelp" runat="server" visible="false">
                                                                                        <img src="Img/Help.gif" align="absBottom" border="0" title="Help"></a>
                                                                                </td>
                                                                            </div>
                                                                            <td align="right">
                                                                                <a href="http://www.quizmine.com/default.aspx">
                                                                                    <img src="Images/home.gif" align="absBottom" border="0" title="Home"></a>
                                                                            </td>
                                                                            <div id="dvWelcome" runat="server" visible="false">
                                                                                <td align="right">
                                                                                    <a href="http://www.quizmine.com/welcome.aspx">
                                                                                        <img src="Img/my.gif" align="absBottom" border="0" title="MySite"></a>
                                                                                </td>
                                                                            </div>
                                                                        </tr>
                                                                    </table>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <div id="divMarketingLinks" align="right" visible="false" runat="server">
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                   <%-- <label id="lblGuest" visible="false" runat="server" name="lblGuest">
                                                                    </label>
                                                                    &nbsp;<a id="anchRegistration" href="http://www.quizmine.com/Registration.aspx" name="anchRegistration"
                                                                        visible="false" runat="server"><strong>Register</strong></a>
                                                                    <label id="lblSeperator" class="frmtxt" visible="false" runat="server">
                                                                        |</label>
                                                                    <a id="Login" href="http://www.quizmine.com/login.aspx" name="Login" visible="false"
                                                                        runat="server"><strong>Login</strong></a>&nbsp;&nbsp;
                                                                    <div id="divForLoginStudent" align="right" runat="server">
                                                                        <label id="lbllogin" name="lbllogin" visible="False" runat="server">
                                                                        </label>
                                                                        &nbsp;<a id="ChangePassword" href="http://www.quizmine.com/EditAccount.aspx" name="ChangePassword"
                                                                            visible="false" runat="server">Edit Account </a><span class="frmtxt" id="Span1">|</span>&nbsp;<a
                                                                                id="Signout" href="http://www.quizmine.com/pp.aspx" name="Signout" visible="false"
                                                                                runat="server"> Log Off</a>&nbsp;&nbsp;</div>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center" style="border-top-style: groove; border-top-width: thin">
                                           <%-- <div id="divOfModes" align="right" runat="server">
                                                <font class="HeaderLinks"><a id="StudyMode" href="#" name="StudyMode" visible="false"
                                                    runat="server">Self-Study Mode (Free) |</a> <a id="CoachingMode" href="#" name="CoachingMode"
                                                        visible="false" runat="server">Coaching Mode (Basic) |</a> <a id="ExamMode" onclick="setCookie('Mode','Exam')"
                                                            href="#" name="ExamMode" visible="false" runat="server">Coaching Mode (Advanced)
                                                            | </a><a id="referFriend" href="http://www.quizmine.com/ReferFriends.aspx" name="referFriend"
                                                                visible="false" runat="server">|Refer Friends|</a>&nbsp; <a class="imp" id="ProgressReport"
                                                                    href="~/PerformanceReport.aspx" runat="server">My Report</a></font>&nbsp;--%>
                                            </div>
                                            <tr>
                                                <td>
                                                    <div id="jsEnable" align="center">
                                                        <font color="red">Please ensure that your browser is Java script compliant.</font></div>
                                                    <div id="browserShifting" align="center" style="display: none">
                                                        <font color="green" size="2">Your browser is not ajax compilent.Please shift to <a
                                                            href="#" onclick="SetHtmMode()">HTML Mode</a> for proper functioning</font>
                                                    </div>
                                                </td>
                                            </tr>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="border-top-style: ridge; border-top-width: thin">
                                            <table width="900">
                                                <tr>
                                                    <td>
                                                        <div width="418" id="ddtopmenubar4" class="ubercolortabs" align="left">
                                                            <ul>
                                                                <li><a href="http://www.quizmine.com/US.aspx" rel="ddsubmenu4"><span>US State Assessment</span></a></li>
                                                                <li><a href="http://www.quizmine.com/uk.aspx" rel="ddsubmenu5"><span>UK</span></a></li>
                                                                <li><a href="http://www.quizmine.com/india.aspx" rel="ddsubmenu6"><span>India</span></a></li>
                                                            </ul>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div width="350" id="ddtopmenubar3" class="ubercolortabs" align="right">
                                                            <ul>
                                                                <li><a href="http://www.quizmine.com/math.aspx" rel="ddsubmenu1"><span>Math</span></a></li>
                                                                <li><a href="http://www.quizmine.com/science.aspx" rel="ddsubmenu2"><span>Science</span></a></li>
                                                                <li><a href="http://www.quizmine.com/games.aspx" rel="ddsubmenu3"><span>Games</span></a></li>
                                                                <li><a href="http://www.quizmine.com"><span>Home</span></a></li>
                                                            </ul>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <script type="text/javascript">
                                                    ddlevelsmenu.setup("ddtopmenubar3", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar")
                                                    ddlevelsmenu.setup("ddtopmenubar4", "topbar1") //ddlevelsmenu.setup("mainmenuid", "topbar")
                                                </script>
                                                <!--HTML for the Drop Down Menus associated with Top Menu Bar-->
                                                <!--They should be inserted OUTSIDE any element other than the BODY tag itself-->
                                                <!--A good location would be the end of the page (right above "</BODY>")-->
                                                <!--Top Drop Down Menu 1 HTML-->
                                                <ul id="ddsubmenu1" class="ddsubmenustyle">
                                                    <li><a href='http://www.quizmine.com/math.aspx'>Math Home</a></li>
                                                    <li><a href='http://www.quizmine.com/master/MainPage.aspx'>Master Basic Math: Infinite
                                                        questions</a></li>
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=DEEB80B0-2FA8-445B-A824-D84F4508BC87&ExamId=F553BECE-76E7-48A6-8DA1-A6E9A2324517'>
                                                        Online Math School (Grade 3)</a></li>
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=D54CE267-EFFE-4570-BD5E-EF51427CC148&ExamId=C001B936-9961-4FFC-B8E3-9B495892A202'>
                                                        Online Math School (Grade 4)</a></li>
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=647B33D0-0560-4F8A-9EDF-4CBCDD154BA4&ExamId=1ACF3058-6373-466C-BF41-8284F8128315'>
                                                        Online Math School (Grade 5)</a></li>
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=8EEEB7E0-D2E0-41BB-802A-B650D7BA2577&ExamId=3906C07E-7C8A-448C-A300-069F67B89DCB'>
                                                        Online Math School (Grade 6)</a></li>
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=B456C759-B7A3-46C7-8F90-71ADF0A70D4E&ExamId=031BE769-7882-408F-A670-E8420F79E21C'>
                                                        Online Math School (Grade 7)</a></li>
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=9892045B-692D-4CB7-85B5-39E825BC1448&ExamId=83B13DF6-F52A-42A9-8009-76ED7B388F5F'>
                                                        Online Math School (Grade 8)</a></li>
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=4CC9745B-7CCC-4686-BE6E-0AA1AACB4EE1&ExamId=3BF1AC97-F201-4A50-8E44-98A9380A0B00'>
                                                        Online Math School (High School)</a></li>
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=281A3F96-FB19-463F-A39A-E5122C32912C&ExamId=BB0AC321-D215-43AD-A2A2-5B7A13D1B2B0'>
                                                        Online Math School (Grade 11 & 12)</a></li>
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=b1aeb9ee-72b6-4ac1-9560-ee2826abeb17&ExamId=f919fd3b-96a1-4f30-a081-9b734a25b4c8'>
                                                        SAT Math</a></li>
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=1ec462f4-ece1-4d23-9332-ae6add3ca75d&ExamId=834F5F91-2A79-4CD1-99A9-8AFBC497A9BD'>
                                                        GMAT Math</a></li>
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=be87b4a0-dff2-479c-8f80-1752148b685a&ExamId=C2B0ADCD-F9DE-4DF6-BCDD-589736533CF2'>
                                                        GED Math</a></li>
                                                </ul>
                                                <!--Top Drop Down Menu 2 HTML-->
                                                <ul id="ddsubmenu2" class="ddsubmenustyle">
                                                    <li><a href='http://www.quizmine.com/science.aspx'>Science Home</a></li>
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=6AA35EA8-B442-435D-8FB5-235050E72021'>
                                                        Online Science School (Grade 3)</a></li>
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=19147515-81DF-4758-95CB-D5776EC7C75E'>
                                                        Online Science School (Grade 4)</a></li>
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=701C53B3-58A8-40E9-AADC-690047D41D58'>
                                                        Online Science School (Grade 5)</a></li>
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=10549E03-4945-4653-81DF-61D176D70566'>
                                                        Online Science School (Grade 6)</a></li>
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=82A170E9-8F2E-4E35-81E2-BE93FB0A4A9C'>
                                                        Online Science School (Grade 7)</a></li>
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=D951D8A9-7B76-4A6F-AF3D-DED31247AA51'>
                                                        Online Science School (Grade 8)</a></li>
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=926FD1DB-42A1-4187-8D32-825AF94F91D5'>
                                                        Online Science School (Grade 9)</a></li>
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=F611BEB8-D652-40B8-9B05-5CC1FD1C5735'>
                                                        Online Science School (Grade 10)</a></li>
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=FEC9CF64-CEA9-4750-BB09-9C320FBB2600'>
                                                        Online Science School (Grade 11)</a></li>
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=FE3DD921-1C34-45EC-929F-733C6BFFB050'>
                                                        Online Science School (Grade 12)</a></li>
                                                </ul>
                                                <!--Top Drop Down Menu 3 HTML-->
                                                <ul id="ddsubmenu3" class="ddsubmenustyle">
                                                    <li><a href='http://www.quizmine.com/BTM'>Beat the Machine</a></li>
                                                    <li><a href='http://www.quizmine.com/OP'>Challenge your friend</a></li>
                                                    <li><a href='http://www.quizmine.com/Sudoku.aspx'>Sudoku</a></li>
                                                </ul>
                                                <!--Top Drop Down Menu 4 HTML-->
                                                <ul id="ddsubmenu4" class="ddsubmenustyle">
                                                    <li><a href='http://www.quizmine.com/US.aspx'>Home</a></li>
                                                </ul>
                                                <ul id="ddsubmenu5" class="ddsubmenustyle">
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=810494ce-725b-4463-a73b-dc555d6be75f&ExamId=f665320f-a80c-497c-bcdc-7659ade8ff2f'>
                                                        KS2 Math (Key Stage 2) </a></li>
                                                    <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=d2aa0daf-df2d-473b-af72-599847bcf59c&ExamId=ae95945a-2281-4828-89e0-481158b5c0b3'>
                                                        KS3 Math (Key Stage 3) </a></li>
                                                </ul>
                                                <ul id="ddsubmenu6" class="ddsubmenustyle">
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=A9FC4996-4134-43DB-844A-6AA9E7B7ACB5'>
                                                        AIEEE 2010</a></li>
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=D9D06388-0C75-4AF5-B7C6-2ED3D01B44F3'>
                                                        IIM CAT 2009 </a></li>
                                                    <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=9C46B946-1DA0-4B75-88BA-628F8F466E91'>
                                                        IIT JEE 2010</a></li>
                                                </ul>
                                        </td>
                                    </tr>
                                    <%--    <tr>
        <td style="border-top-style: ridge; border-top-width: thin">
            <table width="768" align="center" border="0">
                <tr>
                    <td width="270" style="text-align: right">
                        <div width="270" id="ddtopmenubar3" class="ubercolortabs" align="left">
                            <ul>
                                <a href="http://www.quizmine.com/math.aspx" rel="ddsubmenu1"><span>Math</span></a>
                                <a href="http://www.quizmine.com/science.aspx" rel="ddsubmenu2"><span>Science</span></a>
                                <a href="http://www.quizmine.com/games.aspx" rel="ddsubmenu3"><span>Games</span></a>
                            </ul>
                        </div>
                    </td>
                    <td width="158" style="color: #808080">
                        <div width="158" align="center" style="font-size: x-small; color: #808080; font-family: Calibri;">
                            <strong>Life time access for $100 </strong>
                        </div>
                    </td>
                    <td width="340" align="right">
                        <div width="340" id="ddtopmenubar4" class="ubercolortabs" align="right">
                            <ul>
                                <a href="http://www.quizmine.com/US.aspx" rel="ddsubmenu4"><span>US State Assessment</span></a>
                                <li><a href="http://www.quizmine.com/uk.aspx" rel="ddsubmenu5"><span>UK</span></a></li>
                                <li><a href="http://www.quizmine.com/india.aspx" rel="ddsubmenu6"><span>India</span></a></li>
                            </ul>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>

                        <script type="text/javascript">
    ddlevelsmenu.setup("ddtopmenubar3", "topbar") //ddlevelsmenu.setup("mainmenuid", "topbar")
    ddlevelsmenu.setup("ddtopmenubar4", "topbar1") //ddlevelsmenu.setup("mainmenuid", "topbar")
                        </script>

                        <!--HTML for the Drop Down Menus associated with Top Menu Bar-->
                        <!--They should be inserted OUTSIDE any element other than the BODY tag itself-->
                        <!--A good location would be the end of the page (right above "</BODY>")-->
                        <!--Top Drop Down Menu 1 HTML-->
                        <ul id="ddsubmenu1" class="ddsubmenustyle">
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=DEEB80B0-2FA8-445B-A824-D84F4508BC87&ExamId=F553BECE-76E7-48A6-8DA1-A6E9A2324517'>
                                Math(Grade 3)</a></li>
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=D54CE267-EFFE-4570-BD5E-EF51427CC148&ExamId=C001B936-9961-4FFC-B8E3-9B495892A202'>
                                Math(Grade 4)</a></li>
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=647B33D0-0560-4F8A-9EDF-4CBCDD154BA4&ExamId=1ACF3058-6373-466C-BF41-8284F8128315'>
                                Math(Grade 5)</a></li>
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=8EEEB7E0-D2E0-41BB-802A-B650D7BA2577&ExamId=3906C07E-7C8A-448C-A300-069F67B89DCB'>
                                Math(Grade 6)</a></li>
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=B456C759-B7A3-46C7-8F90-71ADF0A70D4E&ExamId=031BE769-7882-408F-A670-E8420F79E21C'>
                                Math(Grade 7)</a></li>
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=9892045B-692D-4CB7-85B5-39E825BC1448&ExamId=83B13DF6-F52A-42A9-8009-76ED7B388F5F'>
                                Math(Grade 8)</a></li>
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=4CC9745B-7CCC-4686-BE6E-0AA1AACB4EE1&ExamId=3BF1AC97-F201-4A50-8E44-98A9380A0B00'>
                                Math(High School)</a></li>
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=281A3F96-FB19-463F-A39A-E5122C32912C&ExamId=BB0AC321-D215-43AD-A2A2-5B7A13D1B2B0'>
                                Math(Grade 11 & 12)</a></li>
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=bced6cf2-b61d-4428-a574-ec4a5c69913d&ExamId=FDEC440F-5296-46B3-8E82-C793FAF1A205'>
                                Arithmetic helper</a></li>
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=be87b4a0-dff2-479c-8f80-1752148b685a&ExamId=C2B0ADCD-F9DE-4DF6-BCDD-589736533CF2'>
                                GED Math</a></li>
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=1ec462f4-ece1-4d23-9332-ae6add3ca75d&ExamId=834F5F91-2A79-4CD1-99A9-8AFBC497A9BD'>
                                GMAT</a></li>
                        </ul>
                        <!--Top Drop Down Menu 2 HTML-->
                        <ul id="ddsubmenu2" class="ddsubmenustyle">
                            <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=6aa35ea8-b442-435d-8fb5-235050e72021&Type=CAT'>
                                Science (Grade 3)</a></li>
                            <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=19147515-81df-4758-95cb-d5776ec7c75e'>
                                Science (Grade 4)</a></li>
                        </ul>
                        <!--Top Drop Down Menu 3 HTML-->
                        <ul id="ddsubmenu3" class="ddsubmenustyle">
                            <li><a href='http://www.quizmine.com/Sudoku.aspx'>Sudoku</a></li>
                            <li><a href='http://www.quizmine.com/Snake.aspx'>Healthy Snake</a></li>
                        </ul>
                        <!--Top Drop Down Menu 4 HTML-->
                        <ul id="ddsubmenu4" class="ddsubmenustyle">
                            <li><a href='http://www.quizmine.com/aims.aspx'>Arizona (AZ - AIMS )</a></li>
                            <li><a href='http://www.quizmine.com/cst.aspx'>California (CA - CST and CAHSEE )</a></li>
                            <li><a href='http://www.quizmine.com/csap.aspx'>Colorado (CO - CSAP )</a></li>
                            <li><a href='http://www.quizmine.com/fcat.aspx'>Florida (FL - FCAT )</a></li>
                            <li><a href='http://www.quizmine.com/CRCT.aspx'>Georgia (GA - CRCT )</a></li>
                            <li><a href='http://www.quizmine.com/ISAT.aspx'>Illinois (IL - ISAT )</a></li>
                            <li><a href='http://www.quizmine.com/KCCT.aspx'>Kentucky(KY - KCCT)</a></li>
                            <li><a href='http://www.quizmine.com/MSA.aspx'>Maryland(MD - MSA )</a></li>
                            <li><a href='http://www.quizmine.com/MCAS.aspx'>Massachusetts(MA - MCAS )</a></li>
                            <li><a href='http://www.quizmine.com/MEAP.aspx'>Michigan(MI - MEAP )</a></li>
                            <li><a href='http://www.quizmine.com/MCA-II.aspx'>Minnesota(MN - MCA-II )</a></li>
                            <li><a href='http://www.quizmine.com/MAP.aspx'>Missouri(MO - MAP )</a></li>
                            <li><a href='http://www.quizmine.com/ASK.aspx'>New Jersey(NJ - NJ ASK )</a></li>
                            <li><a href='http://www.quizmine.com/NYS.aspx'>New York (NY - NYS (3 - 8) )</a></li>
                            <li><a href='http://www.quizmine.com/EOG.aspx'>North Carolina (NC - EOG )</a></li>
                            <li><a href='http://www.quizmine.com/OAT.aspx'>Ohio (OH - OAT )</a></li>
                            <li><a href='http://www.quizmine.com/OCCT.aspx'>Oklahoma (OK - OCCT )</a></li>
                            <li><a href='http://www.quizmine.com/OSA.aspx'>Oregon (OR - OSA )</a></li>
                            <li><a href='http://www.quizmine.com/PSSA.aspx'>Pennsylvania (PA - PSSA )</a></li>
                            <li><a href='http://www.quizmine.com/TCAP.aspx'>Tennessee (TN - TCAP )</a></li>
                            <li><a href='http://www.quizmine.com/TAKS.aspx'>Texas (TX - TAKS )</a></li>
                            <li><a href='http://www.quizmine.com/SOL.aspx'>Virginia (VA - SOL )</a></li>
                            <li><a href='http://www.quizmine.com/WASL.aspx'>Washington (WA - WASL )</a></li>
                            <li><a href='http://www.quizmine.com/WKCE-CRT.aspx'>Wisconsin (WI - WKCE - CRT )</a></li>
                        </ul>
                        <ul id="ddsubmenu5" class="ddsubmenustyle">
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=810494ce-725b-4463-a73b-dc555d6be75f&ExamId=f665320f-a80c-497c-bcdc-7659ade8ff2f'>
                                KS2 Math (Key Stage 2) </a></li>
                            <li><a href='http://www.quizmine.com/CategoryPage.aspx?SubjectId=d2aa0daf-df2d-473b-af72-599847bcf59c&ExamId=ae95945a-2281-4828-89e0-481158b5c0b3'>
                                KS3 Math (Key Stage 3) </a></li>
                        </ul>
                        <ul id="ddsubmenu6" class="ddsubmenustyle">
                            <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=A9FC4996-4134-43DB-844A-6AA9E7B7ACB5'>
                                AIEEE 2010</a></li>
                            <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=D9D06388-0C75-4AF5-B7C6-2ED3D01B44F3'>
                                IIM CAT 2009 </a></li>
                            <li><a href='http://www.quizmine.com/Categories.aspx?ExamId=9C46B946-1DA0-4B75-88BA-628F8F466E91'>
                                IIT JEE 2010</a></li>
                        </ul>
                    </td>
                </tr>
            </table>
            <td>
    </tr>--%>
                                    <script type="text/javascript" language="javascript">
                                        function setCookie(c_name, value) {
                                            //var exdate=new Date()
                                            //exdate.setDate(expiredays)
                                            document.cookie = c_name + "=" + escape(value)

                                        }
                                        function ReadCookie(cookieName) {
                                            var theCookie = "" + document.cookie;
                                            var ind = theCookie.indexOf(cookieName);
                                            if (ind == -1 || cookieName == "") return "";
                                            var ind1 = theCookie.indexOf(';', ind);
                                            if (ind1 == -1) ind1 = theCookie.length;
                                            return unescape(theCookie.substring(ind + cookieName.length + 1, ind1));
                                        }
                                        document.getElementById('jsEnable').innerHTML = '';
                                        document.cookie = 'ppkcookie1=testcookie';
                                        /* check for a cookie */
                                        var uu = ReadCookie('ppkcookie1')
                                        if (uu == "") {
                                            /* if a cookie is not found - shift user -
                                            */
                                            document.location.href = "EnableCookie.aspx";
                                        }

                                        //this javascript is for shifting mode of browser
                                        var browserName;
                                        var browserVer;

                                        if (navigator.userAgent.indexOf("Firefox") > -1) {
                                            var getFFVersion = navigator.userAgent.substring(navigator.userAgent.indexOf("Firefox")).split("/")[1]

                                            browserVer = parseInt(getFFVersion);
                                            browserName = "FireFox"
                                        }
                                        if (navigator.userAgent.indexOf("MSIE") > -1) {
                                            //alert(navigator.userAgent.substring(navigator.userAgent.indexOf("MSIE")))
                                            var tem = navigator.userAgent.substring(navigator.userAgent.indexOf("MSIE")).split(";")[0]
                                            var getFFVersion = tem.split(" ")[1]
                                            browserVer = getFFVersion;
                                            browserName = "MSIE"
                                        }
                                        if (navigator.userAgent.indexOf("Opera") > -1) {
                                            var getFFVersion = navigator.userAgent.substring(navigator.userAgent.indexOf("Opera")).split("/")[1]
                                            browserVer = parseInt(getFFVersion);
                                            browserName = "Opera"
                                        }
                                        if (navigator.userAgent.indexOf("Netscape") > -1) {
                                            var getFFVersion = navigator.userAgent.substring(navigator.userAgent.indexOf("Netscape")).split("/")[1]
                                            browserVer = parseInt(getFFVersion);
                                            browserName = "Netscape"
                                        }
                                        //var browserName=navigator.appName;
                                        //var browserVer=parseInt(navigator.appVersion) ;

                                        var pp = ReadCookie('HTMLMode')

                                        if (pp == '' || pp == null || pp == 'false') {
                                            var os = navigator.platform;

                                            if (os != "Win32" && browserName != "FireFox") {
                                                document.getElementById('browserShifting').innerHTML = "<font color=green size=2>Your Operating System is not ajax compilent.Please shift to  <a href=# onclick=SetHtmMode()>HTML Mode</a> for proper functioning</font>"
                                                document.getElementById('browserShifting').style.display = "none";
                                                document.cookie = 'HTMLMode=true';
                                            }

                                            if ((browserName == "FireFox" && browserVer >= 0.7) || (browserName == "MSIE" && browserVer >= 4) || (browserName == "Opera" && browserVer > 8) || (browserName == "Netscape" && browserVer >= 7)) {
                                                // alert(browserName); 
                                                // alert(browserVer);
                                            }
                                            else {
                                                document.cookie = 'HTMLMode=true';

                                                document.getElementById('browserShifting').style.display = "none";
                                            }

                                        }



                                        function SetHtmMode() {
                                            document.cookie = 'HTMLMode=true';
                                            document.getElementById('browserShifting').style.display = "none";
                                        }
				
                                    </script>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <div id="silverlightControlHost">
                                <object data="data:application/x-silverlight-2," type="application/x-silverlight-2"
                                    width="940" height="480">
                                    <param name="source" value="ClientBin/SilverlightMathPad.xap" />
                                    <param name="onError" value="onSilverlightError" />
                                    <param name="background" value="white" />
                                    <param name="minRuntimeVersion" value="3.0.40818.0" />
                                    <param name="autoUpgrade" value="true" />
                                    <a href="http://go.microsoft.com/fwlink/?LinkID=149156&v=3.0.40818.0" style="text-decoration: none">
                                        <img src="http://go.microsoft.com/fwlink/?LinkId=161376" alt="Get Microsoft Silverlight"
                                            style="border-style: none" />
                                    </a>
                                </object>
                                <iframe id="_sl_historyFrame" style="visibility: hidden; height: 0px; width: 0px;
                                    border: 0px"></iframe>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <div id="divUSA" runat="server" visible="true">
                                <table class="styleTableFooterBar" width="100%">
                                    <tr>
                                        <td class="styleTDFooterPrice" style="height: 82px; text-align: center">
                                            <a href="http://www.quizmine.com/Purchase.aspx"><strong>$
                                                <%=System.Configuration.ConfigurationManager.AppSettings["BasicPaidModeUSD"]%>
                                                per year</strong></a>&nbsp;
                                            <br />
                                            <br>
                                            (<strong>Basic Paid Mode</strong>)
                                            <br>
                                            <br>
                                            Quizzes and tutorials for 1 Exam&nbsp; &nbsp;
                                        </td>
                                        <td class="styleTDFooterPrice" style="height: 82px; text-align: center">
                                            <a href="http://www.quizmine.com/Purchase.aspx"><strong>$
                                                <%=System.Configuration.ConfigurationManager.AppSettings["PremiumPaidModeUSD"]%>
                                                per year</strong></a>&nbsp;
                                            <br>
                                            <br>
                                            (<strong>Premium Paid Mode</strong>)
                                            <br>
                                            <br>
                                            Basic paid mode + Video + Animation (For 1 exam)
                                        </td>
                                        <td class="styleTDFooterPrice" style="height: 82px; text-align: center">
                                            &nbsp; &nbsp;<a href="http://www.quizmine.com/Purchase.aspx" class="style4"><strong>$
                                                <%=System.Configuration.ConfigurationManager.AppSettings["LifeTimePaidModeUSD"]%>
                                                LifeTime </strong></a>
                                            <br>
                                            <br>
                                            (<strong>LifeTime Mode</strong>)&nbsp;
                                            <br>
                                            <br>
                                            All Exams + LifeTime of Access
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="styleTDFooterPrice" style="text-align: center">
                                            Email: <a href="mailto:quizminegroup@quizmine.com?subject=Need more information"
                                                class="style4">Quizminegroup@quizmine.com</a>
                                        </td>
                                        <td class="styleTDFooterPrice" style="text-align: center">
                                            Call: (425) 556 9604 in USA
                                        </td>
                                        <td class="styleTDFooterPrice" style="text-align: center">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table class="styleTableFooterBar" width="100%">
                                    <tr>
                                        <td class="styleTableFooterBarTD">
                                            <a class="styleTableFooterbarAlink" href="http://www.quizmine.com/feedback.aspx">Feedback</a>&nbsp;
                                            |&nbsp; <a class="styleTableFooterbarAlink" href="http://www.quizmine.com/Terms.aspx">
                                                Legal</a>&nbsp;&nbsp; |&nbsp; <a class="styleTableFooterbarAlink" href="http://www.quizmine.com/PointSystem.aspx">
                                                    Help</a>&nbsp; |&nbsp; <a class="styleTableFooterbarAlink" id="anchUserStatus" href="http://www.quizmine.com/Registration.aspx"
                                                        name="anchUserStatus" runat="server">Register</a>&nbsp; |&nbsp; <a class="styleTableFooterbarAlink"
                                                            href="http://www.quizmine.com/sitemap.aspx">Site Map</a> | <a class="styleTableFooterbarAlink"
                                                                href="mailto:quizminegroup@quizmine.com?subject=Need more information">Contact Us</a>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 81%">
                                            <table>
                                                <tr>
                                                    <td class="region_clr_footerRight" style="width: 168px">
                                                        Select Your Region:&nbsp;&nbsp;
                                                    </td>
                                                    <td class="region_clr_footer">
                                                        <img src="Img/usaFlag.gif" border="0" width="37" height="16">&nbsp;
                                                    </td>
                                                    <td class="region_clr_footerLeft" style="width: 186px">
                                                        <strong>United States (Selected)</strong>
                                                    </td>
                                                    <td class="region_clr_footer">
                                                        &nbsp;|&nbsp;
                                                    </td>
                                                    <!--
		<td class="region_clr_footer" >
		<img src="flags/uk_small_flag.gif"  border="0">&nbsp;</td>
		<td class="region_clr_footer" style="width: 104px" >
		<a target="_top" class="region_clr" href="default.aspx?ExamRegion=UK">United Kingdom</a></td>
		<td class="region_clr_footer" style="width: 10px" >&nbsp;|&nbsp;</td>
		<td class="region_clr_footer" >
		<img src="Flags/india_flag.gif"  border="0" width="43" height="21">&nbsp;</td>-->
                                                    <td class="region_clr_footer">
                                                        <a class="region_clr" href="http://www.quizmine.com/india.aspx?UserCountry=India">India
                                                            (for IIT, IIM)</a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="region_clr_footer">
                                            &nbsp;|&nbsp;
                                        </td>
                                        <td class="region_clr_footer">
                                            <a class="region_clr" href="http://www.quizmine.com/UK.aspx?UserCountry=UK">UK&nbsp;
                                                (for KS2 and KS3)</a>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <p id="copyright0" class="region_clr_footer" align="center">
                                                Copyright 2009 Quizmine.com, All rights reserved.</p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="styleTableFooterMkt">
                                            <br>
                                            <span style="font-size: x-small"><a href="http://www.quizmine.com/ceo.aspx"><span
                                                style="color: #FF0000">Email to CEO (Return response guranteed)</span></a> |
                                            </span><a style="font-size: 10pt; color: #000080; font-family: Verdana, Geneva, Arial, Helvetica, sans-serif;
                                                text-align: left; text-decoration: underline;" href="http://www.quizmine.com/default.aspx#Animation_anchor">
                                                <strong>Super Cool Animation</strong></a>&nbsp; | <a href="http://www.quizmine.com/coolvideo.aspx"
                                                    style="font-weight: normal; font-size: 10pt; color: #000080; font-family: Verdana, Geneva, Arial, Helvetica, sans-serif;
                                                    text-align: left; text-decoration: underline;"><strong>Super Cool Videos</strong></a>
                                            | <strong><a href="http://www.quizmine.com/teacher/">Teacher Login</a></strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="styleTableFooterMkt">
                                            ** <span style="font-size: x-small"><a target="_blank" href="http://www.quizmine.com/jobsandintern.aspx">
                                                Jobs and Internships</a>**</span>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
