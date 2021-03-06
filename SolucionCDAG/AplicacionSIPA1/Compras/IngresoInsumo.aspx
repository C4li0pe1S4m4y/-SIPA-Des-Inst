﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="IngresoInsumo.aspx.cs" Inherits="AplicacionSIPA1.Compras.IngresoInsumo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
<script type="text/javascript">
    cargar_p= function () {
    if (Page_IsValid) {
        var updateProgress = $find("<%= UpdateProgress1.ClientID %>");
        window.setTimeout(function () {
            updateProgress.set_visible(true);
        }, 100);
    }
}
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2 style="text-align: center">Ingreso de Insumo </h2>
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-default border">
                <div class="panel-heading" style="background-color: #18bc9c; color: #FFFFFF;">Encabezado</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-sm-2">
                            <label>Renglon:</label>
                            <asp:TextBox ID="txtRenglon" runat="server" CssClass="form-control" required="true" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label>Codigo de Insumo:</label>
                            <asp:TextBox ID="txtCodigoInsumo" runat="server" CssClass="form-control" required="true" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label>Nombre:</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" required="true" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                            <label>Caracteristicas:</label>
                            <asp:TextBox ID="txtCaracteristicas" runat="server" TextMode="MultiLine" required="true" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-md-1"></div>
                        <div class="col-md-2">
                            <label>Presentacion:</label>
                            <asp:TextBox ID="txtPresentacion" Width="80%" runat="server" required="true" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label>Cantidad Insumo:</label>
                            <asp:TextBox ID="txtCantidadInusmo" Width="80%" runat="server" required="true" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-md-2">
                            <label>Codigo Presentacion:</label>
                            <asp:TextBox ID="txtCodigoPresentacion" Width="80%" runat="server" required="true" TextMode="Number" CssClass="form-control"></asp:TextBox>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-4">
                            <label>Cargar Archivo</label>
                            <asp:FileUpload ID="CargaArchivo" runat="server" CssClass="form-control"></asp:FileUpload>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-sm-3">
                            <br />
                            <asp:Button ID="btnGuardar" runat="server" Text="Almacenar" OnClick="btnGuardar_Click" Width="100%" CssClass="btn btn-success" />
                        </div>
                        <div class="col-sm-3">
                            <br />
                            <asp:LinkButton ID="btnListado" runat="server" Text="Listado Insumos" Width="100%" CssClass="btn btn-info" PostBackUrl="~/PedidoInsumos/BusquedaInsumos.aspx" />
                        </div>
                        <div class="col-sm-3">
                            <br />
                            <asp:Button ID="btnCargarArchivo"  runat="server" Text="Cargar Archivo" OnClick="btnCargarArchivo_Click" UseSubmitBehavior="false" Width="100%" CssClass="btn btn-primary" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-sm-1"></div>
                        <div class="col-sm-5">
                           <asp:Image ID="log" runat="server" ImageUrl="~/img/cargar.gif" Visible="false" />
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    <img alt="Cargando" class="auto-style20" longdesc="Imagen de Cargando" src="../img/cargar.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                </div>

            </div>
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





</asp:Content>

