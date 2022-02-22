
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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using metadatalibrary;
using metaeasylibrary;

namespace EasyWebReport
{
	/// <summary>
	/// Summary description for InserisciParametri.
	/// </summary>
	public partial class InserisciParametriExp : System.Web.UI.Page
	{
		WebControl[] TxtBoxArr;


        void LeggiParametri() {
            DataAccess Conn = GetVars.GetUserConn(this);
            DataTable Params;
            //Si ricarica dalla Session il Dataset di GetParamFromDB
            Params = (DataTable)Session["ParamData"];
            if (Params != null) Params.RejectChanges();
            DataTable UserPar = (DataTable)Session["UserPar"];
            if (Params == null) return;
            if (UserPar == null) return;
            DataRow Par = UserPar.Rows[0];

            int i = 0;
            foreach (DataRow drParam in Params.Rows) {
                if (drParam["selectioncode"].ToString() == "costant.hidden") continue;
                string paramname = drParam["paramname"].ToString();
                i++;
                if (IsParamLocked(drParam)) continue;
                //Myid è il nome dato al controllo nella webpage 
                string myId = drParam["__WebControlID"].ToString();

                //Leggo i parametri inseriti dall'utente e li memorizzo in variabili di sessione
                //Attenzione: se si tratta di una combo
                string UserValue = (string)Request.Form[myId];
                object ResValue = DBNull.Value; //valore decodificato

                if (drParam["iscombobox"].ToString().ToUpper() == "S") {
                    //Legge la tabella che carica la combo
                    DataTable dtCombo = GetDataTableXcombo(drParam);
                    if (dtCombo != null) {
                        DataRow[] DtComboFiltrata = dtCombo.Select((drParam["displaymember"].ToString() + " = " +
                            QueryCreator.quotedstrvalue(UserValue, true)));
                        if (DtComboFiltrata.Length > 0) {
                            //legge il combocodefield che mi serve per la stored procedure
                            //l'utente a video vedeva invece il combodescfield
                            ResValue = DtComboFiltrata[0][drParam["valuemember"].ToString()];
                        }
                        else
                            ResValue = UserValue;
                    }
                }
                else {
                    string tag = "x.y." + drParam["tag"].ToString();
                    DataColumn C = UserPar.Columns[paramname];
                    ResValue = HelpForm.GetObjectFromString(C.DataType, UserValue, tag);
                }
                if (((ResValue == null) || (ResValue.ToString() == "") || (ResValue.ToString()== "%" )) &&
                    (drParam["noselectionforall"].ToString().ToLower() == "s"))
                {
                    if ((GetTypeFromSysType(drParam["systype"].ToString()) == typeof(int))){
                        ResValue = DBNull.Value;
                    }
                    else {
                        ResValue = "%";
                    }
                }

                if (ResValue == null || (ResValue.ToString() == "")) ResValue = DBNull.Value;
                //Nella colonna ParamValue della Table dei parametri memorizzo il valore inserito dal'utente
                Par[paramname] = ResValue;
            }
        }

