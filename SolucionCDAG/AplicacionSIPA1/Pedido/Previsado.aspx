<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Previsado.aspx.cs" Inherits="AplicacionSIPA1.Pedido.Previsado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h3 style="text-align: center">PreVisado</h3>
    <div class="row">
        <div class="col-sm-10">
            <asp:Label ID="lblPlanE" runat="server" Text="*" Visible="false"></asp:Label>
            <asp:Label ID="lblErrorPlan" runat="server" ForeColor="Red" Style="font-size: medium" Visible="False">*</asp:Label>
            <asp:DropDownList ID="ddlPlanes" runat="server" AutoPostBack="True" Width="50%" Visible="False">
            </asp:DropDownList>
            <asp:Label ID="lblIdPoa" runat="server" Style="font-size: medium" ForeColor="White">0</asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1">
            <asp:DropDownList ID="ddlAcciones" OnSelectedIndexChanged="ddlAcciones_SelectedIndexChanged" runat="server" AutoPostBack="True" BackColor="#003366" class="" ForeColor="White" Visible="False" Width="50%">
            </asp:DropDownList>
            <asp:Label ID="lblErrorPoa" runat="server" ForeColor="Red" Style="font-size: medium"></asp:Label>
        </div>
        <div class="col-sm-1">
            <label>Año</label>
            <asp:DropDownList ID="ddlAnios" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" class="form-control" Width="100%">
            </asp:DropDownList>
        </div>
        <div class="col-sm-3">
            <label>Unidades</label>
            <asp:DropDownList ID="ddlUnidades" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" Width="100%">
            </asp:DropDownList>
        </div>
        <div class="col-sm-3">
            <label>Dependecias</label>
            <asp:DropDownList ID="ddlDependencias" runat="server" AutoPostBack="True" class="form-control" OnSelectedIndexChanged="ddlDependencia_SelectedIndexChanged" Width="100%">
            </asp:DropDownList>
        </div>
        <div class="col-sm-1">
            <label>No. Documento</label>
            <asp:TextBox ID="txtNo" runat="server" BackColor="#FFFF99" class="form-control" Font-Bold="True" Font-Size="Large" MaxLength="5" Style="text-align: right" Width="91%"></asp:TextBox>
        </div>
        <div class="col-sm-1">
            <br />
            <asp:LinkButton ID="btnBusqueda" Width="85%" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-info" Height="60%">
                 Buscar&nbsp <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
            </asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-3">
            <label>Tipos de Documento</label>
            <asp:RadioButtonList ID="rblTipoDocto" runat="server" AutoPostBack="True" RepeatDirection="Horizontal" OnSelectedIndexChanged="btnBuscar_Click" Width="95%">
                <asp:ListItem Selected="True" Value="0">TODOS</asp:ListItem>
                <asp:ListItem Value="1">Requisiciones</asp:ListItem>
                <asp:ListItem Value="2">Vales</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1">
           
            <asp:Label ID="lblIdTipoDocto" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White">0</asp:Label>
        </div>
        <div class="col-sm-10">
            <label>Estados de Requisiciones/Vales:</label>
            <asp:RadioButtonList ID="rblEstadosPedido" runat="server" AutoPostBack="True" Font-Size="XX-Small" RepeatColumns="8" RepeatDirection="Horizontal" OnSelectedIndexChanged="rblEstadosPedido_SelectedIndexChanged" Width="100%">
            </asp:RadioButtonList>
        </div>
    </div>
    <div class="row">
        <div class=" col-sm-1"></div>
        <div class="col-sm-5">
             <asp:Label ID="lblInformacionEstadoPedido" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <asp:DetailsView ID="dvPedido" runat="server" AllowPaging="True" AutoGenerateRows="False" OnPageIndexChanging="dvPedido_PageIndexChanging" DataKeyNames="ID" Width="100%"
                CssClass="table table-hover ">
                <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                <Fields>
                    <asp:BoundField DataField="ID" HeaderText="Id" Visible="false">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BackColor="#99FF99" BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="no_anio_solicitud" HeaderText="No. Solicitud">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BackColor="#99FF99" BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fecha_pedido" DataFormatString="{0:d}" HeaderText="Fecha Pedido">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="tipo_documento" HeaderText="Requisición/Vale">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BackColor="#99FF99" BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="estado_pedido" HeaderText="Estado de la Req./Vale">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BackColor="#99FF99" BorderStyle="Inset" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="accion" HeaderText="Acción">
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
            <label>*El sistema sólo tiene cargadas las especificaciones técnicas.</label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <asp:GridView ID="gridDetalle" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="12" ShowFooter="True" Width="100%" Font-Size="Small"
                CssClass="table table-hover ">
                <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                <Columns>
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/accept.png" ShowSelectButton="True" Visible="False">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:TemplateField ShowHeader="False" Visible="False">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete" ImageUrl="~/img/24_bits/delete.png" OnClientClick="javascript:if(!confirm('¿Desea Eliminar Este Registro?'))return false" Text="Eliminar" />
                        </ItemTemplate>
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" HeaderText="ID" Visible="False">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="descripcion" HeaderText="DESCRIPCIÓN DEL BIEN Y/O SERVICIO">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="unidad_medida" HeaderText="UNIDAD MEDIDA">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="CANTIDAD">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("cantidad") %>' Font-Bold="True"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="text-right">
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("cantidad") %>' Font-Bold="True"></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="VALOR ESTIMADO INDIVIDUAL SIN IVA">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("costo_estimado") %>' Font-Bold="True"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="text-right">
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("costo_estimado", "Q.{0:0,0.00}") %>' Font-Bold="True"></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SUBTOTAL">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("subtotal") %>' Font-Bold="True"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="text-right">
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("subtotal", "Q.{0:0,0.00}") %>' Font-Bold="True"></asp:Label>
                            </div>
                        </ItemTemplate>
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TOTAL MULTIANUAL">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("total_pedido_multianual") %>' Font-Bold="True"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <div class="text-right">
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("total_pedido_multianual", "Q.{0:0,0.00}") %>' Font-Bold="True"></asp:Label>
                            </div>
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
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <label>Observaciones</label>
            <asp:TextBox ID="txtObser" runat="server" BackColor="#FFFF99" class="form-control" Enabled="true" Height="75px" MaxLength="750" placeholder="Ingrese las observaciones del pedido en caso de rechazo" TextMode="MultiLine" Width="100%"></asp:TextBox>
            <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            <asp:Label ID="lblSuccess" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Green"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-3">
            <label>No. PreOrden</label>
            <asp:TextBox ID="txtPreorden" runat="server" BackColor="#FFFF99" class="form-control" Enabled="true"  placeholder="Ingrese el numero de PreOrden" TextMode="Number" Width="100%"></asp:TextBox>
            
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-2">
             <br />
            <asp:LinkButton ID="btnAprobar" runat="server" Text="Guardar" OnClick="btnAprobar_Click"  CssClass="btn btn-success" Width="100%" Height="60%">
                Guardar&nbsp<span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span>
            </asp:LinkButton>
        </div>
        <div class="col-sm-2">
            <br />
            <asp:LinkButton ID="btnRechazar" runat="server" Text="Rechazar" OnClick="btnRechazar_Click" CssClass="btn btn-danger" Width="100%" Height="60%">
                Rechazar&nbsp <span class="glyphicon glyphicon-remove-sign" aria-hidden="true"></span>
            </asp:LinkButton>
        </div>
    </div>
</asp:Content>
