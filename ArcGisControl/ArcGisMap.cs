using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Text;

namespace ArcGisControl
{
    /// <summary>
    /// Summary description for ArcGisMap
    /// </summary>
    public class ArcGisMap : WebControl, IScriptControl
    {
        private int _Zoom = 8;
        public int Zoom
        {
            get { return this._Zoom; }
            set { this._Zoom = value; }
        }

        public double CenterLatitude { get; set; }
        public double CenterLongitude { get; set; }
        private string _onClick;
        public string onClick
        {
            get { return this._onClick; }
            set { this._onClick = value; }
        }

        private string _geoRSS = "";
        public string geoRSS
        {
            get{return _geoRSS;}
            set { this._geoRSS = value; }
        }
        
        private ScriptManager sm;

        private string cssClass = "http://js.arcgis.com/3.7/js/esri/css/esri.css";

        public override string CssClass
        {
            set
            {
                cssClass = value;
            }
        }

        public ArcGisMap()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor("ArcGisControl.ArcGisMap", this.ClientID);
            
            descriptor.AddProperty("zoom", this.Zoom);
            descriptor.AddProperty("centerLatitude", this.CenterLatitude);
            descriptor.AddProperty("centerLongitude", this.CenterLongitude);
            descriptor.AddProperty("clientid", this.ClientID);
            descriptor.AddProperty("geoRSS", this._geoRSS);
            descriptor.AddProperty("onClick", this.onClick);
            yield return descriptor;
        }


        // Generate the script reference
        public IEnumerable<ScriptReference>
                GetScriptReferences()
        {
            yield return new ScriptReference("ArcGisControl.ArcGisMap.js", this.GetType().Assembly.FullName);
        }

        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Div;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                // Test for ScriptManager and register if it exists
                sm = ScriptManager.GetCurrent(Page);

                if (sm == null)
                    throw new HttpException("A ScriptManager control must exist on the current page.");

                sm.RegisterScriptControl(this);
                
            }
            Page.ClientScript.RegisterClientScriptInclude(Page.ClientScript.GetType(), "esri", "http://js.arcgis.com/3.7/");
            //Page.ClientScript.RegisterClientScriptInclude(Page.ClientScript.GetType(), "css", cssClass);

            string cssUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "ArcGisControl.esri.css");
            HtmlLink cssLink = new HtmlLink();
            cssLink.Href = cssUrl;
            cssLink.Attributes.Add("rel", "stylesheet");
            cssLink.Attributes.Add("type", "text/css");
            this.Page.Header.Controls.Add(cssLink);
            /*StringBuilder sb = new StringBuilder();

            sb.Append(@"<link rel=""stylesheet"" type=""text/css"" href=""");
            sb.Append(cssClass);
            sb.Append(@""" />");

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "MyCSS", sb.ToString());*/
            //InitialiseControls();
            base.OnPreRender(e);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
                sm.RegisterScriptDescriptors(this);

            
            base.Render(writer);
            //writer.Write("<div id='mapDiv'></div>");
        }

        private void InitialiseControls() { 
            /*Image cartImage = new Image(); 
            cartImage.ID = "cartImage"; 
            cartImage.Attributes["class"] = "cartImage"; 
            cartImage.ToolTip = "Shopping Cart"; 
            cartImage.ImageUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "AjaxControl.Images.cart.png"); 
            this.Controls.Add(cartImage);
            */
            Label lbl = new Label();
            lbl.ID = "bob";
            lbl.Text = "frank";
            this.Controls.Add(lbl);
            
            
        }


    }
}