<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="SaldosRenglonesCuatrimestres.aspx.cs" Inherits="AplicacionSIPA1.ReporteriaSistema.SaldosRenglonesCuatrimestres" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3 class="text-center">Consulta Renglones Presupuestarios Por Cuatrimestres </h3>
    <div class="row">
        <div class="col-sm-1">
        </div>
        <div class="col-sm-2">
            <label>Año</label>
            <asp:TextBox ID="txtAnio" runat="server" CssClass="form-control" OnTextChanged="txtAnio_TextChanged" AutoPostBack="true" TextMode="Number"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <label>Cuatrimestre</label>
            <asp:DropDownList ID="ddlCuatrimestre" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCuatrimestre_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <asp:GridView ID="gridReportes" runat="server" OnRowDataBound="gridReportes_RowDataBound"  Width="100%" ShowFooter="True">
                <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle BackColor="#339933" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-sm-1"></div>
        
        <p style="color:InfoText">Reporte de Requisiciones por Baja Cuantilla (Valores menores a Q25,000.00). Solo se toman en cuenta los Servicios. </p>
    </div>
</asp:Content>
