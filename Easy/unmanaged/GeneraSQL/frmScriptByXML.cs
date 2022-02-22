
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using metadatalibrary;

namespace generaSQL//GeneraSQL//
{
	/// <summary>
	/// Summary description for frmScriptByXML.
	/// </summary>
	public class Frm_GeneraSQL : MetaDataForm
	{
		private System.Windows.Forms.Button btnGenera;
		private System.Windows.Forms.TextBox txtOutputFile;
		private System.Windows.Forms.TextBox txtXMLFile;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOpenFile;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_GeneraSQL()
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
			this.btnGenera = new System.Windows.Forms.Button();
			this.txtOutputFile = new System.Windows.Forms.TextBox();
			this.txtXMLFile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOpenFile = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnGenera
			// 
			this.btnGenera.Location = new System.Drawing.Point(160, 136);
			this.btnGenera.Name = "btnGenera";
			this.btnGenera.TabIndex = 23;
			this.btnGenera.Text = "Genera";
			this.btnGenera.Click += new System.EventHandler(this.btnGenera_Click);
			// 
			// txtOutputFile
			// 
			this.txtOutputFile.Location = new System.Drawing.Point(16, 104);
			this.txtOutputFile.Name = "txtOutputFile";
			this.txtOutputFile.Size = new System.Drawing.Size(352, 20);
			this.txtOutputFile.TabIndex = 22;
			this.txtOutputFile.Text = "";
			// 
			// txtXMLFile
			// 
			this.txtXMLFile.Location = new System.Drawing.Point(16, 40);
			this.txtXMLFile.Name = "txtXMLFile";
			this.txtXMLFile.Size = new System.Drawing.Size(328, 20);
			this.txtXMLFile.TabIndex = 19;
			this.txtXMLFile.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(328, 24);
			this.label2.TabIndex = 21;
			this.label2.Text = "Inserisci il nome del file che verrà generato";
			// 
			// btnOpenFile
			// 
			this.btnOpenFile.Location = new System.Drawing.Point(344, 40);
			this.btnOpenFile.Name = "btnOpenFile";
			this.btnOpenFile.Size = new System.Drawing.Size(24, 23);
			this.btnOpenFile.TabIndex = 20;
			this.btnOpenFile.Text = "...";
			this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(336, 24);
			this.label1.TabIndex = 18;
			this.label1.Text = "Seleziona il file XML delle definizioni delle tabelle";
			// 
			// frmScriptByXML
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(382, 181);
			this.Controls.Add(this.btnGenera);
			this.Controls.Add(this.txtOutputFile);
			this.Controls.Add(this.txtXMLFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnOpenFile);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "frmScriptByXML";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Generazione script SQL";
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOpenFile_Click(object sender, System.EventArgs e) {
			OpenFileDialog open = new OpenFileDialog();
			open.Title = "Seleziona il file xml che contiene le definizioni delle tabelle";
			open.Filter = "Xml files (*.xml)|*.xml";
			if (open.ShowDialog() == DialogResult.OK)
				txtXMLFile.Text = open.FileName;
		}

		private bool Validazioni() {
			if (txtXMLFile.Text.Trim() == "") {
				show("Selezionare il file XML delle definizioni", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (txtOutputFile.Text.Trim() == "") {
				show("Inserire il nome del file che verrà generato", "Attenzione",
					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return false;
			}
			if (File.Exists(txtOutputFile.Text.Trim())) {
				DialogResult res = show("Il file esiste, sovrascriverlo?", "Attenzione",
					MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				if (res != DialogResult.Yes) return false;
			}
			return true;
		}

		private void btnGenera_Click(object sender, System.EventArgs e) {
			if (!Validazioni()) return;
			Cursor.Current = Cursors.WaitCursor;
			MetaData meta = MetaData.GetMetaData(this);
			GeneraSQL.GeneraStrutturaEDati(/*true, */meta.Conn, txtXMLFile.Text.Trim(), txtOutputFile.Text.Trim(), 
				UpdateType.insertAndUpdate, DataGenerationType.structureAndData, true);
			Cursor.Current = Cursors.Default;
		}
	}
}
