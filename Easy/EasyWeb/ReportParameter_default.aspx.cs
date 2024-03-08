
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
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HelpWeb;
using funzioni_configurazione;
using metadatalibrary;
using metaeasylibrary;
using AllDataSet;
using EasyWebReport;
using security_function;
using System.Net;
using System.Collections.Specialized;
using System.Text;

public partial class ReportParameter_default : MetaPage
{
    ReportVista reportVista1;
    DSParam DS;
    private string Module;
    private string ReportName;
    string ReportTitle;

    // Aggiungiamo i controlli al placeholder e dopo aggiungiamo il Placeholder (AfterLink o qualcosa del genere) alla pagina;
    PlaceHolder MainPlaceHolder;
    //private /*Rana:Report.*/ReportVista reportVista1;
    //public /*Rana:Report.*/vistaForm DS;
    private Easy_DataAccess myDA;
    private DataTable myPrymaryTable;
    private bool InsertMode;
    const string DummyPrimaryKey = "reportname";
    public int HelpTxtID;
    public int LabelID;
    private Button btnPreview;
    private Button btnParamUfficiali;
    //MetaData Meta;
    bool RefillCustomReportParam = false;
    enum appfmts
    {
        _dateshort = 13, _datetimeshort, _datelong, _datetimelong,
        _time, _timestamp, _datetimeansi, _dateansi, _datedbf, _general = 22,
        _number, _currency, _serial = 25, _longserial, _percentage,
        _highpercentage, _year = 29, _twodigit, _threedigit, _generalus,
        _twodecimal, _twodecimalsep, _threedecimal, _threedecimalsep, _integer = 37,
        _none = 38, _euro, _sixdecimalsep
    };

    ArrayList ComboToPreset=new ArrayList();

    //per la gestione dell'autochoose non da libreria
    Hashtable hashChoose = new Hashtable();
    //contatore per Alias
    int AliasCount = 0;

    int VPosition = 15;
    int HPosition = 10;
    int LabelHeight = 16;
    int TextHeight = 30;
    int HelpHeight = 36;
    int ControlWidth = 300;
    private System.Windows.Forms.Button btnDiagnostic;
    int RigaSuccessiva = 44;
    private DataRow ModuleReport = null;
    private DataRow[] Parameters;
    //Http http = null;
    string ReportDir = "";
    string[] siti = null;
    private Button btnPatch;
    private Button btnAcrobat;
    private static string m_CheckReportLog = "";
    private CheckBox chkClose;
    bool OnePrintObbligatorio = false;
    QueryHelper QHS;
    CQueryHelper QHC;


