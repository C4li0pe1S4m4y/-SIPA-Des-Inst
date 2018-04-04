<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="BusquedaInsumos.aspx.cs" Inherits="AplicacionSIPA1.PedidoInsumos.BusquedaInsumos" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style11 {
            margin-left: 59px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2 style="text-align:center">Busqueda de Insumos</h2>

    <div class="row">
        <div class="col-xs-3">
            <label>Renglon</label>
            <asp:TextBox ID="txtRenglon" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
           
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
