
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
using metadatalibrary;
using System.Data;
namespace abatableexpense_contrattodetail//oneredetraibile//
{
	/// <summary>
	/// Summary description for frmoneredetraibile.
	/// </summary>
	public class Frm_abatableexpense_contrattodetail : MetaDataForm
	{
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.ComboBox cmdTipoDeduzione;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		public vistaForm DS;
		private System.Windows.Forms.Label label3;
        private TextBox textBox3;
        private TextBox txtLong;
        private Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_abatableexpense_contrattodetail()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		public void MetaData_AfterLink()
		{
			MetaData Meta = MetaData.GetMetaData(this);
            DataTable Abatement= Meta.Conn.RUN_SELECT("abatement","*",
                null,Meta.QHS.CmpEq("flagabatableexpense", 'S'),null,false);                        
			string filter = Meta.QHS.AppAnd(Meta.QHS.FieldIn("idabatement",Abatement.Select()),
                Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
			GetData.SetStaticFilter(DS.abatementcode, filter);
		}
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "abatementcode" && R != null) {
                txtLong.Text = QueryCreator.GetPrintable(R["longdescription"].ToString());
            }
        }
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.cmdTipoDeduzione = new System.Windows.Forms.ComboBox();
			this.DS = new abatableexpense_contrattodetail.vistaForm();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.txtLong = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// button3
			// 
			this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button3.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button3.Location = new System.Drawing.Point(310, 243);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(75, 23);
			this.button3.TabIndex = 22;
			this.button3.Tag = "mainsave";
			this.button3.Text = "Ok";
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button2.Location = new System.Drawing.Point(446, 243);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 23;
			this.button2.Text = "Annulla";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.textBox2.Location = new System.Drawing.Point(30, 211);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(112, 20);
			this.textBox2.TabIndex = 21;
			this.textBox2.Tag = "abatableexpense.totalamount";
			// 
			// cmdTipoDeduzione
			// 
			this.cmdTipoDeduzione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmdTipoDeduzione.DataSource = this.DS.abatementcode;
			this.cmdTipoDeduzione.DisplayMember = "description";
			this.cmdTipoDeduzione.Location = new System.Drawing.Point(120, 44);
			this.cmdTipoDeduzione.Name = "cmdTipoDeduzione";
			this.cmdTipoDeduzione.Size = new System.Drawing.Size(413, 21);
			this.cmdTipoDeduzione.TabIndex = 19;
			this.cmdTipoDeduzione.Tag = "abatableexpense.idabatement";
			this.cmdTipoDeduzione.ValueMember = "idabatement";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(112, 20);
			this.textBox1.TabIndex = 17;
			this.textBox1.Tag = "abatableexpense.ayear.year";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 16;
			this.label1.Text = "Esercizio:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 23);
			this.label3.TabIndex = 24;
			this.label3.Text = "Detrazione";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox3.Location = new System.Drawing.Point(30, 166);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(499, 39);
			this.textBox3.TabIndex = 25;
			this.textBox3.Text = "Inserire l\'importo della detrazione al LORDO dell\'applicazione di minimali, massi" +
    "mali o quote di applicabilità";
			// 
			// txtLong
			// 
			this.txtLong.AcceptsReturn = true;
			this.txtLong.AcceptsTab = true;
			this.txtLong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLong.Location = new System.Drawing.Point(30, 96);
			this.txtLong.Multiline = true;
			this.txtLong.Name = "txtLong";
			this.txtLong.ReadOnly = true;
			this.txtLong.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLong.Size = new System.Drawing.Size(499, 64);
			this.txtLong.TabIndex = 26;
			this.txtLong.Tag = "abatementcode.longdescription";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(27, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 13);
			this.label2.TabIndex = 27;
			this.label2.Text = "Descrizione ";
			// 
			// Frm_abatableexpense_contrattodetail
			// 
			this.AcceptButton = this.button3;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.button2;
			this.ClientSize = new System.Drawing.Size(541, 274);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtLong);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.cmdTipoDeduzione);
			this.Controls.Add(this.label1);
			this.Name = "Frm_abatableexpense_contrattodetail";
			this.Text = "frmoneredetraibile";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion
	}
}
