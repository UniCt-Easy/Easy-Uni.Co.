
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
using metadatalibrary;
using System.Data;
using funzioni_configurazione;
using System.Globalization;

namespace admpay_expensesorted_detail {
	/// <summary>
	/// Summary description for FrmAdmPay_ExpenseSorted_Detail.
	/// </summary>
	public class FrmAdmPay_ExpenseSorted_Detail : MetaDataForm {
		MetaData Meta;
		decimal importomovimento;
		decimal importoresiduo;
		decimal importototale;
		decimal importooriginale;
		bool inChiusura = false;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox txtSubmovimento;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPercentuale;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.Label lblPercentuale;
		private System.Windows.Forms.Label lblImporto;
		private System.Windows.Forms.GroupBox gboxclass;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Button btnCodice;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
		public admpay_expensesorted_detail.vistaForm DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmAdmPay_ExpenseSorted_Detail() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			inChiusura = true;
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtSubmovimento = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPercentuale = new System.Windows.Forms.TextBox();
			this.txtImporto = new System.Windows.Forms.TextBox();
			this.lblPercentuale = new System.Windows.Forms.Label();
			this.lblImporto = new System.Windows.Forms.Label();
			this.gboxclass = new System.Windows.Forms.GroupBox();
			this.txtDescrizione = new System.Windows.Forms.TextBox();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.btnCodice = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.DS = new admpay_expensesorted_detail.vistaForm();
			this.gboxclass.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(24, 152);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(504, 48);
			this.textBox1.TabIndex = 3;
			this.textBox1.Tag = "admpay_expensesorted.description";
			this.textBox1.Text = "";
			// 
			// txtSubmovimento
			// 
			this.txtSubmovimento.Location = new System.Drawing.Point(24, 111);
			this.txtSubmovimento.Name = "txtSubmovimento";
			this.txtSubmovimento.ReadOnly = true;
			this.txtSubmovimento.TabIndex = 217;
			this.txtSubmovimento.TabStop = false;
			this.txtSubmovimento.Tag = "admpay_expensesorted.idsubclass";
			this.txtSubmovimento.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 136);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 16);
			this.label1.TabIndex = 219;
			this.label1.Text = "Descrizione";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 95);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(112, 16);
			this.label3.TabIndex = 218;
			this.label3.Text = "Submovimento";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(256, 232);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 16);
			this.label2.TabIndex = 215;
			this.label2.Text = "%";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPercentuale
			// 
			this.txtPercentuale.Location = new System.Drawing.Point(168, 232);
			this.txtPercentuale.Name = "txtPercentuale";
			this.txtPercentuale.Size = new System.Drawing.Size(80, 20);
			this.txtPercentuale.TabIndex = 5;
			this.txtPercentuale.Text = "";
			this.txtPercentuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtPercentuale.Leave += new System.EventHandler(this.txtPercentuale_Leave);
			// 
			// txtImporto
			// 
			this.txtImporto.Location = new System.Drawing.Point(20, 232);
			this.txtImporto.Name = "txtImporto";
			this.txtImporto.TabIndex = 4;
			this.txtImporto.Tag = "admpay_expensesorted.amount";
			this.txtImporto.Text = "";
			this.txtImporto.Leave += new System.EventHandler(this.txtImporto_Leave);
			// 
			// lblPercentuale
			// 
			this.lblPercentuale.Location = new System.Drawing.Point(168, 216);
			this.lblPercentuale.Name = "lblPercentuale";
			this.lblPercentuale.TabIndex = 214;
			this.lblPercentuale.Text = "Percentuale";
			// 
			// lblImporto
			// 
			this.lblImporto.Location = new System.Drawing.Point(20, 216);
			this.lblImporto.Name = "lblImporto";
			this.lblImporto.TabIndex = 213;
			this.lblImporto.Text = "Importo";
			// 
			// gboxclass
			// 
			this.gboxclass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass.Controls.Add(this.txtDescrizione);
			this.gboxclass.Controls.Add(this.txtCodice);
			this.gboxclass.Controls.Add(this.btnCodice);
			this.gboxclass.Location = new System.Drawing.Point(20, 15);
			this.gboxclass.Name = "gboxclass";
			this.gboxclass.Size = new System.Drawing.Size(516, 74);
			this.gboxclass.TabIndex = 1;
			this.gboxclass.TabStop = false;
			this.gboxclass.Tag = "AutoManage.txtCodice.treeclassmovimenti";
			// 
			// txtDescrizione
			// 
			this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizione.Location = new System.Drawing.Point(152, 16);
			this.txtDescrizione.Multiline = true;
			this.txtDescrizione.Name = "txtDescrizione";
			this.txtDescrizione.ReadOnly = true;
			this.txtDescrizione.Size = new System.Drawing.Size(348, 50);
			this.txtDescrizione.TabIndex = 3;
			this.txtDescrizione.TabStop = false;
			this.txtDescrizione.Tag = "sorting.description";
			this.txtDescrizione.Text = "";
			// 
			// txtCodice
			// 
			this.txtCodice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.txtCodice.Location = new System.Drawing.Point(8, 48);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(112, 20);
			this.txtCodice.TabIndex = 1;
			this.txtCodice.Tag = "sorting.sortcode?x";
			this.txtCodice.Text = "";
			// 
			// btnCodice
			// 
			this.btnCodice.Location = new System.Drawing.Point(8, 16);
			this.btnCodice.Name = "btnCodice";
			this.btnCodice.Size = new System.Drawing.Size(80, 23);
			this.btnCodice.TabIndex = 1;
			this.btnCodice.TabStop = false;
			this.btnCodice.Tag = "manage.sorting.tree";
			this.btnCodice.Text = "Codice";
			this.btnCodice.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(346, 264);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 208;
			this.btnOk.TabStop = false;
			this.btnOk.Tag = "mainsave";
			this.btnOk.Text = "Ok";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(450, 264);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 209;
			this.btnAnnulla.TabStop = false;
			this.btnAnnulla.Text = "Annulla";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// FrmAdmPay_ExpenseSorted_Detail
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 302);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.txtSubmovimento);
			this.Controls.Add(this.txtPercentuale);
			this.Controls.Add(this.txtImporto);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lblPercentuale);
			this.Controls.Add(this.lblImporto);
			this.Controls.Add(this.gboxclass);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnAnnulla);
			this.Name = "FrmAdmPay_ExpenseSorted_Detail";
			this.Text = "FrmAdmPay_ExpenseSorted_Detail";
			this.gboxclass.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			DS.sorting.ExtendedProperties[MetaData.ExtraParams] = Meta.ExtraParameter;
		}

		public void MetaData_AfterActivation(){
			if (DS.admpay_expensesorted.Rows.Count==0) return;
			
			DataRow CurrRow = DS.admpay_expensesorted.Rows[0];

			importomovimento= CfgFn.GetNoNullDecimal(CurrRow["amount"]);
			importoresiduo= CfgFn.GetNoNullDecimal(DS.admpay_expensesorted.ExtendedProperties["importoresiduo"]);
			importototale= CfgFn.GetNoNullDecimal(DS.admpay_expensesorted.ExtendedProperties["importototale"]);
			importooriginale= importomovimento;
			
			txtImporto.ReadOnly=false; //read_only;
			txtPercentuale.ReadOnly=false; //read_only;

            object filterObj = DS.admpay_expensesorted.ExtendedProperties["CustomParentRelation"];
            string filter = "";
            if (filterObj != null) {
                filter = filterObj.ToString();
                filter = filter.Replace("!", "");
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.sortingkind, null, filter, null, true);
            }

			if (DS.sortingkind.Rows.Count==0) return;
			DataRow Rtipo = DS.sortingkind.Rows[0];
			if (Rtipo["totalexpression"].ToString()==""){
				importoresiduo=importototale-importooriginale;
			}

			decimal percentuale = 100;
			if (importototale!=0) percentuale= importomovimento/importototale*100;
			decimal rounded = Math.Round(percentuale, 4);
			txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1"); 

			GetData.SetStaticFilter(DS.sorting, filter);
		}

		private void txtPercentuale_Leave(object sender, System.EventArgs e) {
			if (inChiusura) return;
			// ripristina l'importo originale
			if (!txtPercentuale.Modified) return;
			if(!checkpercentuale()) {
				decimal percentuale = 100;
				if (importototale!=0) percentuale= importomovimento/importototale*100;
				decimal rounded = Math.Round(percentuale, 4);                
				// calcola la percentuale in base all'importo
				txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1");                
			}
			else {
				// calcola l'importo in base alla percentuale
				decimal perc = Decimal.Parse(txtPercentuale.Text,
					NumberStyles.Number,
					NumberFormatInfo.CurrentInfo);
				importomovimento = perc* importototale /100;
				txtImporto.Text = importomovimento.ToString("c");                
			}		
		}

		private bool checkpercentuale() {           
			bool OK = false;
			if (txtPercentuale.Text == "") return false;           
			decimal percentmax=0;
			
			if (importototale!=0) percentmax = (importoresiduo + importooriginale)/importototale*100; 
			string errmsg = "Il valore percentuale dovrebbe essere un numero compreso \r" +
				"tra 0 e " + percentmax.ToString("n") + ". Proseguo comunque?";
			try {
				decimal percent = Decimal.Parse(txtPercentuale.Text,
					NumberStyles.Number,
					NumberFormatInfo.CurrentInfo);
				if ((percent < 0) || (percent > percentmax)) {
					OK = (show(errmsg,"Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
				}
				else {
					OK=true;
				}
  
			}
			catch {                
				show("E' necessario digitare un numero" ,"Avviso",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}            
			return OK;
		}

		private void txtImporto_Leave(object sender, System.EventArgs e) {
			if(inChiusura) return;
			if (!txtImporto.Modified) return;              
			if(!checkimporto()) {
				// ripristina l'importo originale
				txtImporto.Text = importomovimento.ToString("c");
			}
			else {
				importomovimento= CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					txtImporto.Text,HelpForm.GetStandardTag(txtImporto.Tag)));
				decimal percentuale = 100;
				if (importototale!=0) percentuale= importomovimento/importototale*100;

				decimal rounded = Math.Round(percentuale, 4);                
				// calcola la percentuale in base all'importo
				txtPercentuale.Text = HelpForm.StringValue(rounded,"x.y.fixed.4...1");            
			}
		}

		private bool checkimporto() {
			bool OK = false;

			if (txtImporto.Text == "") return false;
			string errmsg = "L'importo dovrebbe essere un numero compreso \r" +
				"tra 0 e " + (importoresiduo + importooriginale).ToString("c") + ". Proseguo comunque?";
			try {
				decimal importo = CfgFn.GetNoNullDecimal( HelpForm.GetObjectFromString(typeof(Decimal),
					txtImporto.Text,HelpForm.GetStandardTag(txtImporto.Tag)));
				if ((importo >= 0) && (importo <= (importoresiduo + importooriginale))) {
					OK = true;
				}
				else{
					OK = (show(errmsg,"Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
				}
  
			}
			catch {                
				show("E' necessario inserire un numero","Avviso",
					System.Windows.Forms.MessageBoxButtons.OK,
					System.Windows.Forms.MessageBoxIcon.Exclamation);
				return false;
			}
			return OK;
		}
	}
}
