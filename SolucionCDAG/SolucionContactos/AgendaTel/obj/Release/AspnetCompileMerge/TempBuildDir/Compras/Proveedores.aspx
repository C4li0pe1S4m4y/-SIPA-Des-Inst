<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="AplicacionSIPA1.Compras.Proveedores" MasterPageFile="~/Principal.Master" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="PanelModalProveedor" runat="server" role="dialog" CssClass="modal fade">
                <asp:Panel ID="panelInnerProveedor" runat="server" CssClass="modal-dialog modal-lg">
                    <asp:Panel ID="panelContenProveedor" CssClass="modal-content" runat="server">
                        <asp:Panel ID="Panel1" runat="server" class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Datos<table style="width: 100%;">
                                <tr>
                                    <td class="auto-style15">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">Proveedor:<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtProveedor" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="vaciosMod"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtProveedor" runat="server" class="form-control" placeholder="Nombre del Proveedor" Width="80%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">Nit:
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNit" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="vaciosMod"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNit" runat="server" class="form-control" placeholder="Nit" Width="50%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">Telefono:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtTelefono" runat="server" class="form-control" placeholder="# de Telefono" Width="50%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">Direccion:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="Direccion" Width="50%"></asp:TextBox>
                                    </td>
                                </tr>
                                
                                
                                </tr>
                                <tr>
                                    <td class="auto-style15">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            </h4>
                        </asp:Panel>

                        <asp:Panel ID="Panel3" runat="server" class="modal-footer">
                            <asp:Button ID="btnModalGuardar" runat="server" class="btn btn-primary" Text="Guardar" UseSubmitBehavior="false" data-dismiss="modal" OnClick="btnModalGuardar_Click" />
                            <asp:Button ID="btnModalCerrarR" runat="server" class="btn btn-danger" Text="Cerrar" data-dismiss="modal" aria-hidden="true" />
                        </asp:Panel>

                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>


                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <asp:Button ID="btnAgregarProv" runat="server" BackColor="#3366CC" class="btn btn-primary" Font-Bold="True" OnClick="btnAgregarProv_Click" Text="Agregar Proveedor" Width="50%" />
                                </td>
                                <td>
                                    <asp:Button ID="btnVerProv" runat="server" BackColor="#009933" class="btn btn-primary" Font-Bold="True" OnClick="btnVerProv_Click" Text="Mostrar Proveedores" Width="50%" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gridProveedor" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Left" PageSize="5" Width="75%">
                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                        <Columns>
                                            <asp:BoundField DataField="ID" HeaderText="ID">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="nit" HeaderText="Nit">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Proveedor" HeaderText="Proveedor">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="direccion" HeaderText="Direccion">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="telefono" HeaderText="Telefono">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                        </Columns>
                                        <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <script type="text/javascript">
        function verPanelModalProveedor() {
            $('#ContentPlaceHolder3_PanelModalProveedor').modal('show');
        }
         </script>
</asp:Content>

