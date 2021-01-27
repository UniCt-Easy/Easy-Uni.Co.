
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Net;
using funzioni_configurazione;//funzioni_configurazione
using checkflags;//checkflags

namespace license_estesa//LicenzaUsoEstesa//

{
	/// <summary>
	/// Summary description for FrmLicenzaUsoEstesa.
	/// </summary>
	public class Frm_license_estesa : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox textBox8;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		public /*Rana:LicenzaUsoEstesa.*/vistaForm DS;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox9;
		private System.Windows.Forms.TextBox textBox10;
		MetaData Meta;
		bool CanGoEdit, CanGoInsert;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox textBox11;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox textBox12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label15;
		bool abilitaricalcolo=false;
		string RealServerName;
		string RealDBName;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnRemoveLicense;

		
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_license_estesa()
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.textBox6 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.DS = new /*Rana:LicenzaUsoEstesa.*/vistaForm();
			this.label10 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label15 = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnRemoveLicense = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(544, 24);
			this.label1.TabIndex = 0;
			this.label1.Text = "Le informazioni in questa pagina servono ad aggiornare l\'archivio clienti della S" +
				"oftware && More.";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "Identificativo DB";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(128, 40);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.TabIndex = 2;
			this.textBox1.TabStop = false;
			this.textBox1.Tag = "license.iddb";
			this.textBox1.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 120);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 23);
			this.label3.TabIndex = 3;
			this.label3.Text = "Nome Università";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(128, 120);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(408, 20);
			this.textBox2.TabIndex = 4;
			this.textBox2.Tag = "license.agency";
			this.textBox2.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(112, 23);
			this.label4.TabIndex = 5;
			this.label4.Text = "Nome dipartimento o \'Amministrazione\'";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(128, 152);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(408, 20);
			this.textBox3.TabIndex = 6;
			this.textBox3.Tag = "license.department";
			this.textBox3.Text = "";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(112, 16);
			this.label5.TabIndex = 7;
			this.label5.Text = "Nome e Cognome";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(128, 16);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(408, 20);
			this.textBox4.TabIndex = 9;
			this.textBox4.Tag = "license.referent";
			this.textBox4.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(112, 23);
			this.label6.TabIndex = 9;
			this.label6.Text = "Telefono";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(128, 48);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(408, 20);
			this.textBox5.TabIndex = 10;
			this.textBox5.Tag = "license.phonenumber";
			this.textBox5.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 80);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(112, 23);
			this.label7.TabIndex = 11;
			this.label7.Text = "Fax";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox6
			// 
			this.textBox6.Location = new System.Drawing.Point(128, 80);
			this.textBox6.Name = "textBox6";
			this.textBox6.Size = new System.Drawing.Size(408, 20);
			this.textBox6.TabIndex = 11;
			this.textBox6.Tag = "license.fax";
			this.textBox6.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(8, 112);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(112, 23);
			this.label8.TabIndex = 13;
			this.label8.Tag = "";
			this.label8.Text = "indirizzo E-Mail";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox7
			// 
			this.textBox7.Location = new System.Drawing.Point(128, 112);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(408, 20);
			this.textBox7.TabIndex = 12;
			this.textBox7.Tag = "license.email";
			this.textBox7.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(16, 408);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(96, 23);
			this.label9.TabIndex = 15;
			this.label9.Text = "Note (facoltative)";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox8
			// 
			this.textBox8.Location = new System.Drawing.Point(120, 408);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(424, 64);
			this.textBox8.TabIndex = 13;
			this.textBox8.Tag = "license.annotations";
			this.textBox8.Text = "";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(466, 480);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 46;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(378, 480);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 45;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(8, 64);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(112, 23);
			this.label10.TabIndex = 47;
			this.label10.Text = "Nome Server";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(8, 88);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(112, 23);
			this.label11.TabIndex = 48;
			this.label11.Text = "Nome DB";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox9
			// 
			this.textBox9.Location = new System.Drawing.Point(128, 64);
			this.textBox9.Name = "textBox9";
			this.textBox9.ReadOnly = true;
			this.textBox9.Size = new System.Drawing.Size(408, 20);
			this.textBox9.TabIndex = 49;
			this.textBox9.TabStop = false;
			this.textBox9.Tag = "license.servername";
			this.textBox9.Text = "";
			// 
			// textBox10
			// 
			this.textBox10.Location = new System.Drawing.Point(128, 88);
			this.textBox10.Name = "textBox10";
			this.textBox10.ReadOnly = true;
			this.textBox10.Size = new System.Drawing.Size(408, 20);
			this.textBox10.TabIndex = 50;
			this.textBox10.TabStop = false;
			this.textBox10.Tag = "license.dbname";
			this.textBox10.Text = "";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(24, 184);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(96, 23);
			this.label12.TabIndex = 51;
			this.label12.Text = "Codice Fiscale";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox11
			// 
			this.textBox11.Location = new System.Drawing.Point(128, 184);
			this.textBox11.Name = "textBox11";
			this.textBox11.Size = new System.Drawing.Size(152, 20);
			this.textBox11.TabIndex = 7;
			this.textBox11.Tag = "license.cf";
			this.textBox11.Text = "";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(296, 184);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(80, 23);
			this.label13.TabIndex = 53;
			this.label13.Text = "Provincia";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox12
			// 
			this.textBox12.Location = new System.Drawing.Point(384, 184);
			this.textBox12.Name = "textBox12";
			this.textBox12.Size = new System.Drawing.Size(56, 20);
			this.textBox12.TabIndex = 8;
			this.textBox12.Tag = "license.country";
			this.textBox12.Text = "";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(24, 480);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(320, 23);
			this.label14.TabIndex = 54;
			this.label14.Text = "E\' importante inserire accuratamente tutte le informazioni.";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.textBox4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.textBox5);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.textBox6);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.textBox7);
			this.groupBox1.Location = new System.Drawing.Point(8, 216);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(552, 144);
			this.groupBox1.TabIndex = 9;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Referente per le comunicazioni della Software and More. (*)";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(8, 360);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(544, 40);
			this.label15.TabIndex = 56;
			this.label15.Text = "(*) Per le gestioni centralizzate (es. Perugia Stranieri, Piemonte Orientale) è i" +
				"l nome di chi gestisce centralmente le assistenze. In tutti gli altri casi è il " +
				"nome del segretario amministrativo, responsabile del dipartimento o dell\'amminis" +
				"trazione.";
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(464, 32);
			this.btnReset.Name = "btnReset";
			this.btnReset.TabIndex = 57;
			this.btnReset.Text = "Reimposta";
			this.btnReset.Visible = false;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnRemoveLicense
			// 
			this.btnRemoveLicense.Location = new System.Drawing.Point(312, 32);
			this.btnRemoveLicense.Name = "btnRemoveLicense";
			this.btnRemoveLicense.Size = new System.Drawing.Size(120, 23);
			this.btnRemoveLicense.TabIndex = 58;
			this.btnRemoveLicense.Text = "Rimuovi Licenza";
			this.btnRemoveLicense.Visible = false;
			this.btnRemoveLicense.Click += new System.EventHandler(this.btnRemoveLicense_Click);
			// 
			// FrmLicenzaUsoEstesa
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(570, 511);
			this.Controls.Add(this.btnRemoveLicense);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.label15);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label14);
			this.Controls.Add(this.textBox12);
			this.Controls.Add(this.textBox11);
			this.Controls.Add(this.textBox10);
			this.Controls.Add(this.textBox9);
			this.Controls.Add(this.textBox8);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label13);
			this.Controls.Add(this.label12);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FrmLicenzaUsoEstesa";
			this.Text = "FrmLicenzaUsoEstesa";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion



		public void MetaData_AfterLink(){
			Meta= MetaData.GetMetaData(this);
			RealServerName=CheckFlags.ServerName(Meta.Conn);
			RealDBName= CheckFlags.DBName(Meta.Conn);

			Meta.CanInsert=false;
			Meta.CanInsertCopy=false;
			Meta.CanCancel=false;
			Meta.SearchEnabled=false;		
			int numrighelicenzauso = Meta.Conn.RUN_SELECT_COUNT("license","((serverbackup1 is null)or(serverbackup1 is not null))", true);
			if (numrighelicenzauso==0){
				MessageBox.Show("Attendere il completamento del db e poi ricollegarsi.");
				Meta.CanSave=false;
				CanGoEdit=false;
				CanGoInsert=false;
				Meta.SearchEnabled=false;
				return;
			}

			numrighelicenzauso = Meta.Conn.RUN_SELECT_COUNT("license",null, true);
			if (numrighelicenzauso==1) {
				CanGoInsert=false;
				CanGoEdit=true;
			}
			else {
				CanGoInsert=true;
				CanGoEdit=false;
			}
			HelpForm.SetDenyNull(DS.license.Columns["cf"],true);
			HelpForm.SetDenyNull(DS.license.Columns["agency"],true);
			HelpForm.SetDenyNull(DS.license.Columns["department"],true);
			HelpForm.SetDenyNull(DS.license.Columns["country"],true);
			HelpForm.SetDenyNull(DS.license.Columns["phonenumber"],true);
			HelpForm.SetDenyNull(DS.license.Columns["fax"],true);
			HelpForm.SetDenyNull(DS.license.Columns["email"],true);
			HelpForm.SetDenyNull(DS.license.Columns["referent"],true);			
			
		}

		
		public void MetaData_AfterClear() {
			if (CanGoInsert) {
				CanGoInsert=false;
				MetaData.DoMainCommand(this, "maininsert");
			}
			if (CanGoEdit) {
				CanGoEdit=false;
				MetaData.DoMainCommand(this, "maindosearch.licenzauso");
				Meta.CanInsert=false;
			}
		}

		bool MessaggioDisableVisualizzato=false;
		public void MetaData_BeforeFill(){
			if (DS.license.Rows.Count==0) return;
			DataRow R= DS.license.Rows[0];
			if (InformazioniNonPresenti(R)){
				CalcolaInformazioni(R);
				SetImpostazioniDefault(R);
				abilitaricalcolo=true;
			}
			
			if (R["checkflag"].ToString()!=CheckFlags.CalcolaCheckFlag(R)){
				if (!MessaggioDisableVisualizzato){
					MessageBox.Show("Questo db non è autorizzato dalla Software & More. Contattare il servizio assistenza");
					MessaggioDisableVisualizzato=true;
				}
				Meta.CanSave=false;
				Meta.CanInsert=false;
                btnOK.Visible=false;
				Easy_DataAccess CD = Meta.Conn as Easy_DataAccess;
				if (CD!=null) CD.ReadOnly=true;

			}
			if (((R["servername"].ToString().ToUpper()!= RealServerName.ToUpper())&&
				 (R["serverbackup1"].ToString().ToUpper()!= RealServerName.ToUpper())&&
				 (R["serverbackup2"].ToString().ToUpper()!= RealServerName.ToUpper()))||
				(R["dbname"].ToString()!= RealDBName)){				
				MessageBox.Show("Da questo accesso risulta che il db n."+
					R["iddb"].ToString()+
					" il nuovo server è "+RealServerName+
					" ed il nuovo nomedb è "+RealDBName+
					". Contattare la software and more per fare (ri)abilitare questo db all'uso del programma.");

				bool IsAdmin=false;
				if (Meta.GetSys("FlagMenuAdmin")!=null) 
					IsAdmin=(Meta.GetSys("FlagMenuAdmin").ToString()=="S");

				Meta.CanSave=IsAdmin;
				Meta.CanInsert=false;
				btnOK.Visible=IsAdmin;
				Easy_DataAccess CD = Meta.Conn as Easy_DataAccess;
				if (CD!=null) CD.ReadOnly=!IsAdmin;
				btnReset.Visible=IsAdmin;
				btnRemoveLicense.Visible=IsAdmin;
								
			}
		}


		bool InformazioniNonPresenti(DataRow R){
			if (//(R["iddbcliente"]==DBNull.Value) &&
				(R["servername"]==DBNull.Value) &&
				(R["dbname"]==DBNull.Value) &&
				(R["swmorecode"]==DBNull.Value) &&
				(R["swmoreflag"]==DBNull.Value)) return true;
			return false;		
		}

		/// <summary>
		/// Calcola servername, dbname
		/// </summary>
		/// <param name="R"></param>
		void CalcolaInformazioni(DataRow R){
			R["servername"]= CheckFlags.ServerName(Meta.Conn);
			R["dbname"]=CheckFlags.DBName(Meta.Conn);
		}

		/// <summary>
		/// Imposta info di default per licenze e flag
		/// </summary>
		/// <param name="R"></param>
		void SetImpostazioniDefault(DataRow R){
			R["swmoreflag"]=0;
			DateTime ScadenzaDefault= new DateTime(2000,1,1);
			R["swmorecode"]=DBNull.Value;
			string RealCheck = CheckFlags.CalcolaCheckFlag(R);
			R["checkflag"]=RealCheck;
			R["licstatus"]="B";
			R["expiringlic"]=ScadenzaDefault;
			R["lickind"]="O";
			R["checklic"]=CheckFlags.CalcolaCheckLic(R);
			R["manstatus"]="N";
			R["expiringman"]=ScadenzaDefault;
			R["mankind"]="O";
			R["checkman"]=CheckFlags.CalcolaCheckMan(R);
		}

		int RichiediCodice(){
			try {
				//Richiede al sito della sw&More un incrementale da assegnare al db come iddbcliente
				string XX = "newid";
				while( (XX.Length % 8)!=0) XX+=" ";
				byte [] B2 = DataAccess.CryptString(XX);
				string SS2 = QueryCreator.ByteArrayToString(B2);
				WebClient W = new WebClient();
                W.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
                W.BaseAddress = "http://SERVER/LiveLog/";
                byte[] B = W.DownloadData("http://SERVER/LiveLog/DoEasy.aspx?a=" + SS2);
				string resp="";
				for (int i=0; i<B.Length;i++) resp=resp+ (char)B[i];
				resp= resp.Trim();
				return CfgFn.GetNoNullInt32(resp);			
			}
			catch {
				return 0;
			}
		}




		public void MetaData_BeforePost(){
			if (DS.license.Rows.Count==0) return;
			Easy_DataAccess E= Meta.Conn as Easy_DataAccess;
			if (E!=null){
				if (((Easy_DataAccess) Meta.Conn).ReadOnly) return;
			}
			PostData.RemoveFalseUpdates(DS);
			//if (!DS.HasChanges()) return;
			DataRow R= DS.license.Rows[0];
			if (CfgFn.GetNoNullInt32(R["iddb"])==0){
				int mycode=RichiediCodice();
				if (mycode>0) {
					R["iddb"]=mycode;
					if (abilitaricalcolo) SetImpostazioniDefault(R);
				}
				else {
					string xx = Meta.GetSys("FlagMenuAdmin") as string;
					if (xx==null) xx="";
					if (xx.ToUpper()=="S"){
						string pwdChangeServer;
						FrmAskCode F= new FrmAskCode(0);
						F.txtID.PasswordChar='?';
						DialogResult D= F.ShowDialog(this);
						if (D!=DialogResult.OK)return;
						pwdChangeServer=F.txtID.Text;
						if (pwdChangeServer=="DoMasterSetDB"){
							FrmAskCode FF= new FrmAskCode(0);
							DialogResult DD= FF.ShowDialog(this);
							if (DD==DialogResult.OK){
								mycode=CfgFn.GetNoNullInt32(
									HelpForm.GetObjectFromString(typeof(int),FF.txtID.Text,"x.y"));
								if (mycode>0) {
									R["iddb"]=mycode;
								}
							}
						}
					}
				}
				string RealCheck = CheckFlags.CalcolaCheckFlag(R);
				R["checkflag"]= RealCheck;
			}
		}

		



		public void MetaData_AfterPost(){
			if (DS.license.Rows.Count==0) return;
			DataRow R= DS.license.Rows[0];
			if (CfgFn.GetNoNullInt32(R["iddb"])!=0){
				CheckFlags.SendToInternet(Meta.Conn,DS);
			}
			


		}

		private void btnReset_Click(object sender, System.EventArgs e) {
			if (MessageBox.Show(this,
				"Premere OK solo se si è esattamente CERTI di quello che si sta facendo e "+
				"se si è sotto la STRETTISSIMA tutela di un tecnico della software and more.",
				"Attenzione",MessageBoxButtons.OKCancel)!=DialogResult.OK){
				btnReset.Visible=false;
				btnRemoveLicense.Visible=false;
				btnOK.Visible=false;
				Meta.CanSave=false;
				return;
			}
			string pwdChangeServer;
			FrmAskCode F= new FrmAskCode(0);
			F.txtID.PasswordChar='?';
			DialogResult D= F.ShowDialog(this);
			if (D!=DialogResult.OK)return;
			pwdChangeServer=F.txtID.Text;
			if (pwdChangeServer!="DoMasterChangeServer") return;
			DataRow R = DS.license.Rows[0];

			CalcolaInformazioni(R);
			R["checkflag"]=CheckFlags.CalcolaCheckFlag(R);
			R["checkman"]=CheckFlags.CalcolaCheckMan(R);
			R["licstatus"]="B"; //stato iniziale del nuovo db='bloccato'
			R["checklic"]=CheckFlags.CalcolaCheckLic(R);

			//SetImpostazioniDefault(R);
			abilitaricalcolo=true;
			Meta.FreshForm(true);
			MessageBox.Show("Server del db n."+R["iddb"].ToString() +" reimpostato.");

		}

		private void btnRemoveLicense_Click(object sender, System.EventArgs e) {
			if (MessageBox.Show(this,
				"Premere OK solo se si è esattamente CERTI di quello che si sta facendo e "+
				"se si è sotto la STRETTISSIMA tutela di un tecnico della software and more.",
				"Attenzione",MessageBoxButtons.OKCancel)!=DialogResult.OK){
				btnReset.Visible=false;
				btnRemoveLicense.Visible=false;
				btnOK.Visible=false;
				Meta.CanSave=false;
				return;
			}
			string pwdChangeServer;
			FrmAskCode F= new FrmAskCode(0);
			F.txtID.PasswordChar='?';
			DialogResult D= F.ShowDialog(this);
			if (D!=DialogResult.OK)return;
			pwdChangeServer=F.txtID.Text;
			if (pwdChangeServer!="DoMasterChangeServer") return;
			DataRow R = DS.license.Rows[0];
			R["servername"]=DBNull.Value;
			R["dbname"]=DBNull.Value;
			R["swmorecode"]=DBNull.Value;
			R["swmoreflag"]=DBNull.Value;
			R["iddb"]=DBNull.Value;
			abilitaricalcolo=true;
			Meta.FreshForm(true);
			MessageBox.Show("Informazioni sulla licenza eliminate");

		}


	}
}