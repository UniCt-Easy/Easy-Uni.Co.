/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using metadatalibrary;
using funzioni_configurazione;
using SituazioneViewer;//SituazioneViewer


namespace iva_prorata_default {//iva_prorata//
	/// <summary>
	/// Summary description for frmiva_prorata.
	/// </summary>
	public class Frm_iva_prorata_default : System.Windows.Forms.Form {
		private System.Windows.Forms.ImageList images;
		public vistaForm DS;
		public System.Windows.Forms.Panel MetaDataDetail;
		private System.Windows.Forms.DataGrid dgr;
		public System.Windows.Forms.ToolBar MetaDataToolBar;
		private System.Windows.Forms.ToolBarButton seleziona;
		private System.Windows.Forms.ToolBarButton impostaricerca;
		private System.Windows.Forms.ToolBarButton effettuaricerca;
		private System.Windows.Forms.ToolBarButton modifica;
		private System.Windows.Forms.ToolBarButton inserisci;
		private System.Windows.Forms.ToolBarButton inseriscicopia;
		private System.Windows.Forms.ToolBarButton elimina;
		private System.Windows.Forms.ToolBarButton Salva;
		private System.Windows.Forms.ToolBarButton aggiorna;
		private System.Windows.Forms.TextBox txtProrata;
		private System.Windows.Forms.Label label4;
        private Button btnCopyAll;
		private System.ComponentModel.IContainer components;
        private Button btnVisualizzaProrata;
        private Button btnCalcolaProrata;
        private string tag_perc = "tabella.campo.fixed.2..%.100";
        MetaData Meta;

		public Frm_iva_prorata_default() {
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

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            string filterEsercizio = Meta.QHC.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.iva_prorata,filterEsercizio);

            bool IsAdmin = false;

            if (Meta.GetUsr("consolidamento") != null)
                IsAdmin = (Meta.GetUsr("consolidamento").ToString() == "S");
            if (Meta.GetSys("IsSystemAdmin") != null)
              IsAdmin = IsAdmin ||  (bool)Meta.GetSys("IsSystemAdmin");

