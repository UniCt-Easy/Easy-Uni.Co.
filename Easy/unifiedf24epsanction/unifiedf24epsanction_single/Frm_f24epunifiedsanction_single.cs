
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace unifiedf24epsanction_single
{
	/// <summary>
	/// </summary>
    public class Frm_unifiedf24epsanction_single : MetaDataForm {
		private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.ComboBox cmbTipo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
		public unifiedf24epsanction_single.vistaForm DS;
        private GroupBox grpItaliano;
        private TextBox txtGeoComune;
        private TextBox txtEsercizio;
        private Label label7;
        private Label label4;
        private TextBox textBox2;
        private ComboBox cmbRegioneFiscale;
        private GroupBox grpRegioneProvincia;
        private Label label13;
        private TextBox txtProvincia;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public Frm_unifiedf24epsanction_single ()
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.DS = new unifiedf24epsanction_single.vistaForm();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpItaliano = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.txtGeoComune = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbRegioneFiscale = new System.Windows.Forms.ComboBox();
            this.grpRegioneProvincia = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpItaliano.SuspendLayout();
            this.grpRegioneProvincia.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(330, 236);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 6;
            this.btnOk.TabStop = false;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(434, 236);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 5;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Annulla";
            // 
            // cmbTipo
            // 
            this.cmbTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipo.DataSource = this.DS.f24epsanctionkind;
            this.cmbTipo.DisplayMember = "description";
            this.cmbTipo.Location = new System.Drawing.Point(15, 32);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(420, 21);
            this.cmbTipo.TabIndex = 1;
            this.cmbTipo.Tag = "unifiedf24epsanction.idsanction?x";
            this.cmbTipo.ValueMember = "idsanction";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Sanzione:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 187);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.Tag = "unifiedf24epsanction.amount";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Importo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpItaliano
            // 
            this.grpItaliano.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpItaliano.Controls.Add(this.label13);
            this.grpItaliano.Controls.Add(this.txtProvincia);
            this.grpItaliano.Controls.Add(this.txtGeoComune);
            this.grpItaliano.Location = new System.Drawing.Point(15, 60);
            this.grpItaliano.Name = "grpItaliano";
            this.grpItaliano.Size = new System.Drawing.Size(497, 48);
            this.grpItaliano.TabIndex = 2;
            this.grpItaliano.TabStop = false;
            this.grpItaliano.Tag = "AutoChoose.txtGeoComune.default.(newcity is null and stop is null)";
            this.grpItaliano.Text = "Comune Riferimento";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(401, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 18);
            this.label13.TabIndex = 0;
            this.label13.Text = "Prov.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProvincia
            // 
            this.txtProvincia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProvincia.Location = new System.Drawing.Point(433, 16);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.ReadOnly = true;
            this.txtProvincia.Size = new System.Drawing.Size(56, 20);
            this.txtProvincia.TabIndex = 1;
            this.txtProvincia.TabStop = false;
            this.txtProvincia.Tag = "geo_country.province";
            // 
            // txtGeoComune
            // 
            this.txtGeoComune.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeoComune.Location = new System.Drawing.Point(6, 16);
            this.txtGeoComune.Name = "txtGeoComune";
            this.txtGeoComune.Size = new System.Drawing.Size(387, 20);
            this.txtGeoComune.TabIndex = 1;
            this.txtGeoComune.Tag = "geo_city.title?unifiedf24epsanctionview.city";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(439, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cod. Tributo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(454, 33);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(56, 20);
            this.textBox2.TabIndex = 0;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "f24epsanctionkind.fiscaltaxcode";
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(154, 187);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(76, 20);
            this.txtEsercizio.TabIndex = 5;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "unifiedf24epsanction.ayear.year";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(151, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Anno di Riferimento:";
            // 
            // cmbRegioneFiscale
            // 
            this.cmbRegioneFiscale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRegioneFiscale.DataSource = this.DS.fiscaltaxregion;
            this.cmbRegioneFiscale.DisplayMember = "title";
            this.cmbRegioneFiscale.Location = new System.Drawing.Point(6, 22);
            this.cmbRegioneFiscale.Name = "cmbRegioneFiscale";
            this.cmbRegioneFiscale.Size = new System.Drawing.Size(233, 21);
            this.cmbRegioneFiscale.TabIndex = 0;
            this.cmbRegioneFiscale.Tag = "unifiedf24epsanction.idfiscaltaxregion?geo_cityview.title?f24epsanctionview.regio" +
                "n";
            this.cmbRegioneFiscale.ValueMember = "idfiscaltaxregion";
            // 
            // grpRegioneProvincia
            // 
            this.grpRegioneProvincia.Controls.Add(this.cmbRegioneFiscale);
            this.grpRegioneProvincia.Location = new System.Drawing.Point(15, 110);
            this.grpRegioneProvincia.Name = "grpRegioneProvincia";
            this.grpRegioneProvincia.Size = new System.Drawing.Size(245, 56);
            this.grpRegioneProvincia.TabIndex = 3;
            this.grpRegioneProvincia.TabStop = false;
            this.grpRegioneProvincia.Text = "Regione o Provincia Autonoma";
            // 
            // Frm_unifiedf24epsanction_single
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(524, 275);
            this.Controls.Add(this.grpRegioneProvincia);
            this.Controls.Add(this.grpItaliano);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtEsercizio);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Name = "Frm_unifiedf24epsanction_single";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sanzione F24 EP";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpItaliano.ResumeLayout(false);
            this.grpItaliano.PerformLayout();
            this.grpRegioneProvincia.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


        MetaData Meta;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();

            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.f24epsanctionkind, filterEsercizio, null, true);
         }

        public void MetaData_AfterRowSelect (DataTable T, DataRow R) {
            switch (T.TableName) {
                case "f24epsanctionkind": {
                    if (R != null) {
                        if (DS.unifiedf24epsanction.Rows.Count == 0) return;
                        DataRow Curr = DS.unifiedf24epsanction.Rows[0];
                        switch (R["flagagency"].ToString()) {
                            case "C": {
                                cmbRegioneFiscale.SelectedIndex = -1;
                                Curr["idfiscaltaxregion"] = DBNull.Value;
                                grpRegioneProvincia.Visible = false;
                                grpItaliano.Visible = true;
                                break;
                            }
                            case "R": {
                                txtGeoComune.Text = null;
                                grpItaliano.Visible = false;
                                grpRegioneProvincia.Visible = true;
                                Curr["idcity"] = DBNull.Value;
                                break;
                            }
                            case "N": {
                                txtGeoComune.Text = null;
                                cmbRegioneFiscale.SelectedIndex = -1;
                                grpItaliano.Visible = false;
                                Curr["idfiscaltaxregion"] = DBNull.Value;
                                Curr["idcity"] = DBNull.Value;
                                grpRegioneProvincia.Visible = false;
                                break;
                            }

                        }
                    }
                    else {
                        grpItaliano.Visible = true;
                        grpRegioneProvincia.Visible = true;
                    }
                    return;
                }
            }
        }
	}

}
