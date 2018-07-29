<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ManageChapter.aspx.cs" Inherits="Admin_ManageChapter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Chapter(s)</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Manage Chapters
                   
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-6">
                                <asp:UpdatePanel ID="updPanel_ManageChapter" runat="server">
                                    <ContentTemplate>
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <label for="disabledSelect">Select Subject(s)</label>
                                            </div>
                                            <div class="panel-body">
                                                <%--<asp:CheckBoxList ID="chklSubject" runat="server" CssClass="checkbox"></asp:CheckBoxList>--%>
                                                <asp:DropDownList ID="ddlSubject" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>New Chapter</label>
                                            <asp:TextBox ID="txtChapterName" placeholder="Enter Chapter Name" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="panel panel-default">
                                            <div class="panel-heading">
                                                <label for="disabledSelect">Select Main Course - Sub Category</label>
                                            </div>
                                            <div class="panel-body">
                                                <asp:CheckBoxList ID="chklMainCourseSubCategory" AutoPostBack="true" runat="server" CssClass="checkbox">
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:Button ID="btnSaveNewChapter" runat="server" Text="Save" CssClass="btn btn-default"
                                    OnClick="btnSaveNewChapter_Click" />
                                <asp:Button ID="btnReset" runat="server" Text="Reset Button" CssClass="btn btn-default"
                                    OnClick="btnReset_Click" />
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
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Chapter List
                       
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="table-responsive">
                            <asp:GridView ID="grdSubject" runat="server" EmptyDataText="No Record(s) Found"
                                CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="COURSE NAME">
                                        <ItemTemplate>
                                            <%# Eval("COURSE_NAME") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SUB-CATEGORY NAME">
                                        <ItemTemplate>
                                            <%# Eval("SUBCAT_NAME") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SUBCAT NAME">
                                        <ItemTemplate>
                                            <%# Eval("SUBJECT_NAME") %>
                                        </ItemTemplate>
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
                                    <asp:TemplateField HeaderText="Is Active">
                                        <ItemTemplate>
                                            <%# Eval("PURGEFLAG").ToString()=="A"?true:false %>
                                        </ItemTemplate>
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

