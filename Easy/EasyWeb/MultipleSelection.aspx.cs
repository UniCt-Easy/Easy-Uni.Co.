/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using metadatalibrary;

public partial class MultipleSelection : System.Web.UI.Page
{

    MetaData linked;
    DataSet myDS;
    DataTable ToAdd;
    DataTable Added;
    DataTable SourceTable;
    DataAccess Conn;

    string tablename;
    string sorting;
    string filter;
    string filterSQL;
    string listingtype;
    string notentitychildfilter;
    string entitychildfilter;
    Hashtable HT;
    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        ApplicationState AppState = ApplicationState.GetApplicationState(this);
        PageState PState = AppState.SetRunningPage(this) as MetaPageState;

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        //PageState PS = PageState.getPageState(this);

        MetaData MD = (MetaData)Session["MetaToPass"];        

        HT = MD.ExtraParameter as Hashtable;
        linked = (MetaData)HT["RealMeta"];
        Conn = linked.Conn;
        Page.Title = (string)HT["FormTitle"];
        labAdded.Text = (string)HT["LabelAdded"];
        labToAdd.Text = (string)HT["LabelToAdd"];
        SourceTable = (DataTable)HT["NotEntityChildTable"];
        filter = (string)HT["Filter"];
        filterSQL = (string)HT["FilterSQL"];
        listingtype = (string)HT["ListingType"];
        tablename = DataAccess.GetTableForReading(SourceTable);

        linked.MarkTableAsNotEntityChild(SourceTable);
        notentitychildfilter = SourceTable.ExtendedProperties["NotEntityChild"].ToString();
        entitychildfilter = "NOT(" + notentitychildfilter + ")";

