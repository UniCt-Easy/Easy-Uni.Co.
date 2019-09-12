/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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


namespace meta_provisiondetail 
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_provisiondetail : Meta_easydata {
		public Meta_provisiondetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "provisiondetail") {
			EditTypes.Add("default");
			EditTypes.Add("single");
			ListingTypes.Add("default");
            ListingTypes.Add("lista");
        }

		protected override Form GetForm(string FormName){
		
			if (FormName=="single") {
				Name = "Dettaglio";
				return MetaData.GetFormByDllName("provisiondetail_single"); 
			}
            if (FormName == "default") {
                Name = "Dettaglio";
                return MetaData.GetFormByDllName("provisiondetail_default"); 
            }
            return null;
		}

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile").ToString());
            SetDefault(PrimaryTable, "ydetail", Conn.GetEsercizio());
        }
        override public DataRow Get_New_Row(DataRow ParentRow, DataTable T)
		{	
            RowChange.SetSelector(T, "idprovision");
            RowChange.MarkAsAutoincrement(T.Columns["rownum"], null, null, 6);
			DataRow R = base.Get_New_Row(ParentRow, T);
			return R;

		}

       	
		public override void DescribeColumns(DataTable T, string listtype){
			base.DescribeColumns(T, listtype);
			if (listtype=="lista") {
                foreach (DataColumn C in T.Columns){
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
			    DescribeAColumn(T, "ydetail", "Anno dettaglio", nPos++);
                DescribeAColumn(T, "rownum", "#", nPos++);
                DescribeAColumn(T, "description", "Descr. dettaglio", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);
            }
        
		}   

        public override bool IsValid(DataRow R, out string errmess, out string errfield){            
            if (!base.IsValid(R, out errmess, out errfield)) return false;                 
			if (R["amount"]==DBNull.Value){
				errmess="Attenzione! L'importo non può essere nullo.";
				errfield="amount";
				return false;
			}

            if (R["adate"] == DBNull.Value) {
                errmess = "Attenzione! Non è stata inserita la data contabile.";
                errfield = "adate";
                return false;
            }

            DateTime adate = (DateTime) R["adate"];
            if (adate.Year != CfgFn.GetNoNullInt32(R["ydetail"])) {
                errmess = "La data contabile deve essere coerente con l'anno della variazione.";
                errfield = "adate";
                return false;
            }

            if (R["description"] == DBNull.Value) {
                errmess = "Attenzione! Non è stata inserita la descrizione.";
                errfield = "description";
                return false;
            }
            DataRelation Rfound = null;
            foreach (DataRelation Rp in PrimaryDataTable.ParentRelations){
                if (Rp.ParentTable.TableName != "provision")continue;
                Rfound=Rp;
                break;
            }
            if (Rfound==null)return true;
            DataRow ParentRow = R.GetParentRow(Rfound);
            if (ParentRow==null) {
                errmess="E' necessario selezionare un fondo accantonamento";
                errfield="nvar";
                return false;
            }
			return true;
        }


		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="default")
				return base.SelectOne(ListingType, filter, "provisiondetailview", Exclude);
			else
				return base.SelectOne(ListingType, filter, "provisiondetail", Exclude);
		}		

	}
}
