<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MetasEstrategicas.aspx.cs" Inherits="AplicacionSIPA1.Estrategia.MetasEstrategicas" MasterPageFile="~/Principal.Master" %>





<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    &nbsp;&nbsp;&nbsp;
    <br />
    <style type="text/css">
        
        .auto-style11 {
            text-align: center;
            font-size: x-large;
        }
        .auto-style29 {
            font-size: small;
        }
        .auto-style38 {
            width: 120px;
        }
        .auto-style40 {
            width: 104px;
        }
        .auto-style41 {
            height: 22px;
        }
        .auto-style43 {
            width: 100px;
        }
        .auto-style44 {
            width: 120px;
            height: 22px;
        }
        .auto-style45 {
            height: 22px;
            width: 105px;
        }
        .auto-style47 {
            height: 22px;
        }
        .auto-style48 {
            height: 22px;
            width: 100px;
        }
        .auto-style49 {
            height: 22px;
            width: 272px;
        }
        .auto-style50 {
            height: 22px;
        }
        .auto-style51 {
            height: 22px;
        }
    </style>
</asp:Content>



<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
<br />
                        <table style="width:80%;">
                            <tr>
                                <td class="auto-style11"><strong>METAS ESTRATÉGICAS</strong></td>
                            </tr>
                        </table>
<br />
                        <br />
                        <br />
                        <table style="width: 80%;">
                            <tr>
                                <td class="auto-style38">Año:</td>
                                <td class="auto-style43">
                                    <asp:TextBox ID="txtBAnio" runat="server" class="form-control" MaxLength="4" Width="85%"></asp:TextBox>
                                </td>
                                <td class="auto-style40">
                                    <asp:Button ID="btnBAnio" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBAnio_Click" Text="Buscar" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged" Width="90%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style44"></td>
                                <td class="auto-style41" colspan="3">
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
                                <td class="auto-style44">Objetivo Estratégico:</td>
                                <td class="auto-style48">
                                    <asp:TextBox ID="txtBObjetivo" runat="server" class="form-control" Width="85%"></asp:TextBox>
                                </td>
                                <td class="auto-style45">
                                    <asp:Button ID="btnBObjetivo" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBObjetivo_Click" Text="Buscar" />
                                </td>
                                <td class="auto-style41">
                                    <asp:DropDownList ID="ddlObjetivos" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlObjetivos_SelectedIndexChanged" Width="90%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style44">&nbsp;</td>
                                <td class="auto-style47" colspan="3"><span class="auto-style29"><strong>Ejemplo: 1.1<br /> </strong>
                                    <asp:Label ID="lblErrorObjetivo" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                    </span></td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <br />
                        <table style="width: 80%;">
                            <tr>
                                <td class="auto-style44">Código:</td>
                                <td class="auto-style48">
                                    <asp:TextBox ID="txtCodigo" runat="server" class="form-control" MaxLength="2" placeholder="Código" Width="90%"></asp:TextBox>
                                </td>
                                <td class="auto-style41">
                                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo" CssClass="auto-style29" ErrorMessage="* Ingrese un valor numérico" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="revCodigo" runat="server" ControlToValidate="txtCodigo" CssClass="auto-style29" ErrorMessage="* Ingrese un valor numérico" ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="grpDatos"></asp:RegularExpressionValidator>
                                </td>
                                <td class="auto-style41">&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style44">&nbsp;</td>
                                <td class="auto-style48">&nbsp;</td>
                                <td class="auto-style41">&nbsp;</td>
                                <td class="auto-style41">&nbsp;</td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <table style="width: 80%;">
                            <tr>
                                <td class="auto-style44">Indicador/Kpi:</td>
                                <td class="auto-style49">
                                    <asp:TextBox ID="txtIndicador" runat="server" class="form-control" MaxLength="250" placeholder="Indicador/Kpi" TextMode="MultiLine" Width="95%"></asp:TextBox>
                                </td>
                                <td class="auto-style45">Fórmula Kpi:</td>
                                <td class="auto-style41">
                                    <asp:TextBox ID="txtFormula" runat="server" class="form-control" MaxLength="250" placeholder="Fórmula Indicador/Kpi" TextMode="MultiLine" Width="95%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style44">&nbsp;</td>
                                <td class="auto-style49">
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
                        <br />
                        <br />
                        <table style="width: 80%;">
                            <tr>
                                <td class="auto-style44">Meta Estratégica:</td>
                                <td class="auto-style51">
                                    <asp:TextBox ID="txtNombre" runat="server" class="form-control" MaxLength="500" placeholder="Meta Estratégica" TextMode="MultiLine" Width="96%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMeta" runat="server" ControlToValidate="txtNombre" CssClass="auto-style29" ErrorMessage="* Ingrese un valor" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table style="width: 80%;">
                            <tr>
                                <td class="auto-style44">Unidades:</td>
                                <td class="auto-style50">
                                    <asp:RadioButtonList ID="rblUnidades" runat="server" Font-Size="X-Small" RepeatColumns="5" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style44">&nbsp;</td>
                                <td class="auto-style50">
                                    <asp:Label ID="lblErrorUnidad" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table style="width: 80%;">
                            <tr>
                                <td class="auto-style44">&nbsp;</td>
                                <td class="auto-style50"><span>
                                    <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red" visible="False"></asp:Label>
                                    <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green" visible="False"></asp:Label>
                                    </span></td>
                            </tr>
                            <tr>
                                <td class="auto-style44">&nbsp;</td>
                                <td class="auto-style50">
                                    <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="grpDatos" Width="120px" />
                                    <asp:Button ID="btnNuevo" runat="server" class="btn btn-default" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                                    <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBuscar_Click" Text="Buscar" Width="120px" />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <br />
                    </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>




