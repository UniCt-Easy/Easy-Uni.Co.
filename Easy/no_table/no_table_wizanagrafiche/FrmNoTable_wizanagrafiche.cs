
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace no_table_wizanagrafiche {
    public partial class FrmNoTable_wizanagrafiche : MetaDataForm {

        string instregclass =
"UPDATE registryclass set active='N'\r\n "+
"INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('21','S',{ts '2005-12-23 14:43:09.453'},'Software and more','Società, enti commerciali, ditte individuali e studi associati','N','N','S','N','N','N','N','S','S','S','N','N','N','N','N','N','N','S','N','S','N','N','N','S','S','S','N',{ts '2005-12-23 15:13:21.453'},'Software and more')\r\n " +
"INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('22','S',{ts '2005-12-23 14:45:39.453'},'Software and more','Persona Fisica','S','N','S','S','S','N','N','S','N','S','N','S','S','S','N','S','N','S','N','S','N','S','N','S','S','N','N',{ts '2008-03-26 16:38:44.907'},'SA')\r\n " +
"INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('23','S',{ts '2005-12-23 14:49:12.640'},'Software and more','Enti non commerciali ed istituzioni internazionali','N','N','S','N','N','N','N','S','N','S','N','N','N','N','N','N','N','S','N','S','N','N','N','S','S','S','N',{ts '2005-12-28 14:32:58.627'},'Software and more')\r\n " +
"INSERT INTO [registryclass] (idregistryclass,active,ct,cu,description,flagbadgecode,flagbadgecode_forced,flagCF,flagcf_forced,flagcfbutton,flagextmatricula,flagextmatricula_forced,flagfiscalresidence,flagfiscalresidence_forced,flagforeigncf,flagforeigncf_forced,flaghuman,flaginfofromcfbutton,flagmaritalstatus,flagmaritalstatus_forced,flagmaritalsurname,flagmaritalsurname_forced,flagothers,flagothers_forced,flagp_iva,flagp_iva_forced,flagqualification,flagqualification_forced,flagresidence,flagresidence_forced,flagtitle,flagtitle_forced,lt,lu) VALUES ('24','S',{ts '2005-12-23 14:51:33.610'},'Software and more','Anagrafiche complementari','N','N','S','N','N','N','N','N','N','S','N','N','N','N','N','N','N','S','N','S','N','N','N','N','N','S','N',{ts '2005-12-23 15:13:12.813'},'Software and more')\r\n ";

        string Upd_registry = "UPDATE registry SET idregistryclass = " 
                + " CASE " 
                + " WHEN idregistryclass IN ('01','02','08','09') THEN '21' " 
                + " WHEN idregistryclass IN ('05','06','07') THEN '22' " 
                + " WHEN idregistryclass IN ('03','04') THEN '23' " 
                + " WHEN idregistryclass IN ('10','OO') THEN '24' " 
                + " END"; 

        public FrmNoTable_wizanagrafiche() {
            InitializeComponent();
            tabController.HideTabsMode =
                Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
        }


        #region Gestione Tabs

        string CustomTitle;
        /// <summary>
        /// Displays tab n. NewTab and updates buttons
        /// </summary>
        /// <param name="newTab"></param>
        void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Ricomincia.";
            else
                btnNext.Text = "Next >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
            if (newTab > 0) ShowPage(newTab);
        }
        void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count) {
                if (show(this, "Si desidera eseguire ancora la procedura",
                    "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    newTab = 1;
                    ResetWizard();
                }
                else {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
            }
             DisplayTabs(newTab);
        }

        private void btnBack_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }
        private void btnNext_Click(object sender, System.EventArgs e) {
            StandardChangeTab(+1);
        }

        bool CustomChangeTab(int oldTab, int newTab) {
            if (oldTab == 0) {
                return CheckStandard(); // 0->1: nothing to do
            }
            if ((oldTab == 1) && (newTab == 0)) return true; //1->0:nothing to do!
            return true;
        }

        #endregion
        void ResetWizard() {
        }
        public void MetaData_AfterClear() {
            DisplayTabs(0);
        }
        public void MetaData_AfterActivation() {
            CustomTitle = "Wizard Correzione Anagrafiche";
            //Selects first tab
            DisplayTabs(0);
        }
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        string query1 = "cf is not null  and p_iva is null  and len(cf)=11  and isnumeric(cf)=1 and active='S'";
        string update1 = "update registry set p_iva = cf ";
        
        string query2 = "len(cf)=16 and title=surname+' '+forename and idregistryclass<>'22' AND NOT"+filter_dittacomm;
        string update2 = "update registry set idregistryclass = '22'";

        string query3 = " idregistryclass='22' 	and  cf is null and active='S'";
        string update3 = "update registry set idregistryclass = <combo>";

        string query4 = " idregistryclass='21' and p_iva is null and len(cf)=16 and active='S' AND NOT" + filter_dittacomm;
        string update4 = "update registry set idregistryclass = '22'";

        string query5 = " idregistryclass='21' and p_iva is   null and cf is null and active='S' AND NOT" + filter_dittacomm;
        string update5 = "update registry set idregistryclass = <combo>";

        string query6 = " idregistryclass='23'  and len(cf)=16 and active='S'";
        string update6 = "update registry set idregistryclass = <combo>";

        string query7 = " idregistryclass='23' and p_iva is   null and cf is null and active='S'" +
             "and  not " + filter_entenoncomm;
        string update7 = "update registry set idregistryclass = <combo>";

        string query8 = "idregistryclass='23' and  (p_iva is   not null  or cf is not null) and active='S' " +
                        " and   "+filter_dittacomm;
        string update8 = "update registry set idregistryclass = '21'";

        string query9 = "idregistryclass='23' and  (p_iva is   not null  or cf is not null) and active='S' " +
                        "and  " +
                        "(	cf is null or " +
                           "(select count(*) from registry R where R.idregistryclass='23' and R.cf=registrymainview.cf AND R.multi_cf = 'N')" +
                           "=1 " +
                         ") " +
                         "and " +
                         "(     p_iva is null or " +
                           "(select count(*) from registry R where R.idregistryclass='23' and R.cf=registrymainview.p_iva AND R.multi_cf = 'N')" +
                           "=1" +
                          ")" +
                          "and not " + filter_entenoncomm;

        string update9 = "update registry set idregistryclass = <combo>";

        string query10 = " idregistryclass='24' and active='S' " +
                        "and exists (select * from registry r2 where " +
                        "r2.idregistryclass='23' and " +
                        "(registrymainview.cf=r2.cf OR registrymainview.p_iva=r2.p_iva OR " +
                        " registrymainview.cf=r2.p_iva OR registrymainview.p_iva=r2.cf " +
                        " ) and (r2.multi_cf = 'N')" +
                        ")";

        string update10 = "update registry set idregistryclass = '23'";

        string query11 = "idregistryclass<>'23'  and active='S' and  " + filter_entenoncomm;
            
        const string filter_entenoncomm="( " +
                         " title like '%universi%' " +
                          " OR title like '%SANITARIA LOCALE%'  " +
                           " OR title like 'LICEO %'  " +
                           " OR title like 'I.T.I.S. %'  " +
                           " OR title like 'IST.TECNI%'  " +
                           " OR title like 'ISTITUTO TECNICO %'  " +
                           " OR title like 'SCUOLA %'  " +
                           " OR title like 'A.U.S.L. %'  " +
                           " OR title like 'CITTA'' %'  " +
                           " OR title like 'COMUNE %'  " +
                           " OR title like 'REGIONE %'  " +
                           " OR title like 'PROVINCIA %'  " +
                           " OR title like 'MINISTERO %'  " +
               " OR title like 'DIRETTORE %' " +
              "  OR title like '%I.N.P.S.%'  " +
              "  OR title like '%C.N.R.%'  " +
              "  OR title like 'CNR %'  " +
			  " OR title like 'ITIS %' "+
              "  OR title like '%AMBASCIATA ' " +
              "  OR title like '%PARROCCHIA%' " +
              "  OR title like '%OSPEDALI%' " +
              "  OR title like '%MONASTERO%' " +
              "   OR title like '%ENTE NAZIONALE%' " +
              "  OR title like '%POLITECNICO%' " +
             "   OR title like '%CONDOMINIO%' " +
            "   OR title like '%PROVINCIALE%' " +
             "   OR title like '%REGIONALE%' " +
             "  OR title like '%CARABINIERI%' " +
             "  OR title like '%USL%' " +
             "  OR title like '%U.S.L.%' " +
             "  OR title like 'ISTITUTO %' " +
             "  OR title like 'INSTITUTE %' " +
             "  OR title like 'CENTRO INTERDIP%' " +
             "  OR title like 'S.M.S.%' " +
             "  OR title like '%INPDAP%' " +
             "  OR title like '%I.N.P.D.A.P%' " +
             "  OR title like 'MUSEO %' " +
             "  OR title like '%MUSEUM%' " +
             "  OR title like '%ONLUS%' " +
             "  OR title like 'ITC%' " +
             "  OR title like 'I.T.C%' " +
             "  OR title like 'ITC%' " +
             "  OR title like 'I.I.S.S%' " +
             "  OR title like 'ITC%' " +
             "  OR title like '%INAIL%' " +
             "  OR title like '%I.N.A.I.L%' " +
                          " )";
        string update11 = "update registry set idregistryclass = '23'";

        string query12 = " idregistryclass<>'21' and " + filter_dittacomm;
        const string filter_dittacomm=  " (title like '%POSTE ITALIANE%' OR "+
         " title like 'BANCA %' OR " +
         " title like '% BANCA %' OR " +
         " title like '%-SPA %' OR " +
         " title like '% SPA %' OR " +
         " title like '% SPA' OR " +
         " title like '%S.P.A.%' OR " +
         " title like '%-SRL %' OR " +
         " title like '% SRL' OR " +
         " title like '% SRL %' OR " +
         " title like '%S.R.L.%' OR " +
         " title like '%-SNC %' OR " +
         " title like '% SNC' OR " +
         " title like '% SNC %' OR " +
         " title like '%S.N.C.%' OR " +
         " title like '%-SAS %' OR " +
         " title like '% SAS' OR " +
         " title like '% SAS %' OR " +
         " title like '%S.A.S.%' OR " +
         " title like '% INDIVIDUALE%' OR " +
         " title like '% INDIVID.%' OR " +
         " title like '%-DITTA %' OR " +
         " title like '%INTERNATIONAL%' OR " +
		 " title like '%HOTEL%' OR "+
		 " title like '%ALBERGO%' OR "+
         " title like 'DITTA %' OR " +
         " title like '% DITTA %' OR " +
         " title like '% DITTA' OR " +
         " title like '%ACQUEDOTTO%' OR " +
		 " title like '%MOBILIFICIO%' OR "+
         " title like '%LIBRERIA%' OR " +
         " title like '%AUTORIMESSA%' OR " +
         " title like '%CARTOLERIA%' OR " +
         " title like '%CARTOLIBRERIA%' OR " +
         " title like '%VINICOLA%' OR " +
		 " title like '%ASSICURAZ%' OR "+
		 " title like '%RISTORANT%' OR "+
		"  title like '%SOFTWARE%' OR "+
		 " title like '%FERRAMENTA%' OR "+
		 " title like '%COMPUTER%' OR "+
		 " title like '%AUTOTRASPORTI%' OR "+
		"  title like '%IMPRESA %' OR "+
		"  title like '% SERVICE %' OR "+
		"  title like '%SERVICE' OR "+
		"  title like '%AUTONOLEGG%' OR "+
		"  title like '%A R.L.%' OR "+
		"  title like '%AUTOCARROZZERIA%' OR "+
		 " title like '%ELETTRODOMESTICI%' OR "+
		"  title like 'BAR %' OR "+
        "  title like '% BAR %' OR " +
        "  title like '%PASTICCERIA%' OR " +
		"  title like '%CHIOSCO%' OR "+
		"  title like 'FAMIGLIA %' OR "+
		"  title like '%AGENZIA VIAGGI%') ";

	
        string update12 = "update registry set idregistryclass = '21'";


        string query13 = " idregistryclass='24' and (p_iva is   not null  or cf is not null)";
        string update13 = "update registry set idregistryclass = <combo>";

        string query14 = "idregistryclass not in ('21','22') and len(cf)=16";
        string update14 = "update registry set idregistryclass = <combo>";

        // J.T.R. Non aggiungo filtro su multi_cf perché x le persone fisiche non è contemplato
        string query15 = "idregistryclass= '22' and active='S' and " +
            " (" +
            " (isnull(cf,'')<>'' and (select count(*) from registry where isnull(active,'S')='S' and (cf=registrymainview.cf or cf=registrymainview.p_iva ) and idregistryclass='22')>1)  OR " +
            " (isnull(p_iva,'')<>'' and (select count(*) from registry where isnull(active,'S')='S' and (p_iva=registrymainview.cf or p_iva=registrymainview.p_iva ) and idregistryclass='22')>1)  " +
            " )";
        string update15 = "update registry set idregistryclass = <combo>";

        string query16 = "idregistryclass= '21' and active='S' and " +
   " (" +
            " (isnull(cf,'')<>'' and (select count(*) from registry where isnull(active,'S')='S' and (cf=registrymainview.cf or cf=registrymainview.p_iva ) and (multi_cf = 'N') and idregistryclass='21')>1)  OR " +
            " (isnull(p_iva,'')<>'' and (select count(*) from registry where isnull(active,'S')='S' and (p_iva=registrymainview.cf or p_iva=registrymainview.p_iva ) and (multi_cf = 'N') and idregistryclass='21')>1)  " +
   " )";
        string update16 = "update registry set idregistryclass = <combo>";

        string []query;
        string[] sqlupdates;
        DataGrid[] dgrid;
        Button[] buttons;
        ComboBox[] combo;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;

            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            txtIntro.Text =
                "Questa procedura vi assisterà a correggere alcuni eventuali problemi che potrebbero essere " +
                "presenti nei dati dell'anagrafica.\r\n" +
                "In particolare è preferibile procedere per gradi, completando con cura ogni fase prima di " +
                "passare alla successiva.\r\n" +
                "Alla fine della procedura si otterrà il  risultato di classificare correttamente " +
                "ogni anagrafica con una delle seguenti tipologie:\r\n" +
                "- Persone fisiche (inclusi i professionisti con partita iva)\r\n" +
                "- Ditte commerciali (incluse le ditte individuali\r\n" +
                "- Enti non commerciali e istituzioni internazionali\r\n" +
                "- Anagrafiche complementari (anagrafiche FITTIZIE inserite per scopi molto particolari)";
            txt1.Text =
                "Queste anagrafiche hanno un codice fiscale numerico (ossia di aziende) e non hanno partita iva.\r\n" +
                "Si presume che abbiano pari partita iva e che questa sia stata inserita nel codice fiscale.\r\n" +
                "E' possibile assegnare in questa fase la partita iva.\r\n";
            txt2.Text = "Le seguenti anagrafiche non sono classificate come persone fisiche, eppure " +
                 "hanno un codice fiscale alfanumerico ed una denominazione data da cognome + nome.\r\n" +
                 "Selezionare quali, tra le seguenti, sono persone fisiche e premere il bottone in basso.";
            txt3.Text = " Le seguenti anagrafiche non hanno codice fiscale. Verificare che siano effettivamente PERSONE FISICHE.\r\n" +
                 "Se non sono realmente persone fisiche, selezionarle, scegliere nella tendina la tipologia corretta, e premere il " +
                 "bottone Cambia Tipologia. In alternativa, inserirne il codice fiscale.";
            txt4.Text = "Le seguenti anagrafiche non hanno partita iva ma solo codice fiscale e tuttavia " +
                "sono classificate come DITTE COMMERCIALI (in cui rientrano anche le ditte individuali).\r\n" +
                "Se tra esse sono presenti persone fisiche, selezionarle e premere il bottone.\r\n" +
                "Se la denominazione non è del tipo cognome nome è probabile che siano classificate correttamente.\r\n" +
                "Suggerimento: controllare che i nomi/cognomi siano effettivamente plausibili.\r\n";
            txt5.Text = "Le seguenti anagrafiche non hanno partita iva e neanche codice fiscale." +
                        "Sono tutte attualmente classificate come DITTE COMMERCIALI.\r\n" +
                        "Se tra esse sono presenti altre tipologie, selezionarle, scegliere la tipologia corretta "+
                         "e premere il bottone.";
            txt6.Text = "Le seguenti anagrafiche sono classificate attualmente in modo ERRATO.\r\n"+
                        "Infatti non è possibile che siano enti istituzionali.\r\n"+
                        "Selezionarle a gruppi o singolarmente, scegliere la tipologia corretta " +
                         "e premere il bottone.";

            txt7.Text = "Le seguenti anagrafiche non hanno partita iva e neanche codice fiscale." +
                        "Sono tutte attualmente classificate come ENTI NON COMMERCIALI.\r\n" +
                        "Se tra esse sono presenti altre tipologie, selezionarle, scegliere la tipologia corretta "+
                         "e premere il bottone.";

            txt8.Text = "Le seguenti anagrafiche sono attualmente considerate ENTI NON COMMERCIALI, " +
                    "ma in base alla loro denominazione sembrano ditte commerciali.\r\n" +
                    "Selezionare le ditte commerciali e premere il bottone.";

            txt9.Text = "Le seguenti anagrafiche sono attualmente considerate ENTI NON COMMERCIALI, " +
                    "se dovessero esserci errori, selezionare le righe errate, selezionare la tipologia corretta "+
                    "e premere il bottone per assegnarla.";

            txt10.Text = "Le seguenti anagrafiche classificate come COMPLEMENTARI hanno il CF o P.IVA di un altra anagrafica " +
                    "classificata come ente non commerciale. Si può presumere quindi che siano anch'esse dello stesso tipo.\r\n" +
                    "Selezionare le anagrafiche del tipo 'Enti non commerciali e istituzioni internazionali' e premere il bottone.";

            txt11.Text = "Le seguenti anagrafiche hanno una denominazione che fa supporre che siano " +
                    "enti non commerciali, a differenza della loro classificazione attuale.\r\n" +
                    "Se tra esse sono presenti enti non commerciali, selezionarli e premere il bottone.";
            
            txt12.Text = "Le seguenti anagrafiche hanno una denominazione che fa supporre che siano " +
                    " ditte commerciali, a differenza della loro classificazione attuale.\r\n" +
                    "Se tra esse sono presenti ditte commerciali, selezionarle e premere il bottone.";


            txt13.Text = "Le seguenti anagrafiche sono attualmente considerate anagrafiche complementari, " +
                  "ma questo è un ERRORE poiché hanno CF o P.IVA.\r\n" +
                  "Selezionare le righe, selezionare la tipologia corretta e premere il bottone per assegnarla.";

            txt14.Text = "Le seguenti anagrafiche hanno un codice fiscale alfanumerico, " +
                    "tuttavia non sono classificate come persone fisiche o ditte individuali.\r\n"+
                    "Questo è un ERRORE. Selezionare le righe, selezionare la tipologia corretta e "+
                    "premere il bottone per assegnarla.";

            txt15.Text = "Le seguenti anagrafiche sono persone fisiche che hanno codice fiscale o la partita iva uguale a quello di altre " +
                "persone fisiche presenti e attive.\r\n" +
                "Occorre disattivare o correggere le anagrafiche meno recenti o errate.";

            txt16.Text = "Le seguenti anagrafiche sono ditte commerciali che hanno codice fiscale o la partita iva uguale a quello di altre " +
    "ditte presenti e attive.\r\n" +
    "Occorre disattivare o correggere le ditte meno recenti o errate.";


            txtIntro.Select(0, 0);

            query = new string[] { "", query1, query2, query3, query4, query5, query6, query7, query8, query9, query10, 
                            query11,query12,query13,query14,query15,query16 };
            sqlupdates = new string[] { "", update1, update2, update3, update4, update5, update6, update7, update8, update9, update10, 
                            update11,update12,update13,update14,update15,update16};
            dgrid = new DataGrid[]{null,dgrid1,dgrid2,dgrid3,dgrid4,dgrid5,dgrid6,dgrid7,dgrid8,
                                dgrid9,dgrid10,dgrid11,dgrid12,dgrid13,dgrid14,dgrid15,dgrid16};
            buttons = new Button[] { null, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn10, btn11,
                                                btn12,btn13,btn14,btn15,btn16};
            combo = new ComboBox[] { null, null, null, cmb3, null, cmb5, cmb6, cmb7, null, cmb9, null,null,
                                                null, cmb13, cmb14,cmb15,cmb16};
            for (int i = 1; i < tabController.TabPages.Count; i++) {
                DataGrid G = dgrid[i];
                if (G == null) continue;
                G.DoubleClick += new EventHandler(EditRegistry);
                G.MouseDown += new MouseEventHandler(GRID_MouseDown);
                G.MouseUp += new MouseEventHandler(GRID_MouseUp);
                G.ReadOnly = true;
                G.AllowNavigation=false;
            }
            for (int i = 1; i < tabController.TabPages.Count; i++ ) {
                Button B = buttons[i];
                if (B == null) continue;
                B.Click += btn_Click;

                Crownwood.Magic.Controls.TabPage P = tabController.TabPages[i];
                P.Anchor =
                    ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | 
                        System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));

            }
            
        }

        DataTable Anagrafica;
        void ShowPage(int NPasso) {
            btnBack.Enabled = false;
            btnNext.Enabled = false;
            btnRefresh.Enabled = false;
            labNrighe.Visible = false;

            string filter = query[NPasso];
            DataGrid dgr = dgrid[NPasso];
            //Anagrafica= Conn.RUN_SELECT("registrymainview","*","title",filter,null,false);
            Cursor = Cursors.WaitCursor;
            Application.DoEvents();
            Anagrafica = Conn.SQLRunner("SELECT * FROM registrymainview WHERE " + filter + " ORDER BY TITLE", false, 0);
            Cursor = Cursors.Default;
            DataSet DD = new DataSet("temp");
            DD.Tables.Add(Anagrafica);
            foreach (DataColumn CC in Anagrafica.Columns)
                MetaData.DescribeAColumn(Anagrafica, CC.ColumnName, "", -1);
            int pos = 1;
            MetaData.DescribeAColumn(Anagrafica, "idreg", "#", pos++);
            MetaData.DescribeAColumn(Anagrafica, "title", "Denominazione", pos++);
            MetaData.DescribeAColumn(Anagrafica, "cf", "C.F.", pos++);
            MetaData.DescribeAColumn(Anagrafica, "p_iva", "P.Iva", pos++);
            MetaData.DescribeAColumn(Anagrafica, "registryclass", "Tipologia", pos++);
            MetaData.DescribeAColumn(Anagrafica, "forename", "Nome", pos++);
            MetaData.DescribeAColumn(Anagrafica, "surname", "Cognome", pos++);
            dgr.DataBindings.Clear();
            dgr.DataSource = null;
            dgr.TableStyles.Clear();
            HelpForm.SetDataGrid(dgr, Anagrafica);

            formatgrids fg = new formatgrids(dgr);
            fg.AutosizeColumnWidth();
            ComboBox C = combo[NPasso];
            if (C != null) C.SelectedIndex = 0;

            btnRefresh.Visible = (NPasso > 0);
            btnBack.Enabled = true;
            btnNext.Enabled = true;
            btnRefresh.Enabled = true;
            if (Anagrafica.Rows.Count > 0)
                labNrighe.Text = "Righe trovate: " + Anagrafica.Rows.Count;
            else
                labNrighe.Text = "Nessuna  riga trovata.";
            labNrighe.Visible = true;

        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();

        }


        bool CheckStandard() {
            Conn.DO_SYS_CMD("update registry set cf=null where cf=''", true);
            Conn.DO_SYS_CMD("update registry set p_iva=null where p_iva=''", true);

            int NUM_STD = Conn.RUN_SELECT_COUNT("registryclass",
                            "(idregistryclass in ('21','22','23','24')AND(active='S'))", false);
            if (NUM_STD != 0 && NUM_STD != 4) {
                show("Le tipologie presenti non sono compatibili con questa procedura");
                return false;
            }
            if (NUM_STD == 0) {
                if (show(this, "Mancano in questa anagrafica le tipologie standard. " +
                            "Procedendo saranno installate. Si intende procedere?", "Avviso",
                            MessageBoxButtons.OKCancel) != DialogResult.OK) return false;
                Conn.DO_SYS_CMD(instregclass, false);                
            }
            NUM_STD = Conn.RUN_SELECT_COUNT("registryclass",
                            "(idregistryclass in ('21','22','23','24')AND(active='S'))", false);
            if (NUM_STD != 4) {
                show("Problemi nell'installazione delle tipologie standard");
                return false;
            }
            int NUM_UNKNREG = Conn.RUN_SELECT_COUNT("registry",
                              "(idregistryclass not in ('01','02','03','04','05','06',"+
                              "'07','08','09','10','OO','21','22','23','24'))", false);

            if (NUM_UNKNREG > 0) {
                show("Ci sono anagrafiche classificate con tipologie sconosciute." +
                    "E' necessario correggerle prima di procedere.");
                return false;
            }

            int NUM_BADREG = Conn.RUN_SELECT_COUNT("registry",
                "(idregistryclass not in ('21','22','23','24'))", false);
            if (NUM_BADREG > 0) {
                if(show("Ci sono anagrafiche classificate con tipologie non standard."+
                    "Procedendo saranno riclassificati in automatico con tipologie standard."+
                    "Si intende procedere?", "Avviso",
                    MessageBoxButtons.OKCancel) != DialogResult.OK) return false;
                Conn.DO_SYS_CMD(Upd_registry, false);                   
            }
            NUM_BADREG = Conn.RUN_SELECT_COUNT("registry",
               "(idregistryclass not in ('21','22','23','24'))", false);
            if (NUM_BADREG > 0) {
                show("Sono rimaste anagrafiche non classificate con tipologie standard."+
                    "Questo è un problema non risolvibile in automatico.");
                return false;
            }
            RegClass = Conn.CreateTableByName("registryclass", "*");
            GetData.MarkToAddBlankRow(RegClass);
            GetData.Add_Blank_Row(RegClass);
            Conn.RUN_SELECT_INTO_TABLE(RegClass, "idregistryclass", "idregistryclass in ('21','22','23','24')", null, false);
            for (int i = 1; i < tabController.TabPages.Count; i++) {
                ComboBox C = combo[i];
                if (C == null) continue;
                C.DataSource = RegClass;
                C.DisplayMember = "description";
                C.ValueMember = "idregistryclass";
                C.DropDownStyle = ComboBoxStyle.DropDownList;
            }

            return true;
        }
        DataTable RegClass;

        string getFilterReg() {
            int nstep = tabController.SelectedIndex;
            DataGrid G = dgrid[nstep];
            if (G == null) return null;
            DataRow[] sel = GetGridSelectedRows(G);
            if (sel == null) return null;
            if (sel.Length == 0) return null;
            QueryHelper QHS = Conn.GetQueryHelper();
            string filter = QHS.FieldIn("idreg", sel);
            return filter;

        }
        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null) return null;
            if (G.DataSource == null) return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    Res[count++] = GetGridRow(G, i);
                }
            }
            return Res;
        }
        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter = QHC.CmpEq("idreg", G[index, 0]);
            DataRow[] selectresult = MyTable.Select(filter);
            return selectresult[0];
        }
        private void btn_Click(object sender, EventArgs e) {
            int passo= tabController.SelectedIndex;
            string sqlupdate = sqlupdates[passo];
            if (sqlupdate.IndexOf("<combo>") >= 0) {
                ComboBox C = combo[passo];
                if (C == null) {
                    show("Errore");
                    return;
                }
                if (C.SelectedIndex<=0) {
                    show("E' necessario selezionare prima la tipologia corretta.");
                    return;
                }

                string obj = QHS.quote(C.SelectedValue);
                sqlupdate = sqlupdate.Replace("<combo>", obj);
            }
            string filter = getFilterReg();
            if (filter == null) {
                show("E' necessario selezionare prima le anagrafiche da modificare.");
                return;
            }
            sqlupdate += " WHERE " + filter;
            Conn.SQLRunner(sqlupdate);
            //Riaggiorna il grid           
            ShowPage(passo);

        }
        void GridSelectRow(DataGrid G, int I) {
            DataRow R = GetGridRow(G, I);
            if (R == null) return; 
            MetaData Registry = Meta.Dispatcher.Get("registry");

            Registry.ContextFilter = QHS.CmpEq("idreg", R["idreg"]);
            Registry.Edit(this.ParentForm, "anagrafica", false);
            string listtype = Registry.DefaultListType;
            DataRow RR = Registry.SelectOne(listtype, QHS.CmpEq("idreg", R["idreg"]), null, null);
            if (RR != null) Registry.SelectRow(RR, listtype);
        }

        void EditRegistry(object sender, EventArgs e) {
            int passo = tabController.SelectedIndex;
            DataGrid G = dgrid[passo];
            if (G == null) return;
            int i = G.CurrentRowIndex;
            if (i < 0) return;

            GridSelectRow(G, i);

        }

        DateTime LastGridClick;
        private void GRID_MouseDown(object sender, MouseEventArgs e) {
            if (sender == null) return;
            if (!typeof(DataGrid).IsAssignableFrom(sender.GetType())) return;
            DataGrid G = (DataGrid)sender;
            LastGridClick = DateTime.Now;
            //			if (e.Clicks==1){
            //				NavigatorDoubleClick(sender,null);	
            //			}

        }
        void SimpleSelect(DataGrid G, int R) {
            try {
                G.Select(R);
            }
            catch {
            }
        }
        private void GRID_MouseUp(object sender, MouseEventArgs e) {
            if (sender == null) return;
            if (!typeof(DataGrid).IsAssignableFrom(sender.GetType())) return;
            DataGrid G = (DataGrid)sender;
            DataSet D = G.DataSource as DataSet;
            if (D == null) return;
            DataTable T = D.Tables[G.DataMember];
            if (T == null) return;

            System.Windows.Forms.DataGrid.HitTestInfo myHitTest = G.HitTest(e.X, e.Y);
            if (myHitTest.Type == System.Windows.Forms.DataGrid.HitTestType.Cell) {
                int Row = myHitTest.Row;
                if (!G.IsSelected(Row)) {                    
                    //if (HelpForm.GetAllowMultiSelection(T)) 
                    SimpleSelect(G, Row);
                }
                else {
                    G.UnSelect(Row);
                }
            }
            else {
                int Row = myHitTest.Row;
                //HelpForm.ClearSelection(G);
                //SimpleSelect(G, Row);
            }


        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            ShowPage(tabController.SelectedIndex);
        }

        private void tabController_SelectionChanged(object sender, EventArgs e) {

        }
    }

       
}
