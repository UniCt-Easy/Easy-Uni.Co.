
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace no_table_sortingkind_listaclassi {//tipoclassmovimenti//
	/// <summary>
	/// Summary description for frmtipoclassmovimenti.
	/// </summary>
	public class Frm_no_table_sortingkind_listaclassi : System.Windows.Forms.Form {
		private System.Windows.Forms.CheckBox ckbEntrata;
		private System.Windows.Forms.CheckBox ckbSpesa;
		public vistaForm DS;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnOK;
		MetaData Meta;
		DataAccess Conn;
		DataTable DescrClass;
		string esercizio;
        CQueryHelper QHC;
        QueryHelper QHS;
        private System.Windows.Forms.ListView listViewClassificazioni;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_no_table_sortingkind_listaclassi() {
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.ckbEntrata = new System.Windows.Forms.CheckBox();
			this.ckbSpesa = new System.Windows.Forms.CheckBox();
			this.listViewClassificazioni = new System.Windows.Forms.ListView();
			this.DS = new vistaForm();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ckbEntrata
			// 
			this.ckbEntrata.Location = new System.Drawing.Point(8, 24);
			this.ckbEntrata.Name = "ckbEntrata";
			this.ckbEntrata.Size = new System.Drawing.Size(72, 16);
			this.ckbEntrata.TabIndex = 0;
			this.ckbEntrata.Text = "di Entrata";
			// 
			// ckbSpesa
			// 
			this.ckbSpesa.Location = new System.Drawing.Point(8, 48);
			this.ckbSpesa.Name = "ckbSpesa";
			this.ckbSpesa.Size = new System.Drawing.Size(72, 16);
			this.ckbSpesa.TabIndex = 1;
			this.ckbSpesa.Text = "di Spesa";
			// 
			// listViewClassificazioni
			// 
			this.listViewClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewClassificazioni.Location = new System.Drawing.Point(8, 24);
			this.listViewClassificazioni.Name = "listViewClassificazioni";
			this.listViewClassificazioni.Size = new System.Drawing.Size(304, 344);
			this.listViewClassificazioni.TabIndex = 1;
			this.listViewClassificazioni.Tag = "";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(416, 88);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 4;
			this.btnAnnulla.Text = "Annulla";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(328, 88);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 3;
			this.btnOK.Tag = "";
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(288, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Elenco dei tipi di classificazione:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.ckbSpesa);
			this.groupBox1.Controls.Add(this.ckbEntrata);
			this.groupBox1.Location = new System.Drawing.Point(320, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(176, 72);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Movimenti";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(328, 200);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(168, 168);
			this.textBox1.TabIndex = 21;
			this.textBox1.TabStop = false;
			this.textBox1.Text = @"Per procedere alla classificazione automatica, selezionare dall'elenco dei tipi di classificazione, i tipi su cui eseguire la procedura; selezionare dal gruppo dei movimenti il tipo di movimento da classificare (se di entrata o di spesa o entrambe) ed infine premere sul bottone Ok. Il bottone Annulla, annulla le scelte fatte, non classifica niente e chiude la maschera.";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.Location = new System.Drawing.Point(328, 136);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 48);
			this.label2.TabIndex = 22;
			this.label2.Text = "LEGGERE ATTENTAMENTE PRIMA DI PROCEDERE ALLA CLASSIFICAZIONE AUTOMATICA";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// frmtipoclassmovimenti
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 374);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listViewClassificazioni);
			this.Name = "frmtipoclassmovimenti";
			this.Text = "frmtipoclassmovimenti";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			this.Conn=Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            DescrClass =Conn.RUN_SELECT("sortingkind","idsorkind,description",null,
				"(nphaseincome is not null or nphaseexpense is not null)", null, null, true);
			esercizio = Meta.GetSys("esercizio").ToString();
		}

		public void MetaData_AfterActivation() {
			listViewClassificazioni.Clear();
			listViewClassificazioni.BeginUpdate();
			
			foreach(DataRow R in DescrClass.Select()) {
				ListViewItem listViewOD = new ListViewItem(R["description"].ToString());
				listViewOD.Tag=R["idsorkind"].ToString();
				listViewClassificazioni.Items.Add(listViewOD);
			}
			
			listViewClassificazioni.CheckBoxes= true;
			listViewClassificazioni.Columns.Add("Descrizione",300,HorizontalAlignment.Left);
			listViewClassificazioni.View=View.Details;
			listViewClassificazioni.EndUpdate();
			listViewClassificazioni.Refresh();
		
		}


        private void btnOK_Click(object sender, System.EventArgs e) {
            if (DescrClass.Rows.Count == 0) return;
            if (ckbEntrata.Checked) {
                foreach (object LVI in listViewClassificazioni.Items) {
                    ListViewItem LVI1 = (ListViewItem)LVI;

                    string RR = (string)LVI1.Tag;
                    if (LVI1.Checked) {
                        Conn.CallSP("sort_auto_allincome", new object[] { RR, esercizio }, false, 600);
                    }

                }
            }
            if (ckbSpesa.Checked) {
                foreach (object LVI in listViewClassificazioni.Items) {
                    ListViewItem LVI2 = (ListViewItem)LVI;
                    string RR1 = (string)LVI2.Tag;
                    if (LVI2.Checked) {
                        Conn.CallSP("sort_auto_allexpense", new object[] { RR1, esercizio }, false, 600);
                    }

                }
            }
            MessageBox.Show("Operazione effettuata.");
		}

    }
}
