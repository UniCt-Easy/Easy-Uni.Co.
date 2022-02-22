
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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

namespace exportfunctionparam_single
{
	/// <summary>
	/// Summary description for frmRadio.
	/// </summary>
	public class frmRadio : MetaDataForm
	{
		private System.Windows.Forms.TextBox txtRadioDesc2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox txtRadioVal2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtRadioDesc3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtRadioVal3;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtRadioDesc4;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtRadioVal4;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtRadioDesc5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtRadioVal5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtRadioDesc1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtRadioVal1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        private TextBox txtRadioDesc7;
        private Label label2;
        private TextBox txtRadioVal7;
        private Label label3;
        private TextBox txtRadioDesc8;
        private Label label4;
        private TextBox txtRadioVal8;
        private Label label14;
        private TextBox txtRadioDesc9;
        private Label label15;
        private TextBox txtRadioVal9;
        private Label label16;
        private TextBox txtRadioDesc10;
        private Label label17;
        private TextBox txtRadioVal10;
        private Label label18;
        private TextBox txtRadioDesc6;
        private Label label19;
        private TextBox txtRadioVal6;
        private Label label20;
        private TextBox txtRadioDesc12;
        private Label label21;
        private TextBox txtRadioVal12;
        private Label label22;
        private TextBox txtRadioDesc13;
        private Label label23;
        private TextBox txtRadioVal13;
        private Label label24;
        private TextBox txtRadioDesc14;
        private Label label25;
        private TextBox txtRadioVal14;
        private Label label26;
        private TextBox txtRadioDesc15;
        private Label label27;
        private TextBox txtRadioVal15;
        private Label label28;
        private TextBox txtRadioDesc11;
        private Label label29;
        private TextBox txtRadioVal11;
        private Label label30;
        public string GetValue="";

		public frmRadio(string command)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			ImpostaValori(command);
		}

