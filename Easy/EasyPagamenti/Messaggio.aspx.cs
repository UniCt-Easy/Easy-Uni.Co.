
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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


using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using metadatalibrary;
using metaeasylibrary;
using HelpWeb;

/// <summary>
/// Summary description for Messaggio.
/// </summary>
public partial class Messaggio :System.Web.UI.Page {

        protected void Page_Load(object sender, System.EventArgs e) {
            lblMessaggio.Text = Session["Messaggio"].ToString();
            if (Session["CloseWindow"] != null && ((bool)Session["CloseWindow"])) {
                ImageButton1.Attributes.Add("OnClick", "window.close();");
                ImageButton1.Text = "Chiudi";
            }

        }
        private void ImageButton1_Click(object sender, EventArgs e) {
            Response.Redirect("IndiceReport.aspx");
        }


        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e) {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.ImageButton1.Click += new EventHandler(ImageButton1_Click);

        }
        #endregion
    }

