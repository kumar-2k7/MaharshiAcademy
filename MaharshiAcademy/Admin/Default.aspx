<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Maharshi Academy - Admin Login</title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />

    <%-- <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="dist/css/sb-admin-2.css" rel="stylesheet" />
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" />--%>
    <link href="CSS/default.css" rel="stylesheet" />
</head>

<body>
    <form id="form1" runat="server">
        <div style="align-self">
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" class="bg">
                <tr>
                    <td height="176" align="left" valign="top"></td>
                </tr>
                <tr>
                    <td height="45" align="center" valign="top">
                        <img src='<%= DbConnect.GetBaseURL %>admin/images/cms_login.gif'
                            width="593" height="45" alt="" />
                    </td>
                </tr>
                <tr>
                    <td height="9" align="left" valign="top"></td>
                </tr>
                <tr>
                    <td align="center" valign="middle">
                        <table width="591" height="333px;" border="0" align="center" cellpadding="0" cellspacing="0"
                            class="login_bg">
                            <tr>
                                <td align="left" valign="top">
                                    <table width="305" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="37" align="left" valign="top">&nbsp;<asp:Label ID="lblmsg" runat="server" class="Blackpt12Bold"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <table width="305" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="54" align="left">&nbsp;
                                                        </td>
                                                        <td align="left" class="login_username">Username
                                                        </td>
                                                        <td width="22" align="left">&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtuserid" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td width="36" align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10" align="left" valign="top"></td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <table width="305" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="6" align="left" valign="top"></td>
                                                        <td align="left" valign="top" style="background-image: url(<%= DbConnect.GetBaseURL %>admin/images/dotted_line.gif); width: 305px; height: 3px; background-repeat: no-repeat;"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10" align="left" valign="top"></td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">
                                                <table width="305" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="54" align="left">&nbsp;
                                                        </td>
                                                        <td align="left" class="login_username">Password
                                                        </td>
                                                        <td width="22" align="left">&nbsp;
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtpassword" runat="server" TextMode="Password"></asp:TextBox>
                                                        </td>
                                                        <td width="36" align="left">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="33" align="left" valign="top"></td>
                                        </tr>
                                        <tr>
                                            <td align="right" valign="top" style="padding-right: 33px;">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Login" OnClick="btnSubmit_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" valign="top">&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="left" valign="top" style="padding-top: 1px;">
                                    <img src='<%= DbConnect.GetBaseURL %>admin/images/login_vertical_line.gif'
                                        width="29" height="217" alt="" />
                                </td>
                                <td align="left" valign="top" style="padding-top: 45px; padding-right: 2px;">
                                    <img src='<%= DbConnect.GetBaseURL %>admin/images/login_MaharshiAcademy.gif'
                                        width="247" height="111" alt="" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="66" align="left" valign="top"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
