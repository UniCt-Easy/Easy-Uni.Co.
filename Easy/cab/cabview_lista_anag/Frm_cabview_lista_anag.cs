
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

namespace cabview_lista_anag {//sportellobancalista_anagrafica//
	/// <summary>
	/// Summary description for frmsportellobancalista_anagrafica.
	/// </summary>
	public class Frm_cabview_lista_anag : MetaDataForm {
		private object ultimoIdComune;
		public vistaForm DS;
		private System.Windows.Forms.ImageList images;
		private System.ComponentModel.IContainer components;
        private GroupBox gboxBanca;
        private TextBox txtBanca;
        private Button BancaButton;
        private TextBox txtDescrBanca;
        private CheckBox checkBox1;
        private GroupBox groupBox1;
        private Label labelProvincia;
        private TextBox textBoxProvincia;
        private TextBox textBox6;
        private Label label2;
        private TextBox textBoxCap;
        private Label label8;
        private TextBox txtLocalita;
        private Label label6;
        private Button buttonAggiornaComune;
        private TextBox textBox5;
        private TextBox textBox4;
        private Label label4;
        private TextBox textBox3;
        private Label label5;
        private Label label3;
        private MetaData Meta;

		public Frm_cabview_lista_anag() {
			InitializeComponent();
			QueryCreator.SetTableForPosting(DS.cabview, "cab");
			QueryCreator.SetColumnNameForPosting(DS.cabview.Columns["city"], "");
            QueryCreator.SetColumnNameForPosting(DS.cabview.Columns["country"], "");
            HelpForm.SetDenyNull(DS.cabview.Columns["flagusable"], true);
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_cabview_lista_anag));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.DS = new cabview_lista_anag.vistaForm();
            this.gboxBanca = new System.Windows.Forms.GroupBox();
            this.txtBanca = new System.Windows.Forms.TextBox();
            this.BancaButton = new System.Windows.Forms.Button();
            this.txtDescrBanca = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelProvincia = new System.Windows.Forms.Label();
            this.textBoxProvincia = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCap = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtLocalita = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonAggiornaComune = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxBanca.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            this.images.Images.SetKeyName(9, "");
            this.images.Images.SetKeyName(10, "");
            this.images.Images.SetKeyName(11, "");
            this.images.Images.SetKeyName(12, "");
            this.images.Images.SetKeyName(13, "");
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // gboxBanca
            // 
            this.gboxBanca.Controls.Add(this.txtBanca);
            this.gboxBanca.Controls.Add(this.BancaButton);
            this.gboxBanca.Controls.Add(this.txtDescrBanca);
            this.gboxBanca.Location = new System.Drawing.Point(12, 12);
            this.gboxBanca.Name = "gboxBanca";
            this.gboxBanca.Size = new System.Drawing.Size(489, 66);
            this.gboxBanca.TabIndex = 71;
            this.gboxBanca.TabStop = false;
            this.gboxBanca.Tag = "AutoChoose.txtBanca.default";
            // 
            // txtBanca
            // 
            this.txtBanca.Location = new System.Drawing.Point(7, 42);
            this.txtBanca.Name = "txtBanca";
            this.txtBanca.Size = new System.Drawing.Size(100, 20);
            this.txtBanca.TabIndex = 3;
            this.txtBanca.Tag = "bank.idbank?cabview.idbank";
            // 
            // BancaButton
            // 
            this.BancaButton.Location = new System.Drawing.Point(6, 13);
            this.BancaButton.Name = "BancaButton";
            this.BancaButton.Size = new System.Drawing.Size(101, 23);
            this.BancaButton.TabIndex = 2;
            this.BancaButton.Tag = "choose.bank.default.(flagusable<>\'N\')";
            this.BancaButton.Text = "ABI Cassiere";
            // 
            // txtDescrBanca
            // 
            this.txtDescrBanca.Location = new System.Drawing.Point(123, 9);
            this.txtDescrBanca.Multiline = true;
            this.txtDescrBanca.Name = "txtDescrBanca";
            this.txtDescrBanca.ReadOnly = true;
            this.txtDescrBanca.Size = new System.Drawing.Size(346, 52);
            this.txtDescrBanca.TabIndex = 2;
            this.txtDescrBanca.TabStop = false;
            this.txtDescrBanca.Tag = "bank.description";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(509, 282);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(53, 17);
            this.checkBox1.TabIndex = 70;
            this.checkBox1.Tag = "cabview.flagusable:S:N";
            this.checkBox1.Text = "Attivo";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.labelProvincia);
            this.groupBox1.Controls.Add(this.textBoxProvincia);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxCap);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtLocalita);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(12, 188);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 72);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoChoose.txtLocalita.default";
            // 
            // labelProvincia
            // 
            this.labelProvincia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProvincia.Location = new System.Drawing.Point(414, 16);
            this.labelProvincia.Name = "labelProvincia";
            this.labelProvincia.Size = new System.Drawing.Size(48, 23);
            this.labelProvincia.TabIndex = 69;
            this.labelProvincia.Text = "Sigla Pr.";
            this.labelProvincia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxProvincia
            // 
            this.textBoxProvincia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxProvincia.Location = new System.Drawing.Point(470, 16);
            this.textBoxProvincia.Name = "textBoxProvincia";
            this.textBoxProvincia.Size = new System.Drawing.Size(64, 20);
            this.textBoxProvincia.TabIndex = 2;
            this.textBoxProvincia.TabStop = false;
            this.textBoxProvincia.Tag = "geo_cityview.provincecode";
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Location = new System.Drawing.Point(72, 40);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(342, 20);
            this.textBox6.TabIndex = 3;
            this.textBox6.Tag = "cabview.location";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 67;
            this.label2.Text = "Località";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBoxCap
            // 
            this.textBoxCap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCap.Location = new System.Drawing.Point(470, 40);
            this.textBoxCap.Name = "textBoxCap";
            this.textBoxCap.Size = new System.Drawing.Size(64, 20);
            this.textBoxCap.TabIndex = 4;
            this.textBoxCap.Tag = "cabview.cap";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(430, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 64;
            this.label8.Text = "CAP";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLocalita
            // 
            this.txtLocalita.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLocalita.Location = new System.Drawing.Point(72, 16);
            this.txtLocalita.Name = "txtLocalita";
            this.txtLocalita.Size = new System.Drawing.Size(342, 20);
            this.txtLocalita.TabIndex = 1;
            this.txtLocalita.Tag = "geo_city.title?cabview.city";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 23);
            this.label6.TabIndex = 61;
            this.label6.Text = "Comune";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonAggiornaComune
            // 
            this.buttonAggiornaComune.Location = new System.Drawing.Point(12, 268);
            this.buttonAggiornaComune.Name = "buttonAggiornaComune";
            this.buttonAggiornaComune.Size = new System.Drawing.Size(104, 23);
            this.buttonAggiornaComune.TabIndex = 66;
            this.buttonAggiornaComune.Text = "Aggiorna Comune";
            this.buttonAggiornaComune.Click += new System.EventHandler(this.buttonAggiornaComune_Click);
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(12, 164);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(542, 20);
            this.textBox5.TabIndex = 64;
            this.textBox5.Tag = "cabview.address";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(132, 108);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(422, 20);
            this.textBox4.TabIndex = 63;
            this.textBox4.Tag = "cabview.description";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(132, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 68;
            this.label4.Text = "Nome filiale";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 108);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(112, 20);
            this.textBox3.TabIndex = 62;
            this.textBox3.Tag = "cabview.idcab";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 69;
            this.label5.Text = "Indirizzo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 67;
            this.label3.Text = "CAB";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_cabview_lista_anag
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(582, 311);
            this.Controls.Add(this.gboxBanca);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonAggiornaComune);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Name = "Frm_cabview_lista_anag";
            this.Text = "frmsportellobancalista_anagrafica";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxBanca.ResumeLayout(false);
            this.gboxBanca.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			//riempie il combo Banca
			DataTable BancaTable=Meta.Conn.RUN_SELECT("bank","*",null,null, null, true);
			//foreach (DataRow R in BancaTable.Rows)
			//	cmbBanca.Items.Add(R["idbank"]);
		}

		public void MetaData_AfterClear() {
			buttonAggiornaComune.Visible = false;
            //if (IndexChangePilotato == false &&  cmbBanca.SelectedIndex > 0) {
            //    cmbBanca.SelectedIndex = -1;
            //}
            //cmbBanca.Enabled = !Meta.InsertMode;
		}

        private void MySetComboBoxValue(ComboBox C, object S)
        {
            if (S == null) S = DBNull.Value;
            int first = -1;
            for (int i = 0; i < C.Items.Count; i++)
            {
                if (first == -1) first = i;
                object testvalue = ((ComboBox)C).Items[i]; 
                if (testvalue.Equals(S))
                {
                    if (C.SelectedIndex != i)   {
                        C.SelectedIndex = i;
                    }
                    return;
                }
            }
            if ((C.Items.Count == 1) && (first >= 0))
            {
                C.SelectedIndex = first;
                return;
            }
        }

		public void MetaData_AfterActivation() {
            //if(cmbBanca.Items.Count > 0) {
            //    cmbBanca.SelectedIndex = 0;
            //}
		}

		public void MetaData_AfterFill() {
			DataRow lsr = HelpForm.GetLastSelected(DS.cabview);//Meta.myHelpForm.LastSelectedRow;
			object idcomune = lsr["idcity"];
			VisualizzaBottoneComune(idcomune);

			// abilita disabilita il combo Moduli
			//cmbBanca.Enabled = ! Meta.InsertMode;
            object idbank = lsr["idbank"];

            /* Al fine di utilizzare il TextBanca per la ricerca:
             * è stato cambiato il tag al text "...?cabview.bank",
             * previo aggiunta campo bank alla vista. E'stato implementato il metodo MySetComboBoxValue()
             * alla stregua del metodo della libreria, perchè si verificava un errore sul cast da
             * 'System.String' a 'System.Data.DataRowView. 
             * Si verificava un altro problema:se scrivo %sicilia% e poi effettua Ricerca lui fa una ricerca su 
             * cabview col like'%sicilia%' quindi mi fa vedere nel grid tutte le filiali la cui banca è 
             * like %sicilia%, quindi se scorro l'elenco delle filiali del grid nel combo/text della banca
             * vedrò : BANCO DI SICILIA SPA, CREDITO SICILIANO S.P.A.,
             * questa cosa è errata perchè io mi aspetto di vedere nel grid SOLO le filiali di 
             * BANCO DI SICILIA SPA, se nel combo/text leggo BANCO DI SICILIA SPA.
             * Invece,nel Grid vedo le fliali di entrambe poi, dopo aver selezionato la filiale il combo / tex mi
             * dice la banca.
             * Avedno riscontrato la presenta di tanti problemi si è deciso di rendere il text Banca ReadOnly.
            */


            //IndexChangePilotato = true;
            //MySetComboBoxValue(cmbBanca, idbank);
            //IndexChangePilotato = false;
            
		}		

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (!Meta.DrawStateIsDone) return;

			if ((!Meta.IsEmpty) 
				&& (T.TableName == "geo_city") 
				&& (R!=null)) {			
				VisualizzaBottoneComune(R["idcity"]);
				aggiornaCap(R["idcity"]);
			}

			if ((!Meta.IsEmpty) 
				&& (T.TableName == "cabview") 
				&& (R!=null)) {			
				VisualizzaBottoneComune(R["idcity"]);
			}
		}

		//		public void MetaData_AfterGetFormData() {
		//			if (Meta.IsEmpty || cboCAP.SelectedValue==null) return;
		//			string valore=cboCAP.SelectedValue.ToString();
		//			if (valore!="")
		//				DS.sportellobanca.Rows[0]["cap"]=valore;
		//			else
		//				DS.sportellobanca.Rows[0]["cap"]=DBNull.Value;
		//		}

		//		private void ImpostaComboCAP(ComboBox cbo, string idcomune) {
		//			if (idcomune.Trim()=="") return;
		//
		//			try {
		//				if (idcomune=="") return;
		//				DataSet DScap=Meta.Conn.CallSP("sp_cerca_codici_comune",
		//					new object[] {
		//									 HelpForm.GetObjectFromString(typeof(int),idcomune,null),
		//									 HelpForm.GetObjectFromString(typeof(int),"3",null),
		//									 HelpForm.GetObjectFromString(typeof(int),"1",null)
		//								 });
		//				cbo.DataSource=DScap.Tables[0];
		//				cbo.DisplayMember=DScap.Tables[0].Columns[0].Caption;
		//				cbo.ValueMember=DScap.Tables[0].Columns[0].Caption;
		//			} catch {}
		//		}

 
		/// <summary>
		/// Visualizza o meno il bottone di "aggiorna comune" a seconda se esistono o meno comuni successori
		/// del comune in input.
		/// Il comune successore può essere 
		/// o una ex frazione del comune precedente e divenuta comune autonomo, 
		/// o un nuovo comune nato come fusione del comune precedente con un altro comune 
		/// oppure una semplice ridenominazione del comune precedente. 
		/// </summary>
		/// <param name="idComune"></param>
		private void VisualizzaBottoneComune(object idComune) {
			if (idComune != ultimoIdComune) {
				ultimoIdComune = idComune;
				if (idComune is DBNull) {
					buttonAggiornaComune.Visible = false;
					return;
				}
                object val = Meta.Conn.DO_READ_VALUE("geo_cityusable", QHS.CmpEq("idcity", idComune), "idcity");
				buttonAggiornaComune.Visible = (val==null);
			}
		}
		/// <summary>
		/// Il comune selezionato viene eventualmente aggiornato con un comune successore.
		/// Se ce n'è più di uno di comuni successori l'utente deve sceglierne uno dall'elenco propostogli.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonAggiornaComune_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
			object idcomune = HelpForm.GetLastSelected(DS.cabview)["idcity"];
			object[] list = new object[] {idcomune, "S"};
			DataSet DSout = Meta.Conn.CallSP("compute_history_city", list, true, -1);
			if (DSout==null || DSout.Tables.Count==0 || DS.Tables[0].Rows.Count==0) return;
			DataTable T = DSout.Tables[0];
			object idComune = null;
			if (T.Rows.Count==1) {
				idComune = T.Rows[0]["idcity"];
			}
			else {
				string filtro = QHS.FieldInList("idcity", QueryCreator.ColumnValues(T, null, "idcity", true));
				MetaData metaComune = MetaData.GetMetaData(this, "geo_cityview");
				metaComune.DS = DS.Copy();
				metaComune.FilterLocked = true;

				DataRow r = metaComune.SelectOne("storia", filtro, null, null);

				if (r != null) {
					idComune = r["idcity"];
				} 
				else {
					idComune = HelpForm.GetLastSelected(DS.cabview)["idcity"];
				}
			}
			HelpForm.GetLastSelected(DS.cabview)["idcity"] = idComune;
			Meta.FreshForm(true);
			aggiornaCap(idComune);
		}

		/// <summary>
		/// Se il cap presente nel textBoxCap non appartiene al comune con codice idcomune,
		/// e se l'utente desidera aggiornarlo allora textBoxCap viene riempito con il cap
		/// principale del comune selezionato.
		/// </summary>
		/// <param name="idComune"></param>
		private void aggiornaCap(object idComune) {
			object capPrincipale = Meta.Conn.DO_READ_VALUE("geo_city_agency",
                QHS.AppAnd(QHS.CmpEq("idagency", 3), QHS.CmpEq("idcode",1), QHS.CmpEq("idcity", idComune),
                    QHS.IsNull("stop")), "value");
			if (capPrincipale != null) {
				string cap = textBoxCap.Text;
				if (cap == "") {
					textBoxCap.Text = capPrincipale.ToString();
				} 
				else {
					string query = "select value from geo_city_agency where " +
                        QHS.AppAnd(QHS.CmpEq("idagency",3), QHS.CmpEq("idcity", idComune), QHS.CmpEq("value", cap),
                                    QHS.IsNull("stop"));
					DataTable t = Meta.Conn.SQLRunner(query);
					if ((cap != capPrincipale.ToString()) && (t.Rows.Count == 0)) {
						DialogResult dr = show(this, "Il C.A.P. non è coerente con il comune scelto. Si desidera aggiornarlo?", "Avviso", MessageBoxButtons.YesNo);
						if (dr==DialogResult.Yes) {
							textBoxCap.Text = capPrincipale.ToString();
						}
					}
				}
			}
		}
	}
}
