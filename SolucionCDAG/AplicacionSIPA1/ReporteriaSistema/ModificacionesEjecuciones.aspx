<%@ Page Title="Modificaciones Y Ejecuciones" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ModificacionesEjecuciones.aspx.cs" Inherits="AplicacionSIPA1.ReporteriaSistema.ModificacionesEjecuciones" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2 style="text-align:center">Listado Modificaciones y Ejecuciones</h2>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-1">
            <label>Año</label>
            <asp:DropDownList ID="ddlAnios" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="col-sm-4">
            <label>Unidad</label>
            <asp:DropDownList ID="ddlUnidades" runat="server" CssClass="form-control"  AutoPostBack="true" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="col-sm-4">
            <label>Dependencia</label>
            <asp:DropDownList ID="ddlDependencias" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged" ></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-11">
            <rsweb:ReportViewer ID="ReportViewer1"  runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1473px" Height="500px">
            <LocalReport ReportPath="Reportes\EjecYMod.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        </div>
    </div>
</asp:Content>
