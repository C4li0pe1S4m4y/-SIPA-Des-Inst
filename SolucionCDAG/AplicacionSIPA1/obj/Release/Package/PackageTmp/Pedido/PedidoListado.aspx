<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PedidoListado.aspx.cs" Inherits="AplicacionSIPA1.Pedido.PedidoListado" MasterPageFile="~/Principal.Master" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder3">

    <h2 style="font-size: x-large; text-align: center;" class="text-center">LISTADO - REQUISICIONES</h2>
    <div class="row">
        <div class="col-md-12">

            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-5">
                    <label>Año</label>
                    <strong>
                        <asp:Label ID="lblErrorAnio" runat="server" ForeColor="Red" Style="font-size: medium">*</asp:Label>
                    </strong>
                    <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" Width="100%">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-5">
                    <label>Unidad</label>
                    <strong>
                        <asp:Label ID="lblErrorUnidad" runat="server" ForeColor="Red" Style="font-size: medium">*</asp:Label>
                    </strong>
                    <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" Width="100%">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-5">
                    <label>Dependencia</label>
                    <asp:DropDownList ID="ddlDependencia" runat="server" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" AutoPostBack="True" class="form-control" Width="100%">
                    </asp:DropDownList>
                </div>
                <div class="col-sm-5">
                    <label>Jefatura/Unidad</label>
                    <asp:DropDownList ID="ddlJefaturaUnidad" runat="server" OnSelectedIndexChanged="ddlJefaturaUnidad_SelectedIndexChanged" AutoPostBack="True" class="form-control" Width="100%">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-10">
                    <label>Acciones </label>
                    <asp:DropDownList ID="ddlAcciones" runat="server" AutoPostBack="True" BackColor="#003366" class="form-control" ForeColor="White" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" Width="100%">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-1">
                    <label>No.Requesicion</label>
                    <asp:TextBox ID="txtNoReq" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                </div>
                <div class="col-sm-1">
                    <label>Bien/Servicio</label>
                    <asp:DropDownList ID="ddlTipo"  runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                </div>
                <div class="col-sm-3">
                    <label>Justificación</label>
                    <asp:TextBox ID="txtJustificacion" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                </div>
                <div class="col-lg-3">
                    <br />
                    <asp:ImageButton ID="btnRenglon" runat="server" ImageUrl="~/img/24_bits/find.png" Height="28px" Width="33px" OnClick="btnRenglon_Click" />
                </div>
            </div>
        </div>

    </div>

    <div class="row">
        <div class="col-sm-3">
            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
        <div class="col-sm-2">
            <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
        </div>
    </div>

    <asp:UpdatePanel ID="upIngreso" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-10">
                    <br />
                    <asp:GridView ID="gridDet" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID,multianual" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="12" Width="100%" Font-Size="X-Small"
                        CssClass="table table-hover ">
                        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                        <Columns>
                            <asp:TemplateField HeaderText="Opciones" ControlStyle-Width="25px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnConsultar" runat="server" OnClick="btnConsultar_Click"><asp:Image ImageUrl="~/img/24_bits/accept.png" runat="server" /></asp:LinkButton>
                                    
                                            <asp:LinkButton ID="btnImprimirr" runat="server" OnClick="btnImprimir_Click"><asp:Image ImageUrl="~/img/24_bits/download_page.png" runat="server" /></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="no_anio_solicitud" HeaderText="No.">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" Font-Bold="True" Font-Size="Medium" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fecha_pedido" HeaderText="Fecha Pedido">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tipo_pedido" HeaderText="B/S">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="justificacion" HeaderText="Justificación">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="estado_pedido" HeaderText="Estado Pedido">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Total Pedido">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <div class="text-right">
                                        <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" Text='<%# Bind("total", "Q.{0:0,0.00}") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="observaciones" HeaderText="Observaciones">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fecha_ingreso_compras" HeaderText="Fecha Compras">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="no_orden" HeaderText="No. Orden">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fecha_orden_compra" HeaderText="Fecha Orden">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="proveedor" HeaderText="Proveedor">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="multianual" HeaderText="multianual" Visible="false">
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Anexos">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" NavigateUrl="" Text='<%# Eval("tipo_anexo") %>' OnClick="LinkButton1_Click"></asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#99FF99" Font-Bold="True" ForeColor="#333333" />
                    </asp:GridView>
                </div>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
     <asp:Label ID="lblIdPoa" runat="server" Style="font-size: medium" ForeColor="White">0</asp:Label>
     <div class="row">
        <div class="col-sm-1">
            <asp:Label ID="lblPlanE" Visible="false" runat="server" Text="*"></asp:Label>
        </div>
        <div class="col-sm-2">
            <asp:Label ID="lblErrorPlan" runat="server" ForeColor="Red" Style="font-size: medium">*</asp:Label>
            <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPlanes_SelectedIndexChanged" Width="50%">
            </asp:DropDownList>
        </div>

        <div class="col-sm-3">
            <asp:Label ID="lblErrorPoa" runat="server" ForeColor="Red" Style="font-size: medium"></asp:Label>
        </div>
    </div>

</asp:Content>




