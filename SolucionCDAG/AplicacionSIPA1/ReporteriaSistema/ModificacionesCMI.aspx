<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ModificacionesCMI.aspx.cs" Inherits="AplicacionSIPA1.ReporteriaSistema.ModificacionesCMI" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2 style="text-align: center">Modificaciones CMI</h2>
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
            <label>Dependencia</label>
            <asp:DropDownList ID="ddlDependencias" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDependencias_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-9">
            <label>Accion</label>
            <asp:DropDownList ID="ddlAccion" runat="server" CssClass="form-control" BackColor="#003366" OnSelectedIndexChanged="ddlAccion_SelectedIndexChanged" ForeColor="White" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-sm-2">
            <br />

            <asp:Button ID="btnReport" runat="server" Text="Reporte" CssClass="btn btn-info" OnClick="btnReport_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-11">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1424px" Height="500px">
                <LocalReport ReportPath="Reportes\rptCMIModificaciones.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
        <div class="col-sm-1"></div>
        <div class="col-sm-11">

            <rsweb:ReportViewer ID="ReportViewer2" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1424px" Visible="false" Height="500px">
                <LocalReport ReportPath="Reportes\rptCMIModificacionesAnalista.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>

        </div>
    </div>
</asp:Content>