            if (!IsAdmin) btnCopyAll.Visible = false;
          if (!IsAdmin) btnCalcolaProrata.Visible = false;
          if (!IsAdmin) btnVisualizzaProrata.Visible = false;

		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_iva_prorata_default));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.DS = new iva_prorata_default.vistaForm();
            this.MetaDataDetail = new System.Windows.Forms.Panel();
            this.btnVisualizzaProrata = new System.Windows.Forms.Button();
            this.btnCalcolaProrata = new System.Windows.Forms.Button();
            this.txtProrata = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgr = new System.Windows.Forms.DataGrid();
            this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
            this.seleziona = new System.Windows.Forms.ToolBarButton();
            this.impostaricerca = new System.Windows.Forms.ToolBarButton();
            this.effettuaricerca = new System.Windows.Forms.ToolBarButton();
            this.modifica = new System.Windows.Forms.ToolBarButton();
            this.inserisci = new System.Windows.Forms.ToolBarButton();
            this.inseriscicopia = new System.Windows.Forms.ToolBarButton();
            this.elimina = new System.Windows.Forms.ToolBarButton();
            this.Salva = new System.Windows.Forms.ToolBarButton();
            this.aggiorna = new System.Windows.Forms.ToolBarButton();
            this.btnCopyAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgr)).BeginInit();
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
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MetaDataDetail.Controls.Add(this.btnVisualizzaProrata);
            this.MetaDataDetail.Controls.Add(this.btnCalcolaProrata);
            this.MetaDataDetail.Controls.Add(this.txtProrata);
            this.MetaDataDetail.Controls.Add(this.label4);
            this.MetaDataDetail.Location = new System.Drawing.Point(285, 56);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(294, 107);
            this.MetaDataDetail.TabIndex = 14;
            // 
            // btnVisualizzaProrata
            // 
            this.btnVisualizzaProrata.Location = new System.Drawing.Point(96, 64);
            this.btnVisualizzaProrata.Name = "btnVisualizzaProrata";
            this.btnVisualizzaProrata.Size = new System.Drawing.Size(182, 23);
            this.btnVisualizzaProrata.TabIndex = 22;
            this.btnVisualizzaProrata.Text = "Visualizza Calcolo Prorata";
            this.btnVisualizzaProrata.UseVisualStyleBackColor = true;
            this.btnVisualizzaProrata.Click += new System.EventHandler(this.btnVisualizzaProrata_Click);
            // 
            // btnCalcolaProrata
            // 
            this.btnCalcolaProrata.Location = new System.Drawing.Point(96, 25);
            this.btnCalcolaProrata.Name = "btnCalcolaProrata";
            this.btnCalcolaProrata.Size = new System.Drawing.Size(182, 23);
            this.btnCalcolaProrata.TabIndex = 21;
            this.btnCalcolaProrata.Text = "Calcolo Centralizzato  Prorata";
            this.btnCalcolaProrata.UseVisualStyleBackColor = true;
            this.btnCalcolaProrata.Click += new System.EventHandler(this.btnCalcolaProrata_Click);
            // 
            // txtProrata
            // 
            this.txtProrata.Location = new System.Drawing.Point(8, 32);
            this.txtProrata.Name = "txtProrata";
            this.txtProrata.Size = new System.Drawing.Size(64, 20);
            this.txtProrata.TabIndex = 19;
            this.txtProrata.Tag = "iva_prorata.prorata.fixed.2..%.100";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "% di Prorata";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgr
            // 
            this.dgr.AllowNavigation = false;
            this.dgr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgr.CaptionVisible = false;
            this.dgr.DataMember = "";
            this.dgr.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgr.Location = new System.Drawing.Point(9, 55);
            this.dgr.Name = "dgr";
            this.dgr.Size = new System.Drawing.Size(274, 137);
            this.dgr.TabIndex = 13;
            this.dgr.Tag = "iva_prorata.default";
            // 
            // MetaDataToolBar
            // 
            this.MetaDataToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.MetaDataToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.seleziona,
            this.impostaricerca,
            this.effettuaricerca,
            this.modifica,
            this.inserisci,
            this.inseriscicopia,
            this.elimina,
            this.Salva,
            this.aggiorna});
            this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(56, 56);
            this.MetaDataToolBar.DropDownArrows = true;
            this.MetaDataToolBar.ImageList = this.images;
            this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
            this.MetaDataToolBar.Name = "MetaDataToolBar";
            this.MetaDataToolBar.ShowToolTips = true;
            this.MetaDataToolBar.Size = new System.Drawing.Size(585, 106);
            this.MetaDataToolBar.TabIndex = 12;
            this.MetaDataToolBar.Tag = "";
            // 
            // seleziona
            // 
            this.seleziona.ImageIndex = 1;
            this.seleziona.Name = "seleziona";
            this.seleziona.Tag = "mainselect";
            this.seleziona.Text = "Seleziona";
            this.seleziona.ToolTipText = "Seleziona l\'elemento desiderato";
            // 
            // impostaricerca
            // 
            this.impostaricerca.ImageIndex = 10;
            this.impostaricerca.Name = "impostaricerca";
            this.impostaricerca.Tag = "mainsetsearch";
            this.impostaricerca.Text = "Imposta Ricerca";
            this.impostaricerca.ToolTipText = "Imposta una nuova ricerca";
            // 
            // effettuaricerca
            // 
            this.effettuaricerca.ImageIndex = 12;
            this.effettuaricerca.Name = "effettuaricerca";
            this.effettuaricerca.Tag = "maindosearch";
            this.effettuaricerca.Text = "Effettua Ricerca";
            this.effettuaricerca.ToolTipText = "Cerca in base ai dati immessi";
            // 
            // modifica
            // 
            this.modifica.ImageIndex = 6;
            this.modifica.Name = "modifica";
            this.modifica.Tag = "mainedit";
            this.modifica.Text = "Modifica";
            this.modifica.ToolTipText = "Modifica l\'elemento selezionato";
            // 
            // inserisci
            // 
            this.inserisci.ImageIndex = 0;
            this.inserisci.Name = "inserisci";
            this.inserisci.Tag = "maininsert";
            this.inserisci.Text = "Inserisci";
            this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
            // 
            // inseriscicopia
            // 
            this.inseriscicopia.ImageIndex = 9;
            this.inseriscicopia.Name = "inseriscicopia";
            this.inseriscicopia.Tag = "maininsertcopy";
            this.inseriscicopia.Text = "Inserisci copia";
            this.inseriscicopia.ToolTipText = "Inserisci un nuovo elemento copiando i dati da quello attuale";
            // 
            // elimina
            // 
            this.elimina.ImageIndex = 3;
            this.elimina.Name = "elimina";
            this.elimina.Tag = "maindelete";
            this.elimina.Text = "Elimina";
            this.elimina.ToolTipText = "Elimina l\'elemento selezionato";
            // 
            // Salva
            // 
            this.Salva.ImageIndex = 2;
            this.Salva.Name = "Salva";
            this.Salva.Tag = "mainsave";
            this.Salva.Text = "Salva";
            this.Salva.ToolTipText = "Salva le modifiche effettuate";
            // 
            // aggiorna
            // 
            this.aggiorna.ImageIndex = 13;
            this.aggiorna.Name = "aggiorna";
            this.aggiorna.Tag = "mainrefresh";
            this.aggiorna.Text = "Aggiorna";
            // 
            // btnCopyAll
            // 
            this.btnCopyAll.Location = new System.Drawing.Point(285, 169);
            this.btnCopyAll.Name = "btnCopyAll";
            this.btnCopyAll.Size = new System.Drawing.Size(296, 23);
            this.btnCopyAll.TabIndex = 21;
            this.btnCopyAll.Text = "Copia la percentuale di Prorata su tutti gli altri Dipartimenti";
            this.btnCopyAll.UseVisualStyleBackColor = true;
            this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
            // 
            // Frm_iva_prorata_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(585, 197);
            this.Controls.Add(this.btnCopyAll);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.dgr);
            this.Controls.Add(this.MetaDataToolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Frm_iva_prorata_default";
            this.Text = "frmiva_prorata";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void btnCopyAll_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.SaveFormData();
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) return;
            DataRow R = HelpForm.GetLastSelected(DS.iva_prorata);

            if (MessageBox.Show("Copiare la percentuale di prorata su tutti i dipartimenti?", "Attenzione", MessageBoxButtons.YesNo) !=
                    DialogResult.Yes) return;

            Meta.Conn.CallSP("copyrow_iva_prorata", new object[1] { R["nprorata"] });
        }

        private void btnCalcolaProrata_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            int esercizio_rif = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"))- 1;
            DataSet Out = Meta.Conn.CallSP("compute_unified_prorata", new object[1] { esercizio_rif });
            if (Out == null) return;
            // Calcolo del prorata
            
            decimal prorata = calcolaProrata(Out.Tables[0]);
            txtProrata.Text = HelpForm.StringValue(prorata, tag_perc);
        }

        private void btnVisualizzaProrata_Click(object sender, EventArgs e)
        {
            if (Meta.IsEmpty) return;
            int esercizio_rif =  CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1 ;
            DataSet Out = Meta.Conn.CallSP("compute_unified_prorata", new object[1] { esercizio_rif });
            if (Out == null) return;
            DataTable tSituation = new DataTable();
           
            addColumn(tSituation);
            popolaTabella(Out,tSituation);

            DataSet D = new DataSet();
            D.Tables.Add(tSituation);
            frmSituazioneViewer view = new frmSituazioneViewer(D);
            view.Show();
        }


        private void addColumn(DataTable tSit)
        {
            tSit.Columns.Add("value", typeof(string));
            tSit.Columns["value"].Caption = "value";

            tSit.Columns.Add("amount", typeof(decimal));
            tSit.Columns["amount"].Caption = "amount";

            tSit.Columns.Add("kind", typeof(char));
            tSit.Columns["kind"].Caption = "kind";
        }

        decimal calcolaProrata(DataTable t)
        {
            decimal numerator = 0;
            decimal denominator = 0;
            decimal prorata = 0;
            foreach (DataRow rDetail in t.Rows)
            {
                if (rDetail["numerator"].ToString() == "S")
                {
                    numerator += CfgFn.GetNoNullDecimal(rDetail["taxabletotal"]);
                }
                if (rDetail["denominator"].ToString() == "S")
                {
                    denominator += CfgFn.GetNoNullDecimal(rDetail["taxabletotal"]);
                }
            }
            if (denominator != 0) prorata = CfgFn.Round((numerator / denominator), 2);
            else prorata = 0;
            return prorata;
        }

        private string calcolaLabelTipoFatture(DataRow rDetail)
        {
           
            string deferred = "";
            string collected = "";
            string intracom = "";
            string variation = "";

            if (rDetail["flagdeferred"].ToString() == "N")
            {
                deferred = "a IVA immediata ";
            }
            else
            {
                deferred = "a IVA differita ";
            }

            if ((rDetail["flagdeferred"].ToString() == "S") && (rDetail["collected"].ToString() == "S"))
            {
                collected = "incassate ";
            }
            if ((rDetail["flagdeferred"].ToString() == "S") && (rDetail["collected"].ToString() == "N"))
            {
                collected = "non incassate ";
            }
            if (rDetail["flagvariation"].ToString() == "S")
            {
                variation = "Note di variazione ";
            }
            else
            {
                variation = "Fatture ";
            }

            switch (rDetail["flagintracom"].ToString())
            {
                case "N":
                    intracom = "";
                    break;
                case "S":
                    intracom = "intra-UE ";
                    break;
                case "X":
                    intracom = "extra-UE ";
                    break;
            }
            return variation + intracom + deferred  + collected;
            }

        private void popolaTabella(DataSet Out, DataTable t)
        {
            // Calcolo del prorata
            decimal numerator = 0;
            decimal denominator = 0;
            
            foreach (DataRow rDetail in Out.Tables[0].Rows)
            {
                if (rDetail["numerator"].ToString() == "S")
                {
                    numerator += CfgFn.GetNoNullDecimal(rDetail["taxabletotal"]);
                }
                if (rDetail["denominator"].ToString() == "S")
                {
                    denominator += CfgFn.GetNoNullDecimal(rDetail["taxabletotal"]);
                }
            }

            decimal prorata = calcolaProrata(Out.Tables[0]);

            DataRow rInt = t.NewRow();
            int esercizio_rif =  CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            rInt["value"]  = "Calcolo del Prorata Esercizio " + esercizio_rif.ToString() ;
            rInt["amount"] = DBNull.Value;
            rInt["kind"]  = "H";
            t.Rows.Add(rInt);

            DataRow rBlank = t.NewRow();
            rBlank["value"] = "";
            rBlank["amount"] = DBNull.Value;
            rBlank["kind"] = "N";
            t.Rows.Add(rBlank);

            DataRow rIntNum = t.NewRow();
            rIntNum["value"] = "Contributi al Numeratore"; ;
            rIntNum["amount"] = DBNull.Value;
            rIntNum["kind"] = "N";
            t.Rows.Add(rIntNum);


            foreach (DataRow rDetail in Out.Tables[0].Rows)
            {

                if (rDetail["numerator"].ToString() == "S")
                {

                    string label = calcolaLabelTipoFatture(rDetail);
                  
                    DataRow r1 = t.NewRow();
                    r1["value"] = rDetail["description"].ToString() + " - " + label;
                    r1["amount"] = rDetail["taxabletotal"];
                    r1["kind"] = " ";
                    t.Rows.Add(r1);
                }
            }
            DataRow rTotNum = t.NewRow();
            rTotNum["value"] = "Totale Numeratore";
            rTotNum["amount"] = numerator;
            rTotNum["kind"] = "S";
            t.Rows.Add(rTotNum);


            DataRow rBlank1 = t.NewRow();
            rBlank1["value"] = "";
            rBlank1["amount"] = DBNull.Value;
            rBlank1["kind"] = "N";
            t.Rows.Add(rBlank1);


            DataRow rIntDen = t.NewRow();
            rIntDen["value"] = "Contributi al Denominatore"; ;
            rIntDen["amount"] = DBNull.Value;
            rIntDen["kind"] = "N";
            t.Rows.Add(rIntDen);

            foreach (DataRow rDetail in Out.Tables[0].Rows)
            {
                if (rDetail["denominator"].ToString() == "S")
                {
                    string label = calcolaLabelTipoFatture(rDetail);
                    
                    DataRow r1 = t.NewRow();
                    r1["value"] = rDetail["description"].ToString() + " - " + label;
                    r1["amount"] = rDetail["taxabletotal"];
                    r1["kind"] = " ";
                    t.Rows.Add(r1);
                }
            }
            DataRow rTotDen = t.NewRow();
            rTotDen["value"] = "Totale Denominatore";
            rTotDen["amount"] = denominator;
            rTotDen["kind"] = "S";
            t.Rows.Add(rTotDen);

            DataRow rProrata = t.NewRow();
            rProrata["value"] = "Prorata Calcolato; " + HelpForm.StringValue(prorata, tag_perc) ;
            rProrata["amount"] = DBNull.Value;
            rProrata["kind"] = "N";
            t.Rows.Add(rProrata);

            DataRow rPie = t.NewRow();
            rPie["value"] = "";
            rPie["amount"] = DBNull.Value;
            rPie["kind"] = "N";
            t.Rows.Add(rPie);
        }
	}
}