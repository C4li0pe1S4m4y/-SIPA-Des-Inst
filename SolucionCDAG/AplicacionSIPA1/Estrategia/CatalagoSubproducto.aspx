<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="CatalagoSubproducto.aspx.cs" Inherits="AplicacionSIPA1.Estrategia.CatalagoSubproducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2 style="text-align: center">Catalgo de Producto/Subproducto</h2>
    <div class="row">
        <div class="col-sm-1">
            <asp:Label ID="lblIdProducto" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="col-sm-10">
            <div class="panel panel-default border">
                <div class="panel-heading alert-secondary" style="background-color: #18bc9c; color: #FFFFFF;">&nbsp;&nbsp;&nbsp;Producto</div>
                <div class="panle-body">
                    <div class="row">
                        <div class="col-sm-5">
                            <label>Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <label>Resultado</label>
                            <asp:TextBox ID="txtResultado" runat="server" CssClass="form-control">012</asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <label>Codigo</label>
                            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" ></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <br />
                            <asp:LinkButton ID="btnBusqueda" Width="120%" runat="server" Text="Buscar" OnClick="btnBusqueda_Click" CssClass="btn btn-info" Height="60%">
                                Buscar&nbsp <span class="glyphicon glyphicon-search" aria-hidden="true"></span>
                            </asp:LinkButton>
                        </div>
                        <div class="col-sm-1">
                            <br />
                            <asp:LinkButton ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" Width="120%" Height="60%">
                                Guardar&nbsp<span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span>
                            </asp:LinkButton>
                        </div>
                        <div class="col-sm-1">
                            <br />
                            <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" Width="120%" Height="60%">
                                Eliminar&nbsp<span class="glyphicon glyphicon-remove-sign" aria-hidden="true"></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                    <div class="row">
                        <br />
                        <div class="col-1"></div>
                        <div class="col-sm-8">
                           
                            <asp:Label ID="lblResultado" runat="server" Style="color: white;font-size:medium"></asp:Label>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1">
            <asp:Label ID="lblSubproducto" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="col-sm-10">
            <br />
            <div class="panel panel-default border">
                <div class="panel-heading alert-secondary" style="background-color: #18bc9c; color: #FFFFFF;">&nbsp;&nbsp;&nbsp;SubProducto</div>
                <div class="panle-body">
                    <div class="row">
                        <div class="col-sm-5">
                            <label>Producto</label>
                            <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="col-sm-3">
                            <label>Unidad</label>
                            <asp:DropDownList ID="ddlUnidades" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                        </div>
                        <div class="col-sm-4">
                            <label>Subproducto</label>
                            <asp:TextBox ID="txtSubproducto" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-sm-1">
                            <label>Codigo</label>
                            <asp:TextBox ID="txtCodigoSub" runat="server" CssClass="form-control"  Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-sm-2">
                            <label>Monto</label>
                            <asp:TextBox ID="txtMonto" runat="server" CssClass="form-control" Width="100%"></asp:TextBox>
                        </div>
                        <div class="col-5"></div>
                        <div class="col-sm-1">
                            <br />
                            <asp:LinkButton ID="btnGuardarSub" runat="server" Text="Guardar" OnClick="btnGuardarSub_Click" CssClass="btn btn-success" Width="120%" Height="60%">
                                Guardar&nbsp<span class="glyphicon glyphicon-ok-sign" aria-hidden="true"></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                     <div class="row">
                        <br />
                        <div class="col-1"></div>
                        <div class="col-sm-8">
                           
                            <asp:Label ID="lblResultadoSub" runat="server" Style="color: white;font-size:medium"></asp:Label>
                        </div>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-2"></div>
        <div class="col-sm-10">
            <br />
            <asp:GridView ID="gvListado" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" OnPageIndexChanging="gvListado_PageIndexChanging" OnSelectedIndexChanged="gvListado_SelectedIndexChanged" OnRowDeleting="gvListado_RowDeleting"
                BorderWidth="1px" CellPadding="5" CellSpacing="1" DataKeyNames="ID"   AllowPaging="True" ForeColor="Black" GridLines="Vertical" PageSize="10" ShowFooter="false" Width="50%" CssClass="table table-hover ">
                <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                <Columns>
                    <asp:CommandField ButtonType="Image" SelectImageUrl="~/img/24_bits/edit.png" ShowSelectButton="True">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:CommandField>
                    <asp:TemplateField ShowHeader="False">
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
                    <asp:BoundField DataField="Producto" HeaderText="Producto" Visible="True">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codigo" HeaderText="Codigo" Visible="True">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Subproducto" HeaderText="SubProducto" Visible="True">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
                
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>
