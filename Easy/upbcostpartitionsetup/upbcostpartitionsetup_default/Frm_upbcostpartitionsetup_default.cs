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

using System.Windows.Forms;
using metadatalibrary;

namespace upbcostpartitionsetup_default
{
	/// <summary>
	/// Summary description for Frm_upbcostpartitionsetup_default.
	/// </summary>
	public class Frm_upbcostpartitionsetup_default : MetaDataForm
	{
		MetaData Meta;
		public upbcostpartitionsetup_default.vistaForm DS;
		private GroupBox gboxUPB;
		public TextBox txtUPB;
		private Button button1;
		private TextBox txtDescrUPB;
		public GroupBox grpRipartizioneCosti;
		public Button button3;
		public TextBox textBox3;
		public TextBox txtCodiceRipartizione;
		private GroupBox grpCausale;
		private TextBox textBox5;
		private TextBox txtCodiceCausale;
		private Button button2;
		private Label label1;
		private TextBox txtstart;
		private TextBox txtstop;
		private Label label2;
		private TextBox textBox1;
		private Label label3;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_upbcostpartitionsetup_default()
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
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.grpRipartizioneCosti = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.txtCodiceRipartizione = new System.Windows.Forms.TextBox();
			this.grpCausale = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausale = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtstart = new System.Windows.Forms.TextBox();
			this.txtstop = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.DS = new upbcostpartitionsetup_default.vistaForm();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.gboxUPB.SuspendLayout();
			this.grpRipartizioneCosti.SuspendLayout();
			this.grpCausale.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.button1);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Location = new System.Drawing.Point(12, 61);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(351, 127);
			this.gboxUPB.TabIndex = 2;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			this.gboxUPB.Text = "UPB";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(6, 101);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(337, 20);
			this.txtUPB.TabIndex = 6;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.button1.Location = new System.Drawing.Point(6, 78);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(77, 20);
			this.button1.TabIndex = 5;
			this.button1.TabStop = false;
			this.button1.Tag = "manage.upb.tree";
			this.button1.Text = "UPB";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(119, 19);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(224, 79);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// grpRipartizioneCosti
			// 
			this.grpRipartizioneCosti.Controls.Add(this.button3);
			this.grpRipartizioneCosti.Controls.Add(this.textBox3);
			this.grpRipartizioneCosti.Controls.Add(this.txtCodiceRipartizione);
			this.grpRipartizioneCosti.Location = new System.Drawing.Point(12, 205);
			this.grpRipartizioneCosti.Name = "grpRipartizioneCosti";
			this.grpRipartizioneCosti.Size = new System.Drawing.Size(351, 120);
			this.grpRipartizioneCosti.TabIndex = 6;
			this.grpRipartizioneCosti.TabStop = false;
			this.grpRipartizioneCosti.Tag = "AutoChoose.txtCodiceRipartizione.default.(active=\'S\')";
			this.grpRipartizioneCosti.Text = "Ripartizione dei Costi";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(8, 65);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 23);
			this.button3.TabIndex = 4;
			this.button3.Tag = "choose.costpartition.default.(active=\'S\')";
			this.button3.Text = "Codice";
			this.button3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(128, 19);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(215, 69);
			this.textBox3.TabIndex = 3;
			this.textBox3.TabStop = false;
			this.textBox3.Tag = "costpartition.title";
			// 
			// txtCodiceRipartizione
			// 
			this.txtCodiceRipartizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodiceRipartizione.Location = new System.Drawing.Point(8, 94);
			this.txtCodiceRipartizione.Name = "txtCodiceRipartizione";
			this.txtCodiceRipartizione.Size = new System.Drawing.Size(337, 20);
			this.txtCodiceRipartizione.TabIndex = 2;
			this.txtCodiceRipartizione.Tag = "costpartition.costpartitioncode?x";
			// 
			// grpCausale
			// 
			this.grpCausale.Controls.Add(this.textBox5);
			this.grpCausale.Controls.Add(this.txtCodiceCausale);
			this.grpCausale.Controls.Add(this.button2);
			this.grpCausale.Location = new System.Drawing.Point(369, 61);
			this.grpCausale.Name = "grpCausale";
			this.grpCausale.Size = new System.Drawing.Size(354, 127);
			this.grpCausale.TabIndex = 7;
			this.grpCausale.TabStop = false;
			this.grpCausale.Tag = "AutoManage.txtCodiceCausale.tree";
			this.grpCausale.Text = "Causale";
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(106, 19);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(242, 76);
			this.textBox5.TabIndex = 2;
			this.textBox5.TabStop = false;
			this.textBox5.Tag = "accmotive.title";
			// 
			// txtCodiceCausale
			// 
			this.txtCodiceCausale.Location = new System.Drawing.Point(7, 101);
			this.txtCodiceCausale.Name = "txtCodiceCausale";
			this.txtCodiceCausale.Size = new System.Drawing.Size(341, 20);
			this.txtCodiceCausale.TabIndex = 1;
			this.txtCodiceCausale.Tag = "accmotive.codemotive?invoicedetailview.codemotive";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(7, 77);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(77, 23);
			this.button2.TabIndex = 0;
			this.button2.Tag = "manage.accmotive.tree";
			this.button2.Text = "Causale";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(150, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Data Inizio validità";
			// 
			// txtstart
			// 
			this.txtstart.Location = new System.Drawing.Point(146, 26);
			this.txtstart.Name = "txtstart";
			this.txtstart.Size = new System.Drawing.Size(120, 20);
			this.txtstart.TabIndex = 9;
			this.txtstart.Tag = "upbcostpartitionsetup.start";
			// 
			// txtstop
			// 
			this.txtstop.Location = new System.Drawing.Point(295, 26);
			this.txtstop.Name = "txtstop";
			this.txtstop.Size = new System.Drawing.Size(120, 20);
			this.txtstop.TabIndex = 11;
			this.txtstop.Tag = "upbcostpartitionsetup.stop";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(300, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(86, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Data fine validità";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(20, 26);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 12;
			this.textBox1.Tag = "upbcostpartitionsetup.idupbcostpartitionsetup";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(27, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 13);
			this.label3.TabIndex = 13;
			this.label3.Text = "N. Mappatura";
			// 
			// Frm_upbcostpartitionsetup_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(735, 361);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.txtstop);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtstart);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.grpCausale);
			this.Controls.Add(this.grpRipartizioneCosti);
			this.Controls.Add(this.gboxUPB);
			this.Name = "Frm_upbcostpartitionsetup_default";
			this.Text = "Frm_upbcostpartitionsetup_default";
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.grpRipartizioneCosti.ResumeLayout(false);
			this.grpRipartizioneCosti.PerformLayout();
			this.grpCausale.ResumeLayout(false);
			this.grpCausale.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public void  MetaData_AfterClear(){
		}

        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
		public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
		}

        public void MetaData_AfterFill() {
        }
	}
}
