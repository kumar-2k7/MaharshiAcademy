<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ManageSubCategory.aspx.cs" Inherits="Admin_ManageSubCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="CSS/GridViewPagingCSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Sub Categories</h1>
            </div>
            <!-- /.col-lg-12 -->
        </div>
        <!-- /.row -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        Manage Sub Category
                   
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="form-group">
                                    <label for="disabledSelect">Select Main Course</label>
                                    <asp:DropDownList ID="ddlMainCourse" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="SubCategory" Display="Dynamic" Text="*" ForeColor="Red" ControlToValidate="ddlMainCourse" InitialValue="0" runat="server" ErrorMessage="Select Main Course"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>New Sub Category</label>
                                    <asp:TextBox ID="txtSubCategoryName" placeholder="Enter Sub Category" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="SubCategory" Display="Dynamic" Text="*" ForeColor="Red" ControlToValidate="txtSubCategoryName" runat="server" ErrorMessage="Enter New Sub Category"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Sub Category Description</label>
                                    <asp:TextBox ID="txtSubCategoryDesc" placeholder="Enter Sub Category Description" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="SubCategory" Display="Dynamic" Text="*" ForeColor="Red" ControlToValidate="txtSubCategoryDesc" runat="server" ErrorMessage="Enter Sub Category Description"></asp:RequiredFieldValidator>
                                </div>
                                <asp:Button ID="btnSaveNewSubCategory" runat="server" Text="Save" CssClass="btn btn-default" ValidationGroup="SubCategory"
                                    OnClick="btnSaveNewSubCategory_Click" />
                                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="SubCategory" ShowMessageBox="true" ShowSummary="false" runat="server" />
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
                        Sub Category List
                       
                    </div>
                    <!-- /.panel-heading -->
                    <div class="panel-body">
                        <div class="table-responsive">
                            <asp:GridView ID="grdSubCategory" runat="server" EmptyDataText="No Record(s) Found"
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
                                    <asp:TemplateField HeaderText="SUB-CATEGORY DESCIRPTION">
                                        <ItemTemplate>
                                            <%# Eval("SUBCAT_DESC") %>
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

