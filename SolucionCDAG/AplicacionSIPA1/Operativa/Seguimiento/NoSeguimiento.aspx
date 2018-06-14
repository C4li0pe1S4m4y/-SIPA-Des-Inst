<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="NoSeguimiento.aspx.cs" Inherits="AplicacionSIPA1.Operativa.Seguimiento.NoSeguimiento" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="jumbotron">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <h2 class="success"> <asp:Label ID="lblMensaje" runat="server"></asp:Label>  </h2>
                    <asp:Label ID="lblNoPedido" runat="server" CssClass="text-success"></asp:Label>
                    <asp:Label ID="lblAccion" runat="server" CssClass="text-primary"></asp:Label>
                </div>
              
            </div>
            <div class ="row">
                  <div class="col-md-6  ">
                    <asp:Button ID="btnNuevo" runat="server" CausesValidation="false" class="btn btn-warning"  Text="Nuevo"  />
                    <asp:Button ID="btnListado" runat="server" CausesValidation ="false" class="btn btn-info"  Text="Ver Listado"  />
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>

