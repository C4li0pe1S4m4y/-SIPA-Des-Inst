﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ViaticoGuardado.aspx.cs" Inherits="AplicacionSIPA1.Viaticos.ViaticoGuardado" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="jumbotron">
        <div class="container">
            <<div class="row">
                <div class="col-md-6" style="left: 23px; top: 3px; width: 739px">
                    <h2 class="success"> <asp:Label ID="lblMensaje" runat="server"></asp:Label>  &nbsp;No.
                    <asp:Label ID="lblNoPedido" runat="server" CssClass="text-success"></asp:Label>
                    &nbsp;
                    </h2>
                    <p class="success text-primary"> &nbsp;<asp:Label ID="lblAccion" runat="server" CssClass="text-primary"></asp:Label>
                    &nbsp;Con Exito</p>
                </div>
              
            </div>
            <div class ="row">
                  <div class="col-md-6  " style="left: 23px; top: 3px; width: 548px">
                    <asp:Button ID="btnPedido" runat="server" CausesValidation="false" class="btn btn-warning" OnClick="btnPedido_Click" Text="Nuevo Pedido" PostBackUrl="~/Pedido/PedidoIngreso.aspx" />
                    <asp:Button ID="btnListado" runat="server" CausesValidation ="false" class="btn btn-info" OnClick="btnListado_Click" Text="Ver Listado" PostBackUrl="~/Pedido/PedidoListado.aspx" />
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>