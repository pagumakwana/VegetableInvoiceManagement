<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/_layoutAdmin.Master" AutoEventWireup="true" CodeBehind="500.aspx.cs" Inherits="InvoiceManagement.Module.Error._500" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="error-page">
        <h2 class="headline text-red">500</h2>

        <div class="error-content">
            <h3><i class="fa fa-warning text-red"></i>Oops! Something went wrong.</h3>

            <p>
                We will work on fixing that right away.
            Meanwhile, you may <a href="/Report/dashboard.aspx">return to dashboard</a> or try using the search form.
         
            </p>

            <div class="search-form">
                <div class="input-group">
                    <input type="text" name="search" class="form-control" placeholder="Search"/>

                    <div class="input-group-btn">
                        <button type="submit" name="submit" class="btn btn-danger btn-flat">
                            <i class="fa fa-search"></i>
                        </button>
                    </div>
                </div>
                <!-- /.input-group -->
            </div>
        </div>
    </div>
    <!-- /.error-page -->
</asp:Content>
