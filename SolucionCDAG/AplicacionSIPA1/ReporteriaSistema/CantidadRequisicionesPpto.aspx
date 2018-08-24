<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CantidadRequisicionesPpto.aspx.cs" Inherits="AplicacionSIPA1.ReporteriaSistema.CantidadRequisicionesPpto" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2 style="text-align: center">Cantidad Requisiciones por Analista</h2>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-1">
            <label>Año</label>
            <asp:DropDownList ID="ddlAnios" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-sm-4">
            <label>Unidad</label>
            <asp:DropDownList ID="ddlUnidades" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-sm-4">
            <label>Dependencias</label>
            <asp:DropDownList ID="ddlDependencias" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-2">
            <label>Fecha</label>
            <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-sm-3">
            <label>Analista</label>
            <asp:DropDownList ID="ddlAnalista" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAnalista_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="col-sm-2">
            <br />
            <asp:LinkButton ID="btnBusqueda" Width="75%" runat="server" Text="Buscar" CssClass="btn btn-info" OnClick="btnBusqueda_Click"  Height="60%">
                 Buscar&nbsp <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
            </asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="90%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="475px">
                <LocalReport ReportPath="Reportes\rptCantidadRequisicionesCodificadas.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
    </div>
</asp:Content>
