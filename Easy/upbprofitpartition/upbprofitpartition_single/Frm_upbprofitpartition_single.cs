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

namespace upbprofitpartition_single {
	/// <summary>
	/// Summary description for Frm_upbprofitpartition_single.
	/// </summary>
	public class Frm_upbprofitpartition_single : System.Windows.Forms.Form {
		public upbprofitpartition_single.vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        CQueryHelper QHC;
        QueryHelper QHS;
        private GroupBox groupBox2;
        public TextBox txtUPB_dest;
        private Button btnUPB_dest;
        private TextBox txtDescrUPB_dest;
        MetaData Meta;
		public Frm_upbprofitpartition_single() {
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
            this.DS = new upbprofitpartition_single.vistaForm();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtUPB_dest = new System.Windows.Forms.TextBox();
            this.btnUPB_dest = new System.Windows.Forms.Button();
            this.txtDescrUPB_dest = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(4, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(369, 205);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUPB_dest);
            this.groupBox2.Controls.Add(this.btnUPB_dest);
            this.groupBox2.Controls.Add(this.txtDescrUPB_dest);
            this.groupBox2.Location = new System.Drawing.Point(19, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 127);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoChoose.txtUPB_dest.default.(active=\'S\')";
            this.groupBox2.Text = "UPB Destinazione";
            // 
            // txtUPB_dest
            // 
            this.txtUPB_dest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB_dest.Location = new System.Drawing.Point(6, 101);
            this.txtUPB_dest.Name = "txtUPB_dest";
            this.txtUPB_dest.Size = new System.Drawing.Size(313, 20);
            this.txtUPB_dest.TabIndex = 6;
            this.txtUPB_dest.Tag = "upb_dest.codeupb?x";
            // 
            // btnUPB_dest
            // 
            this.btnUPB_dest.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPB_dest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPB_dest.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPB_dest.Location = new System.Drawing.Point(6, 78);
            this.btnUPB_dest.Name = "btnUPB_dest";
            this.btnUPB_dest.Size = new System.Drawing.Size(77, 20);
            this.btnUPB_dest.TabIndex = 5;
            this.btnUPB_dest.TabStop = false;
            this.btnUPB_dest.Tag = "manage.upb_dest.tree";
            this.btnUPB_dest.Text = "UPB";
            this.btnUPB_dest.UseVisualStyleBackColor = false;
            // 
            // txtDescrUPB_dest
            // 
            this.txtDescrUPB_dest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB_dest.Location = new System.Drawing.Point(119, 19);
            this.txtDescrUPB_dest.Multiline = true;
            this.txtDescrUPB_dest.Name = "txtDescrUPB_dest";
            this.txtDescrUPB_dest.ReadOnly = true;
            this.txtDescrUPB_dest.Size = new System.Drawing.Size(200, 79);
            this.txtDescrUPB_dest.TabIndex = 4;
            this.txtDescrUPB_dest.TabStop = false;
            this.txtDescrUPB_dest.Tag = "upb_dest.title";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(281, 165);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "upbprofitpartition.quota.fixed.2..%.100";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(209, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Quota:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(197, 220);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(293, 220);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 13;
            this.btnAnnulla.Text = "Annulla";
            // 
            // Frm_upbprofitpartition_single
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(377, 250);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.Name = "Frm_upbprofitpartition_single";
            this.Text = "Frm_upbprofitpartition_single";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.upb_dest, "upb");
         
        }

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){

		}

	
		public void MetaData_AfterFill(){
			
		}
	}
}