		private void ImpostaValori(string cmd) {
			if (cmd=="") return;
			string[] token = cmd.Split('|');
			for (int i=0, j=1; i<token.Length; i+=2, j++) {
				foreach (Control ctrl in this.Controls) {
					if (ctrl.GetType()!=typeof(TextBox)) continue;
					if (ctrl.Name.EndsWith("Val"+j.ToString()) || ctrl.Name.EndsWith("Desc"+j.ToString()) ) {
						if (ctrl.Name.StartsWith("txtRadioVal"))
							ctrl.Text=token[i];
						else
							ctrl.Text=token[i+1];
					}
				}
			}
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
            this.txtRadioDesc2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtRadioVal2 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRadioDesc3 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRadioVal3 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRadioDesc4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRadioVal4 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRadioDesc5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRadioVal5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRadioDesc1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRadioVal1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtRadioDesc7 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRadioVal7 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRadioDesc8 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRadioVal8 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRadioDesc9 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRadioVal9 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtRadioDesc10 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtRadioVal10 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtRadioDesc6 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtRadioVal6 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtRadioDesc12 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtRadioVal12 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtRadioDesc13 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtRadioVal13 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.txtRadioDesc14 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtRadioVal14 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.txtRadioDesc15 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txtRadioVal15 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.txtRadioDesc11 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.txtRadioVal11 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRadioDesc2
            // 
            this.txtRadioDesc2.Location = new System.Drawing.Point(208, 48);
            this.txtRadioDesc2.Name = "txtRadioDesc2";
            this.txtRadioDesc2.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc2.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(152, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 38;
            this.label12.Text = "Descr. 2";
            // 
            // txtRadioVal2
            // 
            this.txtRadioVal2.Location = new System.Drawing.Point(77, 48);
            this.txtRadioVal2.Name = "txtRadioVal2";
            this.txtRadioVal2.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal2.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 16);
            this.label13.TabIndex = 36;
            this.label13.Text = "Valore 2";
            // 
            // txtRadioDesc3
            // 
            this.txtRadioDesc3.Location = new System.Drawing.Point(208, 72);
            this.txtRadioDesc3.Name = "txtRadioDesc3";
            this.txtRadioDesc3.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc3.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(152, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 34;
            this.label10.Text = "Descr. 3";
            // 
            // txtRadioVal3
            // 
            this.txtRadioVal3.Location = new System.Drawing.Point(77, 72);
            this.txtRadioVal3.Name = "txtRadioVal3";
            this.txtRadioVal3.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal3.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 16);
            this.label11.TabIndex = 32;
            this.label11.Text = "Valore 3";
            // 
            // txtRadioDesc4
            // 
            this.txtRadioDesc4.Location = new System.Drawing.Point(208, 96);
            this.txtRadioDesc4.Name = "txtRadioDesc4";
            this.txtRadioDesc4.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc4.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(152, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "Descr. 4";
            // 
            // txtRadioVal4
            // 
            this.txtRadioVal4.Location = new System.Drawing.Point(77, 96);
            this.txtRadioVal4.Name = "txtRadioVal4";
            this.txtRadioVal4.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal4.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 28;
            this.label9.Text = "Valore 4";
            // 
            // txtRadioDesc5
            // 
            this.txtRadioDesc5.Location = new System.Drawing.Point(208, 120);
            this.txtRadioDesc5.Name = "txtRadioDesc5";
            this.txtRadioDesc5.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(152, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Descr. 5";
            // 
            // txtRadioVal5
            // 
            this.txtRadioVal5.Location = new System.Drawing.Point(77, 120);
            this.txtRadioVal5.Name = "txtRadioVal5";
            this.txtRadioVal5.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal5.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Valore 5";
            // 
            // txtRadioDesc1
            // 
            this.txtRadioDesc1.Location = new System.Drawing.Point(208, 24);
            this.txtRadioDesc1.Name = "txtRadioDesc1";
            this.txtRadioDesc1.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(152, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 22;
            this.label5.Text = "Descr. 1";
            // 
            // txtRadioVal1
            // 
            this.txtRadioVal1.Location = new System.Drawing.Point(77, 24);
            this.txtRadioVal1.Name = "txtRadioVal1";
            this.txtRadioVal1.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Valore 1";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(280, 403);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(184, 403);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtRadioDesc7
            // 
            this.txtRadioDesc7.Location = new System.Drawing.Point(208, 170);
            this.txtRadioDesc7.Name = "txtRadioDesc7";
            this.txtRadioDesc7.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc7.TabIndex = 42;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(152, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 58;
            this.label2.Text = "Descr. 7";
            // 
            // txtRadioVal7
            // 
            this.txtRadioVal7.Location = new System.Drawing.Point(77, 170);
            this.txtRadioVal7.Name = "txtRadioVal7";
            this.txtRadioVal7.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal7.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 57;
            this.label3.Text = "Valore 7";
            // 
            // txtRadioDesc8
            // 
            this.txtRadioDesc8.Location = new System.Drawing.Point(208, 194);
            this.txtRadioDesc8.Name = "txtRadioDesc8";
            this.txtRadioDesc8.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc8.TabIndex = 44;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(152, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 56;
            this.label4.Text = "Descr. 8";
            // 
            // txtRadioVal8
            // 
            this.txtRadioVal8.Location = new System.Drawing.Point(77, 194);
            this.txtRadioVal8.Name = "txtRadioVal8";
            this.txtRadioVal8.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal8.TabIndex = 43;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(16, 194);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 16);
            this.label14.TabIndex = 55;
            this.label14.Text = "Valore 8";
            // 
            // txtRadioDesc9
            // 
            this.txtRadioDesc9.Location = new System.Drawing.Point(208, 218);
            this.txtRadioDesc9.Name = "txtRadioDesc9";
            this.txtRadioDesc9.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc9.TabIndex = 46;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(152, 218);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 16);
            this.label15.TabIndex = 54;
            this.label15.Text = "Descr. 9";
            // 
            // txtRadioVal9
            // 
            this.txtRadioVal9.Location = new System.Drawing.Point(77, 218);
            this.txtRadioVal9.Name = "txtRadioVal9";
            this.txtRadioVal9.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal9.TabIndex = 45;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(16, 218);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(48, 16);
            this.label16.TabIndex = 53;
            this.label16.Text = "Valore 9";
            // 
            // txtRadioDesc10
            // 
            this.txtRadioDesc10.Location = new System.Drawing.Point(208, 242);
            this.txtRadioDesc10.Name = "txtRadioDesc10";
            this.txtRadioDesc10.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc10.TabIndex = 48;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(152, 242);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 52;
            this.label17.Text = "Descr. 10";
            // 
            // txtRadioVal10
            // 
            this.txtRadioVal10.Location = new System.Drawing.Point(77, 242);
            this.txtRadioVal10.Name = "txtRadioVal10";
            this.txtRadioVal10.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal10.TabIndex = 47;
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(16, 242);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 16);
            this.label18.TabIndex = 51;
            this.label18.Text = "Valore 10";
            // 
            // txtRadioDesc6
            // 
            this.txtRadioDesc6.Location = new System.Drawing.Point(208, 146);
            this.txtRadioDesc6.Name = "txtRadioDesc6";
            this.txtRadioDesc6.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc6.TabIndex = 40;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(152, 146);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 16);
            this.label19.TabIndex = 50;
            this.label19.Text = "Descr. 6";
            // 
            // txtRadioVal6
            // 
            this.txtRadioVal6.Location = new System.Drawing.Point(77, 146);
            this.txtRadioVal6.Name = "txtRadioVal6";
            this.txtRadioVal6.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal6.TabIndex = 39;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(16, 146);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 16);
            this.label20.TabIndex = 49;
            this.label20.Text = "Valore 6";
            // 
            // txtRadioDesc12
            // 
            this.txtRadioDesc12.Location = new System.Drawing.Point(208, 292);
            this.txtRadioDesc12.Name = "txtRadioDesc12";
            this.txtRadioDesc12.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc12.TabIndex = 62;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(152, 292);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 16);
            this.label21.TabIndex = 78;
            this.label21.Text = "Descr. 12";
            // 
            // txtRadioVal12
            // 
            this.txtRadioVal12.Location = new System.Drawing.Point(77, 292);
            this.txtRadioVal12.Name = "txtRadioVal12";
            this.txtRadioVal12.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal12.TabIndex = 61;
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(16, 292);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(53, 16);
            this.label22.TabIndex = 77;
            this.label22.Text = "Valore 12";
            // 
            // txtRadioDesc13
            // 
            this.txtRadioDesc13.Location = new System.Drawing.Point(208, 316);
            this.txtRadioDesc13.Name = "txtRadioDesc13";
            this.txtRadioDesc13.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc13.TabIndex = 64;
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(152, 316);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 16);
            this.label23.TabIndex = 76;
            this.label23.Text = "Descr. 13";
            // 
            // txtRadioVal13
            // 
            this.txtRadioVal13.Location = new System.Drawing.Point(77, 316);
            this.txtRadioVal13.Name = "txtRadioVal13";
            this.txtRadioVal13.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal13.TabIndex = 63;
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(16, 316);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 16);
            this.label24.TabIndex = 75;
            this.label24.Text = "Valore 13";
            // 
            // txtRadioDesc14
            // 
            this.txtRadioDesc14.Location = new System.Drawing.Point(208, 340);
            this.txtRadioDesc14.Name = "txtRadioDesc14";
            this.txtRadioDesc14.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc14.TabIndex = 66;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(152, 340);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 74;
            this.label25.Text = "Descr. 14";
            // 
            // txtRadioVal14
            // 
            this.txtRadioVal14.Location = new System.Drawing.Point(77, 340);
            this.txtRadioVal14.Name = "txtRadioVal14";
            this.txtRadioVal14.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal14.TabIndex = 65;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(16, 340);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 16);
            this.label26.TabIndex = 73;
            this.label26.Text = "Valore 14";
            // 
            // txtRadioDesc15
            // 
            this.txtRadioDesc15.Location = new System.Drawing.Point(208, 364);
            this.txtRadioDesc15.Name = "txtRadioDesc15";
            this.txtRadioDesc15.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc15.TabIndex = 68;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(152, 364);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 16);
            this.label27.TabIndex = 72;
            this.label27.Text = "Descr. 15";
            // 
            // txtRadioVal15
            // 
            this.txtRadioVal15.Location = new System.Drawing.Point(77, 364);
            this.txtRadioVal15.Name = "txtRadioVal15";
            this.txtRadioVal15.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal15.TabIndex = 67;
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(16, 364);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(53, 16);
            this.label28.TabIndex = 71;
            this.label28.Text = "Valore 15";
            // 
            // txtRadioDesc11
            // 
            this.txtRadioDesc11.Location = new System.Drawing.Point(208, 268);
            this.txtRadioDesc11.Name = "txtRadioDesc11";
            this.txtRadioDesc11.Size = new System.Drawing.Size(336, 20);
            this.txtRadioDesc11.TabIndex = 60;
            // 
            // label29
            // 
            this.label29.Location = new System.Drawing.Point(152, 268);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 16);
            this.label29.TabIndex = 70;
            this.label29.Text = "Descr. 11";
            // 
            // txtRadioVal11
            // 
            this.txtRadioVal11.Location = new System.Drawing.Point(77, 268);
            this.txtRadioVal11.Name = "txtRadioVal11";
            this.txtRadioVal11.Size = new System.Drawing.Size(72, 20);
            this.txtRadioVal11.TabIndex = 59;
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(16, 268);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 16);
            this.label30.TabIndex = 69;
            this.label30.Text = "Valore 11";
            // 
            // frmRadio
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(560, 438);
            this.Controls.Add(this.txtRadioDesc12);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtRadioVal12);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.txtRadioDesc13);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txtRadioVal13);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtRadioDesc14);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.txtRadioVal14);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.txtRadioDesc15);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txtRadioVal15);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.txtRadioDesc11);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.txtRadioVal11);
            this.Controls.Add(this.label30);
            this.Controls.Add(this.txtRadioDesc7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRadioVal7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRadioDesc8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRadioVal8);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtRadioDesc9);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtRadioVal9);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txtRadioDesc10);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txtRadioVal10);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtRadioDesc6);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtRadioVal6);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtRadioDesc2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtRadioVal2);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtRadioDesc3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtRadioVal3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRadioDesc4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtRadioVal4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRadioDesc5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRadioVal5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRadioDesc1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRadioVal1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmRadio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Impostazione valori per Radio Button";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void ShowMsg(string msg) {
			show(msg, "Attenzione",
				MessageBoxButtons.OK,MessageBoxIcon.Information);
		}

		private void btnOK_Click(object sender, System.EventArgs e) {
			GetValue="";
			int righe=0;
			if ((txtRadioVal1.Text!="") ^ (txtRadioDesc1.Text!="")) {
				ShowMsg("La riga 1 è incompleta.");
				return;
			}
			if ((txtRadioVal1.Text!="") && (txtRadioDesc1.Text!="")) {
				AggiungiCondizione(1);
				++righe;
			}

			if ((txtRadioVal2.Text!="") ^ (txtRadioDesc2.Text!="")) {
				ShowMsg("La riga 2 è incompleta.");
				return;
			}
			if ((txtRadioVal2.Text!="") && (txtRadioDesc2.Text!="")) {
				AggiungiCondizione(2);
				++righe;
			}

			if ((txtRadioVal3.Text!="") ^ (txtRadioDesc3.Text!="")) {
				ShowMsg("La riga 3 è incompleta.");
				return;
			}
			if ((txtRadioVal3.Text!="") && (txtRadioDesc3.Text!="")) {
				AggiungiCondizione(3);
				++righe;
			}

			if ((txtRadioVal4.Text!="") ^ (txtRadioDesc4.Text!="")) {
				ShowMsg("La riga 4 è incompleta.");
				return;
			}
			if ((txtRadioVal4.Text!="") && (txtRadioDesc4.Text!="")) {
				AggiungiCondizione(4);
				++righe;
			}

			if ((txtRadioVal5.Text!="") ^ (txtRadioDesc5.Text!="")) {
				ShowMsg("La riga 5 è incompleta.");
				return;
			}
			if ((txtRadioVal5.Text!="") && (txtRadioDesc5.Text!="")) {
				AggiungiCondizione(5);
				++righe;
			}


            if ((txtRadioVal6.Text != "") ^ (txtRadioDesc6.Text != ""))
            {
                ShowMsg("La riga 6 è incompleta.");
                return;
            }
            if ((txtRadioVal6.Text != "") && (txtRadioDesc6.Text != ""))
            {
                AggiungiCondizione(6);
                ++righe;
            }


            if ((txtRadioVal7.Text != "") ^ (txtRadioDesc7.Text != ""))
            {
                ShowMsg("La riga 7 è incompleta.");
                return;
            }
            if ((txtRadioVal7.Text != "") && (txtRadioDesc7.Text != ""))
            {
                AggiungiCondizione(7);
                ++righe;
            }

            if ((txtRadioVal8.Text != "") ^ (txtRadioDesc8.Text != ""))
            {
                ShowMsg("La riga 8 è incompleta.");
                return;
            }
            if ((txtRadioVal8.Text != "") && (txtRadioDesc8.Text != ""))
            {
                AggiungiCondizione(8);
                ++righe;
            }

            if ((txtRadioVal9.Text != "") ^ (txtRadioDesc9.Text != ""))
            {
                ShowMsg("La riga 9 è incompleta.");
                return;
            }
            if ((txtRadioVal9.Text != "") && (txtRadioDesc9.Text != ""))
            {
                AggiungiCondizione(9);
                ++righe;
            }

            if ((txtRadioVal10.Text != "") ^ (txtRadioDesc10.Text != ""))
            {
                ShowMsg("La riga 10 è incompleta.");
                return;
            }
            if ((txtRadioVal10.Text != "") && (txtRadioDesc10.Text != ""))
            {
                AggiungiCondizione(10);
                ++righe;
            }
            if ((txtRadioVal11.Text != "") ^ (txtRadioDesc11.Text != "")) {
                ShowMsg("La riga 11 è incompleta.");
                return;
            }
            if ((txtRadioVal11.Text != "") && (txtRadioDesc11.Text != "")) {
                AggiungiCondizione(11);
                ++righe;
            }
            if ((txtRadioVal12.Text != "") ^ (txtRadioDesc12.Text != "")) {
                ShowMsg("La riga 12 è incompleta.");
                return;
            }
            if ((txtRadioVal12.Text != "") && (txtRadioDesc12.Text != "")) {
                AggiungiCondizione(12);
                ++righe;
            }
            if ((txtRadioVal13.Text != "") ^ (txtRadioDesc13.Text != "")) {
                ShowMsg("La riga 13 è incompleta.");
                return;
            }
            if ((txtRadioVal13.Text != "") && (txtRadioDesc13.Text != "")) {
                AggiungiCondizione(13);
                ++righe;
            }
            if ((txtRadioVal14.Text != "") ^ (txtRadioDesc14.Text != "")) {
                ShowMsg("La riga 14 è incompleta.");
                return;
            }
            if ((txtRadioVal14.Text != "") && (txtRadioDesc14.Text != "")) {
                AggiungiCondizione(14);
                ++righe;
            }
            if ((txtRadioVal15.Text != "") ^ (txtRadioDesc15.Text != "")) {
                ShowMsg("La riga 15 è incompleta.");
                return;
            }
            if ((txtRadioVal15.Text != "") && (txtRadioDesc15.Text != "")) {
                AggiungiCondizione(15);
                ++righe;
            }
            //almeno due righe sono necessarie
            if (righe<2) {
				ShowMsg("Per il tipo radio button sono necessarie almeno due condizioni");
				return;
			}
			this.DialogResult=DialogResult.OK;
		}

		private void AggiungiCondizione(int riga) {
			string valore="";
			string descrizione="";
			foreach (Control ctrl in this.Controls) {
				if (ctrl.GetType()!=typeof(TextBox)) continue;
				if (!ctrl.Name.EndsWith(riga.ToString())) continue;
				if (ctrl.Name=="txtRadioVal"+riga.ToString())
					valore=ctrl.Text;
				if (ctrl.Name=="txtRadioDesc"+riga.ToString())
					descrizione=ctrl.Text;
			}
			if (riga>1) GetValue+="|";
			GetValue+=valore+"|"+descrizione;
		}
	}
}
