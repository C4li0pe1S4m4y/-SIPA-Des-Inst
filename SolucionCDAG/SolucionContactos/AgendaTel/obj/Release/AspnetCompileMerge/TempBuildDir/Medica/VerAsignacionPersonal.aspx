<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerAsignacionPersonal.aspx.cs" Inherits="AplicacionSIPA1.Medica.VerAsignacionPersonal" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <script type="text/javascript">
        function verPanelModalPersonal() {
            $('#ContentPlaceHolder3_PanelModalPersonal').modal('show');
        }

         </script>

    <asp:LinkButton ID="lbExportar" runat="server" Font-Bold="True" Font-Size="Large" OnClick="lbExportar_Click">Exportar a Excel</asp:LinkButton>
    <asp:RadioButtonList ID="rblOpcion" runat="server" RepeatDirection="Horizontal" AutoPostBack="True" OnSelectedIndexChanged="rblOpcion_SelectedIndexChanged">
        <asp:ListItem Selected="True" Value="1">Hoy</asp:ListItem>
        <asp:ListItem Value="2">Todos</asp:ListItem>
    </asp:RadioButtonList>
</asp:Content>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="PanelModalPersonal" runat="server" role="dialog" CssClass="modal fade"   >
                <asp:Panel ID="panelInnerPersonal" runat="server" CssClass="modal-dialog modal-lg">
                    <asp:Panel ID="panelContenPersonal" CssClass="modal-content" runat="server">
                        <asp:Panel ID="Panel1" runat="server" class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Atleta:</h4>
                                <table style="width: 100%;">
                                <tr>
                                    <td class="auto-style15">
                                        <asp:Label ID="lblNombreAtleta" runat="server" style="font-weight: 700; font-style: italic"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">
                                        <asp:Label ID="Label1" runat="server" style="font-weight: 700; font-style: italic"></asp:Label>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">Personal:</td>
                                    <td>
                                        <asp:DropDownList ID="dropPersonal" runat="server" class="form-control" Width="99%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                
                                
                                <tr>
                                    <td class="auto-style15">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            
                        </asp:Panel>

                        <asp:Panel ID="Panel3" runat="server" class="modal-footer">
                            <asp:Button ID="btnModalGuardar" runat="server" class="btn btn-primary" Text="Guardar" UseSubmitBehavior="false" data-dismiss="modal" OnClick="btnModalGuardar_Click" />
                            <asp:Button ID="btnModalCerrarR" runat="server" class="btn btn-danger" Text="Cerrar" data-dismiss="modal" aria-hidden="true" />
                        </asp:Panel>

                    </asp:Panel>
                </asp:Panel>
            </asp:Panel>
                                            

                        <asp:GridView ID="gridAsignarPer" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnSelectedIndexChanged="gridAsignarPer_SelectedIndexChanged" PageSize="5" Width="95%">
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True" >
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:CommandField >
                                <asp:BoundField DataField="ID" HeaderText="ID">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Personal" HeaderText="Personal" >
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nombres" HeaderText="Nombres">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tipoAtleta" HeaderText="Tipo">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Genero" HeaderText="Genero">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Etnia" HeaderText="Etnia">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Federacion" HeaderText="FADN">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaNacimiento" DataFormatString="{0:d}" HeaderText="FechaNacimiento">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Unidad" HeaderText="Unidad">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="observacion" HeaderText="observacion">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="usuario" HeaderText="Usuario" >
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FechaIngreso" HeaderText="FechaIngreso">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle BackColor="#339933" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Content>






