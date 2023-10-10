<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Tarea1_WebAvanzada.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <address>
        Ing. Esteban Corrales Vargas<br />
        San José, Costa Rica<br />
        <abbr title="Teléfono">Teléfono:</abbr>
        8312-3795
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:esteban.corrales11@gmail.com">esteban.corrales11@gmail.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:esteban.corrales11@gmail.com">esteban.corrales11@gmail.com</a>
    </address>
</asp:Content>
