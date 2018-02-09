<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptEmpleadoNomina.aspx.cs" Inherits="AplicacionSIPA1.RRHH.rptEmpleadoNomina" MasterPageFile="~/Principal.Master" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder3">
    <div id="Content" style="width:100%; height:100%; overflow:auto;"> 
            <iframe id="frame" runat="server" style="width:100%; height:600px; overflow:auto;"></iframe>
        </div>
</asp:Content>


