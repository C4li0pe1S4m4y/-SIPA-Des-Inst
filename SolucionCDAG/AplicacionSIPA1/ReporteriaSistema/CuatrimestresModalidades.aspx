<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CuatrimestresModalidades.aspx.cs" Inherits="AplicacionSIPA1.ReporteriaSistema.CuatrimestresModalidades" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2> Reporte Modalidades Cuatrimestre</h2>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-2">
            <label>Año</label>
            <asp:DropDownList ID="ddlanio" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
          <div class="col-sm-3">
            <label>Unidad</label>
            <asp:DropDownList ID="ddlUnidad" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUnidad_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
         <div class="col-sm-3">
            <label>Dependencia</label>
            <asp:DropDownList ID="ddlDependencia" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
     <div class="col-sm-12" style="width: 100%; height: 100%; left: 23px; top: 3px;">

        <rsweb:ReportViewer ID="ReportViewer1"  runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1473px">
             <LocalReport ReportPath="Reportes\rptCuatrimestreModalidades.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
              
        </rsweb:ReportViewer>
        
    </div>
</asp:Content>
