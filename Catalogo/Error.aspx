<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Catalogo.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container text-center min-vh-100">
        <div class="row" style="margin-top:50px">
            <div class="col">
                <asp:Label Text="" ID="lblMensaje" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
