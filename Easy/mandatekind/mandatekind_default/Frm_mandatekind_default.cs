
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;




namespace mandatekind_default
{
	/// <summary>
	/// Summary description for Frm_mandatekind_default.
	/// </summary>
	public class Frm_mandatekind_default : MetaDataForm
	{
		public mandatekind_default.vistaForm DS;
        private System.Windows.Forms.ImageList images;
        private TabControl tabMandateKind;
        private TabPage tabPageInfo;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private RadioButton radioButton7;
        private RadioButton radioButton8;
        private RadioButton radioButton9;
        private RadioButton radioButton10;
        private GroupBox groupBox5;
        private RadioButton radioButton11;
        private RadioButton radioButton12;
        private Label label7;
        private Label label8;
        private TextBox textBox17;
        private TextBox textBox18;
        private TextBox textBox23;
        private TextBox textBox24;
        private Label label18;
        private Label label19;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private TabPage tabPageStampa;
        public GroupBox MetaDataDetail1;
        private TabControl tabControl2;
        private TabPage tabPage1;
        private TextBox textBox13;
        private TabPage tabPage2;
        private TextBox textBox12;
        private TabPage tabPage3;
        private TextBox textBox11;
        private Label label11;
        private TextBox textBox14;
        private Label label14;
        private TextBox textBox8;
        private Label label15;
        private Label label13;
        private TextBox textBox15;
        private TextBox textBox16;
        private Label label10;
        private Label label9;
        private TextBox textBox10;
        private TextBox textBox9;
        private TabPage tabPageWeb;
        private TextBox textBox1;
        private Label label1;
        private CheckBox checkBox1;
        private TabPage tabAttributi;
        private TextBox textBox25;
        private Label label20;
        private TextBox textBox20;
        private TextBox textBox21;
        private TextBox textBox22;
        private Label label12;
        private Label label16;
        private Label label17;
        private GroupBox grpTipoBene;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private CheckBox checkBox9;
        private CheckBox checkBox10;
        private TextBox textBox2;
        private Label label2;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TextBox textBox3;
        private TextBox textBox4;
        public GroupBox gboxclass05;
        public TextBox txtCodice05;
        public Button btnCodice05;
        private TextBox txtDenom05;
        public GroupBox gboxclass04;
        public TextBox txtCodice04;
        public Button btnCodice04;
        private TextBox txtDenom04;
        public GroupBox gboxclass03;
        public TextBox txtCodice03;
        public Button btnCodice03;
        private TextBox txtDenom03;
        public GroupBox gboxclass02;
        public TextBox txtCodice02;
        public Button btnCodice02;
        private TextBox txtDenom02;
        public GroupBox gboxclass01;
        public TextBox txtCodice01;
        public Button btnCodice01;
        private TextBox txtDenom01;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        private GroupBox groupBox1;
        private CheckBox checkBox12;
        private CheckBox chkAvcpNascosti;
        private CheckBox checkBox13;
        private RichTextBox richTextBox1;
        private ComboBox cmbipa;
        private Label label47;
        private TextBox txtRiferimentoAmministrazione;
        private CheckBox checkBox14;
        private TabPage tabIVA;
        private GroupBox gBoxIvaKind;
        private Button btnTipo;
        private ComboBox cmbTipoIVA;
        private TextBox txtIva;
        private Label label3;
        private Label lblPercIndeduc;
        private TextBox txtPercIndeduc;
        private TabPage tabClassificazioni;
        private DataGrid dgrClassificazioni;
        private Button btnIndElimina;
        private Button btnIndModifica;
        private Button btnIndInserisci;
        private TabPage tabANAC;
        private GroupBox groupCredDeb;
        private TextBox txtCredDeb;
        private GroupBox grpCertificatiNecessari;
        private CheckBox chkVisura;
        private CheckBox chkCCdedicato;
        private CheckBox chkDurc;
        private MetaData Meta;
        private TabPage tabPage6;
        private DataGrid dataGrid1;
        private Button button1;
        private Button button2;
        private Button button3;
		private CheckBox chkVerificaAnac;
		private CheckBox chkRegolaritaFiscale;
		private CheckBox chkOttempLegge;
		private CheckBox chkCasellarioAmm;
		private CheckBox chkCasellarioGiud;
		private System.ComponentModel.IContainer components;