        void CreaPaginaParametri() {
            DataAccess Conn = GetVars.GetUserConn(this);
            DataTable Params;

            GetParamfromDB();		//Leggo i parametri del report dal DB e imposta var. di sessione
            Params = (DataTable)Session["ParamData"];
            if (Params == null) return;
            DataTable UserPar = (DataTable)Session["UserPar"];
            if (UserPar == null) return;
            DataRow Par = UserPar.Rows[0];

            TxtBoxArr = new WebControl[15];

            //Disegno la tabella dei parametri
            Table1.Width = 800;
            Table1.BorderStyle = BorderStyle.Solid;
            //Table1.BackColor = Color.LightSteelBlue;


            int CountParam = 0;
            foreach (DataRow MyRowParam in Params.Rows) {
                if (MyRowParam["selectioncode"].ToString() == "costant.hidden") continue;
                CountParam++; //Incrementa il contatore di parametri che mi server per generare gli ID dei controlli
                //Aggiunge una riga alla tabella
                TableRow tRow = new TableRow();
                Table1.Rows.Add(tRow);
                //Aggiunge una cella	
                TableCell tCell1 = new TableCell();
                tRow.Cells.Add(tCell1);
                tCell1.Width = 200;
                tCell1.Font.Bold = true;
                //tCell1.BackColor = Color.LightSteelBlue;
                tCell1.Font.Size = FontUnit.Small;
                tCell1.Text = MyRowParam["description"].ToString();  //Descrizione del parametro


                //Nome parametro
                string ParamName = MyRowParam["paramname"].ToString();
                string FlagCombo = MyRowParam["iscombobox"].ToString();
                bool FlagNoSelection = MyRowParam["noselectionforall"].ToString().ToUpper() == "S";
                if (IsParamLocked(MyRowParam)) {

                    TableCell tCell2 = new TableCell();
                    tRow.Cells.Add(tCell2);

                    //Crea una TextBox
                    TextBox myTextBox = new TextBox();

                    //Memorizza la TextBox nell'array di TextBox
                    //TxtBoxArr[countTxt] = myTextBox;
                    myTextBox.Width = 220;
                    tCell2.Controls.Add(myTextBox);
                    MyRowParam["__WebControlID"] = myTextBox.UniqueID;
                    MyRowParam.AcceptChanges();
                    /////////////////////////////////////////////////////////////////////////////////
                    ///Attenzione: Inserire in questa sezione i controlli per il blocco dei parametri
                    //Controllo per Responsabile
                    if (MyRowParam["datasource"].ToString().ToLower() == "manager") {
                        myTextBox.ReadOnly = true;
                        myTextBox.BackColor = System.Drawing.Color.LightGray;
                        myTextBox.Text = Session["Responsabile"].ToString();
                        if (MyRowParam["valuemember"].ToString() == "idman")
                            Par[ParamName] = Session["codiceresponsabile"];
                        else
                            Par[ParamName] = Session["Responsabile"];

                        continue;
                    }

                    if (MyRowParam["datasource"].ToString().ToLower() == "registryreference") {
                        myTextBox.ReadOnly = true;
                        myTextBox.BackColor = System.Drawing.Color.LightGray;
                        myTextBox.Text = Session["Fornitore"].ToString();
                        myTextBox.Width = 300;
                        if (MyRowParam["valuemember"].ToString() == "idreg")
                            Par[ParamName] = Session["codicefornitore"];
                        else
                            Par[ParamName] = Session["Fornitore"];
                        continue;
                    }

                }

                if (FlagCombo.ToUpper() == "S") {
                    //////////////////Aggiunge una DropDownList
                    TableCell tCell2 = new TableCell();
                    tRow.Cells.Add(tCell2);
                    //Crea una dropDownList
                    DropDownList myDropList = new DropDownList();
                    tCell2.Controls.Add(myDropList);
                    DataTable myDtCombo;
                    MyRowParam["__WebControlID"] = myDropList.UniqueID;
                    MyRowParam.AcceptChanges();

                    //Esegue la select per leggere i valori da visualizzare nella dropDownList
                    myDtCombo = GetDataTableXcombo(MyRowParam);
                    foreach (DataRow drCombo in myDtCombo.Rows) {
                        string myValue = drCombo[MyRowParam["displaymember"].ToString()].ToString();
                        if (myValue.Trim() == "") continue;
                        myDropList.Items.Add(myValue);
                    }

                    if (FlagNoSelection) {
                        myDropList.Items.Add("%");
                        myDropList.SelectedValue = "%";
                    }
                    if ((ParamName.ToLower().IndexOf("livello") >= 0 || ParamName.ToLower().IndexOf("level") >= 0)
                        && (MyRowParam["hintkind"].ToString().ToUpper() == "NOHINT")
                        ) {
                        if (myDropList.Items.Count > 0) myDropList.SelectedIndex = 1;
                    }
                    if (MyRowParam["hintkind"].ToString().ToUpper() != "NOHINT") {
                        try {
                            object def = DefaultForParameter(MyRowParam);
                            DataRow[] Val = myDtCombo.Select(MyRowParam["valuemember"].ToString() +
                                "=" + QueryCreator.quotedstrvalue(def, false));
                            if ((Val != null) && (Val.Length > 0)) {
                                myDropList.SelectedValue = Val[0][MyRowParam["displaymember"].ToString()].ToString();
                            }

                            //int NNN = 0;
                            //foreach (DataRow drCombo2 in myDtCombo.Rows) {
                            //    string myValue = drCombo2[0].ToString();
                            //    if (myValue.Trim() == "")
                            //        continue;
                            //    if (myValue == def.ToString()) {
                            //        myDropList.SelectedIndex = NNN;
                            //        break;
                            //    }
                            //    NNN++;
                            //}
                        }
                        catch (Exception E) {
                            QueryCreator.MarkEvent(QueryCreator.GetErrorString(E));
                        };

                    }
                    else {
                        myDropList.SelectedIndex = myDropList.Items.Count - 1;
                    }





                }
                else {
                    //////////////////Aggiunge una TextBox

                    TableCell tCell2 = new TableCell();
                    tRow.Cells.Add(tCell2);

                    //Crea una TextBox
                    TextBox myTextBox = new TextBox();

                    //Memorizza la TextBox nell'array di TextBox
                    //TxtBoxArr[countTxt] = myTextBox;
                    myTextBox.Width = 220;
                    tCell2.Controls.Add(myTextBox);
                    MyRowParam["__WebControlID"] = myTextBox.UniqueID;
                    MyRowParam.AcceptChanges();

                    string tag = "x.y" + MyRowParam["tag"].ToString();

                    //Inserisce il valore di default del parametro
                    myTextBox.Text = HelpForm.StringValue(
                        DefaultForParameter(MyRowParam), tag);

                   // myTextBox.ID = "IdParam" + CountParam;  //Assegna un nome ID alla TextBox;


                    ///////////////////////////////////////////////////////////////////////////////////

                    //////////////////Aggiunge la cella di Help
                    TableCell tCell3 = new TableCell();
                    tCell3.Width = 400;
                    tCell3.Font.Size = FontUnit.XSmall;
                    //tCell3.BackColor = Color.LightSteelBlue;
                    tRow.Cells.Add(tCell3);
                    tCell3.Text = MyRowParam["help"].ToString();

                }
            }
        }


