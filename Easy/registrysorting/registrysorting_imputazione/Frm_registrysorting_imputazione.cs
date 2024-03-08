
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
using metadatalibrary;

namespace registrysorting_imputazione//classtreecreddebi_anagrafica//
{
	/// <summary>
	/// Summary description for frmclasstreecreddebi_anagrafica.
	/// </summary>
	public class Frm_registrysorting_imputazione : MetaDataForm
	{
		public vistaForm DS;
		private System.Windows.Forms.GroupBox groupCredDeb;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtCreDeb;
		private System.Windows.Forms.GroupBox grpTipoClass;
		private System.Windows.Forms.GroupBox gboxclass;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Button btnCodice;
		private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
		MetaData Meta;
        public string param;
		private System.Windows.Forms.PictureBox pictureBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_registrysorting_imputazione()
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

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() 
		{
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			GetData.SetSorting(DS.registrysortingview,"idreg");
            object idsorkind = null;
            param = Meta.ExtraParameter.ToString();
            DataTable DescrClass = Meta.Conn.RUN_SELECT("sortingkind", "description", null,
                    QHS.CmpEq("idsorkind", param), null, null, true);
            if (DescrClass.Rows.Count == 0)
                Meta.Name = "Imputazione anagrafica a \"" + param + "\"";
            else
                Meta.Name = "Imputazione anagrafica a \"" +
                    DescrClass.Rows[0]["description"].ToString() + "\"";

            Meta.DefaultListType = "lista." + param;
            idsorkind = param;


            string filter = QHS.CmpEq("idsorkind", idsorkind);
            GetData.SetStaticFilter(DS.registrysortingview, filter);
            GetData.SetStaticFilter(DS.sorting, filter);
           
            GetData.CacheTable(DS.sortingkind, filter, null, false);
            gboxclass.Tag += "." + filter;
            btnCodice.Tag += "." + filter;
            DS.sorting.ExtendedProperties[MetaData.ExtraParams] = filter;

           

        }
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_registrysorting_imputazione));
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCreDeb = new System.Windows.Forms.TextBox();
            this.grpTipoClass = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gboxclass = new System.Windows.Forms.GroupBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.btnCodice = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DS = new registrysorting_imputazione.vistaForm();
            this.groupCredDeb.SuspendLayout();
            this.grpTipoClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gboxclass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.label4);
            this.groupCredDeb.Controls.Add(this.txtCreDeb);
            this.groupCredDeb.Location = new System.Drawing.Point(8, 16);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(496, 56);
            this.groupCredDeb.TabIndex = 1;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCreDeb.anagrafica.(active<>\'N\')";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Anagrafica:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCreDeb
            // 
            this.txtCreDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreDeb.Location = new System.Drawing.Point(120, 24);
            this.txtCreDeb.Name = "txtCreDeb";
            this.txtCreDeb.Size = new System.Drawing.Size(360, 20);
            this.txtCreDeb.TabIndex = 1;
            this.txtCreDeb.Tag = "registry.title?registrysortingview.registry";
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
            this.grpTipoClass.Location = new System.Drawing.Point(8, 80);
            this.grpTipoClass.Name = "grpTipoClass";
            this.grpTipoClass.Size = new System.Drawing.Size(496, 109);
            this.grpTipoClass.TabIndex = 2;
            this.grpTipoClass.TabStop = false;
            this.grpTipoClass.Tag = "";
            this.grpTipoClass.Text = "Classificazione";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 41);
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
            this.gboxclass.Location = new System.Drawing.Point(184, 7);
            this.gboxclass.Name = "gboxclass";
            this.gboxclass.Size = new System.Drawing.Size(306, 82);
            this.gboxclass.TabIndex = 2;
            this.gboxclass.TabStop = false;
            this.gboxclass.Tag = "AutoManage.txtCodice.tree";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(120, 16);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(162, 60);
            this.txtDescrizione.TabIndex = 6;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "sorting.description";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(8, 52);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(96, 20);
            this.txtCodice.TabIndex = 2;
            this.txtCodice.Tag = "sorting.sortcode?registrysortingview.sortcode";
            // 
            // btnCodice
            // 
            this.btnCodice.Location = new System.Drawing.Point(8, 20);
            this.btnCodice.Name = "btnCodice";
            this.btnCodice.Size = new System.Drawing.Size(96, 23);
            this.btnCodice.TabIndex = 1;
            this.btnCodice.TabStop = false;
            this.btnCodice.Tag = "manage.sorting.tree";
            this.btnCodice.Text = "Codice";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(104, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Tag = "registrysorting.quota.fixed.2..%.100";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(32, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Quota:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_registrysorting_imputazione
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(512, 209);
            this.Controls.Add(this.grpTipoClass);
            this.Controls.Add(this.groupCredDeb);
            this.Name = "Frm_registrysorting_imputazione";
            this.Text = "frmclasstreecreddebi_imputazione";
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.grpTipoClass.ResumeLayout(false);
            this.grpTipoClass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gboxclass.ResumeLayout(false);
            this.gboxclass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		

		



        public void MetaData_AfterClear() {
            txtCodice.ReadOnly = false;
        }
		public void MetaData_AfterFill()
		{
            if (Meta.EditMode)
                txtCodice.ReadOnly = true;
            else
                txtCodice.ReadOnly = false;
		}
	}
}
