/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_creditpart {//meta_assegnazionecrediti//
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_creditpart : Meta_easydata {
		public Meta_creditpart(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "creditpart") {
			EditTypes.Add("default");
			EditTypes.Add("detail");
			EditTypes.Add("assegnazioneautomatica");
			EditTypes.Add("variazione");
			ListingTypes.Add("default");
			ListingTypes.Add("lista");
			ListingTypes.Add("detail");
			ListingTypes.Add("assegnautomatica");
			Name = "Assegnazione credito al bilancio";
		}
		protected override Form GetForm(string FormName) {
			if (FormName=="default") {
				DefaultListType="lista";
				Name = "Assegnazione credito";
				return MetaData.GetFormByDllName("creditpart_default");//PinoRana
			}
			
			if (FormName=="detail"){
				return MetaData.GetFormByDllName("creditpart_detail");//PinoRana
			}


			if (FormName=="variazione"){
				return MetaData.GetFormByDllName("creditpart_detail");
			}

			if (FormName=="assegnazioneautomatica"){
				Name = "Generazione automatismi crediti";
				return MetaData.GetFormByDllName("creditpart_assegnazioneautomatica");//PinoRana
			}
			
			return null;
		}			

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
			RowChange.SetSelector(T, "ycreditpart");
			RowChange.MarkAsAutoincrement(T.Columns["ncreditpart"],null,
				null,7);
			DataRow R = base.Get_New_Row(ParentRow, T);
			if (edit_type=="default") R["ncreditpart"]=-1;
			return R;
		}

		
		public override void DescribeColumns(DataTable T, string listtype) {
			base.DescribeColumns(T, listtype);
			if (listtype=="detail"){
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
                int nPos = 1;
				DescribeAColumn(T, "ycreditpart", "Eserc. assegn.",nPos++);
				DescribeAColumn(T, "ncreditpart", "Num. assegn.",nPos++);
                DescribeAColumn(T, "!codeupb", "Cod. UPB.", "upbcrediti.codeupb", nPos++);
                DescribeAColumn(T, "!upb", "UPB.", "upbcrediti.title", nPos++);
                DescribeAColumn(T, "!codbil", "Voce bil.", "bilanciocrediti.codefin", nPos++);
                DescribeAColumn(T, "!denombil", "Denom. bil.", "bilanciocrediti.title", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);
			}

			if (listtype=="assegnautomatica"){
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				DescribeAColumn(T,"!codicebilancio","Bilancio");
                DescribeAColumn(T, "!codeupb", "UPB", "upb.codeupb");
				DescribeAColumn(T, "amount", "Importo");
			}

		}   

		
		public override void SetDefaults(DataTable T) {
			base.SetDefaults(T);
			SetDefault(T,"ycreditpart",GetSys("esercizio").ToString());
			SetDefault(T,"adate", GetSys("datacontabile"));
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			if (ListingType=="default")
				return base.SelectOne(ListingType, filter, "creditpart", Exclude);
			else
				return base.SelectOne(ListingType, filter, "creditpartview", Exclude);
		}

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (CfgFn.GetNoNullInt32(R["idfin"]) == 0) {
                errmess = "Attenzione! La voce di bilancio non può essere nulla.";
                errfield = "idfin";
                return false;
            }
            if (R["idupb"].ToString().Trim() == "")
            {
                errmess = "Attenzione! L'UPB non può essere nullo.";
                errfield = "idupb";
                return false;
            }
            return true;
        }
	}
}