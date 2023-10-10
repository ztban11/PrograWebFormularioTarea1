<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarPropuesta.aspx.cs" Inherits="Tarea1_WebAvanzada.AgregarPropuesta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="jumbotron">
        <h1>Registro propuestas legislativas</h1>

            <asp:Label ID="lbl_identificacion" runat="server" Text="Identificación *"></asp:Label><br>
            <asp:TextBox ID="txt_Identificacion" runat="server" CssClass="form-control" placeholder="#-####-####"></asp:TextBox><br>
            <!-- Campo identificación es requerido-->
            <asp:RequiredFieldValidator ID="RFVIdentificacion" runat="server" ControlToValidate="txt_Identificacion" Display="Dynamic" ErrorMessage="* Campo Obligatorio" ValidationGroup="a" ForeColor="Red"></asp:RequiredFieldValidator>

            <!-- Máscara para campo identificación-->
            <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.10/jquery.mask.js"></script>
            <script type="text/javascript">
                $(document).ready(function () {
                    $("#<%= txt_Identificacion.ClientID %>").mask("9-9999-9999");
            });
        </script>

            <asp:Label ID="lbl_nombre" runat="server" Text="Nombre *"></asp:Label><br>
            <asp:TextBox ID="txt_nombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox><br>
            <!-- Campo nombre es requerido-->
            <asp:RequiredFieldValidator ID="RFVNombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" ErrorMessage="* Campo Obligatorio" ValidationGroup="a" ForeColor="Red"></asp:RequiredFieldValidator>

            <asp:Label ID="lbl_apellidos" runat="server" Text="Apellidos *"></asp:Label><br>
            <asp:TextBox ID="txt_apellidos" runat="server" CssClass="form-control" placeholder="Apellidos"></asp:TextBox><br>
            <!-- Campo apellidos es requerido-->
            <asp:RequiredFieldValidator ID="RFVApellidos" runat="server" ControlToValidate="txt_apellidos" Display="Dynamic" ErrorMessage="* Campo Obligatorio" ValidationGroup="a" ForeColor="Red"></asp:RequiredFieldValidator>

            <asp:Label ID="lbl_telefono" runat="server" Text="Teléfono *"></asp:Label><br>
            <asp:TextBox ID="txt_tel" runat="server" CssClass="form-control" placeholder="####-####"></asp:TextBox><br>
            <!-- Campo telefono es requerido-->
            <asp:RequiredFieldValidator ID="RFVTelefono" runat="server" ControlToValidate="txt_tel" Display="Dynamic" ErrorMessage="* Campo Obligatorio" ValidationGroup="a" ForeColor="Red"></asp:RequiredFieldValidator>

            <!-- Máscara para campo teléfono-->
            <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.10/jquery.mask.js"></script>
            <script type="text/javascript">
                $(document).ready(function () {
                    $("#<%= txt_tel.ClientID %>").mask("9999-9999");
                });
            </script>

            <asp:Label ID="lbl_email" runat="server" Text="Correo Electrónico *"></asp:Label><br>
            <asp:TextBox ID="txt_email" runat="server" TextMode="Email" CssClass="form-control" placeholder="correo@electrónico"></asp:TextBox><br>
            <!-- Campo email es requerido-->
            <asp:RequiredFieldValidator ID="RFVEmail" runat="server" ControlToValidate="txt_email" Display="Dynamic" ErrorMessage="* Campo Obligatorio" ValidationGroup="a" ForeColor="Red"></asp:RequiredFieldValidator>

 
            <asp:Label ID="lbl_provincia" runat="server" Text="Provincia *"></asp:Label><br>
            <asp:ListBox ID="list_provincias" runat="server" Rows="7" SelectionMode="Single" CssClass="form-control" OnSelectedIndexChanged="list_provincias_SelectedIndexChanged" TabIndex="0" OnLoad="list_provincias_Load" OnTextChanged="list_provincias_TextChanged">
                
                <asp:ListItem>San José</asp:ListItem>
                <asp:ListItem>Alajuela</asp:ListItem>
                <asp:ListItem>Cartago</asp:ListItem>
                <asp:ListItem>Heredia</asp:ListItem>
                <asp:ListItem>Guanacaste</asp:ListItem>
                <asp:ListItem>Puntarenas</asp:ListItem>
                <asp:ListItem>Limón</asp:ListItem>

            </asp:ListBox><br>

            <!-- Campo provincia es requerido-->
            <asp:RequiredFieldValidator ID="RFVProvincia" runat="server" ControlToValidate="list_provincias" Display="Dynamic" ErrorMessage="* Campo Obligatorio" ValidationGroup="CreateGroupValidationGroup" ForeColor="Red" CssClass="has-error"></asp:RequiredFieldValidator>
                
            <asp:Label ID="lbl_canton" runat="server" Text="Canton *"></asp:Label><br>
            <asp:ListBox ID="list_canton" runat="server" AutoPostBack="true"></asp:ListBox><br>

            <!-- Campo cantón es requerido-->
            <asp:RequiredFieldValidator ID="RFVCanton" runat="server" ControlToValidate="list_canton" Display="Dynamic" ErrorMessage="* Campo Obligatorio" ValidationGroup="CreateGroupValidationGroup" ForeColor="Red" CssClass="has-error"></asp:RequiredFieldValidator>

            <asp:Label ID="lbl_propuesta" runat="server" Text="Propuesta"></asp:Label><br>
            <asp:TextBox ID="txt_propuesta" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox><br><br>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click"></asp:Button>
            <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-danger" OnClick="btnLimpiar_Click"></asp:Button><br>
    </div>


</asp:Content>