		public Frm_mandatekind_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            GetData.CacheTable(DS.attachmentkind);
            HelpForm.SetDenyNull(DS.mandatekind.Columns["linktoasset"], true);
			HelpForm.SetDenyNull(DS.mandatekind.Columns["linktoinvoice"], true);
			HelpForm.SetDenyNull(DS.mandatekind.Columns["multireg"], true);
            HelpForm.SetDenyNull(DS.mandatekind.Columns["flagactivity"], true);
            HelpForm.SetDenyNull(DS.mandatekind.Columns["flag_autodocnumbering"], true);
            HelpForm.SetDenyNull(DS.mandatekind.Columns["isrequest"], true);
            HelpForm.SetDenyNull(DS.mandatekind.Columns["assetkind"], true);
            HelpForm.SetDenyNull(DS.mandatekind.Columns["touniqueregister"], true);
            HelpForm.SetDenyNull(DS.mandatekind.Columns["flagcreatedoubleentry"], true);
		}
        DataAccess Conn = null;
        QueryHelper QHS = null;
        
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            Conn = MetaData.GetConnection(this);
            QHS = Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");
            GetData.SetStaticFilter(DS.attachmentkind, QHS.CmpEq("active", "S"));
            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
              null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this, 1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
                    tabMandateKind.TabPages.Remove(tabAttributi);
                }
            }
        }

        public void MetaData_AfterClear() {
            chkCCdedicato.Enabled = true;
            chkVisura.Enabled = true;
            chkDurc.Enabled = true;
			chkVerificaAnac.Enabled = true;
			chkRegolaritaFiscale.Enabled = true;
			chkOttempLegge.Enabled = true;
			chkCasellarioAmm.Enabled = true;
			chkCasellarioGiud.Enabled = true;
        }
        public void MetaData_AfterFill() {
            if (DS.mandatekind.Rows.Count > 0) {
                DataRow R = DS.mandatekind.Rows[0];
                int flag = CfgFn.GetNoNullInt32(R["flag"]) & 1;
                if (flag == 0) {
                    //CIG previsto
                    chkCCdedicato.Enabled = true;
                    chkVisura.Enabled = true;
                    chkDurc.Enabled = true;
					chkVerificaAnac.Enabled = true;
					chkRegolaritaFiscale.Enabled = true;
					chkOttempLegge.Enabled = true;
					chkCasellarioAmm.Enabled = true;
					chkCasellarioGiud.Enabled = true;
                }
                else {
                    //CIG non  previsto, quindi certificati non necessari
                    chkCCdedicato.Enabled = false;
                    chkVisura.Enabled = false;
                    chkDurc.Enabled = false;
					chkVerificaAnac.Enabled = false;
					chkRegolaritaFiscale.Enabled = false;
					chkOttempLegge.Enabled = false;
					chkCasellarioAmm.Enabled = false;
					chkCasellarioGiud.Enabled = false;
                }
            }
        }

        public void MetaData_AfterGetFormData() {
            AlignMandatekindAttachmentkind();
        }

        void AlignMandatekindAttachmentkind() {
            if (!Meta.InsertMode) return;
            DataRow Curr = HelpForm.GetLastSelected(DS.mandatekind);
            if (Curr == null) return;
            foreach (DataRow R in DS.mandatekindattachmentkind.Rows) R["idmankind"] = Curr["idmankind"];
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_mandatekind_default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.tabMandateKind = new System.Windows.Forms.TabControl();
			this.tabPageInfo = new System.Windows.Forms.TabPage();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.grpCertificatiNecessari = new System.Windows.Forms.GroupBox();
			this.chkVerificaAnac = new System.Windows.Forms.CheckBox();
			this.chkRegolaritaFiscale = new System.Windows.Forms.CheckBox();
			this.chkOttempLegge = new System.Windows.Forms.CheckBox();
			this.chkCasellarioAmm = new System.Windows.Forms.CheckBox();
			this.chkCasellarioGiud = new System.Windows.Forms.CheckBox();
			this.chkDurc = new System.Windows.Forms.CheckBox();
			this.chkVisura = new System.Windows.Forms.CheckBox();
			this.chkCCdedicato = new System.Windows.Forms.CheckBox();
			this.label47 = new System.Windows.Forms.Label();
			this.txtRiferimentoAmministrazione = new System.Windows.Forms.TextBox();
			this.cmbipa = new System.Windows.Forms.ComboBox();
			this.DS = new mandatekind_default.vistaForm();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox14 = new System.Windows.Forms.CheckBox();
			this.checkBox13 = new System.Windows.Forms.CheckBox();
			this.checkBox12 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.chkAvcpNascosti = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.checkBox10 = new System.Windows.Forms.CheckBox();
			this.grpTipoBene = new System.Windows.Forms.GroupBox();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.radioButton9 = new System.Windows.Forms.RadioButton();
			this.radioButton10 = new System.Windows.Forms.RadioButton();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.radioButton11 = new System.Windows.Forms.RadioButton();
			this.radioButton12 = new System.Windows.Forms.RadioButton();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox17 = new System.Windows.Forms.TextBox();
			this.textBox18 = new System.Windows.Forms.TextBox();
			this.textBox23 = new System.Windows.Forms.TextBox();
			this.textBox24 = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.tabPageStampa = new System.Windows.Forms.TabPage();
			this.MetaDataDetail1 = new System.Windows.Forms.GroupBox();
			this.tabControl2 = new System.Windows.Forms.TabControl();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.tabPage5 = new System.Windows.Forms.TabPage();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.textBox13 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.textBox12 = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.textBox11 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.textBox14 = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.textBox8 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.textBox15 = new System.Windows.Forms.TextBox();
			this.textBox16 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox10 = new System.Windows.Forms.TextBox();
			this.textBox9 = new System.Windows.Forms.TextBox();
			this.tabAttributi = new System.Windows.Forms.TabPage();
			this.gboxclass05 = new System.Windows.Forms.GroupBox();
			this.txtCodice05 = new System.Windows.Forms.TextBox();
			this.btnCodice05 = new System.Windows.Forms.Button();
			this.txtDenom05 = new System.Windows.Forms.TextBox();
			this.gboxclass04 = new System.Windows.Forms.GroupBox();
			this.txtCodice04 = new System.Windows.Forms.TextBox();
			this.btnCodice04 = new System.Windows.Forms.Button();
			this.txtDenom04 = new System.Windows.Forms.TextBox();
			this.gboxclass03 = new System.Windows.Forms.GroupBox();
			this.txtCodice03 = new System.Windows.Forms.TextBox();
			this.btnCodice03 = new System.Windows.Forms.Button();
			this.txtDenom03 = new System.Windows.Forms.TextBox();
			this.gboxclass02 = new System.Windows.Forms.GroupBox();
			this.txtCodice02 = new System.Windows.Forms.TextBox();
			this.btnCodice02 = new System.Windows.Forms.Button();
			this.txtDenom02 = new System.Windows.Forms.TextBox();
			this.gboxclass01 = new System.Windows.Forms.GroupBox();
			this.txtCodice01 = new System.Windows.Forms.TextBox();
			this.btnCodice01 = new System.Windows.Forms.Button();
			this.txtDenom01 = new System.Windows.Forms.TextBox();
			this.tabPageWeb = new System.Windows.Forms.TabPage();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox25 = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.textBox20 = new System.Windows.Forms.TextBox();
			this.textBox21 = new System.Windows.Forms.TextBox();
			this.textBox22 = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabIVA = new System.Windows.Forms.TabPage();
			this.gBoxIvaKind = new System.Windows.Forms.GroupBox();
			this.btnTipo = new System.Windows.Forms.Button();
			this.cmbTipoIVA = new System.Windows.Forms.ComboBox();
			this.txtIva = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.lblPercIndeduc = new System.Windows.Forms.Label();
			this.txtPercIndeduc = new System.Windows.Forms.TextBox();
			this.tabANAC = new System.Windows.Forms.TabPage();
			this.groupCredDeb = new System.Windows.Forms.GroupBox();
			this.txtCredDeb = new System.Windows.Forms.TextBox();
			this.tabClassificazioni = new System.Windows.Forms.TabPage();
			this.dgrClassificazioni = new System.Windows.Forms.DataGrid();
			this.btnIndElimina = new System.Windows.Forms.Button();
			this.btnIndModifica = new System.Windows.Forms.Button();
			this.btnIndInserisci = new System.Windows.Forms.Button();
			this.tabPage6 = new System.Windows.Forms.TabPage();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.tabMandateKind.SuspendLayout();
			this.tabPageInfo.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.grpCertificatiNecessari.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.grpTipoBene.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.tabPageStampa.SuspendLayout();
			this.MetaDataDetail1.SuspendLayout();
			this.tabControl2.SuspendLayout();
			this.tabPage4.SuspendLayout();
			this.tabPage5.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabAttributi.SuspendLayout();
			this.gboxclass05.SuspendLayout();
			this.gboxclass04.SuspendLayout();
			this.gboxclass03.SuspendLayout();
			this.gboxclass02.SuspendLayout();
			this.gboxclass01.SuspendLayout();
			this.tabPageWeb.SuspendLayout();
			this.tabIVA.SuspendLayout();
			this.gBoxIvaKind.SuspendLayout();
			this.tabANAC.SuspendLayout();
			this.groupCredDeb.SuspendLayout();
			this.tabClassificazioni.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgrClassificazioni)).BeginInit();
			this.tabPage6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
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
			this.images.Images.SetKeyName(14, "");
			this.images.Images.SetKeyName(15, "");
			this.images.Images.SetKeyName(16, "");
			// 
			// tabMandateKind
			// 
			this.tabMandateKind.Controls.Add(this.tabPageInfo);
			this.tabMandateKind.Controls.Add(this.tabPageStampa);
			this.tabMandateKind.Controls.Add(this.tabAttributi);
			this.tabMandateKind.Controls.Add(this.tabPageWeb);
			this.tabMandateKind.Controls.Add(this.tabIVA);
			this.tabMandateKind.Controls.Add(this.tabANAC);
			this.tabMandateKind.Controls.Add(this.tabClassificazioni);
			this.tabMandateKind.Controls.Add(this.tabPage6);
			this.tabMandateKind.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabMandateKind.Location = new System.Drawing.Point(0, 0);
			this.tabMandateKind.Name = "tabMandateKind";
			this.tabMandateKind.SelectedIndex = 0;
			this.tabMandateKind.Size = new System.Drawing.Size(594, 664);
			this.tabMandateKind.TabIndex = 19;
			// 
			// tabPageInfo
			// 
			this.tabPageInfo.Controls.Add(this.groupBox3);
			this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
			this.tabPageInfo.Name = "tabPageInfo";
			this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageInfo.Size = new System.Drawing.Size(586, 638);
			this.tabPageInfo.TabIndex = 0;
			this.tabPageInfo.Text = "Generale";
			this.tabPageInfo.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox3.Controls.Add(this.grpCertificatiNecessari);
			this.groupBox3.Controls.Add(this.label47);
			this.groupBox3.Controls.Add(this.txtRiferimentoAmministrazione);
			this.groupBox3.Controls.Add(this.cmbipa);
			this.groupBox3.Controls.Add(this.richTextBox1);
			this.groupBox3.Controls.Add(this.groupBox1);
			this.groupBox3.Controls.Add(this.gboxUPB);
			this.groupBox3.Controls.Add(this.checkBox10);
			this.groupBox3.Controls.Add(this.grpTipoBene);
			this.groupBox3.Controls.Add(this.groupBox4);
			this.groupBox3.Controls.Add(this.groupBox5);
			this.groupBox3.Controls.Add(this.label7);
			this.groupBox3.Controls.Add(this.label8);
			this.groupBox3.Controls.Add(this.textBox17);
			this.groupBox3.Controls.Add(this.textBox18);
			this.groupBox3.Controls.Add(this.textBox23);
			this.groupBox3.Controls.Add(this.textBox24);
			this.groupBox3.Controls.Add(this.label18);
			this.groupBox3.Controls.Add(this.label19);
			this.groupBox3.Location = new System.Drawing.Point(6, 6);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(575, 626);
			this.groupBox3.TabIndex = 0;
			this.groupBox3.TabStop = false;
			// 
			// grpCertificatiNecessari
			// 
			this.grpCertificatiNecessari.Controls.Add(this.chkVerificaAnac);
			this.grpCertificatiNecessari.Controls.Add(this.chkRegolaritaFiscale);
			this.grpCertificatiNecessari.Controls.Add(this.chkOttempLegge);
			this.grpCertificatiNecessari.Controls.Add(this.chkCasellarioAmm);
			this.grpCertificatiNecessari.Controls.Add(this.chkCasellarioGiud);
			this.grpCertificatiNecessari.Controls.Add(this.chkDurc);
			this.grpCertificatiNecessari.Controls.Add(this.chkVisura);
			this.grpCertificatiNecessari.Controls.Add(this.chkCCdedicato);
			this.grpCertificatiNecessari.Location = new System.Drawing.Point(372, 174);
			this.grpCertificatiNecessari.Name = "grpCertificatiNecessari";
			this.grpCertificatiNecessari.Size = new System.Drawing.Size(193, 221);
			this.grpCertificatiNecessari.TabIndex = 95;
			this.grpCertificatiNecessari.TabStop = false;
			this.grpCertificatiNecessari.Text = "Certificati necessari";
			// 
			// chkVerificaAnac
			// 
			this.chkVerificaAnac.AutoSize = true;
			this.chkVerificaAnac.Location = new System.Drawing.Point(10, 187);
			this.chkVerificaAnac.Name = "chkVerificaAnac";
			this.chkVerificaAnac.Size = new System.Drawing.Size(93, 17);
			this.chkVerificaAnac.TabIndex = 99;
			this.chkVerificaAnac.Tag = "mandatekind.requested_doc:7";
			this.chkVerificaAnac.Text = "Verifica ANAC";
			this.chkVerificaAnac.UseVisualStyleBackColor = true;
			// 
			// chkRegolaritaFiscale
			// 
			this.chkRegolaritaFiscale.AutoSize = true;
			this.chkRegolaritaFiscale.Location = new System.Drawing.Point(10, 163);
			this.chkRegolaritaFiscale.Name = "chkRegolaritaFiscale";
			this.chkRegolaritaFiscale.Size = new System.Drawing.Size(110, 17);
			this.chkRegolaritaFiscale.TabIndex = 98;
			this.chkRegolaritaFiscale.Tag = "mandatekind.requested_doc:6";
			this.chkRegolaritaFiscale.Text = "Regolarità Fiscale";
			this.chkRegolaritaFiscale.UseVisualStyleBackColor = true;
			// 
			// chkOttempLegge
			// 
			this.chkOttempLegge.AutoSize = true;
			this.chkOttempLegge.Location = new System.Drawing.Point(10, 137);
			this.chkOttempLegge.Name = "chkOttempLegge";
			this.chkOttempLegge.Size = new System.Drawing.Size(157, 17);
			this.chkOttempLegge.TabIndex = 97;
			this.chkOttempLegge.Tag = "mandatekind.requested_doc:5";
			this.chkOttempLegge.Text = "Ottemperanza Legge 68/99";
			this.chkOttempLegge.UseVisualStyleBackColor = true;
			// 
			// chkCasellarioAmm
			// 
			this.chkCasellarioAmm.AutoSize = true;
			this.chkCasellarioAmm.Location = new System.Drawing.Point(10, 112);
			this.chkCasellarioAmm.Name = "chkCasellarioAmm";
			this.chkCasellarioAmm.Size = new System.Drawing.Size(141, 17);
			this.chkCasellarioAmm.TabIndex = 96;
			this.chkCasellarioAmm.Tag = "mandatekind.requested_doc:4";
			this.chkCasellarioAmm.Text = "Casellario Amministrativo";
			this.chkCasellarioAmm.UseVisualStyleBackColor = true;
			// 
			// chkCasellarioGiud
			// 
			this.chkCasellarioGiud.AutoSize = true;
			this.chkCasellarioGiud.Location = new System.Drawing.Point(10, 87);
			this.chkCasellarioGiud.Name = "chkCasellarioGiud";
			this.chkCasellarioGiud.Size = new System.Drawing.Size(119, 17);
			this.chkCasellarioGiud.TabIndex = 95;
			this.chkCasellarioGiud.Tag = "mandatekind.requested_doc:3";
			this.chkCasellarioGiud.Text = "Casellario Giudiziale";
			this.chkCasellarioGiud.UseVisualStyleBackColor = true;
			// 
			// chkDurc
			// 
			this.chkDurc.AutoSize = true;
			this.chkDurc.Location = new System.Drawing.Point(10, 63);
			this.chkDurc.Name = "chkDurc";
			this.chkDurc.Size = new System.Drawing.Size(57, 17);
			this.chkDurc.TabIndex = 94;
			this.chkDurc.Tag = "mandatekind.requested_doc:2";
			this.chkDurc.Text = "DURC";
			this.chkDurc.UseVisualStyleBackColor = true;
			// 
			// chkVisura
			// 
			this.chkVisura.AutoSize = true;
			this.chkVisura.Location = new System.Drawing.Point(9, 40);
			this.chkVisura.Name = "chkVisura";
			this.chkVisura.Size = new System.Drawing.Size(102, 17);
			this.chkVisura.TabIndex = 93;
			this.chkVisura.Tag = "mandatekind.requested_doc:1";
			this.chkVisura.Text = "Visura Camerale";
			this.chkVisura.UseVisualStyleBackColor = true;
			// 
			// chkCCdedicato
			// 
			this.chkCCdedicato.AutoSize = true;
			this.chkCCdedicato.Location = new System.Drawing.Point(9, 19);
			this.chkCCdedicato.Name = "chkCCdedicato";
			this.chkCCdedicato.Size = new System.Drawing.Size(84, 17);
			this.chkCCdedicato.TabIndex = 91;
			this.chkCCdedicato.Tag = "mandatekind.requested_doc:0";
			this.chkCCdedicato.Text = "CC dedicato";
			// 
			// label47
			// 
			this.label47.Location = new System.Drawing.Point(14, 590);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(150, 18);
			this.label47.TabIndex = 77;
			this.label47.Text = "Riferimento amministrazione";
			this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtRiferimentoAmministrazione
			// 
			this.txtRiferimentoAmministrazione.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRiferimentoAmministrazione.Location = new System.Drawing.Point(169, 590);
			this.txtRiferimentoAmministrazione.Name = "txtRiferimentoAmministrazione";
			this.txtRiferimentoAmministrazione.Size = new System.Drawing.Size(148, 20);
			this.txtRiferimentoAmministrazione.TabIndex = 76;
			this.txtRiferimentoAmministrazione.Tag = "mandatekind.riferimento_amministrazione";
			// 
			// cmbipa
			// 
			this.cmbipa.DataSource = this.DS.ipa;
			this.cmbipa.DisplayMember = "officename";
			this.cmbipa.Location = new System.Drawing.Point(17, 562);
			this.cmbipa.Name = "cmbipa";
			this.cmbipa.Size = new System.Drawing.Size(300, 21);
			this.cmbipa.TabIndex = 75;
			this.cmbipa.Tag = "mandatekind.ipa_fe";
			this.cmbipa.ValueMember = "ipa_fe";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox1.Location = new System.Drawing.Point(17, 543);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(547, 30);
			this.richTextBox1.TabIndex = 74;
			this.richTextBox1.Text = "Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, prelevato dal sito" +
    " www.indicepa.gov.it.";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox14);
			this.groupBox1.Controls.Add(this.checkBox13);
			this.groupBox1.Controls.Add(this.checkBox12);
			this.groupBox1.Controls.Add(this.checkBox4);
			this.groupBox1.Controls.Add(this.chkAvcpNascosti);
			this.groupBox1.Controls.Add(this.checkBox6);
			this.groupBox1.Controls.Add(this.checkBox5);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Location = new System.Drawing.Point(17, 174);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(212, 221);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Opzioni";
			// 
			// checkBox14
			// 
			this.checkBox14.Location = new System.Drawing.Point(6, 192);
			this.checkBox14.Name = "checkBox14";
			this.checkBox14.Size = new System.Drawing.Size(201, 23);
			this.checkBox14.TabIndex = 8;
			this.checkBox14.TabStop = false;
			this.checkBox14.Tag = "mandatekind.flagcreatedoubleentry:S:N";
			this.checkBox14.Text = "Genera Scritture";
			// 
			// checkBox13
			// 
			this.checkBox13.Location = new System.Drawing.Point(6, 166);
			this.checkBox13.Name = "checkBox13";
			this.checkBox13.Size = new System.Drawing.Size(201, 23);
			this.checkBox13.TabIndex = 7;
			this.checkBox13.TabStop = false;
			this.checkBox13.Tag = "mandatekind.touniqueregister:S:N";
			this.checkBox13.Text = "Protocolla nel Registro Unico";
			// 
			// checkBox12
			// 
			this.checkBox12.Location = new System.Drawing.Point(6, 142);
			this.checkBox12.Name = "checkBox12";
			this.checkBox12.Size = new System.Drawing.Size(201, 23);
			this.checkBox12.TabIndex = 6;
			this.checkBox12.TabStop = false;
			this.checkBox12.Tag = "mandatekind.flag:1";
			this.checkBox12.Text = "Informazioni CONSIP nascoste";
			// 
			// checkBox4
			// 
			this.checkBox4.Location = new System.Drawing.Point(6, 19);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(136, 25);
			this.checkBox4.TabIndex = 1;
			this.checkBox4.TabStop = false;
			this.checkBox4.Tag = "mandatekind.linktoinvoice:S:N";
			this.checkBox4.Text = "Collegabile a fattura";
			// 
			// chkAvcpNascosti
			// 
			this.chkAvcpNascosti.Location = new System.Drawing.Point(6, 117);
			this.chkAvcpNascosti.Name = "chkAvcpNascosti";
			this.chkAvcpNascosti.Size = new System.Drawing.Size(168, 23);
			this.chkAvcpNascosti.TabIndex = 5;
			this.chkAvcpNascosti.TabStop = false;
			this.chkAvcpNascosti.Tag = "mandatekind.flag:0";
			this.chkAvcpNascosti.Text = "Campi AVCP nascosti";
			this.chkAvcpNascosti.CheckedChanged += new System.EventHandler(this.chkAvcpNascosti_CheckedChanged);
			// 
			// checkBox6
			// 
			this.checkBox6.Location = new System.Drawing.Point(5, 69);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(168, 23);
			this.checkBox6.TabIndex = 3;
			this.checkBox6.TabStop = false;
			this.checkBox6.Tag = "mandatekind.multireg:S:N";
			this.checkBox6.Text = "Anagrafica nel dettaglio";
			// 
			// checkBox5
			// 
			this.checkBox5.Location = new System.Drawing.Point(6, 45);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(168, 23);
			this.checkBox5.TabIndex = 2;
			this.checkBox5.TabStop = false;
			this.checkBox5.Tag = "mandatekind.linktoasset:S:N";
			this.checkBox5.Text = "Utilizzabile nel carico cespite";
			// 
			// checkBox1
			// 
			this.checkBox1.Location = new System.Drawing.Point(5, 93);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(168, 23);
			this.checkBox1.TabIndex = 4;
			this.checkBox1.TabStop = false;
			this.checkBox1.Tag = "mandatekind.isrequest:S:N";
			this.checkBox1.Text = "Richiesta d\'ordine";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(17, 84);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Size = new System.Drawing.Size(547, 77);
			this.gboxUPB.TabIndex = 4;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(6, 50);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(535, 20);
			this.txtUPB.TabIndex = 6;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(143, 9);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(398, 36);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// btnUPBCode
			// 
			this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPBCode.Location = new System.Drawing.Point(6, 24);
			this.btnUPBCode.Name = "btnUPBCode";
			this.btnUPBCode.Size = new System.Drawing.Size(111, 20);
			this.btnUPBCode.TabIndex = 2;
			this.btnUPBCode.TabStop = false;
			this.btnUPBCode.Tag = "manage.upb.tree";
			this.btnUPBCode.Text = "UPB:";
			this.btnUPBCode.UseVisualStyleBackColor = false;
			// 
			// checkBox10
			// 
			this.checkBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBox10.Location = new System.Drawing.Point(265, 9);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new System.Drawing.Size(128, 26);
			this.checkBox10.TabIndex = 2;
			this.checkBox10.Tag = "mandatekind.active:S:N";
			this.checkBox10.Text = "Attivo";
			// 
			// grpTipoBene
			// 
			this.grpTipoBene.Controls.Add(this.checkBox9);
			this.grpTipoBene.Controls.Add(this.checkBox8);
			this.grpTipoBene.Controls.Add(this.checkBox7);
			this.grpTipoBene.Controls.Add(this.checkBox3);
			this.grpTipoBene.Controls.Add(this.checkBox2);
			this.grpTipoBene.Location = new System.Drawing.Point(234, 174);
			this.grpTipoBene.Name = "grpTipoBene";
			this.grpTipoBene.Size = new System.Drawing.Size(133, 141);
			this.grpTipoBene.TabIndex = 12;
			this.grpTipoBene.TabStop = false;
			this.grpTipoBene.Text = "Natura";
			// 
			// checkBox9
			// 
			this.checkBox9.Location = new System.Drawing.Point(9, 114);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(96, 19);
			this.checkBox9.TabIndex = 15;
			this.checkBox9.TabStop = false;
			this.checkBox9.Tag = "mandatekind.assetkind:4";
			this.checkBox9.Text = "Altro";
			// 
			// checkBox8
			// 
			this.checkBox8.Location = new System.Drawing.Point(9, 40);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(96, 20);
			this.checkBox8.TabIndex = 14;
			this.checkBox8.TabStop = false;
			this.checkBox8.Tag = "mandatekind.assetkind:3";
			this.checkBox8.Text = "Magazzino";
			// 
			// checkBox7
			// 
			this.checkBox7.Location = new System.Drawing.Point(9, 65);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(70, 17);
			this.checkBox7.TabIndex = 13;
			this.checkBox7.TabStop = false;
			this.checkBox7.Tag = "mandatekind.assetkind:2";
			this.checkBox7.Text = "Servizi";
			// 
			// checkBox3
			// 
			this.checkBox3.Location = new System.Drawing.Point(9, 90);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(120, 18);
			this.checkBox3.TabIndex = 12;
			this.checkBox3.TabStop = false;
			this.checkBox3.Tag = "mandatekind.assetkind:1";
			this.checkBox3.Text = "Aumento di valore";
			// 
			// checkBox2
			// 
			this.checkBox2.Location = new System.Drawing.Point(9, 16);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(96, 21);
			this.checkBox2.TabIndex = 11;
			this.checkBox2.TabStop = false;
			this.checkBox2.Tag = "mandatekind.assetkind:0";
			this.checkBox2.Text = "Inventariabile";
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.radioButton7);
			this.groupBox4.Controls.Add(this.radioButton8);
			this.groupBox4.Controls.Add(this.radioButton9);
			this.groupBox4.Controls.Add(this.radioButton10);
			this.groupBox4.Location = new System.Drawing.Point(17, 408);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(212, 118);
			this.groupBox4.TabIndex = 11;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Attività";
			// 
			// radioButton7
			// 
			this.radioButton7.Location = new System.Drawing.Point(9, 87);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(96, 16);
			this.radioButton7.TabIndex = 4;
			this.radioButton7.Tag = "mandatekind.flagactivity:3";
			this.radioButton7.Text = "Promiscua";
			// 
			// radioButton8
			// 
			this.radioButton8.Location = new System.Drawing.Point(9, 66);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(96, 15);
			this.radioButton8.TabIndex = 3;
			this.radioButton8.Tag = "mandatekind.flagactivity:2";
			this.radioButton8.Text = "Commerciale";
			// 
			// radioButton9
			// 
			this.radioButton9.Location = new System.Drawing.Point(9, 18);
			this.radioButton9.Name = "radioButton9";
			this.radioButton9.Size = new System.Drawing.Size(123, 21);
			this.radioButton9.TabIndex = 1;
			this.radioButton9.Tag = "mandatekind.flagactivity:4";
			this.radioButton9.Text = "Qualsiasi/Non specificata";
			// 
			// radioButton10
			// 
			this.radioButton10.Location = new System.Drawing.Point(9, 44);
			this.radioButton10.Name = "radioButton10";
			this.radioButton10.Size = new System.Drawing.Size(96, 17);
			this.radioButton10.TabIndex = 2;
			this.radioButton10.Tag = "mandatekind.flagactivity:1";
			this.radioButton10.Text = "Istituzionale";
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.radioButton11);
			this.groupBox5.Controls.Add(this.radioButton12);
			this.groupBox5.Location = new System.Drawing.Point(234, 408);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(197, 64);
			this.groupBox5.TabIndex = 13;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Numerazione dei contratti passivi";
			// 
			// radioButton11
			// 
			this.radioButton11.Location = new System.Drawing.Point(6, 19);
			this.radioButton11.Name = "radioButton11";
			this.radioButton11.Size = new System.Drawing.Size(96, 16);
			this.radioButton11.TabIndex = 1;
			this.radioButton11.Tag = "mandatekind.flag_autodocnumbering:N";
			this.radioButton11.Text = "Manuale";
			// 
			// radioButton12
			// 
			this.radioButton12.Location = new System.Drawing.Point(6, 41);
			this.radioButton12.Name = "radioButton12";
			this.radioButton12.Size = new System.Drawing.Size(96, 16);
			this.radioButton12.TabIndex = 2;
			this.radioButton12.Tag = "mandatekind.flag_autodocnumbering:S";
			this.radioButton12.Text = "Automatica";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(454, 450);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(76, 16);
			this.label7.TabIndex = 72;
			this.label7.Text = "Importo Scostamento";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(453, 410);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(96, 16);
			this.label8.TabIndex = 71;
			this.label8.Text = "% Scostamento";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox17
			// 
			this.textBox17.Location = new System.Drawing.Point(457, 428);
			this.textBox17.Name = "textBox17";
			this.textBox17.Size = new System.Drawing.Size(81, 20);
			this.textBox17.TabIndex = 9;
			this.textBox17.Tag = "mandatekind.deltapercentage.fixed.4..%.100";
			// 
			// textBox18
			// 
			this.textBox18.Location = new System.Drawing.Point(457, 469);
			this.textBox18.Name = "textBox18";
			this.textBox18.Size = new System.Drawing.Size(97, 20);
			this.textBox18.TabIndex = 10;
			this.textBox18.Tag = "mandatekind.deltaamount";
			this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// textBox23
			// 
			this.textBox23.Location = new System.Drawing.Point(82, 12);
			this.textBox23.Name = "textBox23";
			this.textBox23.Size = new System.Drawing.Size(160, 20);
			this.textBox23.TabIndex = 1;
			this.textBox23.Tag = "mandatekind.idmankind";
			// 
			// textBox24
			// 
			this.textBox24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox24.Location = new System.Drawing.Point(82, 42);
			this.textBox24.Multiline = true;
			this.textBox24.Name = "textBox24";
			this.textBox24.Size = new System.Drawing.Size(482, 36);
			this.textBox24.TabIndex = 3;
			this.textBox24.Tag = "mandatekind.description";
			// 
			// label18
			// 
			this.label18.Location = new System.Drawing.Point(14, 46);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(128, 19);
			this.label18.TabIndex = 67;
			this.label18.Text = "Descrizione";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(35, 16);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(160, 16);
			this.label19.TabIndex = 66;
			this.label19.Text = "Codice:";
			// 
			// tabPageStampa
			// 
			this.tabPageStampa.Controls.Add(this.MetaDataDetail1);
			this.tabPageStampa.Location = new System.Drawing.Point(4, 22);
			this.tabPageStampa.Name = "tabPageStampa";
			this.tabPageStampa.Padding = new System.Windows.Forms.Padding(3);
			this.tabPageStampa.Size = new System.Drawing.Size(586, 638);
			this.tabPageStampa.TabIndex = 1;
			this.tabPageStampa.Text = "Stampa Contratto Passivo";
			this.tabPageStampa.UseVisualStyleBackColor = true;
			// 
			// MetaDataDetail1
			// 
			this.MetaDataDetail1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MetaDataDetail1.Controls.Add(this.tabControl2);
			this.MetaDataDetail1.Controls.Add(this.label11);
			this.MetaDataDetail1.Controls.Add(this.textBox14);
			this.MetaDataDetail1.Controls.Add(this.label14);
			this.MetaDataDetail1.Controls.Add(this.textBox8);
			this.MetaDataDetail1.Controls.Add(this.label15);
			this.MetaDataDetail1.Controls.Add(this.label13);
			this.MetaDataDetail1.Controls.Add(this.textBox15);
			this.MetaDataDetail1.Controls.Add(this.textBox16);
			this.MetaDataDetail1.Controls.Add(this.label10);
			this.MetaDataDetail1.Controls.Add(this.label9);
			this.MetaDataDetail1.Controls.Add(this.textBox10);
			this.MetaDataDetail1.Controls.Add(this.textBox9);
			this.MetaDataDetail1.Location = new System.Drawing.Point(6, 3);
			this.MetaDataDetail1.Name = "MetaDataDetail1";
			this.MetaDataDetail1.Size = new System.Drawing.Size(575, 629);
			this.MetaDataDetail1.TabIndex = 19;
			this.MetaDataDetail1.TabStop = false;
			this.MetaDataDetail1.Tag = "";
			// 
			// tabControl2
			// 
			this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl2.Controls.Add(this.tabPage4);
			this.tabControl2.Controls.Add(this.tabPage5);
			this.tabControl2.Controls.Add(this.tabPage1);
			this.tabControl2.Controls.Add(this.tabPage2);
			this.tabControl2.Controls.Add(this.tabPage3);
			this.tabControl2.Location = new System.Drawing.Point(13, 224);
			this.tabControl2.Name = "tabControl2";
			this.tabControl2.SelectedIndex = 0;
			this.tabControl2.Size = new System.Drawing.Size(561, 399);
			this.tabControl2.TabIndex = 60;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.textBox3);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(553, 373);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Intestazione Report";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// textBox3
			// 
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox3.Location = new System.Drawing.Point(3, 3);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox3.Size = new System.Drawing.Size(547, 367);
			this.textBox3.TabIndex = 38;
			this.textBox3.Tag = "mandatekind.header";
			// 
			// tabPage5
			// 
			this.tabPage5.Controls.Add(this.textBox4);
			this.tabPage5.Location = new System.Drawing.Point(4, 22);
			this.tabPage5.Name = "tabPage5";
			this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage5.Size = new System.Drawing.Size(673, 373);
			this.tabPage5.TabIndex = 4;
			this.tabPage5.Text = "Indirizzo";
			this.tabPage5.UseVisualStyleBackColor = true;
			// 
			// textBox4
			// 
			this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox4.Location = new System.Drawing.Point(3, 3);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox4.Size = new System.Drawing.Size(667, 367);
			this.textBox4.TabIndex = 38;
			this.textBox4.Tag = "mandatekind.address";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.textBox13);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(673, 373);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Annotazioni 1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// textBox13
			// 
			this.textBox13.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox13.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox13.Location = new System.Drawing.Point(3, 3);
			this.textBox13.Multiline = true;
			this.textBox13.Name = "textBox13";
			this.textBox13.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox13.Size = new System.Drawing.Size(667, 367);
			this.textBox13.TabIndex = 36;
			this.textBox13.Tag = "mandatekind.notes1";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.textBox12);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(673, 373);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Annotazioni 2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// textBox12
			// 
			this.textBox12.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox12.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox12.Location = new System.Drawing.Point(3, 3);
			this.textBox12.Multiline = true;
			this.textBox12.Name = "textBox12";
			this.textBox12.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox12.Size = new System.Drawing.Size(667, 367);
			this.textBox12.TabIndex = 36;
			this.textBox12.Tag = "mandatekind.notes2";
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.textBox11);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(673, 373);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Annotazioni 3";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// textBox11
			// 
			this.textBox11.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox11.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox11.Location = new System.Drawing.Point(3, 3);
			this.textBox11.Multiline = true;
			this.textBox11.Name = "textBox11";
			this.textBox11.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBox11.Size = new System.Drawing.Size(667, 367);
			this.textBox11.TabIndex = 37;
			this.textBox11.Tag = "mandatekind.notes3";
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(10, 157);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(122, 15);
			this.label11.TabIndex = 55;
			this.label11.Text = "Titolo Firma Destra:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox14
			// 
			this.textBox14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox14.Location = new System.Drawing.Point(135, 192);
			this.textBox14.Multiline = true;
			this.textBox14.Name = "textBox14";
			this.textBox14.Size = new System.Drawing.Size(431, 26);
			this.textBox14.TabIndex = 52;
			this.textBox14.Tag = "mandatekind.name_r";
			// 
			// label14
			// 
			this.label14.Location = new System.Drawing.Point(10, 8);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(122, 15);
			this.label14.TabIndex = 59;
			this.label14.Text = "Titolo Firma Sinistra:";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox8
			// 
			this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox8.Location = new System.Drawing.Point(135, 157);
			this.textBox8.Multiline = true;
			this.textBox8.Name = "textBox8";
			this.textBox8.Size = new System.Drawing.Size(431, 26);
			this.textBox8.TabIndex = 53;
			this.textBox8.Tag = "mandatekind.title_r";
			// 
			// label15
			// 
			this.label15.Location = new System.Drawing.Point(10, 46);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(122, 15);
			this.label15.TabIndex = 58;
			this.label15.Text = "Nome Firma Sinistra:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(10, 192);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(122, 15);
			this.label13.TabIndex = 54;
			this.label13.Text = "Nome Firma Destra:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox15
			// 
			this.textBox15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox15.Location = new System.Drawing.Point(135, 8);
			this.textBox15.Multiline = true;
			this.textBox15.Name = "textBox15";
			this.textBox15.Size = new System.Drawing.Size(431, 26);
			this.textBox15.TabIndex = 57;
			this.textBox15.Tag = "mandatekind.title_l";
			// 
			// textBox16
			// 
			this.textBox16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox16.Location = new System.Drawing.Point(135, 46);
			this.textBox16.Multiline = true;
			this.textBox16.Name = "textBox16";
			this.textBox16.Size = new System.Drawing.Size(431, 26);
			this.textBox16.TabIndex = 56;
			this.textBox16.Tag = "mandatekind.name_l";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(10, 82);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(122, 15);
			this.label10.TabIndex = 51;
			this.label10.Text = "Titolo Firma Centro:";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(10, 119);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(122, 15);
			this.label9.TabIndex = 50;
			this.label9.Text = "Nome Firma Centro:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox10
			// 
			this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox10.Location = new System.Drawing.Point(134, 82);
			this.textBox10.Multiline = true;
			this.textBox10.Name = "textBox10";
			this.textBox10.Size = new System.Drawing.Size(432, 26);
			this.textBox10.TabIndex = 49;
			this.textBox10.Tag = "mandatekind.title_c";
			// 
			// textBox9
			// 
			this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox9.Location = new System.Drawing.Point(135, 119);
			this.textBox9.Multiline = true;
			this.textBox9.Name = "textBox9";
			this.textBox9.Size = new System.Drawing.Size(431, 26);
			this.textBox9.TabIndex = 48;
			this.textBox9.Tag = "mandatekind.name_c";
			// 
			// tabAttributi
			// 
			this.tabAttributi.Controls.Add(this.gboxclass05);
			this.tabAttributi.Controls.Add(this.gboxclass04);
			this.tabAttributi.Controls.Add(this.gboxclass03);
			this.tabAttributi.Controls.Add(this.gboxclass02);
			this.tabAttributi.Controls.Add(this.gboxclass01);
			this.tabAttributi.Location = new System.Drawing.Point(4, 22);
			this.tabAttributi.Name = "tabAttributi";
			this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
			this.tabAttributi.Size = new System.Drawing.Size(586, 638);
			this.tabAttributi.TabIndex = 3;
			this.tabAttributi.Text = "Attributi";
			this.tabAttributi.UseVisualStyleBackColor = true;
			// 
			// gboxclass05
			// 
			this.gboxclass05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass05.Controls.Add(this.txtCodice05);
			this.gboxclass05.Controls.Add(this.btnCodice05);
			this.gboxclass05.Controls.Add(this.txtDenom05);
			this.gboxclass05.Location = new System.Drawing.Point(6, 286);
			this.gboxclass05.Name = "gboxclass05";
			this.gboxclass05.Size = new System.Drawing.Size(562, 64);
			this.gboxclass05.TabIndex = 28;
			this.gboxclass05.TabStop = false;
			this.gboxclass05.Tag = "";
			this.gboxclass05.Text = "Classificazione 5";
			// 
			// txtCodice05
			// 
			this.txtCodice05.Location = new System.Drawing.Point(9, 38);
			this.txtCodice05.Name = "txtCodice05";
			this.txtCodice05.Size = new System.Drawing.Size(219, 20);
			this.txtCodice05.TabIndex = 6;
			// 
			// btnCodice05
			// 
			this.btnCodice05.Location = new System.Drawing.Point(8, 16);
			this.btnCodice05.Name = "btnCodice05";
			this.btnCodice05.Size = new System.Drawing.Size(88, 23);
			this.btnCodice05.TabIndex = 4;
			this.btnCodice05.Tag = "manage.sorting05.tree";
			this.btnCodice05.Text = "Codice";
			this.btnCodice05.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom05
			// 
			this.txtDenom05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom05.Location = new System.Drawing.Point(234, 8);
			this.txtDenom05.Multiline = true;
			this.txtDenom05.Name = "txtDenom05";
			this.txtDenom05.ReadOnly = true;
			this.txtDenom05.Size = new System.Drawing.Size(320, 52);
			this.txtDenom05.TabIndex = 3;
			this.txtDenom05.TabStop = false;
			this.txtDenom05.Tag = "sorting05.description";
			// 
			// gboxclass04
			// 
			this.gboxclass04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass04.Controls.Add(this.txtCodice04);
			this.gboxclass04.Controls.Add(this.btnCodice04);
			this.gboxclass04.Controls.Add(this.txtDenom04);
			this.gboxclass04.Location = new System.Drawing.Point(6, 216);
			this.gboxclass04.Name = "gboxclass04";
			this.gboxclass04.Size = new System.Drawing.Size(562, 64);
			this.gboxclass04.TabIndex = 27;
			this.gboxclass04.TabStop = false;
			this.gboxclass04.Tag = "";
			this.gboxclass04.Text = "Classificazione 4";
			// 
			// txtCodice04
			// 
			this.txtCodice04.Location = new System.Drawing.Point(9, 38);
			this.txtCodice04.Name = "txtCodice04";
			this.txtCodice04.Size = new System.Drawing.Size(219, 20);
			this.txtCodice04.TabIndex = 6;
			// 
			// btnCodice04
			// 
			this.btnCodice04.Location = new System.Drawing.Point(8, 16);
			this.btnCodice04.Name = "btnCodice04";
			this.btnCodice04.Size = new System.Drawing.Size(88, 23);
			this.btnCodice04.TabIndex = 4;
			this.btnCodice04.Tag = "manage.sorting04.tree";
			this.btnCodice04.Text = "Codice";
			this.btnCodice04.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom04
			// 
			this.txtDenom04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom04.Location = new System.Drawing.Point(234, 12);
			this.txtDenom04.Multiline = true;
			this.txtDenom04.Name = "txtDenom04";
			this.txtDenom04.ReadOnly = true;
			this.txtDenom04.Size = new System.Drawing.Size(320, 46);
			this.txtDenom04.TabIndex = 3;
			this.txtDenom04.TabStop = false;
			this.txtDenom04.Tag = "sorting04.description";
			// 
			// gboxclass03
			// 
			this.gboxclass03.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass03.Controls.Add(this.txtCodice03);
			this.gboxclass03.Controls.Add(this.btnCodice03);
			this.gboxclass03.Controls.Add(this.txtDenom03);
			this.gboxclass03.Location = new System.Drawing.Point(6, 146);
			this.gboxclass03.Name = "gboxclass03";
			this.gboxclass03.Size = new System.Drawing.Size(562, 64);
			this.gboxclass03.TabIndex = 25;
			this.gboxclass03.TabStop = false;
			this.gboxclass03.Tag = "";
			this.gboxclass03.Text = "Classificazione 3";
			// 
			// txtCodice03
			// 
			this.txtCodice03.Location = new System.Drawing.Point(8, 38);
			this.txtCodice03.Name = "txtCodice03";
			this.txtCodice03.Size = new System.Drawing.Size(219, 20);
			this.txtCodice03.TabIndex = 6;
			// 
			// btnCodice03
			// 
			this.btnCodice03.Location = new System.Drawing.Point(8, 16);
			this.btnCodice03.Name = "btnCodice03";
			this.btnCodice03.Size = new System.Drawing.Size(88, 23);
			this.btnCodice03.TabIndex = 4;
			this.btnCodice03.Tag = "manage.sorting03.tree";
			this.btnCodice03.Text = "Codice";
			this.btnCodice03.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom03
			// 
			this.txtDenom03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom03.Location = new System.Drawing.Point(233, 8);
			this.txtDenom03.Multiline = true;
			this.txtDenom03.Name = "txtDenom03";
			this.txtDenom03.ReadOnly = true;
			this.txtDenom03.Size = new System.Drawing.Size(321, 52);
			this.txtDenom03.TabIndex = 3;
			this.txtDenom03.TabStop = false;
			this.txtDenom03.Tag = "sorting03.description";
			// 
			// gboxclass02
			// 
			this.gboxclass02.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass02.Controls.Add(this.txtCodice02);
			this.gboxclass02.Controls.Add(this.btnCodice02);
			this.gboxclass02.Controls.Add(this.txtDenom02);
			this.gboxclass02.Location = new System.Drawing.Point(6, 76);
			this.gboxclass02.Name = "gboxclass02";
			this.gboxclass02.Size = new System.Drawing.Size(562, 64);
			this.gboxclass02.TabIndex = 26;
			this.gboxclass02.TabStop = false;
			this.gboxclass02.Tag = "";
			this.gboxclass02.Text = "Classificazione 2";
			// 
			// txtCodice02
			// 
			this.txtCodice02.Location = new System.Drawing.Point(8, 38);
			this.txtCodice02.Name = "txtCodice02";
			this.txtCodice02.Size = new System.Drawing.Size(219, 20);
			this.txtCodice02.TabIndex = 6;
			// 
			// btnCodice02
			// 
			this.btnCodice02.Location = new System.Drawing.Point(8, 16);
			this.btnCodice02.Name = "btnCodice02";
			this.btnCodice02.Size = new System.Drawing.Size(88, 23);
			this.btnCodice02.TabIndex = 4;
			this.btnCodice02.Tag = "manage.sorting02.tree";
			this.btnCodice02.Text = "Codice";
			this.btnCodice02.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom02
			// 
			this.txtDenom02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom02.Location = new System.Drawing.Point(233, 8);
			this.txtDenom02.Multiline = true;
			this.txtDenom02.Name = "txtDenom02";
			this.txtDenom02.ReadOnly = true;
			this.txtDenom02.Size = new System.Drawing.Size(321, 52);
			this.txtDenom02.TabIndex = 3;
			this.txtDenom02.TabStop = false;
			this.txtDenom02.Tag = "sorting02.description";
			// 
			// gboxclass01
			// 
			this.gboxclass01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass01.Controls.Add(this.txtCodice01);
			this.gboxclass01.Controls.Add(this.btnCodice01);
			this.gboxclass01.Controls.Add(this.txtDenom01);
			this.gboxclass01.Location = new System.Drawing.Point(6, 6);
			this.gboxclass01.Name = "gboxclass01";
			this.gboxclass01.Size = new System.Drawing.Size(562, 64);
			this.gboxclass01.TabIndex = 24;
			this.gboxclass01.TabStop = false;
			this.gboxclass01.Tag = "";
			this.gboxclass01.Text = "Classificazione 1";
			// 
			// txtCodice01
			// 
			this.txtCodice01.Location = new System.Drawing.Point(7, 40);
			this.txtCodice01.Name = "txtCodice01";
			this.txtCodice01.Size = new System.Drawing.Size(220, 20);
			this.txtCodice01.TabIndex = 5;
			// 
			// btnCodice01
			// 
			this.btnCodice01.Location = new System.Drawing.Point(8, 16);
			this.btnCodice01.Name = "btnCodice01";
			this.btnCodice01.Size = new System.Drawing.Size(88, 23);
			this.btnCodice01.TabIndex = 4;
			this.btnCodice01.Tag = "manage.sorting01.tree";
			this.btnCodice01.Text = "Codice";
			this.btnCodice01.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom01
			// 
			this.txtDenom01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom01.Location = new System.Drawing.Point(233, 8);
			this.txtDenom01.Multiline = true;
			this.txtDenom01.Name = "txtDenom01";
			this.txtDenom01.ReadOnly = true;
			this.txtDenom01.Size = new System.Drawing.Size(321, 52);
			this.txtDenom01.TabIndex = 3;
			this.txtDenom01.TabStop = false;
			this.txtDenom01.Tag = "sorting01.description";
			// 
			// tabPageWeb
			// 
			this.tabPageWeb.Controls.Add(this.textBox2);
			this.tabPageWeb.Controls.Add(this.label2);
			this.tabPageWeb.Controls.Add(this.textBox25);
			this.tabPageWeb.Controls.Add(this.label20);
			this.tabPageWeb.Controls.Add(this.textBox20);
			this.tabPageWeb.Controls.Add(this.textBox21);
			this.tabPageWeb.Controls.Add(this.textBox22);
			this.tabPageWeb.Controls.Add(this.label12);
			this.tabPageWeb.Controls.Add(this.label16);
			this.tabPageWeb.Controls.Add(this.label17);
			this.tabPageWeb.Controls.Add(this.textBox1);
			this.tabPageWeb.Controls.Add(this.label1);
			this.tabPageWeb.Location = new System.Drawing.Point(4, 22);
			this.tabPageWeb.Name = "tabPageWeb";
			this.tabPageWeb.Size = new System.Drawing.Size(586, 638);
			this.tabPageWeb.TabIndex = 2;
			this.tabPageWeb.Text = "Notifiche e Contatti";
			this.tabPageWeb.UseVisualStyleBackColor = true;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(14, 265);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(557, 20);
			this.textBox2.TabIndex = 83;
			this.textBox2.Tag = "mandatekind.dangermail";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 226);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(393, 36);
			this.label2.TabIndex = 84;
			this.label2.Text = "E-mail a cui si intende notificare la richieste di ordine di materiale pericoloso" +
    "/radioattivo:";
			// 
			// textBox25
			// 
			this.textBox25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox25.Location = new System.Drawing.Point(13, 185);
			this.textBox25.Name = "textBox25";
			this.textBox25.Size = new System.Drawing.Size(558, 20);
			this.textBox25.TabIndex = 78;
			this.textBox25.Tag = "mandatekind.email";
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(11, 169);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(100, 16);
			this.label20.TabIndex = 82;
			this.label20.Text = "E-mail:";
			// 
			// textBox20
			// 
			this.textBox20.Location = new System.Drawing.Point(180, 140);
			this.textBox20.Name = "textBox20";
			this.textBox20.Size = new System.Drawing.Size(128, 20);
			this.textBox20.TabIndex = 77;
			this.textBox20.Tag = "mandatekind.faxnumber";
			// 
			// textBox21
			// 
			this.textBox21.Location = new System.Drawing.Point(14, 140);
			this.textBox21.Name = "textBox21";
			this.textBox21.Size = new System.Drawing.Size(128, 20);
			this.textBox21.TabIndex = 76;
			this.textBox21.Tag = "mandatekind.phonenumber";
			// 
			// textBox22
			// 
			this.textBox22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox22.Location = new System.Drawing.Point(14, 91);
			this.textBox22.Name = "textBox22";
			this.textBox22.Size = new System.Drawing.Size(557, 20);
			this.textBox22.TabIndex = 75;
			this.textBox22.Tag = "mandatekind.office";
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(180, 124);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(100, 16);
			this.label12.TabIndex = 81;
			this.label12.Text = "Fax:";
			// 
			// label16
			// 
			this.label16.Location = new System.Drawing.Point(12, 124);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(100, 16);
			this.label16.TabIndex = 80;
			this.label16.Text = "Telefono:";
			// 
			// label17
			// 
			this.label17.Location = new System.Drawing.Point(12, 75);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(100, 16);
			this.label17.TabIndex = 79;
			this.label17.Text = "Ufficio Emittente:";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(15, 35);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(556, 22);
			this.textBox1.TabIndex = 68;
			this.textBox1.Tag = "mandatekind.warnmail";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(270, 19);
			this.label1.TabIndex = 69;
			this.label1.Text = "Indirizzo e-mail di notifica dello stato del contratto";
			// 
			// tabIVA
			// 
			this.tabIVA.Controls.Add(this.gBoxIvaKind);
			this.tabIVA.Location = new System.Drawing.Point(4, 22);
			this.tabIVA.Name = "tabIVA";
			this.tabIVA.Padding = new System.Windows.Forms.Padding(3);
			this.tabIVA.Size = new System.Drawing.Size(586, 638);
			this.tabIVA.TabIndex = 4;
			this.tabIVA.Text = "IVA";
			this.tabIVA.UseVisualStyleBackColor = true;
			// 
			// gBoxIvaKind
			// 
			this.gBoxIvaKind.Controls.Add(this.btnTipo);
			this.gBoxIvaKind.Controls.Add(this.cmbTipoIVA);
			this.gBoxIvaKind.Controls.Add(this.txtIva);
			this.gBoxIvaKind.Controls.Add(this.label3);
			this.gBoxIvaKind.Controls.Add(this.lblPercIndeduc);
			this.gBoxIvaKind.Controls.Add(this.txtPercIndeduc);
			this.gBoxIvaKind.Location = new System.Drawing.Point(24, 21);
			this.gBoxIvaKind.Name = "gBoxIvaKind";
			this.gBoxIvaKind.Size = new System.Drawing.Size(431, 50);
			this.gBoxIvaKind.TabIndex = 10;
			this.gBoxIvaKind.TabStop = false;
			this.gBoxIvaKind.Text = "Forza Tipo IVA";
			// 
			// btnTipo
			// 
			this.btnTipo.Location = new System.Drawing.Point(8, 23);
			this.btnTipo.Name = "btnTipo";
			this.btnTipo.Size = new System.Drawing.Size(64, 23);
			this.btnTipo.TabIndex = 7;
			this.btnTipo.TabStop = false;
			this.btnTipo.Tag = "choose.ivakind.default";
			this.btnTipo.Text = "Tipo IVA";
			// 
			// cmbTipoIVA
			// 
			this.cmbTipoIVA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoIVA.DataSource = this.DS.ivakind;
			this.cmbTipoIVA.DisplayMember = "description";
			this.cmbTipoIVA.Location = new System.Drawing.Point(80, 23);
			this.cmbTipoIVA.Name = "cmbTipoIVA";
			this.cmbTipoIVA.Size = new System.Drawing.Size(151, 21);
			this.cmbTipoIVA.TabIndex = 1;
			this.cmbTipoIVA.Tag = "mandatekind.idivakind_forced";
			this.cmbTipoIVA.ValueMember = "idivakind";
			// 
			// txtIva
			// 
			this.txtIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIva.Location = new System.Drawing.Point(239, 24);
			this.txtIva.Name = "txtIva";
			this.txtIva.ReadOnly = true;
			this.txtIva.Size = new System.Drawing.Size(72, 20);
			this.txtIva.TabIndex = 2;
			this.txtIva.TabStop = false;
			this.txtIva.Tag = "ivakind.rate.fixed.4..%.100";
			this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Location = new System.Drawing.Point(239, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 16);
			this.label3.TabIndex = 35;
			this.label3.Text = "Aliquota";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblPercIndeduc
			// 
			this.lblPercIndeduc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPercIndeduc.Location = new System.Drawing.Point(327, 8);
			this.lblPercIndeduc.Name = "lblPercIndeduc";
			this.lblPercIndeduc.Size = new System.Drawing.Size(88, 16);
			this.lblPercIndeduc.TabIndex = 39;
			this.lblPercIndeduc.Text = "% Indetraibilità";
			this.lblPercIndeduc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPercIndeduc
			// 
			this.txtPercIndeduc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPercIndeduc.Location = new System.Drawing.Point(327, 24);
			this.txtPercIndeduc.Name = "txtPercIndeduc";
			this.txtPercIndeduc.ReadOnly = true;
			this.txtPercIndeduc.Size = new System.Drawing.Size(88, 20);
			this.txtPercIndeduc.TabIndex = 3;
			this.txtPercIndeduc.TabStop = false;
			this.txtPercIndeduc.Tag = "ivakind.unabatabilitypercentage.fixed.4..%.100";
			this.txtPercIndeduc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tabANAC
			// 
			this.tabANAC.Controls.Add(this.groupCredDeb);
			this.tabANAC.Location = new System.Drawing.Point(4, 22);
			this.tabANAC.Name = "tabANAC";
			this.tabANAC.Size = new System.Drawing.Size(586, 638);
			this.tabANAC.TabIndex = 6;
			this.tabANAC.Text = "ANAC";
			this.tabANAC.UseVisualStyleBackColor = true;
			// 
			// groupCredDeb
			// 
			this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupCredDeb.Controls.Add(this.txtCredDeb);
			this.groupCredDeb.Location = new System.Drawing.Point(8, 17);
			this.groupCredDeb.Name = "groupCredDeb";
			this.groupCredDeb.Size = new System.Drawing.Size(558, 56);
			this.groupCredDeb.TabIndex = 5;
			this.groupCredDeb.TabStop = false;
			this.groupCredDeb.Tag = "AutoChoose.txtCredDeb.lista";
			this.groupCredDeb.Text = "R.U.P. Responsabile Unico del Procedimento";
			// 
			// txtCredDeb
			// 
			this.txtCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCredDeb.Location = new System.Drawing.Point(8, 24);
			this.txtCredDeb.Name = "txtCredDeb";
			this.txtCredDeb.Size = new System.Drawing.Size(543, 20);
			this.txtCredDeb.TabIndex = 0;
			this.txtCredDeb.Tag = "registry.title?x";
			// 
			// tabClassificazioni
			// 
			this.tabClassificazioni.Controls.Add(this.dgrClassificazioni);
			this.tabClassificazioni.Controls.Add(this.btnIndElimina);
			this.tabClassificazioni.Controls.Add(this.btnIndModifica);
			this.tabClassificazioni.Controls.Add(this.btnIndInserisci);
			this.tabClassificazioni.Location = new System.Drawing.Point(4, 22);
			this.tabClassificazioni.Name = "tabClassificazioni";
			this.tabClassificazioni.Padding = new System.Windows.Forms.Padding(3);
			this.tabClassificazioni.Size = new System.Drawing.Size(586, 638);
			this.tabClassificazioni.TabIndex = 5;
			this.tabClassificazioni.Text = "Classificazioni";
			this.tabClassificazioni.UseVisualStyleBackColor = true;
			// 
			// dgrClassificazioni
			// 
			this.dgrClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgrClassificazioni.DataMember = "";
			this.dgrClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgrClassificazioni.Location = new System.Drawing.Point(6, 44);
			this.dgrClassificazioni.Name = "dgrClassificazioni";
			this.dgrClassificazioni.ReadOnly = true;
			this.dgrClassificazioni.Size = new System.Drawing.Size(572, 575);
			this.dgrClassificazioni.TabIndex = 19;
			this.dgrClassificazioni.Tag = "mandatekindsorting.detail.default";
			// 
			// btnIndElimina
			// 
			this.btnIndElimina.Location = new System.Drawing.Point(166, 14);
			this.btnIndElimina.Name = "btnIndElimina";
			this.btnIndElimina.Size = new System.Drawing.Size(68, 24);
			this.btnIndElimina.TabIndex = 18;
			this.btnIndElimina.Tag = "delete";
			this.btnIndElimina.Text = "Elimina";
			// 
			// btnIndModifica
			// 
			this.btnIndModifica.Location = new System.Drawing.Point(86, 14);
			this.btnIndModifica.Name = "btnIndModifica";
			this.btnIndModifica.Size = new System.Drawing.Size(69, 24);
			this.btnIndModifica.TabIndex = 17;
			this.btnIndModifica.Tag = "edit.detail";
			this.btnIndModifica.Text = "Modifica...";
			// 
			// btnIndInserisci
			// 
			this.btnIndInserisci.Location = new System.Drawing.Point(6, 14);
			this.btnIndInserisci.Name = "btnIndInserisci";
			this.btnIndInserisci.Size = new System.Drawing.Size(68, 24);
			this.btnIndInserisci.TabIndex = 16;
			this.btnIndInserisci.Tag = "insert.detail";
			this.btnIndInserisci.Text = "Inserisci...";
			// 
			// tabPage6
			// 
			this.tabPage6.Controls.Add(this.dataGrid1);
			this.tabPage6.Controls.Add(this.button1);
			this.tabPage6.Controls.Add(this.button2);
			this.tabPage6.Controls.Add(this.button3);
			this.tabPage6.Location = new System.Drawing.Point(4, 22);
			this.tabPage6.Name = "tabPage6";
			this.tabPage6.Size = new System.Drawing.Size(586, 638);
			this.tabPage6.TabIndex = 7;
			this.tabPage6.Text = "Allegati";
			this.tabPage6.UseVisualStyleBackColor = true;
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(7, 46);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.ReadOnly = true;
			this.dataGrid1.Size = new System.Drawing.Size(572, 574);
			this.dataGrid1.TabIndex = 23;
			this.dataGrid1.Tag = "mandatekindattachmentkind.default.default";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(167, 16);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(68, 24);
			this.button1.TabIndex = 22;
			this.button1.Tag = "delete";
			this.button1.Text = "Elimina";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(87, 16);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(69, 24);
			this.button2.TabIndex = 21;
			this.button2.Tag = "edit.default";
			this.button2.Text = "Modifica...";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(7, 16);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(68, 24);
			this.button3.TabIndex = 20;
			this.button3.Tag = "insert.default";
			this.button3.Text = "Inserisci...";
			// 
			// Frm_mandatekind_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(594, 664);
			this.Controls.Add(this.tabMandateKind);
			this.Name = "Frm_mandatekind_default";
			this.Text = "Frm_mandatekind_default";
			this.tabMandateKind.ResumeLayout(false);
			this.tabPageInfo.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.grpCertificatiNecessari.ResumeLayout(false);
			this.grpCertificatiNecessari.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.grpTipoBene.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.tabPageStampa.ResumeLayout(false);
			this.MetaDataDetail1.ResumeLayout(false);
			this.MetaDataDetail1.PerformLayout();
			this.tabControl2.ResumeLayout(false);
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			this.tabPage5.ResumeLayout(false);
			this.tabPage5.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.tabAttributi.ResumeLayout(false);
			this.gboxclass05.ResumeLayout(false);
			this.gboxclass05.PerformLayout();
			this.gboxclass04.ResumeLayout(false);
			this.gboxclass04.PerformLayout();
			this.gboxclass03.ResumeLayout(false);
			this.gboxclass03.PerformLayout();
			this.gboxclass02.ResumeLayout(false);
			this.gboxclass02.PerformLayout();
			this.gboxclass01.ResumeLayout(false);
			this.gboxclass01.PerformLayout();
			this.tabPageWeb.ResumeLayout(false);
			this.tabPageWeb.PerformLayout();
			this.tabIVA.ResumeLayout(false);
			this.gBoxIvaKind.ResumeLayout(false);
			this.gBoxIvaKind.PerformLayout();
			this.tabANAC.ResumeLayout(false);
			this.groupCredDeb.ResumeLayout(false);
			this.groupCredDeb.PerformLayout();
			this.tabClassificazioni.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgrClassificazioni)).EndInit();
			this.tabPage6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
        #endregion

        private void chkAvcpNascosti_CheckedChanged(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (chkAvcpNascosti.Checked) {
                //CIG non  previsto, quindi certificati non necessari
                chkCCdedicato.Enabled = false;
                chkVisura.Enabled = false;
                chkDurc.Enabled = false;
                chkCCdedicato.Checked = false;
                chkVisura.Checked = false;
                chkDurc.Checked = false;
				chkVerificaAnac.Enabled = false;
				chkRegolaritaFiscale.Enabled = false;
				chkOttempLegge.Enabled = false;
				chkCasellarioAmm.Enabled = false;
				chkCasellarioGiud.Enabled = false;
            }
            else {
                chkCCdedicato.Enabled = true;
                chkVisura.Enabled = true;
                chkDurc.Enabled = true;
				chkVerificaAnac.Enabled = true;
				chkRegolaritaFiscale.Enabled = true;
				chkOttempLegge.Enabled = true;
				chkCasellarioAmm.Enabled = true;
				chkCasellarioGiud.Enabled = true;
            }
        }
    }
}
