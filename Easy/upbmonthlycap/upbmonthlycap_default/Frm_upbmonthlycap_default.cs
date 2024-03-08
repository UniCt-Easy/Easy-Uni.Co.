
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
using System.Data;
using SituazioneViewer;
using funzioni_configurazione;
using metadatalibrary;
using System.Globalization;

namespace upbmonthlycap_default {
	/// <summary>
	/// Summary description for Frm_upb_default.
	/// </summary>
	public class Frm_upbmonthlycap_default : MetaDataForm
	{
		MetaData Meta;
		DataAccess Conn;
		CQueryHelper QHC;
		QueryHelper QHS;
		public upbmonthlycap_default.vistaForm DS;
		private TextBox txtEsercizio;
		private Label labelEsercizio;
		private TextBox txtAmount1;
		private Label labelReserve;
		private TextBox txtAmountReserve;
		private Label labelMonth12;
		private TextBox txtAmount12;
		private Label labelMonth11;
		private TextBox txtAmount11;
		private Label labelMonth10;
		private TextBox txtAmount10;
		private Label labelMonth9;
		private TextBox txtAmount9;
		private Label labelMonth8;
		private TextBox txtAmount8;
		private Label labelMonth7;
		private TextBox txtAmount7;
		private Label labelMonth6;
		private TextBox txtAmount6;
		private Label labelMonth5;
		private TextBox txtAmount5;
		private Label labelMonth4;
		private TextBox txtAmount4;
		private Label labelMonth3;
		private TextBox txtAmount3;
		private Label labelMonth2;
		private TextBox txtAmount2;
		private Label labelMonth1;
		private Panel panel1;
		private GroupBox gboxUPB;
		public TextBox txtUPB;
		private TextBox txtDescrUPB;
		private Button btnUPBCode;
		private System.ComponentModel.IContainer components;					
		
