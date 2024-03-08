
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

namespace unifiedtaxcorrige_default
{
    public partial class Frm_unifiedtaxcorrige_default : MetaDataForm {
        private TextBox textBox4;
        private TextBox txtEserc;
        private Label label16;
        private TextBox txtNum;
        private Label label17;
        private Button btnScollega;
        private Label label5;
        private TextBox textBox6;
        private GroupBox groupBox8;
        private ComboBox cmbBoxDepartment;
        private TextBox textBox18;
        private GroupBox groupBox6;
        private Label label3;
        private Label label11;
        private Label label10;
        private GroupBox groupBox1;
        private Label label2;
        private Label label1;
        private TextBox textBox3;
        private TextBox txtEsercMov;
        private GroupBox groupBox5;
        private TextBox txtCreDeb;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private TextBox textBox19;
        public vistaForm DS;
        private GroupBox gboxService;
        private Label label4;
        private TextBox txtstop;
        private Label label15;
        private TextBox txtstart;
        MetaData Meta;
    
        public Frm_unifiedtaxcorrige_default()
        {
            InitializeComponent();
        }
        private void InitializeComponent(){
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnScollega = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cmbBoxDepartment = new System.Windows.Forms.ComboBox();
            this.DS = new unifiedtaxcorrige_default.vistaForm();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtEsercMov = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtCreDeb = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.gboxService = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtstop = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtstart = new System.Windows.Forms.TextBox();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gboxService.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(72, 72);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(104, 20);
            this.textBox4.TabIndex = 3;
            this.textBox4.Tag = "unifiedtaxcorrige.npay?unifiedtaxcorrigeview.npay";
            // 
            // txtEserc
            // 
            this.txtEserc.Location = new System.Drawing.Point(92, 18);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(104, 20);
            this.txtEserc.TabIndex = 4;
            this.txtEserc.Tag = "unifiedf24ep.ayear.year?unifiedtaxcorrigeview.f24ep_ayear.year";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(21, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 3;
            this.label16.Text = "Esercizio";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(92, 44);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(104, 20);
            this.txtNum.TabIndex = 5;
            this.txtNum.Tag = "unifiedtaxcorrige.idunifiedf24ep?unifiedtaxcorrigeview.idunifiedf24ep";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(21, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 1;
            this.label17.Text = "Numero";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnScollega
            // 
            this.btnScollega.Location = new System.Drawing.Point(301, 391);
            this.btnScollega.Name = "btnScollega";
            this.btnScollega.Size = new System.Drawing.Size(172, 26);
            this.btnScollega.TabIndex = 0;
            this.btnScollega.Text = "Scollega dettaglio dall\'F24EP";
            this.btnScollega.UseVisualStyleBackColor = true;
            this.btnScollega.Click += new System.EventHandler(this.btnScollega_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(244, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Data Competenza:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(350, 267);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(128, 20);
            this.textBox6.TabIndex = 9;
            this.textBox6.Tag = "unifiedtaxcorrige.adate";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cmbBoxDepartment);
            this.groupBox8.Location = new System.Drawing.Point(8, 59);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(472, 48);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Dipartimento";
            // 
            // cmbBoxDepartment
            // 
            this.cmbBoxDepartment.DataSource = this.DS.dbdepartment;
            this.cmbBoxDepartment.DisplayMember = "description";
            this.cmbBoxDepartment.Dock = System.Windows.Forms.DockStyle.Right;
            this.cmbBoxDepartment.Location = new System.Drawing.Point(85, 16);
            this.cmbBoxDepartment.Name = "cmbBoxDepartment";
            this.cmbBoxDepartment.Size = new System.Drawing.Size(384, 21);
            this.cmbBoxDepartment.TabIndex = 1;
            this.cmbBoxDepartment.Tag = "unifiedtaxcorrige.iddbdepartment?unifiedtaxcorrigeview.iddbdepartment";
            this.cmbBoxDepartment.ValueMember = "iddbdepartment";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(113, 292);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(112, 20);
            this.textBox18.TabIndex = 11;
            this.textBox18.Tag = "unifiedtaxcorrige.employamount?unifiedtaxcorrigeview.employamount";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtEserc);
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.txtNum);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Location = new System.Drawing.Point(209, 108);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(216, 80);
            this.groupBox6.TabIndex = 4;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "F24 EP";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mandato:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(12, 266);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 24);
            this.label11.TabIndex = 6;
            this.label11.Text = "Importo c/ammin";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(12, 290);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 24);
            this.label10.TabIndex = 10;
            this.label10.Text = "Importo c/dip";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.txtEsercMov);
            this.groupBox1.Location = new System.Drawing.Point(9, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(192, 97);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Movimento";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Esercizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(72, 48);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(104, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "unifiedtaxcorrige.nmov?unifiedtaxcorrigeview.nmov";
            // 
            // txtEsercMov
            // 
            this.txtEsercMov.Location = new System.Drawing.Point(72, 20);
            this.txtEsercMov.Name = "txtEsercMov";
            this.txtEsercMov.Size = new System.Drawing.Size(104, 20);
            this.txtEsercMov.TabIndex = 1;
            this.txtEsercMov.Tag = "unifiedtaxcorrige.ymov.year";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtCreDeb);
            this.groupBox5.Location = new System.Drawing.Point(9, 206);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(472, 48);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "AutoChoose.txtCreDeb.default";
            this.groupBox5.Text = "Percipiente";
            // 
            // txtCreDeb
            // 
            this.txtCreDeb.Location = new System.Drawing.Point(8, 21);
            this.txtCreDeb.Name = "txtCreDeb";
            this.txtCreDeb.Size = new System.Drawing.Size(456, 20);
            this.txtCreDeb.TabIndex = 6;
            this.txtCreDeb.Tag = "registry.title?unifiedtaxcorrigeview.registry";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Location = new System.Drawing.Point(9, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(472, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ritenuta";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.DS.tax;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox1.Location = new System.Drawing.Point(85, 16);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(384, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Tag = "unifiedtaxcorrige.taxcode?unifiedtaxcorrigeview.taxcode";
            this.comboBox1.ValueMember = "taxcode";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(113, 266);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(112, 20);
            this.textBox19.TabIndex = 7;
            this.textBox19.Tag = "unifiedtaxcorrige.adminamount?unifiedtaxcorrigeview.adminamount";
            // 
            // gboxService
            // 
            this.gboxService.Controls.Add(this.label4);
            this.gboxService.Controls.Add(this.txtstop);
            this.gboxService.Controls.Add(this.label15);
            this.gboxService.Controls.Add(this.txtstart);
            this.gboxService.Location = new System.Drawing.Point(8, 317);
            this.gboxService.Name = "gboxService";
            this.gboxService.Size = new System.Drawing.Size(310, 53);
            this.gboxService.TabIndex = 12;
            this.gboxService.TabStop = false;
            this.gboxService.Text = "Prestazione";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(196, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 22;
            this.label4.Text = "Data Fine";
            // 
            // txtstop
            // 
            this.txtstop.Location = new System.Drawing.Point(196, 29);
            this.txtstop.Name = "txtstop";
            this.txtstop.Size = new System.Drawing.Size(100, 20);
            this.txtstop.TabIndex = 12;
            this.txtstop.Tag = "unifiedtaxcorrige.servicestop";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(69, 14);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 16);
            this.label15.TabIndex = 20;
            this.label15.Text = "Data Inizio";
            // 
            // txtstart
            // 
            this.txtstart.Location = new System.Drawing.Point(69, 30);
            this.txtstart.Name = "txtstart";
            this.txtstart.Size = new System.Drawing.Size(100, 20);
            this.txtstart.TabIndex = 11;
            this.txtstart.Tag = "unifiedtaxcorrige.servicestart";
            // 
            // Frm_unifiedtaxcorrige_default
            // 
            this.ClientSize = new System.Drawing.Size(488, 429);
            this.Controls.Add(this.gboxService);
            this.Controls.Add(this.btnScollega);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.textBox18);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox19);
            this.Name = "Frm_unifiedtaxcorrige_default";
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gboxService.ResumeLayout(false);
            this.gboxService.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Meta.CanInsertCopy = false;
            string filter = "(ymov = '" + Meta.GetSys("esercizio") + "')";
            GetData.SetStaticFilter(DS.unifiedtaxcorrige, filter);
        }

        public void MetaData_AfterClear(){
            txtEsercMov.Text = Meta.GetSys("esercizio").ToString();
            VisualizzabtnScollega();
        }

        public void MetaData_AfterFill()
        {
            Text = "Correzioni Ritenute centralizzate";
            if (Meta.FirstFillForThisRow && Meta.EditMode)
            {
                VisualizzabtnScollega();
            }
        }

        void VisualizzabtnScollega() {
            if (DS.unifiedtaxcorrige.Rows.Count > 0 
                && (DS.unifiedtaxcorrige.Rows[0].RowState == DataRowState.Unchanged))
            {
                DataRow Curr = DS.unifiedtaxcorrige.Rows[0];
                if (Curr["idunifiedf24ep"] == DBNull.Value)
                {
                    btnScollega.Enabled = false;
                }
                else
                {
                    btnScollega.Enabled = true;
                }
            }
            else
            {
                if (Meta.InsertMode || DS.unifiedtaxcorrige.Rows.Count == 0)
                {
                    btnScollega.Enabled = false;
                    return;
                }
            }
        }

        private void btnScollega_Click(object sender, System.EventArgs e){
            if (show(this, "Si è deciso di scollegare il dettaglio della ritenuta dall'E24EP'.\r" +
                "Procedo a rimuovere il dettaglio?", "Avviso", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            DataRow Curr = DS.unifiedtaxcorrige.Rows[0];
            Curr["idunifiedf24ep"] = DBNull.Value;
            txtNum.Text = "";
            txtEserc.Text = "";
        }

    }
}
