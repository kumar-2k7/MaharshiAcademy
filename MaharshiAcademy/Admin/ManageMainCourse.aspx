<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ManageMainCourse.aspx.cs"
    Inherits="Admin_ManageMainCourse" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="CSS/GridViewPagingCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Main Course</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Manage Main Course
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label>New Course Name</label>
                                    <asp:TextBox ID="txtMainCourseName" placeholder="Enter Course" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="MainCourse" Display="Dynamic" ControlToValidate="txtMainCourseName" runat="server" Text="*" ErrorMessage="Enter Course Name" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Course Description</label>
                                    <asp:TextBox ID="txtMainCourseDesc" placeholder="Enter Course Description" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="MainCourse" Display="Dynamic" ControlToValidate="txtMainCourseDesc" runat="server" Text="*" ErrorMessage="Enter Course Description" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <asp:Button ID="btnSaveNewMainCourse" runat="server" Text="Save" CssClass="btn btn-default" OnClick="btnSaveNewMainCourse_Click" ValidationGroup="MainCourse" />
                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="MainCourse" ShowMessageBox="true" ShowSummary="false" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset Button" CssClass="btn btn-default" OnClick="btnReset_Click" />
                            </div>
                            <!-- /.col-lg-6 (nested) -->
                        </div>
                        <!-- /.row (nested) -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <div id="div_grdMainCourse" class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Main Course(s)
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="table-responsive">
                            <asp:GridView ID="grdMainCourse" runat="server" EmptyDataText="No Record(s) Found" AllowPaging="true"
                                PageSize="10" PagerStyle-CssClass="pagination-ys" PagerSettings-Mode="NumericFirstLast"
                                PagerSettings-FirstPageText="First Page" PagerSettings-LastPageText="Last Page"
                                CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false"
                                OnPageIndexChanging="grdMainCourse_PageIndexChanging" OnRowCommand="grdMainCourse_RowCommand"
                                OnRowDeleting="grdMainCourse_RowDeleting" OnRowEditing="grdMainCourse_RowEditing"
                                OnRowUpdating="grdMainCourse_RowUpdating" OnRowCancelingEdit="grdMainCourse_RowCancelingEdit"
                                DataKeyNames="MAIN_COURSE_ID" OnRowDataBound="grdMainCourse_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="COURSE NAME">
                                        <ItemTemplate>
                                            <%# Eval("COURSE_NAME") %>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMainCourseNameGRD" runat="server" CssClass="form-control" Text='<%# Eval("COURSE_NAME") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="COURSE DESCIRPTION">
                                        <ItemTemplate>
                                            <%# Eval("COURSE_DESC") %>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtMainCourseDescGRD" runat="server" CssClass="form-control" Text='<%# Eval("COURSE_DESC") %>'></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CREATED DATE">
                                        <ItemTemplate>
                                            <%# DbConnect.GetDateFormat(Eval("CREATED_ON").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MODIFIED DATE">
                                        <ItemTemplate>
                                            <%# DbConnect.GetDateFormat(Eval("MODIFIED_ON").ToString()) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Active">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkPURGEFLAG" runat="server" AutoPostBack="true" OnCheckedChanged="chkPURGEFLAG_OnCheckedChanged" />
                                            <asp:HiddenField ID="hdnfPurgeFlag" runat="server" Value='<%# Eval("PURGEFLAG").ToString() %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="btn btn-default" CommandName="Edit"
                                                CommandArgument='<%#Eval("MAIN_COURSE_ID").ToString()%>'><%#Eval("MAIN_COURSE_ID").ToString() == "0" ? "" : "Edit"%></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lbtnUpdate" runat="server" CssClass="btn btn-default" OnClientClick="return confirm('Are you sure, you want to update?');"
                                                CommandName="Update" CommandArgument='<%#Eval("MAIN_COURSE_ID").ToString()%>'><%#Eval("MAIN_COURSE_ID").ToString() == "0" ? "" : "Update"%></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnk_delete" runat="server" CssClass="btn btn-default" OnClientClick="return confirm('Are you sure, you want to delete?');"
                                                CommandName="Delete" CommandArgument='<%#Eval("MAIN_COURSE_ID").ToString()%>'><%#Eval("MAIN_COURSE_ID").ToString() == "0" ? "" : "Delete"%></asp:LinkButton>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="lbtnCancel" runat="server" CssClass="btn btn-default" CommandName="Cancel"
                                                CommandArgument='<%#Eval("MAIN_COURSE_ID").ToString()%>'><%#Eval("MAIN_COURSE_ID").ToString() == "0" ? "" : "Cancel"%></asp:LinkButton>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!-- /.table-responsive -->
                    </div>
                    <!-- /.panel-body -->
                </div>
                <!-- /.panel -->
            </div>
            <!-- /.col-lg-6 -->
        </div>
        <!-- /.row -->
    </div>
</asp:Content>

