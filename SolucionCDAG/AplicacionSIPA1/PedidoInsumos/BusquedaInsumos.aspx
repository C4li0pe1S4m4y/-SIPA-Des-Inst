<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="BusquedaInsumos.aspx.cs" Inherits="AplicacionSIPA1.PedidoInsumos.BusquedaInsumos" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
     
        .auto-style14 {
            position: relative;
            min-height: 1px;
            color: #333333;
            top: 11px;
            left: 63px;
            width: 6%;
            float: left;
            padding-left: 15px;
            padding-right: 15px;
        }
        .auto-style15 {
            font-size: small;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2 style="text-align:center">Busqueda de Insumos</h2>

    <div class="row">
        <div class="col-xs-1">
            <label>Renglon</label>
            <asp:TextBox ID="txtRenglon" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
           
        </div>
        
        <div class="col-xs-1">
            <label><span class="auto-style15">Codigo Insumo</span></label>
            <asp:TextBox ID="txtCodigoInsumo" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
           
        </div>
        <div class="col-xs-1">
            <label>Nombre</label>
            <asp:TextBox ID="txtNombre" runat="server" Width="100%" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="col-xs-2">
            <label>Caracteristicas</label>
            <asp:TextBox ID="txtCaracteristicas" runat="server" Width="100%" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="col-xs-1">
            <label>Presentacion</label>
            <asp:TextBox ID="txtPresentacion" runat="server" Width="100%" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="col-xs-1">
            <label>Cantidad</label>
            <asp:TextBox ID="txtCantidad" runat="server" Width="100%" CssClass="form-control" ></asp:TextBox>
        </div>
        <div class="col-xs-1">
             <label><span class="auto-style15">Codigo Presentacion</span></label>
            <asp:TextBox ID="txtCodigoPresentacion" runat="server" Width="100%" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </div>
        <div class="auto-style14">
            <br />
            <asp:ImageButton ID="btnRenglon" runat="server" OnClick="btnRenglon_Click" ImageUrl="~/img/24_bits/find.png" CssClass="auto-style13" Height="28px" Width="33px" />
        </div>
    </div>
    <div class="col-xs-12" style="width: 100%; height: 100%;">
        <br />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1238px" Height="495px" CssClass="auto-style11">
            <LocalReport ReportPath="Reportes\rptCatalogoInsumos.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString2 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString2.ProviderName %>" SelectCommand="SELECT renglon, codigo_insumo, Nombre, Caracteristicas, Presentacion, cantidad_unidad, codigo_presentacion FROM ccl_catalogo"></asp:SqlDataSource>

    </div>
</asp:Content>
