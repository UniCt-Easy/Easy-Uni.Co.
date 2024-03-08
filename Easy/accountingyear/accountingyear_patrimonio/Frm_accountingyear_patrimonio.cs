
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
using System.Data;
using metadatalibrary;
using funzioni_configurazione;

namespace accountingyear_patrimonio//esercizio_patrimonio//
{
	/// <summary>
	/// Summary description for frmesercizio_patrimonio.
	/// </summary>
	public class frmesercizio_patrimonio : MetaDataForm
	{
		public vistaForm DS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnFase1;
		private System.Windows.Forms.Button btnFase2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		int esercizio;
		MetaData Meta;
        private TextBox textBox3;
        private Button btnFase3;
        private Label label3;
        private TextBox textBox4;
        private Button btnFase4;
        private Label label4;
        private Label label5;
        private Button btnFaseRisconti;
        private TextBox textBox5;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public frmesercizio_patrimonio()
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmesercizio_patrimonio));
			this.DS = new accountingyear_patrimonio.vistaForm();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnFase1 = new System.Windows.Forms.Button();
			this.btnFase2 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.btnFase3 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.btnFase4 = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.btnFaseRisconti = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(26, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(131, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Ammortamento Cespiti";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 230);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(147, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Trasferimento Patrimonio";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnFase1
			// 
			this.btnFase1.Location = new System.Drawing.Point(161, 27);
			this.btnFase1.Name = "btnFase1";
			this.btnFase1.Size = new System.Drawing.Size(75, 23);
			this.btnFase1.TabIndex = 2;
			this.btnFase1.Text = "Esegui";
			this.btnFase1.Click += new System.EventHandler(this.btnFase1_Click);
			// 
			// btnFase2
			// 
			this.btnFase2.Location = new System.Drawing.Point(163, 225);
			this.btnFase2.Name = "btnFase2";
			this.btnFase2.Size = new System.Drawing.Size(75, 23);
			this.btnFase2.TabIndex = 3;
			this.btnFase2.Text = "Esegui";
			this.btnFase2.Click += new System.EventHandler(this.btnFase2_Click);
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(245, 16);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(283, 88);
			this.textBox1.TabIndex = 4;
			this.textBox1.Text = resources.GetString("textBox1.Text");
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(247, 214);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(283, 64);
			this.textBox2.TabIndex = 5;
			this.textBox2.Text = "Effettua la chiusura patrimoniale e trasferisce la situazione finale dell\'eserciz" +
    "io in corso come iniziale dell\'esercizio successivo per ogni ente inventariale";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(247, 287);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(283, 64);
			this.textBox3.TabIndex = 8;
			this.textBox3.Text = "Effettua la chiusura dell\'esercizio patrimoniale";
			// 
			// btnFase3
			// 
			this.btnFase3.Location = new System.Drawing.Point(163, 298);
			this.btnFase3.Name = "btnFase3";
			this.btnFase3.Size = new System.Drawing.Size(75, 23);
			this.btnFase3.TabIndex = 7;
			this.btnFase3.Text = "Esegui";
			this.btnFase3.Click += new System.EventHandler(this.btnFase3_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(48, 303);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(111, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Chiusura Esercizio";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(247, 358);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(283, 64);
			this.textBox4.TabIndex = 11;
			this.textBox4.Text = "Effettua la riapertura dell\'esercizio patrimoniale";
			// 
			// btnFase4
			// 
			this.btnFase4.Location = new System.Drawing.Point(163, 369);
			this.btnFase4.Name = "btnFase4";
			this.btnFase4.Size = new System.Drawing.Size(75, 23);
			this.btnFase4.TabIndex = 10;
			this.btnFase4.Text = "Esegui";
			this.btnFase4.Click += new System.EventHandler(this.btnFase4_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(38, 374);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(121, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Riapertura Esercizio";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(12, 121);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(143, 39);
			this.label5.TabIndex = 12;
			this.label5.Text = "Genera Utilizzo Risconti\r\ne Riserve su cespiti\r\nfinanziati";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnFaseRisconti
			// 
			this.btnFaseRisconti.Location = new System.Drawing.Point(161, 125);
			this.btnFaseRisconti.Name = "btnFaseRisconti";
			this.btnFaseRisconti.Size = new System.Drawing.Size(75, 23);
			this.btnFaseRisconti.TabIndex = 13;
			this.btnFaseRisconti.Text = "Esegui";
			this.btnFaseRisconti.Click += new System.EventHandler(this.btnFaseRisconti_Click);
			// 
			// textBox5
			// 
			this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox5.Location = new System.Drawing.Point(245, 120);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(283, 88);
			this.textBox5.TabIndex = 14;
			this.textBox5.Text = "Genera Utilizzo Risconti e Riserve su cespiti finanziati per i contributi conto i" +
    "mpianti relativamente agli ammortamenti effettuati.";
			// 
			// frmesercizio_patrimonio
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 445);
			this.Controls.Add(this.textBox5);
			this.Controls.Add(this.btnFaseRisconti);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.textBox4);
			this.Controls.Add(this.btnFase4);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.btnFase3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnFase2);
			this.Controls.Add(this.btnFase1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "frmesercizio_patrimonio";
			this.Text = "frmesercizio_patrimonio";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

        QueryHelper QHS;
		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
			esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteresercizio = QHS.CmpEq("ayear", esercizio);
            Meta.StartFilter = filteresercizio;
            Meta.SearchEnabled = false;
            Meta.CanInsertCopy = false;
            Meta.CanInsert = false;
            Meta.CanCancel = false;
		}

        public void MetaData_AfterActivation() {
            bool opened = EsercizioAperto(esercizio);
            abilitaBottoni(opened);
        }

		private void btnFase1_Click(object sender, System.EventArgs e)
		{
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            int Nvar = Meta.Conn.RUN_SELECT_COUNT("assetvar",
                            QHS.AppAnd(QHS.BitClear("flag", 0), QHS.CmpEq("yvar", esercizio + 1)), false);
            if (Nvar > 0) {
                show("Esiste già una variazione iniziale nell'anno successivo. Operazione vietata.");
                return;
            }

            string filtro = QHS.AppAnd(
                QHS.CmpEq("year(adate)", Meta.GetSys("esercizio")),
                QHS.BitSet("flag", 0),
                QHS.IsNull("idassetunload"));

            //DataTable t = Meta.Conn.RUN_SELECT("assetamortization", null, null, filtro, null, true);

            //if (t.Rows.Count > 0) {
            //    string messaggio = "La procedura potrebbe effettuare ammortamenti anche ove il valore, sommato agli ammortamenti non inclusi in buoni di scarico, diventi minore di zero, causando incongruenze."
            //        + "\nSi intende procedere ugualmente?";
            //    DialogResult dr = MetaFactory.factory.getSingleton<IMessageShower>().Show(this, messaggio, "Avviso", MessageBoxButtons.YesNoCancel);
            //    if (dr != DialogResult.Yes) return;
            //}
            string includi = "N";
            if (show(this, "Si vogliono marcare gli ammortamenti come da 'Includere in buono di scarico'?", "Richiesta informazioni",
                    MessageBoxButtons.YesNo) == DialogResult.Yes) {
                includi = "S";
            }

			DataSet app = Meta.Conn.CallSP("closeyear_asset_ammortization",new object[]{esercizio,includi},false,0);
			if (!(app == null))
			{
				show("Ammortamento dei Cespiti Eseguita Con Successo!");
			}
			else
			{
				show("Errori nell'ammortamento");
			}
		}

        private void btnFase2_Click(object sender, System.EventArgs e) {
            int esercizio = (int)Meta.GetSys("esercizio");
            string filtro = "not (exists (select * from assetvar where ";
            string filtroInterno = "assetvar.idinventoryagency = inventoryagency.idinventoryagency ";
            filtroInterno = QHS.AppAnd(filtroInterno, QHS.CmpEq("assetvar.yvar", (1 + esercizio)), QHS.BitClear("assetvar.flag", 0));
            filtro += filtroInterno+ "))";
            DataTable t = Meta.Conn.RUN_SELECT("inventoryagency", null, "codeinventoryagency", filtro, null, true);
            if (t.Rows.Count == 0) {
                show(this, "Per tutti gli enti è già stata eseguita la chiusura del patrimonio!");
                return;
            }
            ListViewItem[] items = new ListViewItem[t.Rows.Count];
            for (int i = 0; i < items.Length; i++) {
                items[i] = new ListViewItem(new string[] {
                    t.Rows[i]["codeinventoryagency"].ToString(),
                    t.Rows[i]["description"].ToString(),
                    t.Rows[i]["idinventoryagency"].ToString()});
                items[i].Checked = true;
            }
            ICollection checkedItems = items;
            if (t.Rows.Count > 1) {
                FrmSceltaInventari frmSceltaInventari = new FrmSceltaInventari(items);
				createForm(frmSceltaInventari, this);
                DialogResult dr = frmSceltaInventari.ShowDialog(this);
                if (dr != DialogResult.OK) {
                    return;
                }
                checkedItems = frmSceltaInventari.listView1.CheckedItems;
            }
            bool okMessage = false;
            bool errMessage = false;
            foreach (ListViewItem item in checkedItems) {
                DataSet app = Meta.Conn.CallSP("closeyear_asset", new object[] { esercizio, item.SubItems[2].Text }, false, 600);
                string descrizione = item.SubItems[1].Text;
               
                if (app != null) {
                    okMessage = true;
                    //MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Chiusura del Patrimonio Eseguita Con Successo per l'ente '" + descrizione + "'");
                }
                else {
                    errMessage = true;
                    show(this, "Errori nella chiusura patrimoniale dell'ente '" + descrizione + "'");
                }
            }
            if ((okMessage) && (!errMessage))
                show(this, "Chiusura del Patrimonio Eseguita Con Successo per gli enti selezionati ");
        }

        private void btnFase3_Click(object sender, EventArgs e) {
            chiusuraEsercizio();
        }

        private void btnFase4_Click(object sender, EventArgs e) {
            riaperturaEsercizio();
        }

        private void chiusuraEsercizio() {
            if (DS.accountingyear.Rows.Count == 0) return;
            DataRow rAccountingYear = DS.accountingyear.Rows[0];
            int flag = CfgFn.GetNoNullInt32(rAccountingYear["flag"]);
            if ((flag & 16) == 0) {
                flag |= 0x10;
            }

            rAccountingYear["flag"] = flag;

            PostData Post = Meta.Get_PostData();

            Post.InitClass(DS, Meta.Conn);
            if (!Post.DO_POST()) {
                show(this, "Errore durante la chiusura dell'esercizio" + esercizio);
            }
            else {
                show(this, "Esercizio " + esercizio + " chiuso correttamente");
            }
            this.Close();
        }

        private void riaperturaEsercizio() {
            if (DS.accountingyear.Rows.Count == 0) return;
            DataSet dsOut = DataAccess.CallSP(Meta.Conn, "closeyear_reopenayear", new object [] {esercizio, "P"}, true, 0);

            if (dsOut == null) {
                show(this, "Errore nella S.P. di riapertura dell'esercizio " + esercizio);
            }
            else {
                show(this, "Esercizio " + esercizio + " riaperto correttamente");
            }
            this.Close();
        }

        private void abilitaBottoni(bool enable) {
            btnFase1.Enabled = enable;
            btnFase2.Enabled = enable;
            btnFaseRisconti.Enabled = enable;
            btnFase3.Enabled = enable;
            btnFase4.Enabled = !enable;
        }

        private bool EsercizioAperto(int esercizio) {
            if (DS.accountingyear.Rows.Count == 0) return true;
            DataRow rAccountingYear = DS.accountingyear.Rows[0];
            return ((CfgFn.GetNoNullInt32(rAccountingYear["flag"]) & 16) == 0);
        }

        public void MetaData_AfterClear() {
            MetaData.DoMainCommand(this, "maindosearch.patrimonio");
        }

        private void btnFaseRisconti_Click(object sender, EventArgs e) {
            Meta.Dispatcher.Edit(this, "no_table", "wizardassetgrantdetail", true, null);
        }
    }
}
