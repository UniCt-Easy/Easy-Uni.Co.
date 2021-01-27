
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace servicecsamask_default
{
	/// <summary>
    /// Summary description for Frm_servicecsamask_default.
	/// </summary>
	public class Frm_servicecsamask_default : System.Windows.Forms.Form
    {
        private System.Windows.Forms.ImageList images;
        public vistaForm DS;
        private System.ComponentModel.IContainer components;
        private TextBox textBox2;
        private Label label2;
        private GroupBox grpEtichette;
        public CheckBox chkCsaUsability7;
        public CheckBox chkCsaUsability6;
        public CheckBox chkCsaUsability5;
        public CheckBox chkCsaUsability4;
        public CheckBox chkCsaUsability3;
        public CheckBox chkCsaUsability2;
        public CheckBox chkCsaUsability1;
        private TextBox textBox1;
        private Label label3;
        public CheckBox chkCsaUsability8;
        MetaData Meta;
		

		public Frm_servicecsamask_default()
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

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            HelpForm.SetDenyNull(DS.servicecsamask.Columns["value"], true);
            VisualizzaCheckBox();
         }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_servicecsamask_default));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.DS = new servicecsamask_default.vistaForm();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpEtichette = new System.Windows.Forms.GroupBox();
            this.chkCsaUsability7 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability6 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability5 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability4 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability3 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability2 = new System.Windows.Forms.CheckBox();
            this.chkCsaUsability1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkCsaUsability8 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpEtichette.SuspendLayout();
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(23, 41);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(98, 20);
            this.textBox2.TabIndex = 13;
            this.textBox2.Tag = "servicecsamask.value";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Valore maschera:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpEtichette
            // 
            this.grpEtichette.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEtichette.Controls.Add(this.chkCsaUsability8);
            this.grpEtichette.Controls.Add(this.chkCsaUsability7);
            this.grpEtichette.Controls.Add(this.chkCsaUsability6);
            this.grpEtichette.Controls.Add(this.chkCsaUsability5);
            this.grpEtichette.Controls.Add(this.chkCsaUsability4);
            this.grpEtichette.Controls.Add(this.chkCsaUsability3);
            this.grpEtichette.Controls.Add(this.chkCsaUsability2);
            this.grpEtichette.Controls.Add(this.chkCsaUsability1);
            this.grpEtichette.Location = new System.Drawing.Point(12, 123);
            this.grpEtichette.Name = "grpEtichette";
            this.grpEtichette.Size = new System.Drawing.Size(511, 239);
            this.grpEtichette.TabIndex = 11;
            this.grpEtichette.TabStop = false;
            // 
            // chkCsaUsability7
            // 
            this.chkCsaUsability7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability7.AutoSize = true;
            this.chkCsaUsability7.Location = new System.Drawing.Point(12, 190);
            this.chkCsaUsability7.Name = "chkCsaUsability7";
            this.chkCsaUsability7.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability7.TabIndex = 96;
            this.chkCsaUsability7.Tag = " servicecsamask.value:6";
            this.chkCsaUsability7.Text = " ";
            this.chkCsaUsability7.Visible = false;
            // 
            // chkCsaUsability6
            // 
            this.chkCsaUsability6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability6.AutoSize = true;
            this.chkCsaUsability6.Location = new System.Drawing.Point(11, 167);
            this.chkCsaUsability6.Name = "chkCsaUsability6";
            this.chkCsaUsability6.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability6.TabIndex = 95;
            this.chkCsaUsability6.Tag = " servicecsamask.value:5";
            this.chkCsaUsability6.Text = " ";
            this.chkCsaUsability6.Visible = false;
            // 
            // chkCsaUsability5
            // 
            this.chkCsaUsability5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability5.AutoSize = true;
            this.chkCsaUsability5.Location = new System.Drawing.Point(11, 138);
            this.chkCsaUsability5.Name = "chkCsaUsability5";
            this.chkCsaUsability5.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability5.TabIndex = 94;
            this.chkCsaUsability5.Tag = " servicecsamask.value:4";
            this.chkCsaUsability5.Text = " ";
            this.chkCsaUsability5.Visible = false;
            // 
            // chkCsaUsability4
            // 
            this.chkCsaUsability4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability4.AutoSize = true;
            this.chkCsaUsability4.Location = new System.Drawing.Point(11, 110);
            this.chkCsaUsability4.Name = "chkCsaUsability4";
            this.chkCsaUsability4.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability4.TabIndex = 93;
            this.chkCsaUsability4.Tag = " servicecsamask.value:3";
            this.chkCsaUsability4.Text = " ";
            this.chkCsaUsability4.Visible = false;
            // 
            // chkCsaUsability3
            // 
            this.chkCsaUsability3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability3.AutoSize = true;
            this.chkCsaUsability3.Location = new System.Drawing.Point(11, 78);
            this.chkCsaUsability3.Name = "chkCsaUsability3";
            this.chkCsaUsability3.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability3.TabIndex = 92;
            this.chkCsaUsability3.Tag = " servicecsamask.value:2";
            this.chkCsaUsability3.Text = " ";
            this.chkCsaUsability3.Visible = false;
            // 
            // chkCsaUsability2
            // 
            this.chkCsaUsability2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability2.AutoSize = true;
            this.chkCsaUsability2.Location = new System.Drawing.Point(11, 46);
            this.chkCsaUsability2.Name = "chkCsaUsability2";
            this.chkCsaUsability2.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability2.TabIndex = 91;
            this.chkCsaUsability2.Tag = " servicecsamask.value:1";
            this.chkCsaUsability2.Text = " ";
            this.chkCsaUsability2.Visible = false;
            // 
            // chkCsaUsability1
            // 
            this.chkCsaUsability1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability1.AutoSize = true;
            this.chkCsaUsability1.Location = new System.Drawing.Point(11, 15);
            this.chkCsaUsability1.Name = "chkCsaUsability1";
            this.chkCsaUsability1.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability1.TabIndex = 90;
            this.chkCsaUsability1.Tag = "servicecsamask.value:0";
            this.chkCsaUsability1.Text = " ";
            this.chkCsaUsability1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(25, 97);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(328, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Tag = "servicecsamask.description";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(23, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Descrizione:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkCsaUsability8
            // 
            this.chkCsaUsability8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkCsaUsability8.AutoSize = true;
            this.chkCsaUsability8.Location = new System.Drawing.Point(11, 213);
            this.chkCsaUsability8.Name = "chkCsaUsability8";
            this.chkCsaUsability8.Size = new System.Drawing.Size(29, 17);
            this.chkCsaUsability8.TabIndex = 97;
            this.chkCsaUsability8.Tag = " servicecsamask.value:7";
            this.chkCsaUsability8.Text = " ";
            this.chkCsaUsability8.Visible = false;
            // 
            // Frm_servicecsamask_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(535, 374);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpEtichette);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Name = "Frm_servicecsamask_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpEtichette.ResumeLayout(false);
            this.grpEtichette.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private void VisualizzaCheckBox()
        {
            int n_chk = 8;
            for (int i = 1; i <= (n_chk - 1); i++)
            {
                CheckBox chk = GetCtrlByName("chkCsaUsability" + n_chk.ToString()) as CheckBox;
                if (chk == null) return;
                chk.Visible = false;
            }

            string num = ""; int bitposition=0;
            DataTable tservicecsausability = Meta.Conn.RUN_SELECT("servicecsausability", "*", null, null, null, null, true);
            foreach (DataRow r in tservicecsausability.Rows)
            {
                num = r["idlabel"].ToString();
                bitposition = CfgFn.GetNoNullInt32(r["bitposition"]);
                string dicitura = r["description"].ToString();

                    CheckBox CB = GetCtrlByName("chkCsaUsability" + num) as CheckBox;
                    if (CB == null)
                        continue;
                    CB.Text = dicitura;
                    CB.Tag = "servicecsamask.value:" + bitposition.ToString();
                    CB.Visible = true;                
            }

        }


        private object GetCtrlByName(string Name)
        {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            return Ctrl.GetValue(this);
        }

        private void chkCsaUsability_CheckedChanged(object sender, EventArgs e)
        {
           
        }
	}
}
