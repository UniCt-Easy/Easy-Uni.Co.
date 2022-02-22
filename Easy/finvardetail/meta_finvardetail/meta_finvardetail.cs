
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace meta_finvardetail//meta_dettvarbilancio//
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_finvardetail : Meta_easydata {
		public Meta_finvardetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "finvardetail") {
			EditTypes.Add("default");
			EditTypes.Add("single");
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
			ListingTypes.Add("listaestesa");
            ListingTypes.Add("listaweb");
            ListingTypes.Add("bilancio");
            ListingTypes.Add("upb");
            ListingTypes.Add("underwriting");
		}

		protected override Form GetForm(string FormName){
			if (FormName=="default") {
				DefaultListType="listaestesa";
				Name = "Dettaglio variazione";
				return MetaData.GetFormByDllName("finvardetail_default");//PinoRana
			}
			if (FormName=="single") {
				Name = "Dettaglio";
				return MetaData.GetFormByDllName("finvardetail_single");//PinoRana
			}
			return null;
		}			
	
		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yvar", GetSys("esercizio"));
            if (PrimaryTable.Columns.Contains("createexpense"))
                SetDefault(PrimaryTable, "createexpense", "N");
		}
		override public DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{	
            //string filter = "0001";
            //DataTable UPB = T.DataSet.Tables["upb"];
            //if (UPB.Rows.Count ==0)
            //            SetDefault(T, "idupb", filter);
            RowChange.SetSelector(T, "yvar");
            RowChange.SetSelector(T, "nvar");
            RowChange.MarkAsAutoincrement(T.Columns["rownum"], null, null, 6);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;

		}

        public override bool FilterRow(DataRow R, string list_type)
        {
            if ((list_type == "bilancio")||(list_type == "upb"))
            {
                if (R.Table.DataSet.Tables["finvar"] != null)
                {
                    DataTable tFinVar = R.Table.DataSet.Tables["finvar"];
                    string  filterFinVar = QHC.AppAnd(QHC.CmpEq("yvar", R["yvar"]),
                                              QHC.CmpEq("nvar", R["nvar"]));

                    if (tFinVar.Select(filterFinVar).Length > 0)
                    {
                        DataRow rFinVar = tFinVar.Select(filterFinVar)[0];
                        if (CfgFn.GetNoNullInt32(rFinVar["idfinvarstatus"]) != 5) return false;
                    }

                    return true;
                }
                return true;
            }

            return true;
        }

        public override void CalculateFields(System.Data.DataRow R, string listtype) {
            string filterFin = "";
            string filterFinVar = "";
            string filterVariationKind = "";
            string filterVarStatus = "";
            object flagObj = null;
            string flagPrevision = null;
            string flagSecondaryPrev = null;
            string flagCredit = null;
            string flagProceeds = null;
            object variationKind = null;
            object finvarstatus = null;
            bool finInDS = false;
            if (R.Table.DataSet.Tables["fin"] != null) {
                DataTable tFin = R.Table.DataSet.Tables["fin"];
                filterFin = QHC.CmpEq("idfin", R["idfin"]);
                if (tFin.Select(filterFin).Length > 0) {
                    DataRow rFin = tFin.Select(filterFin)[0];
                    flagObj = rFin["flag"];
                    finInDS = true;
                }
            }

            //bool finVarInDS = false;
            if (R.Table.DataSet.Tables["finvar"] != null)
            {
                DataTable tFinVar = R.Table.DataSet.Tables["finvar"];
                filterFinVar = QHC.AppAnd(QHC.CmpEq("yvar", R["yvar"]),
                                          QHC.CmpEq("nvar", R["nvar"]));
                 
                if (tFinVar.Select(filterFinVar).Length > 0)
                {
                    DataRow rFinVar = tFinVar.Select(filterFinVar)[0];
                    flagPrevision = rFinVar["flagprevision"].ToString().ToUpper();
                    flagSecondaryPrev = rFinVar["flagsecondaryprev"].ToString().ToUpper();
                    flagCredit = rFinVar["flagcredit"].ToString().ToUpper();
                    flagProceeds = rFinVar["flagproceeds"].ToString().ToUpper();
                    filterVariationKind = QHC.CmpEq("idvariationkind", rFinVar["variationkind"]);
                    if (listtype == "bilancio" || listtype == "upb") {
                        variationKind = Conn.DO_READ_VALUE("variationkind", filterVariationKind, "description");
                    }
                    //finVarInDS = true;
                }
            }
            if (!finInDS) {
                filterFin = QHS.CmpEq("idfin", R["idfin"]);
                flagObj = Conn.DO_READ_VALUE("fin", filterFin, "flag");
            }

           

            if (flagObj == null) return;
            byte flag = Convert.ToByte(flagObj);
            bool isEntrata = (flag & 1) == 0;

            if (listtype == "default" || listtype == "listaweb" || listtype == "underwriting")
            {
                if (isEntrata)
                {
                    R["!entrata"] = R["amount"];
                }
                else
                {
                    R["!spesa"] = R["amount"];
                }
            }

            if (listtype == "underwriting") {
                filterFinVar = QHS.AppAnd(QHS.CmpEq("yvar", R["yvar"]),
                                          QHS.CmpEq("nvar", R["nvar"]));
                object idfinvarstatus = Conn.DO_READ_VALUE("finvar", filterFinVar, "idfinvarstatus");
                filterVarStatus = QHS.CmpEq("idfinvarstatus", idfinvarstatus);
                finvarstatus = Conn.DO_READ_VALUE("finvarstatus", filterVarStatus, "description");
                R["!finvarstatus"] = finvarstatus;
            }

            if ((listtype == "bilancio") || (listtype == "upb"))
            {
                if (isEntrata)
                {
                    R["!E/S"] = "E";
                }
                else
                {
                    R["!E/S"] = "S";
                }
                if (flagPrevision == "S") R["!prev_competenza"] = R["amount"];
                if (flagSecondaryPrev == "S") R["!prev_cassa"] = R["amount"];
                if (flagCredit == "S") R["!crediti"] = R["amount"];
                if (flagProceeds == "S") R["!cassa"] = R["amount"];
                R["!variationkind"] = variationKind;
            }
            if (listtype == "listaweb")
            {
                if (R["limit"] != DBNull.Value) {
                    decimal amount = CfgFn.GetNoNullDecimal(R["amount"]);
                    decimal limit = CfgFn.GetNoNullDecimal(R["limit"]);
                    if (amount > limit)
                        R["!semaphore"] = "<center><img src=\"Immagini/red_light.gif\"></center>";
                    else
                        R["!semaphore"] = "<center><img src=\"Immagini/green_light.gif\"></center>";
                }
                else {
                    R["!semaphore"] = "";
                }
            }
		}
		
		public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="default") {
                foreach (DataColumn C in T.Columns){
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "!codicebilancio", "Voce di bilancio", "fin.codefin", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "!entrata", "Entrata", nPos++);
                DescribeAColumn(T, "!spesa", "Spesa", nPos++);
                DescribeAColumn(T, "!upb", "U.P.B.", "upb.codeupb", nPos++);
                DescribeAColumn(T, "!finanziamento", "Finanziamento", "underwriting.title", nPos++);
                ComputeRowsAs(T, listtype);
			}
            if (listtype == "underwriting")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "nvar", "Num. Prot.", nPos++);
                DescribeAColumn(T, "!finvarstatus", "Stato", nPos++);
                DescribeAColumn(T, "!codicebilancio", "Voce di bilancio", "fin.codefin", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "!entrata", "Entrata", nPos++);
                DescribeAColumn(T, "!spesa", "Spesa", nPos++);
                DescribeAColumn(T, "!upb", "U.P.B.", "upb.codeupb", nPos++);
                DescribeAColumn(T, "!finanziamento", "Finanziamento", "underwriting.title", nPos++);
                ComputeRowsAs(T, listtype);
            }
			if (listtype=="lista") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "yvar", "Eserc. variaz.", nPos++);
                DescribeAColumn(T, "nvar", "Num. variaz.", nPos++);
                DescribeAColumn(T, "descvariazione", "Desc. variazione", nPos++);
                DescribeAColumn(T, "provvedimento", "Provvedimento", nPos++);
                DescribeAColumn(T, "numprovved", "Num. provv.", nPos++);
                DescribeAColumn(T, "dataprovved", "Data provv.", nPos++);
                DescribeAColumn(T, "datacontabile", "Data cont.", nPos++);
			}

            if (listtype == "listaweb")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "!codicebilancio", "Voce di bilancio", "fin.codefin", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "!entrata", "Entrata", nPos++);
                DescribeAColumn(T, "!spesa", "Spesa", nPos++);
                DescribeAColumn(T, "!upb", "U.P.B.", "upb.codeupb", nPos++);
                DescribeAColumn(T, "!finanziamento", "Finanziamento", "underwriting.title", nPos++);
                DescribeAColumn(T, "limit", "Limite Variazione", nPos++);
                DescribeAColumn(T, "!semaphore", "Limite Superato", "fin.limit", nPos++);
                ComputeRowsAs(T, listtype);
            }

            if (listtype == "bilancio")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "!variationkind", "Tipo Var.", nPos++);
                DescribeAColumn(T, "nvar", "Num. Prot.", nPos++);
                DescribeAColumn(T, "!nofficial", "Num. Var. Uff.", "finvar.nofficial", nPos++);
                DescribeAColumn(T, "!upb", "U.P.B.", "upb.codeupb", nPos++);
                DescribeAColumn(T, "!finanziamento", "Finanziamento", "underwriting.title", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                if (CfgFn.NomePrevisionePrincipale(Conn) != null)
                     DescribeAColumn(T, "!prev_competenza", "Prev. " + CfgFn.NomePrevisionePrincipale(Conn), nPos++);
                if (CfgFn.NomePrevisioneSecondaria(Conn)!= null)
                     DescribeAColumn(T, "!prev_cassa", "Prev. " + CfgFn.NomePrevisioneSecondaria(Conn), nPos++);
                DescribeAColumn(T, "!crediti", "Dot. Crediti", nPos++);
                DescribeAColumn(T, "!cassa", "Dot.Cassa", nPos++);
                ComputeRowsAs(T, listtype);
                FilterRows(T);
            }

            if (listtype == "upb")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "!variationkind", "Tipo Var.", nPos++);
                DescribeAColumn(T, "nvar", "Num. Prot.", nPos++);
                DescribeAColumn(T, "!nofficial", "Num. Var. Uff.", "finvar.nofficial", nPos++);
                DescribeAColumn(T, "!E/S", "E/S", nPos++);
                DescribeAColumn(T, "!codicebilancio", "Voce di bilancio", "fin.codefin", nPos++);
                DescribeAColumn(T, "!finanziamento", "Finanziamento", "underwriting.title", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                if (CfgFn.NomePrevisionePrincipale(Conn) != null)
                    DescribeAColumn(T, "!prev_competenza", "Prev. " + CfgFn.NomePrevisionePrincipale(Conn), nPos++);
                if (CfgFn.NomePrevisioneSecondaria(Conn) != null)
                    DescribeAColumn(T, "!prev_cassa", "Prev. " + CfgFn.NomePrevisioneSecondaria(Conn), nPos++);
                DescribeAColumn(T, "!crediti", "Dot. Crediti", nPos++);
                DescribeAColumn(T, "!cassa", "Dot.Cassa", nPos++);
                ComputeRowsAs(T, listtype);
                FilterRows(T);
            }
		}   

        public override bool IsValid(DataRow R, out string errmess, out string errfield){            
            if (!base.IsValid(R, out errmess, out errfield)) return false;                 
			if (R["amount"]==DBNull.Value){
				errmess="Attenzione! L'importo non può essere nullo.";
				errfield="amount";
				return false;
			}
			if (CfgFn.GetNoNullInt32(R["idfin"])==0){
				errmess="Attenzione! La voce di bilancio non può essere nulla.";
                errfield = "finview.codefin";
				return false;
			}
            if (CfgFn.GetNoNullDecimal(R["limit"]) < 0){
                errmess = "Il limite non può essere negativo.";
                errfield = "limit";
                return false;
            }
            DataRelation Rfound = null;
            foreach (DataRelation Rp in PrimaryDataTable.ParentRelations){
                if (Rp.ParentTable.TableName != "finvar")continue;
                Rfound=Rp;
                break;
            }
            if (Rfound==null)return true;
            DataRow ParentRow = R.GetParentRow(Rfound);
            if (ParentRow==null) {
                errmess="E' necessario selezionare una variazione";
                errfield="nvar";
                return false;
            }
			return true;
        }


		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="listaestesa")
				return base.SelectOne(ListingType, filter, "finvardetailview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "finvardetail", Exclude);
		}		

	}
}
