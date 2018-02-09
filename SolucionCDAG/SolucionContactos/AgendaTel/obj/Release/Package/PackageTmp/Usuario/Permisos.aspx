﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Permisos.aspx.cs" Inherits="AgendaTel.Usuario.Permisos_aspx" MasterPageFile="~/Principal.Master" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <table style="width:80%;">
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style12" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style17" colspan="2">ASIGNAR PERMISOS&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style16" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">Criterio:</td>
                                <td class="auto-style16" colspan="2">
                                    <asp:RadioButtonList ID="rblCriterio" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblCriterio_SelectedIndexChanged" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style16" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">Valor:</td>
                                <td class="auto-style16">
                                    <asp:TextBox ID="txtBValor" runat="server" class="form-control" MaxLength="250" Width="95%"></asp:TextBox>
                                </td>
                                <td class="auto-style16">
                                    <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBuscar_Click" Text="Buscar" />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td colspan="2">
                                    <asp:GridView ID="gridUsuario" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnPageIndexChanging="gridUsuario_PageIndexChanging" OnSelectedIndexChanged="gridUsuario_SelectedIndexChanged" PageSize="5" Width="65%">
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
                                            <asp:BoundField DataField="Usuario" HeaderText="Usuario">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Empleado" HeaderText="Empleado">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:BoundField>
                                            <asp:CheckBoxField DataField="Habilitado" HeaderText="Activo">
                                            <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                            </asp:CheckBoxField>
                                        </Columns>
                                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                        <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style15">USUARIO:
                                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                                </td>
                                <td class="auto-style12">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">Menu:</td>
                                <td>
                                    <asp:DropDownList ID="dropMenu" runat="server" AutoPostBack="true" CssClass="form-control" Height="44px" OnSelectedIndexChanged="dropMenu_SelectedIndexChanged" style="margin-left: 0px" Width="400px">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style12">
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style18">Sub-Menu:</td>
                                <td class="auto-style14">
                                    <asp:CheckBoxList ID="cbListMenus" runat="server" AutoPostBack="True" CellPadding="12" CellSpacing="-1" RepeatColumns="2" RepeatDirection="Horizontal" style="margin-top: 0px; color: #000000;">
                                    </asp:CheckBoxList>
                                </td>
                                <td class="auto-style19">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style12" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style20"><span>
                                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                                    </span></td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style20">
                                    <span>
                                    <asp:Label ID="lblErrorM" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                    <asp:Label ID="lblSuccessM" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                                    </span>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style20">
                                    <asp:Button ID="btnAsignar" runat="server" class="btn btn-primary" OnClick="btnAsignar_Click" OnClientClick=" disableButton(this)" Text="Asignar" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style21" colspan="2">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style12" colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style11">&nbsp;</td>
                                <td class="auto-style12" colspan="2">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style11 {
            width: 20%;
        }
        .auto-style12 {
            width: 60%;
            font-weight: 700;
            font-size: medium;
        }
        .auto-style14 {
            width: 57%;
            font-weight: 700;
            font-size: medium;
            height: 22px;
        }
        .auto-style15 {
            width: 57%;
            font-weight: 700;
            font-size: x-large;
        }
        .auto-style16 {
            width: 60%;
            font-weight: 700;
            font-size: small;
            text-align: left;
        }
        .auto-style17 {
            width: 60%;
            font-weight: 700;
            font-size: x-large;
            text-align: center;
        }
        .auto-style18 {
            width: 20%;
            height: 22px;
        }
        .auto-style19 {
            width: 60%;
            font-weight: 700;
            font-size: medium;
            height: 22px;
        }
        .auto-style20 {
            text-align: center;
        }
        .auto-style21 {
            width: 60%;
            font-weight: 700;
            font-size: medium;
            text-align: center;
        }
    </style>
</asp:Content>


