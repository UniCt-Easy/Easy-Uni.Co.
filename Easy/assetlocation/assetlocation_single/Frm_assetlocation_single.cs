
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;
namespace assetlocation_single//ubicazioneinventariosingle//
{
	/// <summary>
	/// Summary description for frmubicazioneinventariosingle.
	/// </summary>
	public class frmubicazioneinventariosingle : MetaDataForm {
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.GroupBox grpUbicazione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
        public vistaForm DS;
        private Label label3;
        private GroupBox grpAutoLocation;
        private Button btnUbicazione;
        private TextBox txtDescUbicazione;
        private TextBox txtUbicazione;
        QueryHelper QHS;
        CQueryHelper QHC;
        private MetaData Meta;
        private DataAccess Conn;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public frmubicazioneinventariosingle()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
			GetData.CacheTable(DS.locationlevel, null, null, true);
			HelpForm.SetDenyNull(DS.assetlocation.Columns["idlocation"], true);
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
        private bool Operativo(object idlocation) {
            if (idlocation == DBNull.Value) return false;
   
            DataRow[] Rows = DS.locationview.Select("(idlocation=" +
                QueryCreator.quotedstrvalue(idlocation, true) + ")");
            if (Rows.Length != 1) return false;
            int nlevel = CfgFn.GetNoNullInt32(Rows[0]["nlevel"]);

            DataRow[] Res = DS.locationlevel.Select("(nlevel=" +
                QueryCreator.quotedstrvalue(nlevel, true) + ")");
            if (Res.Length != 1) return false;
            int flag = CfgFn.GetNoNullInt32(Res[0]["flag"]);
            bool usable = ((flag & 2) != 0);
            return usable;
        }

        private bool TipoNumerico(object codicelivello) {
            DataRow[] Res = DS.locationlevel.Select("(nlevel=" +
                QueryCreator.quotedstrvalue(codicelivello, true) + ")");
            if (Res.Length != 1) return false;
            int flag = CfgFn.GetNoNullInt32(Res[0]["flag"]);
            bool numerico = ((flag & 1) == 0);
            return numerico;
        }


        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
		{
			this.btnOk = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.grpUbicazione = new System.Windows.Forms.GroupBox();
			this.grpAutoLocation = new System.Windows.Forms.GroupBox();
			this.btnUbicazione = new System.Windows.Forms.Button();
			this.txtDescUbicazione = new System.Windows.Forms.TextBox();
			this.txtUbicazione = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.DS = new assetlocation_single.vistaForm();
			this.label3 = new System.Windows.Forms.Label();
			this.grpUbicazione.SuspendLayout();
			this.grpAutoLocation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(326, 185);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 2;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(414, 185);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 3;
			this.btnAnnulla.Text = "Annulla";
			// 
			// grpUbicazione
			// 
			this.grpUbicazione.Controls.Add(this.grpAutoLocation);
			this.grpUbicazione.Controls.Add(this.textBox2);
			this.grpUbicazione.Controls.Add(this.label1);
			this.grpUbicazione.Location = new System.Drawing.Point(12, 30);
			this.grpUbicazione.Name = "grpUbicazione";
			this.grpUbicazione.Size = new System.Drawing.Size(478, 140);
			this.grpUbicazione.TabIndex = 1;
			this.grpUbicazione.TabStop = false;
			this.grpUbicazione.Tag = "";
			// 
			// grpAutoLocation
			// 
			this.grpAutoLocation.Controls.Add(this.btnUbicazione);
			this.grpAutoLocation.Controls.Add(this.txtDescUbicazione);
			this.grpAutoLocation.Controls.Add(this.txtUbicazione);
			this.grpAutoLocation.Location = new System.Drawing.Point(7, 43);
			this.grpAutoLocation.Name = "grpAutoLocation";
			this.grpAutoLocation.Size = new System.Drawing.Size(460, 91);
			this.grpAutoLocation.TabIndex = 9;
			this.grpAutoLocation.TabStop = false;
			this.grpAutoLocation.Tag = "AutoChoose.txtUbicazione.default.(active=\'S\')";
			// 
			// btnUbicazione
			// 
			this.btnUbicazione.Location = new System.Drawing.Point(6, 13);
			this.btnUbicazione.Name = "btnUbicazione";
			this.btnUbicazione.Size = new System.Drawing.Size(88, 23);
			this.btnUbicazione.TabIndex = 5;
			this.btnUbicazione.Tag = "manage.locationview.tree.(active=\'S\')";
			this.btnUbicazione.Text = "Ubicazione";
			// 
			// txtDescUbicazione
			// 
			this.txtDescUbicazione.Location = new System.Drawing.Point(110, 37);
			this.txtDescUbicazione.Multiline = true;
			this.txtDescUbicazione.Name = "txtDescUbicazione";
			this.txtDescUbicazione.ReadOnly = true;
			this.txtDescUbicazione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescUbicazione.Size = new System.Drawing.Size(344, 48);
			this.txtDescUbicazione.TabIndex = 7;
			this.txtDescUbicazione.Tag = "locationview.description";
			// 
			// txtUbicazione
			// 
			this.txtUbicazione.Location = new System.Drawing.Point(110, 13);
			this.txtUbicazione.Name = "txtUbicazione";
			this.txtUbicazione.Size = new System.Drawing.Size(152, 20);
			this.txtUbicazione.TabIndex = 6;
			this.txtUbicazione.Tag = "locationview.locationcode?x";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(120, 15);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(88, 20);
			this.textBox2.TabIndex = 10;
			this.textBox2.Tag = "assetlocation.start";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "Data inizio";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(0, 0);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 0;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(15, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(475, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "Per inserire l\'ubicazione originale non inserire la data";
			// 
			// frmubicazioneinventariosingle
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(502, 220);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.grpUbicazione);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnAnnulla);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmubicazioneinventariosingle";
			this.Text = "frmubicazioneinventariosingle";
			this.grpUbicazione.ResumeLayout(false);
			this.grpUbicazione.PerformLayout();
			this.grpAutoLocation.ResumeLayout(false);
			this.grpAutoLocation.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
		private void ShowMsg(string msg) {
			show(msg, "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "locationview") {
				if (!Meta.DrawStateIsDone) return;
				if (DS.assetlocation.Rows.Count==0) return;
				if (R == null) return;
				DataRow Curr = DS.assetlocation.Rows[0];
				if (!Operativo(R["idlocation"])) {
					ShowMsg("L'ubicazione selezionata non è operativa");
					Curr["idlocation"] = DBNull.Value;
					txtUbicazione.Text = "";
					txtDescUbicazione.Text = "";
					return;
				}

			}
		}

	}
}
