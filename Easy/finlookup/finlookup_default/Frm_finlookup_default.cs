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

namespace finlookup_default//convertbilancio//
{
	/// <summary>
	/// Summary description for frmconvertbilancio.
	/// </summary>
	public class Frm_finlookup_default : System.Windows.Forms.Form
	{
		public vistaForm DS;
		MetaData Meta;
		string filteresercizio;
		string filteresercizionew;
		private System.Windows.Forms.GroupBox grpAnnoCorrente;
		private System.Windows.Forms.GroupBox grpAnnoSuccessivo;
		private System.Windows.Forms.RadioButton rdbSpesaCorr;
		private System.Windows.Forms.RadioButton rdbEntrataCorr;
		private System.Windows.Forms.RadioButton rdbSpesaSucc;
		private System.Windows.Forms.RadioButton rdbEntrataSucc;
		private System.Windows.Forms.Button btnBilancio;
		private System.Windows.Forms.GroupBox grpBilancioCorr;
		private System.Windows.Forms.TextBox txtBilancio;
		private System.Windows.Forms.GroupBox grpBilancioSucc;
		private System.Windows.Forms.TextBox txtNewBilancio;
		private System.Windows.Forms.Button btnNewBilancio;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;


		public Frm_finlookup_default()
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
            DataAccess.SetTableForReading(DS.finview1, "finview");

			filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			string filterupb = QHS.CmpEq("idupb", "0001");

			string filter = GetData.MergeFilters(filteresercizio,filterupb);
			GetData.SetStaticFilter(DS.finview,filter);

			int annonext = Convert.ToInt32(Meta.GetSys("esercizio")) + 1;
			filteresercizionew = QHS.CmpEq("ayear", annonext);

			filter = GetData.MergeFilters(filteresercizionew,filterupb);
			GetData.SetStaticFilter(DS.finview1,filter);

			string filterbilancio = "(oldidfin IN ("+
                "(SELECT idfin FROM fin WHERE " + QHS.CmpEq("ayear", Meta.GetSys("esercizio")) + ")))";
			GetData.SetStaticFilter(DS.finlookup,filterbilancio);
			GetData.SetStaticFilter(DS.finlookupview,filterbilancio);

