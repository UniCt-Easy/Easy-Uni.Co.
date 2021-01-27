
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


using ComponentSpace.SAML2;
using ComponentSpace.SAML2.Configuration;
using ComponentSpace.SAML2.Metadata;
using System;
using System.Text;
using System.Web.Configuration;
using System.Web.UI;
using System.Xml;

public partial class saml_Metadata : Page {

    private string CreateAbsoluteURL(string relativeURL) {
        var baseUri = new Uri(SAMLController.Configuration.LocalServiceProviderConfiguration.Name);
        return new Uri(baseUri, ResolveUrl(relativeURL)).ToString();
    }

    protected void Page_Load(object sender, EventArgs e) {
        Response.Clear();

        try {
            SAMLController.Initialize();

            string partnerIdP = WebConfigurationManager.AppSettings.Get("partnerIdP");

            EntityDescriptor entityDescriptor = MetadataExporter.Export(SAMLController.Configuration, partnerIdP);

            string assertionConsumerServiceUrl = CreateAbsoluteURL("~/saml/consumer.aspx");
            string singleLogoutServiceUrl = CreateAbsoluteURL("~/saml/logout.aspx");

            entityDescriptor.SPSSODescriptors[0].AssertionConsumerServices.Clear();
            entityDescriptor.SPSSODescriptors[0].AssertionConsumerServices.Add(new IndexedEndpointType(SAMLIdentifiers.BindingURIs.HTTPPost, assertionConsumerServiceUrl, null, 0, true));

            entityDescriptor.SPSSODescriptors[0].SingleLogoutServices.Clear();
            entityDescriptor.SPSSODescriptors[0].SingleLogoutServices.Add(new EndpointType(SAMLIdentifiers.BindingURIs.HTTPRedirect, singleLogoutServiceUrl, null));
            entityDescriptor.SPSSODescriptors[0].SingleLogoutServices.Add(new EndpointType(SAMLIdentifiers.BindingURIs.HTTPPost, singleLogoutServiceUrl, null));

            XmlElement metadataElement = entityDescriptor.ToXml();

            Response.ContentType = "text/xml";
            Response.AddHeader("Content-Disposition", "attachment; filename=\"metadata.xml\"");

            using (XmlTextWriter xmlTextWriter = new XmlTextWriter(Response.OutputStream, Encoding.UTF8)) {
                xmlTextWriter.Formatting = Formatting.Indented;
                metadataElement.OwnerDocument.Save(xmlTextWriter);
            }
        }
        catch (Exception ex) {
            Response.ContentType = "text/html";

            Response.Write("<p>Si è verificato un errore nel tentativo di estrazione dei metadati dal service provider.</p>");
            Response.Write("<p>" + ex.Message + "</p>");
            Response.Write("<blockquote>" + ex.StackTrace + "</blockquote>");
        }
        finally {
            Response.End();
        }
    }

}
