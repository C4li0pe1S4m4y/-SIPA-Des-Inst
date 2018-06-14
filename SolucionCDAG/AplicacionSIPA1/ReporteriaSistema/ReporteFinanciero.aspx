<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ReporteFinanciero.aspx.cs" Inherits="AplicacionSIPA1.ReporteriaSistema.ReporteFinanciero" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3 class="text-center">Reporte Financiero.</h3>
    <div class="row">
        <div class="col-md-1">
            <asp:Label ID="lblIdPoa" runat="server" Visible="false"></asp:Label></div>
        <div class="col-sm-1">
            <label>Año</label>
            <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" class="form-control" Width="90%"></asp:DropDownList>
        </div>
        <div class="col-sm-4">
            <label>Unidad</label>
            <asp:DropDownList ID="ddlUnidades" runat="server" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" AutoPostBack="True" class="form-control" Width="100%"></asp:DropDownList>
        </div>
        <!-- Se agregaron las lineas de codigo que esta encerradas en el <div> -->
        <div class="col-sm-4">
            <label>Dependencia</label>
            <asp:DropDownList ID="ddlDependencia" runat="server" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" AutoPostBack="True" class="form-control" Width="100%">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-9">
            <asp:Label ID="lblAccion" runat="server" Text="Accion"></asp:Label>
            <asp:DropDownList ID="ddlAcciones" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" runat="server" AutoPostBack="True" BackColor="#003366" class="form-control" ForeColor="White" Width="100%">
            </asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-1">
            <label>No.Requesicion</label>
            <asp:TextBox ID="txtNoReq" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
        </div>

        <div class="col-sm-3">
            <label>Justificación</label>
            <asp:TextBox ID="txtJustificacion" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
        </div>
        <div class="col-sm-3">
            <label>Descripcion</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
        </div>
        <div class="col-lg-3">
            <br />
            <asp:ImageButton ID="btnBusqueda" runat="server" ImageUrl="~/img/24_bits/find.png" OnClick="btnBusqueda_Click" Height="28px" Width="33px" />
        </div>
    </div>
    <div class="col-sm-12" style="width: 100%; height: 100%;">
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1425px" Height="783px" Style="margin-right: 110px; margin-top: 24px;">
            <LocalReport ReportPath="Reportes\rptFinanciero.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>

        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT p.fecha_ing, CONCAT(p.no_solicitud, '-', p.anio_solicitud ) AS No_Requisicion, ac.accion, pd.Descripcion, da.no_renglon, pd.costo_pedido, pd.costo_real, pd.costo_pedido - pd.costo_real AS saldo, CONCAT(p.id_estado_pedido, '-', ep.nombre_estado) AS estado FROM sipa_pedidos p INNER JOIN sipa_acciones ac ON ac.id_accion = p.id_accion INNER JOIN sipa_pedido_detalle pd ON pd.id_pedido = p.id_pedido INNER JOIN sipa_detalles_accion da ON pd.id_detalle_accion = da.id_detalle INNER JOIN sipa_estados_pedido ep ON ep.id_estado_pedido = p.id_estado_pedido"></asp:SqlDataSource>
    </div>
</asp:Content>