			GetData.CacheTable(DS.finlevel,filteresercizio,null,false);
			grpAnnoCorrente.Text="Anno " + Meta.GetSys("esercizio").ToString();
			grpAnnoSuccessivo.Text = "Anno " + annonext.ToString();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_finlookup_default));
            this.DS = new finlookup_default.vistaForm();
            this.grpAnnoCorrente = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grpBilancioCorr = new System.Windows.Forms.GroupBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.rdbSpesaCorr = new System.Windows.Forms.RadioButton();
            this.rdbEntrataCorr = new System.Windows.Forms.RadioButton();
            this.grpAnnoSuccessivo = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.grpBilancioSucc = new System.Windows.Forms.GroupBox();
            this.txtNewBilancio = new System.Windows.Forms.TextBox();
            this.rdbSpesaSucc = new System.Windows.Forms.RadioButton();
            this.rdbEntrataSucc = new System.Windows.Forms.RadioButton();
            this.btnNewBilancio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpAnnoCorrente.SuspendLayout();
            this.grpBilancioCorr.SuspendLayout();
            this.grpAnnoSuccessivo.SuspendLayout();
            this.grpBilancioSucc.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // grpAnnoCorrente
            // 
            this.grpAnnoCorrente.Controls.Add(this.grpBilancioCorr);
            this.grpAnnoCorrente.Location = new System.Drawing.Point(8, 8);
            this.grpAnnoCorrente.Name = "grpAnnoCorrente";
            this.grpAnnoCorrente.Size = new System.Drawing.Size(432, 100);
            this.grpAnnoCorrente.TabIndex = 0;
            this.grpAnnoCorrente.TabStop = false;
            this.grpAnnoCorrente.Text = "Anno Corrente";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(194, 8);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(218, 64);
            this.textBox1.TabIndex = 1;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "finview.title?finlookupview.oldtitle";
            // 
            // grpBilancioCorr
            // 
            this.grpBilancioCorr.Controls.Add(this.textBox1);
            this.grpBilancioCorr.Controls.Add(this.txtBilancio);
            this.grpBilancioCorr.Controls.Add(this.btnBilancio);
            this.grpBilancioCorr.Controls.Add(this.rdbSpesaCorr);
            this.grpBilancioCorr.Controls.Add(this.rdbEntrataCorr);
            this.grpBilancioCorr.Location = new System.Drawing.Point(8, 16);
            this.grpBilancioCorr.Name = "grpBilancioCorr";
            this.grpBilancioCorr.Size = new System.Drawing.Size(418, 78);
            this.grpBilancioCorr.TabIndex = 0;
            this.grpBilancioCorr.TabStop = false;
            this.grpBilancioCorr.Tag = "";
            this.grpBilancioCorr.Text = "Codice di Bilancio Attuale";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(88, 32);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(100, 20);
            this.txtBilancio.TabIndex = 3;
            this.txtBilancio.Tag = "finview.codefin?finlookupview.oldcodefin";
            // 
            // btnBilancio
            // 
            this.btnBilancio.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(8, 32);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(75, 23);
            this.btnBilancio.TabIndex = 2;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // rdbSpesaCorr
            // 
            this.rdbSpesaCorr.Location = new System.Drawing.Point(96, 16);
            this.rdbSpesaCorr.Name = "rdbSpesaCorr";
            this.rdbSpesaCorr.Size = new System.Drawing.Size(64, 16);
            this.rdbSpesaCorr.TabIndex = 1;
            this.rdbSpesaCorr.Tag = "finview.finpart:S?finlookupview.oldpartfin:S";
            this.rdbSpesaCorr.Text = "Spesa";
            this.rdbSpesaCorr.CheckedChanged += new System.EventHandler(this.rdbSpesaCorr_CheckedChanged);
            // 
            // rdbEntrataCorr
            // 
            this.rdbEntrataCorr.Checked = true;
            this.rdbEntrataCorr.Location = new System.Drawing.Point(8, 16);
            this.rdbEntrataCorr.Name = "rdbEntrataCorr";
            this.rdbEntrataCorr.Size = new System.Drawing.Size(64, 16);
            this.rdbEntrataCorr.TabIndex = 0;
            this.rdbEntrataCorr.TabStop = true;
            this.rdbEntrataCorr.Tag = "finview.finpart:E?finlookupview.oldpartfin:E";
            this.rdbEntrataCorr.Text = "Entrata";
            this.rdbEntrataCorr.CheckedChanged += new System.EventHandler(this.rdbEntrataCorr_CheckedChanged);
            // 
            // grpAnnoSuccessivo
            // 
            this.grpAnnoSuccessivo.Controls.Add(this.grpBilancioSucc);
            this.grpAnnoSuccessivo.Location = new System.Drawing.Point(8, 112);
            this.grpAnnoSuccessivo.Name = "grpAnnoSuccessivo";
            this.grpAnnoSuccessivo.Size = new System.Drawing.Size(432, 100);
            this.grpAnnoSuccessivo.TabIndex = 1;
            this.grpAnnoSuccessivo.TabStop = false;
            this.grpAnnoSuccessivo.Text = "Anno Successivo";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(194, 8);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(220, 58);
            this.textBox2.TabIndex = 1;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "finview1.title?finlookupview.newtitle";
            // 
            // grpBilancioSucc
            // 
            this.grpBilancioSucc.Controls.Add(this.textBox2);
            this.grpBilancioSucc.Controls.Add(this.txtNewBilancio);
            this.grpBilancioSucc.Controls.Add(this.rdbSpesaSucc);
            this.grpBilancioSucc.Controls.Add(this.rdbEntrataSucc);
            this.grpBilancioSucc.Controls.Add(this.btnNewBilancio);
            this.grpBilancioSucc.Location = new System.Drawing.Point(8, 16);
            this.grpBilancioSucc.Name = "grpBilancioSucc";
            this.grpBilancioSucc.Size = new System.Drawing.Size(420, 72);
            this.grpBilancioSucc.TabIndex = 0;
            this.grpBilancioSucc.TabStop = false;
            this.grpBilancioSucc.Tag = "";
            this.grpBilancioSucc.Text = "Nuovo Codice di Bilancio";
            // 
            // txtNewBilancio
            // 
            this.txtNewBilancio.Location = new System.Drawing.Point(88, 40);
            this.txtNewBilancio.Name = "txtNewBilancio";
            this.txtNewBilancio.Size = new System.Drawing.Size(100, 20);
            this.txtNewBilancio.TabIndex = 2;
            this.txtNewBilancio.Tag = "finview1.codefin?finlookupview.newfincode";
            // 
            // rdbSpesaSucc
            // 
            this.rdbSpesaSucc.Enabled = false;
            this.rdbSpesaSucc.Location = new System.Drawing.Point(96, 16);
            this.rdbSpesaSucc.Name = "rdbSpesaSucc";
            this.rdbSpesaSucc.Size = new System.Drawing.Size(64, 16);
            this.rdbSpesaSucc.TabIndex = 1;
            this.rdbSpesaSucc.Tag = "finview1.finpart:S?finlookupview.newpartfin:S";
            this.rdbSpesaSucc.Text = "Spesa";
            this.rdbSpesaSucc.CheckedChanged += new System.EventHandler(this.rdbSpesaSucc_CheckedChanged);
            // 
            // rdbEntrataSucc
            // 
            this.rdbEntrataSucc.Checked = true;
            this.rdbEntrataSucc.Enabled = false;
            this.rdbEntrataSucc.Location = new System.Drawing.Point(8, 16);
            this.rdbEntrataSucc.Name = "rdbEntrataSucc";
            this.rdbEntrataSucc.Size = new System.Drawing.Size(64, 16);
            this.rdbEntrataSucc.TabIndex = 0;
            this.rdbEntrataSucc.TabStop = true;
            this.rdbEntrataSucc.Tag = "finview1.finpart:E?finlookupview.newpartfin:E";
            this.rdbEntrataSucc.Text = "Entrata";
            this.rdbEntrataSucc.CheckedChanged += new System.EventHandler(this.rdbEntrataSucc_CheckedChanged);
            // 
            // btnNewBilancio
            // 
            this.btnNewBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewBilancio.ImageIndex = 0;
            this.btnNewBilancio.ImageList = this.imageList1;
            this.btnNewBilancio.Location = new System.Drawing.Point(8, 40);
            this.btnNewBilancio.Name = "btnNewBilancio";
            this.btnNewBilancio.Size = new System.Drawing.Size(75, 23);
            this.btnNewBilancio.TabIndex = 1;
            this.btnNewBilancio.TabStop = false;
            this.btnNewBilancio.Tag = "";
            this.btnNewBilancio.Text = "Bilancio";
            this.btnNewBilancio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frm_finlookup_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(448, 222);
            this.Controls.Add(this.grpAnnoSuccessivo);
            this.Controls.Add(this.grpAnnoCorrente);
            this.Name = "Frm_finlookup_default";
            this.Text = "frmconvertbilancio";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpAnnoCorrente.ResumeLayout(false);
            this.grpBilancioCorr.ResumeLayout(false);
            this.grpBilancioCorr.PerformLayout();
            this.grpAnnoSuccessivo.ResumeLayout(false);
            this.grpBilancioSucc.ResumeLayout(false);
            this.grpBilancioSucc.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_BeforeFill()
		{
			if ((Meta.InsertMode)&&(Meta.FirstFillForThisRow)){
				rdbEntrataCorr.Tag = "E"; 
			}
			else{
				SetTagEntrataCorr();
			}
		}

		public void MetaData_AfterFill()
		{
			rdbEntrataSucc.Checked = rdbEntrataCorr.Checked;
			rdbSpesaSucc.Checked = rdbSpesaCorr.Checked;
			if ((Meta.InsertMode)||(Meta.EditMode))
			{
				rdbEntrataSucc.Enabled=false;
				rdbSpesaSucc.Enabled=false;
			}
		}

		public void SetTagEntrataCorr()
		{
			rdbEntrataCorr.Tag = "finview.finpart:E?finlookupview.oldpartfin:E";
		}

		public void MetaData_AfterClear()
		{
			// Di default pongo Entrata in fase di ricerca
			rdbEntrataCorr.Checked= true;//false; sa
			rdbEntrataSucc.Checked= true;//false; sa

			rdbSpesaCorr.Checked=false;
			rdbSpesaSucc.Checked=false;
	
		}

		private void rdbEntrataCorr_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbEntrataCorr.Checked)
			{
                string filter = QHS.AppAnd(QHS.CmpEq("idupb", "0001"), QHS.CmpEq("finpart", "E"));
                DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
                btnBilancio.Tag = "manage.finview.treealle." + filter; 
                grpBilancioCorr.Tag = "AutoManage.txtBilancio.treealle."+filter;
                Meta.SetAutoMode(grpBilancioCorr);
				rdbEntrataSucc.Checked=true;
			}
			if (!Meta.DrawStateIsDone)return;
			DS.finview.Clear();
			if (Meta.IsEmpty) return;
		}

		private void rdbSpesaCorr_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbSpesaCorr.Checked)
			{
                string filter = QHS.AppAnd(QHS.CmpEq("idupb", "0001"),QHS.CmpEq("finpart","S"));
                DS.finview.ExtendedProperties[MetaData.ExtraParams] = filter;
                btnBilancio.Tag = "manage.finview.treealls." + filter;
                grpBilancioCorr.Tag = "AutoManage.txtBilancio.treealls." + filter;
                Meta.SetAutoMode(grpBilancioCorr);
				rdbSpesaSucc.Checked=true;

				//SetTagEntrataCorr();
			}
			if (!Meta.DrawStateIsDone)return;
			DS.finview.Clear();
			if (Meta.IsEmpty) return;
		}

		private void rdbEntrataSucc_CheckedChanged(object sender, System.EventArgs e)
		{	
			if (rdbEntrataSucc.Checked)
			{
                string filter = QHS.AppAnd(QHS.CmpEq("idupb", "0001"),QHS.CmpEq("finpart","E"));
                DS.finview1.ExtendedProperties[MetaData.ExtraParams] = filter;
				btnNewBilancio.Tag="manage.finview1.treeallenew."+filter;//treesnew
                grpBilancioSucc.Tag = "AutoManage.txtNewBilancio.treeallenew." + filter;
                Meta.SetAutoMode(grpBilancioSucc);
			}
			if (!Meta.DrawStateIsDone)return;
			DS.finview1.Clear();
			if (Meta.IsEmpty) return;
		}

		private void rdbSpesaSucc_CheckedChanged(object sender, System.EventArgs e)
		{

			if (rdbSpesaSucc.Checked)
			{
                string filter = QHS.AppAnd(QHS.CmpEq("idupb", "0001"), QHS.CmpEq("finpart", "S"));
                DS.finview1.ExtendedProperties[MetaData.ExtraParams] = filter;
				btnNewBilancio.Tag="manage.finview1.treeallsnew."+filter;//treesnew
                grpBilancioSucc.Tag = "AutoManage.txtNewBilancio.treeallsnew." + filter;
                Meta.SetAutoMode(grpBilancioSucc);
            }
			if (!Meta.DrawStateIsDone)return;
			DS.finview1.Clear();
			if (Meta.IsEmpty) return;
		}
	}
}
