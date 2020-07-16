/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace costpartitiondetail_single {
	/// <summary>
	/// Summary description for Frm_costpartitiondetail_single.
	/// </summary>
	public class Frm_costpartitiondetail_single : System.Windows.Forms.Form {
		MetaData Meta;
		private DataAccess Conn;
		
        public costpartitiondetail_single.vistaForm DS;
		private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        QueryHelper QHS;
        public GroupBox gboxclass3;
        public Button btnCodice3;
        private TextBox txtDenom3;
        public TextBox txtCodice3;
        public GroupBox gboxclass2;
        public Button btnCodice2;
        private TextBox txtDenom2;
        public TextBox txtCodice2;
        public GroupBox gboxclass1;
        public Button btnCodice1;
        private TextBox txtDenom1;
        public TextBox txtCodice1;
        private GroupBox grpImporto;
        private TextBox txtAmount;
        private Label label4;
        private Label label2;
        private GroupBox grpPercentuale;
        private TextBox txtRate;
        private Label label1;
        CQueryHelper QHC;
		public Frm_costpartitiondetail_single() {
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

		public void MetaData_AfterActivation() {
			
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.DS = new costpartitiondetail_single.vistaForm();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.gboxclass3 = new System.Windows.Forms.GroupBox();
            this.btnCodice3 = new System.Windows.Forms.Button();
            this.txtDenom3 = new System.Windows.Forms.TextBox();
            this.txtCodice3 = new System.Windows.Forms.TextBox();
            this.gboxclass2 = new System.Windows.Forms.GroupBox();
            this.btnCodice2 = new System.Windows.Forms.Button();
            this.txtDenom2 = new System.Windows.Forms.TextBox();
            this.txtCodice2 = new System.Windows.Forms.TextBox();
            this.gboxclass1 = new System.Windows.Forms.GroupBox();
            this.btnCodice1 = new System.Windows.Forms.Button();
            this.txtDenom1 = new System.Windows.Forms.TextBox();
            this.txtCodice1 = new System.Windows.Forms.TextBox();
            this.grpImporto = new System.Windows.Forms.GroupBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpPercentuale = new System.Windows.Forms.GroupBox();
            this.txtRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxclass3.SuspendLayout();
            this.gboxclass2.SuspendLayout();
            this.gboxclass1.SuspendLayout();
            this.grpImporto.SuspendLayout();
            this.grpPercentuale.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(504, 364);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 10;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(400, 364);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 9;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // gboxclass3
            // 
            this.gboxclass3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass3.Controls.Add(this.btnCodice3);
            this.gboxclass3.Controls.Add(this.txtDenom3);
            this.gboxclass3.Controls.Add(this.txtCodice3);
            this.gboxclass3.Location = new System.Drawing.Point(221, 250);
            this.gboxclass3.Name = "gboxclass3";
            this.gboxclass3.Size = new System.Drawing.Size(357, 108);
            this.gboxclass3.TabIndex = 57;
            this.gboxclass3.TabStop = false;
            this.gboxclass3.Tag = "";
            this.gboxclass3.Text = "Classificazione 3";
            // 
            // btnCodice3
            // 
            this.btnCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCodice3.Location = new System.Drawing.Point(6, 56);
            this.btnCodice3.Name = "btnCodice3";
            this.btnCodice3.Size = new System.Drawing.Size(88, 23);
            this.btnCodice3.TabIndex = 4;
            this.btnCodice3.TabStop = false;
            this.btnCodice3.Tag = "manage.sorting3.tree";
            this.btnCodice3.Text = "Codice";
            this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom3
            // 
            this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom3.Location = new System.Drawing.Point(128, 24);
            this.txtDenom3.Multiline = true;
            this.txtDenom3.Name = "txtDenom3";
            this.txtDenom3.ReadOnly = true;
            this.txtDenom3.Size = new System.Drawing.Size(223, 56);
            this.txtDenom3.TabIndex = 3;
            this.txtDenom3.TabStop = false;
            this.txtDenom3.Tag = "sorting3.description";
            // 
            // txtCodice3
            // 
            this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodice3.Location = new System.Drawing.Point(6, 82);
            this.txtCodice3.Name = "txtCodice3";
            this.txtCodice3.Size = new System.Drawing.Size(345, 20);
            this.txtCodice3.TabIndex = 2;
            this.txtCodice3.Tag = "sorting3.sortcode?x";
            // 
            // gboxclass2
            // 
            this.gboxclass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass2.Controls.Add(this.btnCodice2);
            this.gboxclass2.Controls.Add(this.txtDenom2);
            this.gboxclass2.Controls.Add(this.txtCodice2);
            this.gboxclass2.Location = new System.Drawing.Point(221, 124);
            this.gboxclass2.Name = "gboxclass2";
            this.gboxclass2.Size = new System.Drawing.Size(357, 120);
            this.gboxclass2.TabIndex = 56;
            this.gboxclass2.TabStop = false;
            this.gboxclass2.Tag = "";
            this.gboxclass2.Text = "Classificazione 2";
            // 
            // btnCodice2
            // 
            this.btnCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCodice2.Location = new System.Drawing.Point(10, 68);
            this.btnCodice2.Name = "btnCodice2";
            this.btnCodice2.Size = new System.Drawing.Size(88, 23);
            this.btnCodice2.TabIndex = 4;
            this.btnCodice2.TabStop = false;
            this.btnCodice2.Tag = "manage.sorting2.tree";
            this.btnCodice2.Text = "Codice";
            this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom2
            // 
            this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom2.Location = new System.Drawing.Point(128, 24);
            this.txtDenom2.Multiline = true;
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.ReadOnly = true;
            this.txtDenom2.Size = new System.Drawing.Size(221, 67);
            this.txtDenom2.TabIndex = 3;
            this.txtDenom2.TabStop = false;
            this.txtDenom2.Tag = "sorting2.description";
            // 
            // txtCodice2
            // 
            this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodice2.Location = new System.Drawing.Point(6, 94);
            this.txtCodice2.Name = "txtCodice2";
            this.txtCodice2.Size = new System.Drawing.Size(343, 20);
            this.txtCodice2.TabIndex = 2;
            this.txtCodice2.Tag = "sorting2.sortcode?x";
            // 
            // gboxclass1
            // 
            this.gboxclass1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass1.Controls.Add(this.btnCodice1);
            this.gboxclass1.Controls.Add(this.txtDenom1);
            this.gboxclass1.Controls.Add(this.txtCodice1);
            this.gboxclass1.Location = new System.Drawing.Point(221, 12);
            this.gboxclass1.Name = "gboxclass1";
            this.gboxclass1.Size = new System.Drawing.Size(357, 110);
            this.gboxclass1.TabIndex = 55;
            this.gboxclass1.TabStop = false;
            this.gboxclass1.Tag = "";
            this.gboxclass1.Text = "Classificazione 1";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCodice1.Location = new System.Drawing.Point(6, 58);
            this.btnCodice1.Name = "btnCodice1";
            this.btnCodice1.Size = new System.Drawing.Size(88, 23);
            this.btnCodice1.TabIndex = 4;
            this.btnCodice1.TabStop = false;
            this.btnCodice1.Tag = "manage.sorting1.tree";
            this.btnCodice1.Text = "Codice";
            this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom1
            // 
            this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom1.Location = new System.Drawing.Point(128, 24);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(221, 57);
            this.txtDenom1.TabIndex = 3;
            this.txtDenom1.TabStop = false;
            this.txtDenom1.Tag = "sorting1.description";
            // 
            // txtCodice1
            // 
            this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodice1.Location = new System.Drawing.Point(6, 84);
            this.txtCodice1.Name = "txtCodice1";
            this.txtCodice1.Size = new System.Drawing.Size(343, 20);
            this.txtCodice1.TabIndex = 2;
            this.txtCodice1.Tag = "sorting1.sortcode?x";
            // 
            // grpImporto
            // 
            this.grpImporto.Controls.Add(this.txtAmount);
            this.grpImporto.Controls.Add(this.label4);
            this.grpImporto.Controls.Add(this.label2);
            this.grpImporto.Location = new System.Drawing.Point(12, 12);
            this.grpImporto.Name = "grpImporto";
            this.grpImporto.Size = new System.Drawing.Size(182, 71);
            this.grpImporto.TabIndex = 58;
            this.grpImporto.TabStop = false;
            this.grpImporto.Text = " ";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(17, 32);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(130, 20);
            this.txtAmount.TabIndex = 55;
            this.txtAmount.Tag = "costpartitiondetail.amount";
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Importo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = " ";
            // 
            // grpPercentuale
            // 
            this.grpPercentuale.Controls.Add(this.txtRate);
            this.grpPercentuale.Controls.Add(this.label1);
            this.grpPercentuale.Location = new System.Drawing.Point(12, 89);
            this.grpPercentuale.Name = "grpPercentuale";
            this.grpPercentuale.Size = new System.Drawing.Size(182, 84);
            this.grpPercentuale.TabIndex = 59;
            this.grpPercentuale.TabStop = false;
            this.grpPercentuale.Text = " ";
            // 
            // txtRate
            // 
            this.txtRate.Location = new System.Drawing.Point(17, 39);
            this.txtRate.Name = "txtRate";
            this.txtRate.Size = new System.Drawing.Size(130, 20);
            this.txtRate.TabIndex = 56;
            this.txtRate.Tag = "costpartitiondetail.rate.fixed.6..%.100";
            this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Percentuale";
            // 
            // Frm_costpartitiondetail_single
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(590, 394);
            this.Controls.Add(this.grpPercentuale);
            this.Controls.Add(this.grpImporto);
            this.Controls.Add(this.gboxclass3);
            this.Controls.Add(this.gboxclass2);
            this.Controls.Add(this.gboxclass1);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Name = "Frm_costpartitiondetail_single";
            this.Text = "Frm_costpartitiondetail_single";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxclass3.ResumeLayout(false);
            this.gboxclass3.PerformLayout();
            this.gboxclass2.ResumeLayout(false);
            this.gboxclass2.PerformLayout();
            this.gboxclass1.ResumeLayout(false);
            this.gboxclass1.PerformLayout();
            this.grpImporto.ResumeLayout(false);
            this.grpImporto.PerformLayout();
            this.grpPercentuale.ResumeLayout(false);
            this.grpPercentuale.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
	
		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			
		}

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
                filter, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0))
            {
                DataRow r = tExpSetup.Rows[0];
                object idsorkind1 = r["idsortingkind1"];
                object idsorkind2 = r["idsortingkind2"];
                object idsorkind3 = r["idsortingkind3"];
                SetGBoxClass(1, idsorkind1);
                SetGBoxClass(2, idsorkind2);
                SetGBoxClass(3, idsorkind3);

            }	


		}

        object GetCtrlByName(string Name)
        {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;

            return Ctrl.GetValue(this);
        }


        void SetGBoxClass(int num, object sortingkind)
        {
            if (sortingkind == DBNull.Value)
            {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                G.Visible = false;
            }
            else
            {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting" + num.ToString()], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                Button btnCodice = (Button)GetCtrlByName("btnCodice" + num.ToString());
                gboxclass.Tag = "AutoManage.txtCodice" + num.ToString() + ".tree." + filter;
                string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                btnCodice.Tag = "manage.sorting" + num.ToString() + ".tree." + filter;
                DS.Tables["sorting" + num.ToString()].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }

        public void MetaData_AfterFill() {
            DataRow rcostpartitiondetail = Meta.SourceRow;
            DataRow rCostPartition = rcostpartitiondetail.GetParentRow("costpartition_costpartitiondetail");

            object kind = rCostPartition["kind"];
            if (kind != DBNull.Value)
            {
                grpImporto.Visible = (kind.ToString() == "C");
                grpPercentuale.Visible = (kind.ToString() == "P");
            }
        }

      
	}
}