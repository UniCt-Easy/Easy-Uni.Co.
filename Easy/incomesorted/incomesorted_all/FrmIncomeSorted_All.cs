
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

namespace incomesorted_all {
	/// <summary>
	/// Summary description for FrmIncomeSorted_All.
	/// </summary>
	public class FrmIncomeSorted_All : MetaDataForm {
		MetaData Meta;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtSubMov;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox grpClassificazione;
		private System.Windows.Forms.TextBox txtDescrClass;
		private System.Windows.Forms.TextBox txtCodiceClass;
		private System.Windows.Forms.Button btnClassificazione;
		public incomesorted_all.vistaForm DS;
		private System.Windows.Forms.ComboBox cmbTipoMov;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOk;
        private TextBox txtCurrAmount;
        private Label label1;

        int fase;
        DataRow rIncome = null;
        DataTable SourceImpClass = null;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmIncomeSorted_All() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
        CQueryHelper QHC;
        QueryHelper QHS;

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIncomeSorted_All));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtSubMov = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoMov = new System.Windows.Forms.ComboBox();
            this.DS = new incomesorted_all.vistaForm();
            this.button1 = new System.Windows.Forms.Button();
            this.grpClassificazione = new System.Windows.Forms.GroupBox();
            this.txtDescrClass = new System.Windows.Forms.TextBox();
            this.txtCodiceClass = new System.Windows.Forms.TextBox();
            this.btnClassificazione = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtCurrAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpClassificazione.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCurrAmount);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtSubMov);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtDescrizione);
            this.groupBox2.Controls.Add(this.txtImporto);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(8, 152);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 168);
            this.groupBox2.TabIndex = 313;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dati Contabili";
            // 
            // txtSubMov
            // 
            this.txtSubMov.Location = new System.Drawing.Point(264, 16);
            this.txtSubMov.Name = "txtSubMov";
            this.txtSubMov.Size = new System.Drawing.Size(80, 20);
            this.txtSubMov.TabIndex = 1;
            this.txtSubMov.TabStop = false;
            this.txtSubMov.Tag = "incomesorted.idsubclass?incomesortedview.idsubclass";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(240, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 24);
            this.label5.TabIndex = 252;
            this.label5.Text = "#";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 24);
            this.label6.TabIndex = 248;
            this.label6.Text = "Descrizione:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(8, 48);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(336, 53);
            this.txtDescrizione.TabIndex = 2;
            this.txtDescrizione.Tag = "incomesorted.description?incomesortedview.description";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(8, 128);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(104, 20);
            this.txtImporto.TabIndex = 3;
            this.txtImporto.Tag = "incomesorted.amount?incomesortedview.amount";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 250;
            this.label4.Text = "Importo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbTipoMov);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 56);
            this.groupBox1.TabIndex = 312;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            this.groupBox1.Text = "Tipo di Classificazione";
            // 
            // cmbTipoMov
            // 
            this.cmbTipoMov.DataSource = this.DS.sortingkind;
            this.cmbTipoMov.DisplayMember = "description";
            this.cmbTipoMov.Location = new System.Drawing.Point(72, 24);
            this.cmbTipoMov.Name = "cmbTipoMov";
            this.cmbTipoMov.Size = new System.Drawing.Size(280, 21);
            this.cmbTipoMov.TabIndex = 1;
            this.cmbTipoMov.Tag = "sorting.idsorkind?x";
            this.cmbTipoMov.ValueMember = "idsorkind";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 23);
            this.button1.TabIndex = 0;
            this.button1.Tag = "choose.sortingkind.listatipoclassi";
            this.button1.Text = "Tipo";
            // 
            // grpClassificazione
            // 
            this.grpClassificazione.Controls.Add(this.txtDescrClass);
            this.grpClassificazione.Controls.Add(this.txtCodiceClass);
            this.grpClassificazione.Controls.Add(this.btnClassificazione);
            this.grpClassificazione.Location = new System.Drawing.Point(8, 64);
            this.grpClassificazione.Name = "grpClassificazione";
            this.grpClassificazione.Size = new System.Drawing.Size(360, 80);
            this.grpClassificazione.TabIndex = 311;
            this.grpClassificazione.TabStop = false;
            this.grpClassificazione.Tag = "AutoManage.txtCodiceClass.tree";
            this.grpClassificazione.Text = "Classificazione";
            // 
            // txtDescrClass
            // 
            this.txtDescrClass.Location = new System.Drawing.Point(144, 16);
            this.txtDescrClass.Multiline = true;
            this.txtDescrClass.Name = "txtDescrClass";
            this.txtDescrClass.ReadOnly = true;
            this.txtDescrClass.Size = new System.Drawing.Size(200, 53);
            this.txtDescrClass.TabIndex = 5;
            this.txtDescrClass.TabStop = false;
            this.txtDescrClass.Tag = "sorting.description";
            // 
            // txtCodiceClass
            // 
            this.txtCodiceClass.Location = new System.Drawing.Point(16, 48);
            this.txtCodiceClass.Name = "txtCodiceClass";
            this.txtCodiceClass.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceClass.TabIndex = 4;
            this.txtCodiceClass.Tag = "sorting.sortcode?incomesortedview.sortcode";
            // 
            // btnClassificazione
            // 
            this.btnClassificazione.Image = ((System.Drawing.Image)(resources.GetObject("btnClassificazione.Image")));
            this.btnClassificazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClassificazione.Location = new System.Drawing.Point(16, 16);
            this.btnClassificazione.Name = "btnClassificazione";
            this.btnClassificazione.Size = new System.Drawing.Size(104, 23);
            this.btnClassificazione.TabIndex = 0;
            this.btnClassificazione.TabStop = false;
            this.btnClassificazione.Tag = "manage.sorting.tree";
            this.btnClassificazione.Text = "Classificazione:";
            this.btnClassificazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(288, 336);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 315;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(192, 336);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 314;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // txtCurrAmount
            // 
            this.txtCurrAmount.Location = new System.Drawing.Point(246, 145);
            this.txtCurrAmount.Name = "txtCurrAmount";
            this.txtCurrAmount.ReadOnly = true;
            this.txtCurrAmount.Size = new System.Drawing.Size(104, 20);
            this.txtCurrAmount.TabIndex = 255;
            this.txtCurrAmount.Tag = "";
            this.txtCurrAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(236, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 30);
            this.label1.TabIndex = 256;
            this.label1.Text = "Importo (Comprensivo delle variazioni):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // FrmIncomeSorted_All
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(376, 366);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpClassificazione);
            this.Name = "FrmIncomeSorted_All";
            this.Text = "FrmIncomeSorted_All";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpClassificazione.ResumeLayout(false);
            this.grpClassificazione.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        decimal currAmount;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
			DataRow r = Meta.SourceRow;
            rIncome = r.GetParentRow("incomeviewincomesorted");
            object nphase = rIncome["nphase"];

            
            SourceImpClass = r.Table;
            
            fase = CfgFn.GetNoNullInt32(nphase);



			GetData.CacheTable(DS.sortingkind, QHS.CmpEq("nphaseincome",nphase), null, true);
            currAmount = CfgFn.GetNoNullDecimal(rIncome["curramount"]);
		}

        public void MetaData_AfterActivation() {
            txtCurrAmount.Text = currAmount.ToString("c");
        }

		public void MetaData_AfterFill() {
			SetCodiciClass();
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (Meta.IsEmpty) return;

			if (T.TableName == "sortingkind") {
				if (Meta.DrawStateIsDone) {
					if (!Meta.IsEmpty){
						DS.incomesorted.Rows[0]["idsor"] = 0;
					}
					txtCodiceClass.Text = "";
					DS.sorting.Clear();
                    SetCodiciClass();
				}
				
			}
		}

		void SetCodiciClass(){
			btnClassificazione.Enabled = (cmbTipoMov.SelectedIndex > 0);
			txtCodiceClass.ReadOnly = (cmbTipoMov.SelectedIndex <= 0);
			
			if (cmbTipoMov.SelectedIndex<=0){
				txtCodiceClass.Text = "";
				txtDescrClass.Text = "";
			}
			else {
                object idsorkind = cmbTipoMov.SelectedValue;
                string filter = QHS.CmpEq("idsorkind", idsorkind);
                DataTable Available = CalcAvailableIDClassesFor(idsorkind); // Meta.Conn.RUN_SELECT("sorting", "*", null, filter, null, null, true);
                if (Available == null) {
                    Available = Meta.Conn.RUN_SELECT("sorting", "*", null, filter, null, null, true);
                }
                btnClassificazione.Tag = "manage.sorting.tree." + filter;
                grpClassificazione.Tag = "AutoManage.txtCodiceClass.tree." + filter;
                Meta.SetAutoMode(grpClassificazione);
                DS.sorting.ExtendedProperties[MetaData.ExtraParams] = Available;


			}
		}

        DataTable CalcAvailableIDClassesFor(object codicetipoclass) {
            Meta.GetFormData(true);
            DataRow currClass = DS.incomesorted.Rows[0];

            //If codicetipoclass not allowed, leave empty ClassMovimentiAllowed 
            DataRow[] CurrTipoClasses = DS.sortingkind.Select(QHC.CmpEq("idsorkind", codicetipoclass));
            if (CurrTipoClasses.Length == 0) return null;

            int currfase = fase;

            //ClassMovimentiAllowed = ClassMovimenti.Clone();
            //ClassMovimentiAllowed.Clear();
            DataTable ClassMovimentiAllowed = Meta.Conn.CreateTableByName("sorting", "*");


            object IDForSP = DBNull.Value;
            if (!Meta.InsertMode) IDForSP = currClass["idinc"];

            decimal curramount = CfgFn.GetNoNullDecimal(currClass["amount"]);

            //Calls sp_root_tipoclasses_spesa to get roots classes available
            DataSet OutDS = Meta.Conn.CallSP("compute_root_idsor_income",
                new object[9] {  
								   codicetipoclass,
								   Meta.GetSys("esercizio"),
								   IDForSP,
								   rIncome["idreg"],
								   rIncome["idupb"],
								   currfase,
								   rIncome["idfin"],
								   rIncome["idman"],
								   curramount
							   });

            if ((OutDS != null) && (OutDS.Tables.Count > 0)) {
                QueryCreator.MergeDataTable(ClassMovimentiAllowed, OutDS.Tables[0]);
            }

            foreach (DataRow CurrImpClass in SourceImpClass.Rows) {
                if (CurrImpClass.RowState == DataRowState.Deleted) continue;


                int currfaseImpclass = fase;

                try {
                    OutDS = Meta.Conn.CallSP("compute_filtered_idsor_income",
                        new object[33]{	  
										  codicetipoclass,
										  Meta.GetSys("esercizio"),
										  IDForSP, // CurrSpesa["idspesa"],
										  rIncome["idreg"],
										  rIncome["idupb"],
										  currfase,
										  rIncome["idfin"],
										  rIncome["idman"],
										  curramount,										  
										  codicetipoclass,
										  CurrImpClass["idsor"],
										  CurrImpClass["idsubclass"],
										  CurrImpClass["amount"],
										  CurrImpClass["description"],
										  CurrImpClass["flagnodate"],
										  CurrImpClass["tobecontinued"],
										  CurrImpClass["start"],
										  CurrImpClass["stop"],
										  CurrImpClass["valuen1"],
										  CurrImpClass["valuen2"],
										  CurrImpClass["valuen3"],
										  CurrImpClass["valuen4"],
										  CurrImpClass["valuen5"],
										  CurrImpClass["values1"],
										  CurrImpClass["values2"],
										  CurrImpClass["values3"],
										  CurrImpClass["values4"],
										  CurrImpClass["values5"],
										  CurrImpClass["valuev1"],
										  CurrImpClass["valuev2"],
										  CurrImpClass["valuev3"],
										  CurrImpClass["valuev4"],
										  CurrImpClass["valuev5"],
					});
                }
                catch (Exception E) {
                    show(E.Message);
                }
                if ((OutDS != null) && (OutDS.Tables.Count > 0)) {
                    if (ClassMovimentiAllowed == null) ClassMovimentiAllowed = OutDS.Tables[0];
                    else QueryCreator.MergeDataTable(ClassMovimentiAllowed, OutDS.Tables[0]);
                }
            }
            return ClassMovimentiAllowed;
        }
	}
}
