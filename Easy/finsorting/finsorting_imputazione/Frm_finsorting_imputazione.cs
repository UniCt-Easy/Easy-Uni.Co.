/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;

namespace finsorting_imputazione
{
	/// <summary>
	/// </summary>
	public class Frm_finsorting_imputazione : System.Windows.Forms.Form
	{
        public vistaForm DS;
        public string param;
        private GroupBox grpTipoClass;
        private PictureBox pictureBox1;
        private GroupBox gboxclass;
        private TextBox txtDescrizione;
        private TextBox txtCodice;
        private Button btnCodice;
        private TextBox textBox1;
        private Label label2;
        private GroupBox gboxBilancio;
        private CheckBox chkListTitle;
        private TextBox txtDescrBilancio;
        private TextBox txtBilancio;
        private Button btnBilancio;
        private RadioButton rdbEntrata;
        private RadioButton rdbSpesa;
    	/// <summary>
        /// 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_finsorting_imputazione()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_finsorting_imputazione));
            this.DS = new finsorting_imputazione.vistaForm();
            this.grpTipoClass = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gboxclass = new System.Windows.Forms.GroupBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.btnCodice = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gboxBilancio = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.rdbEntrata = new System.Windows.Forms.RadioButton();
            this.rdbSpesa = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpTipoClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gboxclass.SuspendLayout();
            this.gboxBilancio.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // grpTipoClass
            // 
            this.grpTipoClass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTipoClass.Controls.Add(this.pictureBox1);
            this.grpTipoClass.Controls.Add(this.gboxclass);
            this.grpTipoClass.Controls.Add(this.textBox1);
            this.grpTipoClass.Controls.Add(this.label2);
            this.grpTipoClass.Location = new System.Drawing.Point(4, 101);
            this.grpTipoClass.Name = "grpTipoClass";
            this.grpTipoClass.Size = new System.Drawing.Size(520, 109);
            this.grpTipoClass.TabIndex = 3;
            this.grpTipoClass.TabStop = false;
            this.grpTipoClass.Tag = "";
            this.grpTipoClass.Text = "Classificazione";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // gboxclass
            // 
            this.gboxclass.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass.Controls.Add(this.txtDescrizione);
            this.gboxclass.Controls.Add(this.txtCodice);
            this.gboxclass.Controls.Add(this.btnCodice);
            this.gboxclass.Location = new System.Drawing.Point(183, 11);
            this.gboxclass.Name = "gboxclass";
            this.gboxclass.Size = new System.Drawing.Size(330, 92);
            this.gboxclass.TabIndex = 2;
            this.gboxclass.TabStop = false;
            this.gboxclass.Tag = "AutoManage.txtCodice.tree";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(120, 18);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(204, 64);
            this.txtDescrizione.TabIndex = 6;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "sorting.description";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(8, 54);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(96, 20);
            this.txtCodice.TabIndex = 2;
            this.txtCodice.Tag = "sorting.sortcode?finsortingview.sortcode";
            // 
            // btnCodice
            // 
            this.btnCodice.Location = new System.Drawing.Point(8, 22);
            this.btnCodice.Name = "btnCodice";
            this.btnCodice.Size = new System.Drawing.Size(96, 23);
            this.btnCodice.TabIndex = 1;
            this.btnCodice.TabStop = false;
            this.btnCodice.Tag = "manage.sorting.tree";
            this.btnCodice.Text = "Codice";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "finsorting.quota.fixed.2..%.100";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Quota:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // gboxBilancio
            // 
            this.gboxBilancio.Controls.Add(this.chkListTitle);
            this.gboxBilancio.Controls.Add(this.txtDescrBilancio);
            this.gboxBilancio.Controls.Add(this.txtBilancio);
            this.gboxBilancio.Controls.Add(this.btnBilancio);
            this.gboxBilancio.Controls.Add(this.rdbEntrata);
            this.gboxBilancio.Controls.Add(this.rdbSpesa);
            this.gboxBilancio.Location = new System.Drawing.Point(4, 12);
            this.gboxBilancio.Name = "gboxBilancio";
            this.gboxBilancio.Size = new System.Drawing.Size(497, 83);
            this.gboxBilancio.TabIndex = 4;
            this.gboxBilancio.TabStop = false;
            this.gboxBilancio.Tag = "";
            this.gboxBilancio.Text = "Bilancio";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(8, 48);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(193, 16);
            this.chkListTitle.TabIndex = 33;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Location = new System.Drawing.Point(319, 19);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.Size = new System.Drawing.Size(168, 42);
            this.txtDescrBilancio.TabIndex = 32;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "finview.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(207, 43);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(104, 20);
            this.txtBilancio.TabIndex = 6;
            this.txtBilancio.Tag = "finview.codefin?finsortingview.codefin";
            this.txtBilancio.Leave += new System.EventHandler(this.txtBilancio_Leave);
            // 
            // btnBilancio
            // 
            this.btnBilancio.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(207, 19);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(104, 20);
            this.btnBilancio.TabIndex = 5;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // rdbEntrata
            // 
            this.rdbEntrata.Checked = true;
            this.rdbEntrata.Location = new System.Drawing.Point(8, 24);
            this.rdbEntrata.Name = "rdbEntrata";
            this.rdbEntrata.Size = new System.Drawing.Size(64, 16);
            this.rdbEntrata.TabIndex = 0;
            this.rdbEntrata.TabStop = true;
            this.rdbEntrata.Tag = "finview.finpart:E?finvardetailview.finpart:E";
            this.rdbEntrata.Text = "Entrata";
            // 
            // rdbSpesa
            // 
            this.rdbSpesa.Location = new System.Drawing.Point(88, 24);
            this.rdbSpesa.Name = "rdbSpesa";
            this.rdbSpesa.Size = new System.Drawing.Size(64, 16);
            this.rdbSpesa.TabIndex = 1;
            this.rdbSpesa.Tag = "finview.finpart:S?finvardetailview.finpart:S";
            this.rdbSpesa.Text = "Spesa";
            // 
            // Frm_finsorting_imputazione
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(526, 217);
            this.Controls.Add(this.gboxBilancio);
            this.Controls.Add(this.grpTipoClass);
            this.Name = "Frm_finsorting_imputazione";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpTipoClass.ResumeLayout(false);
            this.grpTipoClass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gboxclass.ResumeLayout(false);
            this.gboxclass.PerformLayout();
            this.gboxBilancio.ResumeLayout(false);
            this.gboxBilancio.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        CQueryHelper QHC;
        QueryHelper QHS;
        MetaData Meta;
		

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            object idsorkind = null;
            param = Meta.ExtraParameter.ToString();
            DataTable DescrClass = Meta.Conn.RUN_SELECT("sortingkind", "description", null,
                    QHS.CmpEq("idsorkind", param), null, null, true);
            if (DescrClass.Rows.Count == 0)
                Meta.Name = "Imputazione bilancio a \"" + param + "\"";
            else
                Meta.Name = "Imputazione bilancio a \"" +
                    DescrClass.Rows[0]["description"].ToString() + "\"";
            Meta.DefaultListType = "lista." + param;
            idsorkind = param;
            string filter = QHS.CmpEq("idsorkind", idsorkind);
            GetData.SetStaticFilter(DS.finsortingview, QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),filter));
            GetData.SetStaticFilter(DS.sorting, filter);
            GetData.SetStaticFilter(DS.finview, QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                                    QHC.CmpEq("idupb", "0001")));
            GetData.CacheTable(DS.sortingkind, filter, null, false);
            gboxclass.Tag += "." + filter;
            btnCodice.Tag += "." + filter;
            DS.sorting.ExtendedProperties[MetaData.ExtraParams] = filter;
        }

        public void MetaData_AfterClear () {
            txtCodice.ReadOnly = false;
        }
        public void MetaData_AfterFill () {
            if (Meta.EditMode)
                txtCodice.ReadOnly = true;
            else
                txtCodice.ReadOnly = false;
        }

        private void btnBilancio_Click (object sender, EventArgs e) {
            string filter;
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filteridfin = "";
            if (rdbSpesa.Checked)
                filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.CmpEq("finpart", 'S'));
            if (rdbEntrata.Checked)
                filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.CmpEq("finpart", 'E'));

            //Il filtro sull'UPB c'Ë sempre
          
            filter = QHS.CmpEq("idupb", "0001");
            
            filter = QHS.AppAnd(filteridfin, filter);


            string filteroperativo = "(idfin in (SELECT idfin from finusable where ayear='" +
                esercizio + "'))";

            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter,
                    "(title like " + QueryCreator.quotedstrvalue(
                    "%" + FR.txtDescrizione.Text + "%", true)) + ")";
                filter = GetData.MergeFilters(filter, filteroperativo);
                MetaData.DoMainCommand(this, "choose.finview.default." + filter);
                return;
            }

            DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
            if (rdbSpesa.Checked)
                MetaData.DoMainCommand(this, "manage.finview.treesupb");
            if (rdbEntrata.Checked)
                MetaData.DoMainCommand(this, "manage.finview.treeeupb");
        }


        private void SvuotaFinView () {
            txtBilancio.Text = "";
            txtDescrBilancio.Text = "";
            DS.finview.Clear();
        }

        private void txtBilancio_Leave (object sender, EventArgs e) {
            DataRow Curr = null;
            if (DS.finsorting.Rows.Count > 0) Curr = DS.finsorting.Rows[0];

            if (txtBilancio.Text.Trim() == "") {
                SvuotaFinView();
                if (Curr != null) Curr["idfin"] = 0;
                return;
            }

            string finpart = "";
            if (rdbSpesa.Checked) {
                finpart = "S";
            }
            if (rdbEntrata.Checked) {
                finpart = "E";
            }
            if (finpart == "") return;

            string filterUpb = "";
            
            filterUpb = QHS.CmpEq("idupb", "0001");

            string filtro = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), QHS.CmpEq("finpart", finpart), filterUpb);
            MetaData MetaBilancio = MetaData.GetMetaData(this, "finview");
            MetaBilancio.FilterLocked = true;
            MetaBilancio.SearchEnabled = false;
            MetaBilancio.MainSelectionEnabled = true;
            MetaBilancio.StartFilter = filtro;
            MetaBilancio.ExtraParameter = filtro;
            MetaBilancio.startFieldWanted = "codefin";
            MetaBilancio.startValueWanted = null;

            MetaBilancio.startValueWanted = txtBilancio.Text.Trim();
            string startfield = MetaBilancio.startFieldWanted;
            string startvalue = MetaBilancio.startValueWanted;
            DataRow rFin = null;
            if (startvalue != null) {
                //try to load a row directly, without opening a new form		
                string stripped = startvalue;
                if (stripped.EndsWith("%")) stripped = stripped.TrimEnd(new Char[] { '%' });
                string filter2 = GetData.MergeFilters(filtro, "(" + startfield + "='" + stripped + "')");
                rFin = MetaBilancio.SelectByCondition(filter2, "finview");
            }

            if (rFin == null) {
                string edittype = "tree" + finpart.ToLower() + "upb";
                bool res = MetaBilancio.Edit(this, edittype, true);
                if (!res) {
                    SvuotaFinView();
                    if (Curr != null) Curr["idfin"] = 0;
                    return;
                }
                rFin = MetaBilancio.LastSelectedRow;
            }
            if (Curr != null) Curr["idfin"] = rFin["idfin"];

            if (rFin != null) {
                SvuotaFinView();
                string filter = QHS.AppAnd(QHS.CmpEq("idfin", rFin["idfin"]),
                    QHS.CmpEq("idupb", rFin["idupb"]), QHS.CmpEq("ayear", rFin["ayear"]));
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.finview, null, filter, null, false);
            }
            Meta.FreshForm(gboxBilancio.Controls, true, "finview");
            if (!(Meta.InsertMode || Meta.EditMode)) {
                txtBilancio.Text = rFin["codefin"].ToString();
                txtDescrBilancio.Text = rFin["title"].ToString();
                if (rFin["finpart"].ToString() == "S") {
                    rdbSpesa.Checked = true;
                }
                else {
                    rdbEntrata.Checked = true;
                }
            }
        }

        
	}
}
