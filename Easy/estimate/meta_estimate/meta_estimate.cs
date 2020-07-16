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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace meta_estimate//meta_Contratto di Vendita//
{
	/// <summary>
	/// </summary>
	public class Meta_estimate : Meta_easydata {
		public Meta_estimate(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "estimate") {
			EditTypes.Add("default");
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
            ListingTypes.Add("flussostudenti");
        }

		public override void SetDefaults(DataTable PrimaryTable){
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yestim", GetSys("esercizio"));
			SetDefault(PrimaryTable, "docdate", GetSys("datacontabile"));
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
			SetDefault(PrimaryTable, "officiallyprinted", "N");
            SetDefault(PrimaryTable, "idcurrency", Conn.DO_READ_VALUE("currency", QHS.CmpEq("codecurrency", "EUR"), "idcurrency"));
            SetDefault(PrimaryTable, "exchangerate", 1);
            SetDefault(PrimaryTable, "active", "S");
            SetDefault(PrimaryTable, "flagintracom", "N");
		}

        public override void DescribeColumns(DataTable T, string ListingType) {
            foreach (DataColumn C in T.Columns)
                DescribeAColumn(T, C.ColumnName, "", -1);
            int nPos = 1;
            DescribeAColumn(T, "estimkind", "Tipo Contratto attivo", nPos++);
            DescribeAColumn(T, "yestim", "Esercizio", nPos++);
            DescribeAColumn(T, "nestim", "Numero", nPos++);
            DescribeAColumn(T, "description", "Descrizione", nPos++);
            DescribeAColumn(T, "doc", "Documento", nPos++);
            DescribeAColumn(T, "docdate", "Data doc.", nPos++);
            DescribeAColumn(T, "adate", "Data reg.", nPos++);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			RowChange.SetSelector(T, "yestim");
			//string tiponumerazione = T.ExtendedProperties["tiponumerazione"].ToString();
			/*if (tiponumerazione=="A") {
				//string middleconst=GetSys("esercizio").ToString().Substring(2,2)+"/";
					RowChange.MarkAsAutoincrement(T.Columns["nestim"], null, null, 6);
                    SetDefault(T, "nestim", -10);
			}
			else {
				int nmax = CfgFn.GetNoNullInt32(
						Conn.DO_READ_VALUE("estimate", "(yestim="+
							QueryCreator.quotedstrvalue(GetSys("esercizio"),true)+")", "MAX(nestim)"))+1;
				SetDefault(T,"nestim", nmax);
			}*/

			RowChange.SetSelector(T, "idestimkind");
			DataRow R = base.Get_New_Row(ParentRow, T);
            /*int N = MetaData.MaxFromColumn(T, "nestim");
            if (tiponumerazione == "A") {
                if (N < 99990000)
                    N = 99990000;
                else
                    N = N + 1;
                R["nestim"] = N;
            }*/
       	
			return R;
		}

		protected override Form GetForm(string FormName){
			Name="Contratto attivo";
			DefaultListType="lista";
			if (FormName=="default") return MetaData.GetFormByDllName("estimate_default");
			return null;
		}			

		protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
			if ((C.ColumnName == "yestim") || (C.ColumnName == "nestim"))return;
			base.InsertCopyColumn (C, Source, Dest);
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if ((ListingType == "lista")||(ListingType=="default")) 
				return base.SelectOne(ListingType, filter, "estimateview", Exclude);
			return base.SelectOne(ListingType, filter, "estimate", Exclude);
		}

      
        public override bool IsValid(DataRow R, out string errmess, out string errfield){
			
			
			

            if (R["idestimkind"].ToString()=="") {
                errmess = "Il codice tipo contratto Ë obbligatorio";
                errfield = "idestimkind";
                return false;
            }


            if ((R["doc"].ToString() == "")&&(R["cigcode"].ToString() != "")) {
                errmess = "Il documento collegato in presenza di Codice CIG Ë obbligatorio";
                errfield = "doc";
                return false;
            }


            object multireg = Conn.DO_READ_VALUE("estimatekind",  QHS.CmpEq("idestimkind", R["idestimkind"]), "multireg");
            if (multireg == null || multireg == DBNull.Value) multireg = "N";

            if ((CfgFn.GetNoNullInt32(R["idreg"])== 0) && (multireg.ToString() != "S"))
			{
				errmess="Il 'Cliente' Ë obbligatorio";
				errfield="idreg";
				return false;
			}
 
            if (CfgFn.GetNoNullInt32(R["idcurrency"]) == 0) {
                errmess = "Il campo 'Valuta' Ë obbligatorio";
                errfield = "idcurrency";
                return false;
            }
            if ((R["cigcode"].ToString() != "") && (R["cigcode"].ToString().Length != 10)) {
                errmess = "Il CIG deve avere lunghezza 10.";
                errfield = "cigcode";
                return false;
            }
            if ((R["cigcode"].ToString() != "") && !CfgFn.IsValidString(R["cigcode"].ToString())) {
                errmess = "Il CIG contiene caratteri non validi.I caratteri ammessi sono solo numeri e lettere";
                errfield = "cigcode";
                return false;
            }
            if ((R.RowState==DataRowState.Added) && (!RowChange.IsAutoIncrement(R.Table.Columns["nestim"]))){
				int NPRESENT = Conn.RUN_SELECT_COUNT("estimate","(idestimkind="+QueryCreator.quotedstrvalue(R["idestimkind"],true)+")AND" + 
                    "(yestim="+QueryCreator.quotedstrvalue(R["yestim"],true)+")AND"+
					"(nestim="+QueryCreator.quotedstrvalue(R["nestim"],true)+")",true);
				if (NPRESENT>0){
					errmess="Esiste gi‡ un Contratto attivo con lo stesso numero.";
					errfield= "nestim";
					return false;
				}
			}

            if (R.Table.DataSet.Tables.Contains("estimatedetail")) {
                DataTable md = R.Table.DataSet.Tables["estimatedetail"];
                if (md.Columns.Contains("idepacc")) {
                    if (R["active"].ToString() != "S") {
                        if (md.Select(QHC.IsNotNull("idepacc")).Length > 0) {
                            errmess =
                                "Operazione non consentita in presenza di accertamenti di budget.\r\n" +
                                "Occorre procedere con l'annullamento dei dettagli del contratto con apposizione della data di annullamento.";
                            errfield = "active";
                            return false;
                        }
                    }
                }
            }

            if (!base.IsValid(R, out errmess, out errfield)) return false;
            return true;
		}
	}
}
