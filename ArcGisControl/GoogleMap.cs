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

namespace ArcGisControl
{
    /// <summary>
    /// Summary description for ArcGisMap
    /// </summary>
    public class GoogleMap : WebControl, IScriptControl
    {
        private int _Zoom = 8;
        public int Zoom
        {
            get { return this._Zoom; }
            set { this._Zoom = value; }
        }

        public double CenterLatitude { get; set; }
        public double CenterLongitude { get; set; }

        private string _geoRSS = "";
        public string geoRSS
        {
            get { return _geoRSS; }
            set { this._geoRSS = value; }
        }

        private ScriptManager sm;


        public GoogleMap()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor("ArcGisControl.GoogleMap", this.ClientID);

            descriptor.AddProperty("zoom", this.Zoom);
            descriptor.AddProperty("centerLatitude", this.CenterLatitude);
            descriptor.AddProperty("centerLongitude", this.CenterLongitude);
            descriptor.AddProperty("geoRSS", this._geoRSS);

            yield return descriptor;
        }


        // Generate the script reference
        public IEnumerable<ScriptReference>
                GetScriptReferences()
        {
            yield return new ScriptReference("ArcGisControl.GoogleMap.js", this.GetType().Assembly.FullName);
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
            Page.ClientScript.RegisterClientScriptInclude(Page.ClientScript.GetType(), "google", "http://maps.googleapis.com/maps/api/js?sensor=false");
            base.OnPreRender(e);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
                sm.RegisterScriptDescriptors(this);

            base.Render(writer);
        }



    }
}