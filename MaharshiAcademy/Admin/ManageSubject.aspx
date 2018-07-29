<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ManageSubject.aspx.cs" Inherits="Admin_ManageSubject" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Subject(s)</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Manage Subjects
                   
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label>New Subject</label>
                                    <asp:TextBox ID="txtSubjectName" placeholder="Enter Subject Name" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="disabledSelect">Select Main Course - Sub Category</label>
                                    <%--<div class="checkbox">--%>
                                        <asp:CheckBoxList ID="chklMainCourseSubCategory" runat="server" CssClass="checkbox"></asp:CheckBoxList>
                                    <%--</div>--%>
                                </div>
                                <asp:Button ID="btnSaveNewSubCategory" runat="server" Text="Save" CssClass="btn btn-default"
                                    OnClick="btnSaveNewSubCategory_Click" />
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
                        Subject List
                       
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
                                    <asp:TemplateField HeaderText="SUBCAT NAME">
                                        <ItemTemplate>
                                            <%# Eval("SUBJECT_NAME") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SUB-CATEGORY NAME">
                                        <ItemTemplate>
                                            <%# Eval("SUBCAT_NAME") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="COURSE NAME">
                                        <ItemTemplate>
                                            <%# Eval("COURSE_NAME") %>
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

