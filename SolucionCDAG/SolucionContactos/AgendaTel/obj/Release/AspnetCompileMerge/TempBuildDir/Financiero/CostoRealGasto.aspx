﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CostoRealGasto.aspx.cs" Inherits="AplicacionSIPA1.Financiero.CostoRealGasto" MasterPageFile="~/Principal.Master" %>

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
                                <asp:TemplateField HeaderText="CostoReal">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtCostoReal" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCostoReal" ErrorMessage="*" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidatorMonto" runat="server" ControlToValidate="txtCostoReal" ErrorMessage="Solo Numeros" Font-Bold="True" ForeColor="#CC0000" MaximumValue="500000" MinimumValue="1" Type="Double"></asp:RangeValidator>
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                   <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
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
                    <td>NoOrden<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNoOrden" ErrorMessage="*" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtNoOrden" ErrorMessage="Solo Numeros" Font-Bold="True" ForeColor="Red" MaximumValue="300000000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtNoOrden" runat="server" class="form-control" ForeColor="Black" MaxLength="10" placeholder="No Orden" TextMode="Number" Width="40%"></asp:TextBox>
                    </td>
                    <td>FechaOrden<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFechaOrden" ErrorMessage="*" Font-Bold="True" Font-Size="X-Large" ForeColor="Red" ValidationGroup="vacios"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="rangeFecha" runat="server" ControlToValidate="txtFechaOrden" ErrorMessage="Error Fecha" Font-Bold="True" ForeColor="Red" MaximumValue="31/12/2030" MinimumValue="01/01/2015" Type="Date"></asp:RangeValidator>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFechaOrden" runat="server" class="form-control" placeholder="fechaNacimiento" TextMode="Date" Width="99%"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:Button ID="btnAprobar" runat="server" BackColor="#3366CC" class="btn btn-primary" Font-Bold="True" OnClick="btnAprobar_Click" Text="Guardar Monto" Width="50%" />
                    </td>
                </tr>
            </table>
</ContentTemplate>
                </asp:UpdatePanel>

            </asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
</asp:Content>