        protected void Page_Load(object sender, System.EventArgs e) {
            //WebLog.Log(this,"Visualizza InserisciParametri");


            //labCurrUser.Text = System.Environment.UserName+" (Network= "+System.Environment.UserDomainName+")";
            if (IsPostBack) {
                LeggiParametri();

            }
            else {
                CreaPaginaParametri();

            }

        }
		

		private bool IsParamLocked(DataRow Param) {
			if (Param["iscombobox"].ToString().ToLower()=="n") return false;
			string table= Param["datasource"].ToString().ToLower();
			string tipoutente = Session["tipoutente"] as string;
			if ((tipoutente=="responsabile") && (table == "manager"))return true;
			if ((tipoutente=="fornitore") && (table == "registryreference"))return true;
			return false;
		}

        const string DummyPrimaryKey = "DummyPrimaryKeyField";

		/// <summary>
		/// Create primary table in DS and assign to "myPrimaryTable"
		/// </summary>
		/// <param name="ReportParameters"></param>
		void CreatePrimaryTable(DataRow[] ReportParameters){
			DataTable myPrymaryTable = new DataTable("resultparameter");
			
			//Create a dummy primary key
			DataColumn DCPK = new DataColumn(DummyPrimaryKey,typeof(string));
			DCPK.DefaultValue = "HIRES";
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
				//Col.AllowDBNull = (Param["hintkind"].ToString()=="NOHINT") || ConvertNullToPerc;
                Col.AllowDBNull = true;

				myPrymaryTable.Columns.Add(Col);
			}
			DataSet DS = new DataSet();
			DS.Tables.Add(myPrymaryTable);
			DataRow ParRow = myPrymaryTable.NewRow();
			myPrymaryTable.Rows.Add(ParRow);
			Session["UserPar"] = myPrymaryTable;
		}

		private void GetParamfromDB() {
			DataRow MR= Session["ExportRow"] as DataRow;
			if (MR==null) return;
            TitoloExp.Text = MR["Description"].ToString();
			DataAccess Conn = GetVars.GetUserConn(this);
			if (Conn==null) return;
			string filterpar= "("+
                "procedurename=" + QueryCreator.quotedstrvalue(MR["procedurename"], true) + ")";
            DataTable Params = Conn.RUN_SELECT("exportfunctionparam", "*", "number asc", filterpar, null, true);
			if(Params == null)return;
            Params.Columns.Add("__WebControlID", typeof(string));
            //Dataset di Sessione
			Session["Paramdata"] = Params;
			//Crea la tabella per inserire i parametri dell'utente
            CreatePrimaryTable(Params.Select(null, "number asc"));
			//Aggiunge la colonna ParamValue che mi servirà per conservare il valore inserito dall'utente
			//Params.Columns.Add("ParamValue",GetTypeFromUserFormat(Params["userformat"].ToString()));
	
		}
		/// <summary>
		/// Col1:ComboCodeField     Col2:ComboDescField
		/// </summary>
		/// <param name="myRowParam"></param>
		/// <returns></returns>
		private DataTable GetDataTableXcombo(DataRow myRowParam) {
            DataAccess Conn = GetVars.GetUserConn(this);
            if (Conn == null) return null;

            string Filter = myRowParam["filter"].ToString().Trim();
            if (Filter != "")
            {
                Filter = Conn.Compile(Filter, true);
            }
            string sort = "";
            if (myRowParam["datasource"].ToString().ToLower().IndexOf("level") >= 0)
            {
                sort = myRowParam["valuemember"].ToString();
            }

            //Aggiunge filtro su esercizio se chiave primaria contiene
            // un campo di nome esercizio
            //if (QueryCreator.IsPrimaryKey(datasource, "ayear")) {
            //    Filter = GetData.MergeFilters(Filter, "(ayear='" +Conn.GetSys("esercizio").ToString() + "')");
            //}

            string ComboTable = myRowParam["datasource"].ToString();
            string ComboCodeField = myRowParam["valuemember"].ToString().ToLower();
            string comboDescField = myRowParam["displaymember"].ToString();
            QueryHelper QHS = Conn.GetQueryHelper();

            if (ComboTable.ToLower() == "upb")
            {
                if (Session["codiceresponsabile"] != null && Session["codiceresponsabile"].ToString() != "")
                {
                    Filter = QHS.AppAnd(Filter, QHS.CmpEq("idman", Session["codiceresponsabile"]));
                }
                if (comboDescField == "codeupb")
                {
                    comboDescField = "SUBSTRING(codeupb+'-'+title,1,50) AS codedescr";
                    myRowParam["displaymember"] = "codedescr";
                }
                sort = "printingorder";

            }
            if (ComboTable.ToLower() == "fin")
            {
                if (Session["codiceresponsabile"] != null && Session["codiceresponsabile"].ToString() != "")
                {
                    Filter = QHS.AppAnd(Filter, QHS.CmpEq("idman", Session["codiceresponsabile"]));
                    DataTable FV = Conn.RUN_SELECT("finusable", "idfin", null, Filter, null, false);
                    Filter = QHS.FieldIn("idfin", FV.Select());
                }
                if (comboDescField == "codefin")
                {
                    comboDescField = "SUBSTRING(codefin+'-'+title,1,50) AS codedescr";
                    myRowParam["displaymember"] = "codedescr";
                }
                sort = "printingorder";

            }

            if (Filter == "") Filter = null;
            if (sort == "") sort = comboDescField;

            //string mySelectCombo = "SELECT distinct(" + ComboCodeField + ") AS " + ComboCodeField;
            string mySelectCombo = "SELECT * ";

            if (ComboTable.ToLower() == "fin" || ComboTable.ToLower() == "upb") mySelectCombo += ", " + comboDescField;
            /*
            if (sort != null) {
                if (mySelectCombo.IndexOf(sort) < 0) mySelectCombo += "," + sort;
            }
            */
            //if (ComboTable.ToLower() == "upb") mySelectCombo += ", idman";
            mySelectCombo += " FROM " + ComboTable;
            if (Filter != null) mySelectCombo += " WHERE " + Filter;
            if (sort != null) mySelectCombo += " ORDER BY " + sort;
            DataTable TCombo = Conn.SQLRunner(mySelectCombo, true);

            //DataTable TCombo = Conn.RUN_SELECT(ComboTable, "*", sort, Filter, null, false);

            TCombo.TableName = ComboTable.ToLower();

            Conn.DeleteAllUnselectable(TCombo);
            return TCombo;
        }

        protected void btnVisualizzaReport_Click(object sender, EventArgs e) {
            //Response.Redirect("ExportView.aspx");
            Response.Redirect("RedirectPage.htm?A='IndiceReport.aspx?folder=3'&B='ExportView.aspx'");
        }
        protected void btnNewIndex_Click(object sender, EventArgs e) {
            Response.Redirect("IndiceReport.aspx?folder=3");

        }
			
		#region Gestione tipo parametri



		
		object DefaultForParameter(DataRow Param){
			DataAccess myDA = GetVars.GetUserConn(this);
			string TipoDef = Param["hintkind"].ToString().ToUpper();
			DateTime DC = (DateTime) myDA.GetSys("datacontabile");
			switch(TipoDef){
				case "STRING":	//Other
					return Param["hint"].ToString();
				case "1/CURRM":   //Primo giorno del mese
					return new DateTime(DC.Year, DC.Month, 1);
				case "LASTDAY/CURRM":  //Ultimo giorno del mese
					return new DateTime(DC.Year, DC.Month, 
						DateTime.DaysInMonth(DC.Year, DC.Month));
				case "ACCOUNTYEAR": //esercizio corrente
					return myDA.GetSys("esercizio");
				case "NOHINT": //nessun valore predef.
					return DBNull.Value;
				case "1/1": //Primo giorno dell'anno
					return new DateTime(DC.Year,1,1);
				case "31/12": //Ultimo giorno dell'anno
					return new DateTime(DC.Year,12,31);
				case "ACCOUNTDATE": //Data Contabile
					return DC;
				default:
					return DBNull.Value;

			}

		}

		System.Type GetTypeFromSysType(string systype) {
			systype=systype.ToUpper();

			switch(systype) {
                case "BYTE": return typeof(System.Byte);
                case "INT16": return typeof(System.Int16);
                case "INT32": return typeof(System.Int32); 
				case "DATETIME": return typeof(System.DateTime); 
				case "STRING": return typeof(System.String); 
				case "DECIMAL":return typeof(System.Decimal);
				case "DOUBLE":return typeof(System.Double);
				default:
					return typeof(System.String);
			}

		}

		#endregion



		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
