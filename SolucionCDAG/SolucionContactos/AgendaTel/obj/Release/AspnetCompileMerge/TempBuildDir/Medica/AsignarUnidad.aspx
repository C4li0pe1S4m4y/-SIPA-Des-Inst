<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarUnidad.aspx.cs" Inherits="AplicacionSIPA1.Medica.AsignarUnidad" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
     <script type="text/javascript">
         function verPanelModalAtleta() {
             $('#ContentPlaceHolder3_PanelModalAtleta').modal('show');
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
            width: 15%;
            height: 41px;
        }
        .auto-style13 {
            width: 25%;
            height: 41px;
        }
        .auto-style14 {
            height: 41px;
        }
        .auto-style15 {
            width: 136px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelModalAtleta" runat="server" role="dialog" CssClass="modal fade" >
                <asp:Panel ID="panelInnerAtleta" runat="server" CssClass="modal-dialog modal-lg">
                    <asp:Panel ID="panelContenAtleta" CssClass="modal-content" runat="server">
                        <asp:Panel ID="Panel1" runat="server" class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
                            </button>
                            <h4 class="modal-title">Datos del Atleta<table style="width: 100%;">
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
                                    <td class="auto-style15">Nombre:<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNombre" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="vaciosMod"></asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtNombre" runat="server" class="form-control" placeholder="Nombre" Width="50%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">Tipo Atleta</td>
                                    <td>
                                        <asp:DropDownList ID="dropTipoAtleta" runat="server" class="form-control" Width="60%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">Direccion</td>
                                    <td>
                                        <asp:TextBox ID="txtDireccion" runat="server" class="form-control" placeholder="Direccion" Width="98%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">Telefono</td>
                                    <td>
                                        <asp:TextBox ID="txtTelefono" runat="server" class="form-control" placeholder="Telefono" Width="50%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">Genero</td>
                                    <td>
                                        <asp:DropDownList ID="dropGenero" runat="server" class="form-control">
                                            <asp:ListItem Value="0">&lt;&lt; Elija Genero &gt;&gt;</asp:ListItem>
                                            <asp:ListItem Value="1">Masculino</asp:ListItem>
                                            <asp:ListItem Value="2">Femenino</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">Etnia</td>
                                    <td>
                                        <asp:DropDownList ID="dropEtnia" runat="server" class="form-control" Width="60%">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">Fecha Nacimiento<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtfNacimiento" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="vaciosMod"></asp:RequiredFieldValidator><asp:RangeValidator ID="rangeFechaInicio" runat="server" ControlToValidate="txtfNacimiento" ErrorMessage="Eror Fecha" Font-Bold="True" ForeColor="Red" MaximumValue="31/12/2020" MinimumValue="01/01/1900" Type="Date"></asp:RangeValidator>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtfNacimiento" runat="server" class="form-control" placeholder="Fecha N" TextMode="Date" Width="50%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style15">Federacion</td>
                                    <td>
                                        <asp:DropDownList ID="dropFederacion" runat="server" class="form-control" Width="60%">
                                        </asp:DropDownList>
                                    </td>
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


            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>

            <table style="width: 80%;">
                <tr>
                    <td class="auto-style11" colspan="4">Atencion a Atletas</td>
                </tr>

                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="btnModificarAtleta" runat="server" BackColor="#0033CC" class="btn btn-primary" OnClick="btnModificarAtleta_Click" Text="Modificar Atleta" Width="70%" />
                    </td>
                    <td class="auto-style3">
                        <asp:Button ID="btnNuevoAtleta" runat="server" BackColor="#FF3300" class="btn btn-primary" OnClick="btnNuevoAtleta_Click" Text="Nuevo Atleta" Width="70%" />
                    </td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <tr>
                        <td class="auto-style3">
                            Buscar Por:<asp:RadioButtonList ID="rblOpcion" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Value="1">Nombre</asp:ListItem>
                                <asp:ListItem Value="2">Palabra</asp:ListItem>
                            </asp:RadioButtonList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBuscar" ErrorMessage="*" Font-Bold="True" Font-Size="XX-Large" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style4">
                            <asp:TextBox ID="txtBuscar" runat="server" class="form-control" placeholder="Nombre / Apellido" Width="99%"></asp:TextBox>
                        </td>
                        <td class="auto-style3">
                            <asp:Button ID="btnBuscar" runat="server" BackColor="#339933" class="btn btn-primary" OnClick="btnBuscar_Click" Text="Buscar" Width="99%" />
                        </td>
                        <td class="auto-style4">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    <img alt="Cargando" class="auto-style20" longdesc="../Financiero/Imagen de Cargando" src="../img/cargarCOG.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </td>
                        <tr>
                            <td class="auto-style11" colspan="4">
                                <asp:GridView ID="gridAtletas" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnPageIndexChanging="gridAtletas_PageIndexChanging" OnSelectedIndexChanged="gridAtletas_SelectedIndexChanged" PageSize="5" Width="95%">
                                    <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True">
                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:CommandField>
                                        <asp:BoundField DataField="ID" HeaderText="ID">
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
                                    </Columns>
                                    <EmptyDataTemplate>
                                        Ningun Resultado
                                    </EmptyDataTemplate>
                                    <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">Unidad Medica</td>
                            <td class="auto-style13">
                                <asp:DropDownList ID="dropUnidadMedica" runat="server" class="form-control" Width="99%">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style12">Observacion</td>
                            <td class="auto-style14">
                                <asp:TextBox ID="txtObservacion" runat="server" class="form-control" MaxLength="200" placeholder="Observacion" TextMode="MultiLine" Width="99%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3"><span class="label label-danger">
                                <asp:Label ID="lblError" runat="server" Font-Size="Medium" Text="Label" visible="False"></asp:Label>
                                </span><span class="label label-success">
                                <asp:Label ID="lblSuccess" runat="server" Font-Size="Medium" Text="Label" visible="False"></asp:Label>
                                </span></td>
                            </td>
                            <td></td>
                            <td class="auto-style4">
                                <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Asignar" Width="142px" />
                            </td>
                            <td class="auto-style3">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <tr>
                                <td class="auto-style3" colspan="4">
                                    <asp:GridView ID="gridAsignarAtencion" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="5" Width="95%">
                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                        <Columns>
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
                                        </Columns>
                                        <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#339933" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </tr>
                    </tr>
                    </table>
        </ContentTemplate>
    </asp:UpdatePanel>
            </asp:Content>




