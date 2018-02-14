<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ModificacionPac.aspx.cs" Inherits="AplicacionSIPA1.Pac.ModificacionPac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="../Scripts/bootstrap.js" type="text/javascript"></script>
    <script type="text/javascript">
        function verPanelModalReglon() {
            $('#ContentPlaceHolder2_PanelModalReglon').modal('show');
        }
        function cerrarModal() {
            $('#ContentPlaceHolder2_PanelModalReglon').modal('hide');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="upModificar" runat="server">
        <ContentTemplate>
            <h2 style="text-align: center">Regularizacion PAC</h2>
            <div class="row">
                <div class="col-xs-1">
                    <label>Año</label>
                    <asp:DropDownList ID="ddlAnio" runat="server" CssClass="form-control" Width="85%"></asp:DropDownList>
                </div>
                <div class="col-xs-4">
                    <label>Unidad</label>
                    <asp:DropDownList ID="ddlUnidad" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUnidad_SelectedIndexChanged" Width="90%"></asp:DropDownList>
                </div>
                <div class="col-xs-2">
                    <label>No. de Documento</label>
                    <asp:TextBox ID="txtNo" runat="server" BackColor="#FFFF99" class="form-control" Font-Bold="True"></asp:TextBox>
                </div>
                <div class="col-xs-3">
                    <br />
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" CssClass="btn btn-info" />
                </div>
            </div>
            <div class="row">
                <div class="col-xs-4">
                    <label>Dependencia</label>
                    <asp:DropDownList ID="ddlDependencia" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                </div>
                <div class="col-xs-4">
                    <label>Jefatura/Unidad</label>
                    <asp:DropDownList ID="ddlJefatura" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <br />
                &nbsp;<label class="label label-default">&nbsp;&nbsp; &nbsp;&nbsp; En esta pantalla unicamente se mostraran los estados 8:Impreso, 10:Realizando Gestion de Compras y 12:Liquidado</label>
            </div>
            <br />
            <div class="row">
                <div class="col-lg-11">
                    <div class="panel panel-default">
                        <div class="panel-heading">PAC</div>
                        <div class="panel-body">
                            <asp:DetailsView ID="dvPedido" runat="server" RowStyle-BorderColor="Black" RowStyle-BackColor="#18bc9c" AlternatingRowStyle-BackColor="White" RowStyle-CssClass="table-bordered" AllowPaging="True" Width="100%" CssClass="table table-hover table-responsive"
                                OnPageIndexChanging="dvPedido_PageIndexChanging">
                            </asp:DetailsView>
                            <asp:GridView ID="gvPedido" runat="server" AutoGenerateColumns="false" HeaderStyle-CssClass="modal-header alert-info" RowStyle-BorderColor="Black" CssClass="table table-responsive table-bordered" DataKeyNames="id,PAC,Renglon PAC,Renglon Ppto"
                                OnSelectedIndexChanged="gvPedido_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="id" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="Solicitud" HeaderText="Solicitud" Visible="true"></asp:BoundField>
                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" Visible="true"></asp:BoundField>
                                    <asp:BoundField DataField="Monto" HeaderText="Monto" Visible="true"></asp:BoundField>
                                    <asp:BoundField DataField="PAC" HeaderText="PAC" Visible="true"></asp:BoundField>
                                    <asp:BoundField DataField="Renglon PAC" HeaderText="No. Renglon PAC" Visible="true"></asp:BoundField>
                                    <asp:BoundField DataField="Renglon Ppto" HeaderText="No. Renglon Ppto" Visible="true"></asp:BoundField>
                                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/edit.png" ShowSelectButton="True">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:CommandField>

                                </Columns>
                            </asp:GridView>
                            <asp:GridView ID="tabla_listado" runat="server" Width="100%" GridLines="Both" CssClass="table-striped table">
                                <HeaderStyle BackColor="#04B486" ForeColor="White" />

                            </asp:GridView>


                        </div>
                    </div>
                </div>
            </div>

            <asp:Panel ID="PanelModalReglon" runat="server" role="dialog" CssClass="modal fade">
                <asp:Panel ID="panelInnerReglon" runat="server" CssClass="modal-dialog modal-lg">
                    <asp:Panel ID="Panel1" runat="server" class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">
                            <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
                        </button>
                        <h4 class="modal-title">Accion:
                    <asp:Label ID="lblAccion" runat="server" /></h4>
                    </asp:Panel>
                    <div class="modal-content">
                        <h3 style="text-align: center">Cambio de PAC</h3>
                        <div class="row">
                            <div class="col-xs-6">
                                <label>PAC</label>
                                <asp:Label ID="lblPACm" runat="server"></asp:Label>
                                <asp:Label ID="lblIdDetalle" Visible="false" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-2">
                                <label>Renglon PAC</label>
                                <asp:TextBox ID="txtRenglonPacM" Width="80%" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-2">
                                <label>Renglon Ppto</label>
                                <asp:TextBox ID="txtRenglonPptoM" Width="80%" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-xs-4">
                                <label>Nuevo PAC</label>
                                <asp:DropDownList ID="ddlNPac" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xs-3">
                                <br />
                                <asp:Button ID="btnGuardarM" Width="80%" runat="server" Text="Guardar" CssClass="btn btn-success"  OnClick="btnGuardarM_Click" UseSubmitBehavior="false" data-dismiss="modal"/>
                            </div>
                            <div class="col-xs-3">
                                <br />
                                <asp:Button ID="btnCancelarM" Width="80%" runat="server" Text="Cancelar" data-dismiss="modal" aria-hidden="true" CssClass="btn btn-danger" />
                            </div>
                        </div>

                    </div>
                </asp:Panel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

