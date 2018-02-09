<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="AplicacionSIPA1.Medica.Consultas" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="5">
                                    <asp:RadioButtonList ID="rblOpcion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblOpcion_SelectedIndexChanged" RepeatDirection="Horizontal" ToolTip="1)FederacuibAU,TipoAU,GeneroAU=Muestra un Total de Atenciones brindadas 1.1)AtencionU= Muestra el Detalle (Nombre de Atleta) de las Atenciones Brindas 2)FederacuibAA,TipoAA=Muestra un total por Atleta 2.1)AtencionA=Muestra el Detalle(Nombre de Atleta) de las Atenciones Brindas  por Atleta 3)Federación,Tipo= El total de los atletas atendidos" Width="817px">
                                        <asp:ListItem Selected="True" Value="1">FederacionAU</asp:ListItem>
                                        <asp:ListItem Value="2">TipoAU</asp:ListItem>
                                        <asp:ListItem Value="3">GeneroAU</asp:ListItem>
                                        <asp:ListItem Value="8">AtencionU</asp:ListItem>
                                        <asp:ListItem Value="4">FederacionAA</asp:ListItem>
                                        <asp:ListItem Value="5">TipoAA</asp:ListItem>
                                        <asp:ListItem Value="9">AtencionA</asp:ListItem>
                                        <asp:ListItem Value="6">Federacion</asp:ListItem>
                                        <asp:ListItem Value="7">Tipo</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 112px">Fecha Inicio<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFechaInicio" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rangeFechaInicio" runat="server" ControlToValidate="txtFechaInicio" ErrorMessage="Eror Fecha" Font-Bold="True" ForeColor="Red" MaximumValue="31/12/2030" MinimumValue="01/01/2015" Type="Date"></asp:RangeValidator>
                                </td>
                                <td style="width: 22px">
                                    <asp:TextBox ID="txtFechaInicio" runat="server" class="form-control" placeholder="fechaNacimiento" TextMode="Date" Width="99%"></asp:TextBox>
                                </td>
                                <td style="width: 112px">Fecha Fin<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaFin" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rangeFechaFin" runat="server" ControlToValidate="txtFechaFin" ErrorMessage="Eror Fecha" Font-Bold="True" ForeColor="Red" MaximumValue="31/12/2030" MinimumValue="01/01/2015" Type="Date"></asp:RangeValidator>
                                </td>
                                <td style="width: 32px">
                                    <asp:TextBox ID="txtFechaFin" runat="server" class="form-control" placeholder="fechaNacimiento" TextMode="Date" Width="99%"></asp:TextBox>
                                </td>
                                <td style="width: 128px">
                                    <asp:Button ID="btnBuscar" runat="server" BackColor="#339933" class="btn btn-primary" OnClick="btnBuscar_Click" Text="Buscar" Width="99%" />
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblOpcionP" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblOpcionP_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="2">Todos</asp:ListItem>
                                        <asp:ListItem Value="1">COG</asp:ListItem>
                                        <asp:ListItem Value="0">CDAG</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <img alt="Cargando" class="auto-style20" longdesc="../Financiero/Imagen de Cargando" src="../img/cargarCOG.gif" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <asp:GridView ID="gridAtletas" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="5" Width="95%">
                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                        <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#339933" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <asp:LinkButton ID="lbExportar" runat="server" Font-Bold="True" Font-Size="Large" OnClick="lbExportar_Click">Exportar a Excel</asp:LinkButton>
</asp:Content>



