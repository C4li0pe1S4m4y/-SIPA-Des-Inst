<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignartipoAtencion.aspx.cs" Inherits="AplicacionSIPA1.Medica.AsignartipoAtencion" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">
        function verPanelModalAtencion() {
            $('#ContentPlaceHolder3_PanelModalAtencion').modal('show');
        }
         </script>
    <style type="text/css">
        .auto-style3 {
        }

        .auto-style4 {
            width: 25%;
        }

        .auto-style11 {
            text-align: center;
            font-size: x-large;
        }
        .auto-style12 {
            width: 225px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                       <ContentTemplate>

                           <asp:Panel ID="PanelModalAtencion" runat="server" role="dialog" CssClass="modal fade">
                <asp:Panel ID="panelInnerAtencion" runat="server" CssClass="modal-dialog modal-lg">
                    <asp:Panel ID="panelContenAtencion" CssClass="modal-content" runat="server">
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
                                    <td class="auto-style15">Descripcion:<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="vaciosMod"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" placeholder="Descripcion" Width="50%"></asp:TextBox>
                                    </td>
                                </tr>
                                
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
                                       <asp:Button ID="btnRefresh" runat="server" BackColor="#3366CC" class="btn btn-primary" Font-Bold="True" OnClick="btnRefresh_Click" Text="Cargar Datos" Width="45%" />
                                   </td>
                               </tr>
                        </table>
              
                        <table style="width:80%;" >
                            <tr>
                    <td class="auto-style11" colspan="4">Atencion a Atletas</td>
                </tr>
                
                            <tr>
                                <td class="auto-style11" colspan="4">
                                    <asp:DetailsView ID="dvAtleta" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="ID" OnPageIndexChanging="dvAtleta_PageIndexChanging" Width="75%">
                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                        <Fields>
                                            <asp:BoundField DataField="ID" HeaderText="No">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BackColor="#99FF99" BorderStyle="Inset" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Nombres" HeaderText="Nombre">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BackColor="#FF9933" BorderStyle="Inset" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
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
                                            <asp:BoundField DataField="fechaNacimiento" HeaderText="FechaNacimiento" DataFormatString="{0:d}">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Unidad" HeaderText="Unidad" >
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Federacion" HeaderText="FADN">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                        </Fields>
                                        <FooterStyle Font-Bold="False" />
                                        <PagerStyle BackColor="White" BorderStyle="Solid" Font-Bold="True" Font-Names="Algerian" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="False" />
                                    </asp:DetailsView>
                                </td>
                            </tr>
                
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="lblTipoEnfermedad" runat="server" Text="TIPOS DE ENFERMEDAD" Visible="False"></asp:Label>
                                </td>
                                <td colspan="2">
                                    &nbsp;</td>
                                <td class="auto-style12">
                                    &nbsp;</td>
                                <td class="auto-style4">
                                    &nbsp;</td>
                            </tr>
                
                            <tr>
                                <td class="auto-style3">
                                    <asp:DropDownList ID="dropTipoEnfermedad" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="dropTipoEnfermedad_SelectedIndexChanged" Visible="False" Width="99%">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">&nbsp;</td>
                                <td class="auto-style12">&nbsp;</td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style3">
                                    <asp:Label ID="lblTipoAtencion" runat="server" Text="TIPOS DE ATENCION" Visible="False"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="lblDiagnostico" runat="server" Text="DIAGNOSTICO" Visible="False"></asp:Label>
                                </td>
                                <td class="auto-style12">
                                    <asp:Label ID="lblTratamiento" runat="server" Text="TRATAMIENTO" Visible="False"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblAreaLesion" runat="server" Text="AREA DE LESION" Visible="False"></asp:Label>
                                </td>
                            </tr>
                
                            <tr>
                                <td class="auto-style3">
                                    <asp:DropDownList ID="dropTipoAtencion" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="dropTipoAtencion_SelectedIndexChanged" Visible="False" Width="99%">
                                    </asp:DropDownList>
                                </td>
                                <td colspan="2">
                                    <asp:DropDownList ID="dropDiagnostico" runat="server" class="form-control" Width="99%" OnSelectedIndexChanged="dropDiagnostico_SelectedIndexChanged" AutoPostBack="True" Visible="False">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style12">
                                    <asp:DropDownList ID="dropTratamiento" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="dropTratamiento_SelectedIndexChanged1" Visible="False" Width="99%">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style4">
                                    <asp:DropDownList ID="dropAreaLesion" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="dropAreaLesion_SelectedIndexChanged" Visible="False" Width="99%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3" colspan="5">    <span class="label label-danger"><asp:Label ID="lblError" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span>
                    <span class="label label-success"><asp:Label ID="lblSuccess" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span></td></td>
                            </tr>
                
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td>Observacion</td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txtObservacion" runat="server" class="form-control" MaxLength="200" placeholder="Observacion" TextMode="MultiLine" Width="99%"></asp:TextBox>
                                </td>
                                <td class="auto-style12">
                                    <asp:Button ID="btnAgregar" runat="server" BackColor="#339933" Font-Bold="True" Font-Size="Large" ForeColor="White" OnClick="btnAgregar_Click" Text="Agregar" Width="80%" />
                                </td>
                                <td class="auto-style4">
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <img alt="Cargando" class="auto-style20"  src="../img/cargarCOG.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style3" colspan="5">
                                    <asp:Button ID="btGuardar" runat="server" BackColor="#99CCFF" class="btn btn-primary" Font-Size="Large" ForeColor="Black" OnClick="btGuardar_Click" Text="Guardar" Width="50%" />
                                </td>
                            </tr>
                
                            <tr>
                                <td class="auto-style3" colspan="5">
                                    <asp:GridView ID="gridDetalle" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnRowDeleting="gridDetalle_RowDeleting" PageSize="5" Width="65%">
                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/delete.png" onclientclick="javascript:if(!confirm('¿Desea Eliminar Este Registro?'))return false" Text="Eliminar" />
                                                </ItemTemplate>
                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID" HeaderText="ID">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="tratamiento" HeaderText="Categoria">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Atencion" HeaderText="Descripcion">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="observacion" HeaderText="Observacion" >
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
                
                            <tr>
                                <td class="auto-style3" colspan="4">
                                    &nbsp;</td>
                            </tr>
            </table>
                        </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Content>





