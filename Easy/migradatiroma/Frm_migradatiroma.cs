
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


using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using SituazioneViewer;//SituazioneViewer
using funzioni_configurazione;
using System.Xml;

namespace migradatiroma//istitutocassiere_situazione//
{
	/// <summary>
	/// Summary description for frmistitutocassiere_situazione.
	/// </summary>
	public class Frm_migradatiroma : System.Windows.Forms.Form
	{
		public vistaForm DS;
		private System.Windows.Forms.Button btnMigraDati;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList images;
		public MetaData Meta;

		public Frm_migradatiroma()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.btnMigraDati = new System.Windows.Forms.Button();
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.DS = new migradatiroma.vistaForm();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// btnMigraDati
			// 
			this.btnMigraDati.Location = new System.Drawing.Point(103, 25);
			this.btnMigraDati.Name = "btnMigraDati";
			this.btnMigraDati.Size = new System.Drawing.Size(193, 56);
			this.btnMigraDati.TabIndex = 0;
			this.btnMigraDati.Text = "Migra Mandati";
			// 
			// images
			// 
			this.images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.images.ImageSize = new System.Drawing.Size(16, 16);
			this.images.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// Frm_migradatiroma
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 135);
			this.Controls.Add(this.btnMigraDati);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "Frm_migradatiroma";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		public void MetaData_AfterLink() 
		{
				
			
		}


		public void MetaData_AfterFill(){
		}

		public void MetaData_AfterClear(){
		}


		private void btnImportaMandati_Click(object sender, System.EventArgs e) {
            
            XmlDocument doc = new XmlDocument(); 
            try {
                doc.LoadXml(DS.MandatiXML.Rows[0]["XMLColumn"].ToString());
            }
            catch {
                return;
            }




		}

        
       


			static string getXmlText(XmlNode x, string xpath)
			{
			try
			{
				XmlNode n = x.SelectSingleNode(xpath);
				if (n != null)
				{
					return n.InnerText;
				}
			}
			catch (Exception e)
			{
				string errore = e.Message + " " + e.ToString();
			}
			return null;
			}


}
}