		public Frm_upbmonthlycap_default() {
			InitializeComponent();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.labelEsercizio = new System.Windows.Forms.Label();
			this.txtAmount1 = new System.Windows.Forms.TextBox();
			this.DS = new upbmonthlycap_default.vistaForm();
			this.labelMonth1 = new System.Windows.Forms.Label();
			this.txtAmount2 = new System.Windows.Forms.TextBox();
			this.labelMonth2 = new System.Windows.Forms.Label();
			this.labelMonth3 = new System.Windows.Forms.Label();
			this.txtAmount3 = new System.Windows.Forms.TextBox();
			this.labelMonth4 = new System.Windows.Forms.Label();
			this.txtAmount4 = new System.Windows.Forms.TextBox();
			this.labelMonth5 = new System.Windows.Forms.Label();
			this.txtAmount5 = new System.Windows.Forms.TextBox();
			this.labelMonth6 = new System.Windows.Forms.Label();
			this.txtAmount6 = new System.Windows.Forms.TextBox();
			this.labelMonth12 = new System.Windows.Forms.Label();
			this.txtAmount12 = new System.Windows.Forms.TextBox();
			this.labelMonth11 = new System.Windows.Forms.Label();
			this.txtAmount11 = new System.Windows.Forms.TextBox();
			this.labelMonth10 = new System.Windows.Forms.Label();
			this.txtAmount10 = new System.Windows.Forms.TextBox();
			this.labelMonth9 = new System.Windows.Forms.Label();
			this.txtAmount9 = new System.Windows.Forms.TextBox();
			this.labelMonth8 = new System.Windows.Forms.Label();
			this.txtAmount8 = new System.Windows.Forms.TextBox();
			this.labelMonth7 = new System.Windows.Forms.Label();
			this.txtAmount7 = new System.Windows.Forms.TextBox();
			this.labelReserve = new System.Windows.Forms.Label();
			this.txtAmountReserve = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.panel1.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(562, 72);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.ReadOnly = true;
			this.txtEsercizio.Size = new System.Drawing.Size(66, 20);
			this.txtEsercizio.TabIndex = 0;
			this.txtEsercizio.Tag = "upbmonthlycap.ayear.year";
			// 
			// labelEsercizio
			// 
			this.labelEsercizio.AutoSize = true;
			this.labelEsercizio.Location = new System.Drawing.Point(559, 59);
			this.labelEsercizio.Name = "labelEsercizio";
			this.labelEsercizio.Size = new System.Drawing.Size(49, 13);
			this.labelEsercizio.TabIndex = 1;
			this.labelEsercizio.Text = "Esercizio";
			// 
			// txtAmount1
			// 
			this.txtAmount1.Location = new System.Drawing.Point(14, 21);
			this.txtAmount1.Name = "txtAmount1";
			this.txtAmount1.Size = new System.Drawing.Size(137, 20);
			this.txtAmount1.TabIndex = 4;
			this.txtAmount1.Tag = "upbmonthlycap.amount_1";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// labelMonth1
			// 
			this.labelMonth1.AutoSize = true;
			this.labelMonth1.Location = new System.Drawing.Point(11, 7);
			this.labelMonth1.Name = "labelMonth1";
			this.labelMonth1.Size = new System.Drawing.Size(47, 13);
			this.labelMonth1.TabIndex = 5;
			this.labelMonth1.Text = "Gennaio";
			// 
			// txtAmount2
			// 
			this.txtAmount2.Location = new System.Drawing.Point(170, 21);
			this.txtAmount2.Name = "txtAmount2";
			this.txtAmount2.Size = new System.Drawing.Size(137, 20);
			this.txtAmount2.TabIndex = 6;
			this.txtAmount2.Tag = "upbmonthlycap.amount_2";
			// 
			// labelMonth2
			// 
			this.labelMonth2.AutoSize = true;
			this.labelMonth2.Location = new System.Drawing.Point(167, 7);
			this.labelMonth2.Name = "labelMonth2";
			this.labelMonth2.Size = new System.Drawing.Size(48, 13);
			this.labelMonth2.TabIndex = 7;
			this.labelMonth2.Text = "Febbraio";
			// 
			// labelMonth3
			// 
			this.labelMonth3.AutoSize = true;
			this.labelMonth3.Location = new System.Drawing.Point(323, 7);
			this.labelMonth3.Name = "labelMonth3";
			this.labelMonth3.Size = new System.Drawing.Size(36, 13);
			this.labelMonth3.TabIndex = 9;
			this.labelMonth3.Text = "Marzo";
			// 
			// txtAmount3
			// 
			this.txtAmount3.Location = new System.Drawing.Point(326, 21);
			this.txtAmount3.Name = "txtAmount3";
			this.txtAmount3.Size = new System.Drawing.Size(137, 20);
			this.txtAmount3.TabIndex = 8;
			this.txtAmount3.Tag = "upbmonthlycap.amount_3";
			// 
			// labelMonth4
			// 
			this.labelMonth4.AutoSize = true;
			this.labelMonth4.Location = new System.Drawing.Point(479, 7);
			this.labelMonth4.Name = "labelMonth4";
			this.labelMonth4.Size = new System.Drawing.Size(33, 13);
			this.labelMonth4.TabIndex = 11;
			this.labelMonth4.Text = "Aprile";
			// 
			// txtAmount4
			// 
			this.txtAmount4.Location = new System.Drawing.Point(482, 21);
			this.txtAmount4.Name = "txtAmount4";
			this.txtAmount4.Size = new System.Drawing.Size(137, 20);
			this.txtAmount4.TabIndex = 10;
			this.txtAmount4.Tag = "upbmonthlycap.amount_4";
			// 
			// labelMonth5
			// 
			this.labelMonth5.AutoSize = true;
			this.labelMonth5.Location = new System.Drawing.Point(11, 62);
			this.labelMonth5.Name = "labelMonth5";
			this.labelMonth5.Size = new System.Drawing.Size(42, 13);
			this.labelMonth5.TabIndex = 13;
			this.labelMonth5.Text = "Maggio";
			// 
			// txtAmount5
			// 
			this.txtAmount5.Location = new System.Drawing.Point(14, 76);
			this.txtAmount5.Name = "txtAmount5";
			this.txtAmount5.Size = new System.Drawing.Size(137, 20);
			this.txtAmount5.TabIndex = 12;
			this.txtAmount5.Tag = "upbmonthlycap.amount_5";
			// 
			// labelMonth6
			// 
			this.labelMonth6.AutoSize = true;
			this.labelMonth6.Location = new System.Drawing.Point(167, 62);
			this.labelMonth6.Name = "labelMonth6";
			this.labelMonth6.Size = new System.Drawing.Size(41, 13);
			this.labelMonth6.TabIndex = 15;
			this.labelMonth6.Text = "Giugno";
			// 
			// txtAmount6
			// 
			this.txtAmount6.Location = new System.Drawing.Point(170, 76);
			this.txtAmount6.Name = "txtAmount6";
			this.txtAmount6.Size = new System.Drawing.Size(137, 20);
			this.txtAmount6.TabIndex = 14;
			this.txtAmount6.Tag = "upbmonthlycap.amount_6";
			// 
			// labelMonth12
			// 
			this.labelMonth12.AutoSize = true;
			this.labelMonth12.Location = new System.Drawing.Point(479, 116);
			this.labelMonth12.Name = "labelMonth12";
			this.labelMonth12.Size = new System.Drawing.Size(52, 13);
			this.labelMonth12.TabIndex = 27;
			this.labelMonth12.Text = "Dicembre";
			// 
			// txtAmount12
			// 
			this.txtAmount12.Location = new System.Drawing.Point(482, 130);
			this.txtAmount12.Name = "txtAmount12";
			this.txtAmount12.Size = new System.Drawing.Size(137, 20);
			this.txtAmount12.TabIndex = 26;
			this.txtAmount12.Tag = "upbmonthlycap.amount_12";
			// 
			// labelMonth11
			// 
			this.labelMonth11.AutoSize = true;
			this.labelMonth11.Location = new System.Drawing.Point(323, 116);
			this.labelMonth11.Name = "labelMonth11";
			this.labelMonth11.Size = new System.Drawing.Size(56, 13);
			this.labelMonth11.TabIndex = 25;
			this.labelMonth11.Text = "Novembre";
			// 
			// txtAmount11
			// 
			this.txtAmount11.Location = new System.Drawing.Point(326, 130);
			this.txtAmount11.Name = "txtAmount11";
			this.txtAmount11.Size = new System.Drawing.Size(137, 20);
			this.txtAmount11.TabIndex = 24;
			this.txtAmount11.Tag = "upbmonthlycap.amount_11";
			// 
			// labelMonth10
			// 
			this.labelMonth10.AutoSize = true;
			this.labelMonth10.Location = new System.Drawing.Point(168, 116);
			this.labelMonth10.Name = "labelMonth10";
			this.labelMonth10.Size = new System.Drawing.Size(42, 13);
			this.labelMonth10.TabIndex = 23;
			this.labelMonth10.Text = "Ottobre";
			// 
			// txtAmount10
			// 
			this.txtAmount10.Location = new System.Drawing.Point(170, 130);
			this.txtAmount10.Name = "txtAmount10";
			this.txtAmount10.Size = new System.Drawing.Size(137, 20);
			this.txtAmount10.TabIndex = 22;
			this.txtAmount10.Tag = "upbmonthlycap.amount_10";
			// 
			// labelMonth9
			// 
			this.labelMonth9.AutoSize = true;
			this.labelMonth9.Location = new System.Drawing.Point(11, 116);
			this.labelMonth9.Name = "labelMonth9";
			this.labelMonth9.Size = new System.Drawing.Size(55, 13);
			this.labelMonth9.TabIndex = 21;
			this.labelMonth9.Text = "Settembre";
			// 
			// txtAmount9
			// 
			this.txtAmount9.Location = new System.Drawing.Point(14, 130);
			this.txtAmount9.Name = "txtAmount9";
			this.txtAmount9.Size = new System.Drawing.Size(137, 20);
			this.txtAmount9.TabIndex = 20;
			this.txtAmount9.Tag = "upbmonthlycap.amount_9";
			// 
			// labelMonth8
			// 
			this.labelMonth8.AutoSize = true;
			this.labelMonth8.Location = new System.Drawing.Point(479, 62);
			this.labelMonth8.Name = "labelMonth8";
			this.labelMonth8.Size = new System.Drawing.Size(40, 13);
			this.labelMonth8.TabIndex = 19;
			this.labelMonth8.Text = "Agosto";
			// 
			// txtAmount8
			// 
			this.txtAmount8.Location = new System.Drawing.Point(482, 76);
			this.txtAmount8.Name = "txtAmount8";
			this.txtAmount8.Size = new System.Drawing.Size(137, 20);
			this.txtAmount8.TabIndex = 18;
			this.txtAmount8.Tag = "upbmonthlycap.amount_8";
			// 
			// labelMonth7
			// 
			this.labelMonth7.AutoSize = true;
			this.labelMonth7.Location = new System.Drawing.Point(323, 62);
			this.labelMonth7.Name = "labelMonth7";
			this.labelMonth7.Size = new System.Drawing.Size(35, 13);
			this.labelMonth7.TabIndex = 17;
			this.labelMonth7.Text = "Luglio";
			// 
			// txtAmount7
			// 
			this.txtAmount7.Location = new System.Drawing.Point(326, 76);
			this.txtAmount7.Name = "txtAmount7";
			this.txtAmount7.Size = new System.Drawing.Size(137, 20);
			this.txtAmount7.TabIndex = 16;
			this.txtAmount7.Tag = "upbmonthlycap.amount_7";
			// 
			// labelReserve
			// 
			this.labelReserve.AutoSize = true;
			this.labelReserve.Location = new System.Drawing.Point(11, 170);
			this.labelReserve.Name = "labelReserve";
			this.labelReserve.Size = new System.Drawing.Size(43, 13);
			this.labelReserve.TabIndex = 29;
			this.labelReserve.Text = "Riserva";
			// 
			// txtAmountReserve
			// 
			this.txtAmountReserve.Location = new System.Drawing.Point(14, 184);
			this.txtAmountReserve.Name = "txtAmountReserve";
			this.txtAmountReserve.Size = new System.Drawing.Size(137, 20);
			this.txtAmountReserve.TabIndex = 28;
			this.txtAmountReserve.Tag = "upbmonthlycap.amount_reserve";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.labelReserve);
			this.panel1.Controls.Add(this.txtAmount1);
			this.panel1.Controls.Add(this.txtAmountReserve);
			this.panel1.Controls.Add(this.labelMonth1);
			this.panel1.Controls.Add(this.labelMonth12);
			this.panel1.Controls.Add(this.txtAmount2);
			this.panel1.Controls.Add(this.txtAmount12);
			this.panel1.Controls.Add(this.labelMonth2);
			this.panel1.Controls.Add(this.labelMonth11);
			this.panel1.Controls.Add(this.txtAmount3);
			this.panel1.Controls.Add(this.txtAmount11);
			this.panel1.Controls.Add(this.labelMonth3);
			this.panel1.Controls.Add(this.labelMonth10);
			this.panel1.Controls.Add(this.txtAmount4);
			this.panel1.Controls.Add(this.txtAmount10);
			this.panel1.Controls.Add(this.labelMonth4);
			this.panel1.Controls.Add(this.labelMonth9);
			this.panel1.Controls.Add(this.txtAmount5);
			this.panel1.Controls.Add(this.txtAmount9);
			this.panel1.Controls.Add(this.labelMonth5);
			this.panel1.Controls.Add(this.labelMonth8);
			this.panel1.Controls.Add(this.txtAmount6);
			this.panel1.Controls.Add(this.txtAmount8);
			this.panel1.Controls.Add(this.labelMonth6);
			this.panel1.Controls.Add(this.labelMonth7);
			this.panel1.Controls.Add(this.txtAmount7);
			this.panel1.Location = new System.Drawing.Point(10, 107);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(629, 220);
			this.panel1.TabIndex = 7;
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.gboxUPB.Location = new System.Drawing.Point(12, 12);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(541, 89);
			this.gboxUPB.TabIndex = 8;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.limitespesa.(active=\'S\' )";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(11, 60);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(524, 20);
			this.txtUPB.TabIndex = 5;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(178, 10);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(357, 44);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// btnUPBCode
			// 
			this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPBCode.Location = new System.Drawing.Point(11, 34);
			this.btnUPBCode.Name = "btnUPBCode";
			this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
			this.btnUPBCode.TabIndex = 2;
			this.btnUPBCode.TabStop = false;
			this.btnUPBCode.Tag = "manage.upb.tree";
			this.btnUPBCode.Text = "UPB";
			this.btnUPBCode.UseVisualStyleBackColor = false;
			// 
			// Frm_upbmonthlycap_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(647, 332);
			this.Controls.Add(this.gboxUPB);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.labelEsercizio);
			this.Controls.Add(this.txtEsercizio);
			this.Name = "Frm_upbmonthlycap_default";
			this.Text = "Frm_upbmonthlycap_default";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing) {
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
			QHC = new CQueryHelper();
			QHS = Conn.GetQueryHelper();
			Meta.CanInsertCopy = false;
			string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.upbmonthlycap, filtereserc);
			GetData.SetStaticFilter(DS.upbmonthlycapview, filtereserc);
			GetData.SetStaticFilter(DS.upbyear, filtereserc);
			GetData.SetStaticFilter(DS.upbyearview, filtereserc);
		}

		public void MetaData_AfterClear() {
			txtUPB.Text = "" ;
			txtAmount1.Text = "";
			txtAmount2.Text = "";
			txtAmount3.Text = "";
			txtAmount4.Text = "";
			txtAmount5.Text = "";
			txtAmount6.Text = "";
			txtAmount7.Text = "";
			txtAmount8.Text = "";
			txtAmount9.Text = "";
			txtAmount10.Text = "";
			txtAmount11.Text = "";
			txtAmount12.Text = "";
			txtAmountReserve.Text = "";
			txtEsercizio.Text = Meta.Conn.GetEsercizio().ToString();
		}		
	}
}
