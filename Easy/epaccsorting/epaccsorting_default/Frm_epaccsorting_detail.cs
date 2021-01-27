
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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Globalization;


namespace epaccsorting_default
{
	/// <summary>
	/// Summary description for Frm_expsorting_detail.
	/// </summary>
	public class Frm_epaccsorting_detail : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
		public epaccsorting_default.vistaForm DS;
		MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
		bool inChiusura = false;
		decimal importototale;
		decimal importoclassificazione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPercentuale;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.Label lblPercentuale;
        private System.Windows.Forms.Label lblImporto;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdbNormale;
		private System.Windows.Forms.RadioButton rdbVariazione;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
        private ComboBox cmbTipo;
        private Label label4;
        private GroupBox gboxclass;
        private TextBox txtCodice;
        private Button btnCodice;
        private TextBox txtDescrizione;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_epaccsorting_detail()
		{
			InitializeComponent();		
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			inChiusura = true;
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T!= DS.sortingapplicabilityview) return;

			if (MetaData.GetMetaData(this).DrawState== MetaData.form_drawstates.done) {
				if ((!MetaData.Empty(this))){
					DS.epaccsorting.Rows[0]["idsor"]=0;
				}
				txtCodice.Text="";
				txtDescrizione.Text="";
				DS.sorting.Clear();
			}
			SetCodice();
		}



		void SetCodice(){
			
			if (Meta.EditMode) return;
			btnCodice.Enabled= (cmbTipo.SelectedIndex>0);
			txtCodice.ReadOnly= (cmbTipo.SelectedIndex<=0);
			if (cmbTipo.SelectedIndex<=0){
				txtCodice.Text="";
				txtDescrizione.Text="";
			}
			else {
				string filter = Meta.QHS.CmpEq("idsorkind",cmbTipo.SelectedValue);
				btnCodice.Tag="manage.sorting.tree."+filter;
				//label per il form di selezione della voce di classificazione +"."+ filtro
				DS.sorting.ExtendedProperties[MetaData.ExtraParams]=filter;
				//AutoManage.txtCodiceClass.tree
				gboxclass.Tag="AutoManage.txtCodice.tree."+filter;
				MetaData.GetMetaData(this).SetAutoMode(gboxclass);
			}
		}


		public void MetaData_AfterFill(){
			SetCodice();
		}

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();

            DataRow Source = Meta.SourceRow;
            DataTable TEpaccParent = Source.Table.DataSet.Tables["epacc"];
            if (TEpaccParent==null) TEpaccParent = Source.Table.DataSet.Tables["epaccview"];
            DataRow ParEpacc = TEpaccParent.Select(QHC.CmpEq("idepacc", Source["idepacc"]))[0];
            int nphase = CfgFn.GetNoNullInt32(  ParEpacc["nphase"]);
            string s_table = "epacc";
            if (nphase == 1)
                s_table = "epacc1";
            string filterCT = QHS.CmpEq("tablename", s_table);
            GetData.CacheTable(DS.sortingapplicabilityview, filterCT, null, true);

            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive, filterCT)), QHS.CmpEq("idsorkind", 0)));

            QueryCreator.SetFilterForInsert(DS.sortingapplicabilityview, filterI);
            cmbTipo.DataSource = DS.sortingapplicabilityview;
        }
	

		public void MetaData_AfterActivation(){
			if (DS.epaccsorting.Rows.Count==0) return;

			DataRow CurrRow = DS.epaccsorting.Rows[0];
			importoclassificazione= CfgFn.GetNoNullDecimal(CurrRow["amount"]);
			importototale= CfgFn.GetNoNullDecimal(DS.epaccsorting.ExtendedProperties["importototale"]);
			

			decimal percentuale = 100;
			if (importototale!=0) percentuale= importoclassificazione/importototale*100;
			decimal rounded = Math.Round(percentuale, 4);
			txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1"); 

		}

        //assume importomovimento, importo importototale valorizzati
		private void txtPercentuale_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			// ripristina l'importo originale
			if (!txtPercentuale.Modified) return;
			if(!checkpercentuale()) {
				decimal percentuale = 100;
				if (importototale!=0) percentuale= importoclassificazione/importototale*100;
				decimal rounded = Math.Round(percentuale, 4);                
				// calcola la percentuale in base all'importo
				txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1");                
			}
			else {
				// calcola l'importo in base alla percentuale
				decimal perc = Decimal.Parse(txtPercentuale.Text,
					NumberStyles.Number,
					NumberFormatInfo.CurrentInfo);
				importoclassificazione = CfgFn.RoundValuta( perc* importototale /100);
				txtImporto.Text = importoclassificazione.ToString("c");                
			}
		}

		private bool checkpercentuale() {           
			bool OK = false;
			if (txtPercentuale.Text == "") return false;           
			decimal percentmax=100;			
			
			string errmsg = "Il valore percentuale dovrebbe essere un numero compreso \r" +
				"tra 0 e " + percentmax.ToString("n") + ". Proseguo comunque?";
			try {
				decimal percent = Decimal.Parse(txtPercentuale.Text,
					NumberStyles.Number,
					NumberFormatInfo.CurrentInfo);
				if ((percent < 0)  || (percent > percentmax) ) {
					OK = (MetaFactory.factory.getSingleton<IMessageShower>().Show(errmsg,"Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
				}
				else {
					OK=true;
				}
  
			}
			catch {                
				MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario digitare un numero" ,"Avviso",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}            
			return OK;
		}

		private void txtImporto_Leave(object sender, System.EventArgs e) {        
			if(inChiusura) return;
			if (!txtImporto.Modified) return;              
			if(!checkimporto()) {
				// ripristina l'importo originale
				txtImporto.Text = importoclassificazione.ToString("c");
			}
			else {
				importoclassificazione= CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					txtImporto.Text,HelpForm.GetStandardTag(txtImporto.Tag)));
				decimal percentuale = 100;
				if (importototale!=0) percentuale= importoclassificazione/importototale*100;

				decimal rounded = Math.Round(percentuale, 4);                
				// calcola la percentuale in base all'importo
				txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1");            
			}
		}   

		private bool checkimporto() {
			bool OK = false;

			if (txtImporto.Text == "") return false;
			string errmsg = "L'importo dovrebbe essere un numero compreso \r" +
                "tra 0 e " + importototale.ToString("c") + ". Proseguo comunque?";
			try {
				decimal importo = CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					txtImporto.Text,HelpForm.GetStandardTag(txtImporto.Tag)));
                if (((importo >= 0) && (importo <= importototale) && rdbNormale.Checked) || rdbVariazione.Checked) {
					OK = true;
				}
				else{
					OK = (MetaFactory.factory.getSingleton<IMessageShower>().Show(errmsg,"Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
				}
  
			}
			catch {                
				MetaFactory.factory.getSingleton<IMessageShower>().Show("E' necessario inserire un numero","Avviso",
					System.Windows.Forms.MessageBoxButtons.OK,
					System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}
			return OK;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_epaccsorting_detail));
            this.DS = new epaccsorting_default.vistaForm();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPercentuale = new System.Windows.Forms.TextBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.lblPercentuale = new System.Windows.Forms.Label();
            this.lblImporto = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbVariazione = new System.Windows.Forms.RadioButton();
            this.rdbNormale = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gboxclass = new System.Windows.Forms.GroupBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.btnCodice = new System.Windows.Forms.Button();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gboxclass.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(338, 385);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 10;
            this.btnOk.TabStop = false;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(442, 385);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 11;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Annulla";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(264, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 203;
            this.label2.Text = "%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPercentuale
            // 
            this.txtPercentuale.Location = new System.Drawing.Point(176, 266);
            this.txtPercentuale.Name = "txtPercentuale";
            this.txtPercentuale.Size = new System.Drawing.Size(80, 20);
            this.txtPercentuale.TabIndex = 200;
            this.txtPercentuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentuale.Leave += new System.EventHandler(this.txtPercentuale_Leave);
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(28, 266);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(100, 20);
            this.txtImporto.TabIndex = 199;
            this.txtImporto.Tag = "epaccsorting.amount";
            this.txtImporto.Leave += new System.EventHandler(this.txtImporto_Leave);
            // 
            // lblPercentuale
            // 
            this.lblPercentuale.Location = new System.Drawing.Point(176, 250);
            this.lblPercentuale.Name = "lblPercentuale";
            this.lblPercentuale.Size = new System.Drawing.Size(100, 16);
            this.lblPercentuale.TabIndex = 202;
            this.lblPercentuale.Text = "Percentuale";
            // 
            // lblImporto
            // 
            this.lblImporto.Location = new System.Drawing.Point(28, 250);
            this.lblImporto.Name = "lblImporto";
            this.lblImporto.Size = new System.Drawing.Size(100, 23);
            this.lblImporto.TabIndex = 201;
            this.lblImporto.Text = "Importo";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(28, 194);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(489, 48);
            this.textBox1.TabIndex = 204;
            this.textBox1.Tag = "epaccsorting.description";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 207;
            this.label1.Text = "Descrizione";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDataContabile.Location = new System.Drawing.Point(28, 316);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(104, 20);
            this.txtDataContabile.TabIndex = 209;
            this.txtDataContabile.Tag = "epaccsorting.adate";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(28, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 24);
            this.label5.TabIndex = 208;
            this.label5.Text = "Data Contabile";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.rdbVariazione);
            this.groupBox2.Controls.Add(this.rdbNormale);
            this.groupBox2.Location = new System.Drawing.Point(176, 300);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(216, 40);
            this.groupBox2.TabIndex = 210;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo Classificazione";
            // 
            // rdbVariazione
            // 
            this.rdbVariazione.Location = new System.Drawing.Point(120, 16);
            this.rdbVariazione.Name = "rdbVariazione";
            this.rdbVariazione.Size = new System.Drawing.Size(92, 16);
            this.rdbVariazione.TabIndex = 4;
            this.rdbVariazione.Tag = "epaccsorting.kind:V";
            this.rdbVariazione.Text = "Variazione";
            // 
            // rdbNormale
            // 
            this.rdbNormale.Location = new System.Drawing.Point(12, 16);
            this.rdbNormale.Name = "rdbNormale";
            this.rdbNormale.Size = new System.Drawing.Size(104, 16);
            this.rdbNormale.TabIndex = 3;
            this.rdbNormale.Tag = "epaccsorting.kind:N";
            this.rdbNormale.Text = "Normale";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.cmbTipo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.gboxclass);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(489, 160);
            this.groupBox1.TabIndex = 211;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // cmbTipo
            // 
            this.cmbTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipo.DisplayMember = "description";
            this.cmbTipo.Location = new System.Drawing.Point(104, 32);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(377, 21);
            this.cmbTipo.TabIndex = 1;
            this.cmbTipo.Tag = "sorting.idsorkind?x";
            this.cmbTipo.ValueMember = "idsorkind";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 18;
            this.label4.Text = "Classificazione:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // gboxclass
            // 
            this.gboxclass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass.Controls.Add(this.txtCodice);
            this.gboxclass.Controls.Add(this.btnCodice);
            this.gboxclass.Controls.Add(this.txtDescrizione);
            this.gboxclass.Location = new System.Drawing.Point(78, 56);
            this.gboxclass.Name = "gboxclass";
            this.gboxclass.Size = new System.Drawing.Size(403, 88);
            this.gboxclass.TabIndex = 10;
            this.gboxclass.TabStop = false;
            this.gboxclass.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            // 
            // txtCodice
            // 
            this.txtCodice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice.Location = new System.Drawing.Point(8, 56);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.ReadOnly = true;
            this.txtCodice.Size = new System.Drawing.Size(96, 20);
            this.txtCodice.TabIndex = 2;
            this.txtCodice.Tag = "sorting.sortcode?x";
            // 
            // btnCodice
            // 
            this.btnCodice.Enabled = false;
            this.btnCodice.Location = new System.Drawing.Point(8, 24);
            this.btnCodice.Name = "btnCodice";
            this.btnCodice.Size = new System.Drawing.Size(96, 23);
            this.btnCodice.TabIndex = 1;
            this.btnCodice.Tag = "manage.sorting.tree";
            this.btnCodice.Text = "Codice";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(112, 24);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(283, 56);
            this.txtDescrizione.TabIndex = 3;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "sorting.description";
            // 
            // Frm_epaccsorting_detail
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(530, 424);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtDataContabile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPercentuale);
            this.Controls.Add(this.txtImporto);
            this.Controls.Add(this.lblPercentuale);
            this.Controls.Add(this.lblImporto);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_epaccsorting_detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Classificazione Gerarchica";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gboxclass.ResumeLayout(false);
            this.gboxclass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		
	}
}
