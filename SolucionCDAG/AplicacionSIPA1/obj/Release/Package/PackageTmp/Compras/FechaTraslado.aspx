<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FechaTraslado.aspx.cs" Inherits="AplicacionSIPA1.Compras.FechaTraslado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2 style="text-align: center">Fecha de Traslado de Requisicion.</h2>
    
        <div class="row">
            <div class="col-sm-5"></div>
            <div class="col-sm-2">
                <label>No.Req.</label>
                <asp:TextBox ID="txtNo" BackColor="#fff29d" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-sm-1">
                <label>Año</label>
                <asp:DropDownList ID="ddlanio" Width="100%" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-sm-2">
                <br />
                <asp:Button ID="btnBusqueda" Width="75%" runat="server" Text="Buscar" CssClass="btn btn-info" />
            </div>
        </div>
  
</asp:Content>
