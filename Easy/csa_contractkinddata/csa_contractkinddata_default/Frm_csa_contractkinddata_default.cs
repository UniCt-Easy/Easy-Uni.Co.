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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;

namespace csa_contractkinddata_default {
	/// <summary>
	/// </summary>
	public class Frm_csa_contractkinddata_default : System.Windows.Forms.Form {
		private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancButton;
        public vistaForm DS;
        private TextBox tipo;
        private Label label2;
        private TextBox txtEsercDoc;
        private Label labEsercizio;
        MetaData Meta;
        private GroupBox gboxUPB;
        private Button btnUPB;
        private TextBox txtDescrUPB;
        private GroupBox gboxConto;
        private TextBox txtDenominazioneConto;
        private TextBox txtCodiceConto;
        private Button button2;
        private GroupBox groupBox69;
        private TextBox textBox23;
        private TextBox txtCodiceBilancio;
        private Button button16;
        public GroupBox gboxclassSiope;
        public Button btnCodiceSiope;
        private TextBox txtDenomSiope;
        private TextBox txtCodiceSiope;
        public TextBox txtUPB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_csa_contractkinddata_default() {
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
            this.OkButton = new System.Windows.Forms.Button();
            this.CancButton = new System.Windows.Forms.Button();
            this.tipo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercDoc = new System.Windows.Forms.TextBox();
            this.labEsercizio = new System.Windows.Forms.Label();
            this.DS = new csa_contractkinddata_default.vistaForm();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.btnUPB = new System.Windows.Forms.Button();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.gboxConto = new System.Windows.Forms.GroupBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox69 = new System.Windows.Forms.GroupBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.button16 = new System.Windows.Forms.Button();
            this.gboxclassSiope = new System.Windows.Forms.GroupBox();
            this.btnCodiceSiope = new System.Windows.Forms.Button();
            this.txtDenomSiope = new System.Windows.Forms.TextBox();
            this.txtCodiceSiope = new System.Windows.Forms.TextBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxUPB.SuspendLayout();
            this.gboxConto.SuspendLayout();
            this.groupBox69.SuspendLayout();
            this.gboxclassSiope.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(738, 382);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 7;
            this.OkButton.Tag = "mainsave";
            this.OkButton.Text = "Ok";
            // 
            // CancButton
            // 
            this.CancButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancButton.Location = new System.Drawing.Point(825, 382);
            this.CancButton.Name = "CancButton";
            this.CancButton.Size = new System.Drawing.Size(75, 23);
            this.CancButton.TabIndex = 8;
            this.CancButton.Text = "Annulla";
            // 
            // tipo
            // 
            this.tipo.Location = new System.Drawing.Point(14, 60);
            this.tipo.Name = "tipo";
            this.tipo.Size = new System.Drawing.Size(433, 20);
            this.tipo.TabIndex = 2;
            this.tipo.Tag = "csa_contractkinddata.vocecsa";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 39);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Voce CSA:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercDoc
            // 
            this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEsercDoc.Location = new System.Drawing.Point(70, 12);
            this.txtEsercDoc.Name = "txtEsercDoc";
            this.txtEsercDoc.ReadOnly = true;
            this.txtEsercDoc.Size = new System.Drawing.Size(80, 20);
            this.txtEsercDoc.TabIndex = 1;
            this.txtEsercDoc.TabStop = false;
            this.txtEsercDoc.Tag = "csa_contractkinddata.ayear";
            // 
            // labEsercizio
            // 
            this.labEsercizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEsercizio.Location = new System.Drawing.Point(17, 14);
            this.labEsercizio.Name = "labEsercizio";
            this.labEsercizio.Size = new System.Drawing.Size(55, 16);
            this.labEsercizio.TabIndex = 0;
            this.labEsercizio.Text = "Esercizio";
            this.labEsercizio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.btnUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Location = new System.Drawing.Point(19, 86);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(428, 133);
            this.gboxUPB.TabIndex = 3;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            this.gboxUPB.Text = "UPB per Imputazone Costo";
            // 
            // btnUPB
            // 
            this.btnUPB.Location = new System.Drawing.Point(8, 77);
            this.btnUPB.Name = "btnUPB";
            this.btnUPB.Size = new System.Drawing.Size(88, 24);
            this.btnUPB.TabIndex = 1;
            this.btnUPB.TabStop = false;
            this.btnUPB.Tag = "manage.upb.tree";
            this.btnUPB.Text = "UPB";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(120, 14);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(302, 87);
            this.txtDescrUPB.TabIndex = 2;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // gboxConto
            // 
            this.gboxConto.Controls.Add(this.txtDenominazioneConto);
            this.gboxConto.Controls.Add(this.txtCodiceConto);
            this.gboxConto.Controls.Add(this.button2);
            this.gboxConto.Location = new System.Drawing.Point(464, 230);
            this.gboxConto.Name = "gboxConto";
            this.gboxConto.Size = new System.Drawing.Size(438, 130);
            this.gboxConto.TabIndex = 6;
            this.gboxConto.TabStop = false;
            this.gboxConto.Tag = "AutoManage.txtCodiceConto.tree";
            this.gboxConto.Text = "Conto EP di  Costo";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Location = new System.Drawing.Point(116, 16);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(316, 82);
            this.txtDenominazioneConto.TabIndex = 0;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "account.title";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Location = new System.Drawing.Point(8, 104);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.Size = new System.Drawing.Size(424, 20);
            this.txtCodiceConto.TabIndex = 2;
            this.txtCodiceConto.Tag = "account.codeacc?x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 76);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 1;
            this.button2.TabStop = false;
            this.button2.Tag = "manage.account.tree";
            this.button2.Text = "Conto";
            // 
            // groupBox69
            // 
            this.groupBox69.Controls.Add(this.textBox23);
            this.groupBox69.Controls.Add(this.txtCodiceBilancio);
            this.groupBox69.Controls.Add(this.button16);
            this.groupBox69.Location = new System.Drawing.Point(464, 86);
            this.groupBox69.Name = "groupBox69";
            this.groupBox69.Size = new System.Drawing.Size(438, 133);
            this.groupBox69.TabIndex = 4;
            this.groupBox69.TabStop = false;
            this.groupBox69.Tag = "AutoManage.txtCodiceBilancio.trees";
            this.groupBox69.Text = "Voce di Bilancio per Imputazione Costo";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(116, 20);
            this.textBox23.Multiline = true;
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(316, 81);
            this.textBox23.TabIndex = 0;
            this.textBox23.TabStop = false;
            this.textBox23.Tag = "fin.title";
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(6, 107);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(426, 20);
            this.txtCodiceBilancio.TabIndex = 2;
            this.txtCodiceBilancio.Tag = "fin.codefin?x";
            // 
            // button16
            // 
            this.button16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button16.ImageIndex = 0;
            this.button16.Location = new System.Drawing.Point(8, 77);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(93, 24);
            this.button16.TabIndex = 1;
            this.button16.TabStop = false;
            this.button16.Tag = "manage.fin.trees";
            this.button16.Text = "Bilancio";
            // 
            // gboxclassSiope
            // 
            this.gboxclassSiope.Controls.Add(this.btnCodiceSiope);
            this.gboxclassSiope.Controls.Add(this.txtDenomSiope);
            this.gboxclassSiope.Controls.Add(this.txtCodiceSiope);
            this.gboxclassSiope.Location = new System.Drawing.Point(19, 225);
            this.gboxclassSiope.Name = "gboxclassSiope";
            this.gboxclassSiope.Size = new System.Drawing.Size(428, 135);
            this.gboxclassSiope.TabIndex = 5;
            this.gboxclassSiope.TabStop = false;
            this.gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.treeclassmovimenti";
            this.gboxclassSiope.Text = "Classificazione SIOPE";
            // 
            // btnCodiceSiope
            // 
            this.btnCodiceSiope.Location = new System.Drawing.Point(6, 81);
            this.btnCodiceSiope.Name = "btnCodiceSiope";
            this.btnCodiceSiope.Size = new System.Drawing.Size(88, 23);
            this.btnCodiceSiope.TabIndex = 4;
            this.btnCodiceSiope.TabStop = false;
            this.btnCodiceSiope.Tag = "manage.sorting.tree";
            this.btnCodiceSiope.Text = "Codice";
            this.btnCodiceSiope.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenomSiope
            // 
            this.txtDenomSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenomSiope.Location = new System.Drawing.Point(102, 16);
            this.txtDenomSiope.Multiline = true;
            this.txtDenomSiope.Name = "txtDenomSiope";
            this.txtDenomSiope.ReadOnly = true;
            this.txtDenomSiope.Size = new System.Drawing.Size(318, 88);
            this.txtDenomSiope.TabIndex = 3;
            this.txtDenomSiope.TabStop = false;
            this.txtDenomSiope.Tag = "sorting.description";
            // 
            // txtCodiceSiope
            // 
            this.txtCodiceSiope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodiceSiope.Location = new System.Drawing.Point(8, 110);
            this.txtCodiceSiope.Name = "txtCodiceSiope";
            this.txtCodiceSiope.Size = new System.Drawing.Size(412, 20);
            this.txtCodiceSiope.TabIndex = 2;
            this.txtCodiceSiope.Tag = "sorting.sortcode?x";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(8, 107);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(414, 20);
            this.txtUPB.TabIndex = 9;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // Frm_csa_contractkinddata_default
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.CancButton;
            this.ClientSize = new System.Drawing.Size(916, 417);
            this.Controls.Add(this.gboxclassSiope);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.gboxConto);
            this.Controls.Add(this.groupBox69);
            this.Controls.Add(this.txtEsercDoc);
            this.Controls.Add(this.labEsercizio);
            this.Controls.Add(this.tipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancButton);
            this.Name = "Frm_csa_contractkinddata_default";
            this.Text = "frmContractKindData";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxConto.ResumeLayout(false);
            this.gboxConto.PerformLayout();
            this.groupBox69.ResumeLayout(false);
            this.groupBox69.PerformLayout();
            this.gboxclassSiope.ResumeLayout(false);
            this.gboxclassSiope.PerformLayout();
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
            int esercizioCurr = (int)Meta.GetSys("esercizio");
            string filter = QHS.CmpEq("ayear", esercizioCurr);

            GetData.SetStaticFilter(DS.fin, QHS.AppAnd(filter, QHS.BitSet("flag", 0)));
            GetData.SetStaticFilter(DS.account, filter);
            string filterSiope = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese"));

            DataTable tSortingkind = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiope, null, null, true);
            if ((tSortingkind != null) && (tSortingkind.Rows.Count > 0))
            {
                DataRow R = tSortingkind.Rows[0];
                object idsorkind = R["idsorkind"];
                object idsorkind_main = R["idsorkind"];
                SetGBoxClass(idsorkind);
            }
        }

        void SetGBoxClass(object sortingkind){
            if (sortingkind != DBNull.Value){
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.sorting, filter);
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclassSiope.Text = title;
                gboxclassSiope.Tag = "AutoManage.txtCodiceSiope.tree." + filter;
                btnCodiceSiope.Tag = "manage.sorting.tree." + filter;
            }
        }
       
    }
}