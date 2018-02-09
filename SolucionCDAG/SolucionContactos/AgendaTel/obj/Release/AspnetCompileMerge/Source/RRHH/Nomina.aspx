<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nomina.aspx.cs" Inherits="AplicacionSIPA1.RRHH.Nomina" MasterPageFile="~/Principal.Master" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <span class="auto-style16">
    <script type="text/javascript">
        if (window.history) {
            function noBack() { window.history.forward() }
            noBack();
            window.onload = noBack;
            window.onpageshow = function (evt)
            { if (evt.persisted) noBack() }
            window.onunload = function () { void (0) }
        }
    </script>
    Nomina
</span>
</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <br />
    <div id="welcome">
        

        <asp:UpdatePanel ID="UpdatePanel" runat="server">
            <ContentTemplate>

                            <table style="width:100%;" >
                                <tr>
                                    <td class="auto-style11" colspan="4">
                                        <strong>Periodo<br /> </strong>
                                        <asp:DropDownList ID="dropPeriodo" runat="server" OnSelectedIndexChanged="dropPeriodo_SelectedIndexChanged1">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style21">
                                        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="#339966" Text="Generar Nomina"></asp:Label>
                                    </td>
                                    <td class="auto-style27">
                                        &nbsp;</td>
                                    <td class="auto-style24">&nbsp;</td>
                                    <td class="auto-style19">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style22">Fecha<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFecha" ErrorMessage="*" Font-Bold="True" Font-Italic="False" ForeColor="Red" style="font-size: large" ValidationGroup="vaciosNomina"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="auto-style28">
                                        <asp:TextBox ID="txtFecha" runat="server" class="form-control" OnTextChanged="txtFecha_TextChanged" placeholder="fechaNacimiento" TextMode="Date"></asp:TextBox>
                                    </td>
                                    <td class="auto-style25">Tipo</td>
                                    <td>
                                        <asp:DropDownList ID="dropTipo" runat="server" AutoPostBack="True" class="form-control" DataTextField="descripcion" OnSelectedIndexChanged="dropTipo_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style22">Reglon</td>
                                    <td class="auto-style28">
                                        <asp:DropDownList ID="dropReglon" runat="server" AutoPostBack="True" class="form-control" DataTextField="Descripcion" OnSelectedIndexChanged="dropReglon_SelectedIndexChanged" Width="100%">
                                        </asp:DropDownList>
                                    </td>
                                    <td class="auto-style25">Unidad</td>
                                    <td>
                                        <asp:DropDownList ID="dropUnidad" runat="server" AutoPostBack="True" class="form-control" DataTextField="Descripcion" OnSelectedIndexChanged="dropUnidad_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style22">Descripcion<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="*" Font-Bold="True" Font-Italic="False" ForeColor="Red" style="font-size: large" ValidationGroup="vaciosNomina"></asp:RequiredFieldValidator>
                                    </td>
                                    <td class="auto-style28">
                                        <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" placeholder="Descripcion de la Nomina"></asp:TextBox>
                                    </td>
                                    <td class="auto-style25">
                                        <asp:Label ID="lblProyecto" runat="server" Text="Proyecto" Visible="False"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="dropProyecto" runat="server" class="form-control" DataTextField="Descripcion" OnSelectedIndexChanged="dropProyecto_SelectedIndexChanged" AutoPostBack="True" Visible="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style22">&nbsp;</td>
                                    <td class="auto-style28">
                                        &nbsp;</td>
                                    <td class="auto-style25">
                                        <asp:Button ID="btnGenerar" runat="server" BackColor="#6666FF" class="btn btn-primary" OnClick="btnGenerar_Click" onclientclick="javascript:if(!confirm('¿Seguro que Desea Generar la Nomina?'))return false" Text="AGREGAR" Width="134px" Font-Bold="True" Visible="False" />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style22" colspan="4">
                                        <asp:GridView ID="gridEmpleado" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnSelectedIndexChanged="gridEmpleado_SelectedIndexChanged" PageSize="5" Width="65%" OnRowDataBound="gridEmpleado_RowDataBound">
                                            <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="Aprobado">
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="CheckBox2" runat="server" />
                                                    </EditItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkSelecTodo" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelecTodo_CheckedChanged" Text="Agregar" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkAprobado" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="ID" HeaderText="ID" >
                                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="PuestoAct" HeaderText="Puesto">
                                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="unidad" HeaderText="Unidad">
                                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Reglon" HeaderText="Reglon">
                                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IDProyecto" HeaderText="Proyecto" >
                                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FIngreso" DataFormatString="{0:d}" HeaderText="FIngreso" >
                                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="SueldoBase">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("SueldoBase") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtSueldo" runat="server" BackColor="#FFCC99" Font-Bold="True" Width="65%"></asp:TextBox>
                                                        <asp:RangeValidator ID="RangeValidatorSueldo" runat="server" ControlToValidate="txtSueldo" ErrorMessage="Erro #" Font-Bold="True" ForeColor="#CC0000" MaximumValue="500000" MinimumValue="0" Type="Double"></asp:RangeValidator>
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Bonificacion">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Bonificacion") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtBonificacion" runat="server" Width="65%"></asp:TextBox>
                                                        <asp:RangeValidator ID="RangeValidatorBoni" runat="server" ControlToValidate="txtBonificacion" ErrorMessage="Error #" Font-Bold="True" ForeColor="#CC0000" MaximumValue="10000" MinimumValue="0" Type="Double"></asp:RangeValidator>
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="OtraDedu">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("OtraDedu") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtOtraDedu" runat="server" Width="65%"></asp:TextBox>
                                                        <asp:RangeValidator ID="RangeValidatorOD" runat="server" ControlToValidate="txtOtraDedu" ErrorMessage="Error #" Font-Bold="True" ForeColor="#CC0000" MaximumValue="10000" MinimumValue="0" Type="Double"></asp:RangeValidator>
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderStyle="Solid" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="OtraBoni">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("OtraBoni") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtOtraBoni" runat="server" Width="65%"></asp:TextBox>
                                                        <asp:RangeValidator ID="RangeValidatorOBoni" runat="server" ControlToValidate="txtOtraBoni" ErrorMessage="Error #" Font-Bold="True" ForeColor="#CC0000" MaximumValue="10000" MinimumValue="0" Type="Double"></asp:RangeValidator>
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="BanSeguro">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("BanSeguro") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtBanSeguro" runat="server" Width="65%"></asp:TextBox>
                                                        <asp:RangeValidator ID="RangeValidatorBanSeguro" runat="server" ControlToValidate="txtBanSeguro" ErrorMessage="Error #" Font-Bold="True" ForeColor="#CC0000" MaximumValue="10000" MinimumValue="0" Type="Double"></asp:RangeValidator>
                                                    </ItemTemplate>
                                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                            <SelectedRowStyle BackColor="#CEEFFF" Font-Bold="True" ForeColor="#333333" />
                                            <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                            <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                            <SortedDescendingHeaderStyle BackColor="#242121" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style22" colspan="4">
                                        <div style="OVERFLOW:auto;WIDTH:100%; HEIGHT:400px">
                                            <asp:GridView ID="gridPlanilla" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" CellPadding="5" CellSpacing="1" DataKeyNames="IDEmpleado" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" OnSelectedIndexChanged="gridEmpleado_SelectedIndexChanged" PageSize="5" Width="65%" OnRowDeleting="gridPlanilla_RowDeleting" OnRowDataBound="gridPlanilla_RowDataBound" ShowFooter="True">
                                                <AlternatingRowStyle BackColor="#CCCCCC" Font-Bold="True" />
                                                <Columns>
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/delete.png" onclientclick="javascript:if(!confirm('¿Desea Eliminar Este Registro?'))return false" Text="Eliminar" />
                                                        </ItemTemplate>
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="IDEmpleado" HeaderText="ID" >
                                                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Departamento" HeaderText="Departamento" >
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Renglon" HeaderText="Renglon">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Anio" DataFormatString="{0:d}" HeaderText="Año">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="FIngreso" DataFormatString="{0:d}" HeaderText="FechaIngreso" >
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Dias" HeaderText="Dias">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="SueldoBase" DataFormatString="{0:c}" HeaderText="SueldoBase">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Bonificacion" DataFormatString="{0:c}" HeaderText="Bonificacion">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OtrasBonificaciones" DataFormatString="{0:c}" HeaderText="OBon">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="OtrasDeducciones" DataFormatString="{0:c}" HeaderText="ODed">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IGSS" DataFormatString="{0:c}" HeaderText="IGSS">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Prestaciones" DataFormatString="{0:c}" HeaderText="Prestaciones">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Fianza" DataFormatString="{0:c}" HeaderText="Fianza">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Bantrab" DataFormatString="{0:c}" HeaderText="Bantrab">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="ISR" DataFormatString="{0:c}" HeaderText="ISR ">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="BanSeguro" DataFormatString="{0:c}" HeaderText="BanSeguro">
                                                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" />
                                                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Liquido" DataFormatString="{0:c}" HeaderText="Liquido">
                                                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <FooterStyle ForeColor="#003300" BorderStyle="Inset" Font-Bold="True" />
                                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#CEEFFF" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                                <SortedDescendingHeaderStyle BackColor="#242121" />
                                            </asp:GridView>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style22">&nbsp;</td>
                                    <td class="auto-style28">
                                        <asp:Button ID="btnGuardar" runat="server" class="btn btn-primary" OnClick="btnGuardar_Click" Text="GUARDAR" Width="134px" OnClientClick="javascript:if(!confirm('¿Desea Guardar la Nomina?'))return false" />
                                        <span class="auto-style15">
                                        <asp:Button ID="btnCancelar2" runat="server" class="btn btn-default" OnClick="btnCancelar_Click" Text="CANCELAR" Width="134px" />
                                        </span></td>
                                    <td class="auto-style25">
                                        <br />
                                        <br />
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style11" colspan="4">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style22">&nbsp;</td>
                                    <td class="auto-style28">
                                        &nbsp;</td>
                                    <td class="auto-style25">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style11" colspan="4">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style22">&nbsp;</td>
                                    <td class="auto-style28">&nbsp;</td>
                                    <td class="auto-style25">&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>




<asp:Content ID="Content3" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style11 {
        }
        .auto-style15 {
            font-family: Arial;
            font-weight: bold;
            color: #008000;
        }
        .auto-style16 {
            font-family: Arial;
            font-weight: normal;
            font-size: x-large;
        }
        .auto-style19 {
            background-color: #99CCFF;
        }
        .auto-style21 {
            background-color: #99CCFF;
            width: 208px;
        }
        .auto-style22 {
        }
        .auto-style24 {
            background-color: #99CCFF;
            width: 83px;
        }
        .auto-style25 {
            width: 83px;
        }
        .auto-style27 {
            background-color: #99CCFF;
            width: 448px;
        }
        .auto-style28 {
            width: 448px;
        }
        </style>
</asp:Content>




