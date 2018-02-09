<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MetasEstrategicasB.aspx.cs" Inherits="AplicacionSIPA1.Estrategia.MetasEstrategicasB" MasterPageFile="~/Principal.Master" %>





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
                    <td class="auto-style14"><strong>Metas Estratégicas</strong></td>
                </tr>
                                    <tr>
                                        <td class="auto-style3" style="width: 178px">Año:</td>
                                        <td class="auto-style14">
                                            <asp:DropDownList ID="ddlBAnio" runat="server" AutoPostBack="True" class="form-control" Width="15%">
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
                        <asp:TextBox ID="txtBValor" runat="server" class="form-control" MaxLength="250" Width="95%"></asp:TextBox>
                    </td>
                    <td class="auto-style14">
                        <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBuscar_Click" Text="Buscar" />
                    </td>
                </tr>
            </table>
            <br />
            &nbsp;<br />
            <br />
            <table style="width:80%;">
                <tr>
                    <td class="auto-style3" style="width: 180px">&nbsp;</td>
                    <td class="auto-style14">
                        <asp:GridView ID="gridBusqueda" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnRowDeleting="gridBusqueda_RowDeleting" OnSelectedIndexChanged="gridBusqueda_SelectedIndexChanged" PageSize="5" Width="65%" OnPageIndexChanging="gridBusqueda_PageIndexChanging">
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
                                <asp:BoundField DataField="codigo" HeaderText="Código">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="meta" HeaderText="Meta">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="anio" HeaderText="Año">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="kpi" HeaderText="KPI" Visible="False">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="formula" HeaderText="Fórmula" Visible="False">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codigo_objetivo" HeaderText="Cod. Obj. Estr.">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Objetivo" HeaderText="Obj. Estr.">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="codigo_eje" HeaderText="Cod. Eje" >
                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="eje" HeaderText="Eje" >
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
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <asp:UpdatePanel ID="upModificar" runat="server">
                <ContentTemplate>
                    <br />
                    <table style="width:80%;">
                        <tr>
                            <td class="auto-style3" style="width: 178px">&nbsp;</td>
                            <td class="auto-style11" style="font-size: x-large"><strong>METAS ESTRATÉGICAS</strong></td>
                        </tr>
                        <tr>
                            <td class="auto-style3" style="width: 178px">&nbsp;</td>
                            <td class="auto-style14"><strong>(Modificar/Eliminar) Id -
                                <asp:Label ID="lblID" runat="server"></asp:Label>
                                </strong></td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <table style="width:80%;">
                        <tr>
                            <td class="auto-style3" style="width: 160px">Año:</td>
                            <td style="font-size: medium; width: 80px;">
                                <asp:TextBox ID="txtBAnio" runat="server" class="form-control" MaxLength="4" Width="90%"></asp:TextBox>
                            </td>
                            <td class="modal-sm" style="font-size: medium; width: 102px;">
                                <asp:Button ID="btnBAnio" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBAnio_Click" Text="Buscar" />
                            </td>
                            <td class="auto-style11" style="font-size: medium">
                                <asp:DropDownList ID="ddlAnio" runat="server" class="form-control" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged" Width="15%" AutoPostBack="True">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3" style="width: 155px">&nbsp;</td>
                            <td colspan="3" style="font-size: medium; ">
                                <asp:Label ID="lblErrorAnio" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <table style="width: 80%;">
                        <tr>
                            <td class="auto-style42" style="width: 160px">Objetivo Estratégico:</td>
                            <td class="auto-style42" style="width: 76px">
                                <asp:TextBox ID="txtBObjetivo" runat="server" class="form-control" Width="90%"></asp:TextBox>
                            </td>
                            <td class="auto-style42" style="width: 72px">
                                <asp:Button ID="btnBObjetivo" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBObjetivo_Click" Text="Buscar" />
                            </td>
                            <td class="auto-style42">
                                <asp:DropDownList ID="ddlObjetivo" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlObjetivo_SelectedIndexChanged" Width="75%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style55" style="width: 156px">&nbsp;</td>
                            <td class="auto-style56" colspan="3"><strong><span class="auto-style25" style="font-size: small">Ejemplo: 1.1</span></strong><br />
                                <asp:Label ID="lblErrorObjetivo" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    <table style="width:80%;">
                        <tr>
                            <td class="auto-style3" style="width: 160px">Código Meta:</td>
                            <td class="auto-style11" style="font-size: medium; width: 107px;">
                                <asp:TextBox ID="txtCodigo" runat="server" class="form-control" MaxLength="2" placeholder="Código" Width="85%"></asp:TextBox>
                            </td>
                            <td class="auto-style11" style="font-size: medium; width: 164px;">
                                <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo" CssClass="auto-style26" ErrorMessage="* Ingrese un valor" ForeColor="Red" style="font-size: small" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ID="revCodigo" runat="server" ControlToValidate="txtCodigo" CssClass="auto-style26" ErrorMessage="*Ingrese un valor numérico" ForeColor="Red" style="font-size: small" ValidationExpression="^[0-9]+$" ValidationGroup="grpDatos"></asp:RegularExpressionValidator>
                            </td>
                            <td class="auto-style11" style="font-size: medium">&nbsp;</td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <table style="width: 80%;">
                        <tr>
                            <td class="auto-style44" style="width: 160px">Indicador/Kpi:</td>
                            <td class="auto-style49" style="width: 272px">
                                <asp:TextBox ID="txtIndicador" runat="server" class="form-control" MaxLength="250" placeholder="Indicador/Kpi" TextMode="MultiLine" Width="95%"></asp:TextBox>
                            </td>
                            <td class="auto-style45">Fórmula Kpi:</td>
                            <td class="auto-style41">
                                <asp:TextBox ID="txtFormula" runat="server" class="form-control" MaxLength="250" placeholder="Fórmula Indicador/Kpi" TextMode="MultiLine" Width="95%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style44" style="width: 160px">&nbsp;</td>
                            <td class="auto-style49" style="width: 272px">
                                <asp:RequiredFieldValidator ID="rfvIndicador" runat="server" ControlToValidate="txtIndicador" CssClass="auto-style29" ErrorMessage="* Ingrese un valor" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                            <td class="auto-style45">&nbsp;</td>
                            <td class="auto-style41">
                                <asp:RequiredFieldValidator ID="rfvFormula" runat="server" ControlToValidate="txtFormula" CssClass="auto-style29" ErrorMessage="* Ingrese un valor" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <table style="width:80%;">
                        <tr>
                            <td class="auto-style3" style="width: 160px">Meta Estratégica:</td>
                            <td class="auto-style11" style="font-size: medium; ">
                                <asp:TextBox ID="txtMeta" runat="server" class="form-control" placeholder="Objetivo Estratégico" Width="80%" MaxLength="250" TextMode="MultiLine"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvMeta" runat="server" ControlToValidate="txtMeta" CssClass="auto-style26" ErrorMessage="* Ingrese un valor" ForeColor="Red" style="font-size: small" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <table style="width: 80%;">
                        <tr>
                            <td class="auto-style44" style="width: 160px">Unidades:</td>
                            <td class="auto-style50">
                                <asp:RadioButtonList ID="rblUnidades" runat="server" RepeatColumns="1">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style44" style="width: 160px">&nbsp;</td>
                            <td class="auto-style50">
                                <asp:Label ID="lblErrorUnidad" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table style="width:80%;">
                        <tr>
                            <td class="auto-style3" style="width: 80px">&nbsp;</td>
                            <td class="auto-style11" style="font-size: medium; "><span>
                                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" visible="False"></asp:Label>
                                <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green" visible="False"></asp:Label>
                                </span></td>
                        </tr>
                        <tr>
                            <td class="auto-style3" style="width: 80px">&nbsp;</td>
                            <td class="auto-style11" style="font-size: medium">
                                <asp:Button ID="btnModificar" runat="server" class="btn btn-primary" OnClick="btnModificar_Click" Text="Modificar" ValidationGroup="grpDatos" Width="120px" />
                                <asp:Button ID="btnEliminar" runat="server" class="btn btn-default" OnClick="btnEliminar_Click" Text="Eliminar" Width="120px" CausesValidation="False" />
                                <asp:Button ID="btnNuevaB" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnNuevaB_Click" Text="Buscar" Width="120px" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>




