<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ReporteGrupos.aspx.cs" Inherits="AplicacionSIPA1.ReporteriaSistema.ReporteGrupos" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2 style="text-align:center">Reporte Grupos Presupuestarios</h2>
    <div class="row">
        <div class="col-sm-1"><asp:Label ID="lblPoa" runat="server" Visible="false"></asp:Label></div>
        <div class="col-sm-2">
            <label>Año</label>
            <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True"  class="form-control" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged"  ></asp:DropDownList>
        </div>
        <div class="col-sm-3">
            <label>Unidad</label>
            <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" ></asp:DropDownList>
        </div>
         <div class="col-sm-3">
            <label>Dependencia</label>
            <asp:DropDownList ID="ddlDependencia" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" ></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-8">
            <label>Acciones</label>
            <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" BackColor="#003366" class="form-control" ForeColor="White" Width="100%" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    <div class="col-sm-12" style="width: 100%; height: 100%; left: 23px; top: 3px;">

        <rsweb:ReportViewer ID="ReportViewer1"  runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1473px">
             <LocalReport ReportPath="Reportes\rptReporteGrupos.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
              
        </rsweb:ReportViewer>
        
    </div>
</asp:Content>
