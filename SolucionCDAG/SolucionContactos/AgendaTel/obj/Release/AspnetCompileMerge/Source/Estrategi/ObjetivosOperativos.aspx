<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObjetivosOperativos.aspx.cs" Inherits="AplicacionSIPA1.Estrategi.ObjetivosOperativos" MasterPageFile="~/Principal.Master" %>





<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head"></asp:Content>



<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upBuscar" runat="server">
                <ContentTemplate>
                    <br />
                                <table style="width:80%;">
                <tr>
                    <td class="auto-style3" style="width: 178px">&nbsp;</td>
                    <td class="auto-style11" style="font-size: x-large"><strong>BÚSQUEDA</strong></td>
                </tr>
                <tr>
                    <td class="auto-style3" style="width: 178px">&nbsp;</td>
                    <td class="auto-style14"><strong>Objetivos Operativos</strong></td>
                </tr>
                                    <tr>
                                        <td class="auto-style3" style="width: 178px">Año:</td>
                                        <td class="auto-style14">
                                            <asp:DropDownList ID="ddlBAnio" runat="server" AutoPostBack="True" class="form-control" Width="15%" OnSelectedIndexChanged="ddlBAnio_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style3" style="width: 178px">Unidad Administrativa:</td>
                                        <td class="auto-style14">
                                            <asp:DropDownList ID="ddlBUnidades" runat="server" AutoPostBack="True" class="form-control" Width="90%">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
            </table>
            <table style="width:80%;">
                <tr>
                    <td class="auto-style3" style="width: 180px">Criterio de búsqueda:</td>
                    <td class="auto-style14" colspan="3">
                        <asp:RadioButtonList ID="rblCriterio" runat="server" OnSelectedIndexChanged="rblCriterio_SelectedIndexChanged" RepeatDirection="Horizontal" AutoPostBack="True">
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="width: 180px">&nbsp;</td>
                    <td class="auto-style14">&nbsp;</td>
                    <td class="auto-style12">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <table style="width:80%;">
                <tr>
                    <td class="auto-style3" style="width: 180px">&nbsp;Valor de búsqueda:</td>
                    <td style="width: 425px">
                        <asp:TextBox ID="txtBValor" runat="server" class="form-control" MaxLength="250" Width="95%" OnTextChanged="txtBValor_TextChanged"></asp:TextBox>
                    </td>
                    <td class="auto-style14">
                        <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBuscar_Click" Text="Buscar" Width="120px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3" style="width: 180px">&nbsp;</td>
                    <td colspan="2"><span>
                        <asp:Label ID="lblErrorBusqueda" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                        </span></td>
                </tr>
                <tr>
                    <td class="auto-style3" style="width: 180px">&nbsp;</td>
                    <td style="width: 425px">
                        <asp:Button ID="btnNuevo" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                    </td>
                    <td class="auto-style14">&nbsp;</td>
                </tr>
            </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
            <br />
            &nbsp;<br />
            <br />
            <table style="width:80%;">
                <tr>
                    <td class="auto-style3" style="width: 180px">&nbsp;</td>
                    <td class="auto-style14">
                        <asp:GridView ID="gridBusqueda" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnRowDeleting="gridBusqueda_RowDeleting" OnSelectedIndexChanged="gridBusqueda_SelectedIndexChanged" PageSize="5" Width="95%" OnPageIndexChanging="gridBusqueda_PageIndexChanging">
                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True" HeaderText="Modificar">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:CommandField>
                                
                                <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True"> 
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:CommandField>
                                
                                <asp:BoundField DataField="ID" HeaderText="ID">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codigo_oo" HeaderText="Cód. OP">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="o_operativo" HeaderText="Objetivo Operativo">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="anio" HeaderText="Año">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codigo_meta" HeaderText="Cod. Meta">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Meta" HeaderText="Meta">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codigo_oe" HeaderText="Cód. OE">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="o_estrategico" HeaderText="Objetivo Estrategico">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codigo_eje" HeaderText="Cód. Eje">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="eje" HeaderText="Eje Estratégico">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codigo_unidad" HeaderText="Cod. Un." >
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <asp:UpdatePanel ID="upModificar" runat="server">
                <ContentTemplate>
                    <br />
                    <table style="width:80%;">
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="10"><strong>OBJETIVOS OPERATIVOS</strong></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="10"><strong>
                                <asp:Label ID="lblAccion" runat="server"></asp:Label>
                                &nbsp;IdP -
                                <asp:Label ID="lblIdPoa" runat="server"></asp:Label>
                                </strong></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">Unidad Admin:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtBUnidad" runat="server" class="form-control" MaxLength="4" Width="90%"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:Button ID="btnBUnidad" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBUnidad_Click" Text="Buscar" />
                            </td>
                            <td colspan="6">
                                <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;">
                                <asp:Label ID="lblEU" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="2">&nbsp;</td>
                            <td colspan="6">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">Año:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtBAnio" runat="server" class="form-control" MaxLength="4" Width="90%"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:Button ID="btnBAnio" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBAnio_Click" Text="Buscar" />
                            </td>
                            <td colspan="6">
                                <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;">
                                <asp:Label ID="lblEA" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">Meta Estr.:</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtBMeta" runat="server" class="form-control" Width="90%"></asp:TextBox>
                            </td>
                            <td colspan="2">
                                <asp:Button ID="btnBMeta" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBMeta_Click" Text="Buscar" />
                            </td>
                            <td colspan="8">
                                <asp:DropDownList ID="ddlMetas" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlMetas_SelectedIndexChanged" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;"><span class="auto-style25" style="font-size: small">
                                <asp:Label ID="lblEM" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </span></td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">Código CMI:<asp:RequiredFieldValidator ID="rfvResponsable0" runat="server" ControlToValidate="txtCodigoCMI" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtCodigoCMI" runat="server" class="form-control" MaxLength="20" placeholder="Código CMI" Width="60%"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">Objetivos Op.:</td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlObjetivos" runat="server" AutoPostBack="True" class="form-control" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td colspan="2">Metas Operativas:</td>
                            <td colspan="5">
                                <asp:DropDownList ID="ddlMetasOp" runat="server" AutoPostBack="True" class="form-control" Width="100%">
                                </asp:DropDownList>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">Id:</td>
                            <td colspan="2"><strong>
                                <asp:Label ID="lblID" runat="server"></asp:Label>
                                </strong></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">Id:</td>
                            <td colspan="2"><strong>
                                <asp:Label ID="lblIdDetalle" runat="server"></asp:Label>
                                </strong></td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="2">Cód. Obj. Ope.:<asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="3">Objetivo Operativo:<asp:RequiredFieldValidator ID="rfvEje" runat="server" ControlToValidate="txtObjetivo" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="3">Indicador/KPI:<asp:RequiredFieldValidator ID="rfvIndicador" runat="server" ControlToValidate="txtIndicador" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                            </td>
                            <td colspan="3">Meta Operativa:<asp:RequiredFieldValidator ID="rfvMeta" runat="server" ControlToValidate="txtMeta" ErrorMessage="*" Font-Bold="True" Font-Size="Large" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtCodigo" runat="server" class="form-control" MaxLength="2" OnTextChanged="txtCodigo_TextChanged" placeholder="Código" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtObjetivo" runat="server" class="form-control" Height="100%" MaxLength="250" OnTextChanged="txtObjetivo_TextChanged" placeholder="Objetivo Operativo" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="3">
                                <asp:TextBox ID="txtIndicador" runat="server" class="form-control" Height="100%" MaxLength="500" OnTextChanged="txtIndicador_TextChanged" placeholder="Indicador/Kpi" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtMeta" runat="server" class="form-control" Height="100%" MaxLength="500" OnTextChanged="txtMeta_TextChanged" placeholder="Meta Operativa" TextMode="MultiLine" Width="100%"></asp:TextBox>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="2">
                                <asp:RangeValidator ID="rvCodigo" runat="server" ControlToValidate="txtCodigo" ErrorMessage="Valores entre 1 - 99" Font-Bold="True" ForeColor="Red" MaximumValue="99" MinimumValue="1" Type="Integer" ValidationGroup="grpDatos"></asp:RangeValidator>
                            </td>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="14"><span>
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
                                </span></td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td colspan="14">
                                <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="grpDatos" Width="120px" />
                                <asp:Button ID="btnLimpiarC" runat="server" class="btn btn-default" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                                <asp:Button ID="btnModificar" runat="server" class="btn btn-primary" OnClick="btnModificar_Click" Text="Modificar" ValidationGroup="grpDatos" Width="120px" />
                                <asp:Button ID="btnEliminar" runat="server" CausesValidation="False" class="btn btn-default" OnClick="btnEliminar_Click" Text="Eliminar" Width="120px" />
                                <asp:Button ID="btnNuevaB" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnNuevaB_Click" Text="Buscar" Width="120px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
                            <td style="width:5%;">&nbsp;</td>
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>




