﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MensajeNomina.aspx.cs" Inherits="AplicacionSIPA1.MensajeNomina" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>Comite Olimpico Guatemalteco</title>
  

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
    
    
<link href="~/css/style.css" rel="stylesheet" type="text/css" media="screen" />
<link href="~/css/utilities.css" rel="stylesheet" type="text/css" media="screen" />
<link href="~/Content/bootstrap.css" rel="stylesheet" media="screen" />

<script src="../Scripts/jquery-1.7.1.min.js" type="text/javascript" ></script>
<script src="../Scripts/jquery.dropotron-1.0.js" type="text/javascript" ></script>
<script src="../Scripts/jquery.slidertron-1.1.js" type="text/javascript" ></script>
<script src="../Scripts/bootstrap.js" type="text/javascript" ></script>

    $(function () {
        $('#menu > ul').dropotron({
            mode: 'fade',
            globalOffsetY: 11,
            offsetY: -15
        });

        $('#slider').slidertron({
            viewerSelector: '.viewer',
            indicatorSelector: '.indicator span',
            reelSelector: '.reel',
            slidesSelector: '.slide',
            speed: 'slow',
            advanceDelay: 4000
        });
    });
</script>

   

    <style type="text/css">
        .auto-style1 {
            text-align: right;
        }
        .auto-style2
        {
            color: #FFFFFF;
        }
        .auto-style11 {
            font-size: xx-large;
            font-family: Arial;
            font-weight: normal;
        }
        .auto-style12 {
            color: #008000;
        }
        </style>
</head>
<body>
    <form class="form-horizontal" id ="form1" runat="server">
       
 
<nav class="navbar  navbar-default navbar-fixed-top" role="navigation">

<div class="container-header" >

<div class="navbar-collapse collapse navbar-responsive-collapse in" >


        <div id="DivContenedorMenu_EW" > 
            <asp:Menu ID="Menu1" runat="server" style="color: #FFFFFF" MaximumDynamicDisplayLevels="10" Orientation="Horizontal" Font-Bold="True" CssClass="menu_EW" >
                <DynamicSelectedStyle Font-Bold="False" />
            </asp:Menu>
        </div>


 </div>
        </div>


                <div style="text-align: right">
                    <span class="label label-success"> 
                         Usuario: 
                         <asp:Label ID="lblUsuario" runat="server" style="text-align: center;"></asp:Label>
                     </span>
                    &nbsp;
                     <span class="label label-default"> 
                          <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="INICIAR SESIÓN" LogoutText="CERRAR SESIÓN" Font-Bold="True" ForeColor="Black"  />
                     </span>
                    </div>
 
        </nav>

         <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True"></asp:ScriptManager>
         </div>    

         <br /><br /><br /><br /><br />


        <p class="auto-style11">
            <span class="auto-style12">Nomina No. </span>
            <asp:Label ID="lblIDNomina" runat="server" CssClass="auto-style12" ForeColor="#000099" Text="0"></asp:Label>
            <span class="auto-style12">&nbsp; del Año
            <asp:Label ID="lblAnio" runat="server" CssClass="auto-style12" ForeColor="#000099" Text="0"></asp:Label>
&nbsp;Generada con Exito</span></p>
        <p>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Overline="False" Font-Size="X-Large" Font-Underline="True" NavigateUrl="~/RRHH/Nomina.aspx">Crear Nueva Nomina</asp:HyperLink>
        </p>
        <p>
            <asp:LinkButton ID="LinkButton1" runat="server" Font-Size="X-Large" Font-Underline="True" ForeColor="#0066FF" PostBackUrl="~/RRHH/rptEmpleadoNomina.aspx" OnClick="LinkButton1_Click">Imprimir Nomina</asp:LinkButton>
        </p>
        <p>
            <asp:HyperLink ID="HyperLink3" runat="server" Font-Size="X-Large" Font-Underline="True" NavigateUrl="~/Inicio.aspx">Regresar a Inicio</asp:HyperLink>
        </p>


        </form>

</body>


</html>