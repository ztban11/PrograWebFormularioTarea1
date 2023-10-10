using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;
using System.Configuration;

using System.Data;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Xml.Linq;
using System.IO;

//using Microsoft.AspNetCore.Mvc;

namespace Tarea1_WebAvanzada
{
    public partial class AgregarPropuesta : System.Web.UI.Page
    {
        public bool hayDatos = false;
        public string identificacion = "";
        public string nombre = "";
        public string apellidos = "";
        public string telefono = "";
        public string correo = "";
        public string provincia = "";
        public string canton = "";
        public string propuesta = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                txt_propuesta.Attributes.Add("minlength", "50");
                txt_propuesta.Attributes.Add("maxlength", "200");
                
                ArrayList arrListInicial = new ArrayList();

                arrListInicial.Add("San José");
                arrListInicial.Add("Escazú");
                arrListInicial.Add("Desamparados");
                arrListInicial.Add("Puriscal");
                arrListInicial.Add("Tarrazú");
                arrListInicial.Add("Aserrí");
                arrListInicial.Add("Mora");
                arrListInicial.Add("Goicoechea");
                arrListInicial.Add("Santa Ana");
                arrListInicial.Add("Alajuelita");
                arrListInicial.Add("Coronado");
                arrListInicial.Add("Acosta");
                arrListInicial.Add("Tibas");
                arrListInicial.Add("Moravia");
                arrListInicial.Add("Montes de Oca");
                arrListInicial.Add("Turrubares");
                arrListInicial.Add("Dota");
                arrListInicial.Add("Curridabat");
                arrListInicial.Add("Perez Zeledón");
                arrListInicial.Add("León Cortés");

                list_canton.DataSource = arrListInicial;
                list_canton.DataBind();


                
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if ((this.txt_Identificacion.Text == "" || this.txt_nombre.Text == "" || this.txt_apellidos.Text == "" || this.txt_propuesta.Text == "") )
            {
                string message = "No pueden haber campos vacíos";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
            }
            else {
                identificacion = Convert.ToString(txt_Identificacion.Text);
                nombre = Convert.ToString(txt_nombre.Text);
                apellidos = Convert.ToString(txt_apellidos.Text);
                telefono = Convert.ToString(txt_tel.Text);
                correo = Convert.ToString(txt_email.Text);
                provincia = Convert.ToString(list_provincias.Text);
                canton = Convert.ToString(list_canton.Text);
                propuesta = Convert.ToString(txt_propuesta.Text);

                agregarArchivoXml();

                Response.Redirect("RegistroExitoso.aspx");
            }
        }

        public void agregarArchivoXml()
        {
            
            if(!File.Exists("c:/temp/propuestas.xml"))
            { 
                //Inicialización de componente 'writer'
                XmlTextWriter writer = new XmlTextWriter("c:/temp/propuestas.xml",System.Text.Encoding.UTF8);


            //Inicialización de documento XML
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;

            //Elemento raíz
            writer.WriteStartElement("Propuesta");

            //Llamado al método de creación del nodo
            crearNodo(identificacion,nombre, apellidos, telefono, correo, provincia, canton, propuesta, writer);
            writer.WriteEndElement();

            //Finalización de documento XML
            writer.WriteEndDocument();

            //Close writer
            writer.Flush();
            writer.Close();

            }
            else
            {
                XDocument xDocument = XDocument.Load("c:/temp/propuestas.xml");
                XElement root = xDocument.Element("Propuesta");
                IEnumerable<XElement> filas = root.Descendants("NuevaPropuesta");
                XElement primeraFila = filas.First();
                primeraFila.AddBeforeSelf(new XElement("NuevaPropuesta", new XElement("Identificación", identificacion), new XElement("Nombre", nombre), new XElement("Apellidos", apellidos), new XElement("Teléfono", telefono), new XElement("Correo", correo), new XElement("Provincia", provincia), new XElement("Canton", canton), new XElement("Propuesta", propuesta)));
                xDocument.Save("c:/temp/propuestas.xml");
            }

        }

        private void crearNodo(string sIdentificacion, string sNombre, string sApellido, string sTelefono, string sCorreo, string sProvincia, string sCanton, string sPropuesta, XmlTextWriter writer)
        {
            //Inicialización de nodo padre
            writer.WriteStartElement("NuevaPropuesta");

            //Identificacion
            writer.WriteStartElement("Identificación");
            writer.WriteString(sIdentificacion);
            writer.WriteEndElement();

            //Nombre
            writer.WriteStartElement("Nombre");
            writer.WriteString(sNombre);
            writer.WriteEndElement();

            //Apellidos
            writer.WriteStartElement("Apellidos");
            writer.WriteString(sApellido);
            writer.WriteEndElement();

            //Telefono
            writer.WriteStartElement("Teléfono");
            writer.WriteString(sTelefono);
            writer.WriteEndElement();

            //Correo
            writer.WriteStartElement("Correo");
            writer.WriteString(sCorreo);
            writer.WriteEndElement();

            //Provincia
            writer.WriteStartElement("Provincia");
            writer.WriteString(sProvincia);
            writer.WriteEndElement();

            //Canton
            writer.WriteStartElement("Canton");
            writer.WriteString(sCanton);
            writer.WriteEndElement();

            //Propuesta
            writer.WriteStartElement("Propuesta");
            writer.WriteString(sPropuesta);
            writer.WriteEndElement();

        }

        protected void list_provincias_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void list_provincias_Load(object sender, EventArgs e)
        {
            ArrayList arrList = new ArrayList();

            if (this.list_provincias.SelectedIndex == 1)
            {

                arrList.Add("Alajuela");
                arrList.Add("San Ramón");
                arrList.Add("Grecia");
                arrList.Add("San Mateo");
                arrList.Add("Atenas");
                arrList.Add("Naranjo");
                arrList.Add("Palmares");
                arrList.Add("Poas");
                arrList.Add("Orotina");
                arrList.Add("San Carlos");
                arrList.Add("Alfaro Ruiz");
                arrList.Add("Valverde Vega");
                arrList.Add("Upala");
                arrList.Add("Los Chiles");
                arrList.Add("Guatuso");

                list_canton.DataSource = arrList;
                list_canton.DataBind();
            }
        }

        protected void list_provincias_TextChanged(object sender, EventArgs e)
        {

            ArrayList arrList = new ArrayList();

            if (this.list_provincias.SelectedIndex == 1)
            {

                arrList.Add("Alajuela");
                arrList.Add("San Ramón");
                arrList.Add("Grecia");
                arrList.Add("San Mateo");
                arrList.Add("Atenas");
                arrList.Add("Naranjo");
                arrList.Add("Palmares");
                arrList.Add("Poas");
                arrList.Add("Orotina");
                arrList.Add("San Carlos");
                arrList.Add("Alfaro Ruiz");
                arrList.Add("Valverde Vega");
                arrList.Add("Upala");
                arrList.Add("Los Chiles");
                arrList.Add("Guatuso");

                list_canton.DataSource = arrList;
                list_canton.DataBind();
            } 
            else if (this.list_provincias.SelectedIndex == 2)
            {

                arrList.Add("Cartago");
                arrList.Add("Paraíso");
                arrList.Add("La Unión");
                arrList.Add("Jiménez");
                arrList.Add("Turrialba");
                arrList.Add("Alvarado");
                arrList.Add("Oreamuno");
                arrList.Add("El Guarco");

                list_canton.DataSource = arrList;
                list_canton.DataBind();
            }
            else if (this.list_provincias.SelectedIndex == 3)
            {

                arrList.Add("Heredia");
                arrList.Add("Barva");
                arrList.Add("Santo Domingo");
                arrList.Add("Santa Bárbara");
                arrList.Add("San Rafael");
                arrList.Add("San Isidro");
                arrList.Add("Belén");
                arrList.Add("Flores");
                arrList.Add("San Pablo");
                arrList.Add("Sarapiquí");

                list_canton.DataSource = arrList;
                list_canton.DataBind();
            }
            else if (this.list_provincias.SelectedIndex == 4)
            {

                arrList.Add("Liberia");
                arrList.Add("Nicoya");
                arrList.Add("Santa Cruz");
                arrList.Add("Bagaces");
                arrList.Add("Carrillo");
                arrList.Add("Cañas");
                arrList.Add("Abangares");
                arrList.Add("Tilarán");
                arrList.Add("Nandayure");
                arrList.Add("La Cruz");
                arrList.Add("Hojancha");

                list_canton.DataSource = arrList;
                list_canton.DataBind();
            }
            else if (this.list_provincias.SelectedIndex == 5)
            {

                arrList.Add("Puntarenas");
                arrList.Add("Esparza");
                arrList.Add("Buenos Aires");
                arrList.Add("Montes de Oro");
                arrList.Add("Osa");
                arrList.Add("Aguirre");
                arrList.Add("Golfito");
                arrList.Add("Coto Brus");
                arrList.Add("Parrita");
                arrList.Add("Corredores");
                arrList.Add("Garabito");

                list_canton.DataSource = arrList;
                list_canton.DataBind();
            }
            else if (this.list_provincias.SelectedIndex == 6)
            {

                arrList.Add("Limón");
                arrList.Add("Pococí");
                arrList.Add("Siquirres");
                arrList.Add("Talamanca");
                arrList.Add("Matina");
                arrList.Add("Guacimo");

                list_canton.DataSource = arrList;
                list_canton.DataBind();
            }
            else if (this.list_provincias.SelectedIndex == 0)
            {
                arrList.Add("San José");
                arrList.Add("Escazú");
                arrList.Add("Desamparados");
                arrList.Add("Puriscal");
                arrList.Add("Tarrazú");
                arrList.Add("Aserrí");
                arrList.Add("Mora");
                arrList.Add("Goicoechea");
                arrList.Add("Santa Ana");
                arrList.Add("Alajuelita");
                arrList.Add("Coronado");
                arrList.Add("Acosta");
                arrList.Add("Tibas");
                arrList.Add("Moravia");
                arrList.Add("Montes de Oca");
                arrList.Add("Turrubares");
                arrList.Add("Dota");
                arrList.Add("Curridabat");
                arrList.Add("Perez Zeledón");
                arrList.Add("León Cortés");
            }
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txt_Identificacion.Text = "";
            txt_nombre.Text = "";
            txt_apellidos.Text = "";
            txt_tel.Text = "";
            txt_email.Text = "";
            txt_propuesta.Text = "";
        }
    }
}