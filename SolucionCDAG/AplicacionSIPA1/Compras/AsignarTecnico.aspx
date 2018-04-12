﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarTecnico.aspx.cs" Inherits="AplicacionSIPA1.Compras.AsignarTecnico" MasterPageFile="~/Principal.Master" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upIngreso" runat="server">
                <ContentTemplate>
                    <table style="width: 100%;">
                        <tr>
                            <td style="width: 5%">
                                <asp:Label ID="lblPlanE" runat="server" Text="*"></asp:Label>
                            </td>
                            <td style="width: 5%"><strong>
                                <asp:Label ID="lblErrorPlan" runat="server" ForeColor="Red" Style="font-size: medium" Visible="False">*</asp:Label>
                                <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" Width="50%" Visible="False">
                                </asp:DropDownList>
                            </strong></td>
                            <td style="font-size: x-large; text-align: center;" class="text-center" colspan="16"><strong>ASIGNACIÓN DE TÉCNICO DE COMPRAS A REQUISICIONES</strong></td>
                            <td class="text-right" colspan="2" style="font-size: x-large;"><strong>
                                <asp:Label ID="lblIdPoa" runat="server" Style="font-size: medium" ForeColor="White">0</asp:Label>
                            </strong></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="18" style="text-align: center;"><strong>
                                <asp:Label ID="lblErrorPoa" runat="server" ForeColor="Red" Style="font-size: medium"></asp:Label>
                            </strong></td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="9">
                                <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" Width="100%" Visible="False">
                                </asp:DropDownList>
                            </td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" BackColor="#003366" ForeColor="White" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" Width="100%" Visible="False">
                                </asp:DropDownList>
                            </td>
                            <td class="text-right" colspan="6">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="5">Tipos de documento:</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td colspan="2">No. Documento:</td>
                            <td>&nbsp;</td>
                            <td colspan="3">Año:&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td colspan="9">
                                <asp:RadioButtonList ID="rblTipoDocto" runat="server" RepeatDirection="Horizontal" Width="95%" AutoPostBack="True" OnSelectedIndexChanged="rblTipoDocto_SelectedIndexChanged">
                                    <asp:ListItem Selected="True" Value="1">Requisiciones</asp:ListItem>
                                    <asp:ListItem Value="2">Vales</asp:ListItem>
                                    <asp:ListItem Value="3" Enabled="true">Transferencias, apoyos y otros gastos</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtNo" runat="server" BackColor="#FFFF99" class="form-control" Enabled="true" Font-Size="Large" MaxLength="5" Style="text-align: right" TextMode="Number" Width="95%"></asp:TextBox>
                            </td>
                            <td colspan="3">
                                <asp:DropDownList ID="ddlAnios" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" Width="82%">
                                </asp:DropDownList>
                            </td>
                            <td colspan="3">
                                <asp:Button ID="btnBuscar" runat="server" class="btn btn-success" OnClick="btnBuscar_Click" Text="Buscar" Width="95%" />
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="18">
                                <asp:DetailsView ID="dvPedido" runat="server" AllowPaging="True" AutoGenerateRows="False" DataKeyNames="ID,ID_ACCION" OnPageIndexChanging="dvPedido_PageIndexChanging" Width="100%"
                                    CssClass="table table-hover ">
                                    <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                    <Fields>
                                        <asp:BoundField DataField="ID" HeaderText="Id" Visible="false">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BackColor="#99FF99" BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="no_anio_solicitud" HeaderText="No. Pedido">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BackColor="#99FF99" BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="id_accion" HeaderText="id_accion" Visible="false">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="documento" HeaderText="Tipo de Documento">
                                            <ItemStyle BackColor="#FF6600" Font-Bold="True" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fecha_pedido" DataFormatString="{0:d}" HeaderText="Fecha Pedido">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="accion" HeaderText="Acción">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="tipo_pedido" HeaderText="Tipo de pedido">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="solicitante" HeaderText="Solicitante">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="encargado" HeaderText="Jefe Direccion">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="justificacion" HeaderText="Justificacion">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="unidad" HeaderText="Unidad">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dependencia" HeaderText="Dependencia">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="fadn" HeaderText="FADN">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#FF6600" />
                                        </asp:BoundField>
                                    </Fields>
                                    <FooterStyle Font-Bold="False" />
                                    <PagerStyle BackColor="White" BorderStyle="Solid" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" />
                                </asp:DetailsView>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>

                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="18">
                                <asp:GridView ID="gridDetalle" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="12" ShowFooter="True" Width="100%" Font-Size="Small"
                                    CssClass="table table-hover ">
                                    <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                    <Columns>
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True" Visible="False">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:CommandField>
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/delete.png" OnClientClick="javascript:if(!confirm('¿Desea Eliminar Este Registro?'))return false" Text="Eliminar" />
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN DEL BIEN Y/O SERVICIO">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="unidad_medida" HeaderText="UNIDAD MEDIDA">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="CANTIDAD">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cantidad") %>' Font-Bold="True"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="text-right">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("cantidad") %>' Font-Bold="True"></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="VALOR ESTIMADO INDIVIDUAL SIN IVA">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("costo_estimado") %>' Font-Bold="True"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="text-right">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("costo_estimado", "Q.{0:0,0.00}") %>' Font-Bold="True"></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SUBTOTAL">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("subtotal") %>' Font-Bold="True"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="text-right">
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("subtotal", "Q.{0:0,0.00}") %>' Font-Bold="True"></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TOTAL MULTIANUAL">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox33" runat="server" Text='<%# Bind("total_pedido_multianual") %>' Font-Bold="True"></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="text-right">
                                                    <asp:Label ID="Label33" runat="server" Text='<%# Bind("total_pedido_multianual", "Q.{0:0,0.00}") %>' Font-Bold="True"></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="no_renglon_ppto" HeaderText="RENGLÓN PPTO.">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ajuste" HeaderText="AJUSTE">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                    </Columns>
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="8">Técnicos de compras:</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="10">
                                <asp:DropDownList ID="ddlTecnicos" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="form-control" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="text-align: center;" colspan="16"><span>
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                            </span></td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="16" style="text-align: center;">
                                <asp:Button ID="btnAprobar" runat="server" class="btn btn-success" OnClick="btnAprobar_Click" Text="Asignar Técnico" Width="163px" />
                                <asp:Button ID="btnRechazar" runat="server" class="btn btn-danger" OnClick="btnRechazar_Click" Text="Rechazar" Width="159px" Visible="False" />
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>

                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td colspan="18">
                                <asp:GridView ID="gridSaldos" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" Width="100%" Visible="False"
                                    CssClass="table table-hover ">
                                    <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="no_renglon" HeaderText="Renglon">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="renglon" HeaderText="Descripcion">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Fuente" HeaderText="Fuente">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="Costo Poa">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("costo_poa") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="text-right">
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("costo_poa", "Q.{0:0,0.00}") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Codificado">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("codificado") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="text-right">
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("codificado", "Q.{0:0,0.00}") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Saldo">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("saldo_poa") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <div class="text-right">
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("saldo_poa", "Q.{0:0,0.00}") %>'></asp:Label>
                                                </div>
                                            </ItemTemplate>
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="White" BorderStyle="Inset" Font-Bold="True" ForeColor="Black" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle BackColor="#339933" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                </asp:GridView>
                            </td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                            <td style="width: 5%">&nbsp;</td>
                        </tr>

                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
               
                </ContentTemplate>
            </asp:UpdatePanel>
            <div></div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>




