<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ActaCompras.aspx.cs" Inherits="AplicacionSIPA1.Compras.ActaCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">

    <h2 style="text-align: center">ACTAS ADMINISTRATIVAS</h2>
    <div class="row">

        <div class="col-sm-12">
            <div class="panel panel-default border">
                <div class="panel-heading alert-secondary" style="background-color: #18bc9c; color: #FFFFFF;">&nbsp;&nbsp;&nbsp; Datos Reporte</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-2">
                            <label>Año</label>
                            <asp:DropDownList ID="ddlAnio" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged" CssClass="form-control" Width="80%"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <label>Requisicion</label>
                            <asp:UpdatePanel runat="server" ID="updPanelMantBeneficios">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlRequisicion" runat="server" OnSelectedIndexChanged="ddlRequisicion_SelectedIndexChanged" CssClass="form-control" Width="80%"></asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-2">
                            <label>Acta NO:</label>
                            <asp:TextBox ID="txtActaNo" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label>Hora Inicio</label>
                            <asp:TextBox ID="txthora" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label>Fecha Inicio</label>
                            <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                        </div>

                        <div class="col-sm-2">
                            <br />
                            <asp:Button ID="btnImprimir" runat="server" Text="Generar" CssClass="btn btn-success" OnClick="btnImprimir_Click" />
                        </div>


                    </div>
                </div>
                <br />
            </div>
            <p style="color: black">Las requisiciones que aparecen son aquellas que estan en el estado 12-Liquidado.</p>
        </div>
    </div>


    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>

