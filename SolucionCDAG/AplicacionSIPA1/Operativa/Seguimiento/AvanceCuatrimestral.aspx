<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AvanceCuatrimestral.aspx.cs" Inherits="AplicacionSIPA1.Operativa.Seguimiento.AvanceCuatrimestral" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            margin-right: 30px;
            margin-left: 13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <h2 style="text-align: center">Avance Cuatrimestral</h2>
    <div class="row">
        <div class="col-sm-1">
            <asp:Label ID="lblIdPoa" runat="server" Visible="false"></asp:Label>
        </div>
        <div class="col-sm-1">
            <label>Año</label>
            <asp:DropDownList ID="ddlAnios" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlAnios_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-sm-1">
            <label>Cuatrimestre</label>
            <asp:DropDownList ID="ddlCuatrimestre" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCuatrimestre_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-sm-4">
            <label>Unidad</label>
            <asp:DropDownList ID="ddlUnidades" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlUnidades_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-sm-4">
            <label>Dependencias</label>
            <asp:DropDownList ID="ddlDependencias" runat="server" CssClass="form-control"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-8">
            <label>Acciones</label>
            <asp:DropDownList ID="ddlAccion" runat="server" CssClass="form-control" BackColor="#003366" ForeColor="White" AutoPostBack="true"></asp:DropDownList>
        </div>
        <div class="col-sm-2">
            <br />
            <asp:Button ID="btnReporte" runat="server" Text="Reporte" CssClass="btn btn-info"  OnClick="btnReporte_Click"/>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-3">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </div>
    </div>
    <div class="row">
        
        <div class="col-sm-11">
            <asp:GridView ID="gvAvance" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="Solid" DataKeyNames="ID" BorderWidth="1px" CellPadding="5" CellSpacing="1" Font-Size="Small" ForeColor="Black" GridLines="Vertical" HorizontalAlign="Center" PageSize="12" ShowFooter="True" Width="94%" CssClass="auto-style3"
                OnSelectedIndexChanged="gvAvance_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="#CEEFFF" ForeColor="#333333" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="id_seguimiento_cmi" Visible="False">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Accion" HeaderText="Accion">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="avanceC1" HeaderText="Avance Correspondiente">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="avanceC2" HeaderText="Avance Correspondiente">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="descripcionM1" HeaderText="Avance Correspondiente">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Observaciones DGE">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtObservacionesM1" runat="server" Height="100px" MaxLength="1000" Text='<%# Bind("observacionesM1") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                            <asp:Label ID="lblErrorObservacionesM1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="descripcionM2" HeaderText="Avance Correspondiente">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Observaciones DGE">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtObservacionesM2" runat="server" Height="100px" MaxLength="1000" Text='<%# Bind("observacionesM2") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                            <asp:Label ID="lblErrorObservacionesM2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="descripcionM3" HeaderText="Avance Correspondiente">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Observaciones DGE">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtObservacionesM3" runat="server" Height="100px" MaxLength="1000" Text='<%# Bind("observacionesM3") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                            <asp:Label ID="lblErrorObservacionesM3" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="descripcionM4" HeaderText="Avance Correspondiente">
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="Observaciones DGE">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtObservacionesM4" runat="server" Height="100px" MaxLength="1000" Text='<%# Bind("observacionesM4") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                            <asp:Label ID="lblErrorObservacionesM4" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Resumen Avance Cuatrimestral">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtResumenAvance" runat="server" Height="100px" MaxLength="1000" Text='<%# Bind("avance") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                            <asp:Label ID="lblResumenAvance" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Porcentaje">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:TextBox ID="txtPorcentaje" runat="server" Height="100px" MaxLength="1000" Text='<%# Bind("porcentaje") %>' TextMode="MultiLine" Width="300px"></asp:TextBox>
                            <asp:Label ID="lblPorcentajeAvance" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Almacenar">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select" ImageUrl="~/img/24_bits/save.png" Text="Seleccionar" OnClientClick="javascript:if(!confirm('¿Desea almacenar esta información?'))return false" />
                        </ItemTemplate>
                        <HeaderStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle BorderStyle="Inset" HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#333333" ForeColor="White" HorizontalAlign="Center" />
                
            </asp:GridView>
        </div>
    </div>
</asp:Content>
