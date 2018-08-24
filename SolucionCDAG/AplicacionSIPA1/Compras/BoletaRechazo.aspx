<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="BoletaRechazo.aspx.cs" Inherits="AplicacionSIPA1.Compras.BoletaRechazo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2 style="text-align:center">Boleta de Rechazo</h2>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-1">
            <label>No Boleta</label>
            <asp:TextBox ID="txtNoBoleta" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <label>Fecha Boleta</label>
            <asp:TextBox ID="txtFechaBoleta" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <label>No Requisicion</label>
            <asp:TextBox ID="txtRequisicion" runat="server"  CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-sm-4">
             <label>Motivo de Rechazo</label>
            <br />
            <asp:CheckBoxList ID="chkTiposSalida" runat="server" OnSelectedIndexChanged="chkTiposSalida_SelectedIndexChanged" CssClass="form-control" RepeatDirection="Horizontal" AutoPostBack="True">
                <asp:ListItem Selected="True" Value="Especificaciones Tecnicas">Especificaciones Tecnicas</asp:ListItem>
                <asp:ListItem Selected="True" Value="Duplicidad">Duplicidad</asp:ListItem>
                <asp:ListItem Selected="True" Value="Modificar Uso o destino">Modificar Uso o destino</asp:ListItem>
                <asp:ListItem Selected="True" Value="Falta de Presupuesto">Falta de Presupuesto</asp:ListItem>
                <asp:ListItem Selected="True" Value="Otros">Otros</asp:ListItem>
            </asp:CheckBoxList>
        </div>
    </div>
</asp:Content>
