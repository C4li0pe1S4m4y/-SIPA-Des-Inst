<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FechaTraslado.aspx.cs" Inherits="AplicacionSIPA1.Compras.FechaTraslado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        function abrirModal(tipo) {
            $(tipo).modal('show');
            window.open('http://localhost/seal/OutputResult?execution_guid=854ffdb8-5f29-42fb-b9be-e2ca46487db0', '_blank');

        }
        function cerrarModal(tipo) {
            $(tipo).modal('hide');
        }
        function irTab(tipo) {
            $('.nav-tabs a[href="' + tipo + '"]').tab('show')
        }

    </script>
    <script src="../../Scripts/select2.min.js"></script>
    <link href="../../Content/css/select2.min.css" rel="stylesheet" />
    <script>
        $(function () {

            $(document).ready(function () {
                $('.dropdown_select').select2();
            });
        });
    </script>

    <style type="text/css">
        .auto-style3 {
            display: block;
            font-size: 1rem;
            line-height: 1.5;
            color: #495057;
            background-color: #fff;
            background-clip: padding-box;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
            transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
        }

        .auto-style4 {
            margin-left: 47px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2 style="text-align: center">Ingreso Datos Requisicion. Tecnico Compras</h2>

    <div class="row" title="Datos SIPA">
        <div class="col-sm-1"></div>
        <div class="col-sm-1">
            <label>No.Req.</label>
            <asp:TextBox TextMode="Number" ID="txtNo" BackColor="#fff29d" runat="server" CssClass="form-control" required="true"></asp:TextBox>
        </div>
        <div class="col-sm-1">
            <label>Año</label>
            <asp:DropDownList ID="ddlanio" Width="100%" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
        <div class="col-sm-2">
            <br />
            <asp:LinkButton ID="btnBusqueda" Width="75%" runat="server" Text="Buscar" CssClass="btn btn-info" OnClick="btnBusqueda_Click" Height="60%">
                 Buscar&nbsp <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
            </asp:LinkButton>
        </div>
        <div class="col-sm-5">
            <asp:Label ID="idpedido" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lbl" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="col-sm-2">
            <br />
            <asp:LinkButton ID="lbAnexo" runat="server" CssClass="link-style btn-warning" Text='<%# Eval("tipo_anexo") %>' OnClick="lbAnexo_Click" >
                Anexos
            </asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <div class="panel panel-default border">
                <div class="panel-heading alert-secondary" style="background-color: #18bc9c; color: #FFFFFF;">&nbsp;&nbsp;&nbsp; Datos Requisicion</div>
                <div class="panel-body">
                    <div class="row">

                        <div class="col-sm-3">
                            <label>Unidad</label>
                            <asp:TextBox ID="txtUnidad" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label>Dependencia</label>
                            <asp:TextBox ID="txtDependecia" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label>Fecha Creacion</label>
                            <asp:TextBox ID="txtFechaCreacion" ReadOnly="true" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label>Fecha Mesa Entrada</label>
                            <asp:TextBox ID="txtFechaMesaEntrada" runat="server" ReadOnly="true" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">

                        <div class="col-sm-3">
                            <label>Fecha Asigancion Tecnico</label>
                            <asp:TextBox ID="txtFechaAsignacionTecnico" runat="server" ReadOnly="true" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label>Tecnico</label>
                            <asp:TextBox ID="txtTecnico" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-6">
                            <label>Descripcion</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" ReadOnly="true" TextMode="MultiLine" Height="50%"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-sm-3">
                            <label>Tipo de Compra</label>
                            <asp:TextBox ID="txtTipoCompra" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label>Monto Estimado</label>
                            <asp:TextBox ID="txtMontoEstimado" runat="server" ReadOnly="true" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label>Modalidad de Compra</label>
                            <asp:DropDownList ID="ddlModalidadCompra" ReadOnly="true" runat="server" CssClass="form-control dropdown-select" ></asp:DropDownList>

                        </div>
                        <div class="col-sm-3">
                            <label>Fecha Modificacion</label>
                            <asp:TextBox ID="txtModificacion" runat="server" ReadOnly="true" TextMode="Date" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">

        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <br />
            <div class="panel panel-default border">
                <div class="panel-heading alert-secondary" style="background-color: #18bc9c; color: #FFFFFF;">&nbsp;&nbsp;&nbsp; Ingreso de Datos</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-sm-3">
                            <label>Centro de Costo</label>
                            <asp:DropDownList ID="ddlCentroCosto" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        

                        <div class="col-sm-3">
                            <label>Acta Negociacion</label>
                            <asp:CheckBox ID="cbActaNegociacion" runat="server" CssClass=" form-check" Text="&nbsp;&nbsp;Si/No" />
                        </div>
                        <div class="col-sm-3">
                            <label>Fecha Trasaldo A Visa</label>
                            <asp:TextBox ID="txtFechaTrasladoVisa" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label>Fecha de Ampliacion</label>
                            <asp:TextBox ID="txtFechaAmpliacion" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-sm-3">
                            <label>Fecha de Retorno</label>
                            <asp:TextBox ID="txtFechaRetorno" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-sm-9">
                            <label>Notas</label>
                            <asp:TextBox ID="txtNotas" runat="server" CssClass="auto-style3" TextMode="MultiLine" Width="100%" Height="50%" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div>

        <asp:GridView ID="gvDetalle" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5"
            CellSpacing="1" Font-Size="Small" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="12" ShowFooter="True" Width="125%" CssClass="auto-style4" OnRowDataBound="gvDetalle_RowDataBound">
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
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
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
                        <asp:TextBox ID="txtFechaTrasladoOC" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Orden C.">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtFechaOrdenCompra" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Orden Compra">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtOrdenCompra" runat="server" CssClass="form-control"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Factura">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtFactura" runat="server" CssClass="form-control"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha Factura">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtFechaFactura" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    </ItemTemplate>
                    <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Fecha T. Almacen">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:TextBox ID="txtFechaTrasladoAlmacen" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
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
    </div>

    <div class="row">
        <div class="col-sm-6"></div>
        <div class="col-sm-2">
            <br />
            <asp:Button ID="btnCalcular" runat="server" Text="Calcular" CssClass="btn btn-success" Width="80%" />
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-4">
            <asp:Label ID="lblError" runat="server" Style="color:red" CssClass="form-check-label" Text="hola"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <asp:CheckBox ID="chkConstantes" runat="server" Text="&nbsp;&nbsp;Asignar todo el pedido con los siguiente datos:" AutoPostBack="True" />
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-3">
            <label>Proveedor</label>
            <asp:DropDownList ID="ddlProveedorT" runat="server" Width="100%" Enabled="false" class="dropdown-toggle dropdown_select">
                <%--<option value="">--Proveedor--</option>--%>
            </asp:DropDownList>
        </div>
        <div class="col-sm-2">
            <label>Fecha Orden Compra</label>
            <asp:TextBox ID="txtFechaOrdenCompraT" runat="server" Enabled="false" Width="100%" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="col-sm-1">
            <label>Orden Compra</label>
            <asp:TextBox ID="txtOrdenCompraT" runat="server" Width="100%" Enabled="false" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </div>
        <div class="col-sm-1">
            <label>Factura</label>
            <asp:TextBox ID="txtFacturaT" runat="server" Width="100%" Enabled="false" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </div>
        <div class="col-sm-2">
            <label>Fecha Factura</label>
            <asp:TextBox ID="txtFechaFacturaT" runat="server" Enabled="false" Width="100%" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
    </div>
    <div class="row">

        <div class="col-sm-3"></div>
        <div class="col-sm-2">
            <br />
            <asp:LinkButton ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" Width="100%" Height="60%" >
                Guardar&nbsp<span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span>
            </asp:LinkButton>
        </div>
        <div class="col-sm-2">
            <br />
            <asp:LinkButton ID="btnListado" runat="server" Text="Listado" CssClass="btn btn-info" Width="100%" Height="60%" >
               Listado&nbsp <span class="glyphicon glyphicon-list-alt" aria-hidden="true"></span>
            </asp:LinkButton>
        </div>
        <div class="col-sm-2">
            <br />
            <asp:LinkButton ID="btnRechazar" runat="server" Text="Rechazar" CssClass="btn btn-danger" Width="100%" Height="60%">
                Rechazar&nbsp <span class="glyphicon glyphicon-remove-sign" aria-hidden="true"></span>
            </asp:LinkButton>
        </div>

    </div>

    <br />
    <br />
    <br />


    <div class="modal open" id="myModal" hidden="hidden">
    </div>
</asp:Content>
