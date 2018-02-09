<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IngresoAsignaciones.aspx.cs" Inherits="AgendaTel.Contactos.IngresoAsignaciones" MasterPageFile="~/Principal.Master" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upIngreso" runat="server">
                <ContentTemplate>
            <table style="width:100%;">
                <tr>
                    <td style="width: 5%">
                        &nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="font-size: x-large; text-align: center;" class="text-center" colspan="16"><strong>INGRESO DE ASIGNACIONES DE CONTACTOS Y CASOS</strong></td>
                    <td class="text-right" colspan="2" style="font-size: x-large;"><strong>
                        <asp:Label ID="lblIdPoa" runat="server" style="font-size: medium" ForeColor="White">0</asp:Label>
                        </strong></td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td colspan="18" style="text-align: center;"><strong>
                        <asp:Label ID="lblErrorEncabezado" runat="server" ForeColor="Red" style="font-size: medium"></asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2"><strong><span class="auto-style10" style="background-color: #FFFFFF">:</span>
                        <asp:Label ID="lblIdAsignacion" runat="server" ForeColor="White" style="font-size: medium">0</asp:Label>
                        </strong></td>
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
                    <td colspan="8">Contactos existentes:<strong><asp:Label ID="lblIdContacto" runat="server" ForeColor="White" style="font-size: medium">0</asp:Label>
                        <asp:Label ID="lblErrorContactoExistente" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">Casos existentes:<strong><asp:Label ID="lblIdCaso" runat="server" ForeColor="White" style="font-size: medium">0</asp:Label>
                        <asp:Label ID="lblErrorCasoExistente" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">
                        <asp:DropDownList ID="ddlContactos" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlContactos_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">
                        <asp:DropDownList ID="ddlCasos" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlCasos_SelectedIndexChanged" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">Nombre del Contacto:<strong><asp:Label ID="lblErrorNombreContacto" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">Nombre del Caso:<strong><asp:Label ID="lblErrorNombreCaso" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">
                        <asp:TextBox ID="txtNombreContacto" runat="server" BackColor="#FFFF99" class="form-control" Enabled="true" MaxLength="500" placeholder="" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">
                        <asp:TextBox ID="txtNombreCaso" runat="server" BackColor="#FFFF99" class="form-control" Enabled="true" MaxLength="500" placeholder="" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">Dirección:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">Tipos de casos:<strong><asp:Label ID="lblErrorTipoCaso" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">
                        <asp:TextBox ID="txtDireccion" runat="server" class="form-control" Enabled="true" MaxLength="250" placeholder="" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">
                        <asp:DropDownList ID="ddlTiposCaso" runat="server" AutoPostBack="True" BackColor="#FFFF99" class="form-control" Width="100%">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%" colspan="3">Género</td>
                    <td colspan="3">Código Único de Identificación (CUI):</td>
                    <td style="font-size: x-small;" colspan="2">Número de Identificación Tributaria (NIT):</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">Descripción:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="3">
                        <asp:RadioButtonList ID="rblGenero" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Selected="True" Value="1">Masculino</asp:ListItem>
                            <asp:ListItem Value="2">Femenino</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtCUI" runat="server" class="form-control" Enabled="true" Font-Size="Medium" MaxLength="13" placeholder="" Style="text-align: right" Width="100%">1615317920501</asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtNIT" runat="server" class="form-control" Enabled="true" Font-Size="Medium" MaxLength="10" placeholder="" Style="text-align: right" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8" rowspan="3">
                        <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" Enabled="true" Height="65px" MaxLength="1000" placeholder="" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="3">Sin espacios, Ej: 1165317920101</td>
                    <td colspan="2">Sin espacios, Ej.: 5124085-K</td>
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
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2">Telefono residencial:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2">Número de celular:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2">Teléfono del trabajo:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="4">Fecha de apertura (Ej: 20/01/2000):</td>
                    <td colspan="4">Fecha de finalización (Ej: 20/01/2000):</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTelefonoResidencial" runat="server" class="form-control" Enabled="true" MaxLength="250" placeholder="" Style="text-align: right" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTelefonoCelular" runat="server" class="form-control" Enabled="true" MaxLength="250" placeholder="" Style="text-align: right" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtTelefonoTrabajo" runat="server" class="form-control" Enabled="true" MaxLength="250" placeholder="" Style="text-align: right" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtFechaApertura" runat="server" class="form-control" Font-Bold="True" Font-Size="X-Large" MaxLength="10" Style="text-align: right" TextMode="Date" Width="100%">01/01/2016</asp:TextBox>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtFechaFinalizacion" runat="server" class="form-control" Font-Bold="True" Font-Size="X-Large" MaxLength="10" Style="text-align: right" TextMode="Date" Width="100%">01/01/2016</asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="4">Email personal:</td>
                    <td colspan="4">Email laboral:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8"><strong>
                        <asp:Label ID="lblErrorFechas" runat="server" ForeColor="Red" style="font-size: medium">*</asp:Label>
                        </strong></td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="4">
                        <asp:TextBox ID="txtEmailPersonal" runat="server" class="form-control" Enabled="true" MaxLength="250" placeholder="" Width="100%"></asp:TextBox>
                    </td>
                    <td colspan="4">
                        <asp:TextBox ID="txtEmailLaboral" runat="server" class="form-control" Enabled="true" MaxLength="250" placeholder="" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="4">
                        &nbsp;</td>
                    <td colspan="4">
                        &nbsp;</td>
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
                    <td colspan="8">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">Observaciones:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">Observaciones:</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">
                        <asp:TextBox ID="txtObservacionesContacto" runat="server" class="form-control" Enabled="true" Height="100px" MaxLength="500" placeholder="" TextMode="MultiLine" Width="100%"></asp:TextBox>
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8">
                        <asp:TextBox ID="txtObservacionesCaso" runat="server" class="form-control" Enabled="true" Height="100px" MaxLength="500" placeholder="" TextMode="MultiLine" Width="100%"></asp:TextBox>
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
                    <td colspan="8" style="text-align: center;">
                        <asp:Button ID="btnGuardarContacto" runat="server" class="btn btn-primary" OnClick="btnGuardarContacto_Click" Text="Guardar Contacto" ValidationGroup="grpDatos" Width="200px" />
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="8" style="text-align: center;">
                        <asp:Button ID="btnGuardarCaso" runat="server" class="btn btn-primary" OnClick="btnGuardarCaso_Click" Text="Guardar Caso" ValidationGroup="grpDatos" Width="200px" />
                    </td>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="16" style="text-align: center;"><span>
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
                        <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar Asignación" ValidationGroup="grpDatos" Width="200px" />
                        <asp:Button ID="btnLimpiarC" runat="server" class="btn btn-default" OnClick="btnNuevo_Click" Text="Nuevo" Width="200px" />
                        <asp:Button ID="btnListado" runat="server" CausesValidation="False" class="btn btn-primary" PostBackUrl="~/Contactos/ListadoContactos.aspx" Text="Ver Listado" Width="200px" Visible="False" />
                        <asp:Button ID="btnEliminar" runat="server" class="btn btn-default" OnClick="btnEliminar_Click" Text="Eliminar" Width="200px" Visible="False" />
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
                    <td colspan="18">Casos correspondientes al contacto seleccionado:</td>
                    <td style="width: 5%">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 5%">&nbsp;</td>
                    <td colspan="18">
                        <asp:GridView ID="gridAsignaciones" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="100" Width="100%" OnRowDeleting="gridAsignaciones_RowDeleting">
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False" HeaderText="Eliminar">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/delete.png" onclientclick="javascript:if(!confirm('¿Desea Eliminar Este Registro?'))return false" Text="Eliminar" />
                                    </ItemTemplate>
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nombre_contacto" HeaderText="Nombre del Contacto">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cui" HeaderText="CUI">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nit" HeaderText="NIT">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="genero" HeaderText="genero_contacto">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="direccion" HeaderText="Direccion">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="telefono_residencial" HeaderText="Teléfono residencial">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="telefono_celular" HeaderText="Teléfono celular">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="telefono_trabajo" HeaderText="Teléfono trabajo">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="id_caso" HeaderText="No.Caso">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nombre_caso" HeaderText="Nombre del caso">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="descripcion" HeaderText="Descripción">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tipo_caso" HeaderText="Tipo del caso">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha_apertura_grid" HeaderText="Fecha de apertura">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fecha_finalizacion_grid" HeaderText="Fecha de finalización">
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




