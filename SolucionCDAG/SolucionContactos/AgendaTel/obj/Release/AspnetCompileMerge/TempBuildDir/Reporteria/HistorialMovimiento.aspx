﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistorialMovimiento.aspx.cs" Inherits="AplicacionSIPA1.Reporteria.HistorialMovimiento" MasterPageFile="~/Principal.Master" %>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width: 100%;">
                            <tr>
                                <td colspan="5" style="font-size: x-large">
                                    Historico de Revisiones</td>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:DropDownList ID="dropAnio" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="dropAnio_SelectedIndexChanged" Width="99%">
                                    </asp:DropDownList>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:RadioButtonList ID="rblOpcion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblOpcion_SelectedIndexChanged" RepeatDirection="Horizontal" Width="817px">
                                        <asp:ListItem Selected="True" Value="1">Todos</asp:ListItem>
                                        <asp:ListItem Value="2">Pedido</asp:ListItem>
                                        <asp:ListItem Value="3">Vale</asp:ListItem>
                                        <asp:ListItem Value="4">Gasto</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>&nbsp;</td>
                                <td>&nbsp;<asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        &nbsp;
                                        <img alt="Cargando" class="auto-style20" longdesc="../Financiero/Imagen de Cargando" src="../img/cargarCOG.gif" />
                                    </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                    <asp:TextBox ID="txtNoDocumento" runat="server" class="form-control" placeholder="No Pedido/Vale" TextMode="Number" Width="40%"></asp:TextBox>
                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtNoDocumento" ErrorMessage="Solo Numeros" Font-Bold="True" ForeColor="Red" MaximumValue="5000000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                                    <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary" OnClick="btnBuscar_Click" Text="Buscar" Width="20%" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td style="width: 112px">&nbsp;</td>
                                <td style="width: 22px">
                                    &nbsp;</td>
                                <td style="width: 112px">&nbsp;</td>
                                <td style="width: 32px">
                                    &nbsp;</td>
                                <td style="width: 128px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <asp:GridView ID="gridReportes" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="5" Width="95%" OnRowDataBound="gridReportes_RowDataBound" ShowFooter="True" OnSelectedIndexChanged="gridReportes_SelectedIndexChanged">
                                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                        <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <HeaderStyle BackColor="#339933" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8" style="font-size: x-small">&nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <asp:LinkButton ID="lbExportar" runat="server" Font-Bold="True" Font-Size="Large" OnClick="lbExportar_Click">Exportar a Excel</asp:LinkButton>
</asp:Content>