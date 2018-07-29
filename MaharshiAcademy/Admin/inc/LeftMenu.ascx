<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeftMenu.ascx.cs" Inherits="Admin_inc_LeftMenu" %>
<script language="javascript">
    function DisplaySubMenu(ID) {
        var Path = '<%=DbConnect.GetBaseURL %>'
    try {
        var display = document.getElementById("TR_" + ID).style.display;
        if (display == "") // if visible=true
        {
            document.getElementById("TR_" + ID).style.display = "none";
            document.images["img_" + ID].src = Path + "images/right_arrow.gif"

        }
        else // if visible=false
        {
            document.getElementById("TR_" + ID).style.display = "";
            document.images["img_" + ID].src = Path + "images/Down_arrow.gif"
            //document.getElementById("TR_" + ID).style.backgroundColor='Red';
        }
    }
    catch (e) {
    }
}
function gotopage(ID, URL) {
    //SaveSession(ID);
    document.location.href = URL;
}
function SaveSession(ID) {
    var Result = Admin_inc_LeftMenu.SaveSession(ID).value;
    //alert(Result);
}
</script>
<table cellpadding="0" cellspacing="0" width="100%" border="0">
    <tr>
        <td>
            <asp:Label ID="lblLeftMenu" runat="server"></asp:Label>
        </td>
    </tr>
</table>