        if (!IsPostBack) {
            InitTables();
        }
        else {
            Added = (DataTable)HT["Added"];
            ToAdd = (DataTable)HT["ToAdd"];
            SetDataTable(ToAdd, GridToAdd);
            SetDataTable(Added, GridAdded);

        }

    }

    public void SetDataTable(DataTable T, Panel Plc)
    {
        Plc.Controls.Clear();

        Table myTable = new Table();
        Page myPage = this.Page;
        myTable.Rows.Clear();
        myTable.ID = "Table_" + Plc.ID;
        int[] orderedcols = GetOrderedColumns(T);


        myTable.Font.Size = 9;

        myTable.BorderWidth = 0;
        myTable.CellSpacing = 0;
        myTable.CellPadding = 0; 


        TableRow TR_Intestazione = new TableRow();
        TR_Intestazione.TableSection = TableRowSection.TableHeader;
        myTable.Rows.Add(TR_Intestazione);
        AggiungiTitoli(TR_Intestazione, T,orderedcols);
        int CountRiga = 0;
        int i;

        for (i = 0; i < T.Rows.Count; i++)
        {
            DataRow myDataRow = T.Rows[i];
            if (myDataRow.RowState == DataRowState.Deleted) continue;
            AddTableRow(myTable, myDataRow, i, orderedcols,Plc.ID);
        }
        Plc.ScrollBars = ScrollBars.Auto;
        myTable.CssClass = "to_pgrid";
        Plc.Controls.Add(myTable);
    }

    private void AggiungiTitoli(TableRow myTr, DataTable T,int[] orderedcols)
    {

        int CountTitoli = 1;
        
        TableCell TC_Empty = new TableCell(); // Cella vuota per i checkbox
        myTr.Cells.Add(TC_Empty);

        for (int i = 0; i < orderedcols.Length; i++)
        {
            DataColumn C = T.Columns[orderedcols[i]];
            TableCell TC_Titolo = new TableCell();
            //TC_Titolo.ID = "TitoloGrid_" + CountTitoli.ToString();
            TC_Titolo.Text = "<p style='margin-left:13;margin-right:0;margin-top:0;margin-bottom:0'>"+ 
                C.Caption + "</p>";
            myTr.Cells.Add(TC_Titolo);

            CountTitoli++;

        }

    }

    int[] GetOrderedColumns(DataTable T)
    {

        int[] allcol = new int[T.Columns.Count];
        for (int i = 0; i < allcol.Length; i++) allcol[i] = -1;
        int nassigned = 0;
        if ((T.Columns.Count == 0) || (T.Columns[0].ExtendedProperties["ListColPos"] == null))
        {
            for (int i = 0; i < T.Columns.Count; i++) allcol[i] = i;
            return allcol;
        }
        for (int i = 0; i < T.Columns.Count; i++)
        {
            try
            {
                DataColumn C = T.Columns[i];
                if (C.Caption == "") continue;
                if (C.Caption.StartsWith(".")) C.Caption = " ";

                int col_pos = Convert.ToInt32(C.ExtendedProperties["ListColPos"]);
                if (col_pos != -1)
                {
                    allcol[col_pos] = i;
                    nassigned++;
                }
            }
            catch
            {
            }
        }
        int[] cols = new int[nassigned];
        int actualpos = 0;
        for (int i = 0; i < T.Columns.Count; i++)
        {
            if (allcol[i] >= 0)
            {
                cols[actualpos] = allcol[i];
                actualpos++;
            }
        }


        return cols;
    }

    private void AddTableRow(Table T, DataRow myDataRow,
        int NumeroRiga, int[] orderedcols,string PanelId)
    {
        if (T == null) return;
        if (myDataRow == null) return;

        DataTable TT = myDataRow.Table;

        //Nuova Riga
        TableRow TR1 = new TableRow();
        //TR1.Height = 24;
        T.Rows.Add(TR1);


        if ((NumeroRiga & 1) == 0)
        {
            TR1.CssClass = "odd";
        }

        TableCell T_Chk = new TableCell();
        hwCheckBox HwC = new hwCheckBox();
        HwC.ID = "Chk_Selector_"+PanelId+"_"+NumeroRiga;

        HwC.Tag = NumeroRiga.ToString();
        T_Chk.Controls.Add(HwC);
        TR1.Cells.Add(T_Chk);

        for (int i = 0; i < orderedcols.Length; i++)
        {
            DataColumn C = TT.Columns[orderedcols[i]];
            //Aggiungo tutte le celle.
            TableCell TC1 = new TableCell();
            TC1.Text = GetValoreFormattato(myDataRow, C.ColumnName, HelpForm.GetFormatForColumn(C));
            System.Windows.Forms.HorizontalAlignment HA = HelpForm.GetAlignForColumn(C);
            if (HA == System.Windows.Forms.HorizontalAlignment.Right)
            {
                TC1.HorizontalAlign = HorizontalAlign.Right;
            }
            else
            {
                TC1.HorizontalAlign = HorizontalAlign.Left;
            }
            TR1.Cells.Add(TC1);
        }

    }

    private string GetValoreFormattato(DataRow R, string field, string fmt)
    {
        string tag = "x.y." + fmt; 
        return HelpForm.StringValue(R[field], tag);
    }

    void InitTables()
    {
        myDS = new DataSet();
        myDS.EnforceConstraints = false;

        string columnlist = QueryCreator.SortedColumnNameList(SourceTable);

        Added = Conn.CreateTableByName(tablename, columnlist);
        Added.TableName = "added";
        Added.Namespace = SourceTable.Namespace;

        myDS.Tables.Add(Added);
        DataAccess.SetTableForReading(Added, tablename);
        CopyKeyWhenBlank(SourceTable, Added);

        ToAdd = Conn.CreateTableByName(tablename, columnlist);
        ToAdd.TableName = "toadd";
        myDS.Tables.Add(ToAdd);
        DataAccess.SetTableForReading(ToAdd, tablename);
        CopyKeyWhenBlank(SourceTable, ToAdd);

        //Riempie la Table delle righe "ToAdd" prendendole dal DB. Questa tabella 
        // contiene anche righe gi‡ "added" in memoria, che vanno quindi escluse. 
        //Inoltre va integrata con righe che erano "added" e sono state rimosse
        // in memoria
        DataAccess.RUN_SELECT_INTO_TABLE(Conn, ToAdd, sorting, filterSQL, null, true);

        //Riempie la Table delle righe "Added". Questa contiene anche righe che sono
        // state rimosse in memoria, e quindi vanno rimosse (e integrate a "ToAdd")
        QueryCreator.MergeDataTable(Added, SourceTable);

        //Per tutte le righe rimosse in memoria (che rispettano il filtro): le toglie da 
        // Added e le mette in ToAdd.
        string tomovefilter = GetData.MergeFilters(notentitychildfilter, filter);
        DataRow[] RowsToMove = Added.Select(tomovefilter);
        foreach (DataRow ToMove in RowsToMove)
        {
            string verifyexistentfilter = QueryCreator.WHERE_KEY_CLAUSE(ToMove,
                    DataRowVersion.Default, false);
            //Just for sure I remove from ToAdd those rows I'm going to add to it!
            DataRow[] ToRemoveFromToAdd = ToAdd.Select(verifyexistentfilter);
            foreach (DataRow ToRemFromToAdd in ToRemoveFromToAdd)
            {
                ToRemFromToAdd.Delete();
                ToRemFromToAdd.AcceptChanges();
            }
            //Adds the row to ToAdd
            AddRowToTable(ToAdd, ToMove);

            //Remove the row from Added
            ToMove.Delete();
            if (ToMove.RowState != DataRowState.Detached) ToMove.AcceptChanges();

        }


        //Per tutte le righe rimosse in memoria rimanenti (ossia che NON rispettano
        // il filtro) : le rimuovo da Added
        DataRow[] ToRemoveFromAdded = Added.Select(notentitychildfilter);
        foreach (DataRow ToRemFromAdded in ToRemoveFromAdded)
        {
            ToRemFromAdded.Delete();
            if (ToRemFromAdded.RowState != DataRowState.Detached) ToRemFromAdded.AcceptChanges();
        }

        //Per tutte le righe rimaste in Added: le rimuove da ToAdd
        DataRow[] ToRemoveFromToAdd2 = Added.Select();
        foreach (DataRow ToRemFromToAdd in ToRemoveFromToAdd2)
        {
            string ToRemKeyFilter = QueryCreator.WHERE_KEY_CLAUSE(ToRemFromToAdd, DataRowVersion.Default, false);
            DataRow[] ToRemove = ToAdd.Select(ToRemKeyFilter);
            foreach (DataRow ToRem in ToRemove)
            {
                ToRem.Delete();
                if (ToRem.RowState != DataRowState.Detached) ToRem.AcceptChanges();
            }
        }
        MetaData M = linked.Dispatcher.Get(tablename);
        M.DescribeColumns(ToAdd, listingtype);
        M.DescribeColumns(Added, listingtype);

        HT["Added"] = Added;
        HT["ToAdd"] = ToAdd;
        SetDataTable(ToAdd, GridToAdd);
        SetDataTable(Added, GridAdded);

    }


    DataRow AddRowToTable(DataTable T, DataRow R)
    {
        DataRow NewRow = T.NewRow();
        foreach (DataColumn C in T.Columns)
        {
            if (!R.Table.Columns.Contains(C.ColumnName)) continue;
            NewRow[C.ColumnName] = R[C.ColumnName];
        }
        T.Rows.Add(NewRow);
        NewRow.AcceptChanges();
        return NewRow;
    }

    void RimuoviRighe()
    {
        int nrows = Added.Rows.Count;
        ArrayList Selected = new ArrayList();
        ArrayList ToRemoveFromAdded = new ArrayList();

        for (int index = 0; index < nrows; index++)
        {
            hwCheckBox HwC = GridAdded.FindControl("Chk_Selector_" + GridAdded.ID + "_" + index) as hwCheckBox;
            if (HwC == null) continue;
            if (HwC.Checked == true) Selected.Add(index);
        }

        foreach (int index in Selected)
        {
            //Prende una riga selezionata
            //gridAdded.CurrentRowIndex = index;
            //DataRowView CurrDV = (DataRowView)gridToAdd.BindingContext[myDS, Added.TableName].Current;
            DataRow Curr = Added.Rows[index];
            ToRemoveFromAdded.Add(Curr);

            //La  aggiunge a ToAdd
            AddRowToTable(ToAdd, Curr);
        }

        //Rimuove tutte le righe da Added
        foreach (DataRow ToRemove in ToRemoveFromAdded)
        {
            ToRemove.Delete();
            if (ToRemove.RowState != DataRowState.Detached) ToRemove.AcceptChanges();
        }
        UpdateSourceTable();
    }

    void CheckUnceckAllCheckBoxes(Control C,bool check) {
        if (typeof(hwCheckBox).IsAssignableFrom(C.GetType())) {
            hwCheckBox CC = C as hwCheckBox;
            CC.Checked = check;
        }
        if (C.HasControls()) {
            foreach (Control child in C.Controls) CheckUnceckAllCheckBoxes(child, check);
        }
    }
    void AggiungiTutti()
    {
        //Seleziona tutto e chiama Aggiungi Righe
        CheckUnceckAllCheckBoxes(GridToAdd, true);
        AggiungiRighe();
    }

    void AggiungiRighe()
    {
        int nrows = ToAdd.Rows.Count;
        ArrayList Selected = new ArrayList();
        ArrayList ToRemoveFromToAdd = new ArrayList();

        for (int index = 0; index < nrows; index++)
        {
            hwCheckBox HwC = GridToAdd.FindControl("Chk_Selector_" + GridToAdd.ID + "_" + index) as hwCheckBox;
            if (HwC == null) continue;
            if(HwC.Checked==true) Selected.Add(index);
        }

        /*
        foreach (hwCheckBox hwC in GridToAdd.Controls)
        {
            if (hwC.Checked == true)
            {
                int i = Int32.Parse(hwC.Tag);
                Selected.Add(i);
            }
        }
        */

        foreach (int index in Selected)
        {
            DataRow Curr = ToAdd.Rows[index];
            ToRemoveFromToAdd.Add(Curr);

            //La  aggiunge ad Added
            AddRowToTable(Added, Curr);
        }

        //Rimuove tutte le righe da ToAdd
        foreach (DataRow ToRemove in ToRemoveFromToAdd)
        {
            ToRemove.Delete();
            if (ToRemove.RowState != DataRowState.Detached) ToRemove.AcceptChanges();
        }
        UpdateSourceTable();
    }

    void UpdateSourceTable()
    {
        //Scollega le righe presenti in ToAdd, ove presenti in SourceTable
        DataRow[] ToAddRows = ToAdd.Select();
        foreach (DataRow ToUnlinkRow in ToAddRows)
        {
            string unlinkkeyfilter = QueryCreator.WHERE_KEY_CLAUSE(ToUnlinkRow,
                            DataRowVersion.Default, false);
            DataRow[] ToUnlinkRows = SourceTable.Select(unlinkkeyfilter);
            if (ToUnlinkRows.Length == 0) continue;
            DataRow ToUnlink = ToUnlinkRows[0];
            linked.UnlinkDataRow(ToUnlink);
        }

        //Collega le righe presenti in Added, aggiungendole se non presenti
        DataRow[] AddedRows = Added.Select();
        foreach (DataRow ToLinkRow in AddedRows)
        {
            string linkkeyfilter = QueryCreator.WHERE_KEY_CLAUSE(ToLinkRow,
                        DataRowVersion.Default, false);
            DataRow[] TolinkRows = SourceTable.Select(linkkeyfilter);
            DataRow AddedRow;
            if (TolinkRows.Length == 0)
            {
                //La riga va aggiunta
                AddedRow = AddRowToTable(SourceTable, ToLinkRow);
            }
            else
            {
                AddedRow = TolinkRows[0];
            }
            linked.CheckEntityChildRowAdditions(AddedRow, null);
        }
        // Qui vanno rifatti i SetDataTable
        SetDataTable(ToAdd, GridToAdd);
        SetDataTable(Added, GridAdded);

    }

    protected void btnAdd_Click(object sender, System.EventArgs e)
    {
        AggiungiRighe();
    }

    protected void btnRemove_Click(object sender, System.EventArgs e)
    {
        RimuoviRighe();
    }


    void CopyKeyWhenBlank(DataTable Source, DataTable T)
    {
        if ((T.PrimaryKey != null) &&
            (T.PrimaryKey.Length > 0)) return;

        DataColumn[] NewKey = new DataColumn[Source.PrimaryKey.Length];
        for (int i = 0; i < Source.PrimaryKey.Length; i++)
        {
            NewKey[i] = T.Columns[Source.PrimaryKey[i].ColumnName];
        }
        T.PrimaryKey = NewKey;
    }

    protected void btnSelAllToAdd_Click(object sender, EventArgs e)
    {
        CheckUnceckAllCheckBoxes(GridToAdd, true);

    }
    protected void btnSelAllAdded_Click(object sender, EventArgs e)
    {
        CheckUnceckAllCheckBoxes(GridAdded, true);
        return;
    }
    protected void btnUnSelAllToAdd_Click(object sender, EventArgs e)
    {
        CheckUnceckAllCheckBoxes(GridToAdd, false);
        
    }
    protected void btnUnSelAllAdded_Click(object sender, EventArgs e)
    {
        CheckUnceckAllCheckBoxes(GridAdded, false);
    }
    protected void btnClose_Click(object sender, EventArgs e) {
        Session["MetaToPass"] = null;
        ApplicationState.GetApplicationState(this).ReturnToCaller(this, true);
    }

    /*
    public override void DoCommand(string command) {
        base.DoCommand(command);
        if (command == "do_close") {
            btnClose_Click(null, null);
        }
        if (command == "do_unselalladded") {
            btnUnSelAllAdded_Click(null, null);
        }

        if (command == "do_unselalltoadd") btnUnSelAllToAdd_Click(null, null);
        if (command == "do_selalladded") btnSelAllAdded_Click(null, null);
        if (command == "do_selalltoadd") btnSelAllToAdd_Click(null, null);

        if (command == "do_remove") btnRemove_Click(null, null);
        if (command == "do_add") btnAdd_Click(null, null);
    }
     */
}
