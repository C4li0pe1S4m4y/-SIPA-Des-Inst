﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarTecnico.aspx.cs" Inherits="AplicacionSIPA1.Compras.AsignarTecnico" MasterPageFile="~/Principal.Master" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td colspan="6"><asp:DetailsView ID="dvPedido" runat="server" AutoGenerateRows="False" DataKeyNames="ID" Width="75%" AllowPaging="True" OnPageIndexChanging="dvPedido_PageIndexChanging">
                    <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                        <EmptyDataTemplate>
                            &nbsp;
                        </EmptyDataTemplate>
                    <Fields>
                        <asp:BoundField DataField="ID" HeaderText="No" >
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#99FF99" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Documento" HeaderText="Documento" >
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#FF9933" Font-Bold="True" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FechaPedido" DataFormatString="{0:d}" HeaderText="FechaDocumento">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="idAccion" HeaderText="NoAccion">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Accion" HeaderText="Accion">
                         <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="tipopedido" HeaderText="TipoPedido">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Solicitante" HeaderText="Solicitante">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="JefeDireccion" HeaderText="JefeDireccion">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Justificacion" HeaderText="Justificacion" >
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Unidad" HeaderText="Unidad" >
                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                    </Fields>
                        <FooterStyle Font-Bold="False" />
                        <PagerStyle BackColor="White" BorderStyle="Solid" Font-Bold="True" Font-Names="Algerian" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" Font-Underline="False" />
                </asp:DetailsView></td>
                </tr>
                <tr>
                    <td colspan="6"><asp:GridView ID="gridDetalle" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Left" PageSize="5" ShowFooter="True" Width="75%" OnRowDataBound="gridDetalle_RowDataBound">
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" >
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="UnidadMedida" HeaderText="Medida">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="idPac" HeaderText="NoPac" >
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Costo" HeaderText="Costo">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Reglon" HeaderText="Reglon">
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
                    <td colspan="6">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                           <ProgressTemplate>
                                               <img alt="Cargando" class="auto-style20" longdesc="Imagen de Cargando" src="../img/cargarCOG.gif" />
                                           </ProgressTemplate>
                                       </asp:UpdateProgress>
 
                        <span class="label label-danger"><asp:Label ID="lblError" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span>
                    <span class="label label-success"><asp:Label ID="lblSuccess" runat="server" Text="Label"  visible="False" Font-Size="Medium" ></asp:Label></span></td>
                </tr>
                <tr>
                    <td>
                        <asp:DropDownList ID="dropTecnico" runat="server" class="form-control" Width="98%">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td colspan="4">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAprobar" runat="server" BackColor="#3366CC" class="btn btn-primary" Font-Bold="True" OnClick="btnAprobar_Click" Text="Asignar Tecnico" Width="99%" />
                    </td>
                    <td>&nbsp;</td>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">
                        &nbsp;</td>
                </tr>
            </table>
</ContentTemplate>
                </asp:UpdatePanel>

            </asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
</asp:Content>








