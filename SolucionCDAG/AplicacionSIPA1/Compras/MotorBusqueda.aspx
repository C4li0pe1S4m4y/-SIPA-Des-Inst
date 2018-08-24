<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MotorBusqueda.aspx.cs" Inherits="AplicacionSIPA1.Compras.MotorBusqueda" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2 style="text-align: center">Motor de Busqueda</h2>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-1">
            <label>Año</label>
            <asp:DropDownList ID="ddlAnio" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-sm-1">
            <label>Requisicion</label>
            <asp:TextBox ID="txtRequi" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-3">
            <label>Unidad</label>
            <asp:DropDownList ID="ddlUnidad" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-sm-3">
            <label>Dependencia</label>
            <asp:DropDownList ID="ddlDependencia" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-sm-2">
            <label>Centro de Costo</label>
            <asp:DropDownList ID="ddlCentroCosto" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>

        <div class="col-sm-3">
            <label>Tecnico</label>
            <asp:DropDownList ID="ddlTecnico" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-sm-3">
            <label>Descripcion</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <label>Mes</label>
            <asp:DropDownList ID="ddlMes" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
       
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-3">
            <label>Nit</label>
            <asp:TextBox ID="txtNit" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-sm-3">
            <label>Insumo</label>
            <asp:TextBox ID="txtInsumo" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
        </div>
         <div class="col-sm-2">
            <br />
            <asp:LinkButton ID="btnBuscar" runat="server" Text="Guardar" CssClass="btn btn-info" Width="50%" Height="60%" OnClick="btnBuscar_Click">
                Buscar&nbsp<span class="glyphicon glyphicon-search" aria-hidden="true"></span>
            </asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <br />
            <asp:DetailsView ID="dvPedido" runat="server" AllowPaging="True" AutoGenerateRows="False" OnPageIndexChanging="dvPedido_PageIndexChanging" DataKeyNames="ID" Width="100%"
                CssClass="list-group">
                <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false" ItemStyle-CssClass="list-group-item" ControlStyle-Width="100%">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />

                    </asp:BoundField>
                    <asp:BoundField DataField="no_anio_solicitud" HeaderText="No. Pedido">
                        <HeaderStyle BorderStyle="Inset" Width="30%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BackColor="#99FF99" Width="70%" BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>

                    <asp:BoundField DataField="documento" HeaderText="Tipo de Documento">
                        <HeaderStyle BorderStyle="Inset" Width="30%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BackColor="#FF6600" Width="70%" BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fecha_pedido" DataFormatString="{0:d}" HeaderText="Fecha Pedido">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fecha_Asig" HeaderText="Fecha Asignacion">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fecha_ingreso" HeaderText="Fecha de Ing.">
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
                    <asp:BoundField DataField="centro_costo" HeaderText="Centro de Costo">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Anexos">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" NavigateUrl="" Text='<%# Eval("tipo_anexo") %>'></asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                </Fields>
                <FooterStyle Font-Bold="False" />
                <PagerStyle BackColor="White" BorderStyle="Solid" Font-Bold="True" Font-Overline="False" Font-Size="Medium" Font-Strikeout="False" Font-Underline="False" />
            </asp:DetailsView>
        </div>
    </div>

    <br />
    <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5"
        CellSpacing="1" Font-Size="Small" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="12" ShowFooter="True" Width="125%" CssClass="auto-style4" Style="margin-left: 69px" OnRowDataBound="gvDetalle_RowDataBound">
        <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN">
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="no_renglon" HeaderText="RENGLON">
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="cantidad" HeaderText="CANTIDAD">
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="costo_u_pedido" HeaderText="Valor Unitario">
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="Monto" HeaderText="Monto">
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="costo_pedido" HeaderText="Monto sin IVA">
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:BoundField DataField="ajuste" HeaderText="ajuste">
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Estatus">

                <ItemTemplate>
                    <asp:DropDownList ID="ddlEstatus" runat="server" class="form-control" data-placeholder="Busque Tipo Docto...." Width="135px" Style="font-size: smaller">
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cantidad">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <div class="text-right">
                        <asp:TextBox ID="txtCantidadReal" runat="server" Style="text-align: right" CssClass="form-control" Text='<%# Bind("cantidad_compras") %>' Width="50px"></asp:TextBox>
                    </div>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Monto Individual">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <div class="text-right">
                        <asp:TextBox ID="txtCostoUReal" runat="server" CssClass="form-control" Style="text-align: right" Text='<%# Bind("costo_u_compras", "Q.{0:0,0.00}") %>' Width="125px"></asp:TextBox>
                        <asp:Label ID="lblErrorCostoUReal" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="SUBTOTAL">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Font-Bold="True" Text='<%# Bind("subtotal") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <div class="text-right">
                        <asp:Label ID="lblSubtotalEstimado" runat="server" Font-Bold="True" Text='<%# Bind("subtotal", "Q.{0:0,0.00}") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IVA">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Font-Bold="True" Text='<%# Bind("subtotal") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <div class="text-right">
                        <asp:Label ID="lblIVA" runat="server" Font-Bold="True" Text='<%# Bind("subtotal", "Q.{0:0,0.00}") %>'></asp:Label>
                    </div>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Proveedor">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:DropDownList ID="ddlProveedor" runat="server" Width="250px" class="dropdown-toggle dropdown_select">
                        <%--<option value="">--Proveedor--</option>--%>
                    </asp:DropDownList>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha T. Orden C.">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtFechaTrasladoOC" runat="server" CssClass="form-control" TextMode="Date" Text='<%# Bind("fecha_traslado_orden") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha Orden C.">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtFechaOrdenCompra" runat="server" CssClass="form-control" TextMode="Date" Text='<%# Bind("fecha_orden_compra") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Orden Compra">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtOrdenCompra" runat="server" CssClass="form-control" Text='<%# Bind("no_orden_compra") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Factura">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtFactura" runat="server" CssClass="form-control" Text='<%# Bind("Factura") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha Factura">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtFechaFactura" runat="server" CssClass="form-control" TextMode="Date" Text='<%# Bind("fecha_factura") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha T. Almacen">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtFechaTrasladoAlmacen" runat="server" CssClass="form-control" TextMode="Date" Text='<%# Bind("fecha_traslado_almacen") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha Ingreso B/S">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtFechaIngresoBS" runat="server" CssClass="form-control" TextMode="Date" Text='<%# Bind("fecha_ingreso_BS") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="F.Traslado F.Rotativo">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:TextBox ID="txtFechaFondoRotativo" runat="server" CssClass="form-control" TextMode="Date" Text='<%# Bind("txtFechaFondoRotativo") %>'></asp:TextBox>
                </ItemTemplate>
                <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Seleccionar">
                <ItemTemplate>
                    <asp:CheckBox ID="chkItem" runat="server" />
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
    <br />
    <br />
</asp:Content>
