/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;
using System.Linq;
using System.Collections.Generic;
using SortingMatrix;

namespace invoicesorting_default
{
	/// <summary>
	/// Summary description for Frm_invoicesorting_default.
	/// </summary>
	public class Frm_invoicesorting_default : MetaDataForm
	{
		
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbTipo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox gboxclass;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Button btnCodice;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
		public  vistaForm DS;

        DataAccess Conn;

        //bool HasBeenActivated;

        bool primolivello = false;
        bool secondolivello = false;
        bool terzolivello = false;
        bool quartolivello = false;

        bool formcorto = false;

        Size minSize = new Size(487, 328);
        private GroupBox groupBox1;
        private Manager<TextBox> manager;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public Frm_invoicesorting_default()
		{
			InitializeComponent();
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.DS = new invoicesorting_default.vistaForm();
            this.label1 = new System.Windows.Forms.Label();
            this.gboxclass = new System.Windows.Forms.GroupBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.btnCodice = new System.Windows.Forms.Button();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxclass.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 22;
            this.textBox1.Tag = "invoicesorting.quota.fixed.2..%.100";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(36, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Quota:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // cmbTipo
            // 
            this.cmbTipo.DataSource = this.DS.sortingapplicabilityview;
            this.cmbTipo.DisplayMember = "description";
            this.cmbTipo.Location = new System.Drawing.Point(103, 15);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(328, 21);
            this.cmbTipo.TabIndex = 21;
            this.cmbTipo.Tag = "sorting.idsorkind?x";
            this.cmbTipo.ValueMember = "idsorkind";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(36, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Tipo:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // gboxclass
            // 
            this.gboxclass.Controls.Add(this.txtCodice);
            this.gboxclass.Controls.Add(this.btnCodice);
            this.gboxclass.Controls.Add(this.txtDescrizione);
            this.gboxclass.Location = new System.Drawing.Point(15, 87);
            this.gboxclass.Name = "gboxclass";
            this.gboxclass.Size = new System.Drawing.Size(440, 85);
            this.gboxclass.TabIndex = 25;
            this.gboxclass.TabStop = false;
            this.gboxclass.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(8, 48);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.ReadOnly = true;
            this.txtCodice.Size = new System.Drawing.Size(112, 20);
            this.txtCodice.TabIndex = 2;
            this.txtCodice.Tag = "sorting.sortcode?x";
            // 
            // btnCodice
            // 
            this.btnCodice.Enabled = false;
            this.btnCodice.Location = new System.Drawing.Point(8, 16);
            this.btnCodice.Name = "btnCodice";
            this.btnCodice.Size = new System.Drawing.Size(80, 23);
            this.btnCodice.TabIndex = 1;
            this.btnCodice.Tag = "manage.sorting.tree";
            this.btnCodice.Text = "Codice";
            this.btnCodice.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(152, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(272, 48);
            this.txtDescrizione.TabIndex = 3;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "sorting.description";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(12, 497);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 23;
            this.btnOk.TabStop = false;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(93, 497);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 24;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Annulla";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(15, 178);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 306);
            this.groupBox1.TabIndex = 1052;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Frm_invoicesorting_default
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(470, 532);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gboxclass);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.Name = "Frm_invoicesorting_default";
            this.Text = "Frm_invoicesorting_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxclass.ResumeLayout(false);
            this.gboxclass.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion

        public void MetaData_AfterRowSelect(DataTable T, DataRow R){

            if (T!= DS.sortingapplicabilityview) return;

            if (T.TableName == "sortingapplicabilityview") {
                if (MetaData.GetMetaData(this).DrawState == MetaData.form_drawstates.done) {
                    if ((!MetaData.Empty(this))) {
                        DS.invoicesorting.Rows[0]["idsor"] = DBNull.Value;
                    }
                    txtCodice.Text = "";
                    txtDescrizione.Text = "";
                    DS.sorting.Clear();
                }
                SetCodice();

                AggiornaEtichette();
            }
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

        public void MetaData_AfterFill() {
			SetCodice();
        }

        public void MetaData_AfterActivation() {

            AggiornaEtichette();

            if (Meta.EditMode || Meta.InsertMode) {
                freshForm();
            }
        }

        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();

            QHC = new CQueryHelper();

            string filterCT = QHS.CmpEq("tablename", "invoice");
            GetData.CacheTable(DS.sortingapplicabilityview, filterCT, null, true);

            GetData.CacheTable(DS.sortingkind, null, null, true);

            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                    QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive, filterCT)), QHS.CmpEq("idsorkind", 0)));

            QueryCreator.SetFilterForInsert(DS.sortingapplicabilityview, filterI);
        }