    public override DataSet GetDataSet()
    {
        return DS;
    }
    public override DataSet CreateNewDataSet()
    {
        return new DSParam();
    }
    public override void SetDataSet(DataSet D)
    {
        DS = (DSParam)D;
        HelpTxtID = 0;
        LabelID = 0;
        reportVista1 = new ReportVista();
        
        //BuildForm(Parameters);
    }
    protected override void OnPreInit(EventArgs e) {
        base.OnPreInit(e);
        BuildForm(Meta.ExtraParameter.ToString(), Meta);
    }
    public override void AfterLink(bool firsttime, bool formToLink)
    {
        Meta.CanInsert = false;
        Meta.CanCancel = false;
        Meta.CanSave = false;
        Meta.SearchEnabled = false;
        
        //Parameters = reportVista1.reportparameter.Select(null, "number asc");
        //BuildForm(Parameters);
        //if(ParamsForm.Controls.Count==0)
        ParamsForm.Controls.Add(MainPlaceHolder);

        if (ComboToPreset != null)
        {
            for (int i = 0; i < ComboToPreset.Count; i++)
            {
                hwDropDownList CB = (hwDropDownList)ComboToPreset[i];
                if (CB.Items.Count > 1) CB.SelectedIndex = 1;
            }
            ComboToPreset = null;
        }

        Page.Title = ReportTitle;
        DS.AcceptChanges();
        reportVista1.AcceptChanges();
    }


    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
    }

    public bool BuildForm(string ModuleNameReportName, MetaData M)
    {
        
        IDataAccess DA = Conn;
        myDA = DA as Easy_DataAccess;
        QHC = new CQueryHelper();
        QHS = myDA.GetQueryHelper();
        //Riempie il dataset  ReportVista delle tabelle che mi servono a costruire il Form
        FillReportVista(ModuleNameReportName, DA);
        //			if(reportVista1.Tables["reportparameter"].Rows.Count == 0) {
        //				return false;
        //			}

        
        if (reportVista1.Tables["report"].Rows.Count == 0)
        {
            M.ExtraParameter = "Occorre eseguire un File\\Menu\\Aggiorna Menu.";
            return false;
        }
        
        ModuleReport = reportVista1.Tables["report"].Rows[0];
        ReportTitle = ModuleReport["description"].ToString();
        reporttitle.Text = ReportTitle;



        Parameters = reportVista1.reportparameter.Select(null, "number asc");
        CreatePrimaryTable(Parameters);

        ////////////////////////////////////////////////////////////////////////////
        //Inizia la Procedura per l'inserimento dei controlli nel Form.
        MainPlaceHolder = new PlaceHolder();

        // Inizialmente proviamo il posizionamento relativo
        //VPosition += RigaSuccessiva;  //Incrementa il puntatore per la riga successiva
        Table Tbl = new Table();
        Tbl.CellPadding = 0;
        Tbl.CellSpacing = 0;
        Tbl.BorderWidth = 0;
        Tbl.Style.Add("width", "80%");

        //Per ogni parametro ovvero per ogni riga presente nella tabella reportparameter
        foreach (DataRow Param in Parameters)
        {
            TableRow TR = new TableRow();
            bool skipSizeIncrement = false;
            // DS invece è il DataSet che si va a popolare con le tabelle del report
            string selectioncode = Param["selectioncode"].ToString();
            string paramname = Param["paramname"].ToString();
            

            // Manager. Skippa il controllo.
            //if (Param["datasource"].ToString().ToLower() == "manager" && Session["CodiceResponsabile"]!=null)
            //    continue;

            // il Fornitore non può selezionare Anagrafica. Non consentire la selezione del fornitore. Skippa il controllo in questo caso
            if ((Param["datasource"].ToString().ToLower() == "registryreference" || Param["datasource"].ToString().ToLower() == "registry") 
                && Session["codicefornitore"] != null)
                continue;

            //verifica se sono in presenza di tabella alias 
            //(i campi devono contenere la stringa "|alias")
            bool IsAlias = true;
            /*
             * 
            bool IsAlias = (Param["paramname"].ToString().IndexOf("|alias") != -1);
            if (!IsAlias)
            {
                string table = Param["datasource"].ToString();
                if ((table != "") && DS.Tables.Contains(table)) IsAlias = true;
            }
            */
            if (IsAlias) ++AliasCount;

            bool customField = IsCustomField(selectioncode);

            if (customField)
            {
                //E' un campo nascosto?
                if (selectioncode.ToLower() == "costant.hidden") skipSizeIncrement = true;
                TableCell TC = new TableCell();
                TC.Style.Add("text-align", "left");
                TC.Style.Add("vertical-align", "middle");

                bool added = AddCustomControl(selectioncode,
                    myPrymaryTable.TableName, paramname,
                    HPosition, VPosition, Param, IsAlias, TC);
                if (added) {
                    TR.Cells.Add(TC);
                }
                skipSizeIncrement = !added;
            }
            else
            {
                TableCell TC2 = new TableCell();
                TC2.Style.Add("text-align", "left");
                TC2.Style.Add("vertical-align", "middle");
                //HtmlGenericControl br = new HtmlGenericControl("br");
                if (Param["iscombobox"].ToString().ToUpper() == "S")
                {
                    InserisciLabel(Param, TC2);
                    //TC2.Controls.Add(br);

                    if (!AddTableToDS(Param, IsAlias))
                    {
                        Meta.ExtraParameter = " Errore nella costruzione del parametri (campo " +
                            Param["paramname"].ToString() + " su tabella " +
                                Param["datasource"].ToString() + ")";
                        return false;
                    }

                    if (Param["datasource"].ToString().ToLower() == "upb" && Session["codiceresponsabile"] != null)
                    {
                        // Filtra per responsabile
                        string tablename2 = Param["datasource"].ToString();
                        if (IsAlias)
                        {
                            tablename2 += AliasCount;
                        }

                        //string cmbfilter;
                        //cmbfilter = QHC.AppAnd(QHC.DoPar(QHC.AppOr(QHC.IsNull("idman"), QHC.CmpEq("idman", Session["codiceresponsabile"]))), QHC.CmpEq("active", "S"));
                        //GetData.SetStaticFilter(DS.Tables[tablename2], cmbfilter);
                    
                    }

                    InserisciCombo(Param, IsAlias, TC2);
                }
                else
                {

                    InserisciLabel(Param, TC2);
                    //TC2.Controls.Add(br);

                    InserisciTextBox(Param, TC2);
                }
                TR.Cells.Add(TC2);
            }

            if (!skipSizeIncrement)
            {
                TableCell TC3 = new TableCell();
                TC3.Style.Add("vertical-align", "middle");

                //TC3.Style.Add("text-align", "left");
                if (customField)
                {
                    if (Param["help2"].ToString() != "")
                        InserisciHelp(GetPrintable(myDA.Security.Compile(Param["help2"].ToString(), true)), TC3);
                    else
                        InserisciHelp(GetPrintable(myDA.Security.Compile(Param["help"].ToString(), true)), TC3);
                }
                else
                    InserisciHelp(GetPrintable(myDA.Security.Compile(Param["help"].ToString(), true)), TC3);
                //Incrementa il puntatore per la riga successiva
                VPosition += RigaSuccessiva;
                TR.Cells.Add(TC3);

                Tbl.Rows.Add(TR);
            }
            

        }//Fine foreach
        MainPlaceHolder.Controls.Add(Tbl);
        //Ridefinisce la lunghezza del form
        //int myheigth = VPosition + 120 + btnDiagnostic.Height;
        //if (myheigth < 312) myheigth = 312;
        //this.Height = myheigth;
        return true;
     
    }



    string GetPrintable(string msg)
    {
        string S = msg.Replace("\r", "\n");
        S = S.Replace("\n\n", "\n");
        S = S.Replace("\n", "\r\n");
        return S;
    }


    public override void AfterFill()
    {
        if (ComboToPreset != null)
        {
            for (int i = 0; i < ComboToPreset.Count; i++)
            {
                hwDropDownList CB = (hwDropDownList)ComboToPreset[i];
                if (CB.Items.Count > 1) CB.SelectedIndex = 1;
            }
            ComboToPreset = null;
        }

        Page.Title = ReportTitle;
        DS.AcceptChanges();


    }

    public override void AfterGetFormData()
    {
        DS.AcceptChanges();
    }


    public override void AfterClear()
    {
        Page.Title = ReportTitle;
        if (InsertMode) return;
        InsertMode= true;    //Non si può... InsertMode è readonly
        CommFun.EditNew();

    }

    //Gli viene passata una riga della tabella "reportparameter"
    //che deve avere "iscombobox" = "S" per giustificare l'aggiunta della
    //tabella al dataset.
    //Tale tabella sarà il datasource del combobox
    //e dovrà avere una Relation con la tabella principale.
    //Il Campo con nome "displaymember" dovrà essere campo chiave
    //della tabella che sto aggiungendo al dataset.
    private bool AddTableToDS(DataRow Param, bool IsAlias)
    {

        string paramname = Param["paramname"].ToString();
        string datasourceName = Param["datasource"].ToString();
        string RealTable = datasourceName;
        string CodeFieldName = Param["valuemember"].ToString();
        
        //Aggiunge il nuovo DataTable se non c'è già oppure se è un alias
        if (DS.Tables[datasourceName] == null || IsAlias)
        {
            DataTable T = myDA.CreateTableByName(datasourceName, null);
            if (IsAlias)
            {
                string AliasTable = datasourceName + AliasCount;
                T.TableName = AliasTable;
                datasourceName = AliasTable;
                DataAccess.SetTableForReading(T, RealTable);
            }

            if (DS.Tables.Contains(T.TableName))
                T = DS.Tables[T.TableName];
            else
                DS.Tables.Add(T);

            if (T.Columns[CodeFieldName] == null) return false;
            if (myPrymaryTable.Columns[paramname] == null) return false;
            //Add datasource->PrimaryTable Relation
            DataColumn ParentCol = T.Columns[CodeFieldName];
            DataColumn ChildCol = myPrymaryTable.Columns[paramname];
            string relname = datasourceName + myPrymaryTable.TableName;
            if(DS.Relations[relname]==null)
                DS.Relations.Add(relname, ParentCol, ChildCol, false);
        }

        //Per i parametri che hanno il campo filter avvalorato e che hanno il iscombobox = 'S' 
        //nella tabella reportparameter, imposto un filtro statico sulla tabella del dataset
        DataTable datasource = DS.Tables[datasourceName];
        string Filter = Param["filter"].ToString().Trim();
        if (Filter != "")
        {
            Filter = myDA.Security.Compile(Filter, true);
            GetData.SetStaticFilter(datasource, Filter);
        }
        if (datasourceName.ToLower().IndexOf("level") >= 0)
        {
            if (datasource.Columns["nlevel"] != null)
            {
                GetData.SetSorting(datasource, "nlevel");
                if (Filter != "")
                {
                    GetData.CacheTable(datasource, Filter, "nlevel", true);
                }
                else
                {
                    GetData.CacheTable(datasource, null, "nlevel", true);
                }
            }
        }

        //Aggiunge filtro su esercizio se chiave primaria contiene
        // un campo di nome esercizio
        if ((Filter == "") && (QueryCreator.IsPrimaryKey(datasource, "ayear")))
        {
            GetData.SetStaticFilter(datasource, "(ayear='" +
                Conn.Security.GetSys("esercizio").ToString() + "')");
        }
        return true;
    }


    private void AddCustomTableToDS(DataRow customRow, string paramname, bool IsAlias)
    {

        string parenttable = customRow["tablename"].ToString();
        string RealTable = parenttable;
        //if (DS.Tables[parenttable] != null && DS.Tables[parenttable + AliasCount.ToString()] != null) return; // Esci se la tabella è già presente nel DS
        //Aggiunge il nuovo DataTable se non c'è già
        if (DS.Tables[parenttable] == null || IsAlias)
        {
            DataTable T = myDA.CreateTableByName(parenttable, null);
            if (IsAlias)
            {
                string AliasTable = parenttable + AliasCount;
                T.TableName = AliasTable;
                parenttable = AliasTable;
                DataAccess.SetTableForReading(T, RealTable);
            }
            if (DS.Tables.Contains(T.TableName))
                T = DS.Tables[T.TableName];
            else
                DS.Tables.Add(T);

            string relatedcolname = customRow["relationfield"].ToString();
            DataColumn ParentCol = T.Columns[relatedcolname];
            DataColumn ChildCol = myPrymaryTable.Columns[paramname];
            string relname = parenttable + myPrymaryTable.TableName;
            if(DS.Relations[relname]==null)
                DS.Relations.Add(relname, ParentCol, ChildCol, false);
        }
        DataTable ParentTable = DS.Tables[parenttable];
        string Filter = customRow["filter"].ToString().Trim();
        if (Filter != "")
        {
            Filter = myDA.Security.Compile(Filter, true);
            GetData.SetStaticFilter(ParentTable, Filter);
        }
        string Extra = customRow["extraparameter"].ToString();
        if (Extra != "")
        {
            Extra = myDA.Security.Compile(Extra, true);
            ParentTable.ExtendedProperties[MetaPage.ExtraParams] = Extra;
        }
        //Aggiunge filtro su esercizio se chiave primaria contiene
        // un campo di nome esercizio
        if (QueryCreator.IsPrimaryKey(ParentTable, "ayear"))
        {
            GetData.SetStaticFilter(ParentTable, "(ayear='" +
                Conn.Security.GetSys("esercizio").ToString() + "')");
        }
    }



    private bool AddCustomControl(string tag, string tablename, string paramname,
        int HPosition, int VPosition, DataRow param, bool IsAlias, TableCell TCell)
    {
        if (tag == "") return false;
        int dotpos = tag.IndexOf(".");
        string tipo = tag.Substring(0, dotpos);
        string[] token = tag.Substring(dotpos + 1).Split('|');


        // Se si è manager ed il parametro è upb, invece di mostrare il groupbox, mettiamo una combo filtrata


        switch (tipo.ToLower())
        {
            case "check":
                hwCheckBox ctrl = new hwCheckBox();
                ctrl.Tag = tablename + "." + paramname + ":" + token[0] + ":" + token[1];
                ctrl.Text = token[2];
                ctrl.Width = ControlWidth - 20;
                TCell.Controls.Add(ctrl);
                TCell.Style.Add("text-align", "left");
                TCell.Style.Add("vertical-align", "middle");

                //ctrl.Style.Add("left", HPosition.ToString());
                //ctrl.Style.Add("top", VPosition + 8);
                //ctrl.Location = new Point(HPosition, VPosition + 8);
                if (OnePrintObbligatorio && paramname == "oneprint")
                {
                    ctrl.Enabled = false;
                }
                break;

            case "radio":
                hwPanel grp = InserisciGroupBox(param,TCell);

                int i;
                Unit  Altezza = new Unit(0);
                LiteralControl br;
                for (i = 0; i < token.Length / 2; i++)
                {
                    hwRadioButton rb = new hwRadioButton();
                    rb.Tag = tablename + "." + paramname + ":" + token[2 * i];
                    rb.Text = token[2 * i + 1];
                    //rb.Width = ControlWidth - 20;
                    rb.Height = LabelHeight;
                    //TCell.Controls.Add(rb);
                    grp.Controls.Add(rb);
                    br = new LiteralControl("<br/>");
                    grp.Controls.Add(br);
                    TCell.Controls.Add(grp);

                    // come li piazziamo
                    //rb.Location = new Point(12, Altezza);
                    // Serve incrementarlo??
                    Altezza =   new Unit(Altezza.Value+ rb.Height.Value);
                }
                grp.Height = new Unit(Altezza.Value+ grp.Height.Value); //Altezza + 10;
                //this.VPosition += (grp.Height - HelpHeight - 4);

                break;


            case "custom":
                string selectioncode = token[0];
                //ReportVista.customselectionDataTable T = reportVista1.customselection;
                //DataRow selRow = T.FindByselectioncode(selectioncode);
                DataTable T = reportVista1.customselection;
                string filter=QHC.CmpEq("selectioncode",selectioncode);
                DataRow[] selRow = T.Select(filter);


                if (selRow == null) return false;
                string parenttable = selRow[0]["tablename"].ToString();
                string editlisttype = selRow[0]["editlisttype"].ToString();
                string selectiontype = selRow[0]["selectiontype"].ToString();
                string fieldname = selRow[0]["fieldname"].ToString();
                filter = myDA.Security.Compile(selRow[0]["filter"].ToString(), true);
                string filterapp = filter;
                AddCustomTableToDS(selRow[0], paramname, IsAlias);
                if (IsAlias) parenttable += AliasCount;

                GestioneClass GestAttributi = GestioneClass.GetGestioneClassForField(selectioncode, myDA, parenttable);

                if (GestAttributi != null) {
                    selectiontype = "C";
                    myPrymaryTable.Columns[paramname].DefaultValue = GestAttributi.DefaultValue();
                    bool denynull = !GestAttributi.AllowNull();
                    myPrymaryTable.Columns[paramname].AllowDBNull = !denynull;
                    HelpForm.SetDenyZero(myPrymaryTable.Columns[paramname], denynull);
                    HelpForm.SetDenyNull(myPrymaryTable.Columns[paramname], denynull);

                    if (GestAttributi.AllowSelection() == false) {
                        return false;
                    }

                }

                if (filter != "") filterapp = "." + filterapp;


                // C(hoose) o M(anage)?
                bool IsAutoManage = (selectiontype.ToUpper() == "M");
                bool IsAutoChoose = (selectiontype.ToUpper() == "C");
                bool IsComboManage = (selectiontype.ToUpper() == "U");

                if (false) //(paramname == "idupb" && Session["codiceresponsabile"] != null)
                {

                    // Invece di inserire il groupbox, se sono un responsabile
                    // Inserisco la classica dropdown e la filtro.
                    
                    hwDropDownList CB = new hwDropDownList();
                    CB.Style.Add("width", "302px");

                    string tablename2 = param["datasource"].ToString();
                    string paramname2 = param["paramname"].ToString();
                    if (IsAlias)
                    {
                        tablename2 += AliasCount;
                    }
                    //CB.Location = new Point(btn.Location.X + btn.Width + 1, 14);
                    //CB.Width = ControlWidth - btn.Width - 20;
                    CB.ID = paramname;
                    //CB.DropDownStyle = ComboBoxStyle.DropDownList;
                    CB.Tag = myPrymaryTable.TableName + "." + paramname2;
                    string cmbfilter;
                    cmbfilter = QHC.AppAnd(QHC.DoPar(QHC.AppOr(QHC.IsNull("idman"), QHC.CmpEq("idman", Session["codiceresponsabile"]))), QHC.CmpEq("active", "S"));

                    GetData.SetStaticFilter(DS.Tables[tablename2], cmbfilter);

                    hwLabel LB = InserisciLabel(param,TCell);

                    CB.DataSource = DS.Tables[tablename2];
                    CB.DataValueField = "idupb";
                    CB.DataTextField = "title";
                    CB.AutoPostBack = true;
                    TCell.Controls.Add(CB);
                    return false;
                }

                //Inserisco un groupbox
                hwPanel gb = InserisciGroupBox(param, selRow[0]["selectionname"].ToString(),TCell);
                //gb.Style.Add("background-color", "#bababa;");
                //gb.Style.Add("border", "1px solid grey");
                //gb.Style.Add("width", "95%");



                //aggiungo un button
                hwButton btn = new hwButton();
                btn.ID = "btn"+paramname;
                btn.Text = "Seleziona";
                //btn.Location = new Point(12, 14);
                btn.Style.Add("width", "85px");
                //btn.Height = TextHeight - 9;
                gb.Controls.Add(btn);
                LiteralControl nbsp = new LiteralControl("&nbsp;");
                gb.Controls.Add(nbsp);
                hwTextBox tbp = null;
                if (IsAutoChoose || IsAutoManage)
                {
                    //e un textbox
                    tbp = new hwTextBox();
                    tbp.ID = paramname;

                    //TBP.Location = new Point(btn.Location.X + btn.Width + 1, 14);
                    //TBP.Width = ControlWidth - btn.Width - 20;
                    //TBP.Height = TextHeight;
                    tbp.Tag = parenttable + "." + fieldname + "?x";
                    tbp.Style.Add("width", "179px");
                    gb.Controls.Add(tbp);
                }
                if (IsComboManage)
                {

                    btn.Tag = "manage." + parenttable + "." + editlisttype + filterapp;

                    hwDropDownList CBP = new hwDropDownList();

                    string tablename2 = param["datasource"].ToString();
                    string paramname2 = param["paramname"].ToString();
                    if (IsAlias)
                    {
                        tablename2 += AliasCount;
                    }
                    hwDropDownList CB = new hwDropDownList();
                    CB.Style.Add("width", "179px");
                    //CB.Location = new Point(btn.Location.X + btn.Width + 1, 14);
                    //CB.Width = ControlWidth - btn.Width - 20;
                    CB.ID = paramname;
                    //CB.DropDownStyle = ComboBoxStyle.DropDownList;
                    CB.Tag = myPrymaryTable.TableName + "." + paramname2;
                    CB.DataSource = DS.Tables[tablename2];
                    CB.DataValueField = param["valuemember"].ToString();
                    CB.DataTextField = param["displaymember"].ToString();
                    CB.AutoPostBack = true;
                    if ((paramname.IndexOf("level") >= 0) && (param["hintkind"].ToString().ToUpper() == "NOHINT"))
                    {
                        ComboToPreset.Add(CB);
                    }
                    gb.Controls.Add(CB);
                    TCell.Controls.Add(gb);
                }
                if (GestAttributi != null) {
                    tbp.Style.Add("text-align", "left");
                    tbp.Style.Add("width", "179px");
                    btn.Tag = GestAttributi.BtnTag();
                    gb.Tag = "AutoChoose." + tbp.ID + "." + editlisttype + "." + GestAttributi.GetFilterAutoChoose();

                }
                else {
                    if (IsAutoManage) {
                        tbp.Style.Add("text-align", "right");
                        tbp.Style.Add("width", "179px");
                        //TBP.TextAlign = HorizontalAlignment.Right;
                        btn.Tag = "manage." + parenttable + "." + editlisttype + filterapp;
                        gb.Tag = "AutoManage." + parenttable + "." + editlisttype + filterapp;
                    }
                    if (IsAutoChoose) {
                        tbp.Style.Add("text-align", "left");
                        tbp.Style.Add("width", "179px");
                        //TBP.TextAlign = HorizontalAlignment.Left;
                        btn.Tag = "choose." + parenttable + "." + editlisttype + filterapp;
                        gb.Tag = "AutoChoose." + tbp.ID + "." + editlisttype + filterapp;
                    }
                }
                break;

            case "costant":
                //controlli il cui valore è costante (es. il filtro bilancio deve essere 'E')
                bool visible = !(token[0].ToLower() == "hidden");
                hwLabel lb = InserisciLabel(param,TCell);
                lb.Visible = visible;
                hwTextBox tb = InserisciTextBox(param,TCell);
                if(!visible)
                    tb.Style.Add("display", "none");
                tb.ReadOnly = true;

                if (!visible) return false;
                break;
        }
        return true;
    }


	private bool FillReportVista(string ModuleNameReportName,IDataAccess DA) {
        ClearDataSet.RemoveConstraints(reportVista1);
		GetData MyGetData = new GetData();
		MyGetData.InitClass(reportVista1,DA,"report");
		DataRow DR = reportVista1.report.NewRow();
		
		Module = HelpForm.GetField(ModuleNameReportName,0);
		ReportName = HelpForm.GetField(ModuleNameReportName,1);

		DR["reportname"] = ReportName;
		
		MyGetData.SEARCH_BY_KEY(DR);
		MyGetData.DO_GET(false,null);
		MyGetData.DO_GET_TABLE(reportVista1.customselection,null,null,false,null);
        OnePrintObbligatorio = !security_function.Sec_Function.funzioneConsentita(DA as DataAccess, "multiprint");

        return true;
	}



	/// <summary>
	/// Create primary table in DS and assign to "myPrimaryTable"
	/// </summary>
	/// <param name="ReportParameters"></param>
	void CreatePrimaryTable(DataRow[] ReportParameters){
        if (DS.Tables["resultparameter"] != null)
        {
            myPrymaryTable = DS.Tables["resultparameter"];
            return;
        }

        myPrymaryTable = new DataTable("resultparameter");

        DataColumn DCPK = new DataColumn(DummyPrimaryKey,typeof(string));
		DCPK.DefaultValue = ReportName;
		myPrymaryTable.Columns.Add(DCPK);
		myPrymaryTable.PrimaryKey = new DataColumn[]{DCPK};
		
		//Add parameters as primary table fields
		foreach (DataRow Param in ReportParameters){
			System.Type ColType = GetTypeFromSysType(Param["systype"].ToString());
			string ColName = Param["paramname"].ToString();
			DataColumn Col = new DataColumn(ColName,ColType);

			object Def= DefaultForParameter(Param);
			if (Def!=DBNull.Value) Col.DefaultValue= Def;
			
			//il campo è gestito se è flag combo = 'S' o se 
			//il campo selectioncode (manage/chhose) non è null
			bool Gestito=((Param["iscombobox"].ToString().ToUpper()=="S") ||
				(Param["selectioncode"].ToString()!=""));

			bool ConvertNullToPerc=(Gestito && 
				(Param["noselectionforall"].ToString().ToUpper() == "S"));

			Col.ExtendedProperties["ConvertNullToPerc"]= ConvertNullToPerc;
			///TODO: Verificare Gestione AllowDBNull
			Col.AllowDBNull = (Param["hintkind"].ToString()=="NOHINT") || ConvertNullToPerc;

			myPrymaryTable.Columns.Add(Col);
            if (OnePrintObbligatorio && Col.ColumnName == "oneprint") {
                Col.DefaultValue = "S";
            }
            
		}
        ControllaObbligatorietaResp();
        ControllaObbligatorietaUpb();
        DS.Tables.Add(myPrymaryTable);
	}

    object CalcDefaultForManager() {
        //if (Session["CodiceResponsabile"] != null) return Session["CodiceResponsabile"];
        string filter = Conn.Security.SelectCondition("manager", true);
        filter = QHS.AppAnd(filter, QHS.CmpEq("active", "S"));
        DataTable Man = Conn.RUN_SELECT("manager", "idman", null, filter, null, false);
        if (Man.Rows.Count >= 1) return Man.Rows[0]["idman"];
        return DBNull.Value;
    }

    void ControllaObbligatorietaResp() {
        object idflowchart = Conn.Security.GetSys("idflowchart");
        if (idflowchart == null || idflowchart == DBNull.Value) return; //Nessuna restrizione
        if (!GestioneClass.UsesAttribues(Conn )) return;
        if (myPrymaryTable.Columns.Contains("idsor01")) return; //ci sono gli attributi, non serve limitare il resp

        bool manager_obbligatorio = true;
        object all_man = Conn.Security.GetUsr("all_man");
        if (all_man != null && all_man.ToString().ToUpper() == "S") manager_obbligatorio = false;


        if (myPrymaryTable.Columns.Contains("idman")) {
            DataColumn C1 = myPrymaryTable.Columns["idman"];
            C1.AllowDBNull = !manager_obbligatorio;
            HelpForm.SetDenyZero(C1, manager_obbligatorio);
            C1.Caption = "Responsabile";
            C1.DefaultValue = CalcDefaultForManager();
        }
        if (myPrymaryTable.Columns.Contains("idmananager")) {
            DataColumn C2 = myPrymaryTable.Columns["idmananager"];
            C2.AllowDBNull = !manager_obbligatorio;
            HelpForm.SetDenyZero(C2, manager_obbligatorio);
            C2.Caption = "Responsabile";
            C2.DefaultValue = CalcDefaultForManager();
        }

    }



    void ControllaObbligatorietaUpb() {
        object idflowchart = Conn.Security.GetSys("idflowchart");
        if (idflowchart == null || idflowchart == DBNull.Value) return; //Nessuna restrizione
        if (!GestioneClass.UsesAttribues(Conn)) return;
        if (myPrymaryTable.Columns.Contains("idsor01")) return; //ci sono gli attributi, non serve limitare il resp
        if (myPrymaryTable.Columns.Contains("idman")) return; //c'è il responsabile, basta limitare quello
        object all_upb = Conn.Security.GetUsr("all_upb");
        if (all_upb != null && all_upb.ToString().ToUpper() == "S") return;

        if (myPrymaryTable.Columns.Contains("idupb")) {
            DataColumn C1 = myPrymaryTable.Columns["idupb"];
            C1.AllowDBNull = false;
        }
    }



		private hwLabel InserisciLabel(DataRow Param,TableCell TCell) {
			hwLabel LB = new hwLabel();
            
			TCell.Controls.Add(LB);
			//LB.Width = ControlWidth;
			//LB.Height = LabelHeight;
			//Leggo la descrizione dal DataRow
			LB.Text = Param["description"].ToString().Trim();
            LB.ID = "lbl" + LabelID;
            LabelID++;
            //LB.Location = (new Point(HPosition,VPosition));
            //LB.TextAlign = ContentAlignment.TopLeft;
            LB.Style.Add("text-align", "left");
            //LB.Style.Add("left", HPosition.ToString());
            //LB.Style.Add("top", VPosition.ToString());
            LB.Style.Add("width", "100%");
            LiteralControl br = new LiteralControl("<br/>");
            TCell.Controls.Add(br);

			return LB;
		}


    private hwTextBox InserisciTextBox(DataRow Param,TableCell TCell)
    {
        hwTextBox TBP = new hwTextBox();
        TCell.Controls.Add(TBP);

        //TBP.Width = ControlWidth;
        //TBP.Height = TextHeight;
        TBP.Style.Add("width", "300px");
        TBP.Style.Add("text-align", "right");
        //TBP.Style.Add("left", HPosition.ToString());
        //TBP.Style.Add("top", VPosition.ToString());
        TBP.ID = Param["paramname"].ToString();
        TBP.Tag = myPrymaryTable.TableName + "." + Param["paramname"].ToString();
        string fmt = Param["tag"].ToString();
        //if (fmt=="")fmt="g";
        if (fmt != null) TBP.Tag += "." + fmt;
        return TBP;
    }

    Type GetTypeFromSysType(string systype)
    {
        systype = systype.ToUpper();

        switch (systype)
        {
            case "BYTE": return typeof(System.Byte);
            case "INT16": return typeof(System.Int16);
            case "INT32": return typeof(System.Int32);
            case "DATETIME": return typeof(System.DateTime);
            case "STRING": return typeof(System.String);
            case "DECIMAL": return typeof(System.Decimal);
            case "DOUBLE": return typeof(System.Double);
            default:
                return typeof(System.String);
        }

    }


    object DefaultForParameter(DataRow Param)
    {
        string TipoDef = Param["hintkind"].ToString().ToUpper();
        DateTime DC = (DateTime)Conn.Security.GetSys("datacontabile");
        switch (TipoDef)
        {
            case "STRING":	//Other
                return Param["hint"].ToString();
            case "1/CURRM":   //Primo giorno del mese
                return new DateTime(DC.Year, DC.Month, 1);
            case "LASTDAY/CURRM":  //Ultimo giorno del mese
                return new DateTime(DC.Year, DC.Month,
                            DateTime.DaysInMonth(DC.Year, DC.Month));
            case "ACCOUNTYEAR": //esercizio corrente
                return Conn.Security.GetSys("esercizio");
            case "NOHINT": //nessun valore predef.
                return DBNull.Value;
            case "1/1": //Primo giorno dell'anno
                return new DateTime(DC.Year, 1, 1);
            case "31/12": //Ultimo giorno dell'anno
                return new DateTime(DC.Year, 12, 31);
            case "ACCOUNTDATE": //Data Contabile
                return DC;
            default:
                return DBNull.Value;

        }

    }

    private void InserisciHelp(string help,TableCell TCell)
    {
        //Text box dell'Help
        hwTextBox TBHelp = new hwTextBox();
        TCell.Controls.Add(TBHelp);
        TCell.Style.Add("vertical-align", "middle");
        //TBHelp.Location = (new Point(HPosition + ControlWidth + 10, VPosition));
        TBHelp.ReadOnly = true;
        TBHelp.Width = ControlWidth;
        TBHelp.TextMode = TextBoxMode.MultiLine;
        TBHelp.ID = "HelpTxt" + HelpTxtID;
        TBHelp.TabIndex = -1;
        HelpTxtID++;
        //TBHelp.Multiline = true;
        //TBHelp.TabStop = false;
        //TBHelp.ScrollBars = ScrollBars.Vertical;
        TBHelp.Height = HelpHeight;
        TBHelp.Text = help;
        TCell.Height = HelpHeight + 15;
    }

    private hwPanel InserisciGroupBox(DataRow Param,TableCell TCell)
    {
        string descr = Param["description"].ToString().Trim();
        return InserisciGroupBox(Param, descr,TCell);
    }

    /// <summary>
    /// Aggiunge un GroupBox
    /// </summary>
    /// <param name="Param">riga di reportparameter</param>
    /// <returns>Il GroupBox creato</returns>
    private hwPanel InserisciGroupBox(DataRow Param, string descr,TableCell TCell)
    {
        hwPanel grp = new hwPanel();
        
        //grp.Name = "gb" + Param["paramname"].ToString();
        grp.ID = "grp"+Param["paramname"].ToString();
        descr = myDA.Security.Compile(descr, true);
        // Dovremmo cercare di inserire un tag <fieldset><legend>descr</legend></fieldset> 
        // all'interno dell'hwpanel
        // Come mettere la label sul groupbox??
        grp.GroupingText = descr;

        if (descr == "") grp.Enabled = false;
        TCell.Controls.Add(grp);
        
        //la riduzione di VPosition serve per l'allineamento con l'help
        //grp.Location = new Point(HPosition, VPosition - 4);
        grp.Height = 41;
        //grp.Width = ControlWidth;
        grp.Style.Add("width", "300px");

        return grp;
    }

    /// <summary>
    /// Aggiunge una ComboBox
    /// </summary>
    /// <param name="Param">riga di reportparameter</param>
    /// <param name="IsAlias">True se la tabella padre esiste già nel DataSet</param>
    private void InserisciCombo(DataRow Param, bool IsAlias,TableCell TCell)
    {

        string tablename = Param["datasource"].ToString();
        string paramname = Param["paramname"].ToString();
        if (IsAlias)
        {
            tablename += AliasCount;
        }
        hwDropDownList CB = new hwDropDownList();
        TCell.Controls.Add(CB);
        //CB.Style.Add()
        //CB.Location = new Point(HPosition, VPosition + LabelHeight);
        //CB.Width = ControlWidth;
        CB.Style.Add("width", "302px");
        //CB.DropDownStyle = ComboBoxStyle.DropDownList;
        CB.ID = paramname;
        CB.Tag = myPrymaryTable.TableName + "." + paramname;
        CB.DataSource = DS.Tables[tablename];
        CB.DataValueField = Param["valuemember"].ToString();
        CB.DataTextField = Param["displaymember"].ToString();
        CB.AutoPostBack = true;
        if ((paramname.IndexOf("level") >= 0) && (Param["hintkind"].ToString().ToUpper() == "NOHINT"))
        {
            ComboToPreset.Add(CB);
        }
    }

    /// <summary>
    /// Verifica se il parametro ha una gestione custom
    /// </summary>
    /// <param name="custom">tag</param>
    /// <returns>True se custom</returns>
    private bool IsCustomField(string custom)
    {
        if (custom == "") return false;
        //per i tipi costant, radio, check, etc... non eseguo nessun controllo
        if (!custom.ToLower().StartsWith("custom")) return true;
        //vedo se c'è una riga in customselection con codice
        string selectioncode = custom.Substring(custom.IndexOf(".") + 1);
        string filter = QHC.CmpEq("selectioncode", selectioncode);
        DataRow[] row = reportVista1.customselection.Select(filter);
        return (row != null);
    }

    /// <summary>
    /// Metodo per la creazione del Form per l'inserimento dei parametri da
    /// passare alle storedprocedure dei Report di stampa.
    /// Questo metodo lavora su due Dataset DS e ReportVista.
    /// </summary>
    /// <param name="ModuleNameReportName">campo modulename di reportparameter</param>
    /// <param name="DA">DataAccess</param>
    /// <returns>True se succesfull</returns>

    public override void BeforeClosing()
    {

    }

    public override void DoCommand(string command) {
        if (command == "stampa") {
            HwButton0_Click(null, null); 
        }
    }

    bool Called = false;
    private void BuildWebReportView() {
        if (Called) return;
        Called = true;
        // ---------------------------------------------------------------------------------------
        Easy_DataAccess Conn = GetVars.GetUserConn(this);
        // carico l'url del server di Reporting Services -----------------------------------------
        DataTable config_reportingservices = Conn.RUN_SELECT("config_reportingservices", "*", null, null, null, false);
        if (config_reportingservices.Rows.Count == 0) return;
        string MyReportServerUrl = config_reportingservices.Rows[0]["reportserverurl"].ToString();
        if (MyReportServerUrl.EndsWith("/")) MyReportServerUrl = MyReportServerUrl.Substring(0, MyReportServerUrl.Length - 1);
        string MyReportPath = config_reportingservices.Rows[0]["reportpath"].ToString();
        // ---------------------------------------------------------------------------------------

        string myReport = "";
        string myQuerystring = "";
        DataTable UserPar = (DataTable)Session["UserPar"];
        if (UserPar == null) return;
        DataRow Params = UserPar.Rows[0];
        foreach (DataColumn c in Params.Table.Columns) {
            if (c.ColumnName == "reportname") {
                myReport = Params[c.ColumnName].ToString();
                continue;
            }
            if (myQuerystring != "") myQuerystring += "&";
            myQuerystring += c.ColumnName + "=" + Params[c.ColumnName].ToString();
        }

        string CodeDepartment = Conn.GetSys("database").ToString();

        var b = DataAccess.CryptString(myQuerystring);
        var logparamCript = QueryCreator.ByteArrayToString(b);

        string url = config_reportingservices.Rows[0]["urlwebreportviewer"].ToString();
        if (!url.EndsWith("/")) url += "/";

        var wb = new WebClient();
        var data = new NameValueCollection {
            ["id"] = Guid.NewGuid().ToString(),
            ["codeDepartment"] = CodeDepartment,
            ["reportName"] = Params["reportname"].ToString(),
            ["parameters"] = logparamCript
        };

        //url = "https://localhost:44317/";

        var response = wb.UploadValues(url + "GetReportInfo.aspx", "POST", data);
        string responseInString = Encoding.UTF8.GetString(response);
        if (responseInString.ToUpperInvariant().StartsWith("OK")) {
	        Response.Redirect(url + "ShowReport.aspx?id=" + data["id"]);
	        return;
        }
        else {
            string mym = "Errore nell'accesso al server dei report {url}.\r";
            mym += "Qualora avesse bisogno di assistenza può contattare il servizio assistenza ";
            Session["CloseWindow"] = true;
            Session["Messaggio"] = mym;
            Response.Redirect("Messaggio.aspx");
            return;
        }

    }


    protected void HwButton0_Click(object sender, EventArgs e)
    {
        if (!CommFun.GetFormData(true)) return;

        DataSet DSCopy = DS.Copy();
        DataRow Params = DSCopy.Tables["resultparameter"].Rows[0];
        ModuleReport = reportVista1.Tables["report"].Rows[0];

        //Hashtable usata solo per EseguiSpDoUpdate
        //Hashtable ReportParams= new Hashtable();			
        foreach (DataColumn C in myPrymaryTable.Columns)
        {
            if (C.ColumnName == DummyPrimaryKey) continue;
            bool Convert = (bool)C.ExtendedProperties["ConvertNullToPerc"];
            Type tipo = Params.Table.Columns[C.ColumnName].DataType;
            if (Convert && (tipo == typeof(string)) && (Params[C.ColumnName].ToString() == ""))
                Params[C.ColumnName] = "%"; //ReportParams[C.ColumnName] ="%";
            //else
            //	ReportParams[C.ColumnName]= Params[C];
        }
        
        // Assegna il responsabile se è presente tra i parametri ed io sono un responsabile
        // Assegna il fornitore se è presente tra i parametri ed io sono un fornitore
        foreach (DataRow DR in reportVista1.Tables["reportparameter"].Rows)
        {
            string paramname = DR["paramname"].ToString();
            string datasource = DR["datasource"].ToString().ToLower();
            string valuemember = DR["valuemember"].ToString().ToLower();

            //if (datasource == "manager" && Session["codiceresponsabile"] != null)
            //{
            //    if (valuemember == "idman")
            //        DSCopy.Tables["resultparameter"].Rows[0][paramname] = Session["codiceresponsabile"];
            //    else
            //        DSCopy.Tables["resultparameter"].Rows[0][paramname] = Session["Responsabile"];
            //}

            if (datasource == "registryreference" && Session["codicefornitore"] != null)
            {
                if(valuemember == "idreg")
                    DSCopy.Tables["resultparameter"].Rows[0][paramname] = Session["codicefornitore"];
                else
                    DSCopy.Tables["resultparameter"].Rows[0][paramname] = Session["Fornitore"];
            }

        }

        DS.AcceptChanges();
        Session["UserPar"] = DSCopy.Tables["resultparameter"];
        Session["ModuleReportRow"] = reportVista1.Tables["report"].Rows[0];

        ApplicationState APS = ApplicationState.GetApplicationState(this);

        object print_rs = Conn.DO_READ_VALUE("report", QHS.CmpEq("reportname", ReportName), "print_rs");
        if (print_rs.ToString().ToUpper() == "S") {
            // Stampa con ReportingServices
            BuildWebReportView();
            return;
        }

        APS.ReturnToCaller(this, false);

    }

    public class GestioneClass {
        public static bool UsesAttribues(IDataAccess Conn) {
            foreach (string s in new string[] { "idsortingkind01", "idsortingkind02", "idsortingkind03",
                            "idsortingkind04", "idsortingkind05" }) {
                if (Conn.Security.GetSys(s) != DBNull.Value) return true;
            }
            return false;
        }

        public static GestioneClass GetGestioneClassForField(string field, DataAccess Conn, string parenttable) {
            if (!UsesAttribues(Conn)) return null;
            string f = field.ToLower().Trim();
            if (f == "idsor01") return new GestioneClass(Conn, 1, parenttable);
            if (f == "idsor02") return new GestioneClass(Conn, 2, parenttable);
            if (f == "idsor03") return new GestioneClass(Conn, 3, parenttable);
            if (f == "idsor04") return new GestioneClass(Conn, 4, parenttable);
            if (f == "idsor05") return new GestioneClass(Conn, 5, parenttable);
            return null;
        }

        bool allowSelection = false;
        public bool AllowSelection() {
            return allowSelection;
        }

        bool allowNull = false;
        public bool AllowNull() {
            return allowNull;
        }

        object defaultValue = DBNull.Value;
        public object DefaultValue() {
            return defaultValue;
        }



        string filterkind = "";
        object filter_sec = null;
        QueryHelper QHS;


        public string GetFilterAutoChoose() {
            string filtercomplete = filterkind;
            if (filter_sec != null) filtercomplete = QHS.AppAnd(filtercomplete, filter_sec.ToString());
            return filtercomplete;
        }

        string btnTag = "";
        public string BtnTag() {
            return btnTag;
        }

        string GetManageTag(string parenttable) {
            return "manage." + parenttable + ".tree";
        }
        string GetChooseTag(string parenttable) {
            string filtercomplete = filterkind;
            if (filter_sec != null) filtercomplete = QHS.AppAnd(filtercomplete, filter_sec.ToString());
            return "choose." + parenttable + ".tree." + filtercomplete;
        }


        public GestioneClass(DataAccess Conn, int N, string parenttable) {
            QHS = Conn.GetQueryHelper();

            object ayear = Conn.GetSys("esercizio");
            string NtoS = N.ToString().PadLeft(2, '0'); //01 02 03 04 05
            string field_getsys_sortkind = "idsortingkind" + NtoS;
            object idsorkind = Conn.GetSys(field_getsys_sortkind);

            if (idsorkind == null || idsorkind == DBNull.Value) {
                allowSelection = false;
                allowNull = true;
                defaultValue = DBNull.Value;
                return;
            }

            filterkind = QHS.CmpEq("idsorkind", idsorkind);


            object idflowchart = Conn.GetSys("idflowchart");
            object ndetail = Conn.GetSys("ndetail");
            object idcustomuser = Conn.GetSys("idcustomuser");

            if (idflowchart == null || idflowchart == DBNull.Value) {
                allowSelection = true;
                allowNull = true;
                defaultValue = DBNull.Value;
                btnTag = GetManageTag(parenttable);
                return;
            }


            object as_filter = Conn.DO_READ_VALUE("uniconfig", null, "sorkind" + NtoS + "asfilter");
            if (as_filter == null || as_filter == DBNull.Value) as_filter = "N";
            object all_value = "S";
            object withchilds = "N";
            if (as_filter.ToString().ToUpper() == "S") {
                all_value = Conn.DO_READ_VALUE("flowchartuser",
                                QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser),
                                            QHS.CmpEq("idflowchart", idflowchart),
                                            QHS.CmpEq("ndetail", ndetail)),
                                " isnull(all_sorkind" + NtoS + ",'S')");
                if (all_value == null || all_value == DBNull.Value) {
                    all_value = "S";
                }
                if (all_value.ToString().ToUpper() == "N") {
                    withchilds = Conn.DO_READ_VALUE("flowchartuser",
                                QHS.AppAnd(QHS.CmpEq("idcustomuser", idcustomuser),
                                            QHS.CmpEq("idflowchart", idflowchart),
                                            QHS.CmpEq("ndetail", ndetail)),
                                " isnull(sorkind" + NtoS + "_withchilds,'N')");
                    if (withchilds == null || withchilds == DBNull.Value) {
                        withchilds = "N";
                    }
                }
            }

            if (all_value.ToString().ToUpper() == "S") {
                allowSelection = true;
                allowNull = true;
                defaultValue = DBNull.Value;
                btnTag = GetManageTag(parenttable);
                return;
            }

            object idsor = Conn.GetSys("idsor" + NtoS);
            if (withchilds.ToString().ToUpper() != "S") {
                allowSelection = false;
                allowNull = false;
                defaultValue = idsor;
                return;
            }
            filter_sec = Conn.GetUsr("cond_sor" + NtoS);
            if (filter_sec != null) {
                string f = filter_sec.ToString().Trim();
                if (f.StartsWith("AND(")) {
                    f = f.Substring(3);
                    filter_sec = f;
                }

                if (f == "(1=1") {
                    f = "";
                    filter_sec = null;
                }

                if (f != "") {
                    f = f.Replace("idsor" + NtoS, "idsor");
                    filter_sec = f;
                }
            }

            btnTag = GetChooseTag(parenttable);
            allowSelection = true;
            allowNull = false;
            defaultValue = idsor;



        }
    }
}
