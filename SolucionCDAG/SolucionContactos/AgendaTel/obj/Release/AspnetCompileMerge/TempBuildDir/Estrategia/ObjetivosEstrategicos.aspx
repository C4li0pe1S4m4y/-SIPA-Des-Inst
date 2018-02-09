<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ObjetivosEstrategicos.aspx.cs" Inherits="AplicacionSIPA1.Estrategia.ObjetivosEstrategicos" MasterPageFile="~/Principal.Master" %>





<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    &nbsp;&nbsp;&nbsp;
    <br />
    <style type="text/css">
        .auto-style3 {
            width: 15%;
        }

        .auto-style4 {
            width: 25%;
        }

        .auto-style11 {
            text-align: center;
            font-size: x-large;
        }
        .auto-style14 {
        }
        .auto-style17 {
            width: 15%;
            height: 22px;
        }
        .auto-style18 {
            width: 37%;
            height: 22px;
        }
        .auto-style19 {
            width: 25%;
            height: 22px;
        }
        .auto-style22 {
            height: 43px;
            width: 426px;
        }
        .auto-style23 {
            width: 33%;
            height: 43px;
        }
        .auto-style24 {
            width: 18%;
            height: 43px;
        }
        .auto-style25 {
            font-size: small;
        }
        .auto-style33 {
            width: 93px;
            height: 35px;
        }
        .auto-style37 {
            width: 165px;
            height: 35px;
        }
        .auto-style39 {
            width: 55px;
            height: 35px;
        }
        .auto-style42 {
            width: 18%;
            height: 35px;
        }
        .auto-style43 {
            width: 18%;
            height: 22px;
        }
        .auto-style44 {
            width: 15%;
            height: 35px;
        }
        .auto-style45 {
            width: 25%;
            height: 35px;
        }
        .auto-style55 {
            width: 140px;
        }
        .auto-style56 {
        }
        .auto-style59 {
            width: 73px;
            height: 35px;
        }
        .auto-style60 {
            width: 18%;
        }
        .auto-style63 {
            width: 43%;
        }
        .auto-style65 {
            width: 15%;
            height: 46px;
        }
        .auto-style66 {
            height: 46px;
        }
        .auto-style67 {
            width: 25%;
            height: 46px;
        }
    </style>
</asp:Content>



<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <br />
                        <table style="width:80%;" >
                            <tr>
                                <td class="auto-style11"><strong>OBJETIVOS ESTRATÉGICOS</strong></td>
                            </tr>
            </table>
                        <br />
                        <br />
                        <table style="width:80%;" >
                            <tr>
                                <td class="auto-style42">Año:</td>
                                <td class="auto-style33">
                                    <asp:TextBox ID="txtBAnio" runat="server" class="form-control" Width="80%" MaxLength="4"></asp:TextBox>
                                </td>
                                <td class="auto-style39">
                                    <asp:Button ID="btnBAnio" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBAnio_Click" Text="Buscar" />
                                </td>
                                <td class="auto-style37">
                                    <asp:DropDownList ID="ddlAnio" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged" Width="90%">
                                    </asp:DropDownList>
                                </td>
                                <td class="auto-style44"></td>
                                <td class="auto-style45"></td>
                            </tr>
                            <tr>
                                <td class="auto-style43"></td>
                                <td class="auto-style18" colspan="3">
                                    <asp:Label ID="lblErrorAnio" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </td>
                                <td class="auto-style17"></td>
                                <td class="auto-style19"></td>
                            </tr>
            </table>
                        
                        <br />
                        <br />
                        <br />
                        <br />
                        <table style="width: 80%;">
                            <tr>
                                <td class="auto-style42">Eje Estratégico:</td>
                                <td class="auto-style59">
                                    <asp:TextBox ID="txtBEje" runat="server" class="form-control" Width="80%"></asp:TextBox>
                                </td>
                                <td class="auto-style39">
                                    <asp:Button ID="btnBEje" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBEje_Click" Text="Buscar" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEje" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlEje_SelectedIndexChanged" Width="75%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style55">&nbsp;</td>
                                <td class="auto-style56" colspan="3">
                                    <strong><span class="auto-style25">Ejemplo: 1</span></strong><br />
                                    <asp:Label ID="lblErrorEje" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <table style="width:80%;">
                            <tr>
                                <td class="auto-style60">Código Objetivo:</td>
                                <td>
                                    <asp:TextBox ID="txtCodigoObjEstrategico" runat="server" class="form-control" MaxLength="2" placeholder="Código" Width="85%"></asp:TextBox>
                                </td>
                                <td class="auto-style63">
                                    <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigoObjEstrategico" CssClass="auto-style25" ErrorMessage="* Ingrese un valor numérico" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="revCodigo" runat="server" ControlToValidate="txtCodigoObjEstrategico" CssClass="auto-style25" ErrorMessage="* Ingrese un valor numérico" ForeColor="Red" ValidationExpression="^[0-9]+$" ValidationGroup="grpDatos"></asp:RegularExpressionValidator>
                                </td>
                                <td class="auto-style4">&nbsp;</td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table style="width:80%;">
                            <tr>
                                <td class="auto-style24">Objetivo Estratégico:</td>
                                <td class="auto-style22">
                                    <asp:TextBox ID="txtObjEstrategico" runat="server" class="form-control" MaxLength="500" placeholder="Nombre de Objetivo Estratégico" TextMode="MultiLine" Width="95%"></asp:TextBox>
                                </td>
                                <td class="auto-style23">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtObjEstrategico" CssClass="auto-style25" ErrorMessage="* Ingrese un valor" ForeColor="Red" ValidationGroup="grpDatos"></asp:RequiredFieldValidator>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table style="width:80%;">
                            <tr>
                                <td class="auto-style3">&nbsp;</td>
                                <td class="auto-style14" colspan="2">
                                    <asp:Label ID="lblError" runat="server" Font-Size="Medium" visible="False" Font-Bold="True" ForeColor="Red"></asp:Label>                             
                                    <asp:Label ID="lblSuccess" runat="server" Font-Size="Medium" visible="False" Font-Bold="True" ForeColor="Green"></asp:Label>
                                    </td>
                            </tr>
                            <tr>
                                <td class="auto-style65"></td>
                                <td class="auto-style66">
                                    <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="Guardar" ValidationGroup="grpDatos" Width="120px" />
                                    <asp:Button ID="btnNuevo" runat="server" class="btn btn-default" OnClick="btnNuevo_Click" Text="Nuevo" Width="120px" />
                                    <asp:Button ID="btnBuscar" runat="server" CausesValidation="False" class="btn btn-primary" OnClick="btnBuscar_Click" Text="Buscar" Width="120px" />
                                </td>
                                <td class="auto-style67"></td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <br />
                        <br />
                        </ContentTemplate>
 </asp:UpdatePanel>
</asp:Content>