        //TextBox GetTxtByName(string Name) {
        //    System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
        //    if (Ctrl == null) return null;
        //    if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return null;
        //    TextBox T = (TextBox)Ctrl.GetValue(this);
        //    return T;
        //}
        //Label GetLabByName(string Name) {
        //    System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
        //    if (Ctrl == null) return null;
        //    if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;
        //    Label L = (Label)Ctrl.GetValue(this);
        //    return L;
        //}
        void AggiornaEtichette() {

            if (cmbTipo.SelectedIndex <= 0) {
                //NascondiEtichette();
                manager = new Manager<TextBox>(groupBox1, "invoicesorting", null,
                    Manager<TextBox>.OptionControlAction(Meta.myHelpForm.AddEvents)
                );
                return;
            }
            string codtipomov = cmbTipo.SelectedValue.ToString();
            DataRow Rtipo = DS.sortingkind.Select(QHC.CmpEq("idsorkind", codtipomov))[0];

            manager = new Manager<TextBox>(groupBox1, "invoicesorting", Rtipo,
                Manager<TextBox>.OptionControlAction(Meta.myHelpForm.AddEvents)
            );

            //foreach (string kind in new string[] { "n", "s", "v", "d" }) {
            //    for (int i = 1; i <= 5; i++) {
            //        string suffix = kind + i.ToString();
            //        TextBox T = GetTxtByName("valore" + suffix.ToUpper());
            //        Label L = GetLabByName("label" + suffix.ToUpper());
            //        if (Rtipo["label" + suffix].ToString() == "") {
            //            L.Visible = false;
            //            T.Visible = false;
            //            T.Text = "";
            //        }
            //        else {
            //            L.Visible = true;
            //            L.Text = Rtipo["label" + suffix].ToString();
            //            T.Visible = true;
            //            T.Tag = "invoicesorting.value" + kind + i.ToString();
            //            Meta.myHelpForm.AddEvents(T);

            //            if (kind == "v") T.Tag = T.Tag.ToString() + ".N";
            //            L.Tag = "sortingkind.label" + kind + i.ToString();

            //            if (Rtipo["forced" + suffix].ToString().ToLower() == "s") {
            //                T.Visible = true;
            //                T.ReadOnly = false;
            //                HelpForm.SetDenyNull(DS.Tables["invoicesorting"].Columns["value" + suffix], true);
            //            }
            //        }
            //    }
            //}
        }
        //void NascondiEtichette() {
        //    foreach (string kind in new string[] { "N", "S", "V", "D" }) {
        //        for (int i = 1; i <= 5; i++) {
        //            string suffix = kind + i.ToString();
        //            TextBox T = GetTxtByName("valore" + suffix);
        //            Label L = GetLabByName("label" + suffix);
        //            L.Visible = false;
        //            T.Visible = false;
        //            T.Text = "";
        //        }
        //    }
        //}

        ///// <summary>
        ///// Restituisce un textbox ed imposta in automatico le variabili primo,secondo e terzolivello
        ///// </summary>
        ///// <param name="i"></param>
        ///// <returns></returns>
        //TextBox GetTextBoxNum(int i) {
        //    int col = (i - 1) / 5;
        //    int row = ((i - 1) % 5) + 1;
        //    string suffix = string.Empty;
        //    switch (col) {
        //        case 0:
        //            suffix = "N";
        //            primolivello = true;
        //            break;
        //        case 1:
        //            suffix = "S";
        //            secondolivello = true;
        //            break;
        //        case 2:
        //            suffix = "V";
        //            terzolivello = true;
        //            break;
        //        case 3: // BOH
        //            suffix = "D";
        //            quartolivello = true;
        //            break;
        //    }
        //    suffix += row.ToString();
        //    TextBox T = GetTxtByName("valore" + suffix);
        //    return T;
        //}

        ///// <summary>
        ///// Restituisce un textbox ed imposta in automatico le variabili fromcorto,
        /////			primo,secondo e terzolivello
        ///// </summary>
        ///// <param name="i"></param>
        ///// <returns></returns>
        //Label GetLabelNum(int i) {
        //    int col = (i - 1) / 5;
        //    int row = ((i - 1) % 5) + 1;
        //    if (row > 3) formcorto = false;
        //    string suffix = string.Empty;
        //    switch (col) {
        //        case 0:
        //            suffix = "N";
        //            break;
        //        case 1:
        //            suffix = "S";
        //            break;
        //        case 2:
        //            suffix = "V";
        //            break;
        //        case 3: // BOH
        //            suffix = "D";
        //            break;
        //    }
        //    suffix += row.ToString();
        //    Label L = GetLabByName("label" + suffix);
        //    return L;
        //}
    }
}
