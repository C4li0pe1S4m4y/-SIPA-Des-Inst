﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ReportePedidos.aspx.cs" Inherits="AplicacionSIPA1.ReporteriaSistema.ReportePedidos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2>&nbsp;&nbsp;&nbsp;&nbsp; Listado Documentos Por Acciones </h2>

    <asp:Label runat="server" ID="lblIdPoa" Visible="false" />
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-md-2">
            <asp:Label ID="lblAnio" runat="server" Text="Año"></asp:Label>
            <asp:DropDownList ID="ddlAnios" runat="server" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" AutoPostBack="True" class="form-control" Width="100%">
            </asp:DropDownList>
        </div>
        <div class="col-md-5">
            <asp:Label ID="lblUnidad" runat="server" Text="Unidad"></asp:Label>
            <asp:DropDownList ID="ddlUnidades" runat="server" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" AutoPostBack="True" class="form-control" Width="90%">
            </asp:DropDownList>
        </div>
        <div class="col-sm-4">
            <label>Dependencia</label>
            <asp:DropDownList ID="ddlDependencias" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged" Width="80%"></asp:DropDownList>
        </div>

    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-md-10">
            <asp:Label ID="lblAccion" runat="server" Text="Accion"></asp:Label>
            <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" BackColor="#003366" class="form-control" ForeColor="White" Width="103%">
            </asp:DropDownList>
        </div>
    </div>


    
    <br />
    <asp:Label runat="server" ID="lblErrorPoa" />
    <div class="row">
        <div style="text-align: center;">
            <span>
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
            </span>
        </div>
    </div>
    <div class="col-sm-12" style="width: 100%; height: 100%;">

        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1425px" Height="783px" Style="margin-right: 110px; margin-top: 24px;">
            <LocalReport ReportPath="Reportes\ReporteSaldosAccionesPor.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource2" Name="DataSet1" />
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource3" Name="DataSet2" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT SUM(d.monto) AS monto FROM sipa_detalles_accion d INNER JOIN sipa_acciones aa ON aa.id_accion = d.id_accion INNER JOIN sipa_renglones r ON d.no_renglon = r.No_Renglon INNER JOIN sipa_tipos_financiamiento f ON d.id_tipo_financiamiento = f.id_tipo WHERE (aa.id_poa IN (33,37,40,43,49,56,57,58,59,61,62,63,64,86,87,88,89))"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT no_solicitud, Año, Accion, Documento, fecha_pedido, Descripcion, Estado, unidad_administrativa, Pedido, costo_estimado, costo_real, no_renglon, no_pac, anio_solicitud, id_unidad, id_accion, id_tipo_documento, id_estado_pedido, Solicitante FROM (SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.Descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_pedido AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, p.id_pac AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_pedido_detalle c ON a.id_pedido = c.id_pedido LEFT OUTER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN sipa_pac p ON p.id_pac = c.id_pac INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante WHERE (a.id_tipo_documento = 1) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_vale AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_ccvale_detalle c ON a.id_pedido = c.id_ccvale LEFT OUTER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante WHERE (a.id_tipo_documento = 2) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '') AS Expr1, a.fecha_pedido, c.descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_gasto AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_gasto_detalle c ON a.id_pedido = c.id_gasto LEFT OUTER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante WHERE (a.id_tipo_documento = 3) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real, d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_viaticos c ON a.id_pedido = c.id_viatico LEFT OUTER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = c.id_tipo_viatico WHERE (a.id_tipo_documento = 4)) t"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:dbcdagsipaConnectionString1 %>" ProviderName="<%$ ConnectionStrings:dbcdagsipaConnectionString1.ProviderName %>" SelectCommand="SELECT no_solicitud, Año, Accion, Documento, fecha_pedido, Descripcion, Estado, unidad_administrativa, Pedido, costo_estimado, costo_real, no_renglon, no_pac, anio_solicitud, id_unidad, id_accion, id_tipo_documento, id_estado_pedido, Solicitante FROM (SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.Descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_pedido AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, p.id_pac AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_pedido_detalle c ON a.id_pedido = c.id_pedido INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN sipa_pac p ON p.id_pac = c.id_pac INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante WHERE (a.id_tipo_documento = 1) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, a.Documento, a.fecha_pedido, c.descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_vale AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_ccvale_detalle c ON a.id_pedido = c.id_ccvale INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante WHERE (a.id_tipo_documento = 2) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '') AS Expr1, a.fecha_pedido, c.descripcion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_gasto AS Pedido, c.costo_estimado, c.costo_real, d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_gasto_detalle c ON a.id_pedido = c.id_gasto INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante WHERE (a.id_tipo_documento = 3) UNION ALL SELECT a.no_solicitud, a.anio_solicitud AS Año, fn_codigo_accion(b.id_accion, 0, '', 1) AS Accion, CONCAT(a.Documento, '/', tv.abreviatura) AS Expr1, a.fecha_pedido, c.justificacion, a.estado_salida AS Estado, a.unidad_administrativa, c.costo_viatico + c.pasajes + c.kilometraje AS Pedido, c.costo_estimado + c.pasajes_estimado + c.kilometraje_estimado AS costo_estimado, c.costo_real + c.pasajes_real + c.kilometraje_real AS costo_real, d.no_renglon, 'N/A' AS no_pac, a.anio_solicitud, a.id_unidad, b.id_accion, a.id_tipo_documento, a.id_estado_pedido, CONCAT(se.id_empleado, ' - ', se.nombres) AS Solicitante FROM unionpedidocc a INNER JOIN sipa_acciones b ON a.id_accion = b.id_accion INNER JOIN sipa_viaticos c ON a.id_pedido = c.id_viatico INNER JOIN sipa_detalles_accion d ON d.id_detalle = c.id_detalle_accion INNER JOIN ccl_empleados se ON se.id_empleado = a.id_solicitante INNER JOIN sipa_tipos_viatico tv ON tv.id_tipo_viatico = c.id_tipo_viatico WHERE (a.id_tipo_documento = 4)) t"></asp:SqlDataSource>


    </div>
</asp:Content>